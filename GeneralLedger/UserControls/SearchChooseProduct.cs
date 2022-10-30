using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using GeneralLedger.Tier.BAL;
using GeneralLedger.Tier.BO;


namespace GeneralLedger.UserControls
{
    public partial class SearchChooseProduct : MetroForm
    {
        public Product Product { get; set; }
        public int Index { get; set; }
        public SearchChooseProduct()
        {
            InitializeComponent();
            this.Index = -1;
        }

        private void SearchChooseProduct_Load(object sender, EventArgs e)
        {
            ProductCategoryBAL ProductCategoryBAL = new ProductCategoryBAL();
            List<GeneralLedger.Tier.BO.ProductCategory> productCategoryList = ProductCategoryBAL.getProductCategory();

            productCategoryList.Insert(0, new Tier.BO.ProductCategory { ID = 0, Name = string.Empty });
            this.cbCategories.DataSource = productCategoryList;
            this.cbCategories.ValueMember = "ID";
            this.cbCategories.DisplayMember = "Name";




            ProductBrandBAL productBrandBAL = new ProductBrandBAL();
            List<GeneralLedger.Tier.BO.ProductBrand> productBrandList = productBrandBAL.getProductBrand();
            productBrandList.Insert(0, new Tier.BO.ProductBrand { ID = 0, Name = string.Empty });
            this.cbProductBrand.DataSource = productBrandList;
            this.cbProductBrand.ValueMember = "ID";
            this.cbProductBrand.DisplayMember = "Name";


            ProductTypeBAL ProductTypeBAL = new ProductTypeBAL();
            List<GeneralLedger.Tier.BO.ProductType> ProductTypeList = ProductTypeBAL.getProductType();
            ProductTypeList.Insert(0, new Tier.BO.ProductType { ID = 0, Name = string.Empty });
            this.cbProductTypes.DataSource = ProductTypeList;
            this.cbProductTypes.ValueMember = "ID";
            this.cbProductTypes.DisplayMember = "Name";
        }

        private void dgProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Index >= 0)
                {
                    string color = this.dgProduct.Rows[Index].Cells[3].Value.ToString();
                    string size = this.dgProduct.Rows[Index].Cells[4].Value.ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
            
        }

        private void dgProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroLabel9_Click(object sender, EventArgs e)
        {

        }

