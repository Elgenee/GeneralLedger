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
    public partial class frmReportCustomerLedger : MetroForm
    {
        public int Id { get; set; }

        public frmReportCustomerLedger()
        {
            InitializeComponent();
        }

        private void frmReportCustomerLedger_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            try
            {
                double doubleParser;
                SearchCustomer sc = new SearchCustomer();
                sc.BringToFront();
                sc.TopMost = true;
                DialogResult res = sc.ShowDialog(this);

                if (res == DialogResult.OK)
                {
                    this.Id = sc.Customer.ID;
                    this.txtCustomerName.Text = sc.Customer.Name;

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }

        }
    }
}
