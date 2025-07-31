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
    public partial class SearchAdjustmentAccountReceivableAdjustmentsReturnSales : MetroForm
    {

        public AccountReceivableAdjustment AccountReceivableAdjustment { get; set; }
        public AccountReceivableAdjustmentsServices AccountReceivableAdjustmentsServices { get; set; }
        public int Index { get; set; }
        public SearchAdjustmentAccountReceivableAdjustmentsReturnSales()
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
                var adjustmentReceivableResult = AccountReceivableAdjustmentsServices.GetAccountReceivableAdjustmentsWithSales(this.txtCriteria.Text, 1002);
                if ((adjustmentReceivableResult != null) && adjustmentReceivableResult.Count > 0)
                {
                    this.dgSearchAccountReceivableAdjustments.RowCount = adjustmentReceivableResult.Count;

                    for (int i = 0; i < adjustmentReceivableResult.Count; i++)
                    {
                        var item = adjustmentReceivableResult[i];
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["ID"].Value = item.Id;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["AccountsReceivableAdjustmentsTypeId"].Value = item.AccountsReceivableAdjustmentsType?.Id ?? 0;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["AccountsReceivableAdjustmentType"].Value = item.AccountsReceivableAdjustmentsType?.Name ?? string.Empty;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["AccountsReceivableAdjustmentTransactionNo"].Value = item.TransactionNo ?? string.Empty;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["AccountsReceivableAdjustmentTransactionDate"].Value = item.TransactionDate?.ToShortDateString() ?? string.Empty;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["SalesId"].Value = item.Sale?.Id ?? 0;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["SalesTransactionNo"].Value = item.Sale?.TRANo ?? string.Empty;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["SalesPoNo"].Value = item.Sale?.PONo ?? string.Empty;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["Customer"].Value = item.Sale?.Customer?.strName ?? string.Empty;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["GLTranHeaderID"].Value = item.tblGLTranHeaders?.Select(h => h.ID).FirstOrDefault();
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["Description"].Value = item.Descrpition ?? string.Empty;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["UseDefaultEntry"].Value = item.tblGLTranHeaders?.Select(h => h.blnUseDefaultEntry).FirstOrDefault() ?? false;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["TotalAmount"].Value = item.TotalAmount ?? 0;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["SOPAmount"].Value = item.SOPAmount ?? 0;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["CFAmount"].Value = item.CFAmount ?? 0;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["COMMAmount"].Value = item.COMMAmount ?? 0;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["TotalInventoryAmount"].Value = item.TotalInventoryAmount ?? 0;
                        this.dgSearchAccountReceivableAdjustments.Rows[i].Cells["AdditionalDescription"].Value = string.IsNullOrEmpty(item.AdditionalDescription) ? string.Empty : item.AdditionalDescription;
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
                        SalesId = Int32.Parse(this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["SalesId"].Value.ToString()),
                        Descrpition = this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["Description"].Value.ToString(),
                        AdditionalDescription = this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["AdditionalDescription"].Value.ToString(),
                        TotalAmount = Convert.ToDecimal(this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["TotalAmount"].Value.ToString()),
                        TotalInventoryAmount = Convert.ToDecimal(this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["TotalInventoryAmount"].Value.ToString()),
                        SOPAmount = Convert.ToDecimal(this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["SOPAmount"].Value.ToString()),
                        CFAmount = Convert.ToDecimal(this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["CFAmount"].Value.ToString()),
                        COMMAmount = Convert.ToDecimal(this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["COMMAmount"].Value.ToString()),
                        Sale = new Sale {
                            Id = Int32.Parse(this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["SalesId"].Value.ToString()),
                            TRANo = this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["SalesTransactionNo"].Value.ToString(),
                            PONo = this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["SalesPoNo"].Value.ToString(),
                            Customer = new Customer
                            {
                                strName = this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["Customer"].Value.ToString()
                            },
                            //SOPAmount = Convert.ToDecimal(this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["SOPAmount"].Value.ToString()),
                            //CFAmount = Convert.ToDecimal(this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["CFAmount"].Value.ToString()),
                            //COMMAmount = Convert.ToDecimal(this.dgSearchAccountReceivableAdjustments.Rows[this.Index].Cells["COMMAmount"].Value.ToString()),
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