        private void txtBalance_ValueChanged(object sender, EventArgs e)
        {
            computeSubTotal();
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
                int productCategoryID = (this.cbCategories.SelectedItem == null) ? 0 : ((Tier.BO.ProductCategory)this.cbCategories.SelectedItem).ID;
                int productTypeID = (this.cbProductTypes.SelectedItem == null) ? 0 : ((Tier.BO.ProductType)this.cbProductTypes.SelectedItem).ID;
                int productBrandID = (this.cbProductBrand.SelectedItem == null) ? 0 : ((Tier.BO.ProductBrand)this.cbProductBrand.SelectedItem).ID;

                PurchaseOrderBAL purOrdDAL = new PurchaseOrderBAL();
                List<GeneralLedger.Tier.BO.Product> productList = purOrdDAL.getProductSearch(this.txtCriteria.Text, productCategoryID, productBrandID, productTypeID);

                if (productList.Count > 0 )
                {
                    this.dgProduct.RowCount = productList.Count;
                    for (int i = 0; i < productList.Count; i++)
                    {
                        this.dgProduct.Rows[i].Cells["ProductDetailsID"].Value = productList[i].ProductDetails[0].ID;
                        this.dgProduct.Rows[i].Cells["ProductDetailID"].Value = productList[i].ProductDetails[0].ID;
                        this.dgProduct.Rows[i].Cells["ProductName"].Value = productList[i].ProductName;
                        this.dgProduct.Rows[i].Cells["ProductColor"].Value = productList[i].ProductDetails[0].ProductColor.Name;
                        this.dgProduct.Rows[i].Cells["ProductSize"].Value = productList[i].ProductDetails[0].ProductSize.Name;
                        this.dgProduct.Rows[i].Cells["ProductCategory"].Value = productList[i].ProductCategory.Name;
                        this.dgProduct.Rows[i].Cells["Type"].Value = productList[i].ProductType.Name;
                        this.dgProduct.Rows[i].Cells["Brand"].Value = productList[i].ProductBrand.Name;
                        this.dgProduct.Rows[i].Cells["CurStock"].Value = productList[i].ProductDetails[0].CurStock;
                        this.dgProduct.Rows[i].Cells["ActStock"].Value = productList[i].ProductDetails[0].ActStock;
                        this.dgProduct.Rows[i].Cells["Cost"].Value = productList[i].ProductDetails[0].Cost.ToString("N", CultureInfo.InvariantCulture);
                    }

                    setRowNumber(this.dgProduct);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void dgProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                double doubleParser;
                this.Index = e.RowIndex;
                this.txtProductName.Text = this.dgProduct.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                this.txtColor.Text = this.dgProduct.Rows[e.RowIndex].Cells["ProductColor"].Value.ToString();
                this.txtSize.Text = this.dgProduct.Rows[e.RowIndex].Cells["ProductSize"].Value.ToString();
                this.txtCost.Value = double.TryParse(this.dgProduct.Rows[e.RowIndex].Cells["Cost"].Value.ToString(), out doubleParser) ? doubleParser : 0;


            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void dgProduct_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                double doubleParser;
                this.Index = e.RowIndex;
                this.txtProductName.Text = this.dgProduct.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                this.txtColor.Text = this.dgProduct.Rows[e.RowIndex].Cells["ProductColor"].Value.ToString();
                this.txtSize.Text = this.dgProduct.Rows[e.RowIndex].Cells["ProductSize"].Value.ToString();
                this.txtCost.Value = double.TryParse(this.dgProduct.Rows[e.RowIndex].Cells["Cost"].Value.ToString(), out doubleParser) ? doubleParser : 0;


            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void txtQuantity_ValueChanged(object sender, EventArgs e)
        {

            computeSubTotal();
        }


        private void computeSubTotal() {
            int intParser;
            decimal decimalParser;

            int quantity = int.TryParse(this.txtQuantity.Text, out intParser) ? intParser : 0;
            decimal cost = decimal.TryParse(this.txtCost.Text, out decimalParser) ? decimalParser : 0;
            decimal result = quantity * cost;
            this.txtSubTotal.Text = result.ToString("N", CultureInfo.InvariantCulture);
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                int intParser;
                decimal decimalParser;
                if (this.Index < 0 )
                {
                    MessageBox.Show("Please Select Product");
                    return;
                }

                Product = new Product
                {
                    ProductName = this.dgProduct.Rows[this.Index].Cells["ProductName"].Value.ToString(),
                    ProductDetails = new List<SearchProductAndColorAndSize>() {
                       new SearchProductAndColorAndSize {
                           ID = int.TryParse(this.dgProduct.Rows[this.Index].Cells["ProductDetailID"].Value.ToString() , out intParser) ? intParser : 0,
                           ProductColor = new Tier.BO.ProductColor {
                                Name = this.dgProduct.Rows[this.Index].Cells["ProductColor"].Value.ToString()
                           },
                           ProductSize = new Tier.BO.ProductSize {
                               Name = this.dgProduct.Rows[this.Index].Cells["ProductSize"].Value.ToString()
                           },
                           CurStock =  int.TryParse(this.dgProduct.Rows[this.Index].Cells["CurStock"].Value.ToString() , out intParser) ? intParser : 0,
                           ActStock = int.TryParse(this.dgProduct.Rows[this.Index].Cells["ActStock"].Value.ToString() , out intParser) ? intParser : 0,
                           Cost = decimal.TryParse(this.txtCost.Text, out decimalParser) ? decimalParser : 0,
                           Quantity = int.TryParse(this.txtQuantity.Text , out intParser) ? intParser : 0,
                           QuantityReceived = int.TryParse(this.txtQuantityReceived.Text , out intParser) ? intParser : 0,
                           Subtotal =  decimal.TryParse(this.txtSubTotal.Text, out decimalParser) ? decimalParser : 0,
                        }
                    }
                };

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
