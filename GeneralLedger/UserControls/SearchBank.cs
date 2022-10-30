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
    public partial class SearchBank : MetroForm
    {

        public GeneralLedger.Tier.BO.Bank Bank { get; set; }
        public int BankID { get; set; }

        public int Index { get; set; }
        public SearchBank()
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
                BankBAL bankBAL = new BankBAL();
                List<GeneralLedger.Tier.BO.Bank> bankList = bankBAL.getBank(this.txtCriteria.Text);

                if ((bankList != null) && bankList.Count > 0)
                {
                    this.dgSearchBank.ColumnCount = 10;
                    this.dgSearchBank.RowCount = bankList.Count;

                    for (int i = 0; i < bankList.Count; i++)
                    {

                        this.dgSearchBank.Rows[i].Cells[0].Value = bankList[i].ID;
                        this.dgSearchBank.Rows[i].Cells[1].Value = bankList[i].Name;
                        this.dgSearchBank.Rows[i].Cells[2].Value = bankList[i].AccountNo;
                        this.dgSearchBank.Rows[i].Cells[3].Value = bankList[i].AccountName;
                        this.dgSearchBank.Rows[i].Cells[4].Value = bankList[i].Branch;
                        this.dgSearchBank.Rows[i].Cells[5].Value = bankList[i].StartingDebit;
                        this.dgSearchBank.Rows[i].Cells[6].Value = bankList[i].Debit;
                        
                        this.dgSearchBank.Rows[i].Cells[7].Value = bankList[i].Credit;
                        this.dgSearchBank.Rows[i].Cells[8].Value = bankList[i].Balance;
                        this.dgSearchBank.Rows[i].Cells[9].Value = bankList[i].CurrencyID;
                    }

                    setRowNumber(this.dgSearchBank);
                }
                else
                {

                    this.dgSearchBank.Rows.Clear();
                    this.dgSearchBank.Refresh();
                    MessageBox.Show("No Result");
                }

            }
            catch (Exception ex)
            {
            
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void dgSearchBank_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
           
            try
            {
                this.Index = this.dgSearchBank.CurrentCell.RowIndex;
                if (Index >= 0 )
                {
                    this.BankID = Int32.Parse(this.dgSearchBank.Rows[this.Index].Cells[0].Value.ToString());
                    this.Bank = new Tier.BO.Bank
                    {
                        ID = Int32.Parse(this.dgSearchBank.Rows[this.Index].Cells[0].Value.ToString()),
                        Name = this.dgSearchBank.Rows[this.Index].Cells[1].Value.ToString(),
                        AccountNo = this.dgSearchBank.Rows[this.Index].Cells[2].Value.ToString(),
                        AccountName = this.dgSearchBank.Rows[this.Index].Cells[3].Value.ToString(),
                        Branch = this.dgSearchBank.Rows[this.Index].Cells[4].Value.ToString(),
                        StartingDebit = decimal.Parse(this.dgSearchBank.Rows[this.Index].Cells[5].Value.ToString()),
                        Debit = decimal.Parse(this.dgSearchBank.Rows[this.Index].Cells[6].Value.ToString()),
                        Credit = decimal.Parse(this.dgSearchBank.Rows[this.Index].Cells[7].Value.ToString()),
                        Balance = decimal.Parse(this.dgSearchBank.Rows[this.Index].Cells[8].Value.ToString()),
                        CurrencyID = Int32.Parse(this.dgSearchBank.Rows[this.Index].Cells[9].Value.ToString())

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
