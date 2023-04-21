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
        public AccountsPayableAdjustmentsTypeServices AccountsPayableAdjustmentsTypeServices { get; set; }

        public tblTBBatchHdrServices tblTBBatchHdrServices { get; set; }
        public GLTranServices GLTranServices { get; set; }
        public List<tblGLTranDetail> GLTranDetail { get; set; }
        public int ID { get; set; }
        public int PaymentId { get; set; }
        public int PurchaseId { get; set; }
        public int IndexGrid { get; set; }
        public int GLTranHeader { get; set; }

        public frmAccountPayableAdjustmentReturnPurchase()
        {

            AccountsPayableAdjustmentsTypeServices = new AccountsPayableAdjustmentsTypeServices();
            AccountsPayableAdjustmentsServices = new AccountsPayableAdjustmentsServices();
            GLTranServices = new GLTranServices();
            GLTranDetail = new List<tblGLTranDetail>();
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

                string TransType = (this.ID == 0) ? "insert" : "update";
                int? bankId = null;

                //if (this.chkIsCash.Checked == false)
                //{
                //    bankId = (this.cbBank.SelectedItem == null) ? 0 : ((Tier.BO.Bank)this.cbBank.SelectedItem).ID;
                //}

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
                         PurchaseId = this.PurchaseId
                    };

                    AccountPayableAdjustment = AccountsPayableAdjustmentsServices.AddReturnPurchases(AccountPayableAdjustment, this.GLTranDetail, this.chkUseDefaultEntry.Checked);
                    if (AccountPayableAdjustment != null)
                    {
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

                    AccountPayableAdjustment = AccountsPayableAdjustmentsServices.UpdateReturnPurchases(AccountPayableAdjustment, this.GLTranDetail, this.chkUseDefaultEntry.Checked);
                    if (AccountPayableAdjustment != null)
                    {
                        MessageBox.Show("Successfully saved");
                    }

                }

                GLTranHeader = AccountPayableAdjustment.tblGLTranHeaders.Select(h => h.ID).SingleOrDefault();
                this.GLTranDetail = GLTranServices.GetGLEntryById(GLTranHeader).SelectMany(h => h.tblGLTranDetails).ToList();
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

                    AccountsPayableAdjustmentsServices.RemoveReturnPurchases(AccountPayableAdjustment);

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
                        //this.txtPaymentSIDR.Text = String.Empty;
                        //this.cbBank.Text = String.Empty;
                        //this.cbBank.SelectedText = String.Empty;
                        //this.cbBank.SelectedValue = 0;

                        this.dgJournalEntry.Rows.Clear();
                        this.dgJournalEntry.Refresh();
                        this.GLTranDetail.Clear();
                        this.GLTranHeader = 0;

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
                DialogResult res = sp.ShowDialog(this);

                if (res == DialogResult.OK)
                {
                    this.PurchaseId = sp.Purchase.Id;
                    this.txtPurchaseId.Text = sp.Purchase.Id.ToString();
                    this.txtSupplier.Text = sp.Purchase.Supplier.strName;
                    this.txtPurchasePONo.Text = sp.Purchase.PONo;
                    this.txtPurchaseSIDR.Text = sp.Purchase.SIDR;
                    this.txtPurchaseTotal.Text = sp.Purchase.Total.ToString();

                }

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
