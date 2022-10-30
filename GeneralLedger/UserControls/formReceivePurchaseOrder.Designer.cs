namespace GeneralLedger.UserControls
{
    partial class formReceivePurchaseOrder
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
            this.btnSearch = new MetroFramework.Controls.MetroButton();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.txtCriteria = new MetroFramework.Controls.MetroTextBox();
            this.txtMemo = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.txtAddress = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.cbLocation = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.dtReceivedDate = new MetroFramework.Controls.MetroDateTime();
            this.lblTotalRemaining = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.lblTotalReceived = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.lblTotalProducts = new MetroFramework.Controls.MetroLabel();
            this.metroLabel20 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.txtPurchaseOrderID = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.txtPurchaseOrderNumber = new MetroFramework.Controls.MetroTextBox();
            this.dgPurchaseOrderReceivingDetails = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.dgPurchaseOrderDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProductDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProductColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProductSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProductUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgQuantityReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgQuantityRemaining = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgReceivedStatusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgReceivedStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAddedQuantityReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgIsReceived = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Receive = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.ViewHistory = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgPurchaseOrderReceivingDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1256, 428);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(148, 35);
            this.btnSearch.TabIndex = 149;
            this.btnSearch.Text = "Search Product";
            this.btnSearch.UseSelectable = true;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(32, 425);
            this.metroLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(52, 19);
            this.metroLabel7.TabIndex = 148;
            this.metroLabel7.Text = "Criteria";
            // 
            // txtCriteria
            // 
            // 
            // 
            // 
            this.txtCriteria.CustomButton.Image = null;
            this.txtCriteria.CustomButton.Location = new System.Drawing.Point(983, 2);
            this.txtCriteria.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCriteria.CustomButton.Name = "";
            this.txtCriteria.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtCriteria.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCriteria.CustomButton.TabIndex = 1;
            this.txtCriteria.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCriteria.CustomButton.UseSelectable = true;
            this.txtCriteria.CustomButton.Visible = false;
            this.txtCriteria.Lines = new string[0];
            this.txtCriteria.Location = new System.Drawing.Point(229, 428);
            this.txtCriteria.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCriteria.MaxLength = 32767;
            this.txtCriteria.Name = "txtCriteria";
            this.txtCriteria.PasswordChar = '\0';
            this.txtCriteria.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCriteria.SelectedText = "";
            this.txtCriteria.SelectionLength = 0;
            this.txtCriteria.SelectionStart = 0;
            this.txtCriteria.ShortcutsEnabled = true;
            this.txtCriteria.Size = new System.Drawing.Size(1019, 38);
            this.txtCriteria.TabIndex = 147;
            this.txtCriteria.UseSelectable = true;
            this.txtCriteria.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCriteria.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtMemo
            // 
            // 
            // 
            // 
            this.txtMemo.CustomButton.Image = null;
            this.txtMemo.CustomButton.Location = new System.Drawing.Point(419, 1);
            this.txtMemo.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMemo.CustomButton.Name = "";
            this.txtMemo.CustomButton.Size = new System.Drawing.Size(89, 89);
            this.txtMemo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMemo.CustomButton.TabIndex = 1;
            this.txtMemo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMemo.CustomButton.UseSelectable = true;
            this.txtMemo.CustomButton.Visible = false;
            this.txtMemo.Lines = new string[0];
            this.txtMemo.Location = new System.Drawing.Point(895, 306);
            this.txtMemo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMemo.MaxLength = 32767;
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.PasswordChar = '\0';
            this.txtMemo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMemo.SelectedText = "";
            this.txtMemo.SelectionLength = 0;
            this.txtMemo.SelectionStart = 0;
            this.txtMemo.ShortcutsEnabled = true;
            this.txtMemo.Size = new System.Drawing.Size(509, 91);
            this.txtMemo.TabIndex = 146;
            this.txtMemo.UseSelectable = true;
            this.txtMemo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMemo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(687, 306);
            this.metroLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(48, 19);
            this.metroLabel6.TabIndex = 145;
            this.metroLabel6.Text = "Memo";
            // 
            // txtAddress
            // 
            // 
            // 
            // 
            this.txtAddress.CustomButton.Image = null;
            this.txtAddress.CustomButton.Location = new System.Drawing.Point(419, 1);
            this.txtAddress.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddress.CustomButton.Name = "";
            this.txtAddress.CustomButton.Size = new System.Drawing.Size(89, 89);
            this.txtAddress.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAddress.CustomButton.TabIndex = 1;
            this.txtAddress.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAddress.CustomButton.UseSelectable = true;
            this.txtAddress.CustomButton.Visible = false;
            this.txtAddress.Lines = new string[0];
            this.txtAddress.Location = new System.Drawing.Point(895, 187);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddress.MaxLength = 32767;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PasswordChar = '\0';
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAddress.SelectedText = "";
            this.txtAddress.SelectionLength = 0;
            this.txtAddress.SelectionStart = 0;
            this.txtAddress.ShortcutsEnabled = true;
            this.txtAddress.Size = new System.Drawing.Size(509, 91);
            this.txtAddress.TabIndex = 144;
            this.txtAddress.UseSelectable = true;
            this.txtAddress.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAddress.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(687, 187);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(56, 19);
            this.metroLabel5.TabIndex = 143;
            this.metroLabel5.Text = "Address";
            // 
            // cbLocation
            // 
            this.cbLocation.FormattingEnabled = true;
            this.cbLocation.ItemHeight = 23;
            this.cbLocation.Location = new System.Drawing.Point(895, 128);
            this.cbLocation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.Size = new System.Drawing.Size(509, 29);
            this.cbLocation.TabIndex = 142;
            this.cbLocation.UseSelectable = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(687, 128);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(58, 19);
            this.metroLabel4.TabIndex = 141;
            this.metroLabel4.Text = "Location";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(687, 70);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(92, 19);
            this.metroLabel1.TabIndex = 140;
            this.metroLabel1.Text = "Date Received";
            // 
            // dtReceivedDate
            // 
            this.dtReceivedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReceivedDate.Location = new System.Drawing.Point(895, 70);
            this.dtReceivedDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtReceivedDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtReceivedDate.Name = "dtReceivedDate";
            this.dtReceivedDate.Size = new System.Drawing.Size(509, 29);
            this.dtReceivedDate.TabIndex = 139;
            // 
            // lblTotalRemaining
            // 
            this.lblTotalRemaining.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblTotalRemaining.Location = new System.Drawing.Point(291, 187);
            this.lblTotalRemaining.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalRemaining.Name = "lblTotalRemaining";
            this.lblTotalRemaining.Size = new System.Drawing.Size(293, 47);
            this.lblTotalRemaining.TabIndex = 138;
            this.lblTotalRemaining.Text = "0.00";
            this.lblTotalRemaining.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // metroLabel3
            // 
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(32, 187);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(189, 47);
            this.metroLabel3.TabIndex = 137;
            this.metroLabel3.Text = "Total Remaining";
            // 
            // lblTotalReceived
            // 
            this.lblTotalReceived.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblTotalReceived.Location = new System.Drawing.Point(291, 128);
            this.lblTotalReceived.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalReceived.Name = "lblTotalReceived";
            this.lblTotalReceived.Size = new System.Drawing.Size(293, 47);
            this.lblTotalReceived.TabIndex = 136;
            this.lblTotalReceived.Text = "0.00";
            this.lblTotalReceived.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // metroLabel2
            // 
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(32, 128);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(189, 47);
            this.metroLabel2.TabIndex = 135;
            this.metroLabel2.Text = "Total Received";
            // 
            // lblTotalProducts
            // 
            this.lblTotalProducts.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblTotalProducts.Location = new System.Drawing.Point(291, 70);
            this.lblTotalProducts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalProducts.Name = "lblTotalProducts";
            this.lblTotalProducts.Size = new System.Drawing.Size(293, 47);
            this.lblTotalProducts.TabIndex = 134;
            this.lblTotalProducts.Text = "0.00";
            this.lblTotalProducts.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // metroLabel20
            // 
            this.metroLabel20.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel20.Location = new System.Drawing.Point(32, 70);
            this.metroLabel20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel20.Name = "metroLabel20";
            this.metroLabel20.Size = new System.Drawing.Size(189, 47);
            this.metroLabel20.TabIndex = 133;
            this.metroLabel20.Text = "Total Products";
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.Location = new System.Drawing.Point(32, 243);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(117, 19);
            this.metroLabel12.TabIndex = 151;
            this.metroLabel12.Text = "Purchase Order ID";
            // 
            // txtPurchaseOrderID
            // 
            this.txtPurchaseOrderID.BackColor = System.Drawing.SystemColors.ControlLight;
            // 
            // 
            // 
            this.txtPurchaseOrderID.CustomButton.Image = null;
            this.txtPurchaseOrderID.CustomButton.Location = new System.Drawing.Point(259, 1);
            this.txtPurchaseOrderID.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPurchaseOrderID.CustomButton.Name = "";
            this.txtPurchaseOrderID.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtPurchaseOrderID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPurchaseOrderID.CustomButton.TabIndex = 1;
            this.txtPurchaseOrderID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPurchaseOrderID.CustomButton.UseSelectable = true;
            this.txtPurchaseOrderID.CustomButton.Visible = false;
            this.txtPurchaseOrderID.Enabled = false;
            this.txtPurchaseOrderID.Lines = new string[0];
            this.txtPurchaseOrderID.Location = new System.Drawing.Point(291, 243);
            this.txtPurchaseOrderID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPurchaseOrderID.MaxLength = 32767;
            this.txtPurchaseOrderID.Name = "txtPurchaseOrderID";
            this.txtPurchaseOrderID.PasswordChar = '\0';
            this.txtPurchaseOrderID.ReadOnly = true;
            this.txtPurchaseOrderID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPurchaseOrderID.SelectedText = "";
            this.txtPurchaseOrderID.SelectionLength = 0;
            this.txtPurchaseOrderID.SelectionStart = 0;
            this.txtPurchaseOrderID.ShortcutsEnabled = true;
            this.txtPurchaseOrderID.Size = new System.Drawing.Size(293, 35);
            this.txtPurchaseOrderID.TabIndex = 150;
            this.txtPurchaseOrderID.UseCustomBackColor = true;
            this.txtPurchaseOrderID.UseSelectable = true;
            this.txtPurchaseOrderID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtPurchaseOrderID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(32, 306);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(154, 19);
            this.metroLabel8.TabIndex = 153;
            this.metroLabel8.Text = "Purchase Order Number";
            // 
            // txtPurchaseOrderNumber
            // 
            this.txtPurchaseOrderNumber.BackColor = System.Drawing.SystemColors.ControlLight;
            // 
            // 
            // 
            this.txtPurchaseOrderNumber.CustomButton.Image = null;
            this.txtPurchaseOrderNumber.CustomButton.Location = new System.Drawing.Point(259, 1);
            this.txtPurchaseOrderNumber.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPurchaseOrderNumber.CustomButton.Name = "";
            this.txtPurchaseOrderNumber.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtPurchaseOrderNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPurchaseOrderNumber.CustomButton.TabIndex = 1;
            this.txtPurchaseOrderNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPurchaseOrderNumber.CustomButton.UseSelectable = true;
            this.txtPurchaseOrderNumber.CustomButton.Visible = false;
            this.txtPurchaseOrderNumber.Enabled = false;
            this.txtPurchaseOrderNumber.Lines = new string[0];
            this.txtPurchaseOrderNumber.Location = new System.Drawing.Point(291, 306);
            this.txtPurchaseOrderNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPurchaseOrderNumber.MaxLength = 32767;
            this.txtPurchaseOrderNumber.Name = "txtPurchaseOrderNumber";
            this.txtPurchaseOrderNumber.PasswordChar = '\0';
            this.txtPurchaseOrderNumber.ReadOnly = true;
            this.txtPurchaseOrderNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPurchaseOrderNumber.SelectedText = "";
            this.txtPurchaseOrderNumber.SelectionLength = 0;
            this.txtPurchaseOrderNumber.SelectionStart = 0;
            this.txtPurchaseOrderNumber.ShortcutsEnabled = true;
            this.txtPurchaseOrderNumber.Size = new System.Drawing.Size(293, 35);
            this.txtPurchaseOrderNumber.TabIndex = 152;
            this.txtPurchaseOrderNumber.UseCustomBackColor = true;
            this.txtPurchaseOrderNumber.UseSelectable = true;
            this.txtPurchaseOrderNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtPurchaseOrderNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // dgPurchaseOrderReceivingDetails
            // 
            this.dgPurchaseOrderReceivingDetails.AllowUserToAddRows = false;
            this.dgPurchaseOrderReceivingDetails.AllowUserToDeleteRows = false;
            this.dgPurchaseOrderReceivingDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPurchaseOrderReceivingDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPurchaseOrderReceivingDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPurchaseOrderReceivingDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgPurchaseOrderDetailID,
            this.dgProductDetailID,
            this.dgProductName,
            this.dgProductColor,
            this.dgProductSize,
            this.dgProductUnit,
            this.dgQuantity,
            this.dgQuantityReceived,
            this.dgQuantityRemaining,
            this.dgReceivedStatusID,
            this.dgReceivedStatus,
            this.dgAddedQuantityReceived,
            this.dgIsReceived,
            this.Receive,
            this.ViewHistory});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPurchaseOrderReceivingDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgPurchaseOrderReceivingDetails.EnableHeadersVisualStyles = false;
            this.dgPurchaseOrderReceivingDetails.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgPurchaseOrderReceivingDetails.Location = new System.Drawing.Point(30, 480);
            this.dgPurchaseOrderReceivingDetails.Name = "dgPurchaseOrderReceivingDetails";
            this.dgPurchaseOrderReceivingDetails.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPurchaseOrderReceivingDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgPurchaseOrderReceivingDetails.RowTemplate.Height = 30;
            this.dgPurchaseOrderReceivingDetails.Size = new System.Drawing.Size(1374, 394);
            this.dgPurchaseOrderReceivingDetails.TabIndex = 154;
            this.dgPurchaseOrderReceivingDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPurchaseOrderReceivingDetails_CellContentClick);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
            this.btnClose.Image = global::GeneralLedger.Properties.Resources.cancel;
            this.btnClose.Location = new System.Drawing.Point(1458, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(154, 55);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnClose.TabIndex = 155;
            this.btnClose.Text = "Close Page";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1194, 905);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(210, 35);
            this.btnSave.TabIndex = 175;
            this.btnSave.Text = "Save";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(976, 905);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(210, 35);
            this.metroButton1.TabIndex = 176;
            this.metroButton1.Text = "Clear";
            this.metroButton1.UseSelectable = true;
            // 
            // dgPurchaseOrderDetailID
            // 
            this.dgPurchaseOrderDetailID.HeaderText = "dgPurchaseOrderDetailID";
            this.dgPurchaseOrderDetailID.Name = "dgPurchaseOrderDetailID";
            this.dgPurchaseOrderDetailID.ReadOnly = true;
            // 
            // dgProductDetailID
            // 
            this.dgProductDetailID.HeaderText = "dgProductDetailID";
            this.dgProductDetailID.Name = "dgProductDetailID";
            this.dgProductDetailID.ReadOnly = true;
            // 
            // dgProductName
            // 
            this.dgProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgProductName.HeaderText = "dgProductName";
            this.dgProductName.Name = "dgProductName";
            this.dgProductName.ReadOnly = true;
            this.dgProductName.Width = 160;
            // 
            // dgProductColor
            // 
            this.dgProductColor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgProductColor.HeaderText = "dgProductColor";
            this.dgProductColor.Name = "dgProductColor";
            this.dgProductColor.ReadOnly = true;
            this.dgProductColor.Width = 155;
            // 
            // dgProductSize
            // 
            this.dgProductSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgProductSize.HeaderText = "dgProductSize";
            this.dgProductSize.Name = "dgProductSize";
            this.dgProductSize.ReadOnly = true;
            this.dgProductSize.Width = 149;
            // 
            // dgProductUnit
            // 
            this.dgProductUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgProductUnit.HeaderText = "dgProductUnit";
            this.dgProductUnit.Name = "dgProductUnit";
            this.dgProductUnit.ReadOnly = true;
            this.dgProductUnit.Width = 147;
            // 
            // dgQuantity
            // 
            this.dgQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgQuantity.HeaderText = "dgQuantity";
            this.dgQuantity.Name = "dgQuantity";
            this.dgQuantity.ReadOnly = true;
            this.dgQuantity.Width = 122;
            // 
            // dgQuantityReceived
            // 
            this.dgQuantityReceived.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgQuantityReceived.HeaderText = "dgQuantityReceived";
            this.dgQuantityReceived.Name = "dgQuantityReceived";
            this.dgQuantityReceived.ReadOnly = true;
            this.dgQuantityReceived.Width = 188;
            // 
            // dgQuantityRemaining
            // 
            this.dgQuantityRemaining.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgQuantityRemaining.HeaderText = "dgQuantityRemaining";
            this.dgQuantityRemaining.Name = "dgQuantityRemaining";
            this.dgQuantityRemaining.ReadOnly = true;
            this.dgQuantityRemaining.Width = 198;
            // 
            // dgReceivedStatusID
            // 
            this.dgReceivedStatusID.HeaderText = "dgReceivedStatusID";
            this.dgReceivedStatusID.Name = "dgReceivedStatusID";
            this.dgReceivedStatusID.ReadOnly = true;
            // 
            // dgReceivedStatus
            // 
            this.dgReceivedStatus.HeaderText = "dgReceivedStatus";
            this.dgReceivedStatus.Name = "dgReceivedStatus";
            this.dgReceivedStatus.ReadOnly = true;
            // 
            // dgAddedQuantityReceived
            // 
            this.dgAddedQuantityReceived.HeaderText = "dgAddedQuantityReceived";
            this.dgAddedQuantityReceived.Name = "dgAddedQuantityReceived";
            this.dgAddedQuantityReceived.ReadOnly = true;
            // 
            // dgIsReceived
            // 
            this.dgIsReceived.Checked = true;
            this.dgIsReceived.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.dgIsReceived.CheckValue = "N";
            this.dgIsReceived.HeaderText = "dgIsReceived";
            this.dgIsReceived.Name = "dgIsReceived";
            this.dgIsReceived.ReadOnly = true;
            // 
            // Receive
            // 
            this.Receive.HeaderText = "";
            this.Receive.Name = "Receive";
            this.Receive.ReadOnly = true;
            this.Receive.Text = null;
            // 
            // ViewHistory
            // 
            this.ViewHistory.HeaderText = "";
            this.ViewHistory.Name = "ViewHistory";
            this.ViewHistory.ReadOnly = true;
            this.ViewHistory.Text = null;
            // 
            // formReceivePurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgPurchaseOrderReceivingDetails);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.txtPurchaseOrderNumber);
            this.Controls.Add(this.metroLabel12);
            this.Controls.Add(this.txtPurchaseOrderID);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.txtCriteria);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.cbLocation);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.dtReceivedDate);
            this.Controls.Add(this.lblTotalRemaining);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.lblTotalReceived);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.lblTotalProducts);
            this.Controls.Add(this.metroLabel20);
            this.Name = "formReceivePurchaseOrder";
            this.Size = new System.Drawing.Size(1629, 1053);
            this.Load += new System.EventHandler(this.formReceivePurchaseOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPurchaseOrderReceivingDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnSearch;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTextBox txtCriteria;
        private MetroFramework.Controls.MetroTextBox txtMemo;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox txtAddress;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroComboBox cbLocation;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroDateTime dtReceivedDate;
        private MetroFramework.Controls.MetroLabel lblTotalRemaining;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel lblTotalReceived;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel lblTotalProducts;
        private MetroFramework.Controls.MetroLabel metroLabel20;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroTextBox txtPurchaseOrderID;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox txtPurchaseOrderNumber;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgPurchaseOrderReceivingDetails;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPurchaseOrderDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProductDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProductColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProductSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProductUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgQuantityReceived;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgQuantityRemaining;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgReceivedStatusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgReceivedStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAddedQuantityReceived;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn dgIsReceived;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn Receive;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn ViewHistory;
    }
}
