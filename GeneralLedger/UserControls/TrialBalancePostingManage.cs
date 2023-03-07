using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using GeneralLedger.Tier.BO;
using GeneralLedger.Tier.BAL;
using MetroFramework.Forms;
using GeneralLedger.Report;
using System.Globalization;
using GeneralLedger.Persistence.Services;

namespace GeneralLedger.UserControls
{
    public partial class TrialBalancePostingManage : MetroForm
    {
        public int Id { get; set; }

        public tblTBBatchHdrServices tblTBBatchHdrServices { get; set; }
        public TrialBalancePostingManage(int id , string batchDate , string remarks)
        {

            InitializeComponent();

            if (UserProfile.UserProfileRoles.Exists(r => r.Name.ToUpper() == "POST TRIAL BALANCE"))
            {
                this.btnPostBatchDate.Visible = true;
            }
            this.Id = id;
            this.dtBatchDate.Text = batchDate;
            this.txtRemarks.Text = remarks;
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            if (id != 0)
            {
                loadTBDetail();
            }

            tblTBBatchHdrServices = new tblTBBatchHdrServices();

            if (UserProfile.UserProfileRoles.Exists(r => r.Name.ToUpper() == "LOCK TRIAL BALANCE"))
            {
                this.btnLock.Visible = true;
            }

            if (UserProfile.UserProfileRoles.Exists(r => r.Name.ToUpper() == "UNLOCK TRIAL BALANCE"))
            {
                this.btnUnlock.Visible = true;
            }

            if (UserProfile.UserProfileRoles.Exists(r => r.Name.ToUpper() == "POST TRIAL BALANCE"))
            {
                this.btnPostBatchDate.Visible = true;
            }

        }

