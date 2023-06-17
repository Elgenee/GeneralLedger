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
using System.Globalization;

namespace GeneralLedger.UserControls
{
    public partial class EditPurchaseOrderProduct : MetroForm
    {

        public Product Product { get; set; }

        public EditPurchaseOrderProduct()
        {
            InitializeComponent();
        }

        private void EditPurchaseOrderProduct_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtProductName.Text = this.Product.ProductName;
                this.txtColor.Text = this.Product.ProductDetails[0].ProductColor.Name;
                this.txtSize.Text = this.Product.ProductDetails[0].ProductSize.Name;
                this.txtCurStock.Text = this.Product.ProductDetails[0].CurStock.ToString();
                this.txtActStock.Text = this.Product.ProductDetails[0].ActStock.ToString();
                this.txtQuantity.Text = this.Product.ProductDetails[0].Quantity.ToString();
                this.txtSubTotal.Text = this.Product.ProductDetails[0].Subtotal.ToString();
                this.txtQuantityReceived.Text = this.Product.ProductDetails[0].QuantityReceived.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            try
            {
                int intParser;
                decimal decimalParser;
                this.Product.ProductDetails[0].Quantity = int.TryParse(this.txtQuantity.Text, out intParser) ? intParser : 0;
         
                this.Product.ProductDetails[0].Subtotal = decimal.TryParse(this.txtSubTotal.Text, out decimalParser) ? decimalParser : 0;
                this.Product.ProductDetails[0].QuantityReceived = int.TryParse(this.txtQuantityReceived.Text, out intParser) ? intParser : 0;

                this.DialogResult = DialogResult.OK;

                this.Close();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error:" + ex.Message);
            }

        }
    }
}
