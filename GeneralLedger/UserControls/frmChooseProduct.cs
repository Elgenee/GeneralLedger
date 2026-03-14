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
//using GeneralLedger.Tier.BO;
using System.Reflection;
using GeneralLedger.Core.Domain;
using DevComponents.DotNetBar.SuperGrid;

namespace GeneralLedger.UserControls
{

    public partial class frmChooseProduct : MetroForm
    {
        public Product Product { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductTotalQuantityPrice{ get; set; }
        public decimal ProductTotalUnitPrice { get; set; }
        public bool IsSales { get; set; }
        public bool IsPurchase { get; set; }

        private int currentPage = 1;
        private int pageSize = 20; // You can adjust this as needed
        private int totalItems = 0;
        private int totalPages = 1;
        private List<Product> allProducts = new List<Product>();

        public frmChooseProduct()
        {
            InitializeComponent();
            cmbPageSelector.SelectedIndexChanged += cmbPageSelector_SelectedIndexChanged;
            ProductBAL productBAL = new ProductBAL();
            var productCharacteristicList = productBAL.getProductCharacteristic();
            //this.cbCharacteristic.DataSource = productCharacteristicList;
            //this.cbCharacteristic.ValueMember = "ID";
            //this.cbCharacteristic.DisplayMember = "Name";


            //var locationList = productBAL.getLocation();
            //this.cbLocations.DataSource = locationList;
            //this.cbLocations.ValueMember = "ID";
            //this.cbLocations.DisplayMember = "Name";


            ProductCategoryBAL ProductCategoryBAL = new ProductCategoryBAL();
            List<GeneralLedger.Tier.BO.ProductCategory> productCategoryList = ProductCategoryBAL.getProductCategory();
            //productCategoryList.Insert(0, new Tier.BO.ProductCategory { ID = 0, Name = string.Empty });
            this.cbCategories.DataSource = productCategoryList;
            this.cbCategories.ValueMember = "ID";
            this.cbCategories.DisplayMember = "Name";




            ProductBrandBAL productBrandBAL = new ProductBrandBAL();
            List<GeneralLedger.Tier.BO.ProductBrand> productBrandList = productBrandBAL.getProductBrand();
            //productBrandList.Insert(0, new Tier.BO.ProductBrand { ID = 0, Name = string.Empty });
            this.cbProductBrand.DataSource = productBrandList;
            this.cbProductBrand.ValueMember = "ID";
            this.cbProductBrand.DisplayMember = "Name";


            ProductTypeBAL ProductTypeBAL = new ProductTypeBAL();
            List<GeneralLedger.Tier.BO.ProductType> ProductTypeList = ProductTypeBAL.getProductType();
            //ProductTypeList.Insert(0, new Tier.BO.ProductType { ID = 0, Name = string.Empty });
            this.cbProductTypes.DataSource = ProductTypeList;
            this.cbProductTypes.ValueMember = "ID";
            this.cbProductTypes.DisplayMember = "Name";

            ProductColorBAL productColorBAL = new ProductColorBAL();
            List<GeneralLedger.Tier.BO.ProductColor> ProductColorList = productColorBAL.getProductColor();
            //ProductColorList.Insert(0, new Tier.BO.ProductColor { ID = 0, Name = string.Empty });
            this.cbColor.DataSource = ProductColorList;
            this.cbColor.ValueMember = "ID";
            this.cbColor.DisplayMember = "Name";


            ProductSizeBAL productSizeBAL = new ProductSizeBAL();
            List<GeneralLedger.Tier.BO.ProductSize> ProductSizeList = productSizeBAL.getProductSize();
            //ProductSizeList.Insert(0, new Tier.BO.ProductSize { ID = 0, Name = string.Empty });
            this.cbSize.DataSource = ProductSizeList;
            this.cbSize.ValueMember = "ID";
            this.cbSize.DisplayMember = "Name";

            ProductUnitBAL productUnitBAL = new ProductUnitBAL();
            List<GeneralLedger.Tier.BO.ProductUnit> ProductUnitList = productUnitBAL.getProductUnit();
            // ProductUnitList.Insert(0, new Tier.BO.ProductUnit { ID = 0, Name = string.Empty });
            this.cbProductUnit.DataSource = ProductUnitList;
            this.cbProductUnit.ValueMember = "ID";
            this.cbProductUnit.DisplayMember = "Name";


            PriceTypeBAL priceTypeBAL = new PriceTypeBAL();
            List<GeneralLedger.Tier.BO.PriceType> PriceTypeList = priceTypeBAL.getPriceType();
            //PriceTypeList.Insert(0, new Tier.BO.PriceType { ID = 0, Name = string.Empty });
            this.cbPriceType.DataSource = PriceTypeList;
            this.cbPriceType.ValueMember = "ID";
            this.cbPriceType.DisplayMember = "Name";

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ProductBAL productBAL = new ProductBAL();
                var productListOld = productBAL.getProductSearch(this.txtCriteria.Text);

                //create a list of product from GeneralLedger.Core.Domain and map the data from productList to product
                List<Product> productsListDomain = new List<Product>();
                foreach (var item in productListOld)
                {
                    Product product = new Product();
                    product.Id = item.ID;
                    product.strProductName = item.ProductName;
                    product.strDescription = item.Description;
                    product.ProductCharacteristic = new ProductCharacteristic { 
                         Id = item.ProductCharacteristic.ID,
                         strName = item.ProductCharacteristic.Name
                    };
                    product.intIDProductCharacteristic = item.ProductCharacteristic.ID;

                    product.ProductCategory = new Core.Domain.ProductCategory
                    {
                         Id = item.ProductCategory.ID,
                         strName = item.ProductCategory.Name
                    };
                    product.intIDProductCategory = item.ProductCategory.ID;

                  
                    //product.ProductCategoryID = item.ProductCategoryID;
                    //product.ProductCategoryName = item.ProductCategoryName;

                    product.ProductType = new Core.Domain.ProductType
                    {
                        Id = item.ProductType.ID,
                        strName = item.ProductType.Name
                    };

                    product.intIDProductType = item.ProductType.ID;
                    //product.ProductTypeID = item.ProductTypeID;
                    //product.ProductTypeName = item.ProductTypeName;

                    product.ProductBrand = new Core.Domain.ProductBrand
                    {
                        Id = item.ProductBrand.ID,
                        strName = item.ProductBrand.Name
                    };

                    product.intIDProductBrands = item.ProductBrand.ID;

                    
                    product.ProductColor = new Core.Domain.ProductColor
                    {
                        Id = item.ProductColor.ID,
                        strName = item.ProductColor.Name
                    };

                    product.intIDColor = item.ProductColor.ID;

                    //product.ProductSizeID = item.ProductSizeID;
                    //product.ProductSizeName = item.ProductSizeName;

                    product.ProductSize = new Core.Domain.ProductSize
                    {
                        Id = item.ProductSize.ID,
                        strName = item.ProductSize.Name
                    };

                    product.intIDSize = item.ProductSize.ID;
                    //product.ProductUnitID = item.ProductUnitID;
                    //product.ProductUnitName = item.ProductUnitName;

                    product.ProductUnit = new Core.Domain.ProductUnit
                    {
                        Id = item.ProductUnit.ID,
                        strName = item.ProductUnit.Name
                    };

                    product.intIDProductUnit = item.ProductUnit.ID;
                    product.strCode = item.strCode;
                    product.strPR = item.strPR;
                    product.strPCD = item.strPCD;
                    product.strMFLM = item.strMFLM;
                    product.strPattern = item.strPattern;
                    product.strOffsetCenterBore = item.strOffsetCenterBase;
                    product.strOrigin = item.strOrigin;
                    product.intRemainingCount = item.intRemainingCount;
                    product.curUnitPrice = item.UnitPrice;
                    //product.curSellingPrice = item.SellingPrice;

     
                    //product.ProductStatusID = item.ProductStatusID;
                    //product.ProductStatusName = item.ProductStatusName;
                    productsListDomain.Add(product);
                }
                //productsListDomain.Clear();
                if ((productsListDomain != null) && productsListDomain.Count > 0)
                {

                    allProducts = productsListDomain;
                    totalItems = allProducts.Count;
                    totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
                    currentPage = 1; // Reset to first page
                    DisplayCurrentPage();



                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }


        private void DisplayCurrentPage()
        {
            if (allProducts == null || allProducts.Count == 0)
            {
                this.dgProduct.Rows.Clear();
                MessageBox.Show("No item found...");
                return;
            }

            int startIndex = (currentPage - 1) * pageSize;
            var pageItems = allProducts.Skip(startIndex).Take(pageSize).ToList();

            this.dgProduct.Rows.Clear();
            this.dgProduct.RowCount = pageItems.Count;
            this.dgProduct.ColumnCount = 29;
            this.dgProduct.Columns[0].Name = "ID";
            this.dgProduct.Columns[0].Visible = false;
            this.dgProduct.Columns[1].Name = "Product Name";
            this.dgProduct.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgProduct.Columns[2].Visible = false;
            this.dgProduct.Columns[2].Name = "Description";
            this.dgProduct.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgProduct.Columns[3].Name = "Product Characteristic ID";
            this.dgProduct.Columns[3].Visible = false;
            this.dgProduct.Columns[4].Name = "Product Characteristic Name";
            this.dgProduct.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgProduct.Columns[4].Visible = false;
            this.dgProduct.Columns[5].Name = "Product Category ID";
            this.dgProduct.Columns[5].Visible = false;
            this.dgProduct.Columns[6].Name = "Product Category Name";
            this.dgProduct.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgProduct.Columns[7].Name = "Product Type ID";
            this.dgProduct.Columns[7].Visible = false;
            this.dgProduct.Columns[8].Name = "Product Type Name";
            this.dgProduct.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgProduct.Columns[9].Name = "Product Brand ID";
            this.dgProduct.Columns[9].Visible = false;
            this.dgProduct.Columns[10].Name = "Product Brand Name";
            this.dgProduct.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgProduct.Columns[11].Name = "Per Piece Box";
            this.dgProduct.Columns[11].Visible = false;
            this.dgProduct.Columns[12].Name = "Location ID";
            this.dgProduct.Columns[12].Visible = false;
            this.dgProduct.Columns[13].Name = "Location Name";
            this.dgProduct.Columns[13].Visible = false;
            this.dgProduct.Columns[14].Name = "Product Color ID";
            this.dgProduct.Columns[14].Visible = false;
            this.dgProduct.Columns[15].Name = "Product Color Name";
            this.dgProduct.Columns[16].Name = "Product Size ID";
            this.dgProduct.Columns[16].Visible = false;
            this.dgProduct.Columns[17].Name = "Product Size Name";
            this.dgProduct.Columns[18].Name = "Product Unit ID";
            this.dgProduct.Columns[18].Visible = false;
            this.dgProduct.Columns[19].Name = "Product Unit Name";
            this.dgProduct.Columns[20].Name = "Code";
            this.dgProduct.Columns[21].Name = "PR";
            this.dgProduct.Columns[22].Name = "PCD";
            this.dgProduct.Columns[23].Name = "MFLM";
            this.dgProduct.Columns[24].Name = "Pattern";
            this.dgProduct.Columns[25].Name = "OffsetCenterBase";
            this.dgProduct.Columns[26].Name = "Origin";
            this.dgProduct.Columns[27].Name = "Remaining Count";
            this.dgProduct.Columns[28].Name = "UnitPrice";

            for (int i = 0; i < pageItems.Count; i++)
            {
                //display all the data in productList to the datagridview
                Product product = pageItems[i];
                this.dgProduct.Rows[i].Cells[0].Value = product.Id;
                this.dgProduct.Rows[i].Cells[1].Value = product.strProductName;
                this.dgProduct.Rows[i].Cells[2].Value = product.strDescription;
                this.dgProduct.Rows[i].Cells[3].Value = product.ProductCharacteristic.Id;
                this.dgProduct.Rows[i].Cells[4].Value = product.ProductCharacteristic.strName;
                this.dgProduct.Rows[i].Cells[5].Value = product.ProductCategory.Id;
                this.dgProduct.Rows[i].Cells[6].Value = product.ProductCategory.strName;
                this.dgProduct.Rows[i].Cells[7].Value = product.ProductType.Id;
                this.dgProduct.Rows[i].Cells[8].Value = product.ProductType.strName;
                this.dgProduct.Rows[i].Cells[9].Value = product.ProductBrand.Id;
                this.dgProduct.Rows[i].Cells[10].Value = product.ProductBrand.strName;
                //this.dgProduct.Rows[i].Cells[11].Value = product.PerPieceBox;
                //this.dgProduct.Rows[i].Cells[12].Value = product.Location.ID;
                //this.dgProduct.Rows[i].Cells[13].Value = product.Location.Name;
                this.dgProduct.Rows[i].Cells[14].Value = product.ProductColor.Id;
                this.dgProduct.Rows[i].Cells[15].Value = product.ProductColor.strName;
                this.dgProduct.Rows[i].Cells[16].Value = product.ProductSize.Id;
                this.dgProduct.Rows[i].Cells[17].Value = product.ProductSize.strName;
                this.dgProduct.Rows[i].Cells[18].Value = product.ProductUnit.Id;
                this.dgProduct.Rows[i].Cells[19].Value = product.ProductUnit.strName;
                this.dgProduct.Rows[i].Cells[20].Value = product.strCode;
                this.dgProduct.Rows[i].Cells[21].Value = product.strPR;
                this.dgProduct.Rows[i].Cells[22].Value = product.strPCD;
                this.dgProduct.Rows[i].Cells[23].Value = product.strMFLM;
                this.dgProduct.Rows[i].Cells[24].Value = product.strPattern;
                this.dgProduct.Rows[i].Cells[25].Value = product.strOffsetCenterBore;
                this.dgProduct.Rows[i].Cells[26].Value = product.strOrigin;
                this.dgProduct.Rows[i].Cells[27].Value = product.intRemainingCount;
                this.dgProduct.Rows[i].Cells[28].Value = Math.Round(product.curUnitPrice.Value, 2);
                // this.dgProduct.Rows[i].Cells[29].Value = Math.Round(product.curSellingPrice.Value,2);
            }
            setRowNumber(this.dgProduct);
            UpdatePageControls(); // Add this line
        }

        private void UpdatePageControls()
        {
            // Update lblPageInfo
            lblPageInfo.Text = $"Page {currentPage} of {totalPages}";

            // Populate cmbPageSelector
            cmbPageSelector.SelectedIndexChanged -= cmbPageSelector_SelectedIndexChanged;
            cmbPageSelector.Items.Clear();
            for (int i = 1; i <= totalPages; i++)
            {
                cmbPageSelector.Items.Add(i.ToString());
            }
            if (totalPages > 0)
            {
                cmbPageSelector.SelectedIndex = currentPage - 1;
            }
            cmbPageSelector.SelectedIndexChanged += cmbPageSelector_SelectedIndexChanged;
        }

        private void cmbPageSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPageSelector.SelectedIndex >= 0)
            {
                currentPage = cmbPageSelector.SelectedIndex + 1;
                DisplayCurrentPage();
            }
        }

        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        //create a function to get selected row from the datagridview and assign value to product object and return the product object
        private Product getSelectedRow(int rowIndex)
        {
            //create a product object
            Product product = new Product();
            //fix error Index was out of range. Must be non-negative and less than the size of the collection.Parameter name: index'
                //check if the datagridview has row
  
                //get the selected row
                int selectedRow = rowIndex;
                //assign value to product object
                product.Id = Convert.ToInt32(this.dgProduct.Rows[selectedRow].Cells[0].Value);
                product.strProductName = this.dgProduct.Rows[selectedRow].Cells[1].Value.ToString();
                product.strDescription = this.dgProduct.Rows[selectedRow].Cells[2].Value.ToString();

                //initialize the productCharacteristic object and assign value to it
                product.ProductCharacteristic = new ProductCharacteristic {
                     Id= Convert.ToInt32(this.dgProduct.Rows[selectedRow].Cells[3].Value),
                     strName= this.dgProduct.Rows[selectedRow].Cells[4].Value.ToString()
                };
                //product.ProductCharacteristic.ID = Convert.ToInt32(this.dgProduct.Rows[selectedRow].Cells[3].Value);
                //product.ProductCharacteristic.Name = this.dgProduct.Rows[selectedRow].Cells[4].Value.ToString();

                product.ProductCategory = new GeneralLedger.Core.Domain.ProductCategory
                {
                    Id = Convert.ToInt32(this.dgProduct.Rows[selectedRow].Cells[5].Value),
                    strName = this.dgProduct.Rows[selectedRow].Cells[6].Value.ToString()
                };


                //product.ProductCategory.ID = Convert.ToInt32(this.dgProduct.Rows[selectedRow].Cells[5].Value);
               // product.ProductCategory.Name = this.dgProduct.Rows[selectedRow].Cells[6].Value.ToString();

                product.ProductType = new GeneralLedger.Core.Domain.ProductType
                {
                    Id = Convert.ToInt32(this.dgProduct.Rows[selectedRow].Cells[7].Value),
                    strName = this.dgProduct.Rows[selectedRow].Cells[8].Value.ToString()
                };
                //product.ProductType.ID = Convert.ToInt32(this.dgProduct.Rows[selectedRow].Cells[7].Value);
                //product.ProductType.Name = this.dgProduct.Rows[selectedRow].Cells[8].Value.ToString();

                product.ProductBrand = new GeneralLedger.Core.Domain.ProductBrand
                {
                    Id = Convert.ToInt32(this.dgProduct.Rows[selectedRow].Cells[9].Value),
                    strName = this.dgProduct.Rows[selectedRow].Cells[10].Value.ToString()
                };

               // product.ProductBrand.ID = Convert.ToInt32(this.dgProduct.Rows[selectedRow].Cells[9].Value);
                //product.ProductBrand.Name = this.dgProduct.Rows[selectedRow].Cells[10].Value.ToString();
                product.intPerPiecePerBox = Convert.ToInt32(this.dgProduct.Rows[selectedRow].Cells[11].Value);

                //product.Location = new Tier.BO.Location
                //{
                //    ID = Convert.ToInt32(this.dgProduct.Rows[selectedRow].Cells[12].Value),
                //    Name = this.dgProduct.Rows[selectedRow].Cells[13].Value.ToString()
                //};
                //product.Location.ID = Convert.ToInt32(this.dgProduct.Rows[selectedRow].Cells[12].Value);
                //product.Location.Name = this.dgProduct.Rows[selectedRow].Cells[13].Value.ToString();

                product.ProductColor = new GeneralLedger.Core.Domain.ProductColor
                {
                    Id = Convert.ToInt32(this.dgProduct.Rows[selectedRow].Cells[14].Value),
                    strName = this.dgProduct.Rows[selectedRow].Cells[15].Value.ToString()
                };
                //product.ProductColor.ID = Convert.ToInt32(this.dgProduct.Rows[selectedRow].Cells[14].Value);
                //product.ProductColor.Name = this.dgProduct.Rows[selectedRow].Cells[15].Value.ToString();

                product.ProductSize = new GeneralLedger.Core.Domain.ProductSize
                {
                    Id = Convert.ToInt32(this.dgProduct.Rows[selectedRow].Cells[16].Value),
                    strName = this.dgProduct.Rows[selectedRow].Cells[17].Value.ToString()
                };
                //product.ProductSize.ID = Convert.ToInt32(this.dgProduct.Rows[selectedRow].Cells[16].Value);
                //product.ProductSize.Name = this.dgProduct.Rows[selectedRow].Cells[17].Value.ToString();

                product.ProductUnit = new GeneralLedger.Core.Domain.ProductUnit
                {
                    Id = Convert.ToInt32(this.dgProduct.Rows[selectedRow].Cells[18].Value),
                    strName = this.dgProduct.Rows[selectedRow].Cells[19].Value.ToString()
                };
                //product.ProductUnit.ID = Convert.ToInt32(this.dgProduct.Rows[selectedRow].Cells[18].Value);
                //product.ProductUnit.Name = this.dgProduct.Rows[selectedRow].Cells[19].Value.ToString();
                product.strCode = this.dgProduct.Rows[selectedRow].Cells[20].Value.ToString();
                product.strPR = this.dgProduct.Rows[selectedRow].Cells[21].Value.ToString();
                product.strPCD = this.dgProduct.Rows[selectedRow].Cells[22].Value.ToString();
                product.strMFLM = this.dgProduct.Rows[selectedRow].Cells[23].Value.ToString();
                product.strOffsetCenterBore = this.dgProduct.Rows[selectedRow].Cells[25].Value.ToString();
                product.strOrigin = this.dgProduct.Rows[selectedRow].Cells[26].Value.ToString();
                product.strPattern = this.dgProduct.Rows[selectedRow].Cells[24].Value.ToString();
                product.intRemainingCount = Convert.ToInt32(this.dgProduct.Rows[selectedRow].Cells[27].Value);
                //assign unit price to txtUnitPrice
                product.curUnitPrice = Convert.ToDecimal(this.dgProduct.Rows[selectedRow].Cells[28].Value);
                //product.curSellingPrice = Convert.ToDecimal(this.dgProduct.Rows[selectedRow].Cells[29].Value);

                //this.ProductQuantity = Convert.ToInt32(this.dgProduct.Rows[selectedRow].Cells[28].Value);
                //this.ProductTotalQuantityPrice = Convert.ToDecimal(this.dgProduct.Rows[selectedRow].Cells[29].Value);

            return product;
          
        }
      
        
    
