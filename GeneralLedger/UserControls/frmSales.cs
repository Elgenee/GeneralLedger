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


namespace GeneralLedger.UserControls
{
    public partial class frmSales :  MetroUserControl
    {
        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }

        public int ID { get; set; }

        public frmSales()
        {
            InitializeComponent();
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
                    this.ID = sc.Customer.ID;
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
    }
}
