using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using GeneralLedger.Tier.BAL;
using GeneralLedger.Tier.BO;

namespace GeneralLedger.UserControls
{
    public partial class SearchCustomer : MetroForm
    {

        public GeneralLedger.Tier.BO.Customer Customer { get; set; }
        public int Index { get; set; }

        public SearchCustomer()
        {
            InitializeComponent();
        }
        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {

            try
            {
                CustomerBAL customerBAL = new CustomerBAL();
                List<GeneralLedger.Tier.BO.Customer> customerList = customerBAL.getCustomer(this.txtCriteria.Text);

                if ((customerList != null) && customerList.Count > 0)
                {
                    //this.dgSearchCustomer.ColumnCount = 9;
                    this.dgSearchCustomer.RowCount = customerList.Count;

                    for (int i = 0; i < customerList.Count; i++)
                    {
                        
                        this.dgSearchCustomer.Rows[i].Cells["ID"].Value = customerList[i].ID;
                        this.dgSearchCustomer.Rows[i].Cells["CustomerName"].Value = customerList[i].Name;
                        this.dgSearchCustomer.Rows[i].Cells["StartingDebit"].Value = customerList[i].StartingDebit;
                        this.dgSearchCustomer.Rows[i].Cells["Debit"].Value = customerList[i].Debit;
                        this.dgSearchCustomer.Rows[i].Cells["Credit"].Value = customerList[i].Credit;
                        this.dgSearchCustomer.Rows[i].Cells["CreditLimit"].Value = customerList[i].CreditLimit;
                        this.dgSearchCustomer.Rows[i].Cells["Terms"].Value = customerList[i].Terms;
                        this.dgSearchCustomer.Rows[i].Cells["PriceType"].Value = customerList[i].PriceType.Name;
                        this.dgSearchCustomer.Rows[i].Cells["PriceTypeID"].Value = customerList[i].PriceType.ID;
                        this.dgSearchCustomer.Rows[i].Cells["Address"].Value = customerList[i].Address;
                        this.dgSearchCustomer.Rows[i].Cells["Contact"].Value = customerList[i].Contact;
                   
                    }

                    setRowNumber(this.dgSearchCustomer);
                }
                else
                {

                    this.dgSearchCustomer.Rows.Clear();
                    this.dgSearchCustomer.Refresh();
                    MessageBox.Show("No Result");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

            try
            {
                this.Index = this.dgSearchCustomer.CurrentCell.RowIndex;

                if (Index >= 0)
                {
                    this.Customer = new Customer
                    {
                        ID = Int32.Parse(this.dgSearchCustomer.Rows[this.Index].Cells["ID"].Value.ToString()),
                        Name = this.dgSearchCustomer.Rows[this.Index].Cells["CustomerName"].Value.ToString(),
                        StartingDebit = decimal.Parse(this.dgSearchCustomer.Rows[this.Index].Cells["StartingDebit"].Value.ToString()),
                        Debit = decimal.Parse(this.dgSearchCustomer.Rows[this.Index].Cells["Debit"].Value.ToString()),
                        Credit = decimal.Parse(this.dgSearchCustomer.Rows[this.Index].Cells["Credit"].Value.ToString()),
                        CreditLimit = decimal.Parse(this.dgSearchCustomer.Rows[this.Index].Cells["CreditLimit"].Value.ToString()),
                        Terms = Int32.Parse(this.dgSearchCustomer.Rows[this.Index].Cells["Terms"].Value.ToString()),
                        PriceType = new Tier.BO.PriceType {
                           ID = Int32.Parse(this.dgSearchCustomer.Rows[this.Index].Cells["PriceTypeID"].Value.ToString()),
                           Name = this.dgSearchCustomer.Rows[this.Index].Cells["PriceType"].Value.ToString(),
                        },
                        Address = this.dgSearchCustomer.Rows[this.Index].Cells["Address"].Value.ToString(),
                        Contact = this.dgSearchCustomer.Rows[this.Index].Cells["Contact"].Value.ToString()
                    };

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Select item");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }

        }
    }
}
