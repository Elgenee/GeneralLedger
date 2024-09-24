using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using GeneralLedger.Tier.BO;
using GeneralLedger.Tier.BAL;
using System.Globalization;
using GeneralLedger.Persistence.Services;
using GeneralLedger.Core.Domain;

namespace GeneralLedger.UserControls
{
    public partial class frmAccountReceivableAdjustmentsReturnSales : MetroUserControl
    {
        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }
        public AccountReceivableAdjustment AccountReceivableAdjustment { get; set; }
        public AccountReceivableAdjustmentsServices AccountReceivableAdjustmentsServices { get; set; }
        public AccountReceivableAdjustmentsDetailServices AccountReceivableAdjustmentsDetailServices { get; set; }
        public AccountsReceivableAdjustmentsTypeServices AccountsReceivableAdjustmentsTypeServices { get; set; }

        public tblTBBatchHdrServices tblTBBatchHdrServices { get; set; }
        public GLTranServices GLTranServices { get; set; }
        public List<tblGLTranDetail> GLTranDetail { get; set; }

        public List<tblGLTranDetail> GLTranDetailInventoryEntry { get; set; }

        public int ID { get; set; }

        public int SaleId { get; set; }
        public int IndexGrid { get; set; }
        public int IndexGridInventory { get; set; }
        public int GLTranHeader { get; set; }

        public List<AccountReceivableAdjustmentsDetail> AccountReceivableAdjustmentsDetailList { get; set; }

        public frmAccountReceivableAdjustmentsReturnSales()
        {
            AccountsReceivableAdjustmentsTypeServices = new AccountsReceivableAdjustmentsTypeServices();
            AccountReceivableAdjustmentsServices = new AccountReceivableAdjustmentsServices();
            AccountReceivableAdjustmentsDetailServices = new AccountReceivableAdjustmentsDetailServices();
            GLTranServices = new GLTranServices();
            GLTranDetail = new List<tblGLTranDetail>();
            AccountReceivableAdjustmentsDetailList = new List<AccountReceivableAdjustmentsDetail>();
            AccountReceivableAdjustment = new AccountReceivableAdjustment();
            tblTBBatchHdrServices = new tblTBBatchHdrServices();
            InitializeComponent();
        }

        private void frmAccountReceivableAdjustmentsReturnSales_Load(object sender, EventArgs e)
        {
            var accountReceivableAdjustmentTpesList = AccountsReceivableAdjustmentsTypeServices.GetAll()
                .Where(a => a.Name.ToUpper().Equals("RETURN SALES"))
                .ToList();
            this.cbAdjustmentType.DataSource = accountReceivableAdjustmentTpesList;
            this.cbAdjustmentType.ValueMember = "ID";
            this.cbAdjustmentType.DisplayMember = "Name";
        }