        private void btnSelect_Click(object sender, EventArgs e)
        {

        
        }

        private void dgProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 )
                {
                    this.Product = getSelectedRow(e.RowIndex);
              
                    //assign this.Product property to the controls in the form
                    this.txtID.Text = this.Product.Id.ToString();
                    this.txtProductName.Text = this.Product.strProductName;
                    //this.txtDescription.Text = this.Product.Description;

                    //asign the value and text of the product category to cbCategory
                    this.cbCategories.SelectedValue = this.Product.ProductCategory.Id;
                    //this.cbCategories.Text = this.Product.ProductCategory.Name;

                    this.cbProductTypes.SelectedValue = this.Product.ProductType.Id;
                    // this.cbProductTypes.Text = this.Product.ProductType.Name;

                    this.cbProductBrand.SelectedValue = this.Product.ProductBrand.Id;
                    //this.cbProductBrand.Text = this.Product.ProductBrand.Name;

                    //this.cbLocations.SelectedValue = this.Product.Location.ID;
                    // this.cbLocations.Text = this.Product.Location.Name;

                    this.cbColor.SelectedValue = this.Product.ProductColor.Id;
                    //this.cbColor.Text = this.Product.ProductColor.Name;

                    this.cbSize.SelectedValue = this.Product.ProductSize.Id;
                    //this.cbSize.Text = this.Product.ProductSize.Name;

                    //this.cbProductUnit.Text = this.Product.ProductUnit.Name;
                    this.cbProductUnit.SelectedValue = this.Product.ProductUnit.Id;

                    this.txtCode.Text = this.Product.strCode;
                    this.txtPR.Text = this.Product.strPR;
                    this.txtPCD.Text = this.Product.strPCD;
                    this.txtMFLM.Text = this.Product.strMFLM;
                    this.txtPattern.Text = this.Product.strPattern;
                    this.txtOffsetCenterBore.Text = this.Product.strOffsetCenterBore;
                    this.txtOrigin.Text = this.Product.strOrigin;
                    this.txtRemainingCount.Text = this.Product.intRemainingCount.ToString();
                    this.txtUnitPrice.Text = this.Product.curUnitPrice.ToString();
                    //this.txtSellingPrice.Text = this.Product.curSellingPrice.ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void cbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbCategories.SelectedItem != null)
            {
                if (((GeneralLedger.Tier.BO.ProductCategory)this.cbCategories.SelectedItem).Name == "TIRES")
                {
                    this.lblOrigin.Visible = true;
                    this.txtOrigin.Visible = true;
                    this.lblPattern.Visible = true;
                    this.txtPattern.Visible = true;
                    this.txtPR.Visible = true;
                    this.txtPCD.Visible = false;
                    this.txtPCD.Text = string.Empty;
                    this.txtMFLM.Visible = false;
                    this.txtMFLM.Text = string.Empty;
                    this.txtOffsetCenterBore.Visible = false;
                    this.txtOffsetCenterBore.Text = string.Empty;
                    this.lblPR.Visible = true;
                    this.lblPCD.Visible = false;
                    this.lblMFLM.Visible = false;
                    this.lblOffsetCenterBore.Visible = false;


                }

                //if cbCategories value is MAGWHEELS then hide the following fields
                //pattern, origin, mflm, pr
                else if (((GeneralLedger.Tier.BO.ProductCategory)this.cbCategories.SelectedItem).Name == "MAGWHEELS")
                {
                    this.lblPCD.Visible = true;
                    this.txtPCD.Visible = true;
                    this.lblOffsetCenterBore.Visible = true;
                    this.txtOffsetCenterBore.Visible = true;

                    this.txtPR.Visible = false;
                    this.txtPR.Text = string.Empty;
                 
                    this.txtMFLM.Visible = false;
                    this.txtMFLM.Text = string.Empty;
                    this.txtPattern.Visible = false;
                    this.txtPattern.Text = string.Empty;
                
                    this.txtOrigin.Visible = false;
                    this.txtOrigin.Text = string.Empty;
                    this.lblPR.Visible = false;
                 
                    this.lblMFLM.Visible = false;
                    this.lblPattern.Visible = false;
                    this.lblOrigin.Visible = false;
             
                }

                //if cbCategories value is BATTERY then hide the following fields
                //pcd, offsetcenterbore, origin, pr, pattern, origin
                else if (((GeneralLedger.Tier.BO.ProductCategory)this.cbCategories.SelectedItem).Name == "BATTERY")
                {
                    this.txtPR.Visible = false;
                    this.txtPR.Text = string.Empty;
                    this.txtPCD.Visible = false;
                    this.txtPCD.Text = string.Empty;
                    this.txtMFLM.Visible = true;
                    this.txtPattern.Visible = false;
                    this.txtPattern.Text = string.Empty;
                    this.txtOffsetCenterBore.Visible = false;
                    this.txtOffsetCenterBore.Text = string.Empty;
                    this.txtOrigin.Visible = false;
                    this.txtOrigin.Text = string.Empty;
                    this.lblPR.Visible = false;
                    this.lblPCD.Visible = false;
                    this.lblMFLM.Visible = true;
                    this.lblPattern.Visible = false;
                    this.lblOrigin.Visible = false;
                    this.lblOffsetCenterBore.Visible = false;
                }
                else
                {
                    this.txtPR.Visible = false;
                    this.txtPR.Text = string.Empty;
                    this.txtPCD.Visible = false;
                    this.txtPCD.Text = string.Empty;
                    this.txtMFLM.Visible = false;
                    this.txtMFLM.Text = string.Empty;
                    this.txtPattern.Visible = false;
                    this.txtPattern.Text = string.Empty;
                    this.txtOffsetCenterBore.Visible = false;
                    this.txtOffsetCenterBore.Text = string.Empty;
                    this.txtOrigin.Visible = false;
                    this.txtOrigin.Text = string.Empty;
                    this.lblPR.Visible = false;
                    this.lblPCD.Visible = false;
                    this.lblMFLM.Visible = false;
                    this.lblPattern.Visible = false;
                    this.lblOrigin.Visible = false;
                    this.lblOffsetCenterBore.Visible = false;
                }

            }
        }

