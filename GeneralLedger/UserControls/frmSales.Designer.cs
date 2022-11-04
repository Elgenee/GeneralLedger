namespace GeneralLedger.UserControls
{
    partial class frmSales
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
            this.btnFind = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.btnDelete = new MetroFramework.Controls.MetroButton();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.txtID = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtTransactionNo = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtPONo = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.dtTransactionDate = new MetroFramework.Controls.MetroDateTime();
            this.txtTotal = new DevComponents.Editors.DoubleInput();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.txtCustomerName = new MetroFramework.Controls.MetroTextBox();
            this.txtCustomerID = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.txtTerms = new DevComponents.Editors.IntegerInput();
            this.metroLabel19 = new MetroFramework.Controls.MetroLabel();
            this.dgJournalEntry = new MetroFramework.Controls.MetroGrid();
            this.btnSearchCustomer = new MetroFramework.Controls.MetroButton();
            this.txtDescription = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.txtAgentID = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.txtAgent = new MetroFramework.Controls.MetroTextBox();
            this.btnSearchAgent = new MetroFramework.Controls.MetroButton();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTerms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgJournalEntry)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(642, 764);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(99, 23);
            this.btnFind.TabIndex = 97;
            this.btnFind.Text = "Find";
            this.btnFind.UseSelectable = true;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(332, 764);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(99, 23);
            this.metroButton1.TabIndex = 96;
            this.metroButton1.Text = "Add";
            this.metroButton1.UseSelectable = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(538, 764);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 23);
            this.btnDelete.TabIndex = 95;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseSelectable = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(435, 764);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 23);
            this.btnSave.TabIndex = 94;
            this.btnSave.Text = "Save";
            this.btnSave.UseSelectable = true;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(22, 27);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(49, 19);
            this.metroLabel7.TabIndex = 101;
            this.metroLabel7.Text = "Sale ID";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.ControlLight;
            // 
            // 
            // 
            this.txtID.CustomButton.Image = null;
            this.txtID.CustomButton.Location = new System.Drawing.Point(177, 1);
            this.txtID.CustomButton.Name = "";
            this.txtID.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtID.CustomButton.TabIndex = 1;
            this.txtID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtID.CustomButton.UseSelectable = true;
            this.txtID.CustomButton.Visible = false;
            this.txtID.Enabled = false;
            this.txtID.Lines = new string[0];
            this.txtID.Location = new System.Drawing.Point(169, 27);
            this.txtID.MaxLength = 32767;
            this.txtID.Name = "txtID";
            this.txtID.PasswordChar = '\0';
            this.txtID.ReadOnly = true;
            this.txtID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtID.SelectedText = "";
            this.txtID.SelectionLength = 0;
            this.txtID.SelectionStart = 0;
            this.txtID.ShortcutsEnabled = true;
            this.txtID.Size = new System.Drawing.Size(199, 23);
            this.txtID.TabIndex = 100;
            this.txtID.UseCustomBackColor = true;
            this.txtID.UseSelectable = true;
            this.txtID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(22, 67);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(98, 19);
            this.metroLabel1.TabIndex = 103;
            this.metroLabel1.Text = "Transaction No.";
            // 
            // txtTransactionNo
            // 
            // 
            // 
            // 
            this.txtTransactionNo.CustomButton.Image = null;
            this.txtTransactionNo.CustomButton.Location = new System.Drawing.Point(177, 1);
            this.txtTransactionNo.CustomButton.Name = "";
            this.txtTransactionNo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtTransactionNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTransactionNo.CustomButton.TabIndex = 1;
            this.txtTransactionNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTransactionNo.CustomButton.UseSelectable = true;
            this.txtTransactionNo.CustomButton.Visible = false;
            this.txtTransactionNo.Lines = new string[0];
            this.txtTransactionNo.Location = new System.Drawing.Point(169, 67);
            this.txtTransactionNo.MaxLength = 32767;
            this.txtTransactionNo.Name = "txtTransactionNo";
            this.txtTransactionNo.PasswordChar = '\0';
            this.txtTransactionNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTransactionNo.SelectedText = "";
            this.txtTransactionNo.SelectionLength = 0;
            this.txtTransactionNo.SelectionStart = 0;
            this.txtTransactionNo.ShortcutsEnabled = true;
            this.txtTransactionNo.Size = new System.Drawing.Size(199, 23);
            this.txtTransactionNo.TabIndex = 102;
            this.txtTransactionNo.UseSelectable = true;
            this.txtTransactionNo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTransactionNo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(22, 105);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(53, 19);
            this.metroLabel2.TabIndex = 105;
            this.metroLabel2.Text = "PO No.";
            // 
            // txtPONo
            // 
            // 
            // 
            // 
            this.txtPONo.CustomButton.Image = null;
            this.txtPONo.CustomButton.Location = new System.Drawing.Point(177, 1);
            this.txtPONo.CustomButton.Name = "";
            this.txtPONo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPONo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPONo.CustomButton.TabIndex = 1;
            this.txtPONo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPONo.CustomButton.UseSelectable = true;
            this.txtPONo.CustomButton.Visible = false;
            this.txtPONo.Lines = new string[0];
            this.txtPONo.Location = new System.Drawing.Point(169, 105);
            this.txtPONo.MaxLength = 32767;
            this.txtPONo.Name = "txtPONo";
            this.txtPONo.PasswordChar = '\0';
            this.txtPONo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPONo.SelectedText = "";
            this.txtPONo.SelectionLength = 0;
            this.txtPONo.SelectionStart = 0;
            this.txtPONo.ShortcutsEnabled = true;
            this.txtPONo.Size = new System.Drawing.Size(199, 23);
            this.txtPONo.TabIndex = 104;
            this.txtPONo.UseSelectable = true;
            this.txtPONo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPONo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(22, 143);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(104, 19);
            this.metroLabel3.TabIndex = 107;
            this.metroLabel3.Text = "Transaction Date";
            // 
            // dtTransactionDate
            // 
            this.dtTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTransactionDate.Location = new System.Drawing.Point(169, 143);
            this.dtTransactionDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtTransactionDate.Name = "dtTransactionDate";
            this.dtTransactionDate.Size = new System.Drawing.Size(200, 29);
            this.dtTransactionDate.TabIndex = 106;
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
            this.txtTotal.Location = new System.Drawing.Point(169, 188);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotal.MinimumSize = new System.Drawing.Size(0, 23);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ShowUpDown = true;
            this.txtTotal.Size = new System.Drawing.Size(200, 23);
            this.txtTotal.TabIndex = 108;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(22, 188);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(36, 19);
            this.metroLabel4.TabIndex = 109;
            this.metroLabel4.Text = "Total";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(428, 27);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(82, 19);
            this.metroLabel5.TabIndex = 111;
            this.metroLabel5.Text = "Customer ID";
            // 
            // txtCustomerName
            // 
            // 
            // 
            // 
            this.txtCustomerName.CustomButton.Image = null;
            this.txtCustomerName.CustomButton.Location = new System.Drawing.Point(177, 1);
            this.txtCustomerName.CustomButton.Name = "";
            this.txtCustomerName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCustomerName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCustomerName.CustomButton.TabIndex = 1;
            this.txtCustomerName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCustomerName.CustomButton.UseSelectable = true;
            this.txtCustomerName.CustomButton.Visible = false;
            this.txtCustomerName.Lines = new string[0];
            this.txtCustomerName.Location = new System.Drawing.Point(542, 67);
            this.txtCustomerName.MaxLength = 32767;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.PasswordChar = '\0';
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCustomerName.SelectedText = "";
            this.txtCustomerName.SelectionLength = 0;
            this.txtCustomerName.SelectionStart = 0;
            this.txtCustomerName.ShortcutsEnabled = true;
            this.txtCustomerName.Size = new System.Drawing.Size(199, 23);
            this.txtCustomerName.TabIndex = 112;
            this.txtCustomerName.UseSelectable = true;
            this.txtCustomerName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCustomerName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.BackColor = System.Drawing.SystemColors.ControlLight;
            // 
            // 
            // 
            this.txtCustomerID.CustomButton.Image = null;
            this.txtCustomerID.CustomButton.Location = new System.Drawing.Point(177, 1);
            this.txtCustomerID.CustomButton.Name = "";
            this.txtCustomerID.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCustomerID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCustomerID.CustomButton.TabIndex = 1;
            this.txtCustomerID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCustomerID.CustomButton.UseSelectable = true;
            this.txtCustomerID.CustomButton.Visible = false;
            this.txtCustomerID.Enabled = false;
            this.txtCustomerID.Lines = new string[0];
            this.txtCustomerID.Location = new System.Drawing.Point(542, 27);
            this.txtCustomerID.MaxLength = 32767;
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.PasswordChar = '\0';
            this.txtCustomerID.ReadOnly = true;
            this.txtCustomerID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCustomerID.SelectedText = "";
            this.txtCustomerID.SelectionLength = 0;
            this.txtCustomerID.SelectionStart = 0;
            this.txtCustomerID.ShortcutsEnabled = true;
            this.txtCustomerID.Size = new System.Drawing.Size(199, 23);
            this.txtCustomerID.TabIndex = 113;
            this.txtCustomerID.UseCustomBackColor = true;
            this.txtCustomerID.UseSelectable = true;
            this.txtCustomerID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtCustomerID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(428, 67);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(66, 19);
            this.metroLabel6.TabIndex = 114;
            this.metroLabel6.Text = "Customer";
            // 
            // txtTerms
            // 
            // 
            // 
            // 
            this.txtTerms.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTerms.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtTerms.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTerms.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTerms.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTerms.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTerms.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTerms.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTerms.Location = new System.Drawing.Point(542, 105);
            this.txtTerms.Margin = new System.Windows.Forms.Padding(2);
            this.txtTerms.MinimumSize = new System.Drawing.Size(0, 21);
            this.txtTerms.Name = "txtTerms";
            this.txtTerms.ShowUpDown = true;
            this.txtTerms.Size = new System.Drawing.Size(199, 21);
            this.txtTerms.TabIndex = 116;
            this.txtTerms.WatermarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            // 
            // metroLabel19
            // 
            this.metroLabel19.AutoSize = true;
            this.metroLabel19.Location = new System.Drawing.Point(428, 105);
            this.metroLabel19.Name = "metroLabel19";
            this.metroLabel19.Size = new System.Drawing.Size(43, 19);
            this.metroLabel19.TabIndex = 115;
            this.metroLabel19.Text = "Terms";
            // 
            // dgJournalEntry
            // 
            this.dgJournalEntry.AllowUserToResizeRows = false;
            this.dgJournalEntry.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgJournalEntry.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgJournalEntry.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgJournalEntry.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgJournalEntry.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgJournalEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgJournalEntry.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgJournalEntry.EnableHeadersVisualStyles = false;
            this.dgJournalEntry.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgJournalEntry.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgJournalEntry.Location = new System.Drawing.Point(22, 453);
            this.dgJournalEntry.Name = "dgJournalEntry";
            this.dgJournalEntry.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgJournalEntry.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgJournalEntry.RowHeadersWidth = 51;
            this.dgJournalEntry.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgJournalEntry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgJournalEntry.Size = new System.Drawing.Size(995, 277);
            this.dgJournalEntry.TabIndex = 117;
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.Location = new System.Drawing.Point(747, 27);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(99, 23);
            this.btnSearchCustomer.TabIndex = 118;
            this.btnSearchCustomer.Text = "Search Customer";
            this.btnSearchCustomer.UseSelectable = true;
            this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);
            // 
            // txtDescription
            // 
            // 
            // 
            // 
            this.txtDescription.CustomButton.Image = null;
            this.txtDescription.CustomButton.Location = new System.Drawing.Point(402, 2);
            this.txtDescription.CustomButton.Name = "";
            this.txtDescription.CustomButton.Size = new System.Drawing.Size(167, 167);
            this.txtDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDescription.CustomButton.TabIndex = 1;
            this.txtDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDescription.CustomButton.UseSelectable = true;
            this.txtDescription.CustomButton.Visible = false;
            this.txtDescription.Lines = new string[0];
            this.txtDescription.Location = new System.Drawing.Point(169, 230);
            this.txtDescription.MaxLength = 32767;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PasswordChar = '\0';
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDescription.SelectedText = "";
            this.txtDescription.SelectionLength = 0;
            this.txtDescription.SelectionStart = 0;
            this.txtDescription.ShortcutsEnabled = true;
            this.txtDescription.Size = new System.Drawing.Size(572, 172);
            this.txtDescription.TabIndex = 120;
            this.txtDescription.UseSelectable = true;
            this.txtDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(22, 230);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(74, 19);
            this.metroLabel8.TabIndex = 119;
            this.metroLabel8.Text = "Description";
            // 
            // txtAgentID
            // 
            this.txtAgentID.BackColor = System.Drawing.SystemColors.ControlLight;
            // 
            // 
            // 
            this.txtAgentID.CustomButton.Image = null;
            this.txtAgentID.CustomButton.Location = new System.Drawing.Point(177, 1);
            this.txtAgentID.CustomButton.Name = "";
            this.txtAgentID.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtAgentID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAgentID.CustomButton.TabIndex = 1;
            this.txtAgentID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAgentID.CustomButton.UseSelectable = true;
            this.txtAgentID.CustomButton.Visible = false;
            this.txtAgentID.Enabled = false;
            this.txtAgentID.Lines = new string[0];
            this.txtAgentID.Location = new System.Drawing.Point(542, 143);
            this.txtAgentID.MaxLength = 32767;
            this.txtAgentID.Name = "txtAgentID";
            this.txtAgentID.PasswordChar = '\0';
            this.txtAgentID.ReadOnly = true;
            this.txtAgentID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAgentID.SelectedText = "";
            this.txtAgentID.SelectionLength = 0;
            this.txtAgentID.SelectionStart = 0;
            this.txtAgentID.ShortcutsEnabled = true;
            this.txtAgentID.Size = new System.Drawing.Size(199, 23);
            this.txtAgentID.TabIndex = 122;
            this.txtAgentID.UseCustomBackColor = true;
            this.txtAgentID.UseSelectable = true;
            this.txtAgentID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtAgentID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(428, 143);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(60, 19);
            this.metroLabel9.TabIndex = 121;
            this.metroLabel9.Text = "Agent ID";
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(428, 188);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(44, 19);
            this.metroLabel10.TabIndex = 124;
            this.metroLabel10.Text = "Agent";
            // 
            // txtAgent
            // 
            // 
            // 
            // 
            this.txtAgent.CustomButton.Image = null;
            this.txtAgent.CustomButton.Location = new System.Drawing.Point(177, 1);
            this.txtAgent.CustomButton.Name = "";
            this.txtAgent.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtAgent.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAgent.CustomButton.TabIndex = 1;
            this.txtAgent.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAgent.CustomButton.UseSelectable = true;
            this.txtAgent.CustomButton.Visible = false;
            this.txtAgent.Lines = new string[0];
            this.txtAgent.Location = new System.Drawing.Point(542, 188);
            this.txtAgent.MaxLength = 32767;
            this.txtAgent.Name = "txtAgent";
            this.txtAgent.PasswordChar = '\0';
            this.txtAgent.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAgent.SelectedText = "";
            this.txtAgent.SelectionLength = 0;
            this.txtAgent.SelectionStart = 0;
            this.txtAgent.ShortcutsEnabled = true;
            this.txtAgent.Size = new System.Drawing.Size(199, 23);
            this.txtAgent.TabIndex = 123;
            this.txtAgent.UseSelectable = true;
            this.txtAgent.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAgent.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSearchAgent
            // 
            this.btnSearchAgent.Location = new System.Drawing.Point(747, 143);
            this.btnSearchAgent.Name = "btnSearchAgent";
            this.btnSearchAgent.Size = new System.Drawing.Size(99, 23);
            this.btnSearchAgent.TabIndex = 125;
            this.btnSearchAgent.Text = "Search Agent";
            this.btnSearchAgent.UseSelectable = true;
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(35, 420);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(85, 19);
            this.metroLabel11.TabIndex = 126;
            this.metroLabel11.Text = "Journal Entry";
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
            this.btnClose.Image = global::GeneralLedger.Properties.Resources.cancel;
            this.btnClose.Location = new System.Drawing.Point(917, 27);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 36);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnClose.TabIndex = 90;
            this.btnClose.Text = "Close Page";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroLabel11);
            this.Controls.Add(this.btnSearchAgent);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.txtAgent);
            this.Controls.Add(this.txtAgentID);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.btnSearchCustomer);
            this.Controls.Add(this.dgJournalEntry);
            this.Controls.Add(this.txtTerms);
            this.Controls.Add(this.metroLabel19);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.dtTransactionDate);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtPONo);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtTransactionNo);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Name = "frmSales";
            this.Size = new System.Drawing.Size(1057, 927);
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTerms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgJournalEntry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnClose;
        private MetroFramework.Controls.MetroButton btnFind;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton btnDelete;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTextBox txtID;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtTransactionNo;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtPONo;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroDateTime dtTransactionDate;
        private DevComponents.Editors.DoubleInput txtTotal;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox txtCustomerName;
        private MetroFramework.Controls.MetroTextBox txtCustomerID;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private DevComponents.Editors.IntegerInput txtTerms;
        private MetroFramework.Controls.MetroLabel metroLabel19;
        private MetroFramework.Controls.MetroGrid dgJournalEntry;
        private MetroFramework.Controls.MetroButton btnSearchCustomer;
        private MetroFramework.Controls.MetroTextBox txtDescription;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox txtAgentID;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroTextBox txtAgent;
        private MetroFramework.Controls.MetroButton btnSearchAgent;
        private MetroFramework.Controls.MetroLabel metroLabel11;
    }
}