        private void btnSearchSale_Click(object sender, EventArgs e)
        {
            try
            {
                SearchSale sje = new SearchSale();
                sje.BringToFront();
                sje.TopMost = true;
                sje.IsSales = true;
                DialogResult res = sje.ShowDialog(this);

                if (res == DialogResult.OK)
                {
                    this.SaleId = sje.Sale.Id;
                    this.txtSaleID.Text = sje.Sale.Id.ToString();
                    this.txtSaleTransactionNo.Text = sje.Sale.TRANo;
                    this.txtSalePONo.Text = sje.Sale.PONo;
                    this.txtCustomerName.Text = sje.Sale.Customer.strName;
                    //this.txtTotal.Text = sje.Sale.Total.ToString();
                    this.chkIsFullyPaid.Checked = (bool)sje.Sale.IsFullyPaid;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (this.SaleId == 0)
                {
                    MessageBox.Show("Please select sales...");
                    return;
                }

                if (this.GLTranDetail.Sum(d => d.curCredit) != this.GLTranDetail.Sum(d => d.curDebit))
                {
                    MessageBox.Show("Disbal journal entry");
                    return;
                }

                if (this.AccountReceivableAdjustmentsDetailList.Count == 0)
                {
                    MessageBox.Show("Please enter inventory");
                    return;
                }

                int intParser;
                decimal decimalParser;

                var isLock = tblTBBatchHdrServices.CheckIfLock(this.dtAdjustmentTransactionDate.Value);

                if (isLock)
                {
                    MessageBox.Show("Already lock...");
                    return;
                }

                string TransType = (this.ID == 0) ? "insert" : "update";
                int? bankId = null;

                //if (this.chkIsCash.Checked == false)
                //{
                //    bankId = (this.cbBank.SelectedItem == null) ? 0 : ((Tier.BO.Bank)this.cbBank.SelectedItem).ID;
                //}

                var adjustmentType = (this.cbAdjustmentType.SelectedItem == null) ? 0 : ((AccountsReceivableAdjustmentsType)this.cbAdjustmentType.SelectedItem).Id;
                if (TransType.Equals("insert"))
                {
                   
                    AccountReceivableAdjustment = new AccountReceivableAdjustment
                    {
                        Id = this.ID,
                        AccountsReceivableAdjustmentsTypeId = adjustmentType,
                        TransactionNo = this.txtAdjustmentTransactionNo.Text,
                        TransactionDate = this.dtAdjustmentTransactionDate.Value,
                        Descrpition = this.txtDescription.Text,
                        TotalAmount = decimal.TryParse(this.txtTotal.Text, out decimalParser) ? decimalParser : 0,
                        SalesId = this.SaleId
                    };

                    AccountReceivableAdjustment = AccountReceivableAdjustmentsServices.AddReturnSales(AccountReceivableAdjustment, this.GLTranDetail, this.chkUseDefaultEntry.Checked, this.AccountReceivableAdjustmentsDetailList);

                    if (AccountReceivableAdjustment != null)
                    {
                        this.AccountReceivableAdjustmentsDetailList = AccountReceivableAdjustment.AccountReceivableAdjustmentsDetails.ToList();
                        this.txtDescription.Text = AccountReceivableAdjustment.Descrpition;
                        MessageBox.Show("Successfully saved");
                    }
                }
                else
                {
                    AccountReceivableAdjustment.Id = this.ID;
                    AccountReceivableAdjustment.AccountsReceivableAdjustmentsTypeId = adjustmentType;
                    AccountReceivableAdjustment.TransactionNo = this.txtAdjustmentTransactionNo.Text;
                    AccountReceivableAdjustment.TransactionDate = this.dtAdjustmentTransactionDate.Value;
                    AccountReceivableAdjustment.Descrpition = this.txtDescription.Text;
                    AccountReceivableAdjustment.SalesId = this.SaleId;
                    AccountReceivableAdjustment.TotalAmount = decimal.TryParse(this.txtTotal.Text, out decimalParser) ? decimalParser : 0;


                    AccountReceivableAdjustment = AccountReceivableAdjustmentsServices.UpdateReturnSales(AccountReceivableAdjustment, this.GLTranDetail, this.chkUseDefaultEntry.Checked, this.AccountReceivableAdjustmentsDetailList);
                    if (AccountReceivableAdjustment != null)
                    {
                        this.AccountReceivableAdjustmentsDetailList = AccountReceivableAdjustment.AccountReceivableAdjustmentsDetails.ToList();
                        this.txtDescription.Text = AccountReceivableAdjustment.Descrpition;
                        MessageBox.Show("Successfully saved");
                    }

                }

                //GLTranHeader = AccountReceivableAdjustment.tblGLTranHeaders.Select(h => h.ID).SingleOrDefault();
                this.GLTranDetail = GLTranServices.GetGLEntryByAdjustmentReturnSaleId(AccountReceivableAdjustment.Id , 8).SelectMany(h => h.tblGLTranDetails).ToList();
                if (GLTranDetail.Count > 0)
                {

                    this.dgJournalEntry.ColumnCount = 6;
                    this.dgJournalEntry.RowCount = GLTranDetail.Count;
                    //this.dgChartOfAccountsSubsidiary.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //this.dgChartOfAccountsSubsidiary.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    this.dgJournalEntry.Columns[0].Name = "COA";
                    this.dgJournalEntry.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    this.dgJournalEntry.Columns[1].Name = "COA Code";
                    this.dgJournalEntry.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgJournalEntry.Columns[2].Name = "COA Subsidiary";
                    this.dgJournalEntry.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgJournalEntry.Columns[3].Name = "COA Subsidiary Code";
                    this.dgJournalEntry.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgJournalEntry.Columns[4].Name = "Debit";
                    this.dgJournalEntry.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgJournalEntry.Columns[5].Name = "Credit";
                    this.dgJournalEntry.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    this.dgJournalEntry.Columns[0].ReadOnly = true;
                    this.dgJournalEntry.Columns[1].ReadOnly = true;
                    this.dgJournalEntry.Columns[2].ReadOnly = true;
                    this.dgJournalEntry.Columns[3].ReadOnly = true;
                    this.dgJournalEntry.Columns[4].ReadOnly = true;
                    this.dgJournalEntry.Columns[5].ReadOnly = true;
                    this.dgJournalEntry.Columns[1].Visible = false;
                    this.dgJournalEntry.Columns[3].Visible = false;

                    for (int i = 0; i < GLTranDetail.Count; i++)
                    {

                        this.dgJournalEntry.Rows[i].Cells[0].Value = GLTranDetail[i].tblMasCOA.strName;
                        this.dgJournalEntry.Rows[i].Cells[1].Value = GLTranDetail[i].tblMasCOA.strCode;
                        this.dgJournalEntry.Rows[i].Cells[2].Value = GLTranDetail[i].tblMasCOASub.strName;
                        this.dgJournalEntry.Rows[i].Cells[3].Value = GLTranDetail[i].tblMasCOASub.strCode;
                        this.dgJournalEntry.Rows[i].Cells[4].Value = string.Format("{0:0.00}", GLTranDetail[i].curDebit);
                        this.dgJournalEntry.Rows[i].Cells[5].Value = string.Format("{0:0.00}", GLTranDetail[i].curCredit);

                        this.dgJournalEntry.Rows[i].Cells[0].ReadOnly = true;
                        this.dgJournalEntry.Rows[i].Cells[1].ReadOnly = true;
                        this.dgJournalEntry.Rows[i].Cells[2].ReadOnly = true;
                        this.dgJournalEntry.Rows[i].Cells[3].ReadOnly = true;
                        this.dgJournalEntry.Rows[i].Cells[4].ReadOnly = true;
                        this.dgJournalEntry.Rows[i].Cells[5].ReadOnly = true;
                    }

                    setRowNumber(this.dgJournalEntry);

                    this.txtTotalDebit.Text = string.Format("{0:0.00}", GLTranDetail.Sum(g => g.curDebit));
                    this.txtTotalCredit.Text = string.Format("{0:0.00}", GLTranDetail.Sum(g => g.curCredit));
                }
                else
                {
                    this.dgJournalEntry.Rows.Clear();
                    this.dgJournalEntry.Refresh();
                    this.GLTranDetail.Clear();
                    this.txtTotalDebit.Text = string.Empty;
                    this.txtTotalCredit.Text = string.Empty;
                }

                this.GLTranDetailInventoryEntry = GLTranServices.GetGLEntryByAdjustmentReturnSaleId(AccountReceivableAdjustment.Id, 1011).SelectMany(h => h.tblGLTranDetails).ToList();

                if (GLTranDetailInventoryEntry.Count > 0)
                {

                    this.dgInventoryEntry.ColumnCount = 6;
                    this.dgInventoryEntry.RowCount = GLTranDetailInventoryEntry.Count;
                    //this.dgChartOfAccountsSubsidiary.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //this.dgChartOfAccountsSubsidiary.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    this.dgInventoryEntry.Columns[0].Name = "COA";
                    this.dgInventoryEntry.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    this.dgInventoryEntry.Columns[1].Name = "COA Code";
                    this.dgInventoryEntry.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgInventoryEntry.Columns[2].Name = "COA Subsidiary";
                    this.dgInventoryEntry.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgInventoryEntry.Columns[3].Name = "COA Subsidiary Code";
                    this.dgInventoryEntry.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgInventoryEntry.Columns[4].Name = "Debit";
                    this.dgInventoryEntry.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgInventoryEntry.Columns[5].Name = "Credit";
                    this.dgInventoryEntry.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    this.dgInventoryEntry.Columns[0].ReadOnly = true;
                    this.dgInventoryEntry.Columns[1].ReadOnly = true;
                    this.dgInventoryEntry.Columns[2].ReadOnly = true;
                    this.dgInventoryEntry.Columns[3].ReadOnly = true;
                    this.dgInventoryEntry.Columns[4].ReadOnly = true;
                    this.dgInventoryEntry.Columns[5].ReadOnly = true;
                    this.dgInventoryEntry.Columns[1].Visible = false;
                    this.dgInventoryEntry.Columns[3].Visible = false;

                    for (int i = 0; i < GLTranDetailInventoryEntry.Count; i++)
                    {

                        this.dgInventoryEntry.Rows[i].Cells[0].Value = GLTranDetailInventoryEntry[i].tblMasCOA.strName;
                        this.dgInventoryEntry.Rows[i].Cells[1].Value = GLTranDetailInventoryEntry[i].tblMasCOA.strCode;
                        this.dgInventoryEntry.Rows[i].Cells[2].Value = GLTranDetailInventoryEntry[i].tblMasCOASub.strName;
                        this.dgInventoryEntry.Rows[i].Cells[3].Value = GLTranDetailInventoryEntry[i].tblMasCOASub.strCode;
                        this.dgInventoryEntry.Rows[i].Cells[4].Value = string.Format("{0:0.00}", GLTranDetailInventoryEntry[i].curDebit);
                        this.dgInventoryEntry.Rows[i].Cells[5].Value = string.Format("{0:0.00}", GLTranDetailInventoryEntry[i].curCredit);

                        this.dgInventoryEntry.Rows[i].Cells[0].ReadOnly = true;
                        this.dgInventoryEntry.Rows[i].Cells[1].ReadOnly = true;
                        this.dgInventoryEntry.Rows[i].Cells[2].ReadOnly = true;
                        this.dgInventoryEntry.Rows[i].Cells[3].ReadOnly = true;
                        this.dgInventoryEntry.Rows[i].Cells[4].ReadOnly = true;
                        this.dgInventoryEntry.Rows[i].Cells[5].ReadOnly = true;
                    }

                    setRowNumber(this.dgInventoryEntry);

                    this.txtTotalInventoryDebit.Text = string.Format("{0:0.00}", GLTranDetailInventoryEntry.Sum(g => g.curDebit));
                    this.txtTotalInventoryCredit.Text = string.Format("{0:0.00}", GLTranDetailInventoryEntry.Sum(g => g.curCredit));
                }

                this.ID = AccountReceivableAdjustment.Id;
                this.txtAdjustmentId.Text = AccountReceivableAdjustment.Id.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            SearchChartOfAccounts sca = new SearchChartOfAccounts();
            sca.IDGLTranHeader = GLTranHeader;
            sca.BringToFront();
            sca.TopMost = true;
            DialogResult res = sca.ShowDialog(this);

            if (res == DialogResult.OK)
            {

                var convertGLTranDetailDomain = new tblGLTranDetail
                {
                    intIDGLTranHeader = sca.GLTranDetail.intIDGLTranHeader,
                    intIDMasCoa = sca.GLTranDetail.intIDCOA,
                    intIDMasCoaSub = sca.GLTranDetail.intIDCOASub,
                    curCredit = Convert.ToDecimal(sca.GLTranDetail.curCredit),
                    curDebit = Convert.ToDecimal(sca.GLTranDetail.curDebit),
                    tblMasCOA = new tblMasCOA
                    {
                        ID = sca.GLTranDetail.COA.ID,
                        strCode = sca.GLTranDetail.COA.strCode,
                        strName = sca.GLTranDetail.COA.strName
                    },
                    tblMasCOASub = new tblMasCOASub
                    {
                        ID = sca.GLTranDetail.COASub.ID,
                        strCode = sca.GLTranDetail.COASub.strCoaSubCode,
                        strName = sca.GLTranDetail.COASub.strCoaSubName
                    }
                };

                GLTranDetail.Add(convertGLTranDetailDomain);

                if (GLTranDetail.Count > 0)
                {
                    this.dgJournalEntry.Rows.Clear();
                    this.dgJournalEntry.Refresh();

                    this.dgJournalEntry.ColumnCount = 6;
                    this.dgJournalEntry.RowCount = this.GLTranDetail.Count;

                    //this.dgChartOfAccountsSubsidiary.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //this.dgChartOfAccountsSubsidiary.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    this.dgJournalEntry.Columns[0].Name = "COA";
                    this.dgJournalEntry.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgJournalEntry.Columns[1].Name = "COA Code";
                    this.dgJournalEntry.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgJournalEntry.Columns[2].Name = "COA Subsidiary";
                    this.dgJournalEntry.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgJournalEntry.Columns[3].Name = "COA Subsidiary Code";
                    this.dgJournalEntry.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgJournalEntry.Columns[4].Name = "Debit";
                    this.dgJournalEntry.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgJournalEntry.Columns[5].Name = "Credit";
                    this.dgJournalEntry.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                    this.dgJournalEntry.Columns[0].ReadOnly = true;
                    this.dgJournalEntry.Columns[1].ReadOnly = true;
                    this.dgJournalEntry.Columns[2].ReadOnly = true;
                    this.dgJournalEntry.Columns[3].ReadOnly = true;
                    this.dgJournalEntry.Columns[4].ReadOnly = true;
                    this.dgJournalEntry.Columns[5].ReadOnly = true;
                    this.dgJournalEntry.Columns[1].Visible = false;
                    this.dgJournalEntry.Columns[3].Visible = false;

                    for (int i = 0; i < GLTranDetail.Count; i++)
                    {
                        this.dgJournalEntry.Rows[i].Cells[0].Value = GLTranDetail[i].tblMasCOA.strName;
                        this.dgJournalEntry.Rows[i].Cells[1].Value = GLTranDetail[i].tblMasCOA.strCode;
                        this.dgJournalEntry.Rows[i].Cells[2].Value = GLTranDetail[i].tblMasCOASub.strName;
                        this.dgJournalEntry.Rows[i].Cells[3].Value = GLTranDetail[i].tblMasCOASub.strCode;
                        this.dgJournalEntry.Rows[i].Cells[4].Value = string.Format("{0:0.00}", GLTranDetail[i].curDebit);
                        this.dgJournalEntry.Rows[i].Cells[5].Value = string.Format("{0:0.00}", GLTranDetail[i].curCredit);
                    }

                    setRowNumber(this.dgJournalEntry);

                    this.txtTotalDebit.Text = string.Format("{0:0.00}", GLTranDetail.Sum(g => g.curDebit));
                    this.txtTotalCredit.Text = string.Format("{0:0.00}", GLTranDetail.Sum(g => g.curCredit));
                }
            }
        }

        private void btnDeleteEntry_Click(object sender, EventArgs e)
        {
            try
            {
                if (GLTranDetail.Count > 0)
                {
                    GLTranDetail.RemoveAt(this.IndexGrid);
                    this.dgJournalEntry.Rows.Clear();
                    this.dgJournalEntry.Refresh();

                    if (this.GLTranDetail.Count == 0)
                    {
                        return;
                    }

                    this.dgJournalEntry.ColumnCount = 6;
                    this.dgJournalEntry.RowCount = this.GLTranDetail.Count;

                    this.dgJournalEntry.Columns[0].Name = "COA";
                    this.dgJournalEntry.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgJournalEntry.Columns[1].Name = "COA Code";
                    this.dgJournalEntry.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgJournalEntry.Columns[2].Name = "COA Subsidiary";
                    this.dgJournalEntry.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgJournalEntry.Columns[3].Name = "COA SubsidiaryCode";
                    this.dgJournalEntry.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgJournalEntry.Columns[4].Name = "Debit";
                    this.dgJournalEntry.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgJournalEntry.Columns[5].Name = "Credit";
                    this.dgJournalEntry.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    for (int i = 0; i < GLTranDetail.Count; i++)
                    {
                        this.dgJournalEntry.Rows[i].Cells[0].Value = GLTranDetail[i].tblMasCOA.strName;
                        this.dgJournalEntry.Rows[i].Cells[1].Value = GLTranDetail[i].tblMasCOA.strCode;
                        this.dgJournalEntry.Rows[i].Cells[2].Value = GLTranDetail[i].tblMasCOASub.strName;
                        this.dgJournalEntry.Rows[i].Cells[3].Value = GLTranDetail[i].tblMasCOASub.strCode;
                        this.dgJournalEntry.Rows[i].Cells[4].Value = string.Format("{0:0.00}", GLTranDetail[i].curDebit);
                        this.dgJournalEntry.Rows[i].Cells[5].Value = string.Format("{0:0.00}", GLTranDetail[i].curCredit);
                    }

                    setRowNumber(this.dgJournalEntry);

                    this.txtTotalDebit.Text = string.Format("{0:0.00}", GLTranDetail.Sum(g => g.curDebit));
                    this.txtTotalCredit.Text = string.Format("{0:0.00}", GLTranDetail.Sum(g => g.curCredit));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                SearchAdjustmentAccountReceivableAdjustmentsReturnSales sje = new SearchAdjustmentAccountReceivableAdjustmentsReturnSales();
                sje.BringToFront();
                sje.TopMost = true;
                DialogResult res = sje.ShowDialog(this);

                if (res == DialogResult.OK)
                {

                    this.ID = sje.AccountReceivableAdjustment.Id;
                    this.txtAdjustmentId.Text = sje.AccountReceivableAdjustment.Id.ToString();
                    this.cbAdjustmentType.SelectedValue = sje.AccountReceivableAdjustment.AccountsReceivableAdjustmentsTypeId;
                    this.txtAdjustmentTransactionNo.Text = sje.AccountReceivableAdjustment.TransactionNo;
                    this.dtAdjustmentTransactionDate.Value = (DateTime)sje.AccountReceivableAdjustment.TransactionDate;
                    //this.CollectionId = (int)sje.AccountReceivableAdjustment.CollectionId;
                   // this.txtCollectionId.Text = sje.AccountReceivableAdjustment.CollectionId.ToString();
                    this.SaleId = (int)sje.AccountReceivableAdjustment.SalesId;
                    this.txtSaleTransactionNo.Text = sje.AccountReceivableAdjustment.Sale.TRANo;
                    this.txtCustomerName.Text = sje.AccountReceivableAdjustment.Sale.Customer.strName;
                    this.txtSaleID.Text = this.SaleId.ToString();
                    this.txtSalePONo.Text = sje.AccountReceivableAdjustment.Sale.PONo;
                    //this.txtCollectionTransactionNo.Text = sje.AccountReceivableAdjustment.Collection.TRANo.ToString();
                    //this.cbBank.SelectedValue = sje.AccountReceivableAdjustment.Collection.BankId;
                    //this.chkIsCash.Checked = (bool)sje.AccountReceivableAdjustment.Collection.IsCash;
                    //this.txtCheckDetails.Text = sje.AccountReceivableAdjustment.Collection.CheckDetail;
                    this.txtTotal.Text = sje.AccountReceivableAdjustment.TotalAmount.ToString();
                    this.txtDescription.Text = sje.AccountReceivableAdjustment.Descrpition;
                    this.GLTranHeader = sje.AccountReceivableAdjustment.tblGLTranHeaders.Select(h => h.ID).FirstOrDefault();
                    this.GLTranDetail = GLTranServices.GetGLEntryById(this.GLTranHeader).SelectMany(h => h.tblGLTranDetails).ToList();
                    this.AccountReceivableAdjustmentsDetailList = AccountReceivableAdjustmentsDetailServices.GetAccountReceivableAdjustmentsDetailProductByAccountReceivableAdjustmentId(this.ID).SelectMany(ar => ar.AccountReceivableAdjustmentsDetails).ToList();
                    this.chkUseDefaultEntry.Checked = (bool)sje.AccountReceivableAdjustment.tblGLTranHeaders.Select(h => h.blnUseDefaultEntry).FirstOrDefault();


                    if (GLTranDetail.Count > 0)
                    {

                        this.dgJournalEntry.ColumnCount = 6;
                        this.dgJournalEntry.RowCount = GLTranDetail.Count;
                        //this.dgChartOfAccountsSubsidiary.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        //this.dgChartOfAccountsSubsidiary.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        this.dgJournalEntry.Columns[0].Name = "COA";
                        this.dgJournalEntry.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        this.dgJournalEntry.Columns[1].Name = "COA Code";
                        this.dgJournalEntry.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.dgJournalEntry.Columns[2].Name = "COA Subsidiary";
                        this.dgJournalEntry.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.dgJournalEntry.Columns[3].Name = "COA Subsidiary Code";
                        this.dgJournalEntry.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.dgJournalEntry.Columns[4].Name = "Debit";
                        this.dgJournalEntry.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.dgJournalEntry.Columns[5].Name = "Credit";
                        this.dgJournalEntry.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        this.dgJournalEntry.Columns[0].ReadOnly = true;
                        this.dgJournalEntry.Columns[1].ReadOnly = true;
                        this.dgJournalEntry.Columns[2].ReadOnly = true;
                        this.dgJournalEntry.Columns[3].ReadOnly = true;
                        this.dgJournalEntry.Columns[4].ReadOnly = true;
                        this.dgJournalEntry.Columns[5].ReadOnly = true;
                        this.dgJournalEntry.Columns[1].Visible = false;
                        this.dgJournalEntry.Columns[3].Visible = false;

                        for (int i = 0; i < GLTranDetail.Count; i++)
                        {

                            this.dgJournalEntry.Rows[i].Cells[0].Value = GLTranDetail[i].tblMasCOA.strName;
                            this.dgJournalEntry.Rows[i].Cells[1].Value = GLTranDetail[i].tblMasCOA.strCode;
                            this.dgJournalEntry.Rows[i].Cells[2].Value = GLTranDetail[i].tblMasCOASub.strName;
                            this.dgJournalEntry.Rows[i].Cells[3].Value = GLTranDetail[i].tblMasCOASub.strCode;
                            this.dgJournalEntry.Rows[i].Cells[4].Value = string.Format("{0:0.00}", GLTranDetail[i].curDebit);
                            this.dgJournalEntry.Rows[i].Cells[5].Value = string.Format("{0:0.00}", GLTranDetail[i].curCredit);

                            this.dgJournalEntry.Rows[i].Cells[0].ReadOnly = true;
                            this.dgJournalEntry.Rows[i].Cells[1].ReadOnly = true;
                            this.dgJournalEntry.Rows[i].Cells[2].ReadOnly = true;
                            this.dgJournalEntry.Rows[i].Cells[3].ReadOnly = true;
                            this.dgJournalEntry.Rows[i].Cells[4].ReadOnly = true;
                            this.dgJournalEntry.Rows[i].Cells[5].ReadOnly = true;
                        }

                        setRowNumber(this.dgJournalEntry);

                        this.txtTotalDebit.Text = string.Format("{0:0.00}", GLTranDetail.Sum(g => g.curDebit));
                        this.txtTotalCredit.Text = string.Format("{0:0.00}", GLTranDetail.Sum(g => g.curCredit));
                    }
                    else
                    {
                        this.dgJournalEntry.Rows.Clear();
                        this.dgJournalEntry.Refresh();
                        this.GLTranDetail.Clear();
                        this.txtTotalDebit.Text = string.Empty;
                        this.txtTotalCredit.Text = string.Empty;
                    }

                    if (AccountReceivableAdjustmentsDetailList.Count > 0)
                    {

                        this.dgProduct.Rows.Clear();
                        this.dgProduct.Refresh();
                        //this.dgProduct.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        this.dgProduct.RowCount = AccountReceivableAdjustmentsDetailList.Count;
                        this.dgProduct.ColumnCount = 30;
                        this.dgProduct.Columns[0].Name = "ID";
                        this.dgProduct.Columns[0].Visible = false;
                        this.dgProduct.Columns[1].Name = "Product Name";
                        this.dgProduct.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        this.dgProduct.Columns[2].Visible = false;
                        this.dgProduct.Columns[2].Name = "Description";
                        this.dgProduct.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        this.dgProduct.Columns[3].Name = "Product Characteristic ID";
                        this.dgProduct.Columns[3].Visible = false;
                        this.dgProduct.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        this.dgProduct.Columns[4].Name = "Product Characteristic Name";
                        this.dgProduct.Columns[4].Visible = false;
                        this.dgProduct.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        this.dgProduct.Columns[5].Name = "Product Category ID";
                        this.dgProduct.Columns[5].Visible = false;
                        this.dgProduct.Columns[6].Name = "Product Category Name";
                        this.dgProduct.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        this.dgProduct.Columns[7].Name = "Product Type ID";
                        this.dgProduct.Columns[7].Visible = false;
                        this.dgProduct.Columns[8].Name = "Product Type Name";
                        this.dgProduct.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        this.dgProduct.Columns[9].Name = "Product Brand ID";
                        this.dgProduct.Columns[9].Visible = false;
                        this.dgProduct.Columns[10].Name = "Product Brand Name";
                        this.dgProduct.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        this.dgProduct.Columns[11].Name = "Per Piece Box";
                        this.dgProduct.Columns[11].Visible = false;
                        this.dgProduct.Columns[12].Name = "Location ID";
                        this.dgProduct.Columns[12].Visible = false;
                        this.dgProduct.Columns[13].Name = "Location Name";
                        this.dgProduct.Columns[13].Visible = false;
                        this.dgProduct.Columns[14].Name = "Product Color ID";
                        this.dgProduct.Columns[14].Visible = false;
                        this.dgProduct.Columns[15].Name = "Product Color Name";
                        this.dgProduct.Columns[16].Name = "Product Size ID";
                        this.dgProduct.Columns[16].Visible = false;
                        this.dgProduct.Columns[17].Name = "Product Size Name";
                        this.dgProduct.Columns[18].Name = "Product Unit ID";
                        this.dgProduct.Columns[18].Visible = false;
                        this.dgProduct.Columns[19].Name = "Product Unit Name";
                        this.dgProduct.Columns[20].Name = "Code";
                        this.dgProduct.Columns[20].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        this.dgProduct.Columns[21].Name = "PR";
                        this.dgProduct.Columns[22].Name = "PCD";
                        this.dgProduct.Columns[23].Name = "MFLM";
                        this.dgProduct.Columns[24].Name = "Pattern";
                        this.dgProduct.Columns[25].Name = "OffsetCenterBase";
                        this.dgProduct.Columns[25].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        this.dgProduct.Columns[26].Name = "Origin";
                        this.dgProduct.Columns[27].Name = "Unit Price";
                        this.dgProduct.Columns[28].Name = "Quantity";
                        this.dgProduct.Columns[29].Name = "Total Quantity Price";

                        for (int i = 0; i < AccountReceivableAdjustmentsDetailList.Count; i++)
                        {
                            //display all the data in productList to the datagridview
                            AccountReceivableAdjustmentsDetail accountReceivableAdjustmentsDetail = AccountReceivableAdjustmentsDetailList[i];
                            this.AccountReceivableAdjustment.AccountReceivableAdjustmentsDetails.Add(accountReceivableAdjustmentsDetail);
                            this.dgProduct.Rows[i].Cells[0].Value = accountReceivableAdjustmentsDetail.Id;
                            this.dgProduct.Rows[i].Cells[1].Value = accountReceivableAdjustmentsDetail.Product.strProductName;
                            this.dgProduct.Rows[i].Cells[2].Value = accountReceivableAdjustmentsDetail.Product.strDescription;
                            this.dgProduct.Rows[i].Cells[3].Value = 0;
                            this.dgProduct.Rows[i].Cells[4].Value = string.Empty;
                            this.dgProduct.Rows[i].Cells[5].Value = accountReceivableAdjustmentsDetail.Product.ProductCategory.Id;
                            this.dgProduct.Rows[i].Cells[6].Value = accountReceivableAdjustmentsDetail.Product.ProductCategory.strName;
                            this.dgProduct.Rows[i].Cells[7].Value = accountReceivableAdjustmentsDetail.Product.ProductType.Id;
                            this.dgProduct.Rows[i].Cells[8].Value = accountReceivableAdjustmentsDetail.Product.ProductType.strName;
                            this.dgProduct.Rows[i].Cells[9].Value = accountReceivableAdjustmentsDetail.Product.ProductBrand.Id;
                            this.dgProduct.Rows[i].Cells[10].Value = accountReceivableAdjustmentsDetail.Product.ProductBrand.strName;
                            //this.dgProduct.Rows[i].Cells[11].Value = product.PerPieceBox;
                            //this.dgProduct.Rows[i].Cells[12].Value = product.Location.ID;
                            //this.dgProduct.Rows[i].Cells[13].Value = product.Location.Name;
                            this.dgProduct.Rows[i].Cells[14].Value = accountReceivableAdjustmentsDetail.Product.ProductColor.Id;
                            this.dgProduct.Rows[i].Cells[15].Value = accountReceivableAdjustmentsDetail.Product.ProductColor.strName;
                            this.dgProduct.Rows[i].Cells[16].Value = accountReceivableAdjustmentsDetail.Product.ProductSize.Id;
                            this.dgProduct.Rows[i].Cells[17].Value = accountReceivableAdjustmentsDetail.Product.ProductSize.strName;
                            this.dgProduct.Rows[i].Cells[18].Value = accountReceivableAdjustmentsDetail.Product.ProductUnit.Id;
                            this.dgProduct.Rows[i].Cells[19].Value = accountReceivableAdjustmentsDetail.Product.ProductUnit.strName;
                            this.dgProduct.Rows[i].Cells[20].Value = accountReceivableAdjustmentsDetail.Product.strCode;
                            this.dgProduct.Rows[i].Cells[21].Value = accountReceivableAdjustmentsDetail.Product.strPR;
                            this.dgProduct.Rows[i].Cells[22].Value = accountReceivableAdjustmentsDetail.Product.strPCD;
                            this.dgProduct.Rows[i].Cells[23].Value = accountReceivableAdjustmentsDetail.Product.strMFLM;
                            this.dgProduct.Rows[i].Cells[24].Value = accountReceivableAdjustmentsDetail.Product.strPattern;
                            this.dgProduct.Rows[i].Cells[25].Value = accountReceivableAdjustmentsDetail.Product.strOffsetCenterBore;
                            this.dgProduct.Rows[i].Cells[26].Value = accountReceivableAdjustmentsDetail.Product.strOrigin;
                            this.dgProduct.Rows[i].Cells[27].Value = accountReceivableAdjustmentsDetail.UnitPrice;
                            this.dgProduct.Rows[i].Cells[28].Value = accountReceivableAdjustmentsDetail.Quantity;
                            this.dgProduct.Rows[i].Cells[29].Value = accountReceivableAdjustmentsDetail.TotalPrice;
                            //this.dgProduct.Rows[i].Cells[27].Value = product.curUnitPrice;
                        }

                        setRowNumber(this.dgJournalEntry);
                        this.txtInventoryPurchaseTotal.Text = string.Format("{0:0.00}", AccountReceivableAdjustmentsDetailList.Sum(g => g.TotalPrice));
                        // this.txtTotal.Text = string.Format("{0:0.00}", AccountPayableAdjustmentsDetailList.Sum(g => g.TotalPrice));
                    }

                    this.GLTranDetailInventoryEntry = GLTranServices.GetGLEntryByAdjustmentReturnSaleId(this.ID, 1011).SelectMany(h => h.tblGLTranDetails).ToList();
                    if (GLTranDetailInventoryEntry.Count > 0)
                    {

                        this.dgInventoryEntry.ColumnCount = 6;
                        this.dgInventoryEntry.RowCount = GLTranDetailInventoryEntry.Count;
                        //this.dgChartOfAccountsSubsidiary.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        //this.dgChartOfAccountsSubsidiary.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        this.dgInventoryEntry.Columns[0].Name = "COA";
                        this.dgInventoryEntry.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        this.dgInventoryEntry.Columns[1].Name = "COA Code";
                        this.dgInventoryEntry.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.dgInventoryEntry.Columns[2].Name = "COA Subsidiary";
                        this.dgInventoryEntry.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.dgInventoryEntry.Columns[3].Name = "COA Subsidiary Code";
                        this.dgInventoryEntry.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.dgInventoryEntry.Columns[4].Name = "Debit";
                        this.dgInventoryEntry.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.dgInventoryEntry.Columns[5].Name = "Credit";
                        this.dgInventoryEntry.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        this.dgInventoryEntry.Columns[0].ReadOnly = true;
                        this.dgInventoryEntry.Columns[1].ReadOnly = true;
                        this.dgInventoryEntry.Columns[2].ReadOnly = true;
                        this.dgInventoryEntry.Columns[3].ReadOnly = true;
                        this.dgInventoryEntry.Columns[4].ReadOnly = true;
                        this.dgInventoryEntry.Columns[5].ReadOnly = true;
                        this.dgInventoryEntry.Columns[1].Visible = false;
                        this.dgInventoryEntry.Columns[3].Visible = false;

                        for (int i = 0; i < GLTranDetailInventoryEntry.Count; i++)
                        {

                            this.dgInventoryEntry.Rows[i].Cells[0].Value = GLTranDetailInventoryEntry[i].tblMasCOA.strName;
                            this.dgInventoryEntry.Rows[i].Cells[1].Value = GLTranDetailInventoryEntry[i].tblMasCOA.strCode;
                            this.dgInventoryEntry.Rows[i].Cells[2].Value = GLTranDetailInventoryEntry[i].tblMasCOASub.strName;
                            this.dgInventoryEntry.Rows[i].Cells[3].Value = GLTranDetailInventoryEntry[i].tblMasCOASub.strCode;
                            this.dgInventoryEntry.Rows[i].Cells[4].Value = string.Format("{0:0.00}", GLTranDetailInventoryEntry[i].curDebit);
                            this.dgInventoryEntry.Rows[i].Cells[5].Value = string.Format("{0:0.00}", GLTranDetailInventoryEntry[i].curCredit);

                            this.dgInventoryEntry.Rows[i].Cells[0].ReadOnly = true;
                            this.dgInventoryEntry.Rows[i].Cells[1].ReadOnly = true;
                            this.dgInventoryEntry.Rows[i].Cells[2].ReadOnly = true;
                            this.dgInventoryEntry.Rows[i].Cells[3].ReadOnly = true;
                            this.dgInventoryEntry.Rows[i].Cells[4].ReadOnly = true;
                            this.dgInventoryEntry.Rows[i].Cells[5].ReadOnly = true;
                        }
                        setRowNumber(this.dgInventoryEntry);

                        this.txtTotalInventoryDebit.Text = string.Format("{0:0.00}", GLTranDetailInventoryEntry.Sum(g => g.curDebit));
                        this.txtTotalInventoryCredit.Text = string.Format("{0:0.00}", GLTranDetailInventoryEntry.Sum(g => g.curCredit));
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }

        public void AddAdjustments()
        {

            this.ID = 0;
            this.txtAdjustmentId.Text = String.Empty;
            this.txtAdjustmentTransactionNo.Text =  String.Empty; 
            this.SaleId = 0;
            this.txtSaleTransactionNo.Text =  String.Empty; 
            this.txtCustomerName.Text = String.Empty;
            this.txtSaleID.Text = String.Empty;
            this.txtSalePONo.Text = String.Empty;
            this.txtTotal.Text =  String.Empty;
            this.txtDescription.Text = String.Empty;
            this.txtInventoryPurchaseTotal.Text = string.Empty;
            this.txtTotalDebit.Text = string.Empty;
            this.txtTotalCredit.Text = string.Empty;
            this.dgProduct.Rows.Clear();
            this.dgProduct.Refresh();
            this.dgInventoryEntry.Rows.Clear();
            this.dgInventoryEntry.Refresh();
            this.AccountReceivableAdjustmentsDetailList = new List<AccountReceivableAdjustmentsDetail>();
            this.dgJournalEntry.Rows.Clear();
            this.dgJournalEntry.Refresh();
            this.GLTranDetail.Clear();
            this.GLTranHeader = 0;
            this.chkUseDefaultEntry.Checked = true;

            this.txtTotalInventoryCredit.Text = string.Empty;
            this.txtTotalInventoryDebit.Text = string.Empty;
            GLTranDetail = new List<tblGLTranDetail>();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            AddAdjustments();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                int intParser;
                decimal decimalParser;

                var isLock = tblTBBatchHdrServices.CheckIfLock(this.dtAdjustmentTransactionDate.Value);

                if (isLock)
                {
                    MessageBox.Show("Already lock...");
                    return;
                }

                string TransType = (this.ID > 0) ? "delete" : String.Empty;
                var adjustmentType = (this.cbAdjustmentType.SelectedItem == null) ? 0 : ((AccountsReceivableAdjustmentsType)this.cbAdjustmentType.SelectedItem).Id;

                if (TransType.Equals("delete"))
                {
                    AccountReceivableAdjustment = new AccountReceivableAdjustment
                    {
                        Id = this.ID,
                        AccountsReceivableAdjustmentsTypeId = adjustmentType,
                        TransactionNo = this.txtAdjustmentTransactionNo.Text,
                        TransactionDate = this.dtAdjustmentTransactionDate.Value,
                        Descrpition = this.txtDescription.Text,
                        SalesId = this.SaleId
                    };

                    AccountReceivableAdjustmentsServices.RemoveReturnSales(AccountReceivableAdjustment, this.AccountReceivableAdjustmentsDetailList);

                    if (AccountReceivableAdjustmentsServices != null)
                    {
                        AddAdjustments();
                        MessageBox.Show("Successfully deleted");

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void dgProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.IndexGridInventory = e.RowIndex;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {


            frmChooseReturnSaleProduct frmChooseReturnProduct = new frmChooseReturnSaleProduct();
            frmChooseReturnProduct.BringToFront();
            frmChooseReturnProduct.TopMost = true;
            frmChooseReturnProduct.IsPurchaseReturn = true;
            frmChooseReturnProduct.SalesID = this.SaleId;
            DialogResult res = frmChooseReturnProduct.ShowDialog(this);

            if (res == DialogResult.OK)
            {

                var convertPurchaseDetail = new AccountReceivableAdjustmentsDetail
                {
                    ProductId = frmChooseReturnProduct.Product.Id,
                    //assign frmChooseProduct.Product to Product

                    Product = frmChooseReturnProduct.Product,
                    //UnitPrice = frmChooseProduct.Product.curUnitPrice,
                    UnitPrice = frmChooseReturnProduct.ProductTotalUnitPrice,
                    Quantity = frmChooseReturnProduct.ProductQuantity,
                    TotalPrice = frmChooseReturnProduct.ProductTotalQuantityPrice,
                };

                

                if (!(AccountReceivableAdjustmentsDetailList.Any(p => p.ProductId == convertPurchaseDetail.ProductId)))
                {
                    this.AccountReceivableAdjustmentsDetailList.Add(convertPurchaseDetail);
                }
                else
                {
                    MessageBox.Show("Please product already added");
                    return;
                }

                if (AccountReceivableAdjustmentsDetailList.Count > 0)
                {

                    this.dgProduct.Rows.Clear();
                    this.dgProduct.Refresh();
                    //this.dgProduct.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    this.dgProduct.RowCount = AccountReceivableAdjustmentsDetailList.Count;
                    this.dgProduct.ColumnCount = 30;
                    this.dgProduct.Columns[0].Name = "ID";
                    this.dgProduct.Columns[0].Visible = false;
                    this.dgProduct.Columns[1].Name = "Product Name";
                    this.dgProduct.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[2].Visible = false;
                    this.dgProduct.Columns[2].Name = "Description";
                    this.dgProduct.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[3].Name = "Product Characteristic ID";
                    this.dgProduct.Columns[3].Visible = false;
                    this.dgProduct.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[4].Name = "Product Characteristic Name";
                    this.dgProduct.Columns[4].Visible = false;
                    this.dgProduct.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[5].Name = "Product Category ID";
                    this.dgProduct.Columns[5].Visible = false;
                    this.dgProduct.Columns[6].Name = "Product Category Name";
                    this.dgProduct.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[7].Name = "Product Type ID";
                    this.dgProduct.Columns[7].Visible = false;
                    this.dgProduct.Columns[8].Name = "Product Type Name";
                    this.dgProduct.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[9].Name = "Product Brand ID";
                    this.dgProduct.Columns[9].Visible = false;
                    this.dgProduct.Columns[10].Name = "Product Brand Name";
                    this.dgProduct.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[11].Name = "Per Piece Box";
                    this.dgProduct.Columns[11].Visible = false;
                    this.dgProduct.Columns[12].Name = "Location ID";
                    this.dgProduct.Columns[12].Visible = false;
                    this.dgProduct.Columns[13].Name = "Location Name";
                    this.dgProduct.Columns[13].Visible = false;
                    this.dgProduct.Columns[14].Name = "Product Color ID";
                    this.dgProduct.Columns[14].Visible = false;
                    this.dgProduct.Columns[15].Name = "Product Color Name";
                    this.dgProduct.Columns[16].Name = "Product Size ID";
                    this.dgProduct.Columns[16].Visible = false;
                    this.dgProduct.Columns[17].Name = "Product Size Name";
                    this.dgProduct.Columns[18].Name = "Product Unit ID";
                    this.dgProduct.Columns[18].Visible = false;
                    this.dgProduct.Columns[19].Name = "Product Unit Name";
                    this.dgProduct.Columns[20].Name = "Code";
                    this.dgProduct.Columns[20].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[21].Name = "PR";
                    this.dgProduct.Columns[22].Name = "PCD";
                    this.dgProduct.Columns[23].Name = "MFLM";
                    this.dgProduct.Columns[24].Name = "Pattern";
                    this.dgProduct.Columns[25].Name = "OffsetCenterBase";
                    this.dgProduct.Columns[25].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[26].Name = "Origin";
                    this.dgProduct.Columns[27].Name = "Unit Price";
                    this.dgProduct.Columns[28].Name = "Quantity";
                    this.dgProduct.Columns[29].Name = "Total Quantity Price";

                    for (int i = 0; i < AccountReceivableAdjustmentsDetailList.Count; i++)
                    {
                        //display all the data in productList to the datagridview
                        AccountReceivableAdjustmentsDetail accountReceivableAdjustmentsDetail = AccountReceivableAdjustmentsDetailList[i];
                        this.dgProduct.Rows[i].Cells[0].Value = accountReceivableAdjustmentsDetail.Id;
                        this.dgProduct.Rows[i].Cells[1].Value = accountReceivableAdjustmentsDetail.Product.strProductName;
                        this.dgProduct.Rows[i].Cells[2].Value = accountReceivableAdjustmentsDetail.Product.strDescription;

                        this.dgProduct.Rows[i].Cells[5].Value = accountReceivableAdjustmentsDetail.Product.ProductCategory.Id;
                        this.dgProduct.Rows[i].Cells[6].Value = accountReceivableAdjustmentsDetail.Product.ProductCategory.strName;
                        this.dgProduct.Rows[i].Cells[7].Value = accountReceivableAdjustmentsDetail.Product.ProductType.Id;
                        this.dgProduct.Rows[i].Cells[8].Value = accountReceivableAdjustmentsDetail.Product.ProductType.strName;
                        this.dgProduct.Rows[i].Cells[9].Value = accountReceivableAdjustmentsDetail.Product.ProductBrand.Id;
                        this.dgProduct.Rows[i].Cells[10].Value = accountReceivableAdjustmentsDetail.Product.ProductBrand.strName;

                        this.dgProduct.Rows[i].Cells[14].Value = accountReceivableAdjustmentsDetail.Product.ProductColor.Id;
                        this.dgProduct.Rows[i].Cells[15].Value = accountReceivableAdjustmentsDetail.Product.ProductColor.strName;
                        this.dgProduct.Rows[i].Cells[16].Value = accountReceivableAdjustmentsDetail.Product.ProductSize.Id;
                        this.dgProduct.Rows[i].Cells[17].Value = accountReceivableAdjustmentsDetail.Product.ProductSize.strName;
                        this.dgProduct.Rows[i].Cells[18].Value = accountReceivableAdjustmentsDetail.Product.ProductUnit.Id;
                        this.dgProduct.Rows[i].Cells[19].Value = accountReceivableAdjustmentsDetail.Product.ProductUnit.strName;
                        this.dgProduct.Rows[i].Cells[20].Value = accountReceivableAdjustmentsDetail.Product.strCode;
                        this.dgProduct.Rows[i].Cells[21].Value = accountReceivableAdjustmentsDetail.Product.strPR;
                        this.dgProduct.Rows[i].Cells[22].Value = accountReceivableAdjustmentsDetail.Product.strPCD;
                        this.dgProduct.Rows[i].Cells[23].Value = accountReceivableAdjustmentsDetail.Product.strMFLM;
                        this.dgProduct.Rows[i].Cells[24].Value = accountReceivableAdjustmentsDetail.Product.strPattern;
                        this.dgProduct.Rows[i].Cells[25].Value = accountReceivableAdjustmentsDetail.Product.strOffsetCenterBore;
                        this.dgProduct.Rows[i].Cells[26].Value = accountReceivableAdjustmentsDetail.Product.strOrigin;
                        this.dgProduct.Rows[i].Cells[27].Value = accountReceivableAdjustmentsDetail.UnitPrice;
                        this.dgProduct.Rows[i].Cells[28].Value = accountReceivableAdjustmentsDetail.Quantity;
                        this.dgProduct.Rows[i].Cells[29].Value = accountReceivableAdjustmentsDetail.TotalPrice;

                    }

                    setRowNumber(this.dgJournalEntry);
                    this.txtTotal.Text = string.Format("{0:0.00}", AccountReceivableAdjustmentsDetailList.Sum(g => g.TotalPrice));
                    this.txtInventoryPurchaseTotal.Text = string.Format("{0:0.00}", AccountReceivableAdjustmentsDetailList.Sum(g => g.TotalPrice));
                    //this.txtTotal.Text = string.Format("{0:0.00}", PurchaseDetailsList.Sum(g => g.TotalPrice));
                }

            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {

            try
            {

                if (AccountReceivableAdjustmentsDetailList.Count > 0)
                {
                    this.AccountReceivableAdjustmentsDetailList.RemoveAt(this.IndexGridInventory);
                    this.dgProduct.Rows.Clear();
                    this.dgProduct.Refresh();

                    if (AccountReceivableAdjustmentsDetailList.Count == 0)
                    {
                        this.txtTotal.Text = string.Format("{0:0.00}", AccountReceivableAdjustmentsDetailList.Sum(g => g.TotalPrice));
                        this.txtInventoryPurchaseTotal.Text = string.Format("{0:0.00}", AccountReceivableAdjustmentsDetailList.Sum(g => g.TotalPrice));
                        return;
                    }
                    //this.dgProduct.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    this.dgProduct.RowCount = AccountReceivableAdjustmentsDetailList.Count;
                    this.dgProduct.ColumnCount = 30;
                    this.dgProduct.Columns[0].Name = "ID";
                    this.dgProduct.Columns[0].Visible = false;
                    this.dgProduct.Columns[1].Name = "Product Name";
                    this.dgProduct.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[2].Visible = false;
                    this.dgProduct.Columns[2].Name = "Description";
                    this.dgProduct.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[3].Name = "Product Characteristic ID";
                    this.dgProduct.Columns[3].Visible = false;
                    this.dgProduct.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[4].Name = "Product Characteristic Name";
                    this.dgProduct.Columns[4].Visible = false;
                    this.dgProduct.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[5].Name = "Product Category ID";
                    this.dgProduct.Columns[5].Visible = false;
                    this.dgProduct.Columns[6].Name = "Product Category Name";
                    this.dgProduct.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[7].Name = "Product Type ID";
                    this.dgProduct.Columns[7].Visible = false;
                    this.dgProduct.Columns[8].Name = "Product Type Name";
                    this.dgProduct.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[9].Name = "Product Brand ID";
                    this.dgProduct.Columns[9].Visible = false;
                    this.dgProduct.Columns[10].Name = "Product Brand Name";
                    this.dgProduct.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[11].Name = "Per Piece Box";
                    this.dgProduct.Columns[11].Visible = false;
                    this.dgProduct.Columns[12].Name = "Location ID";
                    this.dgProduct.Columns[12].Visible = false;
                    this.dgProduct.Columns[13].Name = "Location Name";
                    this.dgProduct.Columns[13].Visible = false;
                    this.dgProduct.Columns[14].Name = "Product Color ID";
                    this.dgProduct.Columns[14].Visible = false;
                    this.dgProduct.Columns[15].Name = "Product Color Name";
                    this.dgProduct.Columns[16].Name = "Product Size ID";
                    this.dgProduct.Columns[16].Visible = false;
                    this.dgProduct.Columns[17].Name = "Product Size Name";
                    this.dgProduct.Columns[18].Name = "Product Unit ID";
                    this.dgProduct.Columns[18].Visible = false;
                    this.dgProduct.Columns[19].Name = "Product Unit Name";
                    this.dgProduct.Columns[20].Name = "Code";
                    this.dgProduct.Columns[20].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[21].Name = "PR";
                    this.dgProduct.Columns[22].Name = "PCD";
                    this.dgProduct.Columns[23].Name = "MFLM";
                    this.dgProduct.Columns[24].Name = "Pattern";
                    this.dgProduct.Columns[25].Name = "OffsetCenterBase";
                    this.dgProduct.Columns[25].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[26].Name = "Origin";
                    this.dgProduct.Columns[27].Name = "Unit Price";
                    this.dgProduct.Columns[28].Name = "Quantity";
                    this.dgProduct.Columns[29].Name = "Total Quantity Price";

                    for (int i = 0; i < AccountReceivableAdjustmentsDetailList.Count; i++)
                    {
                        //display all the data in productList to the datagridview
                        AccountReceivableAdjustmentsDetail accountReceivableAdjustmentsDetail = AccountReceivableAdjustmentsDetailList[i];
                        this.dgProduct.Rows[i].Cells[0].Value = accountReceivableAdjustmentsDetail.Id;
                        this.dgProduct.Rows[i].Cells[1].Value = accountReceivableAdjustmentsDetail.Product.strProductName;
                        this.dgProduct.Rows[i].Cells[2].Value = accountReceivableAdjustmentsDetail.Product.strDescription;

                        this.dgProduct.Rows[i].Cells[5].Value = accountReceivableAdjustmentsDetail.Product.ProductCategory.Id;
                        this.dgProduct.Rows[i].Cells[6].Value = accountReceivableAdjustmentsDetail.Product.ProductCategory.strName;
                        this.dgProduct.Rows[i].Cells[7].Value = accountReceivableAdjustmentsDetail.Product.ProductType.Id;
                        this.dgProduct.Rows[i].Cells[8].Value = accountReceivableAdjustmentsDetail.Product.ProductType.strName;
                        this.dgProduct.Rows[i].Cells[9].Value = accountReceivableAdjustmentsDetail.Product.ProductBrand.Id;
                        this.dgProduct.Rows[i].Cells[10].Value = accountReceivableAdjustmentsDetail.Product.ProductBrand.strName;

                        this.dgProduct.Rows[i].Cells[14].Value = accountReceivableAdjustmentsDetail.Product.ProductColor.Id;
                        this.dgProduct.Rows[i].Cells[15].Value = accountReceivableAdjustmentsDetail.Product.ProductColor.strName;
                        this.dgProduct.Rows[i].Cells[16].Value = accountReceivableAdjustmentsDetail.Product.ProductSize.Id;
                        this.dgProduct.Rows[i].Cells[17].Value = accountReceivableAdjustmentsDetail.Product.ProductSize.strName;
                        this.dgProduct.Rows[i].Cells[18].Value = accountReceivableAdjustmentsDetail.Product.ProductUnit.Id;
                        this.dgProduct.Rows[i].Cells[19].Value = accountReceivableAdjustmentsDetail.Product.ProductUnit.strName;
                        this.dgProduct.Rows[i].Cells[20].Value = accountReceivableAdjustmentsDetail.Product.strCode;
                        this.dgProduct.Rows[i].Cells[21].Value = accountReceivableAdjustmentsDetail.Product.strPR;
                        this.dgProduct.Rows[i].Cells[22].Value = accountReceivableAdjustmentsDetail.Product.strPCD;
                        this.dgProduct.Rows[i].Cells[23].Value = accountReceivableAdjustmentsDetail.Product.strMFLM;
                        this.dgProduct.Rows[i].Cells[24].Value = accountReceivableAdjustmentsDetail.Product.strPattern;
                        this.dgProduct.Rows[i].Cells[25].Value = accountReceivableAdjustmentsDetail.Product.strOffsetCenterBore;
                        this.dgProduct.Rows[i].Cells[26].Value = accountReceivableAdjustmentsDetail.Product.strOrigin;
                        this.dgProduct.Rows[i].Cells[27].Value = accountReceivableAdjustmentsDetail.UnitPrice;
                        this.dgProduct.Rows[i].Cells[28].Value = accountReceivableAdjustmentsDetail.Quantity;
                        this.dgProduct.Rows[i].Cells[29].Value = accountReceivableAdjustmentsDetail.TotalPrice;

                    }
                    setRowNumber(this.dgJournalEntry);
                    this.txtTotal.Text = string.Format("{0:0.00}", AccountReceivableAdjustmentsDetailList.Sum(g => g.TotalPrice));
                    this.txtInventoryPurchaseTotal.Text = string.Format("{0:0.00}", AccountReceivableAdjustmentsDetailList.Sum(g => g.TotalPrice));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}
