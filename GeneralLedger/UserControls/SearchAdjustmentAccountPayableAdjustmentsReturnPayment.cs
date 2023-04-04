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
    public partial class SearchAdjustmentAccountPayableAdjustmentsReturnPayment : MetroForm
    {

        public AccountPayableAdjustment AccountPayableAdjustment { get; set; }
        public AccountsPayableAdjustmentsServices AccountsPayableAdjustmentsServices { get; set; }
        public int Index { get; set; }
        public SearchAdjustmentAccountPayableAdjustmentsReturnPayment()
        {
            InitializeComponent();
            AccountPayableAdjustment = new AccountPayableAdjustment();
            AccountsPayableAdjustmentsServices = new AccountsPayableAdjustmentsServices();
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
                var adjustmentPayableResult = AccountsPayableAdjustmentsServices.GetAccountPayableAdjustmentsWithPaymentPurchases(this.txtCriteria.Text, 1);
                if ((adjustmentPayableResult != null) && adjustmentPayableResult.Count > 0)
                {
                    this.dgSearchAccountsPayableAdjustments.RowCount = adjustmentPayableResult.Count;

                    for (int i = 0; i < adjustmentPayableResult.Count; i++)
                    {
                        this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["ID"].Value = adjustmentPayableResult[i].Id;
                        //this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["AccountsReceivableAdjustmentsTypeId"].Value = adjustmentPayableResult[i].AccountsReceivableAdjustmentsType.Id;
                        //this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["AccountsReceivableAdjustmentType"].Value = adjustmentPayableResult[i].AccountsReceivableAdjustmentsType.Name;
                        //this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["AccountsReceivableAdjustmentTransactionNo"].Value = adjustmentPayableResult[i].TransactionNo;
                        //this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["AccountsReceivableAdjustmentTransactionDate"].Value = adjustmentPayableResult[i].TransactionDate.Value.ToShortDateString();
                        //this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["CollectionId"].Value = adjustmentReceivableResult[i].Collection.Id;
                        //this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["SalesId"].Value = adjustmentReceivableResult[i].Collection.Sale.Id;
                        //this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["SalesTransactionNo"].Value = adjustmentReceivableResult[i].Collection.Sale.TRANo;
                        //this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["Customer"].Value = adjustmentReceivableResult[i].Collection.Sale.Customer.strName;
                        //this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["CollectionTransactionNo"].Value = adjustmentReceivableResult[i].Collection.TRANo;
                        //this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["IsCash"].Value = adjustmentReceivableResult[i].Collection.IsCash;
                        //this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["BankAccountsId"].Value = adjustmentReceivableResult[i].Collection.Bank.Id;
                        //this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["BankAccounts"].Value = adjustmentReceivableResult[i].Collection.Bank.strName;
                        //this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["CheckDetails"].Value = adjustmentReceivableResult[i].Collection.CheckDetail;
                        //this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["CollectionTotalAmount"].Value = string.Format("{0:0.00}", adjustmentReceivableResult[i].Collection.Total);
                        //this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["GLTranHeaderID"].Value = adjustmentReceivableResult[i].tblGLTranHeaders.Select(h => h.ID).FirstOrDefault();
                        //this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["Description"].Value = adjustmentReceivableResult[i].Descrpition;
                        //this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["UseDefaultEntry"].Value = adjustmentReceivableResult[i].tblGLTranHeaders.Select(h => h.blnUseDefaultEntry).FirstOrDefault();
                        //this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["TotalAmount"].Value = adjustmentReceivableResult[i].TotalAmount;
                    }

                    setRowNumber(this.dgSearchAccountsPayableAdjustments);

                }
                else
                {
                    this.dgSearchAccountsPayableAdjustments.Rows.Clear();
                    this.dgSearchAccountsPayableAdjustments.Refresh();
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
                this.Index = this.dgSearchAccountsPayableAdjustments.CurrentCell.RowIndex;

                if (Index >= 0)
                {
                    //this.AccountPayableAdjustment = new AccountReceivableAdjustment
                    //{
                    //    Id = Int32.Parse(this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["ID"].Value.ToString()),
                    //    AccountsReceivableAdjustmentsTypeId = Int32.Parse(this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["AccountsReceivableAdjustmentsTypeId"].Value.ToString()),
                    //    AccountsReceivableAdjustmentsType = new AccountsReceivableAdjustmentsType
                    //    {
                    //        Id = Int32.Parse(this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["AccountsReceivableAdjustmentsTypeId"].Value.ToString()),
                    //        Name = this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["AccountsReceivableAdjustmentType"].Value.ToString()
                    //    },
                    //    TransactionNo = this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["AccountsReceivableAdjustmentTransactionNo"].Value.ToString(),
                    //    TransactionDate = Convert.ToDateTime(this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["AccountsReceivableAdjustmentTransactionDate"].Value.ToString()),
                    //    CollectionId = Int32.Parse(this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["CollectionId"].Value.ToString()),
                    //    SalesId = Int32.Parse(this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["SalesId"].Value.ToString()),
                    //    Descrpition = this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["Description"].Value.ToString(),
                    //    TotalAmount = Convert.ToDecimal(this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["TotalAmount"].Value.ToString()),
                    //    Collection = new Collection
                    //    {
                    //        Id = Int32.Parse(this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["CollectionId"].Value.ToString()),
                    //        TRANo = this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["CollectionTransactionNo"].Value.ToString(),
                    //        IsCash = bool.Parse(this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["IsCash"].Value.ToString()),
                    //        Sale = new Sale
                    //        {
                    //            Id = Int32.Parse(this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["SalesId"].Value.ToString()),
                    //            TRANo = this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["SalesTransactionNo"].Value.ToString(),
                    //            Customer = new Customer
                    //            {
                    //                strName = this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["Customer"].Value.ToString(),

                    //            }
                    //        },
                    //        Bank = new Core.Domain.Bank { 
                    //            Id = Int32.Parse(this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["BankAccountsId"].Value.ToString()),
                    //            strName = this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["BankAccounts"].Value.ToString()
                    //        },
                    //        BankId = Int32.Parse(this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["BankAccountsId"].Value.ToString()),
                    //        CheckDetail = this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["CheckDetails"].Value.ToString(),
                    //        Total = Convert.ToDecimal(this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["CollectionTotalAmount"].Value.ToString()),

                    //    },
                    //    tblGLTranHeaders = new List<tblGLTranHeader> {
                    //        new tblGLTranHeader {
                    //         ID = Int32.Parse(this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["GLTranHeaderID"].Value.ToString()),
                    //         blnUseDefaultEntry = bool.Parse(this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["UseDefaultEntry"].Value.ToString())
                    //        }
                    //     }
                    //};
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
