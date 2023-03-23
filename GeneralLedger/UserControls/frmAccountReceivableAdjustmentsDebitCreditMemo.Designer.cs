namespace GeneralLedger.UserControls
{
    partial class frmAccountReceivableAdjustmentsDebitCreditMemo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chkUseDefaultEntry = new MetroFramework.Controls.MetroCheckBox();
            this.btnDeleteEntry = new MetroFramework.Controls.MetroButton();
            this.btnAddEntry = new MetroFramework.Controls.MetroButton();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.txtTotalCredit = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.txtTotalDebit = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.dgJournalEntry = new MetroFramework.Controls.MetroGrid();
            this.btnFind = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.btnDelete = new MetroFramework.Controls.MetroButton();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.metroLabel14 = new MetroFramework.Controls.MetroLabel();
            this.cbAdjustmentType = new MetroFramework.Controls.MetroComboBox();
            this.txtDescription = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.dtAdjustmentTransactionDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtAdjustmentTransactionNo = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtAdjustmentId = new MetroFramework.Controls.MetroTextBox();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnSearchCustomer = new MetroFramework.Controls.MetroButton();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.txtCustomerID = new MetroFramework.Controls.MetroTextBox();
            this.txtCustomerName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtTotal = new DevComponents.Editors.DoubleInput();
            ((System.ComponentModel.ISupportInitialize)(this.dgJournalEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // chkUseDefaultEntry
            // 
            this.chkUseDefaultEntry.AutoSize = true;
            this.chkUseDefaultEntry.Checked = true;
            this.chkUseDefaultEntry.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseDefaultEntry.DisplayFocus = true;
            this.chkUseDefaultEntry.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkUseDefaultEntry.Location = new System.Drawing.Point(805, 511);
            this.chkUseDefaultEntry.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkUseDefaultEntry.Name = "chkUseDefaultEntry";
            this.chkUseDefaultEntry.Size = new System.Drawing.Size(144, 20);
            this.chkUseDefaultEntry.TabIndex = 245;
            this.chkUseDefaultEntry.Text = "Use default entry?";
            this.chkUseDefaultEntry.UseCustomBackColor = true;
            this.chkUseDefaultEntry.UseSelectable = true;
            // 
            // btnDeleteEntry
            // 
            this.btnDeleteEntry.Location = new System.Drawing.Point(1166, 511);
            this.btnDeleteEntry.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteEntry.Name = "btnDeleteEntry";
            this.btnDeleteEntry.Size = new System.Drawing.Size(132, 28);
            this.btnDeleteEntry.TabIndex = 234;
            this.btnDeleteEntry.Text = "Delete Entry";
            this.btnDeleteEntry.UseSelectable = true;
            this.btnDeleteEntry.Click += new System.EventHandler(this.btnDeleteEntry_Click);
            // 
            // btnAddEntry
            // 
            this.btnAddEntry.Location = new System.Drawing.Point(1025, 511);
            this.btnAddEntry.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddEntry.Name = "btnAddEntry";
            this.btnAddEntry.Size = new System.Drawing.Size(132, 28);
            this.btnAddEntry.TabIndex = 233;
            this.btnAddEntry.Text = "Add Entry";
            this.btnAddEntry.UseSelectable = true;
            this.btnAddEntry.Click += new System.EventHandler(this.btnAddEntry_Click);
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.Location = new System.Drawing.Point(1094, 921);
            this.metroLabel12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(78, 20);
            this.metroLabel12.TabIndex = 232;
            this.metroLabel12.Text = "Total Credit";
            // 
            // txtTotalCredit
            // 
            // 
            // 
            // 
            this.txtTotalCredit.CustomButton.Image = null;
            this.txtTotalCredit.CustomButton.Location = new System.Drawing.Point(129, 2);
            this.txtTotalCredit.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalCredit.CustomButton.Name = "";
            this.txtTotalCredit.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtTotalCredit.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTotalCredit.CustomButton.TabIndex = 1;
            this.txtTotalCredit.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTotalCredit.CustomButton.UseSelectable = true;
            this.txtTotalCredit.CustomButton.Visible = false;
            this.txtTotalCredit.Lines = new string[0];
            this.txtTotalCredit.Location = new System.Drawing.Point(1197, 921);
            this.txtTotalCredit.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalCredit.MaxLength = 32767;
            this.txtTotalCredit.Name = "txtTotalCredit";
            this.txtTotalCredit.PasswordChar = '\0';
            this.txtTotalCredit.ReadOnly = true;
            this.txtTotalCredit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTotalCredit.SelectedText = "";
            this.txtTotalCredit.SelectionLength = 0;
            this.txtTotalCredit.SelectionStart = 0;
            this.txtTotalCredit.ShortcutsEnabled = true;
            this.txtTotalCredit.Size = new System.Drawing.Size(155, 28);
            this.txtTotalCredit.TabIndex = 231;
            this.txtTotalCredit.UseSelectable = true;
            this.txtTotalCredit.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTotalCredit.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.Location = new System.Drawing.Point(805, 921);
            this.metroLabel13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(74, 20);
            this.metroLabel13.TabIndex = 230;
            this.metroLabel13.Text = "Total Debit";
            // 
            // txtTotalDebit
            // 
            // 
            // 
            // 
            this.txtTotalDebit.CustomButton.Image = null;
            this.txtTotalDebit.CustomButton.Location = new System.Drawing.Point(129, 2);
            this.txtTotalDebit.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalDebit.CustomButton.Name = "";
            this.txtTotalDebit.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtTotalDebit.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTotalDebit.CustomButton.TabIndex = 1;
            this.txtTotalDebit.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTotalDebit.CustomButton.UseSelectable = true;
            this.txtTotalDebit.CustomButton.Visible = false;
            this.txtTotalDebit.Lines = new string[0];
            this.txtTotalDebit.Location = new System.Drawing.Point(906, 921);
            this.txtTotalDebit.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalDebit.MaxLength = 32767;
            this.txtTotalDebit.Name = "txtTotalDebit";
            this.txtTotalDebit.PasswordChar = '\0';
            this.txtTotalDebit.ReadOnly = true;
            this.txtTotalDebit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTotalDebit.SelectedText = "";
            this.txtTotalDebit.SelectionLength = 0;
            this.txtTotalDebit.SelectionStart = 0;
            this.txtTotalDebit.ShortcutsEnabled = true;
            this.txtTotalDebit.Size = new System.Drawing.Size(155, 28);
            this.txtTotalDebit.TabIndex = 229;
            this.txtTotalDebit.UseSelectable = true;
            this.txtTotalDebit.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTotalDebit.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(40, 511);
            this.metroLabel11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(90, 20);
            this.metroLabel11.TabIndex = 228;
            this.metroLabel11.Text = "Journal Entry";
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
            this.dgJournalEntry.Location = new System.Drawing.Point(34, 553);
            this.dgJournalEntry.Margin = new System.Windows.Forms.Padding(4);
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
            this.dgJournalEntry.Size = new System.Drawing.Size(1327, 341);
            this.dgJournalEntry.TabIndex = 227;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(490, 964);
            this.btnFind.Margin = new System.Windows.Forms.Padding(4);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(132, 28);
            this.btnFind.TabIndex = 226;
            this.btnFind.Text = "Find";
            this.btnFind.UseSelectable = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(78, 964);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(4);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(132, 28);
            this.metroButton1.TabIndex = 225;
            this.metroButton1.Text = "Add";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(352, 964);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(132, 28);
            this.btnDelete.TabIndex = 224;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(216, 964);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(132, 28);
            this.btnSave.TabIndex = 223;
            this.btnSave.Text = "Save";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // metroLabel14
            // 
            this.metroLabel14.AutoSize = true;
            this.metroLabel14.Location = new System.Drawing.Point(40, 94);
            this.metroLabel14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Size = new System.Drawing.Size(139, 20);
            this.metroLabel14.TabIndex = 222;
            this.metroLabel14.Text = "A/R Adjustment Type";
            // 
            // cbAdjustmentType
            // 
            this.cbAdjustmentType.FormattingEnabled = true;
            this.cbAdjustmentType.ItemHeight = 24;
            this.cbAdjustmentType.Location = new System.Drawing.Point(316, 94);
            this.cbAdjustmentType.Margin = new System.Windows.Forms.Padding(4);
            this.cbAdjustmentType.Name = "cbAdjustmentType";
            this.cbAdjustmentType.Size = new System.Drawing.Size(265, 30);
            this.cbAdjustmentType.TabIndex = 221;
            this.cbAdjustmentType.UseSelectable = true;
            // 
            // txtDescription
            // 
            // 
            // 
            // 
            this.txtDescription.CustomButton.Image = null;
            this.txtDescription.CustomButton.Location = new System.Drawing.Point(727, 2);
            this.txtDescription.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.CustomButton.Name = "";
            this.txtDescription.CustomButton.Size = new System.Drawing.Size(207, 207);
            this.txtDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDescription.CustomButton.TabIndex = 1;
            this.txtDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDescription.CustomButton.UseSelectable = true;
            this.txtDescription.CustomButton.Visible = false;
            this.txtDescription.Lines = new string[0];
            this.txtDescription.Location = new System.Drawing.Point(232, 284);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.MaxLength = 32767;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PasswordChar = '\0';
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDescription.SelectedText = "";
            this.txtDescription.SelectionLength = 0;
            this.txtDescription.SelectionStart = 0;
            this.txtDescription.ShortcutsEnabled = true;
            this.txtDescription.Size = new System.Drawing.Size(937, 212);
            this.txtDescription.TabIndex = 220;
            this.txtDescription.UseSelectable = true;
            this.txtDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(40, 284);
            this.metroLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(79, 20);
            this.metroLabel9.TabIndex = 219;
            this.metroLabel9.Text = "Description";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(40, 191);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(211, 20);
            this.metroLabel5.TabIndex = 218;
            this.metroLabel5.Text = "A/R Adjustment Transaction Date";
            // 
            // dtAdjustmentTransactionDate
            // 
            this.dtAdjustmentTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtAdjustmentTransactionDate.Location = new System.Drawing.Point(316, 191);
            this.dtAdjustmentTransactionDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtAdjustmentTransactionDate.MinimumSize = new System.Drawing.Size(0, 30);
            this.dtAdjustmentTransactionDate.Name = "dtAdjustmentTransactionDate";
            this.dtAdjustmentTransactionDate.Size = new System.Drawing.Size(265, 30);
            this.dtAdjustmentTransactionDate.TabIndex = 217;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(40, 144);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(204, 20);
            this.metroLabel4.TabIndex = 216;
            this.metroLabel4.Text = "A/R Adjustment Transaction No.";
            // 
            // txtAdjustmentTransactionNo
            // 
            // 
            // 
            // 
            this.txtAdjustmentTransactionNo.CustomButton.Image = null;
            this.txtAdjustmentTransactionNo.CustomButton.Location = new System.Drawing.Point(239, 2);
            this.txtAdjustmentTransactionNo.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtAdjustmentTransactionNo.CustomButton.Name = "";
            this.txtAdjustmentTransactionNo.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtAdjustmentTransactionNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAdjustmentTransactionNo.CustomButton.TabIndex = 1;
            this.txtAdjustmentTransactionNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAdjustmentTransactionNo.CustomButton.UseSelectable = true;
            this.txtAdjustmentTransactionNo.CustomButton.Visible = false;
            this.txtAdjustmentTransactionNo.Lines = new string[0];
            this.txtAdjustmentTransactionNo.Location = new System.Drawing.Point(316, 144);
            this.txtAdjustmentTransactionNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtAdjustmentTransactionNo.MaxLength = 32767;
            this.txtAdjustmentTransactionNo.Name = "txtAdjustmentTransactionNo";
            this.txtAdjustmentTransactionNo.PasswordChar = '\0';
            this.txtAdjustmentTransactionNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAdjustmentTransactionNo.SelectedText = "";
            this.txtAdjustmentTransactionNo.SelectionLength = 0;
            this.txtAdjustmentTransactionNo.SelectionStart = 0;
            this.txtAdjustmentTransactionNo.ShortcutsEnabled = true;
            this.txtAdjustmentTransactionNo.Size = new System.Drawing.Size(265, 28);
            this.txtAdjustmentTransactionNo.TabIndex = 215;
            this.txtAdjustmentTransactionNo.UseSelectable = true;
            this.txtAdjustmentTransactionNo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAdjustmentTransactionNo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(40, 46);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(120, 20);
            this.metroLabel3.TabIndex = 214;
            this.metroLabel3.Text = "A/R Adjustment Id";
            // 
            // txtAdjustmentId
            // 
            this.txtAdjustmentId.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtAdjustmentId.CustomButton.Image = null;
            this.txtAdjustmentId.CustomButton.Location = new System.Drawing.Point(239, 2);
            this.txtAdjustmentId.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtAdjustmentId.CustomButton.Name = "";
            this.txtAdjustmentId.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtAdjustmentId.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAdjustmentId.CustomButton.TabIndex = 1;
            this.txtAdjustmentId.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAdjustmentId.CustomButton.UseSelectable = true;
            this.txtAdjustmentId.CustomButton.Visible = false;
            this.txtAdjustmentId.Enabled = false;
            this.txtAdjustmentId.Lines = new string[0];
            this.txtAdjustmentId.Location = new System.Drawing.Point(316, 46);
            this.txtAdjustmentId.Margin = new System.Windows.Forms.Padding(4);
            this.txtAdjustmentId.MaxLength = 32767;
            this.txtAdjustmentId.Name = "txtAdjustmentId";
            this.txtAdjustmentId.PasswordChar = '\0';
            this.txtAdjustmentId.ReadOnly = true;
            this.txtAdjustmentId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAdjustmentId.SelectedText = "";
            this.txtAdjustmentId.SelectionLength = 0;
            this.txtAdjustmentId.SelectionStart = 0;
            this.txtAdjustmentId.ShortcutsEnabled = true;
            this.txtAdjustmentId.Size = new System.Drawing.Size(265, 28);
            this.txtAdjustmentId.TabIndex = 213;
            this.txtAdjustmentId.UseCustomBackColor = true;
            this.txtAdjustmentId.UseSelectable = true;
            this.txtAdjustmentId.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtAdjustmentId.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
            this.btnClose.Image = global::GeneralLedger.Properties.Resources.cancel;
            this.btnClose.Location = new System.Drawing.Point(1370, 25);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(137, 44);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnClose.TabIndex = 207;
            this.btnClose.Text = "Close Page";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.Location = new System.Drawing.Point(1039, 46);
            this.btnSearchCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(132, 28);
            this.btnSearchCustomer.TabIndex = 250;
            this.btnSearchCustomer.Text = "Search Customer";
            this.btnSearchCustomer.UseSelectable = true;
            this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(614, 95);
            this.metroLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(69, 20);
            this.metroLabel6.TabIndex = 249;
            this.metroLabel6.Text = "Customer";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtCustomerID.CustomButton.Image = null;
            this.txtCustomerID.CustomButton.Location = new System.Drawing.Point(239, 2);
            this.txtCustomerID.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerID.CustomButton.Name = "";
            this.txtCustomerID.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtCustomerID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCustomerID.CustomButton.TabIndex = 1;
            this.txtCustomerID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCustomerID.CustomButton.UseSelectable = true;
            this.txtCustomerID.CustomButton.Visible = false;
            this.txtCustomerID.Lines = new string[0];
            this.txtCustomerID.Location = new System.Drawing.Point(766, 46);
            this.txtCustomerID.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerID.MaxLength = 32767;
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.PasswordChar = '\0';
            this.txtCustomerID.ReadOnly = true;
            this.txtCustomerID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCustomerID.SelectedText = "";
            this.txtCustomerID.SelectionLength = 0;
            this.txtCustomerID.SelectionStart = 0;
            this.txtCustomerID.ShortcutsEnabled = true;
            this.txtCustomerID.Size = new System.Drawing.Size(265, 28);
            this.txtCustomerID.TabIndex = 248;
            this.txtCustomerID.UseCustomBackColor = true;
            this.txtCustomerID.UseSelectable = true;
            this.txtCustomerID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtCustomerID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.SystemColors.Control;
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
            this.txtCustomerName.Location = new System.Drawing.Point(766, 95);
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
            this.txtCustomerName.TabIndex = 247;
            this.txtCustomerName.UseCustomBackColor = true;
            this.txtCustomerName.UseSelectable = true;
            this.txtCustomerName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCustomerName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(614, 46);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(86, 20);
            this.metroLabel1.TabIndex = 246;
            this.metroLabel1.Text = "Customer ID";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(614, 144);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(90, 20);
            this.metroLabel2.TabIndex = 252;
            this.metroLabel2.Text = "Total Amount";
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
            this.txtTotal.Location = new System.Drawing.Point(766, 144);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTotal.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ShowUpDown = true;
            this.txtTotal.Size = new System.Drawing.Size(267, 28);
            this.txtTotal.TabIndex = 251;
            // 
            // frmAccountReceivableAdjustmentsDebitCreditMemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.btnSearchCustomer);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.chkUseDefaultEntry);
            this.Controls.Add(this.btnDeleteEntry);
            this.Controls.Add(this.btnAddEntry);
            this.Controls.Add(this.metroLabel12);
            this.Controls.Add(this.txtTotalCredit);
            this.Controls.Add(this.metroLabel13);
            this.Controls.Add(this.txtTotalDebit);
            this.Controls.Add(this.metroLabel11);
            this.Controls.Add(this.dgJournalEntry);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.metroLabel14);
            this.Controls.Add(this.cbAdjustmentType);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.dtAdjustmentTransactionDate);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.txtAdjustmentTransactionNo);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.txtAdjustmentId);
            this.Controls.Add(this.btnClose);
            this.Name = "frmAccountReceivableAdjustmentsDebitCreditMemo";
            this.Size = new System.Drawing.Size(1544, 1129);
            this.Load += new System.EventHandler(this.frmAccountReceivableAdjustmentsDebitCreditMemo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgJournalEntry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroCheckBox chkUseDefaultEntry;
        private MetroFramework.Controls.MetroButton btnDeleteEntry;
        private MetroFramework.Controls.MetroButton btnAddEntry;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroTextBox txtTotalCredit;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroTextBox txtTotalDebit;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroGrid dgJournalEntry;
        private MetroFramework.Controls.MetroButton btnFind;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton btnDelete;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroLabel metroLabel14;
        private MetroFramework.Controls.MetroComboBox cbAdjustmentType;
        private MetroFramework.Controls.MetroTextBox txtDescription;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroDateTime dtAdjustmentTransactionDate;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtAdjustmentTransactionNo;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtAdjustmentId;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private MetroFramework.Controls.MetroButton btnSearchCustomer;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox txtCustomerID;
        private MetroFramework.Controls.MetroTextBox txtCustomerName;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private DevComponents.Editors.DoubleInput txtTotal;
    }
}