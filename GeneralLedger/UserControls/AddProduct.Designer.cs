namespace GeneralLedger.UserControls
{
    partial class AddProduct
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProduct));
            this.txtProductName = new MetroFramework.Controls.MetroTextBox();
            this.txtDescription = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.cbCharacteristic = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.cbCategories = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.cbProductTypes = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.cbProductBrand = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.txtPerPiecePerBox = new MetroFramework.Controls.MetroTextBox();
            this.panelForGrid = new MetroFramework.Controls.MetroPanel();
            this.dgProductColorAndProductSize = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ProductDetailsID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SizeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Minimum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Retail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wholesale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Markup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddColorAndSize = new MetroFramework.Controls.MetroButton();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.cbLocation = new MetroFramework.Controls.MetroComboBox();
            this.btnDeleteColorSize = new MetroFramework.Controls.MetroButton();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.txtID = new MetroFramework.Controls.MetroTextBox();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.btnDelete = new MetroFramework.Controls.MetroButton();
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.btnFindProduct = new MetroFramework.Controls.MetroButton();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.cbSize = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel14 = new MetroFramework.Controls.MetroLabel();
            this.cbColor = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel15 = new MetroFramework.Controls.MetroLabel();
            this.txtWholesale = new DevComponents.Editors.DoubleInput();
            this.metroLabel16 = new MetroFramework.Controls.MetroLabel();
            this.txtRetail = new DevComponents.Editors.DoubleInput();
            this.metroLabel17 = new MetroFramework.Controls.MetroLabel();
            this.txtCost = new DevComponents.Editors.DoubleInput();
            this.txtHeight = new DevComponents.Editors.IntegerInput();
            this.metroLabel18 = new MetroFramework.Controls.MetroLabel();
            this.txtWidth = new DevComponents.Editors.IntegerInput();
            this.metroLabel19 = new MetroFramework.Controls.MetroLabel();
            this.txtLength = new DevComponents.Editors.IntegerInput();
            this.txtMinimun = new DevComponents.Editors.IntegerInput();
            this.metroLabel20 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel21 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel22 = new MetroFramework.Controls.MetroLabel();
            this.txtProductDetailsID = new MetroFramework.Controls.MetroTextBox();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.dataGridViewButtonXColumn1 = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.ClearColorAndSize = new MetroFramework.Controls.MetroButton();
            this.panelForGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductColorAndProductSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWholesale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinimun)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProductName
            // 
            // 
            // 
            // 
            this.txtProductName.CustomButton.Image = null;
            this.txtProductName.CustomButton.Location = new System.Drawing.Point(461, 1);
            this.txtProductName.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtProductName.CustomButton.Name = "";
            this.txtProductName.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtProductName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtProductName.CustomButton.TabIndex = 1;
            this.txtProductName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtProductName.CustomButton.UseSelectable = true;
            this.txtProductName.CustomButton.Visible = false;
            this.txtProductName.Lines = new string[0];
            this.txtProductName.Location = new System.Drawing.Point(229, 130);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtProductName.MaxLength = 32767;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.PasswordChar = '\0';
            this.txtProductName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtProductName.SelectedText = "";
            this.txtProductName.SelectionLength = 0;
            this.txtProductName.SelectionStart = 0;
            this.txtProductName.ShortcutsEnabled = true;
            this.txtProductName.Size = new System.Drawing.Size(495, 35);
            this.txtProductName.TabIndex = 4;
            this.txtProductName.UseSelectable = true;
            this.txtProductName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtProductName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtDescription
            // 
            // 
            // 
            // 
            this.txtDescription.CustomButton.Image = null;
            this.txtDescription.CustomButton.Location = new System.Drawing.Point(345, 2);
            this.txtDescription.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDescription.CustomButton.Name = "";
            this.txtDescription.CustomButton.Size = new System.Drawing.Size(147, 147);
            this.txtDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDescription.CustomButton.TabIndex = 1;
            this.txtDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDescription.CustomButton.UseSelectable = true;
            this.txtDescription.CustomButton.Visible = false;
            this.txtDescription.Lines = new string[0];
            this.txtDescription.Location = new System.Drawing.Point(229, 175);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDescription.MaxLength = 32767;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PasswordChar = '\0';
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDescription.SelectedText = "";
            this.txtDescription.SelectionLength = 0;
            this.txtDescription.SelectionStart = 0;
            this.txtDescription.ShortcutsEnabled = true;
            this.txtDescription.Size = new System.Drawing.Size(495, 152);
            this.txtDescription.TabIndex = 11;
            this.txtDescription.UseSelectable = true;
            this.txtDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(9, 175);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(74, 19);
            this.metroLabel4.TabIndex = 10;
            this.metroLabel4.Text = "Description";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(806, 130);
            this.metroLabel8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(87, 19);
            this.metroLabel8.TabIndex = 17;
            this.metroLabel8.Text = "Characteristic";
            // 
            // cbCharacteristic
            // 
            this.cbCharacteristic.FormattingEnabled = true;
            this.cbCharacteristic.ItemHeight = 23;
            this.cbCharacteristic.Location = new System.Drawing.Point(999, 130);
            this.cbCharacteristic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCharacteristic.Name = "cbCharacteristic";
            this.cbCharacteristic.Size = new System.Drawing.Size(330, 29);
            this.cbCharacteristic.TabIndex = 16;
            this.cbCharacteristic.UseSelectable = true;
            this.cbCharacteristic.SelectedValueChanged += new System.EventHandler(this.cbCharacteristic_SelectedValueChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(806, 181);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(122, 19);
            this.metroLabel2.TabIndex = 19;
            this.metroLabel2.Text = "Product Categories";
            // 
            // cbCategories
            // 
            this.cbCategories.FormattingEnabled = true;
            this.cbCategories.ItemHeight = 23;
            this.cbCategories.Location = new System.Drawing.Point(999, 181);
            this.cbCategories.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCategories.Name = "cbCategories";
            this.cbCategories.Size = new System.Drawing.Size(330, 29);
            this.cbCategories.TabIndex = 18;
            this.cbCategories.UseSelectable = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(806, 234);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(91, 19);
            this.metroLabel3.TabIndex = 21;
            this.metroLabel3.Text = "Product Types";
            // 
            // cbProductTypes
            // 
            this.cbProductTypes.FormattingEnabled = true;
            this.cbProductTypes.ItemHeight = 23;
            this.cbProductTypes.Location = new System.Drawing.Point(999, 234);
            this.cbProductTypes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbProductTypes.Name = "cbProductTypes";
            this.cbProductTypes.Size = new System.Drawing.Size(330, 29);
            this.cbProductTypes.TabIndex = 20;
            this.cbProductTypes.UseSelectable = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(806, 286);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(94, 19);
            this.metroLabel5.TabIndex = 23;
            this.metroLabel5.Text = "Product Brand";
            // 
            // cbProductBrand
            // 
            this.cbProductBrand.FormattingEnabled = true;
            this.cbProductBrand.ItemHeight = 23;
            this.cbProductBrand.Location = new System.Drawing.Point(999, 286);
            this.cbProductBrand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbProductBrand.Name = "cbProductBrand";
            this.cbProductBrand.Size = new System.Drawing.Size(330, 29);
            this.cbProductBrand.TabIndex = 22;
            this.cbProductBrand.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(9, 130);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(95, 19);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "Product Name";
            // 
            // metroLabel6
            // 
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(11, 21);
            this.metroLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(563, 59);
            this.metroLabel6.TabIndex = 24;
            this.metroLabel6.Text = "Basic Information";
            // 
            // metroLabel7
            // 
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel7.Location = new System.Drawing.Point(9, 336);
            this.metroLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(563, 42);
            this.metroLabel7.TabIndex = 33;
            this.metroLabel7.Text = "Inventory Details";
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(35, 385);
            this.metroLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(110, 19);
            this.metroLabel9.TabIndex = 35;
            this.metroLabel9.Text = "Piece/s per box/s";
            // 
            // txtPerPiecePerBox
            // 
            // 
            // 
            // 
            this.txtPerPiecePerBox.CustomButton.Image = null;
            this.txtPerPiecePerBox.CustomButton.Location = new System.Drawing.Point(176, 1);
            this.txtPerPiecePerBox.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPerPiecePerBox.CustomButton.Name = "";
            this.txtPerPiecePerBox.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtPerPiecePerBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPerPiecePerBox.CustomButton.TabIndex = 1;
            this.txtPerPiecePerBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPerPiecePerBox.CustomButton.UseSelectable = true;
            this.txtPerPiecePerBox.CustomButton.Visible = false;
            this.txtPerPiecePerBox.Lines = new string[0];
            this.txtPerPiecePerBox.Location = new System.Drawing.Point(253, 385);
            this.txtPerPiecePerBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPerPiecePerBox.MaxLength = 32767;
            this.txtPerPiecePerBox.Name = "txtPerPiecePerBox";
            this.txtPerPiecePerBox.PasswordChar = '\0';
            this.txtPerPiecePerBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPerPiecePerBox.SelectedText = "";
            this.txtPerPiecePerBox.SelectionLength = 0;
            this.txtPerPiecePerBox.SelectionStart = 0;
            this.txtPerPiecePerBox.ShortcutsEnabled = true;
            this.txtPerPiecePerBox.Size = new System.Drawing.Size(210, 35);
            this.txtPerPiecePerBox.TabIndex = 34;
            this.txtPerPiecePerBox.UseSelectable = true;
            this.txtPerPiecePerBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPerPiecePerBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // panelForGrid
            // 
            this.panelForGrid.Controls.Add(this.dgProductColorAndProductSize);
            this.panelForGrid.HorizontalScrollbarBarColor = true;
            this.panelForGrid.HorizontalScrollbarHighlightOnWheel = false;
            this.panelForGrid.HorizontalScrollbarSize = 10;
            this.panelForGrid.Location = new System.Drawing.Point(5, 605);
            this.panelForGrid.Name = "panelForGrid";
            this.panelForGrid.Size = new System.Drawing.Size(1820, 352);
            this.panelForGrid.TabIndex = 48;
            this.panelForGrid.VerticalScrollbarBarColor = true;
            this.panelForGrid.VerticalScrollbarHighlightOnWheel = false;
            this.panelForGrid.VerticalScrollbarSize = 10;
            // 
            // dgProductColorAndProductSize
            // 
            this.dgProductColorAndProductSize.AllowUserToAddRows = false;
            this.dgProductColorAndProductSize.AllowUserToDeleteRows = false;
            this.dgProductColorAndProductSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgProductColorAndProductSize.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProductColorAndProductSize.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductDetailsID,
            this.gdName,
            this.ColorID,
            this.ProductSize,
            this.SizeID,
            this.Minimum,
            this.Length,
            this.Width,
            this.Height,
            this.Cost,
            this.Retail,
            this.Wholesale,
            this.Markup});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgProductColorAndProductSize.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgProductColorAndProductSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgProductColorAndProductSize.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgProductColorAndProductSize.Location = new System.Drawing.Point(0, 0);
            this.dgProductColorAndProductSize.Name = "dgProductColorAndProductSize";
            this.dgProductColorAndProductSize.ReadOnly = true;
            this.dgProductColorAndProductSize.RowTemplate.Height = 30;
            this.dgProductColorAndProductSize.Size = new System.Drawing.Size(1820, 352);
            this.dgProductColorAndProductSize.TabIndex = 63;
            this.dgProductColorAndProductSize.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProductColorAndProductSize_CellClick);
            // 
            // ProductDetailsID
            // 
            this.ProductDetailsID.HeaderText = "ID";
            this.ProductDetailsID.Name = "ProductDetailsID";
            this.ProductDetailsID.ReadOnly = true;
            // 
            // gdName
            // 
            this.gdName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gdName.HeaderText = "Color";
            this.gdName.Name = "gdName";
            this.gdName.ReadOnly = true;
            this.gdName.Width = 82;
            // 
            // ColorID
            // 
            this.ColorID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColorID.HeaderText = "ColorID";
            this.ColorID.Name = "ColorID";
            this.ColorID.ReadOnly = true;
            this.ColorID.Width = 99;
            // 
            // ProductSize
            // 
            this.ProductSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ProductSize.HeaderText = "Size";
            this.ProductSize.Name = "ProductSize";
            this.ProductSize.ReadOnly = true;
            this.ProductSize.Width = 76;
            // 
            // SizeID
            // 
            this.SizeID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SizeID.HeaderText = "SizeID";
            this.SizeID.Name = "SizeID";
            this.SizeID.ReadOnly = true;
            this.SizeID.Width = 93;
            // 
            // Minimum
            // 
            this.Minimum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Minimum.HeaderText = "Minimum";
            this.Minimum.Name = "Minimum";
            this.Minimum.ReadOnly = true;
            this.Minimum.Width = 108;
            // 
            // Length
            // 
            this.Length.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Length.HeaderText = "Length";
            this.Length.Name = "Length";
            this.Length.ReadOnly = true;
            this.Length.Width = 95;
            // 
            // Width
            // 
            this.Width.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Width.HeaderText = "Width";
            this.Width.Name = "Width";
            this.Width.ReadOnly = true;
            this.Width.Width = 86;
            // 
            // Height
            // 
            this.Height.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Height.HeaderText = "Height";
            this.Height.Name = "Height";
            this.Height.ReadOnly = true;
            this.Height.Width = 92;
            // 
            // Cost
            // 
            this.Cost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cost.HeaderText = "Cost";
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            this.Cost.Width = 78;
            // 
            // Retail
            // 
            this.Retail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Retail.HeaderText = "Retail";
            this.Retail.Name = "Retail";
            this.Retail.ReadOnly = true;
            this.Retail.Width = 86;
            // 
            // Wholesale
            // 
            this.Wholesale.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Wholesale.HeaderText = "Wholesale";
            this.Wholesale.Name = "Wholesale";
            this.Wholesale.ReadOnly = true;
            this.Wholesale.Width = 119;
            // 
            // Markup
            // 
            this.Markup.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Markup.FillWeight = 60F;
            this.Markup.HeaderText = "Markup";
            this.Markup.Name = "Markup";
            this.Markup.ReadOnly = true;
            this.Markup.Width = 98;
            // 
            // btnAddColorAndSize
            // 
            this.btnAddColorAndSize.Location = new System.Drawing.Point(1035, 1244);
            this.btnAddColorAndSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddColorAndSize.Name = "btnAddColorAndSize";
            this.btnAddColorAndSize.Size = new System.Drawing.Size(210, 35);
            this.btnAddColorAndSize.TabIndex = 56;
            this.btnAddColorAndSize.Text = "Save Color and Size";
            this.btnAddColorAndSize.UseSelectable = true;
            this.btnAddColorAndSize.Click += new System.EventHandler(this.btnAddColorAndSize_Click);
            // 
            // metroLabel10
            // 
            this.metroLabel10.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel10.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel10.Location = new System.Drawing.Point(17, 547);
            this.metroLabel10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(563, 42);
            this.metroLabel10.TabIndex = 57;
            this.metroLabel10.Text = "Color and Size";
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(547, 385);
            this.metroLabel11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(58, 19);
            this.metroLabel11.TabIndex = 59;
            this.metroLabel11.Text = "Location";
            // 
            // cbLocation
            // 
            this.cbLocation.FormattingEnabled = true;
            this.cbLocation.ItemHeight = 23;
            this.cbLocation.Location = new System.Drawing.Point(740, 385);
            this.cbLocation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.Size = new System.Drawing.Size(330, 29);
            this.cbLocation.TabIndex = 58;
            this.cbLocation.UseSelectable = true;
            // 
            // btnDeleteColorSize
            // 
            this.btnDeleteColorSize.Location = new System.Drawing.Point(1251, 1244);
            this.btnDeleteColorSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeleteColorSize.Name = "btnDeleteColorSize";
            this.btnDeleteColorSize.Size = new System.Drawing.Size(210, 35);
            this.btnDeleteColorSize.TabIndex = 63;
            this.btnDeleteColorSize.Text = "Delete Color and Size";
            this.btnDeleteColorSize.UseSelectable = true;
            this.btnDeleteColorSize.Click += new System.EventHandler(this.btnDeleteColorSize_Click_1);
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.Location = new System.Drawing.Point(9, 85);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(71, 19);
            this.metroLabel12.TabIndex = 66;
            this.metroLabel12.Text = "Product ID";
            this.metroLabel12.Click += new System.EventHandler(this.metroLabel12_Click);
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.ControlLight;
            // 
            // 
            // 
            this.txtID.CustomButton.Image = null;
            this.txtID.CustomButton.Location = new System.Drawing.Point(461, 1);
            this.txtID.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtID.CustomButton.Name = "";
            this.txtID.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtID.CustomButton.TabIndex = 1;
            this.txtID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtID.CustomButton.UseSelectable = true;
            this.txtID.CustomButton.Visible = false;
            this.txtID.Enabled = false;
            this.txtID.Lines = new string[0];
            this.txtID.Location = new System.Drawing.Point(229, 85);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtID.MaxLength = 32767;
            this.txtID.Name = "txtID";
            this.txtID.PasswordChar = '\0';
            this.txtID.ReadOnly = true;
            this.txtID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtID.SelectedText = "";
            this.txtID.SelectionLength = 0;
            this.txtID.SelectionStart = 0;
            this.txtID.ShortcutsEnabled = true;
            this.txtID.Size = new System.Drawing.Size(495, 35);
            this.txtID.TabIndex = 65;
            this.txtID.UseCustomBackColor = true;
            this.txtID.UseSelectable = true;
            this.txtID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(856, 478);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(148, 35);
            this.btnSave.TabIndex = 60;
            this.btnSave.Text = "Save Product";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1016, 478);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(148, 35);
            this.btnDelete.TabIndex = 61;
            this.btnDelete.Text = "Delete Product";
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(692, 478);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(148, 35);
            this.btnClear.TabIndex = 62;
            this.btnClear.Text = "Clear";
            this.btnClear.UseSelectable = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnFindProduct
            // 
            this.btnFindProduct.Location = new System.Drawing.Point(1181, 478);
            this.btnFindProduct.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFindProduct.Name = "btnFindProduct";
            this.btnFindProduct.Size = new System.Drawing.Size(148, 35);
            this.btnFindProduct.TabIndex = 64;
            this.btnFindProduct.Text = "Find Product";
            this.btnFindProduct.UseSelectable = true;
            this.btnFindProduct.Click += new System.EventHandler(this.btnFindProduct_Click);
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.Location = new System.Drawing.Point(672, 989);
            this.metroLabel13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(32, 19);
            this.metroLabel13.TabIndex = 84;
            this.metroLabel13.Text = "Size";
            // 
            // cbSize
            // 
            this.cbSize.FormattingEnabled = true;
            this.cbSize.ItemHeight = 23;
            this.cbSize.Location = new System.Drawing.Point(816, 985);
            this.cbSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbSize.Name = "cbSize";
            this.cbSize.Size = new System.Drawing.Size(397, 29);
            this.cbSize.TabIndex = 83;
            this.cbSize.UseSelectable = true;
            // 
            // metroLabel14
            // 
            this.metroLabel14.AutoSize = true;
            this.metroLabel14.Location = new System.Drawing.Point(48, 1034);
            this.metroLabel14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Size = new System.Drawing.Size(42, 19);
            this.metroLabel14.TabIndex = 82;
            this.metroLabel14.Text = "Color";
            // 
            // cbColor
            // 
            this.cbColor.FormattingEnabled = true;
            this.cbColor.ItemHeight = 23;
            this.cbColor.Location = new System.Drawing.Point(175, 1034);
            this.cbColor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(397, 29);
            this.cbColor.TabIndex = 81;
            this.cbColor.UseSelectable = true;
            // 
            // metroLabel15
            // 
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.Location = new System.Drawing.Point(672, 1179);
            this.metroLabel15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Size = new System.Drawing.Size(69, 19);
            this.metroLabel15.TabIndex = 80;
            this.metroLabel15.Text = "Wholesale";
            // 
            // txtWholesale
            // 
            // 
            // 
            // 
            this.txtWholesale.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtWholesale.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtWholesale.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtWholesale.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtWholesale.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtWholesale.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtWholesale.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWholesale.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtWholesale.Increment = 1D;
            this.txtWholesale.Location = new System.Drawing.Point(816, 1179);
            this.txtWholesale.MinimumSize = new System.Drawing.Size(0, 35);
            this.txtWholesale.Name = "txtWholesale";
            this.txtWholesale.ShowUpDown = true;
            this.txtWholesale.Size = new System.Drawing.Size(397, 35);
            this.txtWholesale.TabIndex = 79;
            // 
            // metroLabel16
            // 
            this.metroLabel16.AutoSize = true;
            this.metroLabel16.Location = new System.Drawing.Point(672, 1115);
            this.metroLabel16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Size = new System.Drawing.Size(41, 19);
            this.metroLabel16.TabIndex = 78;
            this.metroLabel16.Text = "Retail";
            // 
            // txtRetail
            // 
            // 
            // 
            // 
            this.txtRetail.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtRetail.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtRetail.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtRetail.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtRetail.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtRetail.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtRetail.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRetail.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtRetail.Increment = 1D;
            this.txtRetail.Location = new System.Drawing.Point(816, 1115);
            this.txtRetail.MinimumSize = new System.Drawing.Size(0, 35);
            this.txtRetail.Name = "txtRetail";
            this.txtRetail.ShowUpDown = true;
            this.txtRetail.Size = new System.Drawing.Size(397, 35);
            this.txtRetail.TabIndex = 77;
            // 
            // metroLabel17
            // 
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.Location = new System.Drawing.Point(672, 1049);
            this.metroLabel17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel17.Name = "metroLabel17";
            this.metroLabel17.Size = new System.Drawing.Size(35, 19);
            this.metroLabel17.TabIndex = 76;
            this.metroLabel17.Text = "Cost";
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
            this.txtCost.Location = new System.Drawing.Point(816, 1049);
            this.txtCost.MinimumSize = new System.Drawing.Size(0, 35);
            this.txtCost.Name = "txtCost";
            this.txtCost.ShowUpDown = true;
            this.txtCost.Size = new System.Drawing.Size(397, 35);
            this.txtCost.TabIndex = 75;
            // 
            // txtHeight
            // 
            // 
            // 
            // 
            this.txtHeight.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtHeight.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtHeight.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtHeight.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtHeight.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtHeight.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtHeight.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtHeight.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtHeight.Location = new System.Drawing.Point(175, 1297);
            this.txtHeight.MinimumSize = new System.Drawing.Size(0, 33);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.ShowUpDown = true;
            this.txtHeight.Size = new System.Drawing.Size(397, 33);
            this.txtHeight.TabIndex = 74;
            this.txtHeight.WatermarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            // 
            // metroLabel18
            // 
            this.metroLabel18.AutoSize = true;
            this.metroLabel18.Location = new System.Drawing.Point(48, 1297);
            this.metroLabel18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel18.Name = "metroLabel18";
            this.metroLabel18.Size = new System.Drawing.Size(47, 19);
            this.metroLabel18.TabIndex = 73;
            this.metroLabel18.Text = "Height";
            // 
            // txtWidth
            // 
            // 
            // 
            // 
            this.txtWidth.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtWidth.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtWidth.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtWidth.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtWidth.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtWidth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtWidth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWidth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtWidth.Location = new System.Drawing.Point(175, 1228);
            this.txtWidth.MinimumSize = new System.Drawing.Size(0, 33);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.ShowUpDown = true;
            this.txtWidth.Size = new System.Drawing.Size(397, 33);
            this.txtWidth.TabIndex = 72;
            this.txtWidth.WatermarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            // 
            // metroLabel19
            // 
            this.metroLabel19.AutoSize = true;
            this.metroLabel19.Location = new System.Drawing.Point(48, 1228);
            this.metroLabel19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel19.Name = "metroLabel19";
            this.metroLabel19.Size = new System.Drawing.Size(44, 19);
            this.metroLabel19.TabIndex = 71;
            this.metroLabel19.Text = "Width";
            // 
            // txtLength
            // 
            // 
            // 
            // 
            this.txtLength.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtLength.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtLength.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtLength.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtLength.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtLength.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtLength.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLength.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtLength.Location = new System.Drawing.Point(175, 1164);
            this.txtLength.MinimumSize = new System.Drawing.Size(0, 33);
            this.txtLength.Name = "txtLength";
            this.txtLength.ShowUpDown = true;
            this.txtLength.Size = new System.Drawing.Size(397, 33);
            this.txtLength.TabIndex = 70;
            this.txtLength.WatermarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            // 
            // txtMinimun
            // 
            // 
            // 
            // 
            this.txtMinimun.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtMinimun.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtMinimun.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtMinimun.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtMinimun.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtMinimun.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtMinimun.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMinimun.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtMinimun.Location = new System.Drawing.Point(175, 1098);
            this.txtMinimun.MinimumSize = new System.Drawing.Size(0, 35);
            this.txtMinimun.Name = "txtMinimun";
            this.txtMinimun.ShowUpDown = true;
            this.txtMinimun.Size = new System.Drawing.Size(399, 35);
            this.txtMinimun.TabIndex = 69;
            this.txtMinimun.WatermarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            // 
            // metroLabel20
            // 
            this.metroLabel20.AutoSize = true;
            this.metroLabel20.Location = new System.Drawing.Point(48, 1164);
            this.metroLabel20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel20.Name = "metroLabel20";
            this.metroLabel20.Size = new System.Drawing.Size(48, 19);
            this.metroLabel20.TabIndex = 68;
            this.metroLabel20.Text = "Length";
            // 
            // metroLabel21
            // 
            this.metroLabel21.AutoSize = true;
            this.metroLabel21.Location = new System.Drawing.Point(48, 1098);
            this.metroLabel21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel21.Name = "metroLabel21";
            this.metroLabel21.Size = new System.Drawing.Size(65, 19);
            this.metroLabel21.TabIndex = 67;
            this.metroLabel21.Text = "Minimum";
            // 
            // metroLabel22
            // 
            this.metroLabel22.AutoSize = true;
            this.metroLabel22.Location = new System.Drawing.Point(48, 985);
            this.metroLabel22.Name = "metroLabel22";
            this.metroLabel22.Size = new System.Drawing.Size(21, 19);
            this.metroLabel22.TabIndex = 86;
            this.metroLabel22.Text = "ID";
            // 
            // txtProductDetailsID
            // 
            this.txtProductDetailsID.BackColor = System.Drawing.SystemColors.ControlLight;
            // 
            // 
            // 
            this.txtProductDetailsID.CustomButton.Image = null;
            this.txtProductDetailsID.CustomButton.Location = new System.Drawing.Point(365, 1);
            this.txtProductDetailsID.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtProductDetailsID.CustomButton.Name = "";
            this.txtProductDetailsID.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtProductDetailsID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtProductDetailsID.CustomButton.TabIndex = 1;
            this.txtProductDetailsID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtProductDetailsID.CustomButton.UseSelectable = true;
            this.txtProductDetailsID.CustomButton.Visible = false;
            this.txtProductDetailsID.Enabled = false;
            this.txtProductDetailsID.Lines = new string[0];
            this.txtProductDetailsID.Location = new System.Drawing.Point(175, 985);
            this.txtProductDetailsID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtProductDetailsID.MaxLength = 32767;
            this.txtProductDetailsID.Name = "txtProductDetailsID";
            this.txtProductDetailsID.PasswordChar = '\0';
            this.txtProductDetailsID.ReadOnly = true;
            this.txtProductDetailsID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtProductDetailsID.SelectedText = "";
            this.txtProductDetailsID.SelectionLength = 0;
            this.txtProductDetailsID.SelectionStart = 0;
            this.txtProductDetailsID.ShortcutsEnabled = true;
            this.txtProductDetailsID.Size = new System.Drawing.Size(399, 35);
            this.txtProductDetailsID.TabIndex = 85;
            this.txtProductDetailsID.UseCustomBackColor = true;
            this.txtProductDetailsID.UseSelectable = true;
            this.txtProductDetailsID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtProductDetailsID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
            this.btnClose.Image = global::GeneralLedger.Properties.Resources.cancel;
            this.btnClose.Location = new System.Drawing.Point(1623, 71);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(154, 55);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnClose.TabIndex = 55;
            this.btnClose.Text = "Close Page";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dataGridViewButtonXColumn1
            // 
            this.dataGridViewButtonXColumn1.HeaderText = "Delete";
            this.dataGridViewButtonXColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewButtonXColumn1.Image")));
            this.dataGridViewButtonXColumn1.Name = "dataGridViewButtonXColumn1";
            this.dataGridViewButtonXColumn1.Text = null;
            // 
            // ClearColorAndSize
            // 
            this.ClearColorAndSize.Location = new System.Drawing.Point(817, 1244);
            this.ClearColorAndSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ClearColorAndSize.Name = "ClearColorAndSize";
            this.ClearColorAndSize.Size = new System.Drawing.Size(210, 35);
            this.ClearColorAndSize.TabIndex = 87;
            this.ClearColorAndSize.Text = "Clear Color and Size";
            this.ClearColorAndSize.UseSelectable = true;
            this.ClearColorAndSize.Click += new System.EventHandler(this.ClearColorAndSize_Click);
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.ClearColorAndSize);
            this.Controls.Add(this.metroLabel22);
            this.Controls.Add(this.txtProductDetailsID);
            this.Controls.Add(this.metroLabel13);
            this.Controls.Add(this.cbSize);
            this.Controls.Add(this.metroLabel14);
            this.Controls.Add(this.cbColor);
            this.Controls.Add(this.metroLabel15);
            this.Controls.Add(this.txtWholesale);
            this.Controls.Add(this.metroLabel16);
            this.Controls.Add(this.txtRetail);
            this.Controls.Add(this.metroLabel17);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.metroLabel18);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.metroLabel19);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.txtMinimun);
            this.Controls.Add(this.metroLabel20);
            this.Controls.Add(this.metroLabel21);
            this.Controls.Add(this.metroLabel12);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnFindProduct);
            this.Controls.Add(this.btnDeleteColorSize);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.metroLabel11);
            this.Controls.Add(this.cbLocation);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.btnAddColorAndSize);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panelForGrid);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.txtPerPiecePerBox);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.cbProductBrand);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.cbProductTypes);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.cbCategories);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.cbCharacteristic);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtProductName);
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "AddProduct";
            this.Size = new System.Drawing.Size(1854, 1494);
            this.Load += new System.EventHandler(this.AddProduct_Load);
            this.panelForGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgProductColorAndProductSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWholesale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinimun)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTextBox txtProductName;
        private MetroFramework.Controls.MetroTextBox txtDescription;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroComboBox cbCharacteristic;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroComboBox cbCategories;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox cbProductTypes;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroComboBox cbProductBrand;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroTextBox txtPerPiecePerBox;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn dataGridViewButtonXColumn1;
        private MetroFramework.Controls.MetroPanel panelForGrid;
        private MetroFramework.Controls.MetroButton btnAddColorAndSize;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroComboBox cbLocation;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgProductColorAndProductSize;
        private MetroFramework.Controls.MetroButton btnDeleteColorSize;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroTextBox txtID;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroButton btnDelete;
        private MetroFramework.Controls.MetroButton btnClear;
        private MetroFramework.Controls.MetroButton btnFindProduct;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroComboBox cbSize;
        private MetroFramework.Controls.MetroLabel metroLabel14;
        private MetroFramework.Controls.MetroComboBox cbColor;
        private MetroFramework.Controls.MetroLabel metroLabel15;
        private DevComponents.Editors.DoubleInput txtWholesale;
        private MetroFramework.Controls.MetroLabel metroLabel16;
        private DevComponents.Editors.DoubleInput txtRetail;
        private MetroFramework.Controls.MetroLabel metroLabel17;
        private DevComponents.Editors.DoubleInput txtCost;
        private DevComponents.Editors.IntegerInput txtHeight;
        private MetroFramework.Controls.MetroLabel metroLabel18;
        private DevComponents.Editors.IntegerInput txtWidth;
        private MetroFramework.Controls.MetroLabel metroLabel19;
        private DevComponents.Editors.IntegerInput txtLength;
        private DevComponents.Editors.IntegerInput txtMinimun;
        private MetroFramework.Controls.MetroLabel metroLabel20;
        private MetroFramework.Controls.MetroLabel metroLabel21;
        private MetroFramework.Controls.MetroLabel metroLabel22;
        private MetroFramework.Controls.MetroTextBox txtProductDetailsID;
        private MetroFramework.Controls.MetroButton ClearColorAndSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductDetailsID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Minimum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn Width;
        private System.Windows.Forms.DataGridViewTextBoxColumn Height;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Retail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wholesale;
        private System.Windows.Forms.DataGridViewTextBoxColumn Markup;
    }
}
