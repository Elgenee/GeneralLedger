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
using Microsoft.Reporting.WinForms;

namespace GeneralLedger.Report
{
    public partial class frmReportAccountsReceivableSales : MetroForm
    {
        public frmReportAccountsReceivableSales()
        {

            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            GLBAL glBal = new GLBAL();
            List<rptGetSummaryOfAccountsReceivablesSales> getSummaryOfAccountsReceivablesSalesList = glBal.getSummaryOfAccountsReceivablesSales(dtBatchDate.Value.ToString("MM/dd/yyyy"));
            reportViewer1.LocalReport.DataSources.Clear(); //clear report

            reportViewer1.LocalReport.ReportEmbeddedResource = "GeneralLedger.Report.RDLC.rptReportAccountsReceivableSales.rdlc"; // bind reportviewer with .rdlc
            Microsoft.Reporting.WinForms.ReportDataSource dsJournalProoflistList = new Microsoft.Reporting.WinForms.ReportDataSource("dsRPTGetSummaryOfAccountsReceivablesSales", getSummaryOfAccountsReceivablesSalesList); // set the datasource

            ReportParameter datAsOfDate = new ReportParameter("datAsOfDate", dtBatchDate.Value.ToString("MM/dd/yyyy"));

            reportViewer1.LocalReport.DataSources.Add(dsJournalProoflistList);
            //reportViewer1.LocalReport.SetParameters(new ReportParameter[] { datAsOfDate });
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport(); // refresh report

        }

        private void frmReportGLIncomeStatement_Load(object sender, EventArgs e)
        {

        }
    }
}
