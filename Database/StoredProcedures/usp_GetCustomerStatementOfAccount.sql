/*
    dbo.usp_GetCustomerStatementOfAccount
    SQL Server 2012 or later (the EDMX provider version is 2012).

    Deployment
    ----------
    Run this script in the intended database using a client that supports GO.
    This is a first-install CREATE script. If the procedure already exists,
    change CREATE PROCEDURE to ALTER PROCEDURE before deployment.
    No deployment or execution was performed when preparing this file.

    Sources and relationships verified in GeneralLedgerContext.edmx
    -------------------------------------------------------------
    dbo.Customer.Id (int) -> dbo.Sales.intIdCustomer.
    dbo.Sales.Id -> dbo.Collection.SalesId (one invoice per collection).
    dbo.Sales.Id -> dbo.AccountReceivableAdjustments.SalesId.
    dbo.AccountsReceivableAdjustmentsType.Id
        -> dbo.AccountReceivableAdjustments.AccountsReceivableAdjustmentsTypeId.
    A return check also references its original Collection through CollectionId.
    Use its explicit adjustment SalesId for invoice allocation; CollectionId is
    context, not an additional payment or a second adjustment allocation.

    SalesCustomerLedger is a mirror of these source transactions. The services
    use intIdSalesCustomerLedgerTransctionType (spelling as stored) as follows:
      1 = sale,       TotalAmount copied from Sales.Total;
      2 = collection, TotalAmount copied from Collection.Total;
      3 = adjustment, TotalAmount copied from the adjustment.TotalAmount.
    TotalAmount is not a universally signed balance movement. In particular,
    return sales store an amount that their default GL entry credits to AR.
    Source transactions are used once; ledger rows and GL/detail rows are not
    added to them. This also avoids relying on stale ledger invoice links:
    UpdateDebitCreditMemo updates the source SalesId but not ledger.intIdSales.

    Code evidence (repository-relative paths)
    -----------------------------------------
    GeneralLedger.Persistence/Services/SaleServices.cs:
        AddSalesCustomerLedger, UpdateSalesCustomerLedger.
    GeneralLedger.Persistence/Services/CollectionServices.cs:
        Add, Update, Remove; collections subtract from invoice receivables.
    GeneralLedger.Persistence/Services/AccountReceivableAdjustmentsServices.cs:
        AddReturnCheck: default AR debit, increasing receivables.
        AddReturnSales: default AR credit, reducing receivables.
        AddDebitCreditMemo / UpdateDebitCreditMemo: amount copied unchanged.
    GeneralLedger/UserControls/frmAccountReceivableAdjustments*.cs:
        lookup names RETURN CHECK, RETURN SALES, DEBIT MEMO, CREDIT MEMO.
    Memo sign convention was clarified by the user: both types store positive
    amounts; debit memos increase AR and credit memos reduce AR.

    Calculation and result contract
    -------------------------------
    OutstandingBalance = OriginalInvoiceAmount - TotalPaymentsApplied
                         + TotalAdjustments.
    TotalAdjustments is signed: RETURN CHECK / DEBIT MEMO add; RETURN SALES /
    CREDIT MEMO subtract. Type IDs are resolved by the existing lookup names,
    not assumed identity values. Unknown/missing types and negative adjustment
    amounts on eligible invoices cause an explicit error rather than a guessed
    sign. Additional adjustment types need an established rule before inclusion.
    Payments and adjustments are independently grouped by SalesId before joining
    the invoice, preventing multiplication across their one-to-many relations.

    Returns one result set with one row per Sales.Id, ordered by invoice date,
    invoice number, then Sales.Id to break ties. InvoiceNumber is Sales.TRANo,
    kept as text to preserve leading zeroes. DueDate is exactly 60 calendar days
    after Sales.TransactionDate, regardless of customer or invoice Terms.
    Amounts use decimal(28,4): the four fractional digits of existing money
    columns are preserved, with additional aggregate capacity. Format/round for
    presentation after summing; no string formatting is applied here.
    NULL amounts are zero. NULL transaction dates cannot satisfy the cutoff.

    @IncludeFullyPaid = 0 returns positive balances (overdue and not yet due).
    @IncludeFullyPaid = 1 also returns zero and negative/overpaid balances.
    This follows the service convention that a balance <= 0 is settled.
    Sales.IsFullyPaid, LastPaymentDate, IsSalesReturn and Collection.RunningBalance
    are current-state fields and are not used to determine historical balances.
    Sum the returned OutstandingBalance column for the report's total due.

    Confirmed scope and historical limitations
    ------------------------------------------
    Only invoices and their directly allocated transactions are included.
    Customer-only adjustments without SalesId are excluded, as requested; no
    inferred allocation or fallback through CollectionId / the ledger is made.
    Customer opening balances (e.g. curStartingDebit) are not invoice records
    and are excluded. The total covers invoice-linked activity only and may
    differ from an overall customer ledger containing unallocated balances.
    TransactionDate <= @StatementDate is the inclusive business-date cutoff on
    every source. Transactions after that date cannot affect this statement.
    There is no separate posting-status column in these source entities.
    As confirmed, the report uses the currently surviving records and dates;
    later edits, deletions and backdated transactions can change a rerun of an
    earlier statement. It cannot recreate overwritten/deleted versions or a
    historical posting-time snapshot. Ledger.DateInserted is not audit history.

    Index review
    ------------
    The EDMX exposes primary keys/FKs but no nonclustered index definitions;
    no index DDL was found in the repository and no live catalog was inspected.
    No index changes are included. Only if a deployment execution plan shows
    scans that need attention, check existing indexes before considering:
      Sales (intIdCustomer, TransactionDate) INCLUDE (TRANo, Total)
      Collection (SalesId, TransactionDate) INCLUDE (Total)
      AccountReceivableAdjustments (SalesId, TransactionDate)
          INCLUDE (AccountsReceivableAdjustmentsTypeId, TotalAmount)
    Sales.Id and lookup Id are declared primary keys in the EDMX. Review whether
    Id is already available as the clustering key before adding it to coverage.

    Examples (documentation only; not executed)
    -------------------------------------------
    EXEC dbo.usp_GetCustomerStatementOfAccount
        @CustomerID = 123, @StatementDate = '20261016', @IncludeFullyPaid = 0;

    EXEC dbo.usp_GetCustomerStatementOfAccount
        @CustomerID = 123, @StatementDate = '20261016', @IncludeFullyPaid = 1;
*/
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO

