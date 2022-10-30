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
    public partial class ProductIndex : MetroUserControl
    {

        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }
        public int ID { get; set; }

        public ProductIndex()
        {
            InitializeComponent();
         
        }

        private void ProductIndex_Load(object sender, EventArgs e)
        {

            this.dgProductSize.ColumnCount = 4;
            this.dgProductSize.RowCount = 5;
            for (int i = 0; i < 4; i++)
            {
                this.dgProductSize.Rows[i].Cells[0].Value = i;
                this.dgProductSize.Rows[i].Cells[1].Value = "sample1";
                this.dgProductSize.Rows[i].Cells[2].Value = "";
                this.dgProductSize.Rows[i].Cells[3].Value = "";
                //setRowNumber(this.dgProductSize);

            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            MetroTabPage metroTabPage = new MetroTabPage();
            metroTabPage.Text = "Add Product";
            metroTabPage.AutoScroll = true;
            metroTabPage.HorizontalScrollbar = true;
            metroTabPage.HorizontalScrollbarBarColor = true;
            metroTabPage.HorizontalScrollbarHighlightOnWheel = true;
            metroTabPage.HorizontalScrollbarSize = 15;
            metroTabPage.UseStyleColors = true;
            metroTabPage.VerticalScrollbar = true;
            metroTabPage.VerticalScrollbarBarColor = true;
            metroTabPage.VerticalScrollbarHighlightOnWheel = true;
            metroTabPage.VerticalScrollbarSize = 15;
            //metroTabPage.Style = MetroFramework.MetroColorStyle.Orange;
            //metroTabPage.Location = new System.Drawing.Point(15, 38);
            //metroTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            AddProduct addProduct = new AddProduct();
            addProduct.Parent = metroTabPage;
            addProduct.MetroTabPage = metroTabPage;
            addProduct.MetroTabControl = this.MetroTabControl;
            metroTabPage.Controls.Add(addProduct);
            MetroTabControl.TabPages.Add(metroTabPage);
            MetroTabControl.SelectedTab = metroTabPage;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }
    }
}
