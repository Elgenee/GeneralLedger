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
    public partial class frmReportProoflistDetail : MetroForm
    {
        public frmReportProoflistDetail()
        {
            InitializeComponent();
            var spGLGetBookTypeTableAdapter = new GeneralLedgerDataSet1TableAdapters.spGLGetBookTypeTableAdapter();
            this.cbBookType.DataSource = spGLGetBookTypeTableAdapter.GetData().ToList();
            this.cbBookType.ValueMember = "ID";
            this.cbBookType.DisplayMember = "strName";
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            int intParser;

            var spProoflistDetailTableAdapter = new GeneralLedgerDataSet1TableAdapters.spRptProoflistDetailTableAdapter();
            var idBookType = int.TryParse(this.cbBookType.SelectedValue.ToString(), out intParser) ? intParser : 0;
            var result = spProoflistDetailTableAdapter.GetData(idBookType, dtDateFrom.Value, dtDateTo.Value).ToList();
            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.ReportEmbeddedResource = "GeneralLedger.Report.RDLC.ProoflistDetail.rdlc"; // bind reportviewer with .rdlc
            Microsoft.Reporting.WinForms.ReportDataSource dsJournalProoflistList = new Microsoft.Reporting.WinForms.ReportDataSource("dsProoflistDetail", result); // set the datasource

            ReportParameter paraDateFrom = new ReportParameter("datDateFrom", dtDateFrom.Value.ToString("MM/dd/yyyy"));

            ReportParameter paraDateTo = new ReportParameter("datDateTo", dtDateTo.Value.ToString("MM/dd/yyyy"));

            var bookTypeName = ((GeneralLedger.GeneralLedgerDataSet1.spGLGetBookTypeRow)this.cbBookType.SelectedItem).strName;

            ReportParameter paraBookType = new ReportParameter("strBookType", bookTypeName);



            reportViewer1.LocalReport.DataSources.Add(dsJournalProoflistList);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { paraDateFrom, paraDateTo, paraBookType });
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport(); // refresh report


        }
    }
}