CREATE PROCEDURE dbo.usp_GetCustomerStatementOfAccount
    @CustomerID INT,
    @StatementDate DATE,
    @IncludeFullyPaid BIT = 0
AS
BEGIN
    SET NOCOUNT ON;

    IF @CustomerID IS NULL OR @StatementDate IS NULL
    BEGIN
        ;THROW 50001, 'CustomerID and StatementDate are required.', 1;
    END;

    IF @IncludeFullyPaid IS NULL
    BEGIN
        ;THROW 50002, 'IncludeFullyPaid must be 0 or 1.', 1;
    END;

    -- The application selects these same names from the adjustment-type lookup.
    DECLARE @AdjustmentTypeSigns TABLE
    (
        AdjustmentTypeID INT NOT NULL PRIMARY KEY,
        BalanceSign SMALLINT NOT NULL
    );

    INSERT INTO @AdjustmentTypeSigns (AdjustmentTypeID, BalanceSign)
    SELECT
        t.Id,
        CASE UPPER(LTRIM(RTRIM(t.Name)))
            WHEN N'RETURN CHECK' THEN 1
            WHEN N'DEBIT MEMO' THEN 1
            WHEN N'CREDIT MEMO' THEN -1
            WHEN N'RETURN SALES' THEN -1
        END
    FROM dbo.AccountsReceivableAdjustmentsType AS t
    WHERE UPPER(LTRIM(RTRIM(t.Name))) IN
        (N'RETURN CHECK', N'DEBIT MEMO', N'CREDIT MEMO', N'RETURN SALES');

    -- Validate only adjustments allocated to this customer's eligible invoices.
    -- Unallocated and future-dated adjustments are outside this statement.
    IF EXISTS
    (
        SELECT 1
        FROM dbo.AccountReceivableAdjustments AS a
        INNER JOIN dbo.Sales AS s ON s.Id = a.SalesId
        LEFT JOIN @AdjustmentTypeSigns AS ats
            ON ats.AdjustmentTypeID = a.AccountsReceivableAdjustmentsTypeId
        WHERE s.intIdCustomer = @CustomerID
          AND s.TransactionDate <= @StatementDate
          AND a.TransactionDate <= @StatementDate
          AND (ats.AdjustmentTypeID IS NULL OR a.TotalAmount < 0)
    )
    BEGIN
        ;THROW 50003, 'An invoice-linked adjustment has an unsupported/missing type or a negative amount. Review its accounting rule before generating this statement.', 1;
    END;

    ;WITH Invoices AS
    (
        SELECT
            s.Id AS SalesID,
            s.TransactionDate AS InvoiceDate,
            s.TRANo AS InvoiceNumber,
            CONVERT(DECIMAL(28,4), ISNULL(s.Total, 0)) AS OriginalInvoiceAmount
        FROM dbo.Sales AS s
        WHERE s.intIdCustomer = @CustomerID
          AND s.TransactionDate <= @StatementDate
    ),
    PaymentTotals AS
    (
        SELECT
            c.SalesId,
            CONVERT(DECIMAL(28,4),
                SUM(CONVERT(DECIMAL(28,4), ISNULL(c.Total, 0))))
                AS TotalPaymentsApplied
        FROM dbo.Collection AS c
        INNER JOIN Invoices AS i ON i.SalesID = c.SalesId
        WHERE c.TransactionDate <= @StatementDate
        GROUP BY c.SalesId
    ),
    AdjustmentTotals AS
    (
        SELECT
            a.SalesId,
            CONVERT(DECIMAL(28,4),
                SUM(CONVERT(DECIMAL(28,4), ISNULL(a.TotalAmount, 0))
                    * ats.BalanceSign)) AS TotalAdjustments
        FROM dbo.AccountReceivableAdjustments AS a
        INNER JOIN Invoices AS i ON i.SalesID = a.SalesId
        INNER JOIN @AdjustmentTypeSigns AS ats
            ON ats.AdjustmentTypeID = a.AccountsReceivableAdjustmentsTypeId
        WHERE a.TransactionDate <= @StatementDate
        GROUP BY a.SalesId
    ),
    InvoiceAmounts AS
    (
        SELECT
            i.SalesID,
            i.InvoiceDate,
            i.InvoiceNumber,
            i.OriginalInvoiceAmount,
            ISNULL(p.TotalPaymentsApplied, CONVERT(DECIMAL(28,4), 0))
                AS TotalPaymentsApplied,
            ISNULL(a.TotalAdjustments, CONVERT(DECIMAL(28,4), 0))
                AS TotalAdjustments
        FROM Invoices AS i
        LEFT JOIN PaymentTotals AS p ON p.SalesId = i.SalesID
        LEFT JOIN AdjustmentTotals AS a ON a.SalesId = i.SalesID
    ),
    InvoiceBalances AS
    (
        SELECT
            ia.SalesID,
            ia.InvoiceDate,
            ia.InvoiceNumber,
            ia.OriginalInvoiceAmount,
            ia.TotalPaymentsApplied,
            ia.TotalAdjustments,
            CONVERT(DECIMAL(28,4), ia.OriginalInvoiceAmount
                - ia.TotalPaymentsApplied + ia.TotalAdjustments)
                AS OutstandingBalance
        FROM InvoiceAmounts AS ia
    )
    SELECT
        InvoiceDate,
        DATEADD(DAY, 60, InvoiceDate) AS DueDate,
        InvoiceNumber,
        OriginalInvoiceAmount,
        TotalPaymentsApplied,
        TotalAdjustments,
        OutstandingBalance
    FROM InvoiceBalances
    WHERE @IncludeFullyPaid = 1 OR OutstandingBalance > 0
    ORDER BY InvoiceDate, InvoiceNumber, SalesID;
END;
GO
