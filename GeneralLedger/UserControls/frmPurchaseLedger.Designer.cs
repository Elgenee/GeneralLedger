namespace GeneralLedger.UserControls
{
    partial class frmPurchaseLedger
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
            this.strTransactionNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.curTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.curRunningBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRefresh = new MetroFramework.Controls.MetroButton();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.txtRunningBalance = new MetroFramework.Controls.MetroTextBox();
            this.datDateTransaction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgSaleLedger = new MetroFramework.Controls.MetroGrid();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIdSalesCustomerLedgerTransactionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIdSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIdCollection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIdAccountReceivableAdjustment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtAgent = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.txtCustomerName = new MetroFramework.Controls.MetroTextBox();
            this.txtTotal = new DevComponents.Editors.DoubleInput();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.dtTransactionDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtPONo = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtTransactionNo = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.txtID = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSaleLedger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // strTransactionNo
            // 
            this.strTransactionNo.HeaderText = "Transaction No";
            this.strTransactionNo.MinimumWidth = 6;
            this.strTransactionNo.Name = "strTransactionNo";
            this.strTransactionNo.Width = 125;
            // 
            // curTotalAmount
            // 
            this.curTotalAmount.HeaderText = "Total Amount";
            this.curTotalAmount.MinimumWidth = 6;
            this.curTotalAmount.Name = "curTotalAmount";
            this.curTotalAmount.Width = 125;
            // 
            // curRunningBalance
            // 
            this.curRunningBalance.HeaderText = "Running Balance";
            this.curRunningBalance.MinimumWidth = 6;
            this.curRunningBalance.Name = "curRunningBalance";
            this.curRunningBalance.Width = 125;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(866, 168);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(132, 28);
            this.btnRefresh.TabIndex = 215;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseSelectable = true;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(581, 127);
            this.metroLabel8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(112, 20);
            this.metroLabel8.TabIndex = 214;
            this.metroLabel8.Text = "Running Balance";
            // 
            // txtRunningBalance
            // 
            // 
            // 
            // 
            this.txtRunningBalance.CustomButton.Image = null;
            this.txtRunningBalance.CustomButton.Location = new System.Drawing.Point(239, 2);
            this.txtRunningBalance.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtRunningBalance.CustomButton.Name = "";
            this.txtRunningBalance.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtRunningBalance.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtRunningBalance.CustomButton.TabIndex = 1;
            this.txtRunningBalance.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtRunningBalance.CustomButton.UseSelectable = true;
            this.txtRunningBalance.CustomButton.Visible = false;
            this.txtRunningBalance.Lines = new string[0];
            this.txtRunningBalance.Location = new System.Drawing.Point(733, 119);
            this.txtRunningBalance.Margin = new System.Windows.Forms.Padding(4);
            this.txtRunningBalance.MaxLength = 32767;
            this.txtRunningBalance.Name = "txtRunningBalance";
            this.txtRunningBalance.PasswordChar = '\0';
            this.txtRunningBalance.ReadOnly = true;
            this.txtRunningBalance.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRunningBalance.SelectedText = "";
            this.txtRunningBalance.SelectionLength = 0;
            this.txtRunningBalance.SelectionStart = 0;
            this.txtRunningBalance.ShortcutsEnabled = true;
            this.txtRunningBalance.Size = new System.Drawing.Size(265, 28);
            this.txtRunningBalance.TabIndex = 213;
            this.txtRunningBalance.UseSelectable = true;
            this.txtRunningBalance.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtRunningBalance.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // datDateTransaction
            // 
            this.datDateTransaction.HeaderText = "Date Transaction";
            this.datDateTransaction.MinimumWidth = 6;
            this.datDateTransaction.Name = "datDateTransaction";
            this.datDateTransaction.Width = 125;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgSaleLedger);
            this.panel1.Location = new System.Drawing.Point(27, 405);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1336, 573);
            this.panel1.TabIndex = 212;
            // 
            // dtgSaleLedger
            // 
            this.dtgSaleLedger.AllowUserToResizeRows = false;
            this.dtgSaleLedger.BackgroundColor = System.Drawing.Color.White;
            this.dtgSaleLedger.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgSaleLedger.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtgSaleLedger.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgSaleLedger.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgSaleLedger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSaleLedger.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.intIdSalesCustomerLedgerTransactionType,
            this.strType,
            this.intIdSales,
            this.intIdCollection,
            this.intIdAccountReceivableAdjustment,
            this.strTransactionNo,
            this.datDateTransaction,
            this.curTotalAmount,
            this.curRunningBalance});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgSaleLedger.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgSaleLedger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgSaleLedger.EnableHeadersVisualStyles = false;
            this.dtgSaleLedger.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dtgSaleLedger.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtgSaleLedger.Location = new System.Drawing.Point(0, 0);
            this.dtgSaleLedger.Margin = new System.Windows.Forms.Padding(4);
            this.dtgSaleLedger.Name = "dtgSaleLedger";
            this.dtgSaleLedger.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgSaleLedger.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgSaleLedger.RowHeadersWidth = 51;
            this.dtgSaleLedger.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgSaleLedger.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSaleLedger.Size = new System.Drawing.Size(1336, 573);
            this.dtgSaleLedger.TabIndex = 14;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 125;
            // 
            // intIdSalesCustomerLedgerTransactionType
            // 
            this.intIdSalesCustomerLedgerTransactionType.HeaderText = "intIdSalesCustomerLedgerTransactionType";
            this.intIdSalesCustomerLedgerTransactionType.MinimumWidth = 6;
            this.intIdSalesCustomerLedgerTransactionType.Name = "intIdSalesCustomerLedgerTransactionType";
            this.intIdSalesCustomerLedgerTransactionType.ReadOnly = true;
            this.intIdSalesCustomerLedgerTransactionType.Visible = false;
            this.intIdSalesCustomerLedgerTransactionType.Width = 125;
            // 
            // strType
            // 
            this.strType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.strType.HeaderText = "Type";
            this.strType.MinimumWidth = 6;
            this.strType.Name = "strType";
            this.strType.ReadOnly = true;
            // 
            // intIdSales
            // 
            this.intIdSales.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.intIdSales.HeaderText = "intIdSales";
            this.intIdSales.MinimumWidth = 6;
            this.intIdSales.Name = "intIdSales";
            this.intIdSales.ReadOnly = true;
            this.intIdSales.Visible = false;
            // 
            // intIdCollection
            // 
            this.intIdCollection.HeaderText = "intIdCollection";
            this.intIdCollection.MinimumWidth = 6;
            this.intIdCollection.Name = "intIdCollection";
            this.intIdCollection.Visible = false;
            this.intIdCollection.Width = 125;
            // 
            // intIdAccountReceivableAdjustment
            // 
            this.intIdAccountReceivableAdjustment.HeaderText = "intIdAccountReceivableAdjustment";
            this.intIdAccountReceivableAdjustment.MinimumWidth = 6;
            this.intIdAccountReceivableAdjustment.Name = "intIdAccountReceivableAdjustment";
            this.intIdAccountReceivableAdjustment.Visible = false;
            this.intIdAccountReceivableAdjustment.Width = 125;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(53, 221);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(123, 25);
            this.metroLabel5.TabIndex = 211;
            this.metroLabel5.Text = "Purchase Total";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(581, 72);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(59, 20);
            this.metroLabel4.TabIndex = 210;
            this.metroLabel4.Text = "Supplier";
            // 
            // txtAgent
            // 
            // 
            // 
            // 
            this.txtAgent.CustomButton.Image = null;
            this.txtAgent.CustomButton.Location = new System.Drawing.Point(239, 2);
            this.txtAgent.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtAgent.CustomButton.Name = "";
            this.txtAgent.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtAgent.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAgent.CustomButton.TabIndex = 1;
            this.txtAgent.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAgent.CustomButton.UseSelectable = true;
            this.txtAgent.CustomButton.Visible = false;
            this.txtAgent.Lines = new string[0];
            this.txtAgent.Location = new System.Drawing.Point(733, 72);
            this.txtAgent.Margin = new System.Windows.Forms.Padding(4);
            this.txtAgent.MaxLength = 32767;
            this.txtAgent.Name = "txtAgent";
            this.txtAgent.PasswordChar = '\0';
            this.txtAgent.ReadOnly = true;
            this.txtAgent.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAgent.SelectedText = "";
            this.txtAgent.SelectionLength = 0;
            this.txtAgent.SelectionStart = 0;
            this.txtAgent.ShortcutsEnabled = true;
            this.txtAgent.Size = new System.Drawing.Size(265, 28);
            this.txtAgent.TabIndex = 209;
            this.txtAgent.UseSelectable = true;
            this.txtAgent.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAgent.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(581, 23);
            this.metroLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(103, 20);
            this.metroLabel6.TabIndex = 208;
            this.metroLabel6.Text = "Purchase SI/DR";
            // 
            // txtCustomerName
            // 
            // 
            // 
            // 
            this.txtCustomerName.CustomButton.Image = null;
            this.txtCustomerName.CustomButton.Location = new System.Drawing.Point(239, 2);
            this.txtCustomerName.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerName.CustomButton.Name = "";
            this.txtCustomerName.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtCustomerName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCustomerName.CustomButton.TabIndex = 1;
            this.txtCustomerName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCustomerName.CustomButton.UseSelectable = true;
            this.txtCustomerName.CustomButton.Visible = false;
            this.txtCustomerName.Lines = new string[0];
            this.txtCustomerName.Location = new System.Drawing.Point(733, 23);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerName.MaxLength = 32767;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.PasswordChar = '\0';
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCustomerName.SelectedText = "";
            this.txtCustomerName.SelectionLength = 0;
            this.txtCustomerName.SelectionStart = 0;
            this.txtCustomerName.ShortcutsEnabled = true;
            this.txtCustomerName.Size = new System.Drawing.Size(265, 28);
            this.txtCustomerName.TabIndex = 207;
            this.txtCustomerName.UseSelectable = true;
            this.txtCustomerName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCustomerName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtTotal
            // 
            // 
            // 
            // 
            this.txtTotal.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTotal.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtTotal.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTotal.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTotal.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTotal.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotal.Increment = 1D;
            this.txtTotal.IsInputReadOnly = true;
            this.txtTotal.Location = new System.Drawing.Point(280, 221);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTotal.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ShowUpDown = true;
            this.txtTotal.Size = new System.Drawing.Size(267, 28);
            this.txtTotal.TabIndex = 206;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(53, 166);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(215, 25);
            this.metroLabel3.TabIndex = 205;
            this.metroLabel3.Text = "Purchase Transaction Date";
            // 
            // dtTransactionDate
            // 
            this.dtTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTransactionDate.Location = new System.Drawing.Point(280, 166);
            this.dtTransactionDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtTransactionDate.MinimumSize = new System.Drawing.Size(0, 30);
            this.dtTransactionDate.Name = "dtTransactionDate";
            this.dtTransactionDate.Size = new System.Drawing.Size(265, 30);
            this.dtTransactionDate.TabIndex = 204;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(53, 119);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(144, 25);
            this.metroLabel2.TabIndex = 203;
            this.metroLabel2.Text = "Purchase PO No.";
            // 
            // txtPONo
            // 
            // 
            // 
            // 
            this.txtPONo.CustomButton.Image = null;
            this.txtPONo.CustomButton.Location = new System.Drawing.Point(239, 2);
            this.txtPONo.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtPONo.CustomButton.Name = "";
            this.txtPONo.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtPONo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPONo.CustomButton.TabIndex = 1;
            this.txtPONo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPONo.CustomButton.UseSelectable = true;
            this.txtPONo.CustomButton.Visible = false;
            this.txtPONo.Lines = new string[0];
            this.txtPONo.Location = new System.Drawing.Point(280, 119);
            this.txtPONo.Margin = new System.Windows.Forms.Padding(4);
            this.txtPONo.MaxLength = 32767;
            this.txtPONo.Name = "txtPONo";
            this.txtPONo.PasswordChar = '\0';
            this.txtPONo.ReadOnly = true;
            this.txtPONo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPONo.SelectedText = "";
            this.txtPONo.SelectionLength = 0;
            this.txtPONo.SelectionStart = 0;
            this.txtPONo.ShortcutsEnabled = true;
            this.txtPONo.Size = new System.Drawing.Size(265, 28);
            this.txtPONo.TabIndex = 202;
            this.txtPONo.UseSelectable = true;
            this.txtPONo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPONo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(53, 72);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(165, 20);
            this.metroLabel1.TabIndex = 201;
            this.metroLabel1.Text = "Purchase Transaction No.";
            // 
            // txtTransactionNo
            // 
            // 
            // 
            // 
            this.txtTransactionNo.CustomButton.Image = null;
            this.txtTransactionNo.CustomButton.Location = new System.Drawing.Point(239, 2);
            this.txtTransactionNo.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtTransactionNo.CustomButton.Name = "";
            this.txtTransactionNo.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtTransactionNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTransactionNo.CustomButton.TabIndex = 1;
            this.txtTransactionNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTransactionNo.CustomButton.UseSelectable = true;
            this.txtTransactionNo.CustomButton.Visible = false;
            this.txtTransactionNo.Lines = new string[0];
            this.txtTransactionNo.Location = new System.Drawing.Point(280, 72);
            this.txtTransactionNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtTransactionNo.MaxLength = 32767;
            this.txtTransactionNo.Name = "txtTransactionNo";
            this.txtTransactionNo.PasswordChar = '\0';
            this.txtTransactionNo.ReadOnly = true;
            this.txtTransactionNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTransactionNo.SelectedText = "";
            this.txtTransactionNo.SelectionLength = 0;
            this.txtTransactionNo.SelectionStart = 0;
            this.txtTransactionNo.ShortcutsEnabled = true;
            this.txtTransactionNo.Size = new System.Drawing.Size(265, 28);
            this.txtTransactionNo.TabIndex = 200;
            this.txtTransactionNo.UseSelectable = true;
            this.txtTransactionNo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTransactionNo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(53, 23);
            this.metroLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(104, 25);
            this.metroLabel7.TabIndex = 199;
            this.metroLabel7.Text = "Purchase ID";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.ControlLight;
            // 
            // 
            // 
            this.txtID.CustomButton.Image = null;
            this.txtID.CustomButton.Location = new System.Drawing.Point(239, 2);
            this.txtID.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtID.CustomButton.Name = "";
            this.txtID.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtID.CustomButton.TabIndex = 1;
            this.txtID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtID.CustomButton.UseSelectable = true;
            this.txtID.CustomButton.Visible = false;
            this.txtID.Enabled = false;
            this.txtID.Lines = new string[0];
            this.txtID.Location = new System.Drawing.Point(280, 23);
            this.txtID.Margin = new System.Windows.Forms.Padding(4);
            this.txtID.MaxLength = 32767;
            this.txtID.Name = "txtID";
            this.txtID.PasswordChar = '\0';
            this.txtID.ReadOnly = true;
            this.txtID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtID.SelectedText = "";
            this.txtID.SelectionLength = 0;
            this.txtID.SelectionStart = 0;
            this.txtID.ShortcutsEnabled = true;
            this.txtID.Size = new System.Drawing.Size(265, 28);
            this.txtID.TabIndex = 198;
            this.txtID.UseCustomBackColor = true;
            this.txtID.UseSelectable = true;
            this.txtID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(27, 359);
            this.metroLabel11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(143, 25);
            this.metroLabel11.TabIndex = 197;
            this.metroLabel11.Text = "Purchase Ledger";
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
            this.btnClose.Image = global::GeneralLedger.Properties.Resources.cancel;
            this.btnClose.Location = new System.Drawing.Point(1084, 63);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(137, 44);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnClose.TabIndex = 196;
            this.btnClose.Text = "Close Page";
            // 
            // frmPurchaseLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.txtRunningBalance);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.txtAgent);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.dtTransactionDate);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtPONo);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtTransactionNo);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.metroLabel11);
            this.Controls.Add(this.btnClose);
            this.Name = "frmPurchaseLedger";
            this.Size = new System.Drawing.Size(1394, 798);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSaleLedger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn strTransactionNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn curTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn curRunningBalance;
        private MetroFramework.Controls.MetroButton btnRefresh;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox txtRunningBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn datDateTransaction;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroGrid dtgSaleLedger;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdSalesCustomerLedgerTransactionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn strType;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdCollection;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdAccountReceivableAdjustment;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtAgent;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox txtCustomerName;
        private DevComponents.Editors.DoubleInput txtTotal;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroDateTime dtTransactionDate;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtPONo;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtTransactionNo;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTextBox txtID;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private DevComponents.DotNetBar.ButtonX btnClose;
    }
}
