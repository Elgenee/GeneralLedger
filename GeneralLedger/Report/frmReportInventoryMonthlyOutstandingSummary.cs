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
    public partial class frmReportInventoryMonthlyOutstandingSummary : MetroForm
    {
        public frmReportInventoryMonthlyOutstandingSummary()
        {

            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            try
            {
                DateTime datDate = Convert.ToDateTime(this.dtBatchDate.Text);
                string strDate = datDate.ToString("MMMM") + " " + datDate.Day.ToString() + ", " + datDate.Year.ToString();

                GLBAL glBal = new GLBAL();
                List<rptInventoryMonthlyOutstandingSummary> rptInventoryMonthlyOutstandingSummary = glBal.getInventoryMonthlyOutstandingSummary(datDate);
                reportViewer1.LocalReport.DataSources.Clear(); //clear report

                reportViewer1.LocalReport.ReportEmbeddedResource = "GeneralLedger.Report.RDLC.InventoryMonthlyOutstandingSummary.rdlc"; // bind reportviewer with .rdlc
                Microsoft.Reporting.WinForms.ReportDataSource dsJournalProoflistList = new Microsoft.Reporting.WinForms.ReportDataSource("spInventoryMonthlyOutstandingSummary", rptInventoryMonthlyOutstandingSummary); // set the datasource

                ReportParameter paraDateFrom = new ReportParameter("AsOfMonth", datDate.ToString("MM/dd/yyyy"));


                reportViewer1.LocalReport.DataSources.Add(dsJournalProoflistList);
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { paraDateFrom });
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport(); // refresh report
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void frmReportGLIncomeStatement_Load(object sender, EventArgs e)
        {

        }
    }
}
