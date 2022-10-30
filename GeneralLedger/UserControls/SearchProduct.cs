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

                    for (int i = 0; i < productList.Count; i++)
                    {

                        this.dgProduct.Rows[i].Cells[0].Value = productList[i].ID;
                        this.dgProduct.Rows[i].Cells[1].Value = productList[i].ProductName;
                        this.dgProduct.Rows[i].Cells[2].Value = productList[i].Description;
                        this.dgProduct.Rows[i].Cells[3].Value = productList[i].ProductCharacteristic.ID;
                        this.dgProduct.Rows[i].Cells[4].Value = productList[i].ProductCharacteristic.Name;
                        this.dgProduct.Rows[i].Cells[5].Value = productList[i].ProductCategory.ID;
                        this.dgProduct.Rows[i].Cells[6].Value = productList[i].ProductCategory.Name;
                        this.dgProduct.Rows[i].Cells[7].Value = productList[i].ProductType.ID;
                        this.dgProduct.Rows[i].Cells[8].Value = productList[i].ProductType.Name;
                        this.dgProduct.Rows[i].Cells[9].Value = productList[i].ProductBrand.ID;
                        this.dgProduct.Rows[i].Cells[10].Value = productList[i].ProductBrand.Name;
                        this.dgProduct.Rows[i].Cells[11].Value = productList[i].PerPieceBox;
                        this.dgProduct.Rows[i].Cells[12].Value = productList[i].Location.ID;
                        this.dgProduct.Rows[i].Cells[13].Value = productList[i].Location.Name;

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