        private void txtQuantity_ValueChanged(object sender, EventArgs e)
        {
            var unitPrice = string.IsNullOrEmpty(this.txtQuantity.Text) ? 0 : Convert.ToDecimal(this.txtQuantity.Text);
            //var unitPrice = Convert.ToDecimal(this.txtUnitPrice.Text);
            var quantity = string.IsNullOrEmpty(this.txtQuantity.Text)? 0: Convert.ToDecimal(this.txtQuantity.Text);
            var totalPrice = unitPrice * quantity;  
            this.txtTotalPrice.Text = totalPrice.ToString();
        }

        private void cbCategories_EnabledChanged(object sender, EventArgs e)
        {
               this.ForeColor = SystemColors.ControlText;
            
        }

        private void frmChooseProduct_Load(object sender, EventArgs e)
        {

            this.metroLabel18.Visible = false;
            this.txtSellingPrice.Visible = false;
            //if (IsPurchase)
            //{
            //    this.metroLabel18.Visible = false;
            //    this.txtSellingPrice.Visible = false;
            //}

            //if (IsSales)
            //{
            //    this.metroLabel13.Visible = false;
            //    this.txtUnitPrice.Visible = false;
            //}
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Product == null || Product.Id == 0)
                {
                    MessageBox.Show("Please Select Product");
                    return;
                }


