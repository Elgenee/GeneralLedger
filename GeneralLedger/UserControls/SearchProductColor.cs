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
using DevComponents.DotNetBar.Controls;



namespace GeneralLedger.UserControls
{
    public partial class SearchProductColor : MetroForm
    {

        public string Characteristic { get; set; }

        public DataGridViewX DataGridViewX { get; set; }


        public SearchProductAndColorAndSize SearchProductAndColorAndSize { get; set; }


        public SearchProductColor()
        {
            InitializeComponent();
     
        }

        private void SearchProductColor_Load(object sender, EventArgs e)
        {
            this.cbColor.Enabled = true;
            this.cbSize.Enabled = true;

            ProductColorBAL ProductColorBAL = new ProductColorBAL();
            List<GeneralLedger.Tier.BO.ProductColor> ProductColorList = ProductColorBAL.getProductColor();

            ProductColorList.Insert(0, new Tier.BO.ProductColor { ID = 0, Name = string.Empty });
            this.cbColor.DataSource = ProductColorList;
            this.cbColor.ValueMember = "ID";
            this.cbColor.DisplayMember = "Name";

            ProductSizeBAL ProductSizeBAL = new ProductSizeBAL();
            List<GeneralLedger.Tier.BO.ProductSize> ProductSizeList = ProductSizeBAL.getProductSize();
            ProductSizeList.Insert(0, new Tier.BO.ProductSize { ID = 0, Name = string.Empty });
            this.cbSize.DataSource = ProductSizeList;
            this.cbSize.ValueMember = "ID";
            this.cbSize.DisplayMember = "Name";


            if (Characteristic.ToUpper().Equals("WITH COLOR"))
            {
                this.cbSize.Enabled = false;
            }

            if (Characteristic.ToUpper().Equals("WITH SIZE"))
            {
                this.cbColor.Enabled = false;
            }


        }

        private void btnAddColorAndSize_Click(object sender, EventArgs e)
        {
            GeneralLedger.Tier.BO.ProductColor color;
            GeneralLedger.Tier.BO.ProductSize size;
            int intParser;
            decimal decimalParser;

            if (Characteristic.ToUpper().Equals("WITH COLOR"))
            {
                color = (this.cbColor.SelectedItem == null) ? null : ((GeneralLedger.Tier.BO.ProductColor)this.cbColor.SelectedItem);
                size = new Tier.BO.ProductSize { ID = 0, Name = string.Empty };
            }

            else if (Characteristic.ToUpper().Equals("WITH SIZE"))
            {
                color = new Tier.BO.ProductColor { ID = 0, Name = string.Empty };
                size = (this.cbSize.SelectedItem == null) ? null : ((GeneralLedger.Tier.BO.ProductSize)this.cbSize.SelectedItem);
            }
            else
            {
                color = (this.cbColor.SelectedItem == null) ? null : ((GeneralLedger.Tier.BO.ProductColor)this.cbColor.SelectedItem);
                size = (this.cbSize.SelectedItem == null) ? null : ((GeneralLedger.Tier.BO.ProductSize)this.cbSize.SelectedItem);
            }


            //var color = (this.cbColor.SelectedItem == null) ? null : ((GeneralLedger.Tier.BO.ProductColor)this.cbColor.SelectedItem);
            //var size = (this.cbSize.SelectedItem == null) ? null : ((GeneralLedger.Tier.BO.ProductSize)this.cbSize.SelectedItem);

            this.DataGridViewX.Rows.Add("0", 
                color.Name,
                color.ID, 
                size.Name, 
                size.ID, 
                this.txtMinimun.Text, 
                this.txtLength.Text, 
                this.txtWidth.Text, 
                this.txtHeight.Text, 
                this.txtCost.Text, 
                this.txtRetail.Text, 
                this.txtWholesale.Text, 
                "", 
                string.Empty);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
