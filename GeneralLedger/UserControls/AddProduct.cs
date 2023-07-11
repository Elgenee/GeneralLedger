using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using GeneralLedger.Tier.BO;
using GeneralLedger.Tier.BAL;
using System.Globalization;

namespace GeneralLedger.UserControls
{
    public partial class AddProduct : MetroUserControl
    {
        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }
        public int ID { get; set; }

        public int IndexGrid { get; set; }

        public Product Product { get; set; }

        public List<SearchProductAndColorAndSize> SearchProductAndColorAndSizeList { get; set; }

        public AddProduct()
        {
            InitializeComponent();
            ProductBAL productBAL = new ProductBAL();
            var productCharacteristicList = productBAL.getProductCharacteristic();
            //this.cbCharacteristic.DataSource = productCharacteristicList;
            //this.cbCharacteristic.ValueMember = "ID";
            //this.cbCharacteristic.DisplayMember = "Name";


            var locationList = productBAL.getLocation();
            this.cbLocation.DataSource = locationList;
            this.cbLocation.ValueMember = "ID";
            this.cbLocation.DisplayMember = "Name";


            ProductCategoryBAL ProductCategoryBAL = new ProductCategoryBAL();
            List<GeneralLedger.Tier.BO.ProductCategory> productCategoryList = ProductCategoryBAL.getProductCategory();
            productCategoryList.Insert(0, new Tier.BO.ProductCategory { ID = 0, Name = string.Empty });
            this.cbCategories.DataSource = productCategoryList;
            this.cbCategories.ValueMember = "ID";
            this.cbCategories.DisplayMember =  "Name";




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

            ProductColorBAL productColorBAL = new ProductColorBAL();
            List<GeneralLedger.Tier.BO.ProductColor> ProductColorList = productColorBAL.getProductColor();
            ProductColorList.Insert(0, new Tier.BO.ProductColor { ID = 0, Name = string.Empty });
            this.cbColor.DataSource = ProductColorList;
            this.cbColor.ValueMember = "ID";
            this.cbColor.DisplayMember = "Name";


            ProductSizeBAL productSizeBAL = new ProductSizeBAL();
            List<GeneralLedger.Tier.BO.ProductSize> ProductSizeList = productSizeBAL.getProductSize();
            ProductSizeList.Insert(0, new Tier.BO.ProductSize { ID = 0, Name = string.Empty });
            this.cbSize.DataSource = ProductSizeList;
            this.cbSize.ValueMember = "ID";
            this.cbSize.DisplayMember = "Name";

            ProductUnitBAL productUnitBAL = new ProductUnitBAL();
            List<GeneralLedger.Tier.BO.ProductUnit> ProductUnitList = productUnitBAL.getProductUnit();
            ProductUnitList.Insert(0, new Tier.BO.ProductUnit { ID = 0, Name = string.Empty });
            this.cbProductUnit.DataSource = ProductUnitList;
            this.cbProductUnit.ValueMember = "ID";
            this.cbProductUnit.DisplayMember = "Name";


            PriceTypeBAL priceTypeBAL = new PriceTypeBAL();
            List<GeneralLedger.Tier.BO.PriceType> PriceTypeList = priceTypeBAL.getPriceType();
            PriceTypeList.Insert(0, new Tier.BO.PriceType { ID = 0, Name = string.Empty });
            this.cbPriceType.DataSource = PriceTypeList;
            this.cbPriceType.ValueMember = "ID";
            this.cbPriceType.DisplayMember = "Name";


            Product = new Product { ProductDetails = new List<SearchProductAndColorAndSize>() };
        }

        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }

        private void btnAddColorAndSize_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (this.ID.Equals(0))
            //    {
            //        MessageBox.Show("Please select product or save it first");
            //        return;
            //    }

            //    int intParser;
            //    decimal decimalParser;

            //    var searchProductAndColorAndSize = new SearchProductAndColorAndSize
            //    {
            //        ID = int.TryParse(this.txtProductDetailsID.Text, out intParser) ? intParser : 0,
            //        ProductID = this.ID,
            //        ProductColorID = (this.cbColor.SelectedItem == null) ? 0 : ((GeneralLedger.Tier.BO.ProductColor)this.cbColor.SelectedItem).ID,
            //        ProductSizeID = (this.cbSize.SelectedItem == null) ? 0 : ((GeneralLedger.Tier.BO.ProductSize)this.cbSize.SelectedItem).ID,
            //        ProductColor = new Tier.BO.ProductColor
            //        {
            //            ID = (this.cbColor.SelectedItem == null) ? 0 : ((GeneralLedger.Tier.BO.ProductColor)this.cbColor.SelectedItem).ID,
            //            Name = (this.cbColor.SelectedItem == null) ? string.Empty : ((GeneralLedger.Tier.BO.ProductColor)this.cbColor.SelectedItem).Name
            //        },
            //        ProductSize = new Tier.BO.ProductSize
            //        {
            //            ID = (this.cbSize.SelectedItem == null) ? 0 : ((GeneralLedger.Tier.BO.ProductSize)this.cbSize.SelectedItem).ID,
            //            Name = (this.cbSize.SelectedItem == null) ? string.Empty : ((GeneralLedger.Tier.BO.ProductSize)this.cbSize.SelectedItem).Name

            //        },
            //        Mininum = decimal.TryParse(this.txtMinimun.Text, out decimalParser) ? decimalParser : 0,
            //        Length = decimal.TryParse(this.txtLength.Text, out decimalParser) ? decimalParser : 0,
            //        Width = decimal.TryParse(this.txtWidth.Text, out decimalParser) ? decimalParser : 0,
            //        Height = decimal.TryParse(this.txtHeight.Text, out decimalParser) ? decimalParser : 0,
            //        //Cost = decimal.TryParse(this.txtCost.Text, out decimalParser) ? decimalParser : 0,
            //        //Retail = decimal.TryParse(this.txtRetail.Text, out decimalParser) ? decimalParser : 0,
            //        //Wholesale = decimal.TryParse(this.txtWholesale.Text, out decimalParser) ? decimalParser : 0,

            //    };

            //    int productDetailsID = int.TryParse(this.txtProductDetailsID.Text, out intParser) ? intParser : 0;
            //    string TransType = (productDetailsID == 0) ? "insert" : "update";
            //    ProductBAL productBAL = new ProductBAL();
            //    string result = productBAL.ManageProductDetail(searchProductAndColorAndSize, TransType);

            //    if (result != string.Empty)
            //    {
            //        MessageBox.Show("Successfully saved");
            //        this.txtProductDetailsID.Text = result.Split(',')[0];
            //        LoadProductDetail(this.ID);
            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show("Error:" + ex.Message);
            //}
        }

      
        private void LoadProductDetail(int ProductID) {

            //try
            //{

            //    this.dgProductColorAndProductSize.Rows.Clear();
            //    this.dgProductColorAndProductSize.Refresh();

            //    ProductBAL productBAL = new ProductBAL();
            //    List<SearchProductAndColorAndSize> searchProductAndColorAndSizeList = productBAL.getProductDetails(ProductID);


            //    if (searchProductAndColorAndSizeList.Count > 0)
            //    {
            //        this.dgProductColorAndProductSize.RowCount = searchProductAndColorAndSizeList.Count;
            //        for (int i = 0; i < searchProductAndColorAndSizeList.Count; i++)
            //        {
            //            this.dgProductColorAndProductSize.Rows[i].Cells[0].Value = searchProductAndColorAndSizeList[i].ID;
            //            this.dgProductColorAndProductSize.Rows[i].Cells[1].Value = searchProductAndColorAndSizeList[i].ProductColor.Name;
            //            this.dgProductColorAndProductSize.Rows[i].Cells[2].Value = searchProductAndColorAndSizeList[i].ProductColor.ID;
            //            this.dgProductColorAndProductSize.Rows[i].Cells[3].Value = searchProductAndColorAndSizeList[i].ProductSize.Name;
            //            this.dgProductColorAndProductSize.Rows[i].Cells[4].Value = searchProductAndColorAndSizeList[i].ProductSize.ID;
            //            this.dgProductColorAndProductSize.Rows[i].Cells[5].Value = searchProductAndColorAndSizeList[i].Mininum;
            //            this.dgProductColorAndProductSize.Rows[i].Cells[6].Value = searchProductAndColorAndSizeList[i].Length;
            //            this.dgProductColorAndProductSize.Rows[i].Cells[7].Value = searchProductAndColorAndSizeList[i].Width;
            //            this.dgProductColorAndProductSize.Rows[i].Cells[8].Value = searchProductAndColorAndSizeList[i].Height;
                     
            //        }

            //        setRowNumber(this.dgProductColorAndProductSize);

            //    }

            //}
            //catch (Exception ex)
            //{
                
            //    MessageBox.Show("Error:" + ex.Message);
            //}

        }
        private void AddProduct_Load(object sender, EventArgs e)
        {
            ProductColorBAL ProductColorBAL = new ProductColorBAL();
            List<GeneralLedger.Tier.BO.ProductColor> ProductColorList = ProductColorBAL.getProductColor();

            ProductColorList.Insert(0, new Tier.BO.ProductColor { ID = 0, Name = string.Empty });
            //this.cbColor.DataSource = ProductColorList;
            //this.cbColor.ValueMember = "ID";
            //this.cbColor.DisplayMember = "Name";

            ProductSizeBAL ProductSizeBAL = new ProductSizeBAL();
            List<GeneralLedger.Tier.BO.ProductSize> ProductSizeList = ProductSizeBAL.getProductSize();
            //ProductSizeList.Insert(0, new Tier.BO.ProductSize { ID = 0, Name = string.Empty });
            //this.cbSize.DataSource = ProductSizeList;
            //this.cbSize.ValueMember = "ID";
            //this.cbSize.DisplayMember = "Name";
        }

        private void cbBookType_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cbCharacteristic_SelectedValueChanged(object sender, EventArgs e)
        {
            //string selectedValue = (this.cbCharacteristic.SelectedItem == null) ? string.Empty : ((ProductCharacteristic)this.cbCharacteristic.SelectedItem).Name;
            //this.dgProductColorAndProductSize.Columns[0].Visible = true;
            //this.dgProductColorAndProductSize.Columns[1].Visible = true;
            //this.dgProductColorAndProductSize.Columns[2].Visible = true;
            //this.dgProductColorAndProductSize.Columns[3].Visible = true;
            //this.dgProductColorAndProductSize.Columns[4].Visible = true;
            //this.dgProductColorAndProductSize.Columns[5].Visible = true;
            //this.dgProductColorAndProductSize.Columns[6].Visible = true;
            //this.dgProductColorAndProductSize.Columns[7].Visible = true;
            //this.dgProductColorAndProductSize.Columns[8].Visible = true;
            ////this.dgProductColorAndProductSize.Columns[9].Visible = true;
            ////this.dgProductColorAndProductSize.Columns[13].Visible = true;
            //this.dgProductColorAndProductSize.Rows.Clear();

            //if (selectedValue.ToUpper().Equals("WITH COLOR AND SIZE"))
            //{

            //    this.dgProductColorAndProductSize.Columns[0].Visible = false;
            //    this.dgProductColorAndProductSize.Columns[2].Visible = false;
            //    this.dgProductColorAndProductSize.Columns[4].Visible = false;
            //    this.cbSize.Enabled = true;
            //    this.cbColor.Enabled = true;

            //}

            //if (selectedValue.ToUpper().Equals("WITH COLOR"))
            //{

            //    this.dgProductColorAndProductSize.Columns[0].Visible = false;
            //    this.dgProductColorAndProductSize.Columns[2].Visible = false;
            //    this.dgProductColorAndProductSize.Columns[3].Visible = false;
            //    this.dgProductColorAndProductSize.Columns[4].Visible = false;
            //    this.cbSize.Enabled = false;
            //}


            //if (selectedValue.ToUpper().Equals("WITH SIZE"))
            //{

            //    this.dgProductColorAndProductSize.Columns[0].Visible = false;
            //    this.dgProductColorAndProductSize.Columns[1].Visible = false;
            //    this.dgProductColorAndProductSize.Columns[2].Visible = false;
            //    this.dgProductColorAndProductSize.Columns[4].Visible = false;
            //    this.cbColor.Enabled = false;
            //}

        }

        private void dgProductColorAndProductSize_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int intParser;
                double doubleParser;
                if (e.RowIndex >= 0)
                {

                    //this.txtProductDetailsID.Text = dgProductColorAndProductSize.Rows[e.RowIndex].Cells[0].Value.ToString();
                    //this.cbColor.SelectedValue = Convert.ToInt32(dgProductColorAndProductSize.Rows[e.RowIndex].Cells[2].Value.ToString());
                    //this.cbSize.SelectedValue = Convert.ToInt32(dgProductColorAndProductSize.Rows[e.RowIndex].Cells[4].Value.ToString());
                    //this.txtMinimun.Value = Int32.TryParse(dgProductColorAndProductSize.Rows[e.RowIndex].Cells[5].Value.ToString(), out intParser) ? intParser : 0;
                    //this.txtLength.Value = Int32.TryParse(dgProductColorAndProductSize.Rows[e.RowIndex].Cells[6].Value.ToString(), out intParser) ? intParser : 0;
                    //this.txtWidth.Value =  Int32.TryParse(dgProductColorAndProductSize.Rows[e.RowIndex].Cells[7].Value.ToString(), out intParser) ? intParser : 0;
                    //this.txtHeight.Value = Int32.TryParse(dgProductColorAndProductSize.Rows[e.RowIndex].Cells[8].Value.ToString(), out intParser) ? intParser : 0;
                   
                }
               
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnDeleteColorSize_Click(object sender, EventArgs e)
        {
            //try
            //{
                
            //    if (this.ID.Equals(0))
            //    {
            //        MessageBox.Show("Please select product or save it first");
            //        return;
            //    }

            //    int intParser;
            //    decimal decimalParser;

            //    var searchProductAndColorAndSize = new SearchProductAndColorAndSize
            //    {
            //        ID = int.TryParse(this.txtProductDetailsID.Text, out intParser) ? intParser : 0,
            //        ProductID = this.ID,
            //        ProductColorID = (this.cbColor.SelectedItem == null) ? 0 : ((GeneralLedger.Tier.BO.ProductColor)this.cbColor.SelectedItem).ID,
            //        ProductSizeID = (this.cbSize.SelectedItem == null) ? 0 : ((GeneralLedger.Tier.BO.ProductSize)this.cbSize.SelectedItem).ID,
            //        ProductColor = new Tier.BO.ProductColor
            //        {
            //            ID = (this.cbColor.SelectedItem == null) ? 0 : ((GeneralLedger.Tier.BO.ProductColor)this.cbColor.SelectedItem).ID,
            //            Name = (this.cbColor.SelectedItem == null) ? string.Empty : ((GeneralLedger.Tier.BO.ProductColor)this.cbColor.SelectedItem).Name
            //        },
            //        ProductSize = new Tier.BO.ProductSize
            //        {
            //            ID = (this.cbSize.SelectedItem == null) ? 0 : ((GeneralLedger.Tier.BO.ProductSize)this.cbSize.SelectedItem).ID,
            //            Name = (this.cbSize.SelectedItem == null) ? string.Empty : ((GeneralLedger.Tier.BO.ProductSize)this.cbSize.SelectedItem).Name

            //        },
            //        Mininum = decimal.TryParse(this.txtMinimun.Text, out decimalParser) ? decimalParser : 0,
            //        Length = decimal.TryParse(this.txtLength.Text, out decimalParser) ? decimalParser : 0,
            //        Width = decimal.TryParse(this.txtWidth.Text, out decimalParser) ? decimalParser : 0,
            //        Height = decimal.TryParse(this.txtHeight.Text, out decimalParser) ? decimalParser : 0,

            //    };

            //    int productDetailsID = int.TryParse(this.txtProductDetailsID.Text, out intParser) ? intParser : 0;
            //    string TransType ="delete";
            //    ProductBAL productBAL = new ProductBAL();
            //    string result = productBAL.ManageProductDetail(searchProductAndColorAndSize, TransType);

            //    if (result != string.Empty)
            //    {
            //        this.txtProductDetailsID.Text = result.Split(',')[0];
            //        this.txtMinimun.Text = string.Empty;
            //        this.txtLength.Text = string.Empty;
            //        this.txtWidth.Text = string.Empty;
            //        this.txtHeight.Text = string.Empty;
            //        LoadProductDetail(this.ID);
            //        MessageBox.Show("Successfully deleted");
            //    }
        

            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show("Error:" + ex.Message);
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
        

            try
            {
                int intParser;
                decimal decimalParser;
                //for (int i = 0; i < dgProductColorAndProductSize.Rows.Count; i++)
                //{

                //    var searchProductAndColorAndSize = new SearchProductAndColorAndSize {
                //         ID = int.TryParse(this.dgProductColorAndProductSize.Rows[i].Cells[0].Value.ToString() , out intParser) ? intParser : 0,
                //         ProductColorID = int.TryParse(this.dgProductColorAndProductSize.Rows[i].Cells[2].Value.ToString(), out intParser) ? intParser : 0,
                //         ProductSizeID = int.TryParse(this.dgProductColorAndProductSize.Rows[i].Cells[4].Value.ToString(), out intParser) ? intParser : 0,
                //         ProductColor = new Tier.BO.ProductColor
                //         {
                //             ID = int.TryParse(this.dgProductColorAndProductSize.Rows[i].Cells[2].Value.ToString(), out intParser) ? intParser : 0,
                //             Name = this.dgProductColorAndProductSize.Rows[i].Cells[1].Value.ToString()
                //         },
                //         ProductSize = new Tier.BO.ProductSize {
                //             ID = int.TryParse(this.dgProductColorAndProductSize.Rows[i].Cells[4].Value.ToString(), out intParser) ? intParser : 0,
                //             Name = this.dgProductColorAndProductSize.Rows[i].Cells[3].Value.ToString()

                //         },
                //          Mininum = decimal.TryParse(this.dgProductColorAndProductSize.Rows[i].Cells[4].Value.ToString(), out decimalParser) ? decimalParser : 0,
                //          Length = decimal.TryParse(this.dgProductColorAndProductSize.Rows[i].Cells[5].Value.ToString(), out decimalParser) ? decimalParser : 0,
                //          Width = decimal.TryParse(this.dgProductColorAndProductSize.Rows[i].Cells[6].Value.ToString(), out decimalParser) ? decimalParser : 0,
                //          Height = decimal.TryParse(this.dgProductColorAndProductSize.Rows[i].Cells[7].Value.ToString(), out decimalParser) ? decimalParser : 0,
                //          Cost = decimal.TryParse(this.dgProductColorAndProductSize.Rows[i].Cells[8].Value.ToString(), out decimalParser) ? decimalParser : 0,
                //          Retail = decimal.TryParse(this.dgProductColorAndProductSize.Rows[i].Cells[9].Value.ToString(), out decimalParser) ? decimalParser : 0,
                //          Wholesale = decimal.TryParse(this.dgProductColorAndProductSize.Rows[i].Cells[10].Value.ToString(), out decimalParser) ? decimalParser : 0,
                //    };

                //    Product.ProductDetails.Add(searchProductAndColorAndSize);
                //}

                string TransType = (this.ID == 0) ? "insert" : "update";
                //int LoanPaymentMethodTypeID = (this.cbPaymentType.SelectedItem == null) ? 0 : ((LoanPaymentMethodType)this.cbPaymentType.SelectedItem).ID;
                Product.ID = this.ID;
                Product.ProductName = this.txtProductName.Text;
                Product.Description = this.txtDescription.Text;
                //Product.PerPieceBox = decimal.TryParse(this.txtPerPiecePerBox.Text, out decimalParser) ? decimalParser : 0;
                //Product.ProductCharacteristicID = (this.cbCharacteristic.SelectedItem == null) ? 0 : ((Tier.BO.ProductCharacteristic)this.cbCharacteristic.SelectedItem).ID;
                Product.ProductCategoryID = (this.cbCategories.SelectedItem == null) ? 0 : ((Tier.BO.ProductCategory)this.cbCategories.SelectedItem).ID;
                Product.ProductTypeID = (this.cbProductTypes.SelectedItem == null) ? 0 : ((Tier.BO.ProductType)this.cbProductTypes.SelectedItem).ID;
                Product.ProductBrandID = (this.cbProductBrand.SelectedItem == null) ? 0 : ((Tier.BO.ProductBrand)this.cbProductBrand.SelectedItem).ID;
                Product.LocationID = 1;
                Product.strCode = this.txtCode.Text;
                Product.UnitPrice = decimal.TryParse(this.txtUnitPrice.Text, out decimalParser) ? decimalParser : 0;
                Product.strPR = this.txtPR.Text;
                Product.strPCD = this.txtPCD.Text;
                Product.strMFLM = this.txtMFLM.Text;
                Product.strOffsetCenterBase = this.txtOffsetCenterBore.Text;
                Product.strOrigin = this.txtOrigin.Text;
                Product.strPattern = this.txtPattern.Text;
                //Product.ProductCharacteristic = new ProductCharacteristic
                //{
                //    ID = (this.cbCharacteristic.SelectedItem == null) ? 0 : ((Tier.BO.ProductCharacteristic)this.cbCharacteristic.SelectedItem).ID,
                //    Name = (this.cbCharacteristic.SelectedItem == null) ? string.Empty : ((Tier.BO.ProductCharacteristic)this.cbCharacteristic.SelectedItem).Name

                //};

                Product.ProductCategory = new Tier.BO.ProductCategory
                {
                    ID = (this.cbCategories.SelectedItem == null) ? 0 : ((Tier.BO.ProductCategory)this.cbCategories.SelectedItem).ID,
                    Name = (this.cbCategories.SelectedItem == null) ? string.Empty : ((Tier.BO.ProductCategory)this.cbCategories.SelectedItem).Name
                };


                Product.ProductType = new Tier.BO.ProductType
                {
                    ID = (this.cbProductTypes.SelectedItem == null) ? 0 : ((Tier.BO.ProductType)this.cbProductTypes.SelectedItem).ID,
                    Name = (this.cbProductTypes.SelectedItem == null) ? string.Empty : ((Tier.BO.ProductType)this.cbProductTypes.SelectedItem).Name

                };


                Product.ProductBrand = new Tier.BO.ProductBrand {
                    ID = (this.cbProductBrand.SelectedItem == null) ? 0 : ((Tier.BO.ProductBrand)this.cbProductBrand.SelectedItem).ID,
                    Name = (this.cbProductBrand.SelectedItem == null) ? string.Empty : ((Tier.BO.ProductBrand)this.cbProductBrand.SelectedItem).Name
                };

                Product.ProductColor = new Tier.BO.ProductColor
                {
                    ID = (this.cbColor.SelectedItem == null) ? 0 : ((Tier.BO.ProductColor)this.cbColor.SelectedItem).ID,
                    Name = (this.cbColor.SelectedItem == null) ? string.Empty : ((Tier.BO.ProductColor)this.cbColor.SelectedItem).Name
                };

                Product.ProductSize = new Tier.BO.ProductSize
                {
                    ID = (this.cbSize.SelectedItem == null) ? 0 : ((Tier.BO.ProductSize)this.cbSize.SelectedItem).ID,
                    Name = (this.cbSize.SelectedItem == null) ? string.Empty : ((Tier.BO.ProductSize)this.cbSize.SelectedItem).Name
                };

                Product.ProductUnit = new Tier.BO.ProductUnit
                {
                    ID = (this.cbProductUnit.SelectedItem == null) ? 0 : ((Tier.BO.ProductUnit)this.cbProductUnit.SelectedItem).ID,
                    Name = (this.cbProductUnit.SelectedItem == null) ? string.Empty : ((Tier.BO.ProductUnit)this.cbProductUnit.SelectedItem).Name
                };

                Product.Location = new Tier.BO.Location
                {
                    ID = (this.cbLocation.SelectedItem == null) ? 0 : ((Tier.BO.Location)this.cbLocation.SelectedItem).ID,
                    Name = (this.cbLocation.SelectedItem == null) ? string.Empty : ((Tier.BO.Location)this.cbLocation.SelectedItem).Name
                };

                Product.PriceType = new Tier.BO.PriceType
                {
                    ID = (this.cbPriceType.SelectedItem == null) ? 0 : ((Tier.BO.PriceType)this.cbPriceType.SelectedItem).ID,
                    Name = (this.cbPriceType.SelectedItem == null) ? string.Empty : ((Tier.BO.PriceType)this.cbPriceType.SelectedItem).Name
                };

                ProductBAL productBAL = new ProductBAL();
                string result =  productBAL.Manage(Product, TransType);
                if (result != string.Empty)
                {
                    this.ID = Convert.ToInt32(result.Split(',')[0]);
                    this.txtID.Text = this.ID.ToString();
                    //this.cbCharacteristic.Enabled = false;
                    MessageBox.Show("Successfully saved");
                   // return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {


            int intParser;
            decimal decimalParser;

            try
            {

                //for (int i = 0; i < dgProductColorAndProductSize.Rows.Count; i++)
                //{

                //    var searchProductAndColorAndSize = new SearchProductAndColorAndSize
                //    {
                //        ID = int.TryParse(this.dgProductColorAndProductSize.Rows[i].Cells[0].Value.ToString(), out intParser) ? intParser : 0,
                //        ProductColorID = int.TryParse(this.dgProductColorAndProductSize.Rows[i].Cells[2].Value.ToString(), out intParser) ? intParser : 0,
                //        ProductSizeID = int.TryParse(this.dgProductColorAndProductSize.Rows[i].Cells[4].Value.ToString(), out intParser) ? intParser : 0,
                //        ProductColor = new Tier.BO.ProductColor
                //        {
                //            ID = int.TryParse(this.dgProductColorAndProductSize.Rows[i].Cells[2].Value.ToString(), out intParser) ? intParser : 0,
                //            Name = this.dgProductColorAndProductSize.Rows[i].Cells[1].Value.ToString()
                //        },
                //        ProductSize = new Tier.BO.ProductSize
                //        {
                //            ID = int.TryParse(this.dgProductColorAndProductSize.Rows[i].Cells[4].Value.ToString(), out intParser) ? intParser : 0,
                //            Name = this.dgProductColorAndProductSize.Rows[i].Cells[3].Value.ToString()

                //        },
                //        Mininum = decimal.TryParse(this.dgProductColorAndProductSize.Rows[i].Cells[4].Value.ToString(), out decimalParser) ? decimalParser : 0,
                //        Length = decimal.TryParse(this.dgProductColorAndProductSize.Rows[i].Cells[5].Value.ToString(), out decimalParser) ? decimalParser : 0,
                //        Width = decimal.TryParse(this.dgProductColorAndProductSize.Rows[i].Cells[6].Value.ToString(), out decimalParser) ? decimalParser : 0,
                //        Height = decimal.TryParse(this.dgProductColorAndProductSize.Rows[i].Cells[7].Value.ToString(), out decimalParser) ? decimalParser : 0,
                //        Cost = decimal.TryParse(this.dgProductColorAndProductSize.Rows[i].Cells[8].Value.ToString(), out decimalParser) ? decimalParser : 0,
                //        Retail = decimal.TryParse(this.dgProductColorAndProductSize.Rows[i].Cells[9].Value.ToString(), out decimalParser) ? decimalParser : 0,
                //        Wholesale = decimal.TryParse(this.dgProductColorAndProductSize.Rows[i].Cells[10].Value.ToString(), out decimalParser) ? decimalParser : 0,
                //    };

                //    Product.ProductDetails.Add(searchProductAndColorAndSize);
                //}

                string TransType = "delete";
                //int LoanPaymentMethodTypeID = (this.cbPaymentType.SelectedItem == null) ? 0 : ((LoanPaymentMethodType)this.cbPaymentType.SelectedItem).ID;
                Product.ID = this.ID;
                Product.ProductName = this.txtProductName.Text;
                Product.Description = this.txtDescription.Text;
                //Product.PerPieceBox = decimal.TryParse(this.txtPerPiecePerBox.Text, out decimalParser) ? decimalParser : 0;
          
                Product.ProductCategoryID = (this.cbCategories.SelectedItem == null) ? 0 : ((Tier.BO.ProductCategory)this.cbCategories.SelectedItem).ID;
                Product.ProductTypeID = (this.cbProductTypes.SelectedItem == null) ? 0 : ((Tier.BO.ProductType)this.cbProductTypes.SelectedItem).ID;
                Product.ProductBrandID = (this.cbProductBrand.SelectedItem == null) ? 0 : ((Tier.BO.ProductBrand)this.cbProductBrand.SelectedItem).ID;


                Product.ProductCategory = new Tier.BO.ProductCategory
                {
                    ID = (this.cbCategories.SelectedItem == null) ? 0 : ((Tier.BO.ProductCategory)this.cbCategories.SelectedItem).ID,
                    Name = (this.cbCategories.SelectedItem == null) ? string.Empty : ((Tier.BO.ProductCategory)this.cbCategories.SelectedItem).Name
                };


                Product.ProductType = new Tier.BO.ProductType
                {
                    ID = (this.cbProductTypes.SelectedItem == null) ? 0 : ((Tier.BO.ProductType)this.cbProductTypes.SelectedItem).ID,
                    Name = (this.cbProductTypes.SelectedItem == null) ? string.Empty : ((Tier.BO.ProductType)this.cbProductTypes.SelectedItem).Name

                };


                Product.ProductBrand = new Tier.BO.ProductBrand
                {
                    ID = (this.cbProductBrand.SelectedItem == null) ? 0 : ((Tier.BO.ProductBrand)this.cbProductBrand.SelectedItem).ID,
                    Name = (this.cbProductBrand.SelectedItem == null) ? string.Empty : ((Tier.BO.ProductBrand)this.cbProductBrand.SelectedItem).Name
                };


                ProductBAL productBAL = new ProductBAL();
                string result = productBAL.Manage(Product, TransType);
                if (result != string.Empty)
                {
                    this.ID = Convert.ToInt32(result.Split(',')[0]);
                    this.txtID.Text = this.ID.ToString();
                    MessageBox.Show("Successfully deleted");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnFindProduct_Click(object sender, EventArgs e)
        {
            try
            {               
                SearchProduct sp = new SearchProduct();
                sp.BringToFront();
                sp.TopMost = true;
                DialogResult res = sp.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    this.ID = sp.Product.ID;
                    this.txtID.Text = this.ID.ToString();
                    this.txtProductName.Text = sp.Product.ProductName;
                    this.txtDescription.Text = sp.Product.Description;
                  
                    this.cbCategories.SelectedValue = sp.Product.ProductCategory.ID;
                    this.cbProductTypes.SelectedValue = sp.Product.ProductType.ID;
                    this.cbProductBrand.SelectedValue = sp.Product.ProductBrand.ID;
                    //this.txtPerPiecePerBox.Text = sp.Product.PerPieceBox.ToString();
                    this.cbLocation.SelectedValue = sp.Product.Location.ID;

                    //LoadProductDetail(this.ID);


                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void metroLabel12_Click(object sender, EventArgs e)
        {

        }

        private void ClearColorAndSize_Click(object sender, EventArgs e)
        {
            //this.txtProductDetailsID.Text = string.Empty;
            //this.txtMinimun.Text = string.Empty;
            //this.txtLength.Text = string.Empty;
            //this.txtWidth.Text = string.Empty;
            //this.txtHeight.Text = string.Empty;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ID = 0;
            this.txtID.Text = this.ID.ToString();
            this.txtProductName.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
         

            LoadProductDetail(0);
        }

        private void btnDeleteColorSize_Click_1(object sender, EventArgs e)
        {
            //try
            //{
            //    if (this.ID.Equals(0))
            //    {
            //        MessageBox.Show("Please select product or save it first");
            //        return;
            //    }

            //    int intParser;
            //    decimal decimalParser;

            //    var searchProductAndColorAndSize = new SearchProductAndColorAndSize
            //    {
            //        ID = int.TryParse(this.txtProductDetailsID.Text, out intParser) ? intParser : 0,
            //        ProductID = this.ID,
            //        ProductColorID = (this.cbColor.SelectedItem == null) ? 0 : ((GeneralLedger.Tier.BO.ProductColor)this.cbColor.SelectedItem).ID,
            //        ProductSizeID = (this.cbSize.SelectedItem == null) ? 0 : ((GeneralLedger.Tier.BO.ProductSize)this.cbSize.SelectedItem).ID,
            //        ProductColor = new Tier.BO.ProductColor
            //        {
            //            ID = (this.cbColor.SelectedItem == null) ? 0 : ((GeneralLedger.Tier.BO.ProductColor)this.cbColor.SelectedItem).ID,
            //            Name = (this.cbColor.SelectedItem == null) ? string.Empty : ((GeneralLedger.Tier.BO.ProductColor)this.cbColor.SelectedItem).Name
            //        },
            //        ProductSize = new Tier.BO.ProductSize
            //        {
            //            ID = (this.cbSize.SelectedItem == null) ? 0 : ((GeneralLedger.Tier.BO.ProductSize)this.cbSize.SelectedItem).ID,
            //            Name = (this.cbSize.SelectedItem == null) ? string.Empty : ((GeneralLedger.Tier.BO.ProductSize)this.cbSize.SelectedItem).Name

            //        },
            //        Mininum = decimal.TryParse(this.txtMinimun.Text, out decimalParser) ? decimalParser : 0,
            //        Length = decimal.TryParse(this.txtLength.Text, out decimalParser) ? decimalParser : 0,
            //        Width = decimal.TryParse(this.txtWidth.Text, out decimalParser) ? decimalParser : 0,
            //        Height = decimal.TryParse(this.txtHeight.Text, out decimalParser) ? decimalParser : 0

            //    };

            //    int productDetailsID = int.TryParse(this.txtProductDetailsID.Text, out intParser) ? intParser : 0;
            //    string TransType =  "delete";
            //    ProductBAL productBAL = new ProductBAL();
            //    string result = productBAL.ManageProductDetail(searchProductAndColorAndSize, TransType);

            //    if (result != string.Empty)
            //    {
            //        MessageBox.Show("Successfully deleted");
            //        this.txtProductDetailsID.Text = result.Split(',')[0];
            //        this.txtMinimun.Text = string.Empty;
            //        this.txtLength.Text = string.Empty;
            //        this.txtWidth.Text = string.Empty;
            //        this.txtHeight.Text = string.Empty;
            //        LoadProductDetail(this.ID);
            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show("Error:" + ex.Message);
            //}
        }

        private void cbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if cbCategories value is Tires move txtOriginLocation to right
            //if (this.cbCategories.SelectedValue.ToString() == "3")
            //{
            //    this.txtOrigin.Location = new Point(656, 311);
            //}
            //else
            //{
            //    this.txtOrigin.Location = new Point(500, 100);
            //}
        }
    }
}
