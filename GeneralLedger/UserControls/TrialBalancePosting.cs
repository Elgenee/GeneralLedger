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


namespace GeneralLedger.UserControls
{
    public partial class TrialBalancePosting : MetroUserControl
    {
        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }
        public int TBHdrID { get; set; }
        

        public TrialBalancePosting()
        {
            InitializeComponent();
        }

        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                TrialBalanceBAL trialBalanceBAL = new TrialBalanceBAL();
                List<GLTBHdr> tbHdr = trialBalanceBAL.getGLTB(this.dpPeriodFrom.Value, this.dpPeriodTo.Value);

                if ((tbHdr != null) && tbHdr.Count > 0)
                {

                    this.dgTrialBalanceData.ColumnCount = 3;


                    this.dgTrialBalanceData.RowCount = tbHdr.Count;

                    //this.dtgCoa.Columns[0].Name = "ID";
                    //this.dtgCoa.Columns[1].Name = "Code";
                    //this.dtgCoa.Columns[2].Name = "Name";

                    //this.dtgCoa.Columns[3].Name = "Accounting Side";
                    //this.dtgCoa.Columns[4].Name = "IDMasCOAGroup";
                    //this.dtgCoa.Columns[5].Name = "Accounting Group";
                    //this.dtgCoa.Columns[6].Name = "Accounting Type";

                    this.dgTrialBalanceData.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgTrialBalanceData.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgTrialBalanceData.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    for (int i = 0; i < tbHdr.Count; i++)
                    {
                        this.dgTrialBalanceData.Rows[i].Cells[0].Value = tbHdr[i].ID;
                        this.dgTrialBalanceData.Rows[i].Cells[1].Value = tbHdr[i].datBatchDate;
                        this.dgTrialBalanceData.Rows[i].Cells[2].Value = tbHdr[i].Remarks;

                        setRowNumber(this.dgTrialBalanceData);
                    }

                }
                else
                {
                    this.dgTrialBalanceData.Rows.Clear();
                    this.dgTrialBalanceData.Refresh();
                    MessageBox.Show("No Result");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnPostNew_Click(object sender, EventArgs e)
        {
            TrialBalancePostingManage trialBalancePostingManage = new TrialBalancePostingManage(this.TBHdrID , string.Empty,string.Empty);
            trialBalancePostingManage.Id = this.TBHdrID;
            trialBalancePostingManage.BringToFront();
            DialogResult res = trialBalancePostingManage.ShowDialog(this);
        }

        private void TrialBalancePosting_Load(object sender, EventArgs e)
        {

        }

        private void dgTrialBalanceData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    this.TBHdrID = Int32.Parse(this.dgTrialBalanceData.Rows[e.RowIndex].Cells[0].Value.ToString());
                    string date = this.dgTrialBalanceData.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string remarks = this.dgTrialBalanceData.Rows[e.RowIndex].Cells[2].Value.ToString();
                    TrialBalancePostingManage trialBalancePostingManage = new TrialBalancePostingManage(this.TBHdrID, date , remarks);
                    trialBalancePostingManage.Id = this.TBHdrID;
                    trialBalancePostingManage.BringToFront();
                    DialogResult res = trialBalancePostingManage.ShowDialog(this);
                  

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }
    }
}
