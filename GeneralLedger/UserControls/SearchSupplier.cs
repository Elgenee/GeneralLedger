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
    public partial class SearchSupplier : MetroForm
    {
        public int Index { get; set; }
        public GeneralLedger.Tier.BO.Supplier Supplier { get; set; }
        public SearchSupplier()
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
                SupplierBAL supplierBAL = new SupplierBAL();
                List<GeneralLedger.Tier.BO.Supplier> supplierList = supplierBAL.getSupplier(this.txtCriteria.Text);

                if ((supplierList != null) && supplierList.Count > 0)
                {
                    //this.dgSearchCustomer.ColumnCount = 9;
                    this.dgSearchSupplier.RowCount = supplierList.Count;

                    for (int i = 0; i < supplierList.Count; i++)
                    {

                        this.dgSearchSupplier.Rows[i].Cells["ID"].Value = supplierList[i].ID;
                        this.dgSearchSupplier.Rows[i].Cells["SupplierName"].Value = supplierList[i].Name;
                        this.dgSearchSupplier.Rows[i].Cells["StartingDebit"].Value = supplierList[i].StartingDebit;
                        this.dgSearchSupplier.Rows[i].Cells["Debit"].Value = supplierList[i].Debit;
                        this.dgSearchSupplier.Rows[i].Cells["Credit"].Value = supplierList[i].Credit;
                        this.dgSearchSupplier.Rows[i].Cells["Balance"].Value = supplierList[i].Balance;
                        this.dgSearchSupplier.Rows[i].Cells["Address"].Value = supplierList[i].Address;
                        this.dgSearchSupplier.Rows[i].Cells["Contacts"].Value = supplierList[i].Contacts;
                        this.dgSearchSupplier.Rows[i].Cells["BankID"].Value = supplierList[i].Bank.ID;
                        this.dgSearchSupplier.Rows[i].Cells["BankName"].Value = supplierList[i].Bank.AccountName;
                    }

                    setRowNumber(this.dgSearchSupplier);
                }
                else
                {

                    this.dgSearchSupplier.Rows.Clear();
                    this.dgSearchSupplier.Refresh();
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
                this.Index = this.dgSearchSupplier.CurrentCell.RowIndex;

                if (Index >= 0)
                {
                    this.Supplier = new GeneralLedger.Tier.BO.Supplier
                    {
                        ID = Int32.Parse(this.dgSearchSupplier.Rows[this.Index].Cells["ID"].Value.ToString()),
                        Name = this.dgSearchSupplier.Rows[this.Index].Cells["SupplierName"].Value.ToString(),
                        StartingDebit = decimal.Parse(this.dgSearchSupplier.Rows[this.Index].Cells["StartingDebit"].Value.ToString()),
                        Debit = decimal.Parse(this.dgSearchSupplier.Rows[this.Index].Cells["Debit"].Value.ToString()),
                        Credit = decimal.Parse(this.dgSearchSupplier.Rows[this.Index].Cells["Credit"].Value.ToString()),
                        Balance = decimal.Parse(this.dgSearchSupplier.Rows[this.Index].Cells["Balance"].Value.ToString()),
                        Address = this.dgSearchSupplier.Rows[this.Index].Cells["Address"].Value.ToString(),
                        Contacts = this.dgSearchSupplier.Rows[this.Index].Cells["Contacts"].Value.ToString(),
                        intIDBank = Int32.Parse(this.dgSearchSupplier.Rows[this.Index].Cells["BankID"].Value.ToString()),
                        Bank = new Tier.BO.Bank
                        {
                            ID = Int32.Parse(this.dgSearchSupplier.Rows[this.Index].Cells["BankID"].Value.ToString()),
                            AccountName = this.dgSearchSupplier.Rows[this.Index].Cells["BankName"].Value.ToString(),
                            
                        }

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
