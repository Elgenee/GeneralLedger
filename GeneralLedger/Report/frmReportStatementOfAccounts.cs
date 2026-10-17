using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using GeneralLedger.UserControls;
using MetroFramework.Forms;
using Microsoft.Reporting.WinForms;

namespace GeneralLedger.Report
{
    public partial class frmReportStatementOfAccounts : MetroForm
    {
        public int Id { get; set; }

        public frmReportStatementOfAccounts()
        {
            InitializeComponent();
            dtDateAsOf.Value = DateTime.Today;
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                using (var searchCustomer = new SearchCustomer())
                {
                    searchCustomer.TopMost = true;
                    if (searchCustomer.ShowDialog(this) == DialogResult.OK
                        && searchCustomer.Customer != null)
                    {
                        Id = searchCustomer.Customer.ID;
                        txtCustomerName.Text = searchCustomer.Customer.Name;
                        BringToFront();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Unable to select a customer: " + ex.Message,
                    "Statement of Accounts", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (Id <= 0 || string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show(this, "Please search and select a customer first.",
                    "Statement of Accounts", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSearchCustomer.Focus();
                return;
            }

            try
            {
                btnPreview.Enabled = false;
                UseWaitCursor = true;

                var connectionSettings = ConfigurationManager.ConnectionStrings["MainDB"];
                if (connectionSettings == null
                    || string.IsNullOrWhiteSpace(connectionSettings.ConnectionString))
                {
                    throw new InvalidOperationException("The MainDB connection is not configured.");
                }

                using (var adapter = new GeneralLedgerDataSetTableAdapters.usp_GetCustomerStatementOfAccountTableAdapter())
                {
                    // Use the same database as the customer search and ledger report.
                    adapter.Connection.ConnectionString = connectionSettings.ConnectionString;
                    var statementDate = dtDateAsOf.Value.Date;
                    var statement = adapter.GetData(Id, statementDate, false);

                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.ReportEmbeddedResource =
                        "GeneralLedger.Report.RDLC.rptReportStatementOfAccounts.rdlc";
                    reportViewer1.LocalReport.DataSources.Add(
                        new ReportDataSource("GeneralLedgerDataSet", (DataTable)statement));
                    reportViewer1.LocalReport.SetParameters(new[]
                    {
                        new ReportParameter("CustomerName", txtCustomerName.Text),
                        new ReportParameter("DateAsOf",
                            statementDate.ToString("s", CultureInfo.InvariantCulture))
                    });
                    reportViewer1.LocalReport.Refresh();
                    reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Unable to preview the statement of accounts: " + ex.Message,
                    "Statement of Accounts", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UseWaitCursor = false;
                btnPreview.Enabled = true;
            }
        }
    }
}