                if (IsSales)
                {
                    var remainingCount = Convert.ToInt32(this.txtRemainingCount.Value);
                    var quantity = Convert.ToInt32(this.txtQuantity.Value);

                    if (remainingCount < quantity)
                    {
                        MessageBox.Show("Remaining count is not enough");
                        return;
                    }

                }
              

                //if (IsSales)
                //{
                //    this.ProductTotalUnitPrice = string.IsNullOrEmpty(this.txtSellingPrice.Text) ? 0 : Convert.ToDecimal(this.txtSellingPrice.Text);
                //    this.ProductQuantity = string.IsNullOrEmpty(this.txtQuantity.Text) ? 0 : Convert.ToInt32(this.txtQuantity.Text);
                //    this.ProductTotalQuantityPrice = this.ProductTotalUnitPrice * this.ProductQuantity;
                //}

                //if (IsPurchase)
                //{
                //    this.ProductTotalUnitPrice = string.IsNullOrEmpty(this.txtUnitPrice.Text) ? 0 : Convert.ToDecimal(this.txtUnitPrice.Text);
                //    this.ProductQuantity = string.IsNullOrEmpty(this.txtQuantity.Text) ? 0 : Convert.ToInt32(this.txtQuantity.Text);
                //    this.ProductTotalQuantityPrice = this.ProductTotalUnitPrice * this.ProductQuantity;
                //}

