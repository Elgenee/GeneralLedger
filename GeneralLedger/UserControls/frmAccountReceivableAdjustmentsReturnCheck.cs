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
    public partial class frmAccountReceivableAdjustmentsReturnCheck : MetroUserControl
    {
        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }
        public AccountReceivableAdjustment AccountReceivableAdjustment { get; set; }
        public AccountReceivableAdjustmentsServices AccountReceivableAdjustmentsServices { get; set; }
        public AccountsReceivableAdjustmentsTypeServices AccountsReceivableAdjustmentsTypeServices { get; set; }

        public tblTBBatchHdrServices tblTBBatchHdrServices { get; set; }
        public GLTranServices GLTranServices { get; set; }
        public List<tblGLTranDetail> GLTranDetail { get; set; }
        public int ID { get; set; }
        public int CollectionId { get; set; }
        public int SaleId { get; set; }
        public int IndexGrid { get; set; }
        public int GLTranHeader { get; set; }

        public frmAccountReceivableAdjustmentsReturnCheck()
        {
          
            AccountsReceivableAdjustmentsTypeServices = new AccountsReceivableAdjustmentsTypeServices();
            AccountReceivableAdjustmentsServices = new AccountReceivableAdjustmentsServices();
            GLTranServices = new GLTranServices();
            GLTranDetail = new List<tblGLTranDetail>();
            AccountReceivableAdjustment = new AccountReceivableAdjustment();
            tblTBBatchHdrServices = new tblTBBatchHdrServices();
            InitializeComponent();
        }

        private void btnSearchSale_Click(object sender, EventArgs e)
        {
            try
            {
                SearchCollection sje = new SearchCollection();
                sje.BringToFront();
                sje.TopMost = true;
                DialogResult res = sje.ShowDialog(this);

                if (res == DialogResult.OK)
                {
                    this.txtCollectionId.Text = sje.Collection.Id.ToString();
                    this.txtSaleTransactionNo.Text = sje.Collection.Sale.TRANo;
                    this.CollectionId = sje.Collection.Id;
                    this.txtCollectionTransactionNo.Text = sje.Collection.TRANo;
                    this.txtCustomerName.Text = sje.Collection.Sale.Customer.strName;
                    this.cbBank.SelectedValue = sje.Collection.BankId;
                    this.txtCheckDetails.Text = sje.Collection.CheckDetail;
                    this.txtCollectionTotal.Text = sje.Collection.Total.ToString();
                    this.chkIsCash.Checked = (bool)sje.Collection.IsCash;
                    this.SaleId = (int)sje.Collection.SalesId;

                    checkAdjustmentType();

                    //this.SaleId = sje.Sale.Id;
                    //this.txtSaleID.Text = sje.Sale.Id.ToString();
                    //this.txtSaleTransactionNo.Text = sje.Sale.TRANo;
                    //this.txtSalePONo.Text = sje.Sale.PONo;
                    //this.txtCustomerName.Text = sje.Sale.customerName.strName;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void frmAccountReceivableAdjustments_Load(object sender, EventArgs e)
        {
            BankBAL bankBAL = new BankBAL();

            var bankList = bankBAL.getBank(string.Empty);
            this.cbBank.DataSource = bankList;
            this.cbBank.ValueMember = "ID";
            this.cbBank.DisplayMember = "Name";

            var accountReceivableAdjustmentTpesList = AccountsReceivableAdjustmentsTypeServices.GetAll();
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
                if (this.CollectionId == 0)
                {
                    MessageBox.Show("Please select collection...");
                    return;
                }

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

                var adjustmentType = (this.cbAdjustmentType.SelectedItem == null) ? 0 : ((AccountsReceivableAdjustmentsType)this.cbAdjustmentType.SelectedItem).Id;
                if (TransType.Equals("insert"))
                {
                    AccountReceivableAdjustment = new AccountReceivableAdjustment { 
                         Id = this.ID,    
                         AccountsReceivableAdjustmentsTypeId = adjustmentType,
                         TransactionNo = this.txtAdjustmentTransactionNo.Text,
                         TransactionDate = this.dtAdjustmentTransactionDate.Value,
                         CollectionId = this.CollectionId,
                         Descrpition = this.txtDescription.Text,
                         TotalAmount = decimal.TryParse(this.txtCollectionTotal.Text, out decimalParser) ? decimalParser : 0,
                         SalesId = this.SaleId
                    };

                    AccountReceivableAdjustment = AccountReceivableAdjustmentsServices.Add(AccountReceivableAdjustment, this.GLTranDetail, this.chkUseDefaultEntry.Checked);

                    if (AccountReceivableAdjustment != null)
                    {
                        MessageBox.Show("Successfully saved");
                    }
                }
                else
                {
                    AccountReceivableAdjustment.Id = this.ID;
                    AccountReceivableAdjustment.AccountsReceivableAdjustmentsTypeId = adjustmentType;
                    AccountReceivableAdjustment.TransactionNo = this.txtAdjustmentTransactionNo.Text;
                    AccountReceivableAdjustment.TransactionDate = this.dtAdjustmentTransactionDate.Value;
                    AccountReceivableAdjustment.CollectionId = this.CollectionId;
                    AccountReceivableAdjustment.Descrpition = this.txtDescription.Text;
                    AccountReceivableAdjustment.SalesId = this.SaleId;
                    AccountReceivableAdjustment.TotalAmount = decimal.TryParse(this.txtCollectionTotal.Text, out decimalParser) ? decimalParser : 0;

                    AccountReceivableAdjustment = AccountReceivableAdjustmentsServices.Update(AccountReceivableAdjustment, this.GLTranDetail, this.chkUseDefaultEntry.Checked);
                    if (AccountReceivableAdjustment != null)
                    {
                        MessageBox.Show("Successfully saved");
                    }

                }

                GLTranHeader = AccountReceivableAdjustment.tblGLTranHeaders.Select(h => h.ID).SingleOrDefault();
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

                this.ID = AccountReceivableAdjustment.Id;
                this.txtAdjustmentId.Text = AccountReceivableAdjustment.Id.ToString();

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
                SearchAdjustmentAccountReceivableAdjustments sje = new SearchAdjustmentAccountReceivableAdjustments();
                sje.BringToFront();
                sje.TopMost = true;
                DialogResult res = sje.ShowDialog(this);

                if (res == DialogResult.OK)
                {
                    checkAdjustmentType();
                    this.ID = sje.AccountReceivableAdjustment.Id;
                    this.txtAdjustmentId.Text = sje.AccountReceivableAdjustment.Id.ToString();
                    this.cbAdjustmentType.SelectedValue = sje.AccountReceivableAdjustment.AccountsReceivableAdjustmentsTypeId;
                    this.txtAdjustmentTransactionNo.Text = sje.AccountReceivableAdjustment.TransactionNo;
                    this.dtAdjustmentTransactionDate.Value = (DateTime)sje.AccountReceivableAdjustment.TransactionDate;
                    this.CollectionId = (int)sje.AccountReceivableAdjustment.CollectionId;
                    this.txtCollectionId.Text = sje.AccountReceivableAdjustment.CollectionId.ToString();
                    this.SaleId = (int)sje.AccountReceivableAdjustment.SalesId;
                    this.txtSaleTransactionNo.Text = sje.AccountReceivableAdjustment.Collection.Sale.TRANo;
                    this.txtCustomerName.Text = sje.AccountReceivableAdjustment.Collection.Sale.Customer.strName;
                    this.txtCollectionTransactionNo.Text = sje.AccountReceivableAdjustment.Collection.TRANo.ToString();
                    this.cbBank.SelectedValue = sje.AccountReceivableAdjustment.Collection.BankId;
                    this.chkIsCash.Checked = (bool)sje.AccountReceivableAdjustment.Collection.IsCash;
                    this.txtCheckDetails.Text = sje.AccountReceivableAdjustment.Collection.CheckDetail;
                    this.txtCollectionTotal.Text = sje.AccountReceivableAdjustment.TotalAmount.ToString();
                    this.txtDescription.Text = sje.AccountReceivableAdjustment.Descrpition;
                    this.GLTranHeader = sje.AccountReceivableAdjustment.tblGLTranHeaders.Select(h => h.ID).FirstOrDefault();
                    this.GLTranDetail = GLTranServices.GetGLEntryById(this.GLTranHeader).SelectMany(h => h.tblGLTranDetails).ToList();
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
                var adjustmentType = (this.cbAdjustmentType.SelectedItem == null) ? 0 : ((AccountsReceivableAdjustmentsType)this.cbAdjustmentType.SelectedItem).Id;

                if (TransType.Equals("delete"))
                {
                    AccountReceivableAdjustment = new AccountReceivableAdjustment
                    {
                        Id = this.ID,
                        AccountsReceivableAdjustmentsTypeId = adjustmentType,
                        TransactionNo = this.txtAdjustmentTransactionNo.Text,
                        TransactionDate = this.dtAdjustmentTransactionDate.Value,
                        CollectionId = this.CollectionId,
                        Descrpition = this.txtDescription.Text,
                        SalesId = this.SaleId
                    };

                    AccountReceivableAdjustmentsServices.Remove(AccountReceivableAdjustment);

                    if (AccountReceivableAdjustmentsServices != null)
                    {
                        this.ID = 0;
                        this.txtAdjustmentId.Text = String.Empty;
                        this.txtAdjustmentTransactionNo.Text = String.Empty;
                        this.SaleId = 0;
                        this.CollectionId = 0;
                        this.txtCollectionId.Text = String.Empty;
                        this.txtSaleTransactionNo.Text = String.Empty;
                        this.txtCustomerName.Text = String.Empty;
                        this.txtCollectionTransactionNo.Text = String.Empty;
                        this.chkIsCash.Checked = false;
                        this.txtCheckDetails.Text = String.Empty;
                        this.txtCollectionTotal.Text = String.Empty;
                        this.txtDescription.Text = String.Empty;
                        this.cbBank.Text = String.Empty;
                        this.cbBank.SelectedText = String.Empty;
                        this.cbBank.SelectedValue = 0;

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
            this.SaleId = 0;
            this.CollectionId = 0;
            this.txtCollectionId.Text = String.Empty;
            this.txtSaleTransactionNo.Text = String.Empty;
            this.txtCustomerName.Text = String.Empty;
            this.txtCollectionTransactionNo.Text = String.Empty;
            this.chkIsCash.Checked = false;
            this.txtCheckDetails.Text = String.Empty;
            this.txtCollectionTotal.Text = String.Empty;
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
            checkAdjustmentType();
        }

        public void checkAdjustmentType() {
           
            var adjustmentType = (this.cbAdjustmentType.SelectedItem == null) ? string.Empty : ((AccountsReceivableAdjustmentsType)this.cbAdjustmentType.SelectedItem).Name;

            if (adjustmentType.ToLower().Equals("return check"))
            {
                this.txtCollectionTotal.Enabled = false;
                this.txtCollectionTotal.IsInputReadOnly = true;
                this.txtCollectionTotal.BackColor = Color.Transparent;
                this.txtCollectionTotal.BackgroundStyle.BackColor = System.Drawing.SystemColors.Control;
                this.txtCollectionTotal.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.Control;


            }
            else
            {
                this.txtCollectionTotal.Value = 0;
                this.txtCollectionTotal.Enabled = true;
                this.txtCollectionTotal.IsInputReadOnly = false;
                this.txtCollectionTotal.BackColor = Color.Transparent;
                this.txtCollectionTotal.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
                this.txtCollectionTotal.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.Window;
            }
        }
    }
}
