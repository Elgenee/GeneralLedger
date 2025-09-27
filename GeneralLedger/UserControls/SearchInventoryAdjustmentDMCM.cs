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
    public partial class SearchInventoryAdjustmentDMCM : MetroForm
    {
        public InventoryAdjustment InventoryAdjustment { get; set; }
        public InventoryAdjustmentServices InventoryAdjustmentServices { get; set; }
        public int Index { get; set; }


        public SearchInventoryAdjustmentDMCM()
        {
            InitializeComponent();
            InventoryAdjustmentServices = new InventoryAdjustmentServices();
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
                List<InventoryAdjustment> adjustmentResult = InventoryAdjustmentServices.GetInventoryAdjustmentWithInventoryAdjustmentType(this.txtCriteria.Text);

                if ((adjustmentResult != null) && adjustmentResult.Count > 0)
                {
                    this.dgSearchInventoryAdjustment.RowCount = adjustmentResult.Count;

                    for (int i = 0; i < adjustmentResult.Count; i++)
                    {
                        this.dgSearchInventoryAdjustment.Rows[i].Cells["ID"].Value = adjustmentResult[i].Id;
                        this.dgSearchInventoryAdjustment.Rows[i].Cells["TransactionNo"].Value = adjustmentResult[i].TransactionNo;
                        this.dgSearchInventoryAdjustment.Rows[i].Cells["TransactionDate"].Value = adjustmentResult[i].TransactionDate?.ToShortDateString();
                        this.dgSearchInventoryAdjustment.Rows[i].Cells["InventoryAdjustmentTypeID"].Value = adjustmentResult[i].InventoryAdjustmentType?.Id;
                        this.dgSearchInventoryAdjustment.Rows[i].Cells["InventoryAdjustmentType"].Value = adjustmentResult[i].InventoryAdjustmentType?.Name;
                        this.dgSearchInventoryAdjustment.Rows[i].Cells["Description"].Value = adjustmentResult[i].Description;
                        // If you have GLTranHeaderID and UseDefaultEntry, set them here
                        // this.dgSearchInventoryAdjustment.Rows[i].Cells["GLTranHeaderID"].Value = ...;
                        // this.dgSearchInventoryAdjustment.Rows[i].Cells["UseDefaultEntry"].Value = ...;
                    }

                    setRowNumber(this.dgSearchInventoryAdjustment);
                }
                else
                {
                    this.dgSearchInventoryAdjustment.Rows.Clear();
                    this.dgSearchInventoryAdjustment.Refresh();
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
                this.Index = this.dgSearchInventoryAdjustment.CurrentCell.RowIndex;

                if (Index >= 0)
                {
                    this.InventoryAdjustment = new InventoryAdjustment
                    {
                        Id = Convert.ToInt32(this.dgSearchInventoryAdjustment.Rows[this.Index].Cells["ID"].Value),
                        TransactionNo = this.dgSearchInventoryAdjustment.Rows[this.Index].Cells["TransactionNo"].Value?.ToString(),
                        TransactionDate = DateTime.TryParse(this.dgSearchInventoryAdjustment.Rows[this.Index].Cells["TransactionDate"].Value?.ToString(), out DateTime dt) ? (DateTime?)dt : null,
                        Description = this.dgSearchInventoryAdjustment.Rows[this.Index].Cells["Description"].Value?.ToString(),
                        InventoryAdjustmentTypeId = this.dgSearchInventoryAdjustment.Rows[this.Index].Cells["InventoryAdjustmentTypeID"].Value != null ? (int?)Convert.ToInt32(this.dgSearchInventoryAdjustment.Rows[this.Index].Cells["InventoryAdjustmentTypeID"].Value) : null,
                        InventoryAdjustmentType = this.dgSearchInventoryAdjustment.Rows[this.Index].Cells["InventoryAdjustmentType"].Value != null ? new InventoryAdjustmentType
                        {
                            Id = Convert.ToInt32(this.dgSearchInventoryAdjustment.Rows[this.Index].Cells["InventoryAdjustmentTypeID"].Value),
                            Name = this.dgSearchInventoryAdjustment.Rows[this.Index].Cells["InventoryAdjustmentType"].Value.ToString()
                        } : null,

                        // Set InventoryAdjustmentType if needed
                        // Set GLTranHeaderID and UseDefaultEntry if needed
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
