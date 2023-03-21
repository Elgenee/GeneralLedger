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
    public partial class SearchAdjustmentAccountReceivableAdjustmentsReturnCheck : MetroForm
    {

        public AccountReceivableAdjustment AccountReceivableAdjustment { get; set; }
        public AccountReceivableAdjustmentsServices AccountReceivableAdjustmentsServices { get; set; }
        public int Index { get; set; }
        public SearchAdjustmentAccountReceivableAdjustmentsReturnCheck()
        {
            InitializeComponent();
            AccountReceivableAdjustment = new AccountReceivableAdjustment();
            AccountReceivableAdjustmentsServices = new AccountReceivableAdjustmentsServices();
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
                var adjustmentReceivableResult = AccountReceivableAdjustmentsServices.GetAccountReceivableAdjustmentsWithCollectionSales(this.txtCriteria.Text, 1);
                if ((adjustmentReceivableResult != null) && adjustmentReceivableResult.Count > 0)
                {
                    this.dgSearchAccountReceivableAdjustments.RowCount = adjustmentReceivableResult.Count;

                    for (int i = 0; i < adjustmentReceivableResult.Count; i++)
                    {
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["ID"].Value = adjustmentReceivableResult[i].Id;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["AccountsReceivableAdjustmentsTypeId"].Value = adjustmentReceivableResult[i].AccountsReceivableAdjustmentsType.Id;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["AccountsReceivableAdjustmentType"].Value = adjustmentReceivableResult[i].AccountsReceivableAdjustmentsType.Name;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["AccountsReceivableAdjustmentTransactionNo"].Value = adjustmentReceivableResult[i].TransactionNo;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["AccountsReceivableAdjustmentTransactionDate"].Value = adjustmentReceivableResult[i].TransactionDate.Value.ToShortDateString();
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["CollectionId"].Value = adjustmentReceivableResult[i].Collection.Id;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["SalesId"].Value = adjustmentReceivableResult[i].Collection.Sale.Id;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["SalesTransactionNo"].Value = adjustmentReceivableResult[i].Collection.Sale.TRANo;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["Customer"].Value = adjustmentReceivableResult[i].Collection.Sale.Customer.strName;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["CollectionTransactionNo"].Value = adjustmentReceivableResult[i].Collection.TRANo;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["IsCash"].Value = adjustmentReceivableResult[i].Collection.IsCash;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["BankAccountsId"].Value = adjustmentReceivableResult[i].Collection.Bank.Id;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["BankAccounts"].Value = adjustmentReceivableResult[i].Collection.Bank.strName;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["CheckDetails"].Value = adjustmentReceivableResult[i].Collection.CheckDetail;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["CollectionTotalAmount"].Value = string.Format("{0:0.00}", adjustmentReceivableResult[i].Collection.Total);
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["GLTranHeaderID"].Value = adjustmentReceivableResult[i].tblGLTranHeaders.Select(h => h.ID).FirstOrDefault();
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["Description"].Value = adjustmentReceivableResult[i].Descrpition;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["UseDefaultEntry"].Value = adjustmentReceivableResult[i].tblGLTranHeaders.Select(h => h.blnUseDefaultEntry).FirstOrDefault();
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["TotalAmount"].Value = adjustmentReceivableResult[i].TotalAmount;
                    }

                    setRowNumber(this.dgSearchAccountReceivableAdjustments);

                }
                else
                {
                    this.dgSearchAccountReceivableAdjustments.Rows.Clear();
                    this.dgSearchAccountReceivableAdjustments.Refresh();
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
                this.Index = this.dgSearchAccountReceivableAdjustments.CurrentCell.RowIndex;

                if (Index >= 0)
                {
                    this.AccountReceivableAdjustment = new AccountReceivableAdjustment
                    {
                        Id = Int32.Parse(this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["ID"].Value.ToString()),
                        AccountsReceivableAdjustmentsTypeId = Int32.Parse(this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["AccountsReceivableAdjustmentsTypeId"].Value.ToString()),
                        AccountsReceivableAdjustmentsType = new AccountsReceivableAdjustmentsType
                        {
                            Id = Int32.Parse(this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["AccountsReceivableAdjustmentsTypeId"].Value.ToString()),
                            Name = this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["AccountsReceivableAdjustmentType"].Value.ToString()
                        },
                        TransactionNo = this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["AccountsReceivableAdjustmentTransactionNo"].Value.ToString(),
                        TransactionDate = Convert.ToDateTime(this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["AccountsReceivableAdjustmentTransactionDate"].Value.ToString()),
                        CollectionId = Int32.Parse(this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["CollectionId"].Value.ToString()),
                        SalesId = Int32.Parse(this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["SalesId"].Value.ToString()),
                        Descrpition = this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["Description"].Value.ToString(),
                        TotalAmount = Convert.ToDecimal(this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["TotalAmount"].Value.ToString()),
                        Collection = new Collection
                        {
                            Id = Int32.Parse(this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["CollectionId"].Value.ToString()),
                            TRANo = this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["CollectionTransactionNo"].Value.ToString(),
                            IsCash = bool.Parse(this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["IsCash"].Value.ToString()),
                            Sale = new Sale
                            {
                                Id = Int32.Parse(this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["SalesId"].Value.ToString()),
                                TRANo = this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["SalesTransactionNo"].Value.ToString(),
                                Customer = new Customer
                                {
                                    strName = this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["Customer"].Value.ToString(),

                                }
                            },
                            Bank = new Core.Domain.Bank { 
                                Id = Int32.Parse(this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["BankAccountsId"].Value.ToString()),
                                strName = this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["BankAccounts"].Value.ToString()
                            },
                            BankId = Int32.Parse(this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["BankAccountsId"].Value.ToString()),
                            CheckDetail = this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["CheckDetails"].Value.ToString(),
                            Total = Convert.ToDecimal(this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["CollectionTotalAmount"].Value.ToString()),

                        },
                        tblGLTranHeaders = new List<tblGLTranHeader> {
                            new tblGLTranHeader {
                             ID = Int32.Parse(this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["GLTranHeaderID"].Value.ToString()),
                             blnUseDefaultEntry = bool.Parse(this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["UseDefaultEntry"].Value.ToString())
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