                this.ProductTotalUnitPrice = string.IsNullOrEmpty(this.txtUnitPrice.Text) ? 0 : Convert.ToDecimal(this.txtUnitPrice.Text);
                this.ProductQuantity = string.IsNullOrEmpty(this.txtQuantity.Text) ? 0 : Convert.ToInt32(this.txtQuantity.Text);
                this.ProductTotalQuantityPrice = this.ProductTotalUnitPrice * this.ProductQuantity;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnClearProduct_Click(object sender, EventArgs e)
        {

        }


        private void txtUnitPrice_ValueChanged_1(object sender, EventArgs e)
        {
            var unitPrice = string.IsNullOrEmpty(this.txtUnitPrice.Text) ? 0 : Convert.ToDecimal(this.txtUnitPrice.Text);
            //var unitPrice = Convert.ToDecimal(this.txtUnitPrice.Text);
            var quantity = string.IsNullOrEmpty(this.txtQuantity.Text) ? 0 : Convert.ToInt32(this.txtQuantity.Text);
            var totalPrice = unitPrice * quantity;
            this.txtTotalPrice.Text = totalPrice.ToString();

        }

        private void txtQuantity_ValueChanged_1(object sender, EventArgs e)
        {

            var unitPrice = string.IsNullOrEmpty(this.txtUnitPrice.Text) ? 0 : Convert.ToDecimal(this.txtUnitPrice.Text);
            //var unitPrice = Convert.ToDecimal(this.txtUnitPrice.Text);
            var quantity = string.IsNullOrEmpty(this.txtQuantity.Text) ? 0 : Convert.ToInt32(this.txtQuantity.Text);
            var totalPrice = unitPrice * quantity;
            this.txtTotalPrice.Text = totalPrice.ToString();

            //if (IsPurchase)
            //{
            //    var unitPrice = string.IsNullOrEmpty(this.txtUnitPrice.Text) ? 0 : Convert.ToDecimal(this.txtUnitPrice.Text);
            //    //var unitPrice = Convert.ToDecimal(this.txtUnitPrice.Text);
            //    var quantity = string.IsNullOrEmpty(this.txtQuantity.Text) ? 0 : Convert.ToInt32(this.txtQuantity.Text);
            //    var totalPrice = unitPrice * quantity;
            //    this.txtTotalPrice.Text = totalPrice.ToString();
            //}

            //if (IsSales)
            //{
            //    var sellingPrice = string.IsNullOrEmpty(this.txtSellingPrice.Text) ? 0 : Convert.ToDecimal(this.txtSellingPrice.Text);
            //    //var unitPrice = Convert.ToDecimal(this.txtUnitPrice.Text);
            //    var quantity = string.IsNullOrEmpty(this.txtQuantity.Text) ? 0 : Convert.ToInt32(this.txtQuantity.Text);
            //    var totalPrice = sellingPrice * quantity;
            //    this.txtTotalPrice.Text = totalPrice.ToString();
            //}


        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayCurrentPage();
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                DisplayCurrentPage();
            }

        }
    }
}
