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
                     //this.dgProduct.DataSource = productList;

                    //display all the data in productList to the dgProduct with the following columns
                    //id, productname, description, productcharacteristicid, productcharacteristicname, productcategoryid, productcategoryname, producttypeid, producttypename, productbrandid, productbrandname, perpiecebox, locationid, locationname, productcolorid, productcolorname, productsizeid, productsizename, productunitid, productunitname, code, productstatusid, productstatusname
                    this.dgProduct.ColumnCount = 28;
                    this.dgProduct.Columns[0].Name = "ID";
                    this.dgProduct.Columns[0].Visible = false;
                    this.dgProduct.Columns[1].Name = "Product Name";
                    this.dgProduct.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[2].Name = "Description";
                    this.dgProduct.Columns[3].Name = "Product Characteristic ID";
                    this.dgProduct.Columns[3].Visible = false;
                    this.dgProduct.Columns[4].Name = "Product Characteristic Name";
                    this.dgProduct.Columns[5].Name = "Product Category ID";
                    this.dgProduct.Columns[5].Visible = false;
                    this.dgProduct.Columns[6].Name = "Product Category Name";
                    this.dgProduct.Columns[7].Name = "Product Type ID";
                    this.dgProduct.Columns[7].Visible = false;
                    this.dgProduct.Columns[8].Name = "Product Type Name";
                    this.dgProduct.Columns[9].Name = "Product Brand ID";
                    this.dgProduct.Columns[9].Visible = false;
                    this.dgProduct.Columns[10].Name = "Product Brand Name";
                    this.dgProduct.Columns[11].Name = "Per Piece Box";
                    this.dgProduct.Columns[12].Name = "Location ID";
                    this.dgProduct.Columns[12].Visible = false;
                    this.dgProduct.Columns[13].Name = "Location Name";
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
                    this.dgProduct.Columns[27].Name = "UnitPrice";
                    //this.dgProduct.Columns[28].Name = "SellingPrice";

                    //loop through the productList and display all the data in productList to the datagridview
                    //
                    for (int i = 0; i < productList.Count; i++)
                    {
                        //display all the data in productList to the datagridview
                        Product product = productList[i];
                        this.dgProduct.Rows[i].Cells[0].Value = product.ID;
                        this.dgProduct.Rows[i].Cells[1].Value = product.ProductName;
                        this.dgProduct.Rows[i].Cells[2].Value = product.Description;
                        this.dgProduct.Rows[i].Cells[3].Value = product.ProductCharacteristic.ID;
                        this.dgProduct.Rows[i].Cells[4].Value = product.ProductCharacteristic.Name;
                        this.dgProduct.Rows[i].Cells[5].Value = product.ProductCategory.ID;
                        this.dgProduct.Rows[i].Cells[6].Value = product.ProductCategory.Name;
                        this.dgProduct.Rows[i].Cells[7].Value = product.ProductType.ID;
                        this.dgProduct.Rows[i].Cells[8].Value = product.ProductType.Name;
                        this.dgProduct.Rows[i].Cells[9].Value = product.ProductBrand.ID;
                        this.dgProduct.Rows[i].Cells[10].Value = product.ProductBrand.Name;
                        this.dgProduct.Rows[i].Cells[11].Value = product.PerPieceBox;
                        this.dgProduct.Rows[i].Cells[12].Value = product.Location.ID;
                        this.dgProduct.Rows[i].Cells[13].Value = product.Location.Name;
                        this.dgProduct.Rows[i].Cells[14].Value = product.ProductColor.ID;
                        this.dgProduct.Rows[i].Cells[15].Value = product.ProductColor.Name;
                        this.dgProduct.Rows[i].Cells[16].Value = product.ProductSize.ID;
                        this.dgProduct.Rows[i].Cells[17].Value = product.ProductSize.Name;
                        this.dgProduct.Rows[i].Cells[18].Value = product.ProductUnit.ID;
                        this.dgProduct.Rows[i].Cells[19].Value = product.ProductUnit.Name;
                        this.dgProduct.Rows[i].Cells[20].Value = product.strCode;
                        this.dgProduct.Rows[i].Cells[21].Value = product.strPR;
                        this.dgProduct.Rows[i].Cells[22].Value = product.strPCD;
                        this.dgProduct.Rows[i].Cells[23].Value = product.strMFLM;
                        this.dgProduct.Rows[i].Cells[24].Value = product.strPattern;
                        this.dgProduct.Rows[i].Cells[25].Value = product.strOffsetCenterBase;
                        this.dgProduct.Rows[i].Cells[26].Value = product.strOrigin;
                        this.dgProduct.Rows[i].Cells[27].Value = string.Format("{0:0.00}", product.UnitPrice);
                        //this.dgProduct.Rows[i].Cells[28].Value = string.Format("{0:0.00}", product.SellingPrice);  
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
                        PriceType = new Tier.BO.PriceType
                        {
                            ID = Int32.Parse(this.dgProduct.Rows[e.RowIndex].Cells[7].Value.ToString()),
                            Name = this.dgProduct.Rows[e.RowIndex].Cells[8].Value.ToString()

                        },

                        ProductType = new Tier.BO.ProductType {
                            ID = Int32.Parse(this.dgProduct.Rows[e.RowIndex].Cells[7].Value.ToString()),
                            Name = this.dgProduct.Rows[e.RowIndex].Cells[8].Value.ToString()

                        },
                        ProductSize = new Tier.BO.ProductSize
                        {
                            ID = Int32.Parse(this.dgProduct.Rows[e.RowIndex].Cells[16].Value.ToString()),
                            Name = this.dgProduct.Rows[e.RowIndex].Cells[17].Value.ToString()

                        },
                        ProductColor = new Tier.BO.ProductColor
                        {
                            ID = Int32.Parse(this.dgProduct.Rows[e.RowIndex].Cells[14].Value.ToString()),
                            Name = this.dgProduct.Rows[e.RowIndex].Cells[15].Value.ToString()

                        },
                        ProductUnit = new Tier.BO.ProductUnit
                        {
                            ID = Int32.Parse(this.dgProduct.Rows[e.RowIndex].Cells[18].Value.ToString()),
                            Name = this.dgProduct.Rows[e.RowIndex].Cells[19].Value.ToString()

                        },
                        strCode = this.dgProduct.Rows[e.RowIndex].Cells[20].Value.ToString(),
                        strPR = this.dgProduct.Rows[e.RowIndex].Cells[21].Value.ToString(),
                        strPCD = this.dgProduct.Rows[e.RowIndex].Cells[22].Value.ToString(),
                        strMFLM = this.dgProduct.Rows[e.RowIndex].Cells[23].Value.ToString(),
                        strPattern = this.dgProduct.Rows[e.RowIndex].Cells[24].Value.ToString(),
                        strOffsetCenterBase = this.dgProduct.Rows[e.RowIndex].Cells[25].Value.ToString(),
                        strOrigin = this.dgProduct.Rows[e.RowIndex].Cells[26].Value.ToString(),
                        UnitPrice = decimal.Parse(this.dgProduct.Rows[e.RowIndex].Cells[27].Value.ToString()),      
                        //SellingPrice = decimal.Parse(this.dgProduct.Rows[e.RowIndex].Cells[28].Value.ToString()),
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
