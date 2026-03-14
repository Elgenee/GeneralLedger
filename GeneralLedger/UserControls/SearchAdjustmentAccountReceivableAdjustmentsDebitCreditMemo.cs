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
    public partial class SearchAdjustmentAccountReceivableAdjustmentsDebitCreditMemo : MetroForm
    {

        public AccountReceivableAdjustment AccountReceivableAdjustment { get; set; }
        public AccountReceivableAdjustmentsServices AccountReceivableAdjustmentsServices { get; set; }
        public int Index { get; set; }
        public int intIdAccountsReceivableAdjustmentsType { get; set; }
        public SearchAdjustmentAccountReceivableAdjustmentsDebitCreditMemo()
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
                var adjustmentReceivableResult = AccountReceivableAdjustmentsServices.GetAccountReceivableAdjustmentsDMCM(this.txtCriteria.Text);
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
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["CustomerId"].Value = adjustmentReceivableResult[i].Customer.Id;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["Customer"].Value = adjustmentReceivableResult[i].Customer.strName;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["SalesId"].Value = adjustmentReceivableResult[i].Sale.Id;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["SalesTransactionNo"].Value = adjustmentReceivableResult[i].Sale.TRANo;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["SalesPoNo"].Value = adjustmentReceivableResult[i].Sale.PONo;
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
                        Descrpition = this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["Description"].Value.ToString(),
                        TotalAmount = Convert.ToDecimal(this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["TotalAmount"].Value.ToString()),
                        Customer = new Customer
                        {
                            Id = Int32.Parse(this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["CustomerId"].Value.ToString()),
                            strName = this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["Customer"].Value.ToString()
                        },
                        Sale = new Sale
                        {
                            Id = Int32.Parse(this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["SalesId"].Value.ToString()),
                            TRANo = this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["SalesTransactionNo"].Value.ToString(),
                            PONo = this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["SalesPoNo"].Value.ToString(),
                            Customer = new Customer
                            {
                                strName = this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["Customer"].Value.ToString()
                            }
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
