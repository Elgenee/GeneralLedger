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
using MetroFramework.Controls;

namespace GeneralLedger.UserControls
{
    public partial class StockInquiry : MetroUserControl
    {
        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }
        public int IndexGrid { get; set; }
        public int ID { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductBrandName { get; set; }
        public string ProductColor { get; set; }
        public string ProductSize { get; set; }
        public string Code { get; set; }

        public StockInquiry()
        {
            InitializeComponent();
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
                    product.ProductCharacteristic = new ProductCharacteristic
                    {
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
                    product.intRemainingCount = item.intRemainingCount;

                    //product.ProductStatusID = item.ProductStatusID;
                    //product.ProductStatusName = item.ProductStatusName;
                    productsListDomain.Add(product);
                }
                //productsListDomain.Clear();
                if ((productsListDomain != null) && productsListDomain.Count > 0)
                {


                    this.dgProduct.RowCount = productsListDomain.Count;
                    //this.dgProduct.DataSource = productList;

                    //display all the data in productList to the dgProduct with the following columns
                    //id, productname, description, productcharacteristicid, productcharacteristicname, productcategoryid, productcategoryname, producttypeid, producttypename, productbrandid, productbrandname, perpiecebox, locationid, locationname, productcolorid, productcolorname, productsizeid, productsizename, productunitid, productunitname, code, productstatusid, productstatusname
                    this.dgProduct.ColumnCount = 30;
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
                    this.dgProduct.Columns[29].Name = "Total";

                    //loop through the productList and display all the data in productList to the datagridview
                    //
                    for (int i = 0; i < productsListDomain.Count; i++)
                    {

                        //display all the data in productList to the datagridview
                        Product product = productsListDomain[i];
                        var total = product.intRemainingCount.Value * product.curUnitPrice.Value;
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
                        this.dgProduct.Rows[i].Cells[28].Value = string.Format("{0:0.00}", product.curUnitPrice);
                        this.dgProduct.Rows[i].Cells[29].Value = string.Format("{0:0.00}", total);
                    }
                    setRowNumber(this.dgProduct);
                }
                else
                {
                    MessageBox.Show("No item found...");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (this.ProductId == 0 )
            {
                MessageBox.Show("Please select item first...");
                return;
            }

            StockInquiryDetails details = new StockInquiryDetails();
            details.BringToFront();
            details.TopMost = true;
            details.ProductId = this.ProductId;
            details.txtProductName.Text = this.ProductName;
            details.txtProductCategory.Text = this.ProductCategory;
            details.txtProductType.Text = ProductTypeName;
            details.txtBrand.Text = ProductBrandName;
            details.txtProductColor.Text = ProductColor;
            details.txtProductCode.Text = Code;
            details.txtProductSize.Text = ProductSize;


            DialogResult res = details.ShowDialog(this);
        }

        private void dgProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.ProductId = Convert.ToInt32(this.dgProduct.Rows[e.RowIndex].Cells[0].Value);
                this.ProductName = Convert.ToString(this.dgProduct.Rows[e.RowIndex].Cells[1].Value);
                this.ProductCategory = Convert.ToString(this.dgProduct.Rows[e.RowIndex].Cells[6].Value);
                this.ProductTypeName = Convert.ToString(this.dgProduct.Rows[e.RowIndex].Cells[8].Value);
                this.ProductBrandName = Convert.ToString(this.dgProduct.Rows[e.RowIndex].Cells[10].Value);
                this.ProductColor = Convert.ToString(this.dgProduct.Rows[e.RowIndex].Cells[15].Value);
                this.ProductSize = Convert.ToString(this.dgProduct.Rows[e.RowIndex].Cells[17].Value);
                this.Code = Convert.ToString(this.dgProduct.Rows[e.RowIndex].Cells[20].Value);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void dgProduct_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.ProductId = Convert.ToInt32(this.dgProduct.Rows[e.RowIndex].Cells[0].Value);
                this.ProductName = Convert.ToString(this.dgProduct.Rows[e.RowIndex].Cells[1].Value);
                this.ProductCategory = Convert.ToString(this.dgProduct.Rows[e.RowIndex].Cells[6].Value);
                this.ProductTypeName = Convert.ToString(this.dgProduct.Rows[e.RowIndex].Cells[8].Value);
                this.ProductBrandName = Convert.ToString(this.dgProduct.Rows[e.RowIndex].Cells[10].Value);
                this.ProductColor = Convert.ToString(this.dgProduct.Rows[e.RowIndex].Cells[15].Value);
                this.ProductSize = Convert.ToString(this.dgProduct.Rows[e.RowIndex].Cells[17].Value);
                this.Code = Convert.ToString(this.dgProduct.Rows[e.RowIndex].Cells[20].Value);

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
                this.ProductId = Convert.ToInt32(this.dgProduct.Rows[e.RowIndex].Cells[0].Value);
                this.ProductName = Convert.ToString(this.dgProduct.Rows[e.RowIndex].Cells[1].Value);
                this.ProductCategory = Convert.ToString(this.dgProduct.Rows[e.RowIndex].Cells[6].Value);
                this.ProductTypeName = Convert.ToString(this.dgProduct.Rows[e.RowIndex].Cells[8].Value);
                this.ProductBrandName = Convert.ToString(this.dgProduct.Rows[e.RowIndex].Cells[10].Value);
                this.ProductColor = Convert.ToString(this.dgProduct.Rows[e.RowIndex].Cells[15].Value);
                this.ProductSize = Convert.ToString(this.dgProduct.Rows[e.RowIndex].Cells[17].Value);
                this.Code = Convert.ToString(this.dgProduct.Rows[e.RowIndex].Cells[20].Value);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}
