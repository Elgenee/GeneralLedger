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
    public partial class SearchPurchase : MetroForm
    {
        public Purchase Purchase { get; set; }
        public PurchaseServices PurchaseServices { get; set; }
        public int Index { get; set; }
        public bool IsPurchase { get; set; } = false;
        public bool IsPayment { get; set; } = false;


        public SearchPurchase()
        {
            InitializeComponent();
            PurchaseServices = new PurchaseServices();
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
  
                List<Purchase> purchaseResult;

                if (IsPayment)
                {
                    purchaseResult = PurchaseServices.GetPurchaseWithoutReturnPurchase(this.txtCriteria.Text);
                }
                else
                {
                    purchaseResult = PurchaseServices.GetPurchaseWithSupplier(this.txtCriteria.Text);
                }

                //var purchaseResult = PurchaseServices.GetPurchaseWithSupplier(this.txtCriteria.Text);

                if ((purchaseResult != null) && purchaseResult.Count > 0)
                {
                    this.dgSearchPurchase.RowCount = purchaseResult.Count;

                    for (int i = 0; i < purchaseResult.Count; i++)
                    {
                        this.dgSearchPurchase.Rows[i].Cells["ID"].Value = purchaseResult[i].Id;
                        this.dgSearchPurchase.Rows[i].Cells["PONo"].Value = purchaseResult[i].PONo;
                        this.dgSearchPurchase.Rows[i].Cells["TRANo"].Value = purchaseResult[i].TRANo;
                        this.dgSearchPurchase.Rows[i].Cells["TransactionDate"].Value = purchaseResult[i].TransactionDate.Value.ToShortDateString();
                        this.dgSearchPurchase.Rows[i].Cells["SupplierID"].Value = purchaseResult[i].intIDSupplier;
                        this.dgSearchPurchase.Rows[i].Cells["Supplier"].Value = purchaseResult[i].Supplier.strName;
                        this.dgSearchPurchase.Rows[i].Cells["SIDR"].Value = purchaseResult[i].SIDR;
                        this.dgSearchPurchase.Rows[i].Cells["Total"].Value = string.Format("{0:0.00}", purchaseResult[i].Total);
                        this.dgSearchPurchase.Rows[i].Cells["Terms"].Value = purchaseResult[i].Terms;
                        this.dgSearchPurchase.Rows[i].Cells["AdditionalDescription"].Value = purchaseResult[i].AdditionalDescription;
                        this.dgSearchPurchase.Rows[i].Cells["Description"].Value = purchaseResult[i].Description;
                        this.dgSearchPurchase.Rows[i].Cells["GLTranHeaderID"].Value = purchaseResult[i].tblGLTranHeaders.Select(h => h.ID).FirstOrDefault();
                        this.dgSearchPurchase.Rows[i].Cells["UseDefaultEntry"].Value = purchaseResult[i].tblGLTranHeaders.Select(h => h.blnUseDefaultEntry).FirstOrDefault();
                    }

                    setRowNumber(this.dgSearchPurchase);
                }
                else
                {
                    this.dgSearchPurchase.Rows.Clear();
                    this.dgSearchPurchase.Refresh();
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
                this.Index = this.dgSearchPurchase.CurrentCell.RowIndex;

                if (Index >= 0)
                {
                    this.Purchase = new Purchase {
                        Id = Int32.Parse(this.dgSearchPurchase.Rows[this.Index].Cells["ID"].Value.ToString()),
                        PONo = this.dgSearchPurchase.Rows[this.Index].Cells["PONo"].Value.ToString(),
                        TRANo = this.dgSearchPurchase.Rows[this.Index].Cells["TRANo"].Value.ToString(),
                        TransactionDate = Convert.ToDateTime(this.dgSearchPurchase.Rows[this.Index].Cells["TransactionDate"].Value.ToString()),
                        intIDSupplier = Int32.Parse(this.dgSearchPurchase.Rows[this.Index].Cells["SupplierID"].Value.ToString()),
                        Supplier = new Supplier { 
                            Id = Int32.Parse(this.dgSearchPurchase.Rows[this.Index].Cells["SupplierID"].Value.ToString()),
                            strName = this.dgSearchPurchase.Rows[this.Index].Cells["Supplier"].Value.ToString()
                        },
                        SIDR = this.dgSearchPurchase.Rows[this.Index].Cells["SIDR"].Value.ToString(),
                        Total = Convert.ToDecimal(this.dgSearchPurchase.Rows[this.Index].Cells["Total"].Value.ToString()),
                        AdditionalDescription = this.dgSearchPurchase.Rows[this.Index].Cells["AdditionalDescription"].Value.ToString(),
                        Description = this.dgSearchPurchase.Rows[this.Index].Cells["Description"].Value.ToString(),
                        tblGLTranHeaders = new List<tblGLTranHeader> {
                            new tblGLTranHeader {
                             ID = Int32.Parse(this.dgSearchPurchase.Rows[this.Index].Cells["GLTranHeaderID"].Value.ToString()),
                             blnUseDefaultEntry = bool.Parse(this.dgSearchPurchase.Rows[this.Index].Cells["UseDefaultEntry"].Value.ToString())
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
