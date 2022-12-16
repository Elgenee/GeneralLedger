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
    public partial class frmCollection : MetroUserControl
    {
        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }
        public Collection Collection { get; set; }
        public CollectionServices CollectionServices { get; set; }
        public GLTranServices GLTranServices { get; set; }
        public int ID { get; set; }
        public int SaleId { get; set; }
        public List<tblGLTranDetail> GLTranDetail { get; set; }
        public int IndexGrid { get; set; }
        public int GLTranHeader { get; set; }

        public frmCollection()
        {
            InitializeComponent();
            CollectionServices = new CollectionServices();
            GLTranServices = new GLTranServices();
            GLTranDetail = new List<tblGLTranDetail>();
            SaleId = 0;
            this.Collection = new Collection();
        }

        private void frmCollection_Load(object sender, EventArgs e)
        {
            BankBAL bankBAL = new BankBAL();

            var bankList = bankBAL.getBank(string.Empty);
            this.cbBank.DataSource = bankList;
            this.cbBank.ValueMember = "ID";
            this.cbBank.DisplayMember = "Name";
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel5_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel7_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel6_Click(object sender, EventArgs e)
        {

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
                if (this.SaleId == 0)
                {
                    MessageBox.Show("Please select sales...");
                    return;
                }

                int intParser;
                decimal decimalParser;

                string TransType = (this.ID == 0) ? "insert" : "update";
                int? bankId = null;

                //if (this.chkIsCash.Checked == false)
                //{
                //    bankId = (this.cbBank.SelectedItem == null) ? 0 : ((Tier.BO.Bank)this.cbBank.SelectedItem).ID;
                //}

                bankId = (this.cbBank.SelectedItem == null) ? 0 : ((Tier.BO.Bank)this.cbBank.SelectedItem).ID;

                if (TransType.Equals("insert"))
                {
                    Collection = new Collection
                    {
                        Id = this.ID,
                        TRANo = this.txtTransactionNo.Text,
                        Total = decimal.TryParse(this.txtTotal.Text, out decimalParser) ? decimalParser : 0,
                        TransactionDate = this.dtTransactionDate.Value,
                        SalesId = this.SaleId,
                        BankId = bankId,
                        CheckDetail = this.txtCheckDetails.Text,
                        Description = this.txtDescription.Text,
                        IsCash = this.chkIsCash.Checked
                    };

                    Collection = CollectionServices.Add(Collection, this.GLTranDetail, this.chkUseDefaultEntry.Checked);

                    if (Collection != null)
                    {
                        MessageBox.Show("Successfully saved");
                    }
                }
                else
                {
                    Collection.Id = this.ID;
                    Collection.TRANo = this.txtTransactionNo.Text;
                    Collection.Total = decimal.TryParse(this.txtTotal.Text, out decimalParser) ? decimalParser : 0;
                    Collection.TransactionDate = this.dtTransactionDate.Value;
                    Collection.SalesId = this.SaleId;
                    Collection.BankId = bankId;
                    Collection.CheckDetail = this.txtCheckDetails.Text;
                    Collection.Description = this.txtDescription.Text;
                    Collection.IsCash = this.chkIsCash.Checked;
                    Collection = CollectionServices.Update(Collection, this.GLTranDetail, this.chkUseDefaultEntry.Checked);

                    if (Collection != null)
                    {
                        MessageBox.Show("Successfully saved");
                    }
                }

                GLTranHeader = Collection.tblGLTranHeaders.Select(h => h.ID).SingleOrDefault();
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

                this.ID = Collection.Id;
                this.txtCollectionId.Text = Collection.Id.ToString();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void chkIsCash_CheckStateChanged(object sender, EventArgs e)
        {
            //if (this.chkIsCash.Checked)
            //{
            //    this.cbBank.Enabled = false;
            //    this.txtCheckDetails.Enabled = false;
               
            //}
            //else
            //{
            //    this.cbBank.Enabled = true;
            //    this.txtCheckDetails.Enabled = true;
            //}
        }

        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            //if (this.ID == 0)
            //{
            //    MessageBox.Show("Please save transaction first before editing entry");
            //    return;
            //}

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            try
            {
                SearchCollection sje = new SearchCollection();
                sje.BringToFront();
                sje.TopMost = true;
                DialogResult res = sje.ShowDialog(this);

                if (res == DialogResult.OK)
                {
                  
                    this.ID = sje.Collection.Id;
                    this.Collection.Id = sje.Collection.Id;
                    this.txtCollectionId.Text = sje.Collection.Id.ToString();
                    this.txtTransactionNo.Text = sje.Collection.TRANo;
                    this.dtTransactionDate.Value = (DateTime)sje.Collection.TransactionDate;
                    this.txtTotal.Text = sje.Collection.Total.ToString();
                    this.chkIsCash.Checked = (bool)sje.Collection.IsCash;
                    this.txtDescription.Text = sje.Collection.Description;
                    this.SaleId = (int)sje.Collection.SalesId;
                    this.txtSaleID.Text = sje.Collection.SalesId.ToString();
                    this.txtSaleTransactionNo.Text = sje.Collection.Sale.TRANo;
                    this.txtSalePONo.Text = sje.Collection.Sale.PONo;
                    this.txtCustomerName.Text = sje.Collection.Sale.Customer.strName;
                    this.cbBank.SelectedValue = sje.Collection.BankId;
                    this.txtCheckDetails.Text = sje.Collection.CheckDetail;

                    this.GLTranHeader = sje.Collection.tblGLTranHeaders.Select(h => h.ID).FirstOrDefault();
                    this.GLTranDetail = GLTranServices.GetGLEntryById(this.GLTranHeader).SelectMany(h => h.tblGLTranDetails).ToList();

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int intParser;
                decimal decimalParser;

                string TransType = (this.ID > 0) ? "delete" : String.Empty;
                if (TransType.Equals("delete"))
                {
               
                    Collection = new Collection
                    {
                        Id = this.ID,
                        TRANo = this.txtTransactionNo.Text,
                        Total = decimal.TryParse(this.txtTotal.Text, out decimalParser) ? decimalParser : 0,
                        TransactionDate = this.dtTransactionDate.Value,
                        SalesId = this.SaleId,
                        CheckDetail = this.txtCheckDetails.Text,
                        Description = this.txtDescription.Text,
                        IsCash = this.chkIsCash.Checked
                    };

                    CollectionServices.Remove(Collection);

                    if (Collection != null)
                    {
                        this.ID = 0;
                        this.txtCollectionId.Text = string.Empty;
                        this.txtTransactionNo.Text = string.Empty;
                        this.SaleId = 0;
                        this.txtSaleID.Text = string.Empty;
                        this.txtSaleTransactionNo.Text = String.Empty;
                        this.txtSalePONo.Text = String.Empty;
                        this.txtCustomerName.Text = String.Empty;
                        this.chkIsCash.Checked = false;
                        this.txtCheckDetails.Text = String.Empty;
                        this.dgJournalEntry.Rows.Clear();
                        this.dgJournalEntry.Refresh();
                        this.GLTranDetail.Clear();
                        this.GLTranHeader = 0;
                        this.txtTotalDebit.Text = string.Empty;
                        this.txtTotalCredit.Text = string.Empty;
                        this.txtTotal.Text = string.Empty;
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
            this.txtCollectionId.Text = string.Empty;
            this.txtTransactionNo.Text = string.Empty;
            this.SaleId = 0;
            this.txtSaleID.Text = string.Empty;
            this.txtSaleTransactionNo.Text = String.Empty;
            this.txtSalePONo.Text = String.Empty;
            this.txtCustomerName.Text = String.Empty;
            this.chkIsCash.Checked = false;
            this.txtCheckDetails.Text = String.Empty;
            this.dgJournalEntry.Rows.Clear();
            this.dgJournalEntry.Refresh();
            this.GLTranDetail.Clear();
            this.GLTranHeader = 0;
            this.txtTotalDebit.Text = string.Empty;
            this.txtTotalCredit.Text = string.Empty;
            this.txtTotal.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            GLTranDetail = new List<tblGLTranDetail>();
        }

        private void chkUseDefaultEntry_Click(object sender, EventArgs e)
        {
            if (this.chkUseDefaultEntry.Checked)
            {
                this.btnAddEntry.Enabled = false;
                this.btnDeleteEntry.Enabled = false;
            }
            else
            {
                this.btnAddEntry.Enabled = true;
                this.btnDeleteEntry.Enabled = true;
            }
        }
    }
}
