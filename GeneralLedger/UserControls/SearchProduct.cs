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


namespace GeneralLedger.UserControls
{
    public partial class SearchProduct :  MetroForm
    {

        public Product Product { get; set; }
        public SearchProduct()
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
                var productList = productBAL.getProductSearch(this.txtCriteria.Text);
               

                if ((productList != null) && productList.Count > 0)
                {
                    this.dgProduct.RowCount = productList.Count;
                    //insert data to datagridview row from productList
                    this.dgProduct.DataSource = productList;

                    //loop through the datagridview and display all the data in productList to the datagridview
                    //for (int i = 0; i < productList.Count; i++)
                    //{
                    //    //display all the data in productList to the datagridview
                    //Product product = productList[i];
                    //this.dgProduct.Rows[i].Cells[0].Value = product.ID;
                    //this.dgProduct.Rows[i].Cells[1].Value = product.ProductName;
                    //this.dgProduct.Rows[i].Cells[2].Value = product.Description;
                    //this.dgProduct.Rows[i].Cells[3].Value = product.ProductCharacteristicID;
                    //this.dgProduct.Rows[i].Cells[4].Value = product.ProductCharacteristicName;
                    //this.dgProduct.Rows[i].Cells[5].Value = product.ProductCategoryID;
                    //this.dgProduct.Rows[i].Cells[6].Value = product.ProductCategoryName;
                    //this.dgProduct.Rows[i].Cells[7].Value = product.ProductTypeID;
                    //this.dgProduct.Rows[i].Cells[8].Value = product.ProductTypeName;
                    //this.dgProduct.Rows[i].Cells[9].Value = product.ProductBrandID;
                    //this.dgProduct.Rows[i].Cells[10].Value = product.ProductBrandName;
                    //this.dgProduct.Rows[i].Cells[11].Value = product.PerPieceBox;
                    //this.dgProduct.Rows[i].Cells[12].Value = product.LocationID;
                    //this.dgProduct.Rows[i].Cells[13].Value = product.LocationName;
                    //this.dgProduct.Rows[i].Cells[14].Value = product.ProductColorID;
                    //this.dgProduct.Rows[i].Cells[15].Value = product.ProductColorName;
                    //this.dgProduct.Rows[i].Cells[16].Value = product.ProductSizeID;
                    //this.dgProduct.Rows[i].Cells[17].Value = product.ProductSizeName;
                    //this.dgProduct.Rows[i].Cells[18].Value = product.ProductPrice;
                    //this.dgProduct.Rows[i].Cells[19].Value = product.ProductCost;
                    //this.dgProduct.Rows[i].Cells[20].Value = product.ProductQuantity;
                    //this.dgProduct.Rows[i].Cells[21].Value = product.ProductReorderLevel;
                    //this.dgProduct.Rows[i].Cells[22].Value = product.ProductReorderQuantity;
                    //this.dgProduct.Rows[i].Cells[23].Value = product.ProductStatus;
                    //this.dgProduct.Rows[i].Cells[24].Value = product.ProductCreatedDate;
                    //this.dgProduct.Rows[i].Cells[25].Value = product.ProductModifiedDate;
                    //this.dgProduct.Rows[i].Cells[26].Value = product.ProductCreatedBy;
                    //this.dgProduct.Rows[i].Cells[27].Value = product.ProductModifiedBy;


                    //how to assign productlist to datagridview and assign column name to datagridview
                    //
                    //
                    //  
                    //this.dgProduct.DataSource = productList;
                    //this.dgProduct.Columns[0].HeaderText = "ID";
                    //this.dgProduct.Columns[1].HeaderText = "Product Name";
                    //this.dgProduct.Columns[2].HeaderText = "Description";
                    //this.dgProduct.Columns[3].HeaderText = "Product Characteristic ID";
                    //this.dgProduct.Columns[4].HeaderText = "Product Characteristic Name";
                    //this.dgProduct.Columns[5].HeaderText = "Product Category ID";
                    //this.dgProduct.Columns[6].HeaderText = "Product Category Name";
                    //this.dgProduct.Columns[7].HeaderText = "Product Type ID";
                    //this.dgProduct.Columns[8].HeaderText = "Product Type Name";
                    //this.dgProduct.Columns[9].HeaderText = "Product Brand ID";
                    //this.dgProduct.Columns[10].HeaderText = "Product Brand Name";
                    //this.dgProduct.Columns[11].HeaderText = "Per Piece Box";
                    //this.dgProduct.Columns[12].HeaderText = "Location ID";
                    //this.dgProduct.Columns[13].HeaderText = "Location Name";
                    //this.dgProduct.Columns[14].HeaderText = "Product Color ID";
                    //this.dgProduct.Columns[15].HeaderText = "Product Color Name";
                    //this.dgProduct.Columns[16].HeaderText = "Product Size ID";
                    //this.dgProduct.Columns[17].HeaderText = "Product Size Name";
                    //this.dgProduct.Columns[18].HeaderText = "Product Price";
                    //this.dgProduct.Columns[19].HeaderText = "Product Quantity";
                    //this.dgProduct.Columns[20].HeaderText = "Product Image";
                    //this.dgProduct.Columns[21].HeaderText = "Product Status";
                    //this.dgProduct.Columns[22].HeaderText = "Product Created By";
                    //this.dgProduct.Columns[23].HeaderText = "Product Created Date";
                    //this.dgProduct.Columns[24].HeaderText = "Product Updated By";



                    //for (int i = 0; i < productList.Count; i++)
                    //{
                    //    //display all the data in productList to the datagridview
                    //    Product product = productList[i];
                    //    this.dgProduct.Rows[i].Cells[0].Value = product.ID;
                    //    this.dgProduct.Rows[i].Cells[1].Value = product.ProductName;
                    //    this.dgProduct.Rows[i].Cells[2].Value = product.Description;
                    //    this.dgProduct.Rows[i].Cells[3].Value = product.ProductCharacteristic.ID;
                    //    this.dgProduct.Rows[i].Cells[4].Value = product.ProductCharacteristic.Name;
                    //    this.dgProduct.Rows[i].Cells[5].Value = product.ProductCategory.ID;
                    //    this.dgProduct.Rows[i].Cells[6].Value = product.ProductCategory.Name;
                    //    this.dgProduct.Rows[i].Cells[7].Value = product.ProductType.ID;
                    //    this.dgProduct.Rows[i].Cells[8].Value = product.ProductType.Name;
                    //    this.dgProduct.Rows[i].Cells[9].Value = product.ProductBrand.ID;
                    //    this.dgProduct.Rows[i].Cells[10].Value = product.ProductBrand.Name;
                    //    this.dgProduct.Rows[i].Cells[11].Value = product.PerPieceBox;
                    //    this.dgProduct.Rows[i].Cells[12].Value = product.Location.ID;
                    //    this.dgProduct.Rows[i].Cells[13].Value = product.Location.Name;
                    //    this.dgProduct.Rows[i].Cells[14].Value = product.ProductColor.ID;
                    //    this.dgProduct.Rows[i].Cells[15].Value = product.ProductColor.Name;
                    //    this.dgProduct.Rows[i].Cells[16].Value = product.ProductSize.ID;
                    //    this.dgProduct.Rows[i].Cells[17].Value = product.ProductSize.Name;
                    //    this.dgProduct.Rows[i].Cells[18].Value = product.ProductUnit.ID;
                    //    this.dgProduct.Rows[i].Cells[19].Value = product.ProductUnit.Name;
                    //    this.dgProduct.Rows[i].Cells[20].Value = product.strCode;

                    //    //this.dgProduct.Rows[i].Cells[22].Value = product.ProductStatus.Name;
                    //    //

                    //    this.dgProduct.Rows[i].Cells[0].Value = productList[i].ID;
                    //    this.dgProduct.Rows[i].Cells[1].Value = productList[i].ProductName;
                    //    this.dgProduct.Rows[i].Cells[2].Value = productList[i].Description;
                    //    this.dgProduct.Rows[i].Cells[3].Value = productList[i].ProductCharacteristic.ID;
                    //    this.dgProduct.Rows[i].Cells[4].Value = productList[i].ProductCharacteristic.Name;
                    //    this.dgProduct.Rows[i].Cells[5].Value = productList[i].ProductCategory.ID;
                    //    this.dgProduct.Rows[i].Cells[6].Value = productList[i].ProductCategory.Name;
                    //    this.dgProduct.Rows[i].Cells[7].Value = productList[i].ProductType.ID;
                    //    this.dgProduct.Rows[i].Cells[8].Value = productList[i].ProductType.Name;
                    //    this.dgProduct.Rows[i].Cells[9].Value = productList[i].ProductBrand.ID;
                    //    this.dgProduct.Rows[i].Cells[10].Value = productList[i].ProductBrand.Name;
                    //    this.dgProduct.Rows[i].Cells[11].Value = productList[i].PerPieceBox;
                    //    this.dgProduct.Rows[i].Cells[12].Value = productList[i].Location.ID;
                    //    this.dgProduct.Rows[i].Cells[13].Value = productList[i].Location.Name;

                    //}
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
  
                if (e.RowIndex >= 0)
                {
                    this.Product = new Product {
                        ID = Int32.Parse(this.dgProduct.Rows[e.RowIndex].Cells[0].Value.ToString()),
                        ProductName = this.dgProduct.Rows[e.RowIndex].Cells[1].Value.ToString(),
                        Description = this.dgProduct.Rows[e.RowIndex].Cells[2].Value.ToString(),
                        ProductCharacteristic = new ProductCharacteristic {
                            ID = Int32.Parse(this.dgProduct.Rows[e.RowIndex].Cells[3].Value.ToString()),
                            Name = this.dgProduct.Rows[e.RowIndex].Cells[4].Value.ToString()

                        },
                        ProductCategory = new Tier.BO.ProductCategory {
                            ID = Int32.Parse(this.dgProduct.Rows[e.RowIndex].Cells[5].Value.ToString()),
                            Name = this.dgProduct.Rows[e.RowIndex].Cells[6].Value.ToString()
                        },

                        ProductType = new Tier.BO.ProductType {
                            ID = Int32.Parse(this.dgProduct.Rows[e.RowIndex].Cells[7].Value.ToString()),
                            Name = this.dgProduct.Rows[e.RowIndex].Cells[8].Value.ToString()

                        },
                        ProductBrand = new Tier.BO.ProductBrand {
                            ID = Int32.Parse(this.dgProduct.Rows[e.RowIndex].Cells[9].Value.ToString()),
                            Name = this.dgProduct.Rows[e.RowIndex].Cells[10].Value.ToString()

                        },
                        PerPieceBox = decimal.Parse(this.dgProduct.Rows[e.RowIndex].Cells[11].Value.ToString()),
                        Location = new Tier.BO.Location {
                            ID = Int32.Parse(this.dgProduct.Rows[e.RowIndex].Cells[12].Value.ToString()),
                            Name = this.dgProduct.Rows[e.RowIndex].Cells[13].Value.ToString()

                        }

                    };
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
                if (this.Product == null)
                {
                    MessageBox.Show("Please select item");
                    return;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void dgProduct_CellDoubleClick(object sender, DataGridViewRowDividerDoubleClickEventArgs e)
        {

        }
    }
}
