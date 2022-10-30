using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeneralLedger.Tier.BO;
using GeneralLedger.Tier.BAL;
using MetroFramework.Forms;
using Microsoft.Reporting.WinForms;


namespace GeneralLedger.Report
{
    public partial class frmReportGLBalanceSheet : MetroForm
    {
        public frmReportGLBalanceSheet()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            DateTime datDate = Convert.ToDateTime(this.dtBatchDate.Text);
            string strDate = datDate.ToString("MMMM") + " " + datDate.Day.ToString() + ", " + datDate.Year.ToString();
            string intFiscYear = datDate.Year.ToString();
            string intMonth = datDate.Month.ToString();

            GLBAL glBal = new GLBAL();
            List<rptBSCashBank> bsCashBank = glBal.getBSCashBank(Convert.ToInt32(intFiscYear), Convert.ToInt32(intMonth));
            List<rptBSCashBank> bsFixedAsset = glBal.getRepBSFixedAsset(Convert.ToInt32(intFiscYear), Convert.ToInt32(intMonth));
            List<rptBSCashBank> bsOtherAsset = glBal.getRepBSOtherAsset(Convert.ToInt32(intFiscYear), Convert.ToInt32(intMonth));
            List<rptBSCashBank> bsLiabilityAccountPayable = glBal.getRepBSLiabilityAccountsPayable(Convert.ToInt32(intFiscYear), Convert.ToInt32(intMonth));
            List<rptBSCashBank> bsOwnersEquity = glBal.getRepBSOwnersEquity(Convert.ToInt32(intFiscYear), Convert.ToInt32(intMonth));



            reportViewer1.LocalReport.DataSources.Clear(); //clear report

            //reportViewer1.LocalReport.ReportEmbeddedResource = "GeneralLedger.Report.RDLC.rptGLBalanceSheet.rdlc"; // bind reportviewer with .rdlc
            reportViewer1.LocalReport.ReportEmbeddedResource = "GeneralLedger.Report.RDLC.rptGLBalanceSheet.rdlc"; // bind reportviewer with .rdlc
            //Microsoft.Reporting.WinForms.ReportDataSource dsCashBank = new Microsoft.Reporting.WinForms.ReportDataSource("dsCB", bsCashBank); // set the datasource
            Microsoft.Reporting.WinForms.ReportDataSource dsCashBank = new Microsoft.Reporting.WinForms.ReportDataSource("dsCurrentAsset", bsCashBank); // set the datasource
            Microsoft.Reporting.WinForms.ReportDataSource dsFixedAsset = new Microsoft.Reporting.WinForms.ReportDataSource("dsFixedAsset", bsFixedAsset); // set the datasource
            Microsoft.Reporting.WinForms.ReportDataSource dsOtherAsset = new Microsoft.Reporting.WinForms.ReportDataSource("dsOtherAsset", bsOtherAsset); // set the datasource
            Microsoft.Reporting.WinForms.ReportDataSource dsLiabilityAccountPayable = new Microsoft.Reporting.WinForms.ReportDataSource("dsLiabilityAccountsPayable", bsLiabilityAccountPayable); // set the datasource
            Microsoft.Reporting.WinForms.ReportDataSource dsOwnersEquity = new Microsoft.Reporting.WinForms.ReportDataSource("dsOwnersEquity", bsOwnersEquity); // set the datasource

            ReportParameter parameters = new ReportParameter("PeriodMonth", strDate);

            reportViewer1.LocalReport.DataSources.Add(dsCashBank);
            reportViewer1.LocalReport.DataSources.Add(dsFixedAsset);
            reportViewer1.LocalReport.DataSources.Add(dsOtherAsset);
            reportViewer1.LocalReport.DataSources.Add(dsLiabilityAccountPayable);
            reportViewer1.LocalReport.DataSources.Add(dsOwnersEquity);

            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parameters });

            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport(); // refresh report

        }
    }
}
