namespace GeneralLedger.UserControls
{
    partial class frmChooseProduct
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.dgProduct = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnSearch = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtCriteria = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel14 = new MetroFramework.Controls.MetroLabel();
            this.txtCode = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.cbProductUnit = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.cbPriceType = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.cbSize = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.cbColor = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.txtID = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.cbProductBrand = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.cbProductTypes = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cbCategories = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.txtProductName = new MetroFramework.Controls.MetroTextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPCD = new MetroFramework.Controls.MetroLabel();
            this.txtPCD = new MetroFramework.Controls.MetroTextBox();
            this.lblMFLM = new MetroFramework.Controls.MetroLabel();
            this.txtMFLM = new MetroFramework.Controls.MetroTextBox();
            this.lblOffsetCenterBore = new MetroFramework.Controls.MetroLabel();
            this.txtOffsetCenterBore = new MetroFramework.Controls.MetroTextBox();
            this.lblOrigin = new MetroFramework.Controls.MetroLabel();
            this.txtOrigin = new MetroFramework.Controls.MetroTextBox();
            this.lblPattern = new MetroFramework.Controls.MetroLabel();
            this.txtPattern = new MetroFramework.Controls.MetroTextBox();
            this.lblPR = new MetroFramework.Controls.MetroLabel();
            this.txtPR = new MetroFramework.Controls.MetroTextBox();
            this.btnClearProduct = new MetroFramework.Controls.MetroButton();
            this.btnAddProduct = new MetroFramework.Controls.MetroButton();
            this.txtRemainingCount = new DevComponents.Editors.DoubleInput();
            this.metroLabel15 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel16 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel17 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtTotalPrice = new DevComponents.Editors.DoubleInput();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.txtQuantity = new DevComponents.Editors.IntegerInput();
            this.metroLabel18 = new MetroFramework.Controls.MetroLabel();
            this.txtSellingPrice = new DevComponents.Editors.DoubleInput();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.txtUnitPrice = new DevComponents.Editors.DoubleInput();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProduct)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemainingCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSellingPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.dgProduct);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(10, 91);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1156, 277);
            this.metroPanel1.TabIndex = 25;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // dgProduct
            // 
            this.dgProduct.AllowUserToAddRows = false;
            this.dgProduct.AllowUserToDeleteRows = false;
            this.dgProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgProduct.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgProduct.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgProduct.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgProduct.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgProduct.Location = new System.Drawing.Point(0, 0);
            this.dgProduct.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgProduct.Name = "dgProduct";
            this.dgProduct.ReadOnly = true;
            this.dgProduct.RowHeadersWidth = 51;
            this.dgProduct.RowTemplate.Height = 30;
            this.dgProduct.Size = new System.Drawing.Size(1156, 277);
            this.dgProduct.TabIndex = 64;
            this.dgProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProduct_CellClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(393, 60);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(99, 23);
            this.btnSearch.TabIndex = 28;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseSelectable = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(46, 48);
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
            this.txtCriteria.CustomButton.Location = new System.Drawing.Point(134, 1);
            this.txtCriteria.CustomButton.Name = "";
            this.txtCriteria.CustomButton.Size = new System.Drawing.Size(16, 17);
            this.txtCriteria.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCriteria.CustomButton.TabIndex = 1;
            this.txtCriteria.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCriteria.CustomButton.UseSelectable = true;
            this.txtCriteria.CustomButton.Visible = false;
            this.txtCriteria.Lines = new string[0];
            this.txtCriteria.Location = new System.Drawing.Point(188, 60);
            this.txtCriteria.MaxLength = 32767;
            this.txtCriteria.Name = "txtCriteria";
            this.txtCriteria.PasswordChar = '\0';
            this.txtCriteria.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCriteria.SelectedText = "";
            this.txtCriteria.SelectionLength = 0;
            this.txtCriteria.SelectionStart = 0;
            this.txtCriteria.ShortcutsEnabled = true;
            this.txtCriteria.Size = new System.Drawing.Size(200, 23);
            this.txtCriteria.TabIndex = 26;
            this.txtCriteria.UseSelectable = true;
            this.txtCriteria.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCriteria.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel14
            // 
            this.metroLabel14.AutoSize = true;
            this.metroLabel14.Location = new System.Drawing.Point(15, 450);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Size = new System.Drawing.Size(41, 19);
            this.metroLabel14.TabIndex = 192;
            this.metroLabel14.Text = "Code";
            // 
            // txtCode
            // 
            // 
            // 
            // 
            this.txtCode.CustomButton.Image = null;
            this.txtCode.CustomButton.Location = new System.Drawing.Point(231, 1);
            this.txtCode.CustomButton.Name = "";
            this.txtCode.CustomButton.Size = new System.Drawing.Size(16, 17);
            this.txtCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCode.CustomButton.TabIndex = 1;
            this.txtCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCode.CustomButton.UseSelectable = true;
            this.txtCode.CustomButton.Visible = false;
            this.txtCode.Enabled = false;
            this.txtCode.Lines = new string[0];
            this.txtCode.Location = new System.Drawing.Point(160, 450);
            this.txtCode.MaxLength = 32767;
            this.txtCode.Name = "txtCode";
            this.txtCode.PasswordChar = '\0';
            this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCode.SelectedText = "";
            this.txtCode.SelectionLength = 0;
            this.txtCode.SelectionStart = 0;
            this.txtCode.ShortcutsEnabled = true;
            this.txtCode.Size = new System.Drawing.Size(330, 23);
            this.txtCode.TabIndex = 191;
            this.txtCode.UseSelectable = true;
            this.txtCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(15, 518);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(82, 19);
            this.metroLabel9.TabIndex = 188;
            this.metroLabel9.Text = "Product Unit";
            // 
            // cbProductUnit
            // 
            this.cbProductUnit.Enabled = false;
            this.cbProductUnit.FormattingEnabled = true;
            this.cbProductUnit.ItemHeight = 23;
            this.cbProductUnit.Location = new System.Drawing.Point(161, 518);
            this.cbProductUnit.Name = "cbProductUnit";
            this.cbProductUnit.Size = new System.Drawing.Size(330, 29);
            this.cbProductUnit.TabIndex = 187;
            this.cbProductUnit.UseSelectable = true;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(15, 482);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(69, 19);
            this.metroLabel7.TabIndex = 186;
            this.metroLabel7.Text = "Price Type";
            // 
            // cbPriceType
            // 
            this.cbPriceType.Enabled = false;
            this.cbPriceType.FormattingEnabled = true;
            this.cbPriceType.ItemHeight = 23;
            this.cbPriceType.Location = new System.Drawing.Point(160, 482);
            this.cbPriceType.Name = "cbPriceType";
            this.cbPriceType.Size = new System.Drawing.Size(330, 29);
            this.cbPriceType.TabIndex = 185;
            this.cbPriceType.UseSelectable = true;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(511, 555);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(82, 19);
            this.metroLabel8.TabIndex = 184;
            this.metroLabel8.Text = "Product Size";
            // 
            // cbSize
            // 
            this.cbSize.Enabled = false;
            this.cbSize.FormattingEnabled = true;
            this.cbSize.ItemHeight = 23;
            this.cbSize.Location = new System.Drawing.Point(638, 557);
            this.cbSize.Name = "cbSize";
            this.cbSize.Size = new System.Drawing.Size(222, 29);
            this.cbSize.TabIndex = 183;
            this.cbSize.UseSelectable = true;
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(511, 522);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(92, 19);
            this.metroLabel10.TabIndex = 182;
            this.metroLabel10.Text = "Product Color";
            // 
            // cbColor
            // 
            this.cbColor.Enabled = false;
            this.cbColor.FormattingEnabled = true;
            this.cbColor.ItemHeight = 23;
            this.cbColor.Location = new System.Drawing.Point(638, 522);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(222, 29);
            this.cbColor.TabIndex = 181;
            this.cbColor.UseSelectable = true;
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.Location = new System.Drawing.Point(15, 389);
            this.metroLabel12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(71, 19);
            this.metroLabel12.TabIndex = 180;
            this.metroLabel12.Text = "Product ID";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.ControlLight;
            // 
            // 
            // 
            this.txtID.CustomButton.Image = null;
            this.txtID.CustomButton.Location = new System.Drawing.Point(231, 1);
            this.txtID.CustomButton.Name = "";
            this.txtID.CustomButton.Size = new System.Drawing.Size(16, 17);
            this.txtID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtID.CustomButton.TabIndex = 1;
            this.txtID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtID.CustomButton.UseSelectable = true;
            this.txtID.CustomButton.Visible = false;
            this.txtID.Enabled = false;
            this.txtID.Lines = new string[0];
            this.txtID.Location = new System.Drawing.Point(162, 385);
            this.txtID.MaxLength = 32767;
            this.txtID.Name = "txtID";
            this.txtID.PasswordChar = '\0';
            this.txtID.ReadOnly = true;
            this.txtID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtID.SelectedText = "";
            this.txtID.SelectionLength = 0;
            this.txtID.SelectionStart = 0;
            this.txtID.ShortcutsEnabled = true;
            this.txtID.Size = new System.Drawing.Size(330, 23);
            this.txtID.TabIndex = 179;
            this.txtID.UseCustomBackColor = true;
            this.txtID.UseSelectable = true;
            this.txtID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(511, 487);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(94, 19);
            this.metroLabel5.TabIndex = 177;
            this.metroLabel5.Text = "Product Brand";
            // 
            // cbProductBrand
            // 
            this.cbProductBrand.Enabled = false;
            this.cbProductBrand.FormattingEnabled = true;
            this.cbProductBrand.ItemHeight = 23;
            this.cbProductBrand.Location = new System.Drawing.Point(638, 487);
            this.cbProductBrand.Name = "cbProductBrand";
            this.cbProductBrand.Size = new System.Drawing.Size(222, 29);
            this.cbProductBrand.TabIndex = 176;
            this.cbProductBrand.UseSelectable = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(511, 454);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(91, 19);
            this.metroLabel3.TabIndex = 175;
            this.metroLabel3.Text = "Product Types";
            // 
            // cbProductTypes
            // 
            this.cbProductTypes.Enabled = false;
            this.cbProductTypes.FormattingEnabled = true;
            this.cbProductTypes.ItemHeight = 23;
            this.cbProductTypes.Location = new System.Drawing.Point(638, 453);
            this.cbProductTypes.Name = "cbProductTypes";
            this.cbProductTypes.Size = new System.Drawing.Size(222, 29);
            this.cbProductTypes.TabIndex = 174;
            this.cbProductTypes.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(511, 416);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(122, 19);
            this.metroLabel1.TabIndex = 173;
            this.metroLabel1.Text = "Product Categories";
            // 
            // cbCategories
            // 
            this.cbCategories.Enabled = false;
            this.cbCategories.FormattingEnabled = true;
            this.cbCategories.ItemHeight = 23;
            this.cbCategories.Location = new System.Drawing.Point(638, 416);
            this.cbCategories.Name = "cbCategories";
            this.cbCategories.Size = new System.Drawing.Size(222, 29);
            this.cbCategories.TabIndex = 172;
            this.cbCategories.UseSelectable = true;
            this.cbCategories.SelectedIndexChanged += new System.EventHandler(this.cbCategories_SelectedIndexChanged);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(15, 416);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(95, 19);
            this.metroLabel6.TabIndex = 169;
            this.metroLabel6.Text = "Product Name";
            // 
            // txtProductName
            // 
            // 
            // 
            // 
            this.txtProductName.CustomButton.Image = null;
            this.txtProductName.CustomButton.Location = new System.Drawing.Point(231, 1);
            this.txtProductName.CustomButton.Name = "";
            this.txtProductName.CustomButton.Size = new System.Drawing.Size(16, 17);
            this.txtProductName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtProductName.CustomButton.TabIndex = 1;
            this.txtProductName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtProductName.CustomButton.UseSelectable = true;
            this.txtProductName.CustomButton.Visible = false;
            this.txtProductName.Enabled = false;
            this.txtProductName.Lines = new string[0];
            this.txtProductName.Location = new System.Drawing.Point(161, 418);
            this.txtProductName.MaxLength = 32767;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.PasswordChar = '\0';
            this.txtProductName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtProductName.SelectedText = "";
            this.txtProductName.SelectionLength = 0;
            this.txtProductName.SelectionStart = 0;
            this.txtProductName.ShortcutsEnabled = true;
            this.txtProductName.Size = new System.Drawing.Size(330, 23);
            this.txtProductName.TabIndex = 168;
            this.txtProductName.UseSelectable = true;
            this.txtProductName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtProductName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.flowLayoutPanel1.Controls.Add(this.lblPCD);
            this.flowLayoutPanel1.Controls.Add(this.txtPCD);
            this.flowLayoutPanel1.Controls.Add(this.lblMFLM);
            this.flowLayoutPanel1.Controls.Add(this.txtMFLM);
            this.flowLayoutPanel1.Controls.Add(this.lblOffsetCenterBore);
            this.flowLayoutPanel1.Controls.Add(this.txtOffsetCenterBore);
            this.flowLayoutPanel1.Controls.Add(this.lblOrigin);
            this.flowLayoutPanel1.Controls.Add(this.txtOrigin);
            this.flowLayoutPanel1.Controls.Add(this.lblPattern);
            this.flowLayoutPanel1.Controls.Add(this.txtPattern);
            this.flowLayoutPanel1.Controls.Add(this.lblPR);
            this.flowLayoutPanel1.Controls.Add(this.txtPR);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(877, 389);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(257, 331);
            this.flowLayoutPanel1.TabIndex = 193;
            // 
            // lblPCD
            // 
            this.lblPCD.Location = new System.Drawing.Point(3, 0);
            this.lblPCD.Name = "lblPCD";
            this.lblPCD.Size = new System.Drawing.Size(242, 23);
            this.lblPCD.TabIndex = 158;
            this.lblPCD.Text = "PCD";
            // 
            // txtPCD
            // 
            // 
            // 
            // 
            this.txtPCD.CustomButton.Image = null;
            this.txtPCD.CustomButton.Location = new System.Drawing.Point(165, 1);
            this.txtPCD.CustomButton.Name = "";
            this.txtPCD.CustomButton.Size = new System.Drawing.Size(16, 17);
            this.txtPCD.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPCD.CustomButton.TabIndex = 1;
            this.txtPCD.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPCD.CustomButton.UseSelectable = true;
            this.txtPCD.CustomButton.Visible = false;
            this.txtPCD.Enabled = false;
            this.txtPCD.Lines = new string[0];
            this.txtPCD.Location = new System.Drawing.Point(3, 26);
            this.txtPCD.MaxLength = 32767;
            this.txtPCD.Name = "txtPCD";
            this.txtPCD.PasswordChar = '\0';
            this.txtPCD.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPCD.SelectedText = "";
            this.txtPCD.SelectionLength = 0;
            this.txtPCD.SelectionStart = 0;
            this.txtPCD.ShortcutsEnabled = true;
            this.txtPCD.Size = new System.Drawing.Size(242, 23);
            this.txtPCD.TabIndex = 157;
            this.txtPCD.UseSelectable = true;
            this.txtPCD.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPCD.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblMFLM
            // 
            this.lblMFLM.AutoSize = true;
            this.lblMFLM.Location = new System.Drawing.Point(3, 52);
            this.lblMFLM.Name = "lblMFLM";
            this.lblMFLM.Size = new System.Drawing.Size(51, 19);
            this.lblMFLM.TabIndex = 160;
            this.lblMFLM.Text = "MF/LM";
            // 
            // txtMFLM
            // 
            // 
            // 
            // 
            this.txtMFLM.CustomButton.Image = null;
            this.txtMFLM.CustomButton.Location = new System.Drawing.Point(165, 1);
            this.txtMFLM.CustomButton.Name = "";
            this.txtMFLM.CustomButton.Size = new System.Drawing.Size(16, 17);
            this.txtMFLM.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMFLM.CustomButton.TabIndex = 1;
            this.txtMFLM.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMFLM.CustomButton.UseSelectable = true;
            this.txtMFLM.CustomButton.Visible = false;
            this.txtMFLM.Enabled = false;
            this.txtMFLM.Lines = new string[0];
            this.txtMFLM.Location = new System.Drawing.Point(3, 74);
            this.txtMFLM.MaxLength = 32767;
            this.txtMFLM.Name = "txtMFLM";
            this.txtMFLM.PasswordChar = '\0';
            this.txtMFLM.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMFLM.SelectedText = "";
            this.txtMFLM.SelectionLength = 0;
            this.txtMFLM.SelectionStart = 0;
            this.txtMFLM.ShortcutsEnabled = true;
            this.txtMFLM.Size = new System.Drawing.Size(242, 23);
            this.txtMFLM.TabIndex = 159;
            this.txtMFLM.UseSelectable = true;
            this.txtMFLM.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMFLM.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblOffsetCenterBore
            // 
            this.lblOffsetCenterBore.Location = new System.Drawing.Point(3, 100);
            this.lblOffsetCenterBore.Name = "lblOffsetCenterBore";
            this.lblOffsetCenterBore.Size = new System.Drawing.Size(242, 23);
            this.lblOffsetCenterBore.TabIndex = 162;
            this.lblOffsetCenterBore.Text = "Offset/CenterBore";
            // 
            // txtOffsetCenterBore
            // 
            // 
            // 
            // 
            this.txtOffsetCenterBore.CustomButton.Image = null;
            this.txtOffsetCenterBore.CustomButton.Location = new System.Drawing.Point(165, 1);
            this.txtOffsetCenterBore.CustomButton.Name = "";
            this.txtOffsetCenterBore.CustomButton.Size = new System.Drawing.Size(16, 17);
            this.txtOffsetCenterBore.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtOffsetCenterBore.CustomButton.TabIndex = 1;
            this.txtOffsetCenterBore.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtOffsetCenterBore.CustomButton.UseSelectable = true;
            this.txtOffsetCenterBore.CustomButton.Visible = false;
            this.txtOffsetCenterBore.Enabled = false;
            this.txtOffsetCenterBore.Lines = new string[0];
            this.txtOffsetCenterBore.Location = new System.Drawing.Point(3, 126);
            this.txtOffsetCenterBore.MaxLength = 32767;
            this.txtOffsetCenterBore.Name = "txtOffsetCenterBore";
            this.txtOffsetCenterBore.PasswordChar = '\0';
            this.txtOffsetCenterBore.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtOffsetCenterBore.SelectedText = "";
            this.txtOffsetCenterBore.SelectionLength = 0;
            this.txtOffsetCenterBore.SelectionStart = 0;
            this.txtOffsetCenterBore.ShortcutsEnabled = true;
            this.txtOffsetCenterBore.Size = new System.Drawing.Size(242, 23);
            this.txtOffsetCenterBore.TabIndex = 161;
            this.txtOffsetCenterBore.UseSelectable = true;
            this.txtOffsetCenterBore.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtOffsetCenterBore.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblOrigin
            // 
            this.lblOrigin.Location = new System.Drawing.Point(3, 152);
            this.lblOrigin.Name = "lblOrigin";
            this.lblOrigin.Size = new System.Drawing.Size(242, 23);
            this.lblOrigin.TabIndex = 164;
            this.lblOrigin.Text = "Origin";
            // 
            // txtOrigin
            // 
            // 
            // 
            // 
            this.txtOrigin.CustomButton.Image = null;
            this.txtOrigin.CustomButton.Location = new System.Drawing.Point(165, 1);
            this.txtOrigin.CustomButton.Name = "";
            this.txtOrigin.CustomButton.Size = new System.Drawing.Size(16, 17);
            this.txtOrigin.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtOrigin.CustomButton.TabIndex = 1;
            this.txtOrigin.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtOrigin.CustomButton.UseSelectable = true;
            this.txtOrigin.CustomButton.Visible = false;
            this.txtOrigin.Enabled = false;
            this.txtOrigin.Lines = new string[0];
            this.txtOrigin.Location = new System.Drawing.Point(3, 178);
            this.txtOrigin.MaxLength = 32767;
            this.txtOrigin.Name = "txtOrigin";
            this.txtOrigin.PasswordChar = '\0';
            this.txtOrigin.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtOrigin.SelectedText = "";
            this.txtOrigin.SelectionLength = 0;
            this.txtOrigin.SelectionStart = 0;
            this.txtOrigin.ShortcutsEnabled = true;
            this.txtOrigin.Size = new System.Drawing.Size(242, 23);
            this.txtOrigin.TabIndex = 163;
            this.txtOrigin.UseSelectable = true;
            this.txtOrigin.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtOrigin.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblPattern
            // 
            this.lblPattern.Location = new System.Drawing.Point(3, 204);
            this.lblPattern.Name = "lblPattern";
            this.lblPattern.Size = new System.Drawing.Size(242, 23);
            this.lblPattern.TabIndex = 168;
            this.lblPattern.Text = "Pattern";
            // 
            // txtPattern
            // 
            // 
            // 
            // 
            this.txtPattern.CustomButton.Image = null;
            this.txtPattern.CustomButton.Location = new System.Drawing.Point(165, 1);
            this.txtPattern.CustomButton.Name = "";
            this.txtPattern.CustomButton.Size = new System.Drawing.Size(16, 17);
            this.txtPattern.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPattern.CustomButton.TabIndex = 1;
            this.txtPattern.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPattern.CustomButton.UseSelectable = true;
            this.txtPattern.CustomButton.Visible = false;
            this.txtPattern.Enabled = false;
            this.txtPattern.Lines = new string[0];
            this.txtPattern.Location = new System.Drawing.Point(3, 230);
            this.txtPattern.MaxLength = 32767;
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.PasswordChar = '\0';
            this.txtPattern.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPattern.SelectedText = "";
            this.txtPattern.SelectionLength = 0;
            this.txtPattern.SelectionStart = 0;
            this.txtPattern.ShortcutsEnabled = true;
            this.txtPattern.Size = new System.Drawing.Size(242, 23);
            this.txtPattern.TabIndex = 167;
            this.txtPattern.UseSelectable = true;
            this.txtPattern.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPattern.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblPR
            // 
            this.lblPR.Location = new System.Drawing.Point(3, 256);
            this.lblPR.Name = "lblPR";
            this.lblPR.Size = new System.Drawing.Size(242, 23);
            this.lblPR.TabIndex = 170;
            this.lblPR.Text = "PR";
            // 
            // txtPR
            // 
            // 
            // 
            // 
            this.txtPR.CustomButton.Image = null;
            this.txtPR.CustomButton.Location = new System.Drawing.Point(165, 1);
            this.txtPR.CustomButton.Name = "";
            this.txtPR.CustomButton.Size = new System.Drawing.Size(16, 17);
            this.txtPR.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPR.CustomButton.TabIndex = 1;
            this.txtPR.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPR.CustomButton.UseSelectable = true;
            this.txtPR.CustomButton.Visible = false;
            this.txtPR.Enabled = false;
            this.txtPR.Lines = new string[0];
            this.txtPR.Location = new System.Drawing.Point(3, 282);
            this.txtPR.MaxLength = 32767;
            this.txtPR.Name = "txtPR";
            this.txtPR.PasswordChar = '\0';
            this.txtPR.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPR.SelectedText = "";
            this.txtPR.SelectionLength = 0;
            this.txtPR.SelectionStart = 0;
            this.txtPR.ShortcutsEnabled = true;
            this.txtPR.Size = new System.Drawing.Size(242, 23);
            this.txtPR.TabIndex = 169;
            this.txtPR.UseSelectable = true;
            this.txtPR.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPR.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnClearProduct
            // 
            this.btnClearProduct.Location = new System.Drawing.Point(676, 633);
            this.btnClearProduct.Name = "btnClearProduct";
            this.btnClearProduct.Size = new System.Drawing.Size(94, 23);
            this.btnClearProduct.TabIndex = 199;
            this.btnClearProduct.Text = "Clear Product";
            this.btnClearProduct.UseSelectable = true;
            this.btnClearProduct.Click += new System.EventHandler(this.btnClearProduct_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(784, 633);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(75, 23);
            this.btnAddProduct.TabIndex = 198;
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.UseSelectable = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // txtRemainingCount
            // 
            // 
            // 
            // 
            this.txtRemainingCount.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtRemainingCount.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtRemainingCount.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtRemainingCount.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtRemainingCount.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtRemainingCount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtRemainingCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRemainingCount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtRemainingCount.Increment = 1D;
            this.txtRemainingCount.IsInputReadOnly = true;
            this.txtRemainingCount.Location = new System.Drawing.Point(638, 592);
            this.txtRemainingCount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRemainingCount.MinimumSize = new System.Drawing.Size(0, 23);
            this.txtRemainingCount.Name = "txtRemainingCount";
            this.txtRemainingCount.Size = new System.Drawing.Size(221, 23);
            this.txtRemainingCount.TabIndex = 202;
            // 
            // metroLabel15
            // 
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.Location = new System.Drawing.Point(511, 593);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Size = new System.Drawing.Size(110, 19);
            this.metroLabel15.TabIndex = 201;
            this.metroLabel15.Text = "Remaining Count";
            // 
            // metroLabel16
            // 
            this.metroLabel16.Location = new System.Drawing.Point(406, 734);
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Size = new System.Drawing.Size(86, 16);
            this.metroLabel16.TabIndex = 204;
            this.metroLabel16.Text = "...................";
            // 
            // metroLabel17
            // 
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.Location = new System.Drawing.Point(1201, 373);
            this.metroLabel17.Name = "metroLabel17";
            this.metroLabel17.Size = new System.Drawing.Size(42, 19);
            this.metroLabel17.TabIndex = 205;
            this.metroLabel17.Text = "|||||||||||";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(15, 619);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(58, 19);
            this.metroLabel4.TabIndex = 195;
            this.metroLabel4.Text = "Quantity";
            // 
            // txtTotalPrice
            // 
            // 
            // 
            // 
            this.txtTotalPrice.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTotalPrice.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtTotalPrice.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTotalPrice.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTotalPrice.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTotalPrice.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotalPrice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotalPrice.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotalPrice.Increment = 1D;
            this.txtTotalPrice.IsInputReadOnly = true;
            this.txtTotalPrice.Location = new System.Drawing.Point(161, 654);
            this.txtTotalPrice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTotalPrice.MinimumSize = new System.Drawing.Size(0, 23);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(329, 23);
            this.txtTotalPrice.TabIndex = 196;
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(15, 654);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(69, 19);
            this.metroLabel11.TabIndex = 197;
            this.metroLabel11.Text = "Total Price";
            // 
            // txtQuantity
            // 
            // 
            // 
            // 
            this.txtQuantity.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtQuantity.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtQuantity.Location = new System.Drawing.Point(161, 624);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.ShowUpDown = true;
            this.txtQuantity.Size = new System.Drawing.Size(329, 20);
            this.txtQuantity.TabIndex = 203;
            this.txtQuantity.ValueChanged += new System.EventHandler(this.txtQuantity_ValueChanged_1);
            // 
            // metroLabel18
            // 
            this.metroLabel18.AutoSize = true;
            this.metroLabel18.Location = new System.Drawing.Point(15, 588);
            this.metroLabel18.Name = "metroLabel18";
            this.metroLabel18.Size = new System.Drawing.Size(80, 19);
            this.metroLabel18.TabIndex = 206;
            this.metroLabel18.Text = "Selling Price";
            // 
            // txtSellingPrice
            // 
            // 
            // 
            // 
            this.txtSellingPrice.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtSellingPrice.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtSellingPrice.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtSellingPrice.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtSellingPrice.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtSellingPrice.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtSellingPrice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSellingPrice.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtSellingPrice.Increment = 1D;
            this.txtSellingPrice.IsInputReadOnly = true;
            this.txtSellingPrice.Location = new System.Drawing.Point(161, 588);
            this.txtSellingPrice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSellingPrice.MinimumSize = new System.Drawing.Size(0, 23);
            this.txtSellingPrice.Name = "txtSellingPrice";
            this.txtSellingPrice.Size = new System.Drawing.Size(330, 23);
            this.txtSellingPrice.TabIndex = 207;
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.Location = new System.Drawing.Point(15, 555);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(65, 19);
            this.metroLabel13.TabIndex = 190;
            this.metroLabel13.Text = "Unit Price";
            // 
            // txtUnitPrice
            // 
            // 
            // 
            // 
            this.txtUnitPrice.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtUnitPrice.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtUnitPrice.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtUnitPrice.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtUnitPrice.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtUnitPrice.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtUnitPrice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUnitPrice.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtUnitPrice.Increment = 1D;
            this.txtUnitPrice.IsInputReadOnly = true;
            this.txtUnitPrice.Location = new System.Drawing.Point(161, 555);
            this.txtUnitPrice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUnitPrice.MinimumSize = new System.Drawing.Size(0, 23);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(330, 23);
            this.txtUnitPrice.TabIndex = 200;
            this.txtUnitPrice.ValueChanged += new System.EventHandler(this.txtUnitPrice_ValueChanged_1);
            // 
            // frmChooseProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1236, 769);
            this.Controls.Add(this.txtSellingPrice);
            this.Controls.Add(this.metroLabel18);
            this.Controls.Add(this.metroLabel17);
            this.Controls.Add(this.metroLabel16);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtRemainingCount);
            this.Controls.Add(this.metroLabel15);
            this.Controls.Add(this.txtUnitPrice);
            this.Controls.Add(this.btnClearProduct);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.metroLabel11);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.metroLabel14);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.metroLabel13);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.cbProductUnit);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.cbPriceType);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.cbSize);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.cbColor);
            this.Controls.Add(this.metroLabel12);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.cbProductBrand);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.cbProductTypes);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.cbCategories);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtCriteria);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmChooseProduct";
            this.Padding = new System.Windows.Forms.Padding(15, 60, 15, 16);
            this.Text = "frmChooseProduct";
            this.Load += new System.EventHandler(this.frmChooseProduct_Load);
            this.metroPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgProduct)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemainingCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSellingPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgProduct;
        private MetroFramework.Controls.MetroButton btnSearch;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtCriteria;
        private MetroFramework.Controls.MetroLabel metroLabel14;
        private MetroFramework.Controls.MetroTextBox txtCode;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroComboBox cbProductUnit;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroComboBox cbPriceType;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroComboBox cbSize;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroComboBox cbColor;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroTextBox txtID;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroComboBox cbProductBrand;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox cbProductTypes;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox cbCategories;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox txtProductName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MetroFramework.Controls.MetroButton btnClearProduct;
        private MetroFramework.Controls.MetroButton btnAddProduct;
        private MetroFramework.Controls.MetroLabel lblPCD;
        private MetroFramework.Controls.MetroTextBox txtPCD;
        private MetroFramework.Controls.MetroLabel lblMFLM;
        private MetroFramework.Controls.MetroTextBox txtMFLM;
        private MetroFramework.Controls.MetroLabel lblOffsetCenterBore;
        private MetroFramework.Controls.MetroTextBox txtOffsetCenterBore;
        private MetroFramework.Controls.MetroLabel lblOrigin;
        private MetroFramework.Controls.MetroTextBox txtOrigin;
        private MetroFramework.Controls.MetroLabel lblPattern;
        private MetroFramework.Controls.MetroTextBox txtPattern;
        private MetroFramework.Controls.MetroLabel lblPR;
        private MetroFramework.Controls.MetroTextBox txtPR;
        private DevComponents.Editors.DoubleInput txtRemainingCount;
        private MetroFramework.Controls.MetroLabel metroLabel15;
        private MetroFramework.Controls.MetroLabel metroLabel16;
        private MetroFramework.Controls.MetroLabel metroLabel17;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private DevComponents.Editors.DoubleInput txtTotalPrice;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private DevComponents.Editors.IntegerInput txtQuantity;
        private MetroFramework.Controls.MetroLabel metroLabel18;
        private DevComponents.Editors.DoubleInput txtSellingPrice;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private DevComponents.Editors.DoubleInput txtUnitPrice;
    }
}