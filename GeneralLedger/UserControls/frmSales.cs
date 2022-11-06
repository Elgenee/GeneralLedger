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
    public partial class frmSales :  MetroUserControl
    {
        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }

        public Sale Sale { get; set; }
        public SaleServices SaleServices { get; set; }

        public int ID { get; set; }

        public int CustomerId { get; set; }

        public int AgentId { get; set; }

        public frmSales()
        {
            InitializeComponent();
            SaleServices = new SaleServices();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
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
                    this.CustomerId = sc.Customer.ID;
                    this.txtCustomerID.Text = sc.Customer.ID.ToString(); 
                    this.txtCustomerName.Text = sc.Customer.Name;
                    this.txtTerms.Text = sc.Customer.Terms.ToString();
                    //this.txtID.Text = sc.Customer.ID.ToString();
                    //this.txtCustomerName.Text = sc.Customer.Name;
                    //this.txtStartingDebit.Value = Convert.ToDouble(sc.Customer.StartingDebit);
                    //this.txtDebit.Value = Convert.ToDouble(sc.Customer.Debit);
                    //this.txtCredit.Value = Convert.ToDouble(sc.Customer.Credit);
                    //this.txtCreditLimit.Value = Convert.ToDouble(sc.Customer.CreditLimit);
                    //this.txtTerms.Value = sc.Customer.Terms;
                    //this.cbPriceType.SelectedValue = sc.Customer.PriceType.ID;
                    //this.txtAddress.Text = sc.Customer.Address;
                    //this.txtContact.Text = sc.Customer.Contact;

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnSearchAgent_Click(object sender, EventArgs e)
        {
            try
            {
                double doubleParser;
                SearchAgent sa = new SearchAgent();
                sa.BringToFront();
                sa.TopMost = true;
                DialogResult res = sa.ShowDialog(this);

                if (res == DialogResult.OK)
                {
                    this.AgentId = sa.Agent.Id;
                    this.txtAgentID.Text = sa.Agent.Id.ToString();
                    this.txtAgent.Text = sa.Agent.Name;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                int intParser;
                decimal decimalParser;

                string TransType = (this.ID == 0) ? "insert" : "update";

                Sale = new Sale { 
                    Id = this.ID,
                    PONo = this.txtPONo.Text,
                    TRANo = this.txtTransactionNo.Text,
                    intIdAgent = this.AgentId,
                    intIdCustomer = this.CustomerId,
                    Total = decimal.TryParse(this.txtTotal.Text, out decimalParser) ? decimalParser : 0,
                    TransactionDate = this.dtTransactionDate.Value
                };

                if (TransType.Equals("insert"))
                {
                    var sale = SaleServices.Add(Sale);
                    if (sale != null)
                    {
                        MessageBox.Show("Successfully saved");
                    }
                }
                else
                {
                    var sale = SaleServices.Add(Sale);
                    if (sale != null)
                    {
                        MessageBox.Show("Successfully saved");
                    }
                }

                this.ID = Sale.Id;
                this.txtID.Text = Sale.Id.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}
