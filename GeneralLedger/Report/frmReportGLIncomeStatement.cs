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
    public partial class frmReportGLIncomeStatement : MetroForm
    {
        public frmReportGLIncomeStatement()
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
            List<rptISIncome> isIncome = glBal.getRepISIncome(Convert.ToInt32(intFiscYear), Convert.ToInt32(intMonth));
            List<rptISExpenses> isExpense = glBal.getRepISExpense(Convert.ToInt32(intFiscYear), Convert.ToInt32(intMonth));
            List<rptISTotal> isTotal = glBal.getRepISTotal(Convert.ToInt32(intFiscYear), Convert.ToInt32(intMonth));
            List<rptISProvisionIT> isProvIT = glBal.getRepISProvIT(Convert.ToInt32(intFiscYear), Convert.ToInt32(intMonth));
            List<rptISNetIncome> isNetInc = glBal.getRepISNetInc(Convert.ToInt32(intFiscYear), Convert.ToInt32(intMonth));

            List<rptISNetSalesTotal> isNetSalesTotal = glBal.getRepISNetSalesTotal(Convert.ToInt32(intFiscYear), Convert.ToInt32(intMonth));

            List<rptISLessSales> isLessSales = glBal.getRepISLessSales(Convert.ToInt32(intFiscYear), Convert.ToInt32(intMonth));

            List<rptISLessCostOfGoodSold> isLessCostOfGoodSold = glBal.getRepISLessCostOfGoodSold(Convert.ToInt32(intFiscYear), Convert.ToInt32(intMonth));
            List<rptISNetSalesTotal> isLessCostOfGoodSoldTotal = glBal.getRepISLessCostOfGoodSoldTotal(Convert.ToInt32(intFiscYear), Convert.ToInt32(intMonth));

            reportViewer1.LocalReport.DataSources.Clear(); //clear report

            reportViewer1.LocalReport.ReportEmbeddedResource = "GeneralLedger.Report.RDLC.GLIncomeStatement.rdlc"; // bind reportviewer with .rdlc
            Microsoft.Reporting.WinForms.ReportDataSource dsisIncome2 = new Microsoft.Reporting.WinForms.ReportDataSource("dsISGrossSales", isIncome); // set the datasource

            Microsoft.Reporting.WinForms.ReportDataSource dsisNetSalesTotal = new Microsoft.Reporting.WinForms.ReportDataSource("dsISNetSalesTotal", isNetSalesTotal);
            //Microsoft.Reporting.WinForms.ReportDataSource dsisIncome = new Microsoft.Reporting.WinForms.ReportDataSource("dsIncome", isIncome); // set the datasource
            Microsoft.Reporting.WinForms.ReportDataSource dsisExpense = new Microsoft.Reporting.WinForms.ReportDataSource("dsExpense", isExpense); // set the datasource
            Microsoft.Reporting.WinForms.ReportDataSource dsisTotal = new Microsoft.Reporting.WinForms.ReportDataSource("dsTotal", isTotal); // set the datasource
            Microsoft.Reporting.WinForms.ReportDataSource dsisProvIT = new Microsoft.Reporting.WinForms.ReportDataSource("dsISProvIT", isProvIT); // set the datasource
            Microsoft.Reporting.WinForms.ReportDataSource dsisNetInc = new Microsoft.Reporting.WinForms.ReportDataSource("dsNetInc", isNetInc); // set the datasource
            Microsoft.Reporting.WinForms.ReportDataSource dsisLessSales = new Microsoft.Reporting.WinForms.ReportDataSource("dsISLessSales", isLessSales); // set the datasource
            Microsoft.Reporting.WinForms.ReportDataSource dsisLessCostOfGoodSold = new Microsoft.Reporting.WinForms.ReportDataSource("dsISLessCostOfGoodSold", isLessCostOfGoodSold); // set the datasource
            Microsoft.Reporting.WinForms.ReportDataSource dsisLessCostOfGoodSoldTotal = new Microsoft.Reporting.WinForms.ReportDataSource("dsISLessCostOfGoodSoldTotal", isLessCostOfGoodSoldTotal); // set the datasource

            ReportParameter parameters = new ReportParameter("PeriodEnded", strDate);

            //reportViewer1.LocalReport.DataSources.Add(dsisIncome);
            reportViewer1.LocalReport.DataSources.Add(dsisExpense);
            reportViewer1.LocalReport.DataSources.Add(dsisTotal);
            reportViewer1.LocalReport.DataSources.Add(dsisProvIT);
            reportViewer1.LocalReport.DataSources.Add(dsisNetInc);
            reportViewer1.LocalReport.DataSources.Add(dsisIncome2);
            reportViewer1.LocalReport.DataSources.Add(dsisLessSales);
            reportViewer1.LocalReport.DataSources.Add(dsisLessCostOfGoodSold);
            reportViewer1.LocalReport.DataSources.Add(dsisNetSalesTotal);
            reportViewer1.LocalReport.DataSources.Add(dsisLessCostOfGoodSoldTotal);

            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parameters });

            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport(); // refresh report

            //parameters[0] = new ReportParameter("PeriodEnded", strDate);
         
            //dsisIncome.Value = isIncome;
            //dsisExpense.Value = isExpense;
            //dsisTotal.Value = isTotal;
            //dsisProvIT.Value = isProvIT;
            //dsisNetInc.Value = isNetInc;

        }

        private void frmReportGLIncomeStatement_Load(object sender, EventArgs e)
        {

        }
    }
}
