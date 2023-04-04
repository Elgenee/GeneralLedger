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


namespace GeneralLedger.UserControls
{
    public partial class JournalEntry : MetroUserControl
    {
        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }
        public List<GLTranDetail> GLTranDetail { get; set; }

        public tblTBBatchHdrServices tblTBBatchHdrServices { get; set; }

        public int IndexGrid { get; set; }
        public int ID { get; set; }
        public int IDGLTranHeader { get; set; }


        public JournalEntry()
        {
            GLTranDetail = new List<GLTranDetail>();
            InitializeComponent();
            tblTBBatchHdrServices = new tblTBBatchHdrServices();
        }

        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            SearchChartOfAccounts sca = new SearchChartOfAccounts();
            sca.BringToFront();
            sca.TopMost = true;
            DialogResult res = sca.ShowDialog(this);

            if (res == DialogResult.OK)
            {
              
            }
        }

        private void metroLabel9_Click(object sender, EventArgs e)
        {

        }

        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            SearchChartOfAccounts sca = new SearchChartOfAccounts();
            sca.BringToFront();
            sca.TopMost = true;
            DialogResult res = sca.ShowDialog(this);

            if (res == DialogResult.OK)
            {
              
                GLTranDetail.Add(sca.GLTranDetail);

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
                        this.dgJournalEntry.Rows[i].Cells[0].Value = GLTranDetail[i].COA.strName;
                        this.dgJournalEntry.Rows[i].Cells[1].Value = GLTranDetail[i].COA.strCode;
                        this.dgJournalEntry.Rows[i].Cells[2].Value = GLTranDetail[i].COASub.strCoaSubName;
                        this.dgJournalEntry.Rows[i].Cells[3].Value = GLTranDetail[i].COASub.strCoaSubCode;
                        this.dgJournalEntry.Rows[i].Cells[4].Value = GLTranDetail[i].curDebit.ToString("N", CultureInfo.InvariantCulture);
                        this.dgJournalEntry.Rows[i].Cells[5].Value = GLTranDetail[i].curCredit.ToString("N", CultureInfo.InvariantCulture);
                    }

                    setRowNumber(this.dgJournalEntry);

                    this.txtTotalDebit.Text = GLTranDetail.Sum(g => g.curDebit).ToString("N", CultureInfo.InvariantCulture);
                    this.txtTotalCredit.Text = GLTranDetail.Sum(g => g.curCredit).ToString("N", CultureInfo.InvariantCulture);
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
                        this.dgJournalEntry.Rows[i].Cells[0].Value = GLTranDetail[i].COA.strName;
                        this.dgJournalEntry.Rows[i].Cells[1].Value = GLTranDetail[i].COA.strCode;
                        this.dgJournalEntry.Rows[i].Cells[2].Value = GLTranDetail[i].COASub.strCoaSubName;
                        this.dgJournalEntry.Rows[i].Cells[3].Value = GLTranDetail[i].COASub.strCoaSubCode;
                        this.dgJournalEntry.Rows[i].Cells[4].Value = GLTranDetail[i].curDebit;
                        this.dgJournalEntry.Rows[i].Cells[5].Value = GLTranDetail[i].curCredit;
                    }

                    setRowNumber(this.dgJournalEntry);

                    this.txtTotalDebit.Text = GLTranDetail.Sum(g => g.curDebit).ToString();
                    this.txtTotalCredit.Text = GLTranDetail.Sum(g => g.curCredit).ToString();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void dgJournalEntry_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //e.RowIndex

            try
            {

                this.IndexGrid = e.RowIndex;
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
                if (GLTranDetail.Count <= 0 )
                {
                    return;
                }

                var isLock = tblTBBatchHdrServices.CheckIfLock(this.dtBatchDate.Value);

                if (isLock)
                {
                    MessageBox.Show("Already lock...");
                    return;
                }

                string TransType = (this.ID == 0) ? "insert" : "update";
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("&ID", this.ID.ToString());
                param.Add("&TransactionNo", this.txtTransactionNo.Text);
                param.Add("&BatchDate", this.dtBatchDate.Text);
                param.Add("&TransactionCode", this.txtTransactionCode.Text);
                param.Add("&Description", this.txtDescription.Text);
                param.Add("&curCreditAmount", this.txtTotalCredit.Text);
                param.Add("&curDebitAmount", this.txtTotalDebit.Text);
                param.Add("&IDGLTranHeader", this.IDGLTranHeader.ToString());
                param.Add("&IDGLBookType", this.cbBookType.SelectedValue.ToString());
              

                JournalEntryBAL JournalEntryBAL = new JournalEntryBAL();
                string result  = JournalEntryBAL.ManageJournalEntry(param, TransType, this.GLTranDetail);

                if (result != string.Empty)
                {
                    this.ID = Convert.ToInt32(result.Split(',')[0]);
                    this.txtID.Text = this.ID.ToString();
              
                   
                    this.txtTransactionCode.Text = result.Split(',')[1];
                    //this.txtID.Enabled = false;
                    //this.txtTransactionCode.Enabled = false;
                    //this.dtBatchDate.Enabled = false;
                    //this.txtDescription.Enabled = false;
                    //this.btnAddEntry.Enabled = false;
                    //this.btnDeleteEntry.Enabled = false;
                    //this.txtTransactionNo.Enabled = false;
                    this.IDGLTranHeader = Convert.ToInt32(result.Split(',')[2]);
                    MessageBox.Show("Successfully Saved");
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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.ID = 0;
            this.IDGLTranHeader = 0;
            this.GLTranDetail = new List<GLTranDetail>();
            this.txtDescription.Text = string.Empty;
            this.txtTransactionCode.Text = string.Empty;
            this.txtTransactionNo.Text = string.Empty;
            this.txtTotalCredit.Text = string.Empty;
            this.txtTotalDebit.Text = string.Empty;
            this.dgJournalEntry.Refresh();
            this.dgJournalEntry.Rows.Clear();

            this.txtID.Enabled = true;
            this.txtTransactionCode.Enabled = true;
            this.dtBatchDate.Enabled = true;
            this.txtDescription.Enabled = true;
            this.btnAddEntry.Enabled = true;
            this.btnDeleteEntry.Enabled = true;
            this.txtTransactionNo.Enabled = true;
            this.txtID.Text = string.Empty;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            try
            {
                SeachJournalEntry sje = new SeachJournalEntry();
                sje.BringToFront();
                sje.TopMost = true;
                DialogResult res = sje.ShowDialog(this);

                if (res == DialogResult.OK)
                {

                    this.ID = sje.JournalEntry.ID;
                    this.txtID.Text = sje.JournalEntry.ID.ToString();
                    this.txtTransactionNo.Text = sje.JournalEntry.strTransactionNumber;
                    this.txtTransactionCode.Text = sje.JournalEntry.strTransactionCode;
                    this.txtDescription.Text = sje.JournalEntry.strDescription;
                    this.IDGLTranHeader = sje.JournalEntry.GLTranHeader.ID;
                    this.dtBatchDate.Text = sje.JournalEntry.datBatchDate;

                    JournalEntryBAL journalEntryBAL = new JournalEntryBAL();
                    this.GLTranDetail = journalEntryBAL.getTranDetail(this.IDGLTranHeader);

                    //var result = this.GLTranDetail.Where(g => g.intIDCOA == 4037).ToList();

                    if (GLTranDetail.Count > 0)
                    {
                       

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

                     

                            this.dgJournalEntry.Rows[i].Cells[0].Value = GLTranDetail[i].COA.strName;
                            this.dgJournalEntry.Rows[i].Cells[1].Value = GLTranDetail[i].COA.strCode;
                            this.dgJournalEntry.Rows[i].Cells[2].Value = GLTranDetail[i].COASub.strCoaSubName;
                            this.dgJournalEntry.Rows[i].Cells[3].Value = GLTranDetail[i].COASub.strCoaSubCode;
                            this.dgJournalEntry.Rows[i].Cells[4].Value = GLTranDetail[i].curDebit.ToString("N", CultureInfo.InvariantCulture);
                            this.dgJournalEntry.Rows[i].Cells[5].Value = GLTranDetail[i].curCredit.ToString("N", CultureInfo.InvariantCulture);

                            this.dgJournalEntry.Rows[i].Cells[0].ReadOnly = true;
                            this.dgJournalEntry.Rows[i].Cells[1].ReadOnly = true;
                            this.dgJournalEntry.Rows[i].Cells[2].ReadOnly = true;
                            this.dgJournalEntry.Rows[i].Cells[3].ReadOnly = true;
                            this.dgJournalEntry.Rows[i].Cells[4].ReadOnly = true;
                            this.dgJournalEntry.Rows[i].Cells[5].ReadOnly = true;
                        }

                        setRowNumber(this.dgJournalEntry);

                        this.txtTotalDebit.Text = GLTranDetail.Sum(g => g.curDebit).ToString("N", CultureInfo.InvariantCulture);
                        this.txtTotalCredit.Text = GLTranDetail.Sum(g => g.curCredit).ToString("N", CultureInfo.InvariantCulture);
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
                //if (GLTranDetail.Count <= 0)
                //{
                //    return;
                //}

                var isLock = tblTBBatchHdrServices.CheckIfLock(this.dtBatchDate.Value);

                if (isLock)
                {
                    MessageBox.Show("Already lock...");
                    return;
                }

                string TransType =  "delete";
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("&ID", this.ID.ToString());
                param.Add("&TransactionNo", this.txtTransactionNo.Text);
                param.Add("&BatchDate", this.dtBatchDate.Text);
                param.Add("&TransactionCode", this.txtTransactionCode.Text);
                param.Add("&Description", this.txtDescription.Text);
                param.Add("&curCreditAmount", this.txtTotalCredit.Text);
                param.Add("&curDebitAmount", this.txtTotalDebit.Text);
                param.Add("&IDGLTranHeader", this.IDGLTranHeader.ToString());
                JournalEntryBAL JournalEntryBAL = new JournalEntryBAL();
                string result = JournalEntryBAL.ManageJournalEntry(param, TransType, this.GLTranDetail);



                if (result != string.Empty)
                {
                    this.ID = Convert.ToInt32(result.Split(',')[0]);
                    this.txtTransactionCode.Text = result.Split(',')[1];
                    this.IDGLTranHeader = Convert.ToInt32(result.Split(',')[2]);
                    this.txtTransactionNo.Text = string.Empty;
                    this.txtDescription.Text = string.Empty;
                    this.dgJournalEntry.Rows.Clear();
                    this.dgJournalEntry.Refresh();
                    this.txtID.Enabled = true;
                    this.txtTransactionCode.Enabled = true;
                    this.dtBatchDate.Enabled = true;
                    this.txtDescription.Enabled = true;
                    this.btnAddEntry.Enabled = true;
                    this.btnDeleteEntry.Enabled = true;
                    this.txtTransactionNo.Enabled = true;
                    this.txtID.Text = string.Empty;
                    this.GLTranDetail.Clear();
                    this.txtTotalCredit.Text = string.Empty;
                    this.txtTotalDebit.Text = string.Empty;
                    MessageBox.Show("Successfully Deleted");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void JournalEntry_Load(object sender, EventArgs e)
        {
            var spGLGetBookTypeTableAdapter = new GeneralLedgerDataSet1TableAdapters.spGLGetBookTypeTableAdapter();
            this.cbBookType.DataSource = spGLGetBookTypeTableAdapter.GetData().ToList();
            this.cbBookType.ValueMember = "ID";
            this.cbBookType.DisplayMember = "strName";

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }
    }
}