        private void btnPostBatchDate_Click(object sender, EventArgs e)
        {
            try
            {
                int intParser = 0;
                TrialBalanceBAL tbBal = new TrialBalanceBAL();
                
                string result = tbBal.PostGL(this.dtBatchDate.Text, this.txtRemarks.Text);

                if (result != string.Empty)
                {
                    this.Id = int.TryParse(result, out intParser) ? intParser : 0;
                    List<GLTBHdr> listOfGLTBHeader = tbBal.getGLTBById(this.Id);
                    List<GLTBDtl> listOfGLTBDetail = tbBal.getGLTBDetail(this.Id);

                    this.dgTrialBalance.Rows.Clear();
                    this.dgTrialBalance.Refresh();
                    this.dgTrialBalance.ColumnCount = 11;
                    this.dgTrialBalance.RowCount = listOfGLTBDetail.Count();
                    this.dgTrialBalance.Columns[0].Name = "ID";
                    this.dgTrialBalance.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgTrialBalance.Columns[1].Name = "intIDTBBatchHdr";
                    this.dgTrialBalance.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgTrialBalance.Columns[2].Name = "COADesc";
                    this.dgTrialBalance.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgTrialBalance.Columns[3].Name = "COASubDesc";
                    this.dgTrialBalance.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgTrialBalance.Columns[4].Name = "curBegBal";
                    this.dgTrialBalance.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgTrialBalance.Columns[5].Name = "curDebit";
                    this.dgTrialBalance.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgTrialBalance.Columns[6].Name = "curCredit";
                    this.dgTrialBalance.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgTrialBalance.Columns[7].Name = "curEndBal";
                    this.dgTrialBalance.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgTrialBalance.Columns[8].Name = "COA";
                    this.dgTrialBalance.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgTrialBalance.Columns[9].Name = "COASub";
                    this.dgTrialBalance.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgTrialBalance.Columns[10].Name = "COAstrCode";
                    this.dgTrialBalance.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    this.dgTrialBalance.Columns[0].Visible = false;
                    this.dgTrialBalance.Columns[1].Visible = false;
                    this.dgTrialBalance.Columns[8].Visible = false;
                    this.dgTrialBalance.Columns[9].Visible = false;
                    this.dgTrialBalance.Columns[10].Visible = false;

                    for (int i = 0; i < listOfGLTBDetail.Count; i++)
                    {

                        this.dgTrialBalance.Rows[i].Cells[0].Value = listOfGLTBDetail[i].ID;
                        this.dgTrialBalance.Rows[i].Cells[1].Value = listOfGLTBDetail[i].intIDTBBatchHdr;
                        this.dgTrialBalance.Rows[i].Cells[2].Value = listOfGLTBDetail[i].COADesc;
                        this.dgTrialBalance.Rows[i].Cells[3].Value = listOfGLTBDetail[i].COASubDesc;
                        this.dgTrialBalance.Rows[i].Cells[4].Value = listOfGLTBDetail[i].curBegBal.ToString("N", CultureInfo.InvariantCulture);
                        this.dgTrialBalance.Rows[i].Cells[5].Value = listOfGLTBDetail[i].curDebit.ToString("N", CultureInfo.InvariantCulture);
                        this.dgTrialBalance.Rows[i].Cells[6].Value = listOfGLTBDetail[i].curCredit.ToString("N", CultureInfo.InvariantCulture);
                        this.dgTrialBalance.Rows[i].Cells[7].Value = listOfGLTBDetail[i].curEndBal.ToString("N", CultureInfo.InvariantCulture);
                        this.dgTrialBalance.Rows[i].Cells[8].Value = listOfGLTBDetail[i].COA;
                        this.dgTrialBalance.Rows[i].Cells[9].Value = listOfGLTBDetail[i].COASub;
                        this.dgTrialBalance.Rows[i].Cells[10].Value = listOfGLTBDetail[i].COAstrCode;
                    }

                    setRowNumber(this.dgTrialBalance);
                    this.txtBegBalance.Text = listOfGLTBDetail.Sum(b => b.curBegBal).ToString("N", CultureInfo.InvariantCulture);
                    this.txtCredit.Text = listOfGLTBDetail.Sum(b => b.curCredit).ToString("N", CultureInfo.InvariantCulture);
                    this.txtDebit.Text = listOfGLTBDetail.Sum(b => b.curDebit).ToString("N", CultureInfo.InvariantCulture);
                    this.txtEndBalance.Text = listOfGLTBDetail.Sum(b => b.curEndBal).ToString("N", CultureInfo.InvariantCulture);
                    MessageBox.Show("Successfully Processed");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }

        }


        public void loadTBDetail() {

            try
            {
                TrialBalanceBAL trialBalanceBAL = new TrialBalanceBAL();
                List<GLTBHdr> listOfGLTBHeader = trialBalanceBAL.getGLTBById(this.Id);
                List<GLTBDtl> listOfGLTBDetail = trialBalanceBAL.getGLTBDetail(this.Id);

                this.dgTrialBalance.Rows.Clear();
                this.dgTrialBalance.Refresh();
                this.dgTrialBalance.ColumnCount = 11;
                this.dgTrialBalance.RowCount = listOfGLTBDetail.Count();
                this.dgTrialBalance.Columns[0].Name = "ID";
                this.dgTrialBalance.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgTrialBalance.Columns[1].Name = "intIDTBBatchHdr";
                this.dgTrialBalance.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgTrialBalance.Columns[2].Name = "COADesc";
                this.dgTrialBalance.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgTrialBalance.Columns[3].Name = "COASubDesc";
                this.dgTrialBalance.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgTrialBalance.Columns[4].Name = "curBegBal";
                this.dgTrialBalance.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgTrialBalance.Columns[5].Name = "curDebit";
                this.dgTrialBalance.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgTrialBalance.Columns[6].Name = "curCredit";
                this.dgTrialBalance.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgTrialBalance.Columns[7].Name = "curEndBal";
                this.dgTrialBalance.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgTrialBalance.Columns[8].Name = "COA";
                this.dgTrialBalance.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgTrialBalance.Columns[9].Name = "COASub";
                this.dgTrialBalance.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgTrialBalance.Columns[10].Name = "COAstrCode";
                this.dgTrialBalance.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                this.dgTrialBalance.Columns[0].Visible = false;
                this.dgTrialBalance.Columns[1].Visible = false;
                this.dgTrialBalance.Columns[8].Visible = false;
                this.dgTrialBalance.Columns[9].Visible = false;
                this.dgTrialBalance.Columns[10].Visible = false;

                for (int i = 0; i < listOfGLTBDetail.Count; i++)
                {

                    this.dgTrialBalance.Rows[i].Cells[0].Value = listOfGLTBDetail[i].ID;
                    this.dgTrialBalance.Rows[i].Cells[1].Value = listOfGLTBDetail[i].intIDTBBatchHdr;
                    this.dgTrialBalance.Rows[i].Cells[2].Value = listOfGLTBDetail[i].COADesc;
                    this.dgTrialBalance.Rows[i].Cells[3].Value = listOfGLTBDetail[i].COASubDesc;
                    this.dgTrialBalance.Rows[i].Cells[4].Value = listOfGLTBDetail[i].curBegBal.ToString("N", CultureInfo.InvariantCulture);
                    this.dgTrialBalance.Rows[i].Cells[5].Value = listOfGLTBDetail[i].curDebit.ToString("N", CultureInfo.InvariantCulture);
                    this.dgTrialBalance.Rows[i].Cells[6].Value = listOfGLTBDetail[i].curCredit.ToString("N", CultureInfo.InvariantCulture);
                    this.dgTrialBalance.Rows[i].Cells[7].Value = listOfGLTBDetail[i].curEndBal.ToString("N", CultureInfo.InvariantCulture);
                    this.dgTrialBalance.Rows[i].Cells[8].Value = listOfGLTBDetail[i].COA;
                    this.dgTrialBalance.Rows[i].Cells[9].Value = listOfGLTBDetail[i].COASub;
                    this.dgTrialBalance.Rows[i].Cells[10].Value = listOfGLTBDetail[i].COAstrCode;

                }

                setRowNumber(this.dgTrialBalance);
                this.txtBegBalance.Text = listOfGLTBDetail.Sum(b => b.curBegBal).ToString("N", CultureInfo.InvariantCulture);
                this.txtCredit.Text = listOfGLTBDetail.Sum(b => b.curCredit).ToString("N", CultureInfo.InvariantCulture);
                this.txtDebit.Text = listOfGLTBDetail.Sum(b => b.curDebit).ToString("N", CultureInfo.InvariantCulture);
                this.txtEndBalance.Text = listOfGLTBDetail.Sum(b => b.curEndBal).ToString("N", CultureInfo.InvariantCulture);

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
        private void btnPreviewTrialBalance_Click(object sender, EventArgs e)
        {
            frmRptGLTrialBalance frmRptGLTrialBalance = new frmRptGLTrialBalance();
            frmRptGLTrialBalance.ID = this.Id;
            frmRptGLTrialBalance.BringToFront();
            frmRptGLTrialBalance.Show();
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            try
            {
                    var IsLock = tblTBBatchHdrServices.Lock(this.Id);
                    if (IsLock)
                    {
                        MessageBox.Show("Lock...");
                 
                    }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            try
            {
                var IsLock = tblTBBatchHdrServices.Unlock(this.Id);
                if (IsLock)
                {
                    MessageBox.Show("Unlock...");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}
