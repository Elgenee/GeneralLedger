using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using GeneralLedger.Tier.BO;
using GeneralLedger.Tier.BAL;
using System.Globalization;
using GeneralLedger.Persistence.Services;
using GeneralLedger.Core.Domain;

namespace GeneralLedger.UserControls
{
    public partial class frmSalesLedger : MetroUserControl
    {

        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }
        public int Id { get; set; }
        public string TransactionNo { get; set; }
        public string CustomerName { get; set; }
        public string POno { get; set; }
        public decimal Total { get; set; }
        public DateTime TransactionDate { get; set; }
        public SaleServices SaleServices { get; set; }

        public SalesCustomerLedgerServices SalesCustomerLedgerServices { get; set; }

        public frmSalesLedger(int id)
        {
            this.Id = id;
            SaleServices = new SaleServices();
            SalesCustomerLedgerServices = new SalesCustomerLedgerServices();
            InitializeComponent();
           
        }

        private void frmSalesLedger_Load(object sender, EventArgs e)
        {
            try
            {
                var sale = this.SaleServices.GetSaleWithCustomerAgent(this.Id);
                this.txtTransactionNo.Text = sale.TRANo;
                this.txtPONo.Text = sale.PONo;
                this.dtTransactionDate.Value = (DateTime)sale.TransactionDate;
                this.txtTotal.Text = sale.Total.ToString();
                this.txtCustomerName.Text = sale.Customer.strName;
                this.txtAgent.Text = sale.Agent.Name;

                var saleLedger = this.SalesCustomerLedgerServices.GetSalesCustomerLedger(this.Id).ToList();

                var runningBalance = saleLedger.OrderByDescending(l => l.ID).Select(l => l.curRunningBalance).FirstOrDefault();
                this.txtRunningBalance.Text = runningBalance.ToString();

                if (saleLedger != null && saleLedger.Count() > 0) {
                    this.dtgSaleLedger.RowCount = saleLedger.Count();

                    for (int i = 0; i < saleLedger.Count(); i++)
                    {
                        this.dtgSaleLedger.Rows[i].Cells["ID"].Value = saleLedger[i].ID;
                        this.dtgSaleLedger.Rows[i].Cells["intIdSalesCustomerLedgerTransactionType"].Value = saleLedger[i].intIdSalesCustomerLedgerTransctionType;
                        this.dtgSaleLedger.Rows[i].Cells["strType"].Value = saleLedger[i].strType;
                        this.dtgSaleLedger.Rows[i].Cells["intIdSales"].Value = saleLedger[i].intIdSales;
                        this.dtgSaleLedger.Rows[i].Cells["intIdCollection"].Value = saleLedger[i].intIdCollection;
                        this.dtgSaleLedger.Rows[i].Cells["strTransactionNo"].Value = saleLedger[i].strTransactionNo;
                        this.dtgSaleLedger.Rows[i].Cells["datDateTransaction"].Value = saleLedger[i].datDateTransaction.Value.ToShortDateString();
                        this.dtgSaleLedger.Rows[i].Cells["curTotalAmount"].Value = string.Format("{0:0.00}", saleLedger[i].curTotalAmount);
                        this.dtgSaleLedger.Rows[i].Cells["curRunningBalance"].Value = string.Format("{0:0.00}", saleLedger[i].curRunningBalance);
                    }
                }
                else
                {
                    this.dtgSaleLedger.Rows.Clear();
                    this.dtgSaleLedger.Refresh();
                    MessageBox.Show("No Result");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }
    }
}
