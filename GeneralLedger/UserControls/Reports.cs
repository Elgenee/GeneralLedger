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
using GeneralLedger.Report;

namespace GeneralLedger.UserControls
{
    public partial class Reports : MetroUserControl
    {
        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }
        public MetroFramework.Controls.MetroTabControl metroTabControlMain;
        public Reports()
        {
            InitializeComponent();
        }

        private void ViewReport_Click(object sender, EventArgs e)
        {
           
            if (this.metroListView1.SelectedItems.Count > 0)
            {
                string item = this.metroListView1.SelectedItems[0].Text.ToUpper();

                if (item.ToUpper().Equals("INCOME STATEMENT"))
                {
                    frmReportGLIncomeStatement frmReportGLIncomeStatement = new frmReportGLIncomeStatement();
                    frmReportGLIncomeStatement.Show();
                }

                if (item.ToUpper().Equals("TRIAL BALANCE"))
                {

                    MetroTabPage metroTabPage = new MetroTabPage();
                    metroTabPage.Text = "Trial Balance";
                    TrialBalancePosting trialBalancePosting = new TrialBalancePosting();
                    trialBalancePosting.Parent = metroTabPage;
                    trialBalancePosting.MetroTabPage = metroTabPage;
                    trialBalancePosting.MetroTabControl = this.metroTabControlMain;
                    metroTabPage.Controls.Add(trialBalancePosting);
                    metroTabControlMain.TabPages.Add(metroTabPage);
                    metroTabControlMain.SelectedTab = metroTabPage;
                }

                if (item.ToUpper().Equals("JOURNAL ENTRY PROOFLIST"))
                {
                    frmReportJournalProoflist frmReportJournalProoflist = new frmReportJournalProoflist();
                    frmReportJournalProoflist.Show();
                }

                if (item.ToUpper().Equals("BALANCE SHEET"))
                {
                    frmReportGLBalanceSheet frmReportGLBalanceSheet = new frmReportGLBalanceSheet();
                    frmReportGLBalanceSheet.Show();
                }
              
                if (item.ToUpper().Equals("ACCOUNT RUNNING BALANCES"))
                {

                    MetroTabPage metroTabPage = new MetroTabPage();
                    metroTabPage.Text = "Account Running Balances";
                    AccountRunningBalances accountRunningBalances = new AccountRunningBalances();
                    accountRunningBalances.Parent = metroTabPage;
                    accountRunningBalances.MetroTabPage = metroTabPage;
                    accountRunningBalances.MetroTabControl = this.metroTabControlMain;
                    metroTabPage.Controls.Add(accountRunningBalances);
                    metroTabControlMain.TabPages.Add(metroTabPage);
                    metroTabControlMain.SelectedTab = metroTabPage;
                }

                if (item.ToUpper().Equals("GL OVERALL BOOK PROOFLIST SUMMARY"))
                {
                    BookProoflistSummary frmReportBookProoflistSummary = new BookProoflistSummary();
                    frmReportBookProoflistSummary.Show();
                }

                if (item.ToUpper().Equals("PROOFLIST DETAIL"))
                {
                    frmReportProoflistDetail frmReportProoflistDetail = new frmReportProoflistDetail();
                    frmReportProoflistDetail.Show();
                }



                //rest of your logic 
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }
    }
}
