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

namespace GeneralLedger.Report
{
    public partial class frmRptGLTrialBalance : MetroForm
    {
        public int ID { get; set; }
        public frmRptGLTrialBalance()
        {
            InitializeComponent();
        }

        private void frmRptGLTrialBalance_Load(object sender, EventArgs e)
        {
            TrialBalanceBAL trialBalanceBAL = new TrialBalanceBAL();

            List<GLTBHdr> listOfGLTBHeader = trialBalanceBAL.getGLTBById(this.ID);
            List<GLTBDtl> listOfGLTBDetail = trialBalanceBAL.getGLTBDetail(this.ID);



            reportViewer1.LocalReport.DataSources.Clear(); //clear report
            reportViewer1.LocalReport.ReportEmbeddedResource = "GeneralLedger.Report.RDLC.rptGLTrialBalance.rdlc"; // bind reportviewer with .rdlc

            Microsoft.Reporting.WinForms.ReportDataSource dataset1 = new Microsoft.Reporting.WinForms.ReportDataSource("dsTBhdr", listOfGLTBHeader); // set the datasource
            Microsoft.Reporting.WinForms.ReportDataSource dataset2 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", listOfGLTBDetail); // set the datasource

            reportViewer1.LocalReport.DataSources.Add(dataset1);
            reportViewer1.LocalReport.DataSources.Add(dataset2);

            dataset1.Value = listOfGLTBHeader;
            dataset2.Value = listOfGLTBDetail;

            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }
    }
}
