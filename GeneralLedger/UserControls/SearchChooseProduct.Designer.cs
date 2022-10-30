namespace GeneralLedger.UserControls
{
    partial class SearchChooseProduct
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
            this.ProductDetailsID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtCriteria = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.cbProductBrand = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.cbProductTypes = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cbCategories = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.btnAddProduct = new MetroFramework.Controls.MetroButton();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.txtProductName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.txtCost = new DevComponents.Editors.DoubleInput();
            this.txtQuantity = new DevComponents.Editors.IntegerInput();
            this.metroLabel20 = new MetroFramework.Controls.MetroLabel();
            this.btnClearProduct = new MetroFramework.Controls.MetroButton();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtSubTotal = new DevComponents.Editors.DoubleInput();
            this.txtQuantityReceived = new DevComponents.Editors.IntegerInput();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.txtColor = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.txtSize = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantityReceived)).BeginInit();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.dgProduct);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 15;
            this.metroPanel1.Location = new System.Drawing.Point(11, 363);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1374, 394);
            this.metroPanel1.TabIndex = 25;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 15;
            // 
            // dgProduct
            // 
            this.dgProduct.AllowUserToAddRows = false;
            this.dgProduct.AllowUserToDeleteRows = false;
            this.dgProduct.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductDetailsID,
            this.ProductDetailID,
            this.ProductName,
            this.ProductColor,
            this.ProductSize,
            this.ProductCategory,
            this.Type,
            this.Brand,
            this.CurStock,
            this.ActStock,
            this.Cost});
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
            this.dgProduct.Name = "dgProduct";
            this.dgProduct.ReadOnly = true;
            this.dgProduct.RowTemplate.Height = 30;
            this.dgProduct.Size = new System.Drawing.Size(1374, 394);
            this.dgProduct.TabIndex = 64;
            this.dgProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProduct_CellClick);
            this.dgProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProduct_CellContentClick_1);
            // 
            // ProductDetailsID
            // 
            this.ProductDetailsID.HeaderText = "ID";
            this.ProductDetailsID.Name = "ProductDetailsID";
            this.ProductDetailsID.ReadOnly = true;
            // 
            // ProductDetailID
            // 
            this.ProductDetailID.HeaderText = "ProductDetailID";
            this.ProductDetailID.Name = "ProductDetailID";
            this.ProductDetailID.ReadOnly = true;
            // 
            // ProductName
            // 
            this.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ProductName.HeaderText = "ProductName";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.Width = 142;
            // 
            // ProductColor
            // 
            this.ProductColor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ProductColor.HeaderText = "ProductColor";
            this.ProductColor.Name = "ProductColor";
            this.ProductColor.ReadOnly = true;
            this.ProductColor.Width = 137;
            // 
            // ProductSize
            // 
            this.ProductSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ProductSize.HeaderText = "ProductSize";
            this.ProductSize.Name = "ProductSize";
            this.ProductSize.ReadOnly = true;
            this.ProductSize.Width = 131;
            // 
            // ProductCategory
            // 
            this.ProductCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ProductCategory.HeaderText = "ProductCategory";
            this.ProductCategory.Name = "ProductCategory";
            this.ProductCategory.ReadOnly = true;
            this.ProductCategory.Width = 164;
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 79;
            // 
            // Brand
            // 
            this.Brand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Brand.HeaderText = "Brand";
            this.Brand.Name = "Brand";
            this.Brand.ReadOnly = true;
            this.Brand.Width = 88;
            // 
            // CurStock
            // 
            this.CurStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CurStock.HeaderText = "Cur. Stock";
            this.CurStock.Name = "CurStock";
            this.CurStock.ReadOnly = true;
            this.CurStock.Width = 119;
            // 
            // ActStock
            // 
            this.ActStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ActStock.HeaderText = "Act. Stock";
            this.ActStock.Name = "ActStock";
            this.ActStock.ReadOnly = true;
            this.ActStock.Width = 118;
            // 
            // Cost
            // 
            this.Cost.HeaderText = "Cost";
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1000, 298);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(148, 35);
            this.btnSearch.TabIndex = 28;
            this.btnSearch.Text = "Search Product";
            this.btnSearch.UseSelectable = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(714, 241);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(52, 19);
            this.metroLabel2.TabIndex = 27;
            this.metroLabel2.Text = "Criteria";
            // 
            // txtCriteria
            // 
            // 
            // 
            // 
            this.txtCriteria.CustomButton.Image = null;
            this.txtCriteria.CustomButton.Location = new System.Drawing.Point(411, 2);
            this.txtCriteria.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCriteria.CustomButton.Name = "";
            this.txtCriteria.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtCriteria.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCriteria.CustomButton.TabIndex = 1;
            this.txtCriteria.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCriteria.CustomButton.UseSelectable = true;
            this.txtCriteria.CustomButton.Visible = false;
            this.txtCriteria.Lines = new string[0];
            this.txtCriteria.Location = new System.Drawing.Point(864, 241);
            this.txtCriteria.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCriteria.MaxLength = 32767;
            this.txtCriteria.Name = "txtCriteria";
            this.txtCriteria.PasswordChar = '\0';
            this.txtCriteria.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCriteria.SelectedText = "";
            this.txtCriteria.SelectionLength = 0;
            this.txtCriteria.SelectionStart = 0;
            this.txtCriteria.ShortcutsEnabled = true;
            this.txtCriteria.Size = new System.Drawing.Size(447, 38);
            this.txtCriteria.TabIndex = 26;
            this.txtCriteria.UseSelectable = true;
            this.txtCriteria.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCriteria.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(28, 241);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(94, 19);
            this.metroLabel5.TabIndex = 35;
            this.metroLabel5.Text = "Product Brand";
            // 
            // cbProductBrand
            // 
            this.cbProductBrand.FormattingEnabled = true;
            this.cbProductBrand.ItemHeight = 23;
            this.cbProductBrand.Location = new System.Drawing.Point(239, 241);
            this.cbProductBrand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbProductBrand.Name = "cbProductBrand";
            this.cbProductBrand.Size = new System.Drawing.Size(372, 29);
            this.cbProductBrand.TabIndex = 34;
            this.cbProductBrand.UseSelectable = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(714, 178);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(91, 19);
            this.metroLabel3.TabIndex = 33;
            this.metroLabel3.Text = "Product Types";
            // 
            // cbProductTypes
            // 
            this.cbProductTypes.FormattingEnabled = true;
            this.cbProductTypes.ItemHeight = 23;
            this.cbProductTypes.Location = new System.Drawing.Point(864, 178);
            this.cbProductTypes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbProductTypes.Name = "cbProductTypes";
            this.cbProductTypes.Size = new System.Drawing.Size(447, 29);
            this.cbProductTypes.TabIndex = 32;
            this.cbProductTypes.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(28, 178);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(122, 19);
            this.metroLabel1.TabIndex = 31;
            this.metroLabel1.Text = "Product Categories";
            // 
            // cbCategories
            // 
            this.cbCategories.FormattingEnabled = true;
            this.cbCategories.ItemHeight = 23;
            this.cbCategories.Location = new System.Drawing.Point(239, 178);
            this.cbCategories.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCategories.Name = "cbCategories";
            this.cbCategories.Size = new System.Drawing.Size(372, 29);
            this.cbCategories.TabIndex = 30;
            this.cbCategories.UseSelectable = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(22, 119);
            this.metroLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(568, 31);
            this.metroLabel6.TabIndex = 36;
            this.metroLabel6.Text = "Product Filters";
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(1189, 910);
            this.btnAddProduct.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(148, 35);
            this.btnAddProduct.TabIndex = 41;
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.UseSelectable = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.Location = new System.Drawing.Point(13, 783);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(95, 19);
            this.metroLabel12.TabIndex = 68;
            this.metroLabel12.Text = "Product Name";
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.SystemColors.ControlLight;
            // 
            // 
            // 
            this.txtProductName.CustomButton.Image = null;
            this.txtProductName.CustomButton.Location = new System.Drawing.Point(238, 2);
            this.txtProductName.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtProductName.CustomButton.Name = "";
            this.txtProductName.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtProductName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtProductName.CustomButton.TabIndex = 1;
            this.txtProductName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtProductName.CustomButton.UseSelectable = true;
            this.txtProductName.CustomButton.Visible = false;
            this.txtProductName.Enabled = false;
            this.txtProductName.Lines = new string[0];
            this.txtProductName.Location = new System.Drawing.Point(206, 783);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtProductName.MaxLength = 32767;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.PasswordChar = '\0';
            this.txtProductName.ReadOnly = true;
            this.txtProductName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtProductName.SelectedText = "";
            this.txtProductName.SelectionLength = 0;
            this.txtProductName.SelectionStart = 0;
            this.txtProductName.ShortcutsEnabled = true;
            this.txtProductName.Size = new System.Drawing.Size(274, 38);
            this.txtProductName.TabIndex = 67;
            this.txtProductName.UseCustomBackColor = true;
            this.txtProductName.UseSelectable = true;
            this.txtProductName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtProductName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(522, 848);
            this.metroLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(35, 19);
            this.metroLabel9.TabIndex = 94;
            this.metroLabel9.Text = "Cost";
            this.metroLabel9.Click += new System.EventHandler(this.metroLabel9_Click);
            // 
            // txtCost
            // 
            // 
            // 
            // 
            this.txtCost.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtCost.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtCost.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtCost.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtCost.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtCost.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtCost.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCost.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtCost.Increment = 1D;
            this.txtCost.Location = new System.Drawing.Point(632, 848);
            this.txtCost.MinimumSize = new System.Drawing.Size(0, 35);
            this.txtCost.Name = "txtCost";
            this.txtCost.ShowUpDown = true;
            this.txtCost.Size = new System.Drawing.Size(254, 35);
            this.txtCost.TabIndex = 93;
            this.txtCost.ValueChanged += new System.EventHandler(this.txtBalance_ValueChanged);
            // 
            // txtQuantity
            // 
            // 
            // 
            // 
            this.txtQuantity.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtQuantity.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtQuantity.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtQuantity.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtQuantity.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtQuantity.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtQuantity.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtQuantity.Location = new System.Drawing.Point(632, 783);
            this.txtQuantity.MinimumSize = new System.Drawing.Size(0, 33);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.ShowUpDown = true;
            this.txtQuantity.Size = new System.Drawing.Size(254, 33);
            this.txtQuantity.TabIndex = 96;
            this.txtQuantity.WatermarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtQuantity.ValueChanged += new System.EventHandler(this.txtQuantity_ValueChanged);
            // 
            // metroLabel20
            // 
            this.metroLabel20.AutoSize = true;
            this.metroLabel20.Location = new System.Drawing.Point(522, 783);
            this.metroLabel20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel20.Name = "metroLabel20";
            this.metroLabel20.Size = new System.Drawing.Size(58, 19);
            this.metroLabel20.TabIndex = 95;
            this.metroLabel20.Text = "Quantity";
            // 
            // btnClearProduct
            // 
            this.btnClearProduct.Location = new System.Drawing.Point(1033, 910);
            this.btnClearProduct.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClearProduct.Name = "btnClearProduct";
            this.btnClearProduct.Size = new System.Drawing.Size(148, 35);
            this.btnClearProduct.TabIndex = 97;
            this.btnClearProduct.Text = "Clear Product";
            this.btnClearProduct.UseSelectable = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(522, 910);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(58, 19);
            this.metroLabel4.TabIndex = 99;
            this.metroLabel4.Text = "SubTotal";
            // 
            // txtSubTotal
            // 
            // 
            // 
            // 
            this.txtSubTotal.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtSubTotal.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtSubTotal.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtSubTotal.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtSubTotal.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtSubTotal.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtSubTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSubTotal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtSubTotal.Increment = 1D;
            this.txtSubTotal.Location = new System.Drawing.Point(632, 910);
            this.txtSubTotal.MinimumSize = new System.Drawing.Size(0, 35);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ShowUpDown = true;
            this.txtSubTotal.Size = new System.Drawing.Size(254, 35);
            this.txtSubTotal.TabIndex = 98;
            // 
            // txtQuantityReceived
            // 
            // 
            // 
            // 
            this.txtQuantityReceived.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtQuantityReceived.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtQuantityReceived.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtQuantityReceived.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtQuantityReceived.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtQuantityReceived.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtQuantityReceived.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtQuantityReceived.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtQuantityReceived.Location = new System.Drawing.Point(1111, 783);
            this.txtQuantityReceived.MinimumSize = new System.Drawing.Size(0, 33);
            this.txtQuantityReceived.Name = "txtQuantityReceived";
            this.txtQuantityReceived.ShowUpDown = true;
            this.txtQuantityReceived.Size = new System.Drawing.Size(274, 33);
            this.txtQuantityReceived.TabIndex = 101;
            this.txtQuantityReceived.WatermarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(922, 788);
            this.metroLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(114, 19);
            this.metroLabel7.TabIndex = 100;
            this.metroLabel7.Text = "Quantity Received";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(13, 848);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(42, 19);
            this.metroLabel8.TabIndex = 103;
            this.metroLabel8.Text = "Color";
            // 
            // txtColor
            // 
            this.txtColor.BackColor = System.Drawing.SystemColors.ControlLight;
            // 
            // 
            // 
            this.txtColor.CustomButton.Image = null;
            this.txtColor.CustomButton.Location = new System.Drawing.Point(238, 2);
            this.txtColor.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtColor.CustomButton.Name = "";
            this.txtColor.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtColor.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtColor.CustomButton.TabIndex = 1;
            this.txtColor.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtColor.CustomButton.UseSelectable = true;
            this.txtColor.CustomButton.Visible = false;
            this.txtColor.Enabled = false;
            this.txtColor.Lines = new string[0];
            this.txtColor.Location = new System.Drawing.Point(206, 848);
            this.txtColor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtColor.MaxLength = 32767;
            this.txtColor.Name = "txtColor";
            this.txtColor.PasswordChar = '\0';
            this.txtColor.ReadOnly = true;
            this.txtColor.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtColor.SelectedText = "";
            this.txtColor.SelectionLength = 0;
            this.txtColor.SelectionStart = 0;
            this.txtColor.ShortcutsEnabled = true;
            this.txtColor.Size = new System.Drawing.Size(274, 38);
            this.txtColor.TabIndex = 102;
            this.txtColor.UseCustomBackColor = true;
            this.txtColor.UseSelectable = true;
            this.txtColor.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtColor.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(13, 910);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(32, 19);
            this.metroLabel10.TabIndex = 105;
            this.metroLabel10.Text = "Size";
            // 
            // txtSize
            // 
            this.txtSize.BackColor = System.Drawing.SystemColors.ControlLight;
            // 
            // 
            // 
            this.txtSize.CustomButton.Image = null;
            this.txtSize.CustomButton.Location = new System.Drawing.Point(238, 2);
            this.txtSize.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSize.CustomButton.Name = "";
            this.txtSize.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtSize.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSize.CustomButton.TabIndex = 1;
            this.txtSize.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSize.CustomButton.UseSelectable = true;
            this.txtSize.CustomButton.Visible = false;
            this.txtSize.Enabled = false;
            this.txtSize.Lines = new string[0];
            this.txtSize.Location = new System.Drawing.Point(206, 910);
            this.txtSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSize.MaxLength = 32767;
            this.txtSize.Name = "txtSize";
            this.txtSize.PasswordChar = '\0';
            this.txtSize.ReadOnly = true;
            this.txtSize.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSize.SelectedText = "";
            this.txtSize.SelectionLength = 0;
            this.txtSize.SelectionStart = 0;
            this.txtSize.ShortcutsEnabled = true;
            this.txtSize.Size = new System.Drawing.Size(274, 38);
            this.txtSize.TabIndex = 104;
            this.txtSize.UseCustomBackColor = true;
            this.txtSize.UseSelectable = true;
            this.txtSize.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtSize.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // SearchChooseProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1409, 963);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.txtQuantityReceived);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.btnClearProduct);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.metroLabel20);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.metroLabel12);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.cbProductBrand);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.cbProductTypes);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.cbCategories);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtCriteria);
            this.Name = "SearchChooseProduct";
            this.Text = "Choose Product";
            this.Load += new System.EventHandler(this.SearchChooseProduct_Load);
            this.metroPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantityReceived)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgProduct;
        private MetroFramework.Controls.MetroButton btnSearch;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtCriteria;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroComboBox cbProductBrand;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox cbProductTypes;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox cbCategories;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroButton btnAddProduct;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroTextBox txtProductName;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private DevComponents.Editors.DoubleInput txtCost;
        private DevComponents.Editors.IntegerInput txtQuantity;
        private MetroFramework.Controls.MetroLabel metroLabel20;
        private MetroFramework.Controls.MetroButton btnClearProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductDetailsID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private DevComponents.Editors.DoubleInput txtSubTotal;
        private DevComponents.Editors.IntegerInput txtQuantityReceived;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox txtColor;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroTextBox txtSize;
    }
}