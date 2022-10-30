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
    public partial class BookProoflistSummary : MetroForm
    {
        public BookProoflistSummary()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            
            var spGLOverAllBookProoflistSummaryTableAdapter = new GeneralLedgerDataSet1TableAdapters.spGLOverAllBookProoflistSummaryTableAdapter();
            var result = spGLOverAllBookProoflistSummaryTableAdapter.GetData(Convert.ToDateTime(dtDateFrom.Value.ToString("MM/dd/yyyy")), Convert.ToDateTime(dtDateTo.Value.ToString("MM/dd/yyyy"))).ToList();
            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.ReportEmbeddedResource = "GeneralLedger.Report.RDLC.rptGLOverAllBoolProoflistSummary.rdlc"; // bind reportviewer with .rdlc
            Microsoft.Reporting.WinForms.ReportDataSource dsJournalProoflistList = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", result); // set the datasource

            ReportParameter paraDateFrom = new ReportParameter("dateFrom", dtDateFrom.Value.ToString("MM/dd/yyyy"));

            ReportParameter paraDateTo = new ReportParameter("dateTo", dtDateTo.Value.ToString("MM/dd/yyyy"));


            reportViewer1.LocalReport.DataSources.Add(dsJournalProoflistList);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { paraDateFrom, paraDateTo });
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport(); // refresh report

        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
