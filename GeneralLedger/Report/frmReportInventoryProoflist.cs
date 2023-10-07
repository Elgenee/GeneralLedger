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
    public partial class frmReportInventoryProoflist : MetroForm
    {
        public frmReportInventoryProoflist()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                GLBAL glBal = new GLBAL();
                List<rptInventoryProoflist> rptSalesProoflistList = glBal.getInventoryProoflist(dtDateFrom.Value.ToString("MM/dd/yyyy"), dtDateTo.Value.ToString("MM/dd/yyyy"));
                reportViewer1.LocalReport.DataSources.Clear(); //clear report

                reportViewer1.LocalReport.ReportEmbeddedResource = "GeneralLedger.Report.RDLC.InventoryProoflist.rdlc"; // bind reportviewer with .rdlc
                Microsoft.Reporting.WinForms.ReportDataSource dsJournalProoflistList = new Microsoft.Reporting.WinForms.ReportDataSource("dsRPTInventoryProoflist", rptSalesProoflistList); // set the datasource

                ReportParameter paraDateFrom = new ReportParameter("datDateFrom", dtDateFrom.Value.ToString("MM/dd/yyyy"));
                ReportParameter paraDateTo = new ReportParameter("datDateTo", dtDateTo.Value.ToString("MM/dd/yyyy"));


                reportViewer1.LocalReport.DataSources.Add(dsJournalProoflistList);
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { paraDateFrom, paraDateTo });
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport(); // refresh report
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void dtDateTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtDateFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
