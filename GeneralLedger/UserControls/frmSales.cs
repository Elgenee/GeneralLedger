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
    public partial class frmSales :  MetroUserControl
    {
        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }

        public Sale Sale { get; set; }
        public SaleServices SaleServices { get; set; }
        public GLTranServices GLTranServices { get; set; }
        public SalesCustomerLedgerServices SalesCustomerLedgerServices { get; set; }
        public int ID { get; set; }

        public int GLTranHeader { get; set; }

        public int CustomerId { get; set; }

        public int AgentId { get; set; }

        public List<tblGLTranDetail> GLTranDetail { get; set; }

        public int IndexGrid { get; set; }

        public frmSales()
        {
            InitializeComponent();
            SaleServices = new SaleServices();
            GLTranDetail = new List<tblGLTranDetail>();
            GLTranServices = new GLTranServices();
            GLTranHeader = 0;
            CustomerId = 0;
            AgentId = 0;
            this.Sale = new Sale();
            SalesCustomerLedgerServices = new SalesCustomerLedgerServices();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                double doubleParser;
                SearchCustomer sc = new SearchCustomer();
                sc.BringToFront();
                sc.TopMost = true;
                DialogResult res = sc.ShowDialog(this);

                if (res == DialogResult.OK)
                {
                    this.CustomerId = sc.Customer.ID;
                    this.txtCustomerID.Text = sc.Customer.ID.ToString(); 
                    this.txtCustomerName.Text = sc.Customer.Name;
                    this.txtTerms.Text = sc.Customer.Terms.ToString();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnSearchAgent_Click(object sender, EventArgs e)
        {
            try
            {
                double doubleParser;
                SearchAgent sa = new SearchAgent();
                sa.BringToFront();
                sa.TopMost = true;
                DialogResult res = sa.ShowDialog(this);

                if (res == DialogResult.OK)
                {
                    this.AgentId = sa.Agent.Id;
                    this.txtAgentID.Text = sa.Agent.Id.ToString();
                    this.txtAgent.Text = sa.Agent.Name;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (this.AgentId == 0)
                { 
                    MessageBox.Show("Please select agent..." );
                    return;
                 }

                if (this.CustomerId == 0) {
                    MessageBox.Show("Please select customer...");
                    return;
                }
               

                int intParser;
                decimal decimalParser;

                string TransType = (this.ID == 0) ? "insert" : "update";
                if (TransType.Equals("insert"))
                {
                    Sale = new Sale
                    {
                        Id = this.ID,
                        PONo = this.txtPONo.Text,
                        TRANo = this.txtTransactionNo.Text,
                        intIdAgent = this.AgentId,
                        intIdCustomer = this.CustomerId,
                        Terms = int.TryParse(this.txtTerms.Text , out intParser) ? intParser : 0,
                        Total = decimal.TryParse(this.txtTotal.Text, out decimalParser) ? decimalParser : 0,
                        TransactionDate = this.dtTransactionDate.Value,
                        Description = this.txtDescription.Text
                    };

                    Sale = SaleServices.Add(Sale, this.GLTranDetail , this.chkUseDefaultEntry.Checked);
                
                    if (Sale != null)
                    {
                        MessageBox.Show("Successfully saved");
                       
                    }
                }
                else
                {
                   
                    Sale.PONo = this.txtPONo.Text;
                    Sale.TRANo = this.txtTransactionNo.Text;
                    Sale.intIdAgent = this.AgentId;
                    Sale.intIdCustomer = this.CustomerId;
                    Sale.Total = decimal.TryParse(this.txtTotal.Text, out decimalParser) ? decimalParser : 0;
                    Sale.TransactionDate = this.dtTransactionDate.Value;
                    Sale.Description = this.txtDescription.Text;
                    Sale = SaleServices.Update(Sale, this.GLTranDetail, this.chkUseDefaultEntry.Checked);
        
                    if (Sale != null)
                    {
                        MessageBox.Show("Successfully saved");
                    }
                }

                GLTranHeader = Sale.tblGLTranHeaders.Select(h => h.ID).SingleOrDefault();
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

                this.ID = Sale.Id;
                this.txtID.Text = Sale.Id.ToString();
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
                SearchSale sje = new SearchSale();
                sje.BringToFront();
                sje.TopMost = true;
                DialogResult res = sje.ShowDialog(this);

                if (res == DialogResult.OK)
                {

                    this.ID = sje.Sale.Id;
                    this.Sale.Id = sje.Sale.Id;

                    //this.Sale.Agent.Id = sje.Sale.Agent.Id;
                    //this.Sale.Agent.Name = sje.Sale.Agent.Name;
                    //this.Sale.TRANo = sje.Sale.TRANo;
                    //this.Sale.PONo = sje.Sale.PONo;
                    //this.Sale.Total = sje.Sale.Total;
                    //this.Sale.Customer.Id = sje.Sale.Customer.Id;
                    //this.Sale.Customer.strName = sje.Sale.Customer.strName;

                    this.txtID.Text = Sale.Id.ToString();
                    this.AgentId = sje.Sale.Agent.Id;
                    this.CustomerId = sje.Sale.Customer.Id;
                    this.txtPONo.Text = sje.Sale.PONo;
                    this.txtTransactionNo.Text = sje.Sale.TRANo;
                    this.dtTransactionDate.Value = (DateTime)sje.Sale.TransactionDate;
                    this.txtDescription.Text = sje.Sale.Description;
                    this.txtTotal.Text = sje.Sale.Total.ToString();
                    this.txtCustomerID.Text = sje.Sale.Customer.Id.ToString();
                    this.txtCustomerName.Text = sje.Sale.Customer.strName;
                    this.txtAgentID.Text = sje.Sale.Agent.Id.ToString();
                    this.txtAgent.Text = sje.Sale.Agent.Name.ToString();

                    this.GLTranHeader = sje.Sale.tblGLTranHeaders.Select(h => h.ID).FirstOrDefault();
                    this.chkUseDefaultEntry.Checked = (bool)sje.Sale.tblGLTranHeaders.Select(h => h.blnUseDefaultEntry).FirstOrDefault();
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

        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            //if (this.ID == 0 )
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
                     tblMasCOA = new tblMasCOA {
                         ID = sca.GLTranDetail.COA.ID,
                         strCode = sca.GLTranDetail.COA.strCode,
                         strName = sca.GLTranDetail.COA.strName
                     },
                     tblMasCOASub = new tblMasCOASub { 
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

        private void dgJournalEntry_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                this.IndexGrid = e.RowIndex;
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
                    Sale = new Sale
                    {
                        Id = this.ID,
                        PONo = this.txtPONo.Text,
                        TRANo = this.txtTransactionNo.Text,
                        intIdAgent = this.AgentId,
                        intIdCustomer = this.CustomerId,
                        Total = decimal.TryParse(this.txtTotal.Text, out decimalParser) ? decimalParser : 0,
                        TransactionDate = this.dtTransactionDate.Value,
                        Description = this.txtDescription.Text
                    };

                    SaleServices.Remove(Sale);

                    if (Sale != null)
                    {
                        this.ID = 0;
                        this.txtID.Text = string.Empty;
                        this.txtPONo.Text = string.Empty;
                        this.txtTransactionNo.Text = string.Empty;
                        this.AgentId = 0;
                        this.CustomerId = 0;
                        this.txtAgent.Text = string.Empty;
                        this.txtCustomerID.Text = string.Empty;
                        this.txtAgentID.Text = string.Empty;
                        this.txtCustomerName.Text = string.Empty;
                        this.txtTerms.Text = string.Empty;
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
            this.txtID.Text = string.Empty;
            this.txtPONo.Text = string.Empty;
            this.txtTransactionNo.Text = string.Empty;
            this.AgentId = 0;
            this.CustomerId = 0;
            this.txtAgent.Text = string.Empty;
            this.txtCustomerID.Text = string.Empty;
            this.txtAgentID.Text = string.Empty;
            this.txtCustomerName.Text = string.Empty;
            this.txtTerms.Text = string.Empty;
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

        private void frmSales_Load(object sender, EventArgs e)
        {

        }

        private void btnViewLedger_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.ID == 0)
                {
                    MessageBox.Show("Please select transaction first...");
                    return;
                }
           
                //var result = SalesCustomerLedgerServices.GetSalesCustomerLedger(this.Sale.Id);

                MetroTabPage metroTabPage = new MetroTabPage();
                metroTabPage.Text = "Sales Ledger";
                metroTabPage.AutoScroll = true;
                metroTabPage.HorizontalScrollbar = true;
                metroTabPage.HorizontalScrollbarBarColor = true;
                metroTabPage.HorizontalScrollbarHighlightOnWheel = true;
                metroTabPage.HorizontalScrollbarSize = 15;
                metroTabPage.UseStyleColors = true;
                metroTabPage.VerticalScrollbar = true;
                metroTabPage.VerticalScrollbarBarColor = true;
                metroTabPage.VerticalScrollbarHighlightOnWheel = true;
                metroTabPage.VerticalScrollbarSize = 15;
                //metroTabPage.Size = new System.Drawing.Size(1200, 1013);
                metroTabPage.Style = MetroFramework.MetroColorStyle.Orange;
                metroTabPage.Location = new System.Drawing.Point(4, 38);
                metroTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);

                frmSalesLedger frmSalesLedger = new frmSalesLedger(this.ID);
                frmSalesLedger.Parent = metroTabPage;
                frmSalesLedger.MetroTabPage = metroTabPage;
                frmSalesLedger.AutoScroll = true;
                frmSalesLedger.MetroTabControl = this.MetroTabControl;
  
                metroTabPage.Controls.Add(frmSalesLedger);
                MetroTabControl.TabPages.Add(metroTabPage);
                MetroTabControl.SelectedTab = metroTabPage;
               
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
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
