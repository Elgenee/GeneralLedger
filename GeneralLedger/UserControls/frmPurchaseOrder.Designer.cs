namespace GeneralLedger.UserControls
{
    partial class frmPurchaseOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchaseOrder));
            this.metroLabel17 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtPONumber = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.dtBatchDate = new MetroFramework.Controls.MetroDateTime();
            this.btnChooseProduct = new MetroFramework.Controls.MetroButton();
            this.dgPurchaseOrderDetails = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ProductDetailsID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbLocation = new MetroFramework.Controls.MetroComboBox();
            this.cbSupplier = new MetroFramework.Controls.MetroComboBox();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.cbNewParts = new DevComponents.DotNetBar.CheckBoxItem();
            this.cbRefurbishedParts = new DevComponents.DotNetBar.CheckBoxItem();
            this.tab2 = new DevComponents.DotNetBar.SuperTabItem();
            this.metroLabel20 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.lblTotalQuantity = new MetroFramework.Controls.MetroLabel();
            this.lblSubtotal = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.txtDiscountAmount = new DevComponents.Editors.DoubleInput();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.txtDiscountPercentage = new DevComponents.Editors.DoubleInput();
            this.lblGrandtotal = new MetroFramework.Controls.MetroLabel();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.chkHasPayment = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.txtAmountPaid = new DevComponents.Editors.DoubleInput();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.lblChange = new MetroFramework.Controls.MetroLabel();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.chkApproved = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox2 = new MetroFramework.Controls.MetroCheckBox();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.btnEditProduct = new MetroFramework.Controls.MetroButton();
            this.btnDeleteProduct = new MetroFramework.Controls.MetroButton();
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.chkAddBalanceToSupplier = new MetroFramework.Controls.MetroCheckBox();
            this.lblTotalReceived = new MetroFramework.Controls.MetroLabel();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgPurchaseOrderDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountPaid)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel17
            // 
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.Location = new System.Drawing.Point(26, 90);
            this.metroLabel17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel17.Name = "metroLabel17";
            this.metroLabel17.Size = new System.Drawing.Size(59, 20);
            this.metroLabel17.TabIndex = 82;
            this.metroLabel17.Text = "Supplier";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(26, 37);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(84, 20);
            this.metroLabel1.TabIndex = 80;
            this.metroLabel1.Text = "PO Number";
            // 
            // txtPONumber
            // 
            // 
            // 
            // 
            this.txtPONumber.CustomButton.Image = null;
            this.txtPONumber.CustomButton.Location = new System.Drawing.Point(234, 2);
            this.txtPONumber.CustomButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPONumber.CustomButton.Name = "";
            this.txtPONumber.CustomButton.Size = new System.Drawing.Size(24, 22);
            this.txtPONumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPONumber.CustomButton.TabIndex = 1;
            this.txtPONumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPONumber.CustomButton.UseSelectable = true;
            this.txtPONumber.CustomButton.Visible = false;
            this.txtPONumber.Lines = new string[0];
            this.txtPONumber.Location = new System.Drawing.Point(149, 37);
            this.txtPONumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPONumber.MaxLength = 32767;
            this.txtPONumber.Name = "txtPONumber";
            this.txtPONumber.PasswordChar = '\0';
            this.txtPONumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPONumber.SelectedText = "";
            this.txtPONumber.SelectionLength = 0;
            this.txtPONumber.SelectionStart = 0;
            this.txtPONumber.ShortcutsEnabled = true;
            this.txtPONumber.Size = new System.Drawing.Size(293, 32);
            this.txtPONumber.TabIndex = 79;
            this.txtPONumber.UseSelectable = true;
            this.txtPONumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPONumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(509, 37);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(61, 20);
            this.metroLabel2.TabIndex = 84;
            this.metroLabel2.Text = "Location";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(509, 90);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(107, 20);
            this.metroLabel3.TabIndex = 86;
            this.metroLabel3.Text = "Date Purchased";
            // 
            // dtBatchDate
            // 
            this.dtBatchDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBatchDate.Location = new System.Drawing.Point(660, 90);
            this.dtBatchDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtBatchDate.MinimumSize = new System.Drawing.Size(0, 30);
            this.dtBatchDate.Name = "dtBatchDate";
            this.dtBatchDate.Size = new System.Drawing.Size(294, 30);
            this.dtBatchDate.TabIndex = 85;
            // 
            // btnChooseProduct
            // 
            this.btnChooseProduct.Location = new System.Drawing.Point(149, 149);
            this.btnChooseProduct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChooseProduct.Name = "btnChooseProduct";
            this.btnChooseProduct.Size = new System.Drawing.Size(132, 28);
            this.btnChooseProduct.TabIndex = 87;
            this.btnChooseProduct.Text = "Choose Product";
            this.btnChooseProduct.UseSelectable = true;
            this.btnChooseProduct.Click += new System.EventHandler(this.btnChooseProduct_Click);
            // 
            // dgPurchaseOrderDetails
            // 
            this.dgPurchaseOrderDetails.AllowUserToAddRows = false;
            this.dgPurchaseOrderDetails.AllowUserToDeleteRows = false;
            this.dgPurchaseOrderDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPurchaseOrderDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPurchaseOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPurchaseOrderDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductDetailsID,
            this.ProductName,
            this.ProductColor,
            this.ProductSize,
            this.CurStock,
            this.ActStock,
            this.Quantity,
            this.QuantityReceived,
            this.Cost,
            this.SubTotal});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPurchaseOrderDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgPurchaseOrderDetails.EnableHeadersVisualStyles = false;
            this.dgPurchaseOrderDetails.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgPurchaseOrderDetails.Location = new System.Drawing.Point(13, 195);
            this.dgPurchaseOrderDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgPurchaseOrderDetails.Name = "dgPurchaseOrderDetails";
            this.dgPurchaseOrderDetails.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPurchaseOrderDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgPurchaseOrderDetails.RowHeadersWidth = 51;
            this.dgPurchaseOrderDetails.RowTemplate.Height = 30;
            this.dgPurchaseOrderDetails.Size = new System.Drawing.Size(1276, 306);
            this.dgPurchaseOrderDetails.TabIndex = 88;
            this.dgPurchaseOrderDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPurchaseOrderDetails_CellClick);
            this.dgPurchaseOrderDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPurchaseOrderDetails_CellContentClick);
            // 
            // ProductDetailsID
            // 
            this.ProductDetailsID.HeaderText = "ProductDetailsID";
            this.ProductDetailsID.MinimumWidth = 6;
            this.ProductDetailsID.Name = "ProductDetailsID";
            this.ProductDetailsID.ReadOnly = true;
            this.ProductDetailsID.Width = 125;
            // 
            // ProductName
            // 
            this.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ProductName.HeaderText = "ProductName";
            this.ProductName.MinimumWidth = 6;
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.Width = 123;
            // 
            // ProductColor
            // 
            this.ProductColor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ProductColor.HeaderText = "ProductColor";
            this.ProductColor.MinimumWidth = 6;
            this.ProductColor.Name = "ProductColor";
            this.ProductColor.ReadOnly = true;
            this.ProductColor.Width = 119;
            // 
            // ProductSize
            // 
            this.ProductSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ProductSize.HeaderText = "ProductSize";
            this.ProductSize.MinimumWidth = 6;
            this.ProductSize.Name = "ProductSize";
            this.ProductSize.ReadOnly = true;
            this.ProductSize.Width = 113;
            // 
            // CurStock
            // 
            this.CurStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CurStock.HeaderText = "CurStock";
            this.CurStock.MinimumWidth = 6;
            this.CurStock.Name = "CurStock";
            this.CurStock.ReadOnly = true;
            this.CurStock.Width = 94;
            // 
            // ActStock
            // 
            this.ActStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ActStock.HeaderText = "ActStock";
            this.ActStock.MinimumWidth = 6;
            this.ActStock.Name = "ActStock";
            this.ActStock.ReadOnly = true;
            this.ActStock.Width = 92;
            // 
            // Quantity
            // 
            this.Quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 90;
            // 
            // QuantityReceived
            // 
            this.QuantityReceived.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.QuantityReceived.HeaderText = "QuantityReceived";
            this.QuantityReceived.MinimumWidth = 6;
            this.QuantityReceived.Name = "QuantityReceived";
            this.QuantityReceived.ReadOnly = true;
            this.QuantityReceived.Width = 149;
            // 
            // Cost
            // 
            this.Cost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cost.HeaderText = "Cost";
            this.Cost.MinimumWidth = 6;
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            this.Cost.Width = 65;
            // 
            // SubTotal
            // 
            this.SubTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SubTotal.HeaderText = "SubTotal";
            this.SubTotal.MinimumWidth = 6;
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            this.SubTotal.Width = 94;
            // 
            // cbLocation
            // 
            this.cbLocation.FormattingEnabled = true;
            this.cbLocation.ItemHeight = 24;
            this.cbLocation.Location = new System.Drawing.Point(660, 37);
            this.cbLocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.Size = new System.Drawing.Size(294, 30);
            this.cbLocation.TabIndex = 89;
            this.cbLocation.UseSelectable = true;
            // 
            // cbSupplier
            // 
            this.cbSupplier.FormattingEnabled = true;
            this.cbSupplier.ItemHeight = 24;
            this.cbSupplier.Location = new System.Drawing.Point(149, 90);
            this.cbSupplier.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbSupplier.Name = "cbSupplier";
            this.cbSupplier.Size = new System.Drawing.Size(294, 30);
            this.cbSupplier.TabIndex = 90;
            this.cbSupplier.UseSelectable = true;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
            this.btnClose.Image = global::GeneralLedger.Properties.Resources.cancel;
            this.btnClose.Location = new System.Drawing.Point(1130, 37);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(137, 44);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnClose.TabIndex = 111;
            this.btnClose.Text = "Close Page";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbNewParts
            // 
            this.cbNewParts.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cbNewParts.Checked = true;
            this.cbNewParts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNewParts.Name = "cbNewParts";
            this.cbNewParts.Text = "New Part";
            // 
            // cbRefurbishedParts
            // 
            this.cbRefurbishedParts.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cbRefurbishedParts.Name = "cbRefurbishedParts";
            this.cbRefurbishedParts.Text = "Refurbished Part";
            // 
            // tab2
            // 
            this.tab2.GlobalItem = false;
            this.tab2.Image = ((System.Drawing.Image)(resources.GetObject("tab2.Image")));
            this.tab2.Name = "tab2";
            this.tab2.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab2.Text = "Order Data";
            // 
            // metroLabel20
            // 
            this.metroLabel20.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel20.Location = new System.Drawing.Point(660, 522);
            this.metroLabel20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel20.Name = "metroLabel20";
            this.metroLabel20.Size = new System.Drawing.Size(190, 38);
            this.metroLabel20.TabIndex = 112;
            this.metroLabel20.Text = "Total Quantity";
            // 
            // metroLabel4
            // 
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(660, 626);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(190, 38);
            this.metroLabel4.TabIndex = 113;
            this.metroLabel4.Text = "Subtotal";
            // 
            // lblTotalQuantity
            // 
            this.lblTotalQuantity.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblTotalQuantity.Location = new System.Drawing.Point(930, 522);
            this.lblTotalQuantity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalQuantity.Name = "lblTotalQuantity";
            this.lblTotalQuantity.Size = new System.Drawing.Size(345, 38);
            this.lblTotalQuantity.TabIndex = 114;
            this.lblTotalQuantity.Text = "0.00";
            this.lblTotalQuantity.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblSubtotal.Location = new System.Drawing.Point(930, 626);
            this.lblSubtotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(345, 38);
            this.lblSubtotal.TabIndex = 115;
            this.lblSubtotal.Text = "0.00";
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // metroLabel7
            // 
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel7.Location = new System.Drawing.Point(660, 678);
            this.metroLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(190, 38);
            this.metroLabel7.TabIndex = 116;
            this.metroLabel7.Text = "Discount";
            // 
            // txtDiscountAmount
            // 
            // 
            // 
            // 
            this.txtDiscountAmount.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtDiscountAmount.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtDiscountAmount.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtDiscountAmount.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtDiscountAmount.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtDiscountAmount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDiscountAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDiscountAmount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDiscountAmount.Increment = 1D;
            this.txtDiscountAmount.Location = new System.Drawing.Point(930, 678);
            this.txtDiscountAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiscountAmount.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtDiscountAmount.Name = "txtDiscountAmount";
            this.txtDiscountAmount.ShowUpDown = true;
            this.txtDiscountAmount.Size = new System.Drawing.Size(345, 28);
            this.txtDiscountAmount.TabIndex = 117;
            this.txtDiscountAmount.ValueChanged += new System.EventHandler(this.txtDiscountAmount_ValueChanged);
            // 
            // metroLabel8
            // 
            this.metroLabel8.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel8.Location = new System.Drawing.Point(838, 678);
            this.metroLabel8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(85, 38);
            this.metroLabel8.TabIndex = 118;
            this.metroLabel8.Text = "(N/A)";
            // 
            // metroLabel9
            // 
            this.metroLabel9.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel9.Location = new System.Drawing.Point(838, 723);
            this.metroLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(85, 38);
            this.metroLabel9.TabIndex = 120;
            this.metroLabel9.Text = "(%)";
            // 
            // txtDiscountPercentage
            // 
            // 
            // 
            // 
            this.txtDiscountPercentage.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtDiscountPercentage.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtDiscountPercentage.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtDiscountPercentage.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtDiscountPercentage.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtDiscountPercentage.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDiscountPercentage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDiscountPercentage.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDiscountPercentage.Increment = 1D;
            this.txtDiscountPercentage.Location = new System.Drawing.Point(930, 723);
            this.txtDiscountPercentage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiscountPercentage.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtDiscountPercentage.Name = "txtDiscountPercentage";
            this.txtDiscountPercentage.ShowUpDown = true;
            this.txtDiscountPercentage.Size = new System.Drawing.Size(345, 28);
            this.txtDiscountPercentage.TabIndex = 119;
            this.txtDiscountPercentage.ValueChanged += new System.EventHandler(this.txtDiscountPercentage_ValueChanged);
            // 
            // lblGrandtotal
            // 
            this.lblGrandtotal.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblGrandtotal.Location = new System.Drawing.Point(930, 775);
            this.lblGrandtotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGrandtotal.Name = "lblGrandtotal";
            this.lblGrandtotal.Size = new System.Drawing.Size(345, 38);
            this.lblGrandtotal.TabIndex = 122;
            this.lblGrandtotal.Text = "0.00";
            this.lblGrandtotal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // metroLabel11
            // 
            this.metroLabel11.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel11.Location = new System.Drawing.Point(660, 775);
            this.metroLabel11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(190, 38);
            this.metroLabel11.TabIndex = 121;
            this.metroLabel11.Text = "Grand Total";
            // 
            // chkHasPayment
            // 
            this.chkHasPayment.AutoSize = true;
            this.chkHasPayment.DisplayFocus = true;
            this.chkHasPayment.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkHasPayment.Location = new System.Drawing.Point(930, 830);
            this.chkHasPayment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkHasPayment.Name = "chkHasPayment";
            this.chkHasPayment.Size = new System.Drawing.Size(110, 20);
            this.chkHasPayment.TabIndex = 123;
            this.chkHasPayment.Text = "Has Payment";
            this.chkHasPayment.UseSelectable = true;
            this.chkHasPayment.CheckStateChanged += new System.EventHandler(this.chkHasPayment_CheckStateChanged);
            // 
            // metroLabel5
            // 
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(660, 877);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(270, 38);
            this.metroLabel5.TabIndex = 124;
            this.metroLabel5.Text = "Payment Details : (Cash)";
            // 
            // txtAmountPaid
            // 
            // 
            // 
            // 
            this.txtAmountPaid.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtAmountPaid.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtAmountPaid.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtAmountPaid.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtAmountPaid.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtAmountPaid.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtAmountPaid.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAmountPaid.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtAmountPaid.Enabled = false;
            this.txtAmountPaid.Increment = 1D;
            this.txtAmountPaid.Location = new System.Drawing.Point(930, 924);
            this.txtAmountPaid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAmountPaid.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtAmountPaid.Name = "txtAmountPaid";
            this.txtAmountPaid.ShowUpDown = true;
            this.txtAmountPaid.Size = new System.Drawing.Size(345, 28);
            this.txtAmountPaid.TabIndex = 125;
            this.txtAmountPaid.ValueChanged += new System.EventHandler(this.txtAmountPaid_ValueChanged);
            // 
            // metroLabel6
            // 
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(660, 924);
            this.metroLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(190, 38);
            this.metroLabel6.TabIndex = 126;
            this.metroLabel6.Text = "Amount Paid";
            // 
            // lblChange
            // 
            this.lblChange.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblChange.Location = new System.Drawing.Point(930, 975);
            this.lblChange.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(345, 38);
            this.lblChange.TabIndex = 128;
            this.lblChange.Text = "0.00";
            this.lblChange.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // metroLabel12
            // 
            this.metroLabel12.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel12.Location = new System.Drawing.Point(660, 975);
            this.metroLabel12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(190, 38);
            this.metroLabel12.TabIndex = 127;
            this.metroLabel12.Text = "Change";
            // 
            // chkApproved
            // 
            this.chkApproved.AutoSize = true;
            this.chkApproved.DisplayFocus = true;
            this.chkApproved.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkApproved.Location = new System.Drawing.Point(930, 1038);
            this.chkApproved.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkApproved.Name = "chkApproved";
            this.chkApproved.Size = new System.Drawing.Size(91, 20);
            this.chkApproved.TabIndex = 129;
            this.chkApproved.Text = "Approved";
            this.chkApproved.UseSelectable = true;
            // 
            // metroCheckBox2
            // 
            this.metroCheckBox2.AutoSize = true;
            this.metroCheckBox2.DisplayFocus = true;
            this.metroCheckBox2.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.metroCheckBox2.Location = new System.Drawing.Point(1059, 1038);
            this.metroCheckBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.metroCheckBox2.Name = "metroCheckBox2";
            this.metroCheckBox2.Size = new System.Drawing.Size(162, 20);
            this.metroCheckBox2.TabIndex = 130;
            this.metroCheckBox2.Text = "Print Invoice on Save";
            this.metroCheckBox2.UseSelectable = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1130, 1117);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(132, 28);
            this.btnSave.TabIndex = 131;
            this.btnSave.Text = "Save";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEditProduct
            // 
            this.btnEditProduct.Location = new System.Drawing.Point(293, 149);
            this.btnEditProduct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.Size = new System.Drawing.Size(132, 28);
            this.btnEditProduct.TabIndex = 132;
            this.btnEditProduct.Text = "Edit Product";
            this.btnEditProduct.UseSelectable = true;
            this.btnEditProduct.Click += new System.EventHandler(this.btnEditProduct_Click);
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.Location = new System.Drawing.Point(439, 149);
            this.btnDeleteProduct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(132, 28);
            this.btnDeleteProduct.TabIndex = 133;
            this.btnDeleteProduct.Text = "Delete Product";
            this.btnDeleteProduct.UseSelectable = true;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(978, 1117);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(132, 28);
            this.btnClear.TabIndex = 134;
            this.btnClear.Text = "Clear";
            this.btnClear.UseSelectable = true;
            // 
            // chkAddBalanceToSupplier
            // 
            this.chkAddBalanceToSupplier.AutoSize = true;
            this.chkAddBalanceToSupplier.DisplayFocus = true;
            this.chkAddBalanceToSupplier.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkAddBalanceToSupplier.Location = new System.Drawing.Point(683, 1038);
            this.chkAddBalanceToSupplier.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkAddBalanceToSupplier.Name = "chkAddBalanceToSupplier";
            this.chkAddBalanceToSupplier.Size = new System.Drawing.Size(186, 20);
            this.chkAddBalanceToSupplier.TabIndex = 135;
            this.chkAddBalanceToSupplier.Text = "Add Balance to Supplier";
            this.chkAddBalanceToSupplier.UseSelectable = true;
            this.chkAddBalanceToSupplier.Visible = false;
            // 
            // lblTotalReceived
            // 
            this.lblTotalReceived.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblTotalReceived.Location = new System.Drawing.Point(930, 570);
            this.lblTotalReceived.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalReceived.Name = "lblTotalReceived";
            this.lblTotalReceived.Size = new System.Drawing.Size(345, 38);
            this.lblTotalReceived.TabIndex = 137;
            this.lblTotalReceived.Text = "0.00";
            this.lblTotalReceived.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // metroLabel13
            // 
            this.metroLabel13.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel13.Location = new System.Drawing.Point(660, 570);
            this.metroLabel13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(190, 38);
            this.metroLabel13.TabIndex = 136;
            this.metroLabel13.Text = "Total Received";
            // 
            // frmPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.lblTotalReceived);
            this.Controls.Add(this.metroLabel13);
            this.Controls.Add(this.chkAddBalanceToSupplier);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDeleteProduct);
            this.Controls.Add(this.btnEditProduct);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.metroCheckBox2);
            this.Controls.Add(this.chkApproved);
            this.Controls.Add(this.lblChange);
            this.Controls.Add(this.metroLabel12);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.txtAmountPaid);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.chkHasPayment);
            this.Controls.Add(this.lblGrandtotal);
            this.Controls.Add(this.metroLabel11);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.txtDiscountPercentage);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.txtDiscountAmount);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.lblTotalQuantity);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel20);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbSupplier);
            this.Controls.Add(this.cbLocation);
            this.Controls.Add(this.dgPurchaseOrderDetails);
            this.Controls.Add(this.btnChooseProduct);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.dtBatchDate);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel17);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtPONumber);
            this.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.Name = "frmPurchaseOrder";
            this.Size = new System.Drawing.Size(1324, 1316);
            this.Load += new System.EventHandler(this.frmPurchaseOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPurchaseOrderDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountPaid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel17;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtPONumber;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroDateTime dtBatchDate;
        private MetroFramework.Controls.MetroButton btnChooseProduct;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgPurchaseOrderDetails;
        private MetroFramework.Controls.MetroComboBox cbLocation;
        private MetroFramework.Controls.MetroComboBox cbSupplier;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.CheckBoxItem cbNewParts;
        private DevComponents.DotNetBar.CheckBoxItem cbRefurbishedParts;
        private DevComponents.DotNetBar.SuperTabItem tab2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductDetailsID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityReceived;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private MetroFramework.Controls.MetroLabel metroLabel20;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel lblTotalQuantity;
        private MetroFramework.Controls.MetroLabel lblSubtotal;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private DevComponents.Editors.DoubleInput txtDiscountAmount;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private DevComponents.Editors.DoubleInput txtDiscountPercentage;
        private MetroFramework.Controls.MetroLabel lblGrandtotal;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroCheckBox chkHasPayment;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private DevComponents.Editors.DoubleInput txtAmountPaid;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel lblChange;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroCheckBox chkApproved;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox2;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroButton btnEditProduct;
        private MetroFramework.Controls.MetroButton btnDeleteProduct;
        private MetroFramework.Controls.MetroButton btnClear;
        private MetroFramework.Controls.MetroCheckBox chkAddBalanceToSupplier;
        private MetroFramework.Controls.MetroLabel lblTotalReceived;
        private MetroFramework.Controls.MetroLabel metroLabel13;
    }
}
