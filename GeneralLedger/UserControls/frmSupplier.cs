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
    public partial class frmSupplier : MetroUserControl
    {

        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }

        public int ID { get; set; }

        public Supplier Supplier { get; set; }

        public frmSupplier()
        {
            InitializeComponent();
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

                Supplier = new Supplier {
                    ID = int.TryParse(this.txtID.Text, out intParser) ? intParser : 0,
                    Name = this.txtSupplierName.Text,
                    StartingDebit = decimal.TryParse(this.txtStartingDebit.Text, out decimalParser) ? decimalParser : 0,
                    Balance = decimal.TryParse(this.txtBalance.Text, out decimalParser) ? decimalParser : 0,
                    Debit = decimal.TryParse(this.txtDebit.Text, out decimalParser) ? decimalParser : 0,
                    Credit = decimal.TryParse(this.txtCredit.Text, out decimalParser) ? decimalParser : 0,
                    Address = this.txtAddress.Text,
                    Contacts = this.txtContact.Text,
                    intIDBank = (this.cbBank.SelectedItem == null) ? 0 : ((Tier.BO.Bank)this.cbBank.SelectedItem).ID
                };


                SupplierBAL supplierBAL = new SupplierBAL();
                string result = supplierBAL.Manage(Supplier, TransType);

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

        private void frmSupplier_Load(object sender, EventArgs e)
        {
           

            BankBAL bankBAL = new BankBAL();

            var bankList = bankBAL.getBank(string.Empty);
            this.cbBank.DataSource = bankList;
            this.cbBank.ValueMember = "ID";
            this.cbBank.DisplayMember = "Name";



        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            try
            {
                double doubleParser;
                SearchSupplier ss = new SearchSupplier();
                ss.BringToFront();
                ss.TopMost = true;
                DialogResult res = ss.ShowDialog(this);

                if (res == DialogResult.OK)
                {
                    //this.ID = sc.customerName.ID;
                    //this.txtID.Text = sc.customerName.ID.ToString();
                    this.ID = ss.Supplier.ID;
                    this.txtID.Text = ss.Supplier.ID.ToString();
                    this.txtSupplierName.Text = ss.Supplier.Name;
                    this.txtStartingDebit.Value = Convert.ToDouble(ss.Supplier.StartingDebit);
                    this.txtDebit.Value = Convert.ToDouble(ss.Supplier.Debit);
                    this.txtCredit.Value = Convert.ToDouble(ss.Supplier.Credit);
                    this.txtBalance.Value = Convert.ToDouble(ss.Supplier.Balance);
                    this.txtAddress.Text = ss.Supplier.Address;
                    this.txtContact.Text = ss.Supplier.Contacts;
                    this.cbBank.SelectedValue = ss.Supplier.Bank.ID;

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }

        }

        public void clear() {
            this.ID = 0;
            this.txtID.Text = string.Empty;
            this.txtSupplierName.Text = string.Empty;
            this.txtStartingDebit.Value = 0;
            this.txtDebit.Value = 0;
            this.txtCredit.Value = 0;
            this.txtBalance.Value = 0;
            this.txtAddress.Text = string.Empty;
            this.txtContact.Text = string.Empty;
       
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int intParser;
                decimal decimalParser;

                string TransType = "delete";

                Supplier = new Supplier
                {
                    ID = int.TryParse(this.txtID.Text, out intParser) ? intParser : 0,
                    Name = this.txtSupplierName.Text,
                    StartingDebit = decimal.TryParse(this.txtStartingDebit.Text, out decimalParser) ? decimalParser : 0,
                    Balance = decimal.TryParse(this.txtBalance.Text, out decimalParser) ? decimalParser : 0,
                    Debit = decimal.TryParse(this.txtDebit.Text, out decimalParser) ? decimalParser : 0,
                    Credit = decimal.TryParse(this.txtCredit.Text, out decimalParser) ? decimalParser : 0,
                    Address = this.txtAddress.Text,
                    Contacts = this.txtContact.Text,
                    intIDBank = (this.cbBank.SelectedItem == null) ? 0 : ((Tier.BO.Bank)this.cbBank.SelectedItem).ID
                };


                SupplierBAL supplierBAL = new SupplierBAL();
                string result = supplierBAL.Manage(Supplier, TransType);

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
    }
}
