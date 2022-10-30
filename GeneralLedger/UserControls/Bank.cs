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
    public partial class Bank : MetroUserControl
    {
        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }
        public int ID { get; set; }

        public Bank()
        {
            InitializeComponent();

            BankBAL bankBal = new BankBAL();
            var currencyList = bankBal.getCurrency();
            this.cbCurrency.DataSource = currencyList;
            this.cbCurrency.ValueMember = "ID";
            this.cbCurrency.DisplayMember = "Name";
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

                var bank = new GeneralLedger.Tier.BO.Bank {
                    ID = int.TryParse(this.txtID.Text, out intParser) ? intParser : 0,
                    AccountName = this.txtAccountName.Text,
                    AccountNo = this.txtBankAccountNo.Text,
                    Name = this.txtBankName.Text,
                    Branch = this.txtBranch.Text,
                    CurrencyID = (this.cbCurrency.SelectedItem == null) ? 0 : ((GeneralLedger.Tier.BO.Currency)this.cbCurrency.SelectedItem).ID,
                    StartingDebit = decimal.TryParse(this.txtStartingDebit.Text, out decimalParser) ? decimalParser : 0,
                    Credit = decimal.TryParse(this.txtCredit.Text, out decimalParser) ? decimalParser : 0,
                    Debit = decimal.TryParse(this.txtDebit.Text, out decimalParser) ? decimalParser : 0,
                    Balance = decimal.TryParse(this.txtBalance.Text, out decimalParser) ? decimalParser : 0,

                };


                BankBAL bankBal = new BankBAL();
                string result = bankBal.Manage(bank, TransType);


                if (result != string.Empty)
                {
                    this.ID = Convert.ToInt32(result.Split(',')[0]);
                    this.txtID.Text = this.ID.ToString();
                    MessageBox.Show("Successfully saved");
                }

            }
            catch (Exception ex)
            {


                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                double doubleParser;
                SearchBank sb = new SearchBank();
                sb.BringToFront();
                sb.TopMost = true;
                DialogResult res = sb.ShowDialog(this);

                if (res == DialogResult.OK)
                {
                    this.ID = sb.BankID;
                    this.txtID.Text = this.ID.ToString();
                    this.txtBankName.Text = sb.Bank.Name;
                    this.txtBankAccountNo.Text = sb.Bank.AccountNo;
                    this.txtAccountName.Text = sb.Bank.AccountName;
                    this.txtBranch.Text = sb.Bank.Branch;
                    this.cbCurrency.SelectedValue = sb.Bank.CurrencyID;
                    this.txtStartingDebit.Value = double.Parse(sb.Bank.StartingDebit.ToString());
                    this.txtCredit.Value = double.Parse(sb.Bank.Credit.ToString());
                    this.txtDebit.Value = double.Parse(sb.Bank.Debit.ToString());
                    this.txtBalance.Value = double.Parse(sb.Bank.Balance.ToString());

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

                var bank = new GeneralLedger.Tier.BO.Bank
                {
                    ID = int.TryParse(this.txtID.Text, out intParser) ? intParser : 0,
                    AccountName = this.txtAccountName.Text,
                    AccountNo = this.txtBankAccountNo.Text,
                    Name = this.txtBankName.Text,
                    Branch = this.txtBranch.Text,
                    CurrencyID = (this.cbCurrency.SelectedItem == null) ? 0 : ((GeneralLedger.Tier.BO.Currency)this.cbCurrency.SelectedItem).ID,
                    StartingDebit = decimal.TryParse(this.txtStartingDebit.Text, out decimalParser) ? decimalParser : 0,
                    Credit = decimal.TryParse(this.txtCredit.Text, out decimalParser) ? decimalParser : 0,
                    Debit = decimal.TryParse(this.txtDebit.Text, out decimalParser) ? decimalParser : 0,
                    Balance = decimal.TryParse(this.txtBalance.Text, out decimalParser) ? decimalParser : 0,

                };


                BankBAL bankBal = new BankBAL();
                string result = bankBal.Manage(bank, TransType);


                if (result != string.Empty)
                {
                    this.ID = Convert.ToInt32(result.Split(',')[0]);
                    MessageBox.Show("Delete successfully");
                    clear();
                }

            }
            catch (Exception ex)
            {


                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void clear() {
            this.txtAccountName.Text = string.Empty;
            this.txtBankAccountNo.Text = string.Empty;
            this.txtBankName.Text = string.Empty;
            this.txtBranch.Text = this.txtBranch.Text;
            this.txtStartingDebit.Text = string.Empty;
            this.txtCredit.Text = string.Empty;
            this.txtDebit.Text = string.Empty;
            this.txtBalance.Text = string.Empty;
            this.txtBranch.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
