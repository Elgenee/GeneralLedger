namespace GeneralLedger.UserControls
{
    partial class StockInquiryDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.dgProduct = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.txtProductName = new MetroFramework.Controls.MetroLabel();
            this.txtProductCategory = new MetroFramework.Controls.MetroLabel();
            this.txtProductType = new MetroFramework.Controls.MetroLabel();
            this.txtBrand = new MetroFramework.Controls.MetroLabel();
            this.txtProductColor = new MetroFramework.Controls.MetroLabel();
            this.txtProductCode = new MetroFramework.Controls.MetroLabel();
            this.txtTotalIn = new MetroFramework.Controls.MetroLabel();
            this.txtTotalOut = new MetroFramework.Controls.MetroLabel();
            this.txtTotalInAmount = new MetroFramework.Controls.MetroLabel();
            this.txtTotalOutAmount = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.txtTotalRemainingCount = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.txtProductSize = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.dgProduct);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 12;
            this.metroPanel1.Location = new System.Drawing.Point(25, 226);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1269, 479);
            this.metroPanel1.TabIndex = 20;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 13;
            // 
            // dgProduct
            // 
            this.dgProduct.AllowUserToAddRows = false;
            this.dgProduct.AllowUserToDeleteRows = false;
            this.dgProduct.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgProduct.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgProduct.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgProduct.Location = new System.Drawing.Point(0, 0);
            this.dgProduct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgProduct.Name = "dgProduct";
            this.dgProduct.ReadOnly = true;
            this.dgProduct.RowHeadersWidth = 51;
            this.dgProduct.RowTemplate.Height = 30;
            this.dgProduct.Size = new System.Drawing.Size(1269, 479);
            this.dgProduct.TabIndex = 64;
            this.dgProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProduct_CellClick);
            this.dgProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProduct_CellClick);
            this.dgProduct.RowDividerDoubleClick += new System.Windows.Forms.DataGridViewRowDividerDoubleClickEventHandler(this.dgProduct_CellDoubleClick);
            // 
            // txtProductName
            // 
            this.txtProductName.AutoSize = true;
            this.txtProductName.Location = new System.Drawing.Point(208, 76);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(95, 20);
            this.txtProductName.TabIndex = 33;
            this.txtProductName.Text = "ProductName";
            // 
            // txtProductCategory
            // 
            this.txtProductCategory.AutoSize = true;
            this.txtProductCategory.Location = new System.Drawing.Point(662, 76);
            this.txtProductCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtProductCategory.Name = "txtProductCategory";
            this.txtProductCategory.Size = new System.Drawing.Size(128, 20);
            this.txtProductCategory.TabIndex = 34;
            this.txtProductCategory.Text = "txtProductCategory";
            // 
            // txtProductType
            // 
            this.txtProductType.AutoSize = true;
            this.txtProductType.Location = new System.Drawing.Point(208, 120);
            this.txtProductType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtProductType.Name = "txtProductType";
            this.txtProductType.Size = new System.Drawing.Size(101, 20);
            this.txtProductType.TabIndex = 35;
            this.txtProductType.Text = "txtProductType";
            // 
            // txtBrand
            // 
            this.txtBrand.AutoSize = true;
            this.txtBrand.Location = new System.Drawing.Point(662, 125);
            this.txtBrand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(59, 20);
            this.txtBrand.TabIndex = 36;
            this.txtBrand.Text = "txtBrand";
            // 
            // txtProductColor
            // 
            this.txtProductColor.AutoSize = true;
            this.txtProductColor.Location = new System.Drawing.Point(1182, 125);
            this.txtProductColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtProductColor.Name = "txtProductColor";
            this.txtProductColor.Size = new System.Drawing.Size(104, 20);
            this.txtProductColor.TabIndex = 37;
            this.txtProductColor.Text = "txtProductColor";
            // 
            // txtProductCode
            // 
            this.txtProductCode.AutoSize = true;
            this.txtProductCode.Location = new System.Drawing.Point(1182, 79);
            this.txtProductCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(104, 20);
            this.txtProductCode.TabIndex = 38;
            this.txtProductCode.Text = "txtProductCode";
            // 
            // txtTotalIn
            // 
            this.txtTotalIn.AutoSize = true;
            this.txtTotalIn.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.txtTotalIn.Location = new System.Drawing.Point(157, 727);
            this.txtTotalIn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtTotalIn.Name = "txtTotalIn";
            this.txtTotalIn.Size = new System.Drawing.Size(69, 25);
            this.txtTotalIn.TabIndex = 39;
            this.txtTotalIn.Text = "Total In:";
            // 
            // txtTotalOut
            // 
            this.txtTotalOut.AutoSize = true;
            this.txtTotalOut.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.txtTotalOut.Location = new System.Drawing.Point(478, 727);
            this.txtTotalOut.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtTotalOut.Name = "txtTotalOut";
            this.txtTotalOut.Size = new System.Drawing.Size(84, 25);
            this.txtTotalOut.TabIndex = 40;
            this.txtTotalOut.Text = "Total Out:";
            // 
            // txtTotalInAmount
            // 
            this.txtTotalInAmount.AutoSize = true;
            this.txtTotalInAmount.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.txtTotalInAmount.Location = new System.Drawing.Point(252, 727);
            this.txtTotalInAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtTotalInAmount.Name = "txtTotalInAmount";
            this.txtTotalInAmount.Size = new System.Drawing.Size(139, 25);
            this.txtTotalInAmount.TabIndex = 41;
            this.txtTotalInAmount.Text = "txtTotalInAmount";
            // 
            // txtTotalOutAmount
            // 
            this.txtTotalOutAmount.AutoSize = true;
            this.txtTotalOutAmount.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.txtTotalOutAmount.Location = new System.Drawing.Point(600, 727);
            this.txtTotalOutAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtTotalOutAmount.Name = "txtTotalOutAmount";
            this.txtTotalOutAmount.Size = new System.Drawing.Size(154, 25);
            this.txtTotalOutAmount.TabIndex = 42;
            this.txtTotalOutAmount.Text = "txtTotalOutAmount";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(41, 74);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(102, 20);
            this.metroLabel1.TabIndex = 43;
            this.metroLabel1.Text = "Product Name:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(41, 120);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(94, 20);
            this.metroLabel2.TabIndex = 44;
            this.metroLabel2.Text = "Product Type:";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(488, 76);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(121, 20);
            this.metroLabel3.TabIndex = 45;
            this.metroLabel3.Text = "Product Category:";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(488, 125);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(100, 20);
            this.metroLabel4.TabIndex = 46;
            this.metroLabel4.Text = "Product Brand:";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(1010, 76);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(97, 20);
            this.metroLabel5.TabIndex = 47;
            this.metroLabel5.Text = "Product Code:";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(1010, 125);
            this.metroLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(98, 20);
            this.metroLabel6.TabIndex = 48;
            this.metroLabel6.Text = "Product Color:";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel7.Location = new System.Drawing.Point(814, 727);
            this.metroLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(187, 25);
            this.metroLabel7.TabIndex = 49;
            this.metroLabel7.Text = "Total Remaining Count:";
            // 
            // txtTotalRemainingCount
            // 
            this.txtTotalRemainingCount.AutoSize = true;
            this.txtTotalRemainingCount.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.txtTotalRemainingCount.Location = new System.Drawing.Point(1056, 727);
            this.txtTotalRemainingCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtTotalRemainingCount.Name = "txtTotalRemainingCount";
            this.txtTotalRemainingCount.Size = new System.Drawing.Size(191, 25);
            this.txtTotalRemainingCount.TabIndex = 50;
            this.txtTotalRemainingCount.Text = "txtTotalRemainingCount";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(41, 165);
            this.metroLabel8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(111, 25);
            this.metroLabel8.TabIndex = 52;
            this.metroLabel8.Text = "Product Size:";
            // 
            // txtProductSize
            // 
            this.txtProductSize.AutoSize = true;
            this.txtProductSize.Location = new System.Drawing.Point(213, 165);
            this.txtProductSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtProductSize.Name = "txtProductSize";
            this.txtProductSize.Size = new System.Drawing.Size(120, 25);
            this.txtProductSize.TabIndex = 51;
            this.txtProductSize.Text = "txtProductSize";
            // 
            // StockInquiryDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1460, 803);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.txtProductSize);
            this.Controls.Add(this.txtTotalRemainingCount);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtTotalOutAmount);
            this.Controls.Add(this.txtTotalInAmount);
            this.Controls.Add(this.txtTotalOut);
            this.Controls.Add(this.txtTotalIn);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.txtProductColor);
            this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.txtProductType);
            this.Controls.Add(this.txtProductCategory);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.metroPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "StockInquiryDetails";
            this.Padding = new System.Windows.Forms.Padding(17, 74, 17, 16);
            this.Text = "Stock Inquiry Detail";
            this.Load += new System.EventHandler(this.StockInquiryDetails_Load);
            this.metroPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgProduct;
        public MetroFramework.Controls.MetroLabel txtProductName;
        public MetroFramework.Controls.MetroLabel txtProductCategory;
        public MetroFramework.Controls.MetroLabel txtProductType;
        public MetroFramework.Controls.MetroLabel txtBrand;
        public MetroFramework.Controls.MetroLabel txtProductColor;
        public MetroFramework.Controls.MetroLabel txtProductCode;
        public MetroFramework.Controls.MetroLabel txtTotalIn;
        public MetroFramework.Controls.MetroLabel txtTotalOut;
        public MetroFramework.Controls.MetroLabel txtTotalInAmount;
        public MetroFramework.Controls.MetroLabel txtTotalOutAmount;
        public MetroFramework.Controls.MetroLabel metroLabel1;
        public MetroFramework.Controls.MetroLabel metroLabel2;
        public MetroFramework.Controls.MetroLabel metroLabel3;
        public MetroFramework.Controls.MetroLabel metroLabel4;
        public MetroFramework.Controls.MetroLabel metroLabel5;
        public MetroFramework.Controls.MetroLabel metroLabel6;
        public MetroFramework.Controls.MetroLabel metroLabel7;
        public MetroFramework.Controls.MetroLabel txtTotalRemainingCount;
        public MetroFramework.Controls.MetroLabel metroLabel8;
        public MetroFramework.Controls.MetroLabel txtProductSize;
    }
}