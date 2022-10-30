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
    public partial class frmCustomer : MetroUserControl
    {

        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }
        public int ID { get; set; }

        public Customer Customer { get; set; }


        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            PriceTypeBAL priceTypeBAL = new PriceTypeBAL();
            List<GeneralLedger.Tier.BO.PriceType> priceTypeList = priceTypeBAL.getPriceType();

            this.cbPriceType.DataSource = priceTypeList;
            this.cbPriceType.ValueMember = "ID";
            this.cbPriceType.DisplayMember = "Name";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                int intParser;
                decimal decimalParser;

                string TransType = (this.ID == 0) ? "insert" : "update";
                Customer = new Customer
                {
                    ID = int.TryParse(this.txtID.Text, out intParser) ? intParser : 0,
                    Name = this.txtCustomerName.Text,
                    StartingDebit = decimal.TryParse(this.txtStartingDebit.Text, out decimalParser) ? decimalParser : 0,
                    CreditLimit = decimal.TryParse(this.txtCreditLimit.Text, out decimalParser) ? decimalParser : 0,
                    Debit = decimal.TryParse(this.txtDebit.Text, out decimalParser) ? decimalParser : 0,
                    Credit = decimal.TryParse(this.txtCredit.Text, out decimalParser) ? decimalParser : 0,
                    Terms = int.TryParse(this.txtTerms.Text, out intParser) ? intParser : 0,
                    PriceTypeID = (this.cbPriceType.SelectedItem == null) ? 0 : ((Tier.BO.PriceType)this.cbPriceType.SelectedItem).ID,
                    Address = this.txtAddress.Text,
                    Contact = this.txtContact.Text
                };


                CustomerBAL customerBAL = new CustomerBAL();
                string result = customerBAL.Manage(Customer, TransType);

                if (result != string.Empty)
                {
                    this.ID = Convert.ToInt32(result.Split(',')[0]);
                    this.txtID.Text = result.Split(',')[0];
                    MessageBox.Show("Successfully saved");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int intParser;
                decimal decimalParser;

                string TransType = "delete";
                Customer = new Customer
                {
                    ID = int.TryParse(this.txtID.Text, out intParser) ? intParser : 0,
                    Name = this.txtCustomerName.Text,
                    StartingDebit = decimal.TryParse(this.txtStartingDebit.Text, out decimalParser) ? decimalParser : 0,
                    CreditLimit = decimal.TryParse(this.txtCreditLimit.Text, out decimalParser) ? decimalParser : 0,
                    Terms = int.TryParse(this.txtTerms.Text, out intParser) ? intParser : 0,
                    PriceTypeID = (this.cbPriceType.SelectedItem == null) ? 0 : ((Tier.BO.PriceType)this.cbPriceType.SelectedItem).ID,
                    Address = this.txtAddress.Text,
                    Contact = this.txtContact.Text
                };


                CustomerBAL customerBAL = new CustomerBAL();
                string result = customerBAL.Manage(Customer, TransType);

                if (result != string.Empty)
                {
                    this.ID = Convert.ToInt32(result.Split(',')[0]);
                    this.txtID.Text = result.Split(',')[0];
                    MessageBox.Show("Successfully deleted");
                    clear();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }

        }

        public void clear()
        {
            this.ID = 0;
            this.txtID.Text = string.Empty;
            this.txtCustomerName.Text = string.Empty;
            this.txtStartingDebit.Value = 0;
            this.txtCreditLimit.Value = 0;
            this.txtTerms.Value = 0;
            this.txtContact.Text = string.Empty;
            this.txtAddress.Text = string.Empty;

        }

        private void btnFind_Click(object sender, EventArgs e)
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
                    this.txtID.Text = sc.Customer.ID.ToString();
                    this.txtCustomerName.Text = sc.Customer.Name;
                    this.txtStartingDebit.Value = Convert.ToDouble(sc.Customer.StartingDebit);
                    this.txtDebit.Value = Convert.ToDouble(sc.Customer.Debit);
                    this.txtCredit.Value = Convert.ToDouble(sc.Customer.Credit);
                    this.txtCreditLimit.Value = Convert.ToDouble(sc.Customer.CreditLimit);
                    this.txtTerms.Value = sc.Customer.Terms;
                    this.cbPriceType.SelectedValue = sc.Customer.PriceType.ID;
                    this.txtAddress.Text = sc.Customer.Address;
                    this.txtContact.Text = sc.Customer.Contact;

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
