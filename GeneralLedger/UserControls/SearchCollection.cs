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
using GeneralLedger.Persistence.Services;
using GeneralLedger.Core.Domain;

namespace GeneralLedger.UserControls
{
    public partial class SearchCollection : MetroForm
    {

        public Collection Collection { get; set; }
        public CollectionServices CollectionServices { get; set; }

        public int Index { get; set; }
        public SearchCollection()
        {
            InitializeComponent();
            CollectionServices = new CollectionServices();
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
                var collectionResult = CollectionServices.GetCollectionWithSaleBank(this.txtCriteria.Text);
                if ((collectionResult != null) && collectionResult.Count > 0)
                {
                    //this.dgSearchCustomer.ColumnCount = 9; string.Format("{0:0.00}", saleResult[i].Total)
                    this.dgSearchSale.RowCount = collectionResult.Count;

                    for (int i = 0; i < collectionResult.Count; i++)
                    {

                        this.dgSearchSale.Rows[i].Cells["ID"].Value = collectionResult[i].Id;
                        this.dgSearchSale.Rows[i].Cells["TransactionNo"].Value = collectionResult[i].TRANo;
                        this.dgSearchSale.Rows[i].Cells["TransactionDate"].Value = collectionResult[i].TransactionDate.Value.ToShortDateString();
                        this.dgSearchSale.Rows[i].Cells["SalesID"].Value = collectionResult[i].SalesId;
                        this.dgSearchSale.Rows[i].Cells["SaleTransactionNo"].Value = collectionResult[i].Sale.TRANo;
                        this.dgSearchSale.Rows[i].Cells["PONo"].Value = collectionResult[i].Sale.PONo;
                        this.dgSearchSale.Rows[i].Cells["Customer"].Value = collectionResult[i].Sale.Customer.strName;
                        this.dgSearchSale.Rows[i].Cells["Total"].Value = string.Format("{0:0.00}", collectionResult[i].Sale.Total);
                        this.dgSearchSale.Rows[i].Cells["IsCash"].Value = collectionResult[i].IsCash;
                        this.dgSearchSale.Rows[i].Cells["CheckDetail"].Value = collectionResult[i].CheckDetail;
                        this.dgSearchSale.Rows[i].Cells["BankAccountId"].Value = ((bool)collectionResult[i].IsCash)? 1 : collectionResult[i].Bank.Id;
                        this.dgSearchSale.Rows[i].Cells["BankAccount"].Value = ((bool)collectionResult[i].IsCash) ? string.Empty :collectionResult[i].Bank.strName;
                        this.dgSearchSale.Rows[i].Cells["Description"].Value = collectionResult[i].Description;
                        this.dgSearchSale.Rows[i].Cells["GLTranHeaderID"].Value = collectionResult[i].tblGLTranHeaders.Select(h => h.ID).FirstOrDefault();

                    }

                    setRowNumber(this.dgSearchSale);
                }
                else
                {

                    this.dgSearchSale.Rows.Clear();
                    this.dgSearchSale.Refresh();
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
                this.Index = this.dgSearchSale.CurrentCell.RowIndex;

                if (Index >= 0)
                {
                    this.Collection = new Collection
                    {
                        Id = Int32.Parse(this.dgSearchSale.Rows[this.Index].Cells["ID"].Value.ToString()),
                        TRANo = this.dgSearchSale.Rows[this.Index].Cells["TransactionNo"].Value.ToString(),
                        TransactionDate = Convert.ToDateTime(this.dgSearchSale.Rows[this.Index].Cells["TransactionDate"].Value.ToString()),
                        SalesId = Int32.Parse(this.dgSearchSale.Rows[this.Index].Cells["SalesID"].Value.ToString()),
                        Sale = new Sale {
                             Id = Int32.Parse(this.dgSearchSale.Rows[this.Index].Cells["SalesID"].Value.ToString()),
                             TRANo = this.dgSearchSale.Rows[this.Index].Cells["SaleTransactionNo"].Value.ToString(),
                             PONo = this.dgSearchSale.Rows[this.Index].Cells["PONo"].Value.ToString(),
                             Customer = new Customer { 
                              strName = this.dgSearchSale.Rows[this.Index].Cells["Customer"].Value.ToString()
                             }
                        },
                        IsCash = Convert.ToBoolean(this.dgSearchSale.Rows[this.Index].Cells["IsCash"].Value.ToString()),
                        Total = Convert.ToDecimal(this.dgSearchSale.Rows[this.Index].Cells["Total"].Value.ToString()),
                        CheckDetail = this.dgSearchSale.Rows[this.Index].Cells["CheckDetail"].Value.ToString(),
                        BankId = Int32.Parse(this.dgSearchSale.Rows[this.Index].Cells["BankAccountId"].Value.ToString()),
                        Bank = new Core.Domain.Bank
                        {
                            Id = Int32.Parse(this.dgSearchSale.Rows[this.Index].Cells["BankAccountId"].Value.ToString()),
                            strAccountName = this.dgSearchSale.Rows[this.Index].Cells["BankAccount"].Value.ToString()
                        },
                        Description = this.dgSearchSale.Rows[this.Index].Cells["Description"].Value.ToString(),
                        tblGLTranHeaders = new List<tblGLTranHeader> {
                            new tblGLTranHeader {
                             ID = Int32.Parse(this.dgSearchSale.Rows[this.Index].Cells["GLTranHeaderID"].Value.ToString())
                            }
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
