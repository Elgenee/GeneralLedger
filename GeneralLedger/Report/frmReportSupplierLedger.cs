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
using GeneralLedger.UserControls;

namespace GeneralLedger.Report
{
    public partial class frmReportSupplierLedger : MetroForm
    {
        public int Id { get; set; }

        public frmReportSupplierLedger()
        {
            InitializeComponent();
        }

        private void frmReportCustomerLedger_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
            //this.reportViewer2.RefreshReport();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            GLBAL glBal = new GLBAL();
            List<rptGetSupplierLedgerOverall> rptGetSupplierLedgerOverallList =  glBal.getSupplierLedgerOverall(this.Id);
            reportViewer2.LocalReport.DataSources.Clear(); //clear report
         
            reportViewer2.LocalReport.ReportEmbeddedResource = "GeneralLedger.Report.RDLC.SupplierLedgerOverall.rdlc"; // bind reportviewer with .rdlc
            Microsoft.Reporting.WinForms.ReportDataSource dsJournalProoflistList = new Microsoft.Reporting.WinForms.ReportDataSource("dsGetSupplierLedgerOverall", rptGetSupplierLedgerOverallList); // set the datasource

            ReportParameter datAsOfDate = new ReportParameter("Supplier", this.txtSupplierName.Text);

            reportViewer2.LocalReport.DataSources.Add(dsJournalProoflistList);
            reportViewer2.LocalReport.SetParameters(new ReportParameter[] { datAsOfDate });
            this.reportViewer2.LocalReport.Refresh();
            this.reportViewer2.RefreshReport(); // refresh report
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {

            try
            {
                double doubleParser;
                SearchSupplier sc = new SearchSupplier();
                sc.BringToFront();
                sc.TopMost = true;
                DialogResult res = sc.ShowDialog(this);

                if (res == DialogResult.OK)
                {
                    this.Id = sc.Supplier.ID;
                    this.txtSupplierName.Text = sc.Supplier.Name;
                    this.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}
