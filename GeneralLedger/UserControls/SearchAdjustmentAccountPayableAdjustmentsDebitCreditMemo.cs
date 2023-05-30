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
    public partial class SearchAdjustmentAccountPayableAdjustmentsDebitCreditMemo : MetroForm
    {

        public AccountPayableAdjustment AccountPayableAdjustment { get; set; }
        public AccountsPayableAdjustmentsServices AccountsPayableAdjustmentsServices { get; set; }
        public int Index { get; set; }


        public int intIdAccountsPayableAdjustmentType { get; set; }
        public SearchAdjustmentAccountPayableAdjustmentsDebitCreditMemo()
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
                var adjustmentPayableResult = AccountsPayableAdjustmentsServices.GetAccountPayableAdjustmentsDMCM(this.txtCriteria.Text);
                if ((adjustmentPayableResult != null) && adjustmentPayableResult.Count > 0)
                {
                    this.dgSearchAccountsPayableAdjustments.RowCount = adjustmentPayableResult.Count;

                    for (int i = 0; i < adjustmentPayableResult.Count; i++)
                    {
                        this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["ID"].Value = adjustmentPayableResult[i].Id;
                        this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["AccountsPayableAdjustmentsTypeId"].Value = adjustmentPayableResult[i].AccountsPayableAdjustmentsType.Id;
                        this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["AccountsPayableAdjustmentType"].Value = adjustmentPayableResult[i].AccountsPayableAdjustmentsType.Name;
                        this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["AccountsPayableAdjustmentTransactionNo"].Value = adjustmentPayableResult[i].TransactionNo;
                        this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["AccountsPayableAdjustmentTransactionDate"].Value = adjustmentPayableResult[i].TransactionDate.Value.ToShortDateString();
                        this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["Supplier"].Value = adjustmentPayableResult[i].Supplier.strName;
                        this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["SupplierID"].Value = adjustmentPayableResult[i].Supplier.Id;
                        this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["Supplier"].Value = adjustmentPayableResult[i].Supplier.strName;
                        this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["PurchaseId"].Value = adjustmentPayableResult[i].Purchase.Id;
                        this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["PurchasePONo"].Value = adjustmentPayableResult[i].Purchase.PONo;
                        this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["PurchaseTransactionNo"].Value = adjustmentPayableResult[i].Purchase.TRANo;
                        this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["PurchaseSIDR"].Value = adjustmentPayableResult[i].Purchase.SIDR;
                        this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["PurchaseTotalAmount"].Value = adjustmentPayableResult[i].Purchase.Total;
                        this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["GLTranHeaderID"].Value = adjustmentPayableResult[i].tblGLTranHeaders.Select(h => h.ID).FirstOrDefault();
                        this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["Description"].Value = adjustmentPayableResult[i].Description;
                        this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["UseDefaultEntry"].Value = adjustmentPayableResult[i].tblGLTranHeaders.Select(h => h.blnUseDefaultEntry).FirstOrDefault();
                        this.dgSearchAccountsPayableAdjustments.Rows[i].Cells["TotalAmount"].Value = adjustmentPayableResult[i].TotalAmount;
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
                    this.AccountPayableAdjustment = new AccountPayableAdjustment
                    {
                        Id = Int32.Parse(this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["ID"].Value.ToString()),
                        AccountsPayableAdjustmentTypeId = Int32.Parse(this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["AccountsPayableAdjustmentsTypeId"].Value.ToString()),
                        AccountsPayableAdjustmentsType = new AccountsPayableAdjustmentsType
                        {
                            Id = Int32.Parse(this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["AccountsPayableAdjustmentsTypeId"].Value.ToString()),
                            Name = this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["AccountsPayableAdjustmentType"].Value.ToString()
                        },
                        TransactionNo = this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["AccountsPayableAdjustmentTransactionNo"].Value.ToString(),
                        TransactionDate = Convert.ToDateTime(this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["AccountsPayableAdjustmentTransactionDate"].Value.ToString()),
                        //PaymentId = Int32.Parse(this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["PaymentId"].Value.ToString()),
                        //PurchaseId = Int32.Parse(this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["PurchaseId"].Value.ToString()),
                        Supplier = new Supplier {
                            Id = Int32.Parse(this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["SupplierID"].Value.ToString()),
                            strName = this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["Supplier"].Value.ToString()

                        },
                        Purchase = new Purchase
                        {
                            Id = Int32.Parse(this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["PurchaseId"].Value.ToString()),
                            PONo = this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["PurchasePONo"].Value.ToString(),
                            SIDR = this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["PurchaseSIDR"].Value.ToString(),
                            TRANo = this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["PurchaseTransactionNo"].Value.ToString(),
                            Total = Convert.ToDecimal(this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["PurchaseTotalAmount"].Value.ToString()),
                            Supplier = new Supplier
                            {
                                Id = Int32.Parse(this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["SupplierID"].Value.ToString()),
                                strName = this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["Supplier"].Value.ToString()
                            }
                        },
                        Description = this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["Description"].Value.ToString(),
                        TotalAmount = Convert.ToDecimal(this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["TotalAmount"].Value.ToString()),
                        tblGLTranHeaders = new List<tblGLTranHeader> {
                            new tblGLTranHeader {
                             ID = Int32.Parse(this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["GLTranHeaderID"].Value.ToString()),
                             blnUseDefaultEntry = bool.Parse(this.dgSearchAccountsPayableAdjustments.Rows[this.Index].Cells["UseDefaultEntry"].Value.ToString())
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
