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
    public partial class frmAccountPayableAdjustmentReturnPurchase : MetroUserControl
    {
        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }
        public AccountPayableAdjustment AccountPayableAdjustment { get; set; }
        public AccountsPayableAdjustmentsServices AccountsPayableAdjustmentsServices { get; set; }
        public AccountsPayableAdjustmentsDetailServices AccountsPayableAdjustmentsDetailServices { get; set; }
        public AccountsPayableAdjustmentsTypeServices AccountsPayableAdjustmentsTypeServices { get; set; }

        public tblTBBatchHdrServices tblTBBatchHdrServices { get; set; }
        public GLTranServices GLTranServices { get; set; }
        public List<tblGLTranDetail> GLTranDetail { get; set; }
        public List<tblGLTranDetail> GLTranDetailInventoryEntry { get; set; }
        public int ID { get; set; }
        public int PaymentId { get; set; }
        public int PurchaseId { get; set; }
        public int IndexGrid { get; set; }

        public int IndexGridInventory { get; set; }
        public int GLTranHeader { get; set; }

        public List<AccountPayableAdjustmentsDetail> AccountPayableAdjustmentsDetailList { get; set; }

        public frmAccountPayableAdjustmentReturnPurchase()
        {

            AccountsPayableAdjustmentsTypeServices = new AccountsPayableAdjustmentsTypeServices();
            AccountsPayableAdjustmentsServices = new AccountsPayableAdjustmentsServices();
            AccountsPayableAdjustmentsDetailServices = new AccountsPayableAdjustmentsDetailServices();
            GLTranServices = new GLTranServices();
            GLTranDetail = new List<tblGLTranDetail>();
            AccountPayableAdjustmentsDetailList = new List<AccountPayableAdjustmentsDetail>();
            AccountPayableAdjustment = new AccountPayableAdjustment();
            tblTBBatchHdrServices = new tblTBBatchHdrServices();
            InitializeComponent();
        }

        private void btnSearchSale_Click(object sender, EventArgs e)
        {

            try
            {
                SearchPayment sp = new SearchPayment();
                sp.BringToFront();
                sp.TopMost = true;
                DialogResult res = sp.ShowDialog(this);

                if (res == DialogResult.OK)
                {
                    this.PaymentId = sp.Payment.Id;
                    this.txtPurchaseId.Text = sp.Payment.Id.ToString();
                    //this.txtPurchaseTransactionNO.Text = sp.Payment.Purchase.TRANo;
                    this.txtSupplier.Text = sp.Payment.Purchase.Supplier.strName;
                    //this.txtPaymentCV.Text = sp.Payment.PaymentCV.ToString();
                    this.PurchaseId = sp.Payment.Purchase.Id;
                    //this.txtTotal.Text = sp.Payment.PaymentTotal.ToString();
                    //this.txtPaymentSIDR.Text = sp.Payment.PaymentSIDR.ToString();
                    //this.txtCheckDetails.Text = sp.Payment.PaymentCheckDetail.ToString();

               

                    //this.Payment.Id = sp.Payment.Id;
                    //this.txtPaymentId.Text = sp.Payment.Id.ToString();
                    //this.txtPaymentCV.Text = sp.Payment.PaymentCV;
                    //this.txtPaymentSIDR.Text = sp.Payment.PaymentSIDR;
                    //this.dtPaymentTransactionDate.Value = (DateTime)sp.Payment.PaymentTransactionDate;
                    //this.txtPaymentTotal.Text = sp.Payment.PaymentTotal.ToString();
                    //this.chkIsCash.Checked = (bool)sp.Payment.PaymentIsCash;
                    //this.txtDescription.Text = sp.Payment.PaymentDescription;
                    //this.PurchaseId = (int)sp.Payment.PurchaseId;
                    //this.txtPurchaseId.Text = sp.Payment.PurchaseId.ToString();
                    //this.txtSupplier.Text = sp.Payment.Purchase.Supplier.strName;
                    //this.txtPurchasePONo.Text = sp.Payment.Purchase.PONo.ToString();
                    //this.txtPurchaseSIDR.Text = sp.Payment.Purchase.SIDR.ToString();
                    //this.txtPurchaseTotal.Text = sp.Payment.Purchase.Total.ToString();
                    //this.cbBank.SelectedValue = sp.Payment.PaymentBankId;
                    //this.txtCheckDetails.Text = sp.Payment.PaymentCheckDetail;
                    //this.GLTranHeader = sp.Payment.tblGLTranHeaders.Select(h => h.ID).FirstOrDefault();
                    //this.GLTranDetail = GLTranServices.GetGLEntryById(this.GLTranHeader).SelectMany(h => h.tblGLTranDetails).ToList();
                    //this.chkUseDefaultEntry.Checked = (bool)sp.Payment.tblGLTranHeaders.Select(h => h.blnUseDefaultEntry).FirstOrDefault();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void frmAccountReceivableAdjustments_Load(object sender, EventArgs e)
        {
            BankBAL bankBAL = new BankBAL();

            var bankList = bankBAL.getBank(string.Empty);
            //this.cbBank.DataSource = bankList;
            //this.cbBank.ValueMember = "ID";
            //this.cbBank.DisplayMember = "Name";

            var accountReceivableAdjustmentTpesList = AccountsPayableAdjustmentsTypeServices.GetAll()
                .Where(a => a.Name.ToUpper().Equals("RETURN PURCHASE"))
                .ToList();
            this.cbAdjustmentType.DataSource = accountReceivableAdjustmentTpesList;
            this.cbAdjustmentType.ValueMember = "ID";
            this.cbAdjustmentType.DisplayMember = "Name";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }

        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
              
                if (this.GLTranDetail.Sum(d => d.curCredit) != this.GLTranDetail.Sum(d => d.curDebit))
                {
                    MessageBox.Show("Disbal journal entry");
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


                if (AccountPayableAdjustmentsDetailList.Count == 0)
                {
                    MessageBox.Show("Please enter inventory");
                    return;
                }

                string TransType = (this.ID == 0) ? "insert" : "update";
                int? bankId = null;

 

                var adjustmentType = (this.cbAdjustmentType.SelectedItem == null) ? 0 : ((AccountsPayableAdjustmentsType)this.cbAdjustmentType.SelectedItem).Id;
                if (TransType.Equals("insert"))
                {
                    AccountPayableAdjustment = new AccountPayableAdjustment
                    { 
                         Id = this.ID,    
                         AccountsPayableAdjustmentTypeId = adjustmentType,
                         TransactionNo = this.txtAdjustmentTransactionNo.Text,
                         TransactionDate = this.dtAdjustmentTransactionDate.Value,
                         Description = this.txtDescription.Text,
                         TotalAmount = decimal.TryParse(this.txtPurchaseTotal.Text, out decimalParser) ? decimalParser : 0,
                         AdditionalDescription = this.txtAdditionalDescription.Text, // Added line
                         PurchaseId = this.PurchaseId
                    };

                    AccountPayableAdjustment = AccountsPayableAdjustmentsServices.AddReturnPurchases(AccountPayableAdjustment, this.GLTranDetail, this.chkUseDefaultEntry.Checked, this.AccountPayableAdjustmentsDetailList);
                    if (AccountPayableAdjustment != null)
                    {
                        this.AccountPayableAdjustmentsDetailList = AccountPayableAdjustment.AccountPayableAdjustmentsDetails.ToList();
                        this.txtDescription.Text = AccountPayableAdjustment.Description;
                        MessageBox.Show("Successfully saved");
                    }
                }
                else
                {
                    AccountPayableAdjustment.Id = this.ID;
                    AccountPayableAdjustment.AccountsPayableAdjustmentTypeId = adjustmentType;
                    AccountPayableAdjustment.TransactionNo = this.txtAdjustmentTransactionNo.Text;
                    AccountPayableAdjustment.TransactionDate = this.dtAdjustmentTransactionDate.Value;
                    AccountPayableAdjustment.Description = this.txtDescription.Text;
                    AccountPayableAdjustment.PurchaseId = this.PurchaseId;
                    AccountPayableAdjustment.TotalAmount = decimal.TryParse(this.txtPurchaseTotal.Text, out decimalParser) ? decimalParser : 0;
                    AccountPayableAdjustment.AdditionalDescription = this.txtAdditionalDescription.Text;

                    AccountPayableAdjustment = AccountsPayableAdjustmentsServices.UpdateReturnPurchases(AccountPayableAdjustment, this.GLTranDetail, this.chkUseDefaultEntry.Checked, this.AccountPayableAdjustmentsDetailList);
                  
                    if (AccountPayableAdjustment != null)
                    {
                        this.AccountPayableAdjustmentsDetailList = AccountPayableAdjustment.AccountPayableAdjustmentsDetails.ToList();
                        this.txtDescription.Text = AccountPayableAdjustment.Description;
                        MessageBox.Show("Successfully saved");
                    }

                }

                //GLTranHeader = AccountPayableAdjustment.tblGLTranHeaders.Select(h => h.ID).SingleOrDefault();
                //this.GLTranDetail = GLTranServices.GetGLEntryById(GLTranHeader).SelectMany(h => h.tblGLTranDetails).ToList();
                this.GLTranDetail = GLTranServices.GetGLEntryByAdjustmentReturnPurchaseId(AccountPayableAdjustment.Id, 11).SelectMany(h => h.tblGLTranDetails).ToList();

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

                this.GLTranDetailInventoryEntry = GLTranServices.GetGLEntryByAdjustmentReturnPurchaseId(AccountPayableAdjustment.Id, 1011).SelectMany(h => h.tblGLTranDetails).ToList();
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

                this.ID = AccountPayableAdjustment.Id;
                this.txtAdjustmentId.Text = AccountPayableAdjustment.Id.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                SearchAdjustmentAccountPayableAdjustmentsReturnPurchase spe = new SearchAdjustmentAccountPayableAdjustmentsReturnPurchase();
                spe.BringToFront();
                spe.TopMost = true;
                DialogResult res = spe.ShowDialog(this);

                if (res == DialogResult.OK)
                {
        
                    this.ID = spe.AccountPayableAdjustment.Id;
                    this.txtAdjustmentId.Text = spe.AccountPayableAdjustment.Id.ToString();
                    this.cbAdjustmentType.SelectedValue = spe.AccountPayableAdjustment.AccountsPayableAdjustmentTypeId;
                    this.txtAdjustmentTransactionNo.Text = spe.AccountPayableAdjustment.TransactionNo;
                    this.dtAdjustmentTransactionDate.Value = (DateTime)spe.AccountPayableAdjustment.TransactionDate;
                    //this.PaymentId = (int)spe.AccountPayableAdjustment.PaymentId;
                  
                    this.PurchaseId = (int)spe.AccountPayableAdjustment.PurchaseId;
                    this.txtPurchaseId.Text = spe.AccountPayableAdjustment.PurchaseId.ToString();
                    this.txtPurchasePONo.Text = spe.AccountPayableAdjustment.Purchase.PONo;
                    this.txtPurchaseSIDR.Text = spe.AccountPayableAdjustment.Purchase.SIDR;
                    this.txtSupplier.Text = spe.AccountPayableAdjustment.Purchase.Supplier.strName;
                    //this.txtPaymentCV.Text = spe.AccountPayableAdjustment.Payment.PaymentCV.ToString();
                    //this.txtPurchaseSIDR.Text = spe.AccountPayableAdjustment.Payment.PaymentSIDR.ToString();
                    //this.cbBank.SelectedValue = spe.AccountPayableAdjustment.Payment.PaymentBankId;
                    //this.chkIsCash.Checked = (bool)spe.AccountPayableAdjustment.Payment.PaymentIsCash;
                    // this.txtCheckDetails.Text = spe.AccountPayableAdjustment.Payment.PaymentCheckDetail;
                    this.txtPurchaseTotal.Text = spe.AccountPayableAdjustment.TotalAmount.ToString();
                    this.txtDescription.Text = spe.AccountPayableAdjustment.Description;
                    this.GLTranHeader = spe.AccountPayableAdjustment.tblGLTranHeaders.Select(h => h.ID).FirstOrDefault();
                    this.GLTranDetail = GLTranServices.GetGLEntryById(this.GLTranHeader).SelectMany(h => h.tblGLTranDetails).ToList();
                    this.AccountPayableAdjustmentsDetailList = AccountsPayableAdjustmentsDetailServices.GetAccountPayableAdjustmentsDetailProductByAccountPayableAdjustmentId(this.ID).SelectMany(ar => ar.AccountPayableAdjustmentsDetails).ToList();
                    this.txtAdditionalDescription.Text = spe.AccountPayableAdjustment.AdditionalDescription;

                    this.chkUseDefaultEntry.Checked = (bool)spe.AccountPayableAdjustment.tblGLTranHeaders.Select(h => h.blnUseDefaultEntry).FirstOrDefault();
           
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

                    if (AccountPayableAdjustmentsDetailList.Count > 0)
                    {

                        this.dgProduct.Rows.Clear();
                        this.dgProduct.Refresh();
                        //this.dgProduct.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        this.dgProduct.RowCount = AccountPayableAdjustmentsDetailList.Count;
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

                        for (int i = 0; i < AccountPayableAdjustmentsDetailList.Count; i++)
                        {
                            //display all the data in productList to the datagridview
                            AccountPayableAdjustmentsDetail accountPayableAdjustmentsDetail = AccountPayableAdjustmentsDetailList[i];
                            this.AccountPayableAdjustment.AccountPayableAdjustmentsDetails.Add(accountPayableAdjustmentsDetail);
                            this.dgProduct.Rows[i].Cells[0].Value = accountPayableAdjustmentsDetail.Id;
                            this.dgProduct.Rows[i].Cells[1].Value = accountPayableAdjustmentsDetail.Product.strProductName;
                            this.dgProduct.Rows[i].Cells[2].Value = accountPayableAdjustmentsDetail.Product.strDescription;
                            this.dgProduct.Rows[i].Cells[3].Value = 0;
                            this.dgProduct.Rows[i].Cells[4].Value = string.Empty;
                            this.dgProduct.Rows[i].Cells[5].Value = accountPayableAdjustmentsDetail.Product.ProductCategory.Id;
                            this.dgProduct.Rows[i].Cells[6].Value = accountPayableAdjustmentsDetail.Product.ProductCategory.strName;
                            this.dgProduct.Rows[i].Cells[7].Value = accountPayableAdjustmentsDetail.Product.ProductType.Id;
                            this.dgProduct.Rows[i].Cells[8].Value = accountPayableAdjustmentsDetail.Product.ProductType.strName;
                            this.dgProduct.Rows[i].Cells[9].Value = accountPayableAdjustmentsDetail.Product.ProductBrand.Id;
                            this.dgProduct.Rows[i].Cells[10].Value = accountPayableAdjustmentsDetail.Product.ProductBrand.strName;
                            //this.dgProduct.Rows[i].Cells[11].Value = product.PerPieceBox;
                            //this.dgProduct.Rows[i].Cells[12].Value = product.Location.ID;
                            //this.dgProduct.Rows[i].Cells[13].Value = product.Location.Name;
                            this.dgProduct.Rows[i].Cells[14].Value = accountPayableAdjustmentsDetail.Product.ProductColor.Id;
                            this.dgProduct.Rows[i].Cells[15].Value = accountPayableAdjustmentsDetail.Product.ProductColor.strName;
                            this.dgProduct.Rows[i].Cells[16].Value = accountPayableAdjustmentsDetail.Product.ProductSize.Id;
                            this.dgProduct.Rows[i].Cells[17].Value = accountPayableAdjustmentsDetail.Product.ProductSize.strName;
                            this.dgProduct.Rows[i].Cells[18].Value = accountPayableAdjustmentsDetail.Product.ProductUnit.Id;
                            this.dgProduct.Rows[i].Cells[19].Value = accountPayableAdjustmentsDetail.Product.ProductUnit.strName;
                            this.dgProduct.Rows[i].Cells[20].Value = accountPayableAdjustmentsDetail.Product.strCode;
                            this.dgProduct.Rows[i].Cells[21].Value = accountPayableAdjustmentsDetail.Product.strPR;
                            this.dgProduct.Rows[i].Cells[22].Value = accountPayableAdjustmentsDetail.Product.strPCD;
                            this.dgProduct.Rows[i].Cells[23].Value = accountPayableAdjustmentsDetail.Product.strMFLM;
                            this.dgProduct.Rows[i].Cells[24].Value = accountPayableAdjustmentsDetail.Product.strPattern;
                            this.dgProduct.Rows[i].Cells[25].Value = accountPayableAdjustmentsDetail.Product.strOffsetCenterBore;
                            this.dgProduct.Rows[i].Cells[26].Value = accountPayableAdjustmentsDetail.Product.strOrigin;
                            this.dgProduct.Rows[i].Cells[27].Value = accountPayableAdjustmentsDetail.UnitPrice;
                            this.dgProduct.Rows[i].Cells[28].Value = accountPayableAdjustmentsDetail.Quantity;
                            this.dgProduct.Rows[i].Cells[29].Value = accountPayableAdjustmentsDetail.TotalPrice;
                            //this.dgProduct.Rows[i].Cells[27].Value = product.curUnitPrice;
                        }

                        setRowNumber(this.dgJournalEntry);
                        this.txtInventoryPurchaseTotal.Text = string.Format("{0:0.00}", AccountPayableAdjustmentsDetailList.Sum(g => g.TotalPrice));
                       // this.txtTotal.Text = string.Format("{0:0.00}", AccountPayableAdjustmentsDetailList.Sum(g => g.TotalPrice));
                    }


                    this.GLTranDetailInventoryEntry = GLTranServices.GetGLEntryByAdjustmentReturnPurchaseId(this.ID, 1011).SelectMany(h => h.tblGLTranDetails).ToList();
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
                var adjustmentType = (this.cbAdjustmentType.SelectedItem == null) ? 0 : ((AccountsPayableAdjustmentsType)this.cbAdjustmentType.SelectedItem).Id;

                if (TransType.Equals("delete"))
                {
                    AccountPayableAdjustment = new AccountPayableAdjustment
                    {
                        Id = this.ID,
                        AccountsPayableAdjustmentTypeId = adjustmentType,
                        TransactionNo = this.txtAdjustmentTransactionNo.Text,
                        TransactionDate = this.dtAdjustmentTransactionDate.Value,
                        PaymentId = this.PaymentId,
                        Description = this.txtDescription.Text,
                        PurchaseId = this.PurchaseId
                    };

                    AccountsPayableAdjustmentsServices.RemoveReturnPurchases(AccountPayableAdjustment ,  this.AccountPayableAdjustmentsDetailList);

                    if (AccountPayableAdjustment != null)
                    {
                        this.ID = 0;
                        this.txtAdjustmentId.Text = String.Empty;
                        this.txtAdjustmentTransactionNo.Text = String.Empty;
                        this.PurchaseId = 0;
                        this.PaymentId = 0;
                        this.txtPurchaseId.Text = String.Empty;
                        //this.txtPurchaseTransactionNO.Text = String.Empty;
                        this.txtSupplier.Text = String.Empty;
                        this.txtPurchasePONo.Text = string.Empty;
                        this.txtPurchaseSIDR.Text = string.Empty;
                        this.txtPurchaseTotal.Text = string.Empty;
                        //this.txtPaymentCV.Text = String.Empty;
                        //this.chkIsCash.Checked = false;
                        //this.txtCheckDetails.Text = String.Empty;
                        //this.txtTotal.Text = String.Empty;
                        this.txtDescription.Text = String.Empty;
                        this.txtInventoryPurchaseTotal.Text = string.Empty;
                        //this.txtPaymentSIDR.Text = String.Empty;
                        //this.cbBank.Text = String.Empty;
                        //this.cbBank.SelectedText = String.Empty;
                        //this.cbBank.SelectedValue = 0;

                        this.dgJournalEntry.Rows.Clear();
                        this.dgJournalEntry.Refresh();
                        this.dgProduct.Rows.Clear();
                        this.dgProduct.Refresh();
                        this.AccountPayableAdjustmentsDetailList = new List<AccountPayableAdjustmentsDetail>();
                        this.dgInventoryEntry.Rows.Clear();
                        this.dgInventoryEntry.Refresh();


                        this.GLTranDetail.Clear();
                        this.GLTranHeader = 0;

                        this.txtTotalInventoryCredit.Text = string.Empty;
                        this.txtTotalInventoryDebit.Text = string.Empty;
                        this.txtTotalDebit.Text = string.Empty;
                        this.txtTotalCredit.Text = string.Empty;
                        this.txtDescription.Text = string.Empty;
                        GLTranDetail = new List<tblGLTranDetail>();
                        MessageBox.Show("Successfully deleted");

                    }
                  
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.ID = 0;
            this.txtAdjustmentId.Text = String.Empty;
            this.txtAdjustmentTransactionNo.Text = String.Empty;
            this.PurchaseId = 0;
            this.PaymentId = 0;
            this.txtPurchaseId.Text = String.Empty;
            //this.txtPurchaseTransactionNO.Text = String.Empty;
            this.txtSupplier.Text = String.Empty;
           // this.txtPaymentCV.Text = String.Empty;
           // this.chkIsCash.Checked = false;
           // this.txtCheckDetails.Text = String.Empty;
           // this.txtTotal.Text = String.Empty;
            this.txtDescription.Text = String.Empty;

            this.dgJournalEntry.Rows.Clear();
            this.dgJournalEntry.Refresh();
            this.GLTranDetail.Clear();
            this.GLTranHeader = 0;

            this.txtTotalDebit.Text = string.Empty;
            this.txtTotalCredit.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            GLTranDetail = new List<tblGLTranDetail>();

        }

        private void cbAdjustmentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSearchPayment_Click(object sender, EventArgs e)
        {
            try
            {
                SearchPurchase sp = new SearchPurchase();
                sp.BringToFront();
                sp.TopMost = true;
                sp.IsPurchase = true;
                DialogResult res = sp.ShowDialog(this);

                if (res == DialogResult.OK)
                {
                    this.PurchaseId = sp.Purchase.Id;
                    this.txtPurchaseId.Text = sp.Purchase.Id.ToString();
                    this.txtSupplier.Text = sp.Purchase.Supplier.strName;
                    this.txtPurchasePONo.Text = sp.Purchase.PONo;
                    this.txtPurchaseSIDR.Text = sp.Purchase.SIDR;
                    //this.txtPurchaseTotal.Text = sp.Purchase.Total.ToString();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {

            frmChooseReturnPurchaseProduct frmChooseReturnProduct = new frmChooseReturnPurchaseProduct();
            frmChooseReturnProduct.BringToFront();
            frmChooseReturnProduct.TopMost = true;
            frmChooseReturnProduct.IsPurchaseReturn = true;
            frmChooseReturnProduct.PurchaseID = this.PurchaseId;
            DialogResult res = frmChooseReturnProduct.ShowDialog(this);

            if (res == DialogResult.OK)
            {
                
                var convertPurchaseDetail = new AccountPayableAdjustmentsDetail
                {
                    ProductId = frmChooseReturnProduct.Product.Id,
                    //assign frmChooseProduct.Product to Product
                     
                    Product = frmChooseReturnProduct.Product,
                    //UnitPrice = frmChooseProduct.Product.curUnitPrice,
                    UnitPrice = frmChooseReturnProduct.ProductTotalUnitPrice,
                    Quantity = frmChooseReturnProduct.ProductQuantity,
                    TotalPrice = frmChooseReturnProduct.ProductTotalQuantityPrice,
                };

                if (!(AccountPayableAdjustmentsDetailList.Any(p => p.ProductId == convertPurchaseDetail.ProductId)))
                {
                   this.AccountPayableAdjustmentsDetailList.Add(convertPurchaseDetail);
                }
                else
                {
                    MessageBox.Show("Please product already added");
                    return;
                }

                if (AccountPayableAdjustmentsDetailList.Count > 0)
                {

                    this.dgProduct.Rows.Clear();
                    this.dgProduct.Refresh();
                    //this.dgProduct.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    this.dgProduct.RowCount = AccountPayableAdjustmentsDetailList.Count;
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

                    for (int i = 0; i < AccountPayableAdjustmentsDetailList.Count; i++)
                    {
                        //display all the data in productList to the datagridview
                        AccountPayableAdjustmentsDetail accountPayableAdjustmentsDetail = AccountPayableAdjustmentsDetailList[i];
                        this.dgProduct.Rows[i].Cells[0].Value = accountPayableAdjustmentsDetail.Id;
                        this.dgProduct.Rows[i].Cells[1].Value = accountPayableAdjustmentsDetail.Product.strProductName;
                        this.dgProduct.Rows[i].Cells[2].Value = accountPayableAdjustmentsDetail.Product.strDescription;
                       
                        this.dgProduct.Rows[i].Cells[5].Value = accountPayableAdjustmentsDetail.Product.ProductCategory.Id;
                        this.dgProduct.Rows[i].Cells[6].Value = accountPayableAdjustmentsDetail.Product.ProductCategory.strName;
                        this.dgProduct.Rows[i].Cells[7].Value = accountPayableAdjustmentsDetail.Product.ProductType.Id;
                        this.dgProduct.Rows[i].Cells[8].Value = accountPayableAdjustmentsDetail.Product.ProductType.strName;
                        this.dgProduct.Rows[i].Cells[9].Value = accountPayableAdjustmentsDetail.Product.ProductBrand.Id;
                        this.dgProduct.Rows[i].Cells[10].Value = accountPayableAdjustmentsDetail.Product.ProductBrand.strName;
                
                        this.dgProduct.Rows[i].Cells[14].Value = accountPayableAdjustmentsDetail.Product.ProductColor.Id;
                        this.dgProduct.Rows[i].Cells[15].Value = accountPayableAdjustmentsDetail.Product.ProductColor.strName;
                        this.dgProduct.Rows[i].Cells[16].Value = accountPayableAdjustmentsDetail.Product.ProductSize.Id;
                        this.dgProduct.Rows[i].Cells[17].Value = accountPayableAdjustmentsDetail.Product.ProductSize.strName;
                        this.dgProduct.Rows[i].Cells[18].Value = accountPayableAdjustmentsDetail.Product.ProductUnit.Id;
                        this.dgProduct.Rows[i].Cells[19].Value = accountPayableAdjustmentsDetail.Product.ProductUnit.strName;
                        this.dgProduct.Rows[i].Cells[20].Value = accountPayableAdjustmentsDetail.Product.strCode;
                        this.dgProduct.Rows[i].Cells[21].Value = accountPayableAdjustmentsDetail.Product.strPR;
                        this.dgProduct.Rows[i].Cells[22].Value = accountPayableAdjustmentsDetail.Product.strPCD;
                        this.dgProduct.Rows[i].Cells[23].Value = accountPayableAdjustmentsDetail.Product.strMFLM;
                        this.dgProduct.Rows[i].Cells[24].Value = accountPayableAdjustmentsDetail.Product.strPattern;
                        this.dgProduct.Rows[i].Cells[25].Value = accountPayableAdjustmentsDetail.Product.strOffsetCenterBore;
                        this.dgProduct.Rows[i].Cells[26].Value = accountPayableAdjustmentsDetail.Product.strOrigin;
                        this.dgProduct.Rows[i].Cells[27].Value = accountPayableAdjustmentsDetail.UnitPrice;
                        this.dgProduct.Rows[i].Cells[28].Value = accountPayableAdjustmentsDetail.Quantity;
                        this.dgProduct.Rows[i].Cells[29].Value = accountPayableAdjustmentsDetail.TotalPrice;
                 
                    }

                    setRowNumber(this.dgJournalEntry);
                    this.txtPurchaseTotal.Text = string.Format("{0:0.00}", AccountPayableAdjustmentsDetailList.Sum(g => g.TotalPrice));
                    this.txtInventoryPurchaseTotal.Text = string.Format("{0:0.00}", AccountPayableAdjustmentsDetailList.Sum(g => g.TotalPrice));
                    //this.txtTotal.Text = string.Format("{0:0.00}", PurchaseDetailsList.Sum(g => g.TotalPrice));
                }

            }

        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {

                if (AccountPayableAdjustmentsDetailList.Count > 0)
                {
                    this.AccountPayableAdjustmentsDetailList.RemoveAt(this.IndexGridInventory);
                    this.dgProduct.Rows.Clear();
                    this.dgProduct.Refresh();

                    if (AccountPayableAdjustmentsDetailList.Count == 0)
                    {
                        this.txtPurchaseTotal.Text = string.Format("{0:0.00}", AccountPayableAdjustmentsDetailList.Sum(g => g.TotalPrice));
                        this.txtInventoryPurchaseTotal.Text = string.Format("{0:0.00}", AccountPayableAdjustmentsDetailList.Sum(g => g.TotalPrice));
                        return;
                    }
                    //this.dgProduct.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    this.dgProduct.RowCount = AccountPayableAdjustmentsDetailList.Count;
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

                    for (int i = 0; i < AccountPayableAdjustmentsDetailList.Count; i++)
                    {
                        //display all the data in productList to the datagridview
                        AccountPayableAdjustmentsDetail accountPayableAdjustmentsDetail = AccountPayableAdjustmentsDetailList[i];
                        this.dgProduct.Rows[i].Cells[0].Value = accountPayableAdjustmentsDetail.Id;
                        this.dgProduct.Rows[i].Cells[1].Value = accountPayableAdjustmentsDetail.Product.strProductName;
                        this.dgProduct.Rows[i].Cells[2].Value = accountPayableAdjustmentsDetail.Product.strDescription;

                        this.dgProduct.Rows[i].Cells[5].Value = accountPayableAdjustmentsDetail.Product.ProductCategory.Id;
                        this.dgProduct.Rows[i].Cells[6].Value = accountPayableAdjustmentsDetail.Product.ProductCategory.strName;
                        this.dgProduct.Rows[i].Cells[7].Value = accountPayableAdjustmentsDetail.Product.ProductType.Id;
                        this.dgProduct.Rows[i].Cells[8].Value = accountPayableAdjustmentsDetail.Product.ProductType.strName;
                        this.dgProduct.Rows[i].Cells[9].Value = accountPayableAdjustmentsDetail.Product.ProductBrand.Id;
                        this.dgProduct.Rows[i].Cells[10].Value = accountPayableAdjustmentsDetail.Product.ProductBrand.strName;

                        this.dgProduct.Rows[i].Cells[14].Value = accountPayableAdjustmentsDetail.Product.ProductColor.Id;
                        this.dgProduct.Rows[i].Cells[15].Value = accountPayableAdjustmentsDetail.Product.ProductColor.strName;
                        this.dgProduct.Rows[i].Cells[16].Value = accountPayableAdjustmentsDetail.Product.ProductSize.Id;
                        this.dgProduct.Rows[i].Cells[17].Value = accountPayableAdjustmentsDetail.Product.ProductSize.strName;
                        this.dgProduct.Rows[i].Cells[18].Value = accountPayableAdjustmentsDetail.Product.ProductUnit.Id;
                        this.dgProduct.Rows[i].Cells[19].Value = accountPayableAdjustmentsDetail.Product.ProductUnit.strName;
                        this.dgProduct.Rows[i].Cells[20].Value = accountPayableAdjustmentsDetail.Product.strCode;
                        this.dgProduct.Rows[i].Cells[21].Value = accountPayableAdjustmentsDetail.Product.strPR;
                        this.dgProduct.Rows[i].Cells[22].Value = accountPayableAdjustmentsDetail.Product.strPCD;
                        this.dgProduct.Rows[i].Cells[23].Value = accountPayableAdjustmentsDetail.Product.strMFLM;
                        this.dgProduct.Rows[i].Cells[24].Value = accountPayableAdjustmentsDetail.Product.strPattern;
                        this.dgProduct.Rows[i].Cells[25].Value = accountPayableAdjustmentsDetail.Product.strOffsetCenterBore;
                        this.dgProduct.Rows[i].Cells[26].Value = accountPayableAdjustmentsDetail.Product.strOrigin;
                        this.dgProduct.Rows[i].Cells[27].Value = accountPayableAdjustmentsDetail.UnitPrice;
                        this.dgProduct.Rows[i].Cells[28].Value = accountPayableAdjustmentsDetail.Quantity;
                        this.dgProduct.Rows[i].Cells[29].Value = accountPayableAdjustmentsDetail.TotalPrice;

                    }
                    setRowNumber(this.dgJournalEntry);
                    this.txtPurchaseTotal.Text = string.Format("{0:0.00}", AccountPayableAdjustmentsDetailList.Sum(g => g.TotalPrice));
                    this.txtInventoryPurchaseTotal.Text = string.Format("{0:0.00}", AccountPayableAdjustmentsDetailList.Sum(g => g.TotalPrice));
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

        //public void checkAdjustmentType() {

        //    var adjustmentType = (this.cbAdjustmentType.SelectedItem == null) ? string.Empty : ((AccountsReceivableAdjustmentsType)this.cbAdjustmentType.SelectedItem).Name;

        //    if (adjustmentType.ToLower().Equals("return check"))
        //    {
        //        this.txtTotal.Enabled = false;
        //        this.txtTotal.IsInputReadOnly = true;
        //        this.txtTotal.BackColor = Color.Transparent;
        //        this.txtTotal.BackgroundStyle.BackColor = System.Drawing.SystemColors.Control;
        //        this.txtTotal.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.Control;


        //    }
        //    else
        //    {
        //        this.txtTotal.Value = 0;
        //        this.txtTotal.Enabled = true;
        //        this.txtTotal.IsInputReadOnly = false;
        //        this.txtTotal.BackColor = Color.Transparent;
        //        this.txtTotal.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
        //        this.txtTotal.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.Window;
        //    }
        //}
    }
}
