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
using Microsoft.Reporting.WinForms;


namespace GeneralLedger.UserControls
{
    public partial class AccountRunningBalances : MetroUserControl
    {

        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }

        public int Coa { get; set; }
        public int CoaSub { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public AccountRunningBalances()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchChartOfAccountsWithoutAmount sca = new SearchChartOfAccountsWithoutAmount();
            sca.BringToFront();
            sca.TopMost = true;
            DialogResult res = sca.ShowDialog(this);

            if (res == DialogResult.OK)
            {
                this.txtStrCoaCode.Text = sca.GLTranDetail.COA.strCode;
                this.txtStrCoa.Text = sca.GLTranDetail.COA.strName;
                this.txtStrCoaSubCode.Text = sca.GLTranDetail.COASub.strCoaSubCode;
                this.txtStrCoaSub.Text = sca.GLTranDetail.COASub.strCoaSubName;
                this.Coa = sca.GLTranDetail.intIDCOA;
                this.CoaSub = sca.GLTranDetail.intIDCOASub;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }
        
        private void btnPreview_Click(object sender, EventArgs e)
        {
            var spRptGLGeneralLedgerDetailTableAdapter = new GeneralLedgerDataSetTableAdapters.spRptGLGeneralLedgerDetailTableAdapter();
            
            var result = spRptGLGeneralLedgerDetailTableAdapter.GetData(this.Coa, this.CoaSub, dtDateFrom.Value.ToString("MM/dd/yyyy"), dtDateTo.Value.ToString("MM/dd/yyyy")).ToList();
            var resultBegBalance = new GeneralLedgerDataSetTableAdapters.spRptGLGeneralLedgerDetailBegBalanceTableAdapter().GetData(this.Coa, this.CoaSub, dtDateFrom.Value.ToString("MM/dd/yyyy"), dtDateTo.Value.ToString("MM/dd/yyyy")).ToArray();


            reportViewer1.LocalReport.DataSources.Clear(); //clear report

            reportViewer1.LocalReport.ReportEmbeddedResource = "GeneralLedger.Report.RDLC.rptGLAccountRunningBalance.rdlc"; // bind reportviewer with .rdlc
            Microsoft.Reporting.WinForms.ReportDataSource dsGLGeneralLedgerList = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", result); // set the datasource


            string accountName = string.Concat(this.txtStrCoa.Text, " - ", this.txtStrCoaSub.Text);

            ReportParameter paraDateFrom = new ReportParameter("datFrom", dtDateFrom.Value.ToString("MM/dd/yyyy"));

            ReportParameter paraDateTo = new ReportParameter("datTo", dtDateTo.Value.ToString("MM/dd/yyyy"));
            ReportParameter paraAccountName = new ReportParameter("strAccountName", accountName);
            ReportParameter paraBegBalance = new ReportParameter("curBegBal", resultBegBalance[0].Column1.ToString());

            reportViewer1.LocalReport.DataSources.Add(dsGLGeneralLedgerList);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { paraAccountName, paraDateFrom, paraDateTo , paraBegBalance });
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport(); // refresh report

        }
    }
}
