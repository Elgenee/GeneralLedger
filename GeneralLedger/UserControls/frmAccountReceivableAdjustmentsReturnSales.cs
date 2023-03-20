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
        public AccountsReceivableAdjustmentsTypeServices AccountsReceivableAdjustmentsTypeServices { get; set; }

        public tblTBBatchHdrServices tblTBBatchHdrServices { get; set; }
        public GLTranServices GLTranServices { get; set; }
        public List<tblGLTranDetail> GLTranDetail { get; set; }

        public int ID { get; set; }

        public int SaleId { get; set; }
        public int IndexGrid { get; set; }
        public int GLTranHeader { get; set; }


        public frmAccountReceivableAdjustmentsReturnSales()
        {
            AccountsReceivableAdjustmentsTypeServices = new AccountsReceivableAdjustmentsTypeServices();
            AccountReceivableAdjustmentsServices = new AccountReceivableAdjustmentsServices();
            GLTranServices = new GLTranServices();
            GLTranDetail = new List<tblGLTranDetail>();
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
                DialogResult res = sje.ShowDialog(this);

                if (res == DialogResult.OK)
                {
                    this.SaleId = sje.Sale.Id;
                    this.txtSaleID.Text = sje.Sale.Id.ToString();
                    this.txtSaleTransactionNo.Text = sje.Sale.TRANo;
                    this.txtSalePONo.Text = sje.Sale.PONo;
                    this.txtCustomerName.Text = sje.Sale.Customer.strName;
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
                    AccountReceivableAdjustment.Descrpition = this.txtDescription.Text;
                    AccountReceivableAdjustment.SalesId = this.SaleId;
  

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

    }
}
