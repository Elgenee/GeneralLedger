namespace GeneralLedger.UserControls
{
    partial class frmAccountReceivableAdjustmentsReturnCheck
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.btnSearchSale = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtCollectionTransactionNo = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.txtCollectionId = new MetroFramework.Controls.MetroTextBox();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.txtSaleTransactionNo = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.txtCustomerName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtCheckDetails = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.cbBank = new MetroFramework.Controls.MetroComboBox();
            this.chkIsCash = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel15 = new MetroFramework.Controls.MetroLabel();
            this.txtCollectionTotal = new DevComponents.Editors.DoubleInput();
            this.chkUseDefaultEntry = new MetroFramework.Controls.MetroCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgJournalEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCollectionTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeleteEntry
            // 
            this.btnDeleteEntry.Location = new System.Drawing.Point(1169, 604);
            this.btnDeleteEntry.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteEntry.Name = "btnDeleteEntry";
            this.btnDeleteEntry.Size = new System.Drawing.Size(132, 28);
            this.btnDeleteEntry.TabIndex = 194;
            this.btnDeleteEntry.Text = "Delete Entry";
            this.btnDeleteEntry.UseSelectable = true;
            this.btnDeleteEntry.Click += new System.EventHandler(this.btnDeleteEntry_Click);
            // 
            // btnAddEntry
            // 
            this.btnAddEntry.Location = new System.Drawing.Point(1028, 604);
            this.btnAddEntry.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddEntry.Name = "btnAddEntry";
            this.btnAddEntry.Size = new System.Drawing.Size(132, 28);
            this.btnAddEntry.TabIndex = 193;
            this.btnAddEntry.Text = "Add Entry";
            this.btnAddEntry.UseSelectable = true;
            this.btnAddEntry.Click += new System.EventHandler(this.btnAddEntry_Click);
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.Location = new System.Drawing.Point(1097, 1014);
            this.metroLabel12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(78, 20);
            this.metroLabel12.TabIndex = 192;
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
            this.txtTotalCredit.Location = new System.Drawing.Point(1200, 1014);
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
            this.txtTotalCredit.TabIndex = 191;
            this.txtTotalCredit.UseSelectable = true;
            this.txtTotalCredit.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTotalCredit.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.Location = new System.Drawing.Point(808, 1014);
            this.metroLabel13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(74, 20);
            this.metroLabel13.TabIndex = 190;
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
            this.txtTotalDebit.Location = new System.Drawing.Point(909, 1014);
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
            this.txtTotalDebit.TabIndex = 189;
            this.txtTotalDebit.UseSelectable = true;
            this.txtTotalDebit.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTotalDebit.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(43, 604);
            this.metroLabel11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(90, 20);
            this.metroLabel11.TabIndex = 188;
            this.metroLabel11.Text = "Journal Entry";
            // 
            // dgJournalEntry
            // 
            this.dgJournalEntry.AllowUserToResizeRows = false;
            this.dgJournalEntry.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgJournalEntry.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgJournalEntry.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgJournalEntry.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgJournalEntry.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgJournalEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgJournalEntry.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgJournalEntry.EnableHeadersVisualStyles = false;
            this.dgJournalEntry.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgJournalEntry.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgJournalEntry.Location = new System.Drawing.Point(37, 646);
            this.dgJournalEntry.Margin = new System.Windows.Forms.Padding(4);
            this.dgJournalEntry.Name = "dgJournalEntry";
            this.dgJournalEntry.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgJournalEntry.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgJournalEntry.RowHeadersWidth = 51;
            this.dgJournalEntry.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgJournalEntry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgJournalEntry.Size = new System.Drawing.Size(1327, 341);
            this.dgJournalEntry.TabIndex = 187;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(493, 1057);
            this.btnFind.Margin = new System.Windows.Forms.Padding(4);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(132, 28);
            this.btnFind.TabIndex = 186;
            this.btnFind.Text = "Find";
            this.btnFind.UseSelectable = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(81, 1057);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(4);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(132, 28);
            this.metroButton1.TabIndex = 185;
            this.metroButton1.Text = "Add";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(355, 1057);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(132, 28);
            this.btnDelete.TabIndex = 184;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(219, 1057);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(132, 28);
            this.btnSave.TabIndex = 183;
            this.btnSave.Text = "Save";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // metroLabel14
            // 
            this.metroLabel14.AutoSize = true;
            this.metroLabel14.Location = new System.Drawing.Point(43, 84);
            this.metroLabel14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Size = new System.Drawing.Size(139, 20);
            this.metroLabel14.TabIndex = 180;
            this.metroLabel14.Text = "A/R Adjustment Type";
            // 
            // cbAdjustmentType
            // 
            this.cbAdjustmentType.FormattingEnabled = true;
            this.cbAdjustmentType.ItemHeight = 24;
            this.cbAdjustmentType.Location = new System.Drawing.Point(319, 84);
            this.cbAdjustmentType.Margin = new System.Windows.Forms.Padding(4);
            this.cbAdjustmentType.Name = "cbAdjustmentType";
            this.cbAdjustmentType.Size = new System.Drawing.Size(265, 30);
            this.cbAdjustmentType.TabIndex = 179;
            this.cbAdjustmentType.UseSelectable = true;
            this.cbAdjustmentType.SelectedIndexChanged += new System.EventHandler(this.cbAdjustmentType_SelectedIndexChanged);
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
            this.txtDescription.Location = new System.Drawing.Point(235, 377);
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
            this.txtDescription.TabIndex = 177;
            this.txtDescription.UseSelectable = true;
            this.txtDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(43, 377);
            this.metroLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(79, 20);
            this.metroLabel9.TabIndex = 176;
            this.metroLabel9.Text = "Description";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(43, 182);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(211, 20);
            this.metroLabel5.TabIndex = 173;
            this.metroLabel5.Text = "A/R Adjustment Transaction Date";
            // 
            // dtAdjustmentTransactionDate
            // 
            this.dtAdjustmentTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtAdjustmentTransactionDate.Location = new System.Drawing.Point(319, 182);
            this.dtAdjustmentTransactionDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtAdjustmentTransactionDate.MinimumSize = new System.Drawing.Size(0, 30);
            this.dtAdjustmentTransactionDate.Name = "dtAdjustmentTransactionDate";
            this.dtAdjustmentTransactionDate.Size = new System.Drawing.Size(265, 30);
            this.dtAdjustmentTransactionDate.TabIndex = 172;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(43, 134);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(204, 20);
            this.metroLabel4.TabIndex = 171;
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
            this.txtAdjustmentTransactionNo.Location = new System.Drawing.Point(319, 134);
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
            this.txtAdjustmentTransactionNo.TabIndex = 170;
            this.txtAdjustmentTransactionNo.UseSelectable = true;
            this.txtAdjustmentTransactionNo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAdjustmentTransactionNo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(43, 36);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(120, 20);
            this.metroLabel3.TabIndex = 169;
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
            this.txtAdjustmentId.Location = new System.Drawing.Point(319, 36);
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
            this.txtAdjustmentId.TabIndex = 168;
            this.txtAdjustmentId.UseCustomBackColor = true;
            this.txtAdjustmentId.UseSelectable = true;
            this.txtAdjustmentId.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtAdjustmentId.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSearchSale
            // 
            this.btnSearchSale.Location = new System.Drawing.Point(1181, 36);
            this.btnSearchSale.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchSale.Name = "btnSearchSale";
            this.btnSearchSale.Size = new System.Drawing.Size(132, 28);
            this.btnSearchSale.TabIndex = 165;
            this.btnSearchSale.Text = "Search Collection";
            this.btnSearchSale.UseSelectable = true;
            this.btnSearchSale.Click += new System.EventHandler(this.btnSearchSale_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(665, 182);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(169, 20);
            this.metroLabel1.TabIndex = 162;
            this.metroLabel1.Text = "Collection Transaction No.";
            // 
            // txtCollectionTransactionNo
            // 
            // 
            // 
            // 
            this.txtCollectionTransactionNo.CustomButton.Image = null;
            this.txtCollectionTransactionNo.CustomButton.Location = new System.Drawing.Point(239, 2);
            this.txtCollectionTransactionNo.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtCollectionTransactionNo.CustomButton.Name = "";
            this.txtCollectionTransactionNo.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtCollectionTransactionNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCollectionTransactionNo.CustomButton.TabIndex = 1;
            this.txtCollectionTransactionNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCollectionTransactionNo.CustomButton.UseSelectable = true;
            this.txtCollectionTransactionNo.CustomButton.Visible = false;
            this.txtCollectionTransactionNo.Lines = new string[0];
            this.txtCollectionTransactionNo.Location = new System.Drawing.Point(905, 182);
            this.txtCollectionTransactionNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCollectionTransactionNo.MaxLength = 32767;
            this.txtCollectionTransactionNo.Name = "txtCollectionTransactionNo";
            this.txtCollectionTransactionNo.PasswordChar = '\0';
            this.txtCollectionTransactionNo.ReadOnly = true;
            this.txtCollectionTransactionNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCollectionTransactionNo.SelectedText = "";
            this.txtCollectionTransactionNo.SelectionLength = 0;
            this.txtCollectionTransactionNo.SelectionStart = 0;
            this.txtCollectionTransactionNo.ShortcutsEnabled = true;
            this.txtCollectionTransactionNo.Size = new System.Drawing.Size(265, 28);
            this.txtCollectionTransactionNo.TabIndex = 161;
            this.txtCollectionTransactionNo.UseCustomBackColor = true;
            this.txtCollectionTransactionNo.UseSelectable = true;
            this.txtCollectionTransactionNo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCollectionTransactionNo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(665, 36);
            this.metroLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(87, 20);
            this.metroLabel7.TabIndex = 160;
            this.metroLabel7.Text = "Collection ID";
            // 
            // txtCollectionId
            // 
            this.txtCollectionId.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtCollectionId.CustomButton.Image = null;
            this.txtCollectionId.CustomButton.Location = new System.Drawing.Point(239, 2);
            this.txtCollectionId.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtCollectionId.CustomButton.Name = "";
            this.txtCollectionId.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtCollectionId.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCollectionId.CustomButton.TabIndex = 1;
            this.txtCollectionId.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCollectionId.CustomButton.UseSelectable = true;
            this.txtCollectionId.CustomButton.Visible = false;
            this.txtCollectionId.Lines = new string[0];
            this.txtCollectionId.Location = new System.Drawing.Point(905, 36);
            this.txtCollectionId.Margin = new System.Windows.Forms.Padding(4);
            this.txtCollectionId.MaxLength = 32767;
            this.txtCollectionId.Name = "txtCollectionId";
            this.txtCollectionId.PasswordChar = '\0';
            this.txtCollectionId.ReadOnly = true;
            this.txtCollectionId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCollectionId.SelectedText = "";
            this.txtCollectionId.SelectionLength = 0;
            this.txtCollectionId.SelectionStart = 0;
            this.txtCollectionId.ShortcutsEnabled = true;
            this.txtCollectionId.Size = new System.Drawing.Size(265, 28);
            this.txtCollectionId.TabIndex = 159;
            this.txtCollectionId.UseCustomBackColor = true;
            this.txtCollectionId.UseSelectable = true;
            this.txtCollectionId.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtCollectionId.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
            this.btnClose.Image = global::GeneralLedger.Properties.Resources.cancel;
            this.btnClose.Location = new System.Drawing.Point(1373, 15);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(137, 44);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnClose.TabIndex = 158;
            this.btnClose.Text = "Close Page";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(665, 84);
            this.metroLabel8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(133, 20);
            this.metroLabel8.TabIndex = 196;
            this.metroLabel8.Text = "Sale Transaction No.";
            // 
            // txtSaleTransactionNo
            // 
            // 
            // 
            // 
            this.txtSaleTransactionNo.CustomButton.Image = null;
            this.txtSaleTransactionNo.CustomButton.Location = new System.Drawing.Point(239, 2);
            this.txtSaleTransactionNo.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtSaleTransactionNo.CustomButton.Name = "";
            this.txtSaleTransactionNo.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtSaleTransactionNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSaleTransactionNo.CustomButton.TabIndex = 1;
            this.txtSaleTransactionNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSaleTransactionNo.CustomButton.UseSelectable = true;
            this.txtSaleTransactionNo.CustomButton.Visible = false;
            this.txtSaleTransactionNo.Lines = new string[0];
            this.txtSaleTransactionNo.Location = new System.Drawing.Point(905, 84);
            this.txtSaleTransactionNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtSaleTransactionNo.MaxLength = 32767;
            this.txtSaleTransactionNo.Name = "txtSaleTransactionNo";
            this.txtSaleTransactionNo.PasswordChar = '\0';
            this.txtSaleTransactionNo.ReadOnly = true;
            this.txtSaleTransactionNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSaleTransactionNo.SelectedText = "";
            this.txtSaleTransactionNo.SelectionLength = 0;
            this.txtSaleTransactionNo.SelectionStart = 0;
            this.txtSaleTransactionNo.ShortcutsEnabled = true;
            this.txtSaleTransactionNo.Size = new System.Drawing.Size(265, 28);
            this.txtSaleTransactionNo.TabIndex = 195;
            this.txtSaleTransactionNo.UseCustomBackColor = true;
            this.txtSaleTransactionNo.UseSelectable = true;
            this.txtSaleTransactionNo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSaleTransactionNo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(665, 134);
            this.metroLabel10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(69, 20);
            this.metroLabel10.TabIndex = 198;
            this.metroLabel10.Text = "Customer";
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
            this.txtCustomerName.Location = new System.Drawing.Point(905, 134);
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
            this.txtCustomerName.TabIndex = 197;
            this.txtCustomerName.UseCustomBackColor = true;
            this.txtCustomerName.UseSelectable = true;
            this.txtCustomerName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCustomerName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(665, 281);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(93, 20);
            this.metroLabel2.TabIndex = 202;
            this.metroLabel2.Text = "Check Details";
            // 
            // txtCheckDetails
            // 
            // 
            // 
            // 
            this.txtCheckDetails.CustomButton.Image = null;
            this.txtCheckDetails.CustomButton.Location = new System.Drawing.Point(241, 2);
            this.txtCheckDetails.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtCheckDetails.CustomButton.Name = "";
            this.txtCheckDetails.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtCheckDetails.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCheckDetails.CustomButton.TabIndex = 1;
            this.txtCheckDetails.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCheckDetails.CustomButton.UseSelectable = true;
            this.txtCheckDetails.CustomButton.Visible = false;
            this.txtCheckDetails.Lines = new string[0];
            this.txtCheckDetails.Location = new System.Drawing.Point(905, 281);
            this.txtCheckDetails.Margin = new System.Windows.Forms.Padding(4);
            this.txtCheckDetails.MaxLength = 32767;
            this.txtCheckDetails.Name = "txtCheckDetails";
            this.txtCheckDetails.PasswordChar = '\0';
            this.txtCheckDetails.ReadOnly = true;
            this.txtCheckDetails.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCheckDetails.SelectedText = "";
            this.txtCheckDetails.SelectionLength = 0;
            this.txtCheckDetails.SelectionStart = 0;
            this.txtCheckDetails.ShortcutsEnabled = true;
            this.txtCheckDetails.Size = new System.Drawing.Size(267, 28);
            this.txtCheckDetails.TabIndex = 201;
            this.txtCheckDetails.UseCustomBackColor = true;
            this.txtCheckDetails.UseSelectable = true;
            this.txtCheckDetails.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCheckDetails.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(665, 231);
            this.metroLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(100, 20);
            this.metroLabel6.TabIndex = 200;
            this.metroLabel6.Text = "Bank Accounts";
            // 
            // cbBank
            // 
            this.cbBank.BackColor = System.Drawing.SystemColors.Control;
            this.cbBank.Enabled = false;
            this.cbBank.FormattingEnabled = true;
            this.cbBank.ItemHeight = 24;
            this.cbBank.Location = new System.Drawing.Point(905, 231);
            this.cbBank.Margin = new System.Windows.Forms.Padding(4);
            this.cbBank.Name = "cbBank";
            this.cbBank.Size = new System.Drawing.Size(265, 30);
            this.cbBank.TabIndex = 199;
            this.cbBank.UseCustomBackColor = true;
            this.cbBank.UseSelectable = true;
            // 
            // chkIsCash
            // 
            this.chkIsCash.AutoSize = true;
            this.chkIsCash.DisplayFocus = true;
            this.chkIsCash.Enabled = false;
            this.chkIsCash.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkIsCash.Location = new System.Drawing.Point(1181, 190);
            this.chkIsCash.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkIsCash.Name = "chkIsCash";
            this.chkIsCash.Size = new System.Drawing.Size(56, 20);
            this.chkIsCash.TabIndex = 141;
            this.chkIsCash.Text = "Cash";
            this.chkIsCash.UseCustomBackColor = true;
            this.chkIsCash.UseSelectable = true;
            // 
            // metroLabel15
            // 
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.Location = new System.Drawing.Point(665, 326);
            this.metroLabel15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Size = new System.Drawing.Size(90, 20);
            this.metroLabel15.TabIndex = 204;
            this.metroLabel15.Text = "Total Amount";
            // 
            // txtCollectionTotal
            // 
            // 
            // 
            // 
            this.txtCollectionTotal.BackgroundStyle.BackColor = System.Drawing.SystemColors.Control;
            this.txtCollectionTotal.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.Control;
            this.txtCollectionTotal.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtCollectionTotal.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtCollectionTotal.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtCollectionTotal.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtCollectionTotal.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtCollectionTotal.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtCollectionTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCollectionTotal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtCollectionTotal.Increment = 1D;
            this.txtCollectionTotal.Location = new System.Drawing.Point(905, 326);
            this.txtCollectionTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCollectionTotal.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtCollectionTotal.Name = "txtCollectionTotal";
            this.txtCollectionTotal.Size = new System.Drawing.Size(267, 28);
            this.txtCollectionTotal.TabIndex = 203;
            // 
            // chkUseDefaultEntry
            // 
            this.chkUseDefaultEntry.AutoSize = true;
            this.chkUseDefaultEntry.Checked = true;
            this.chkUseDefaultEntry.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseDefaultEntry.DisplayFocus = true;
            this.chkUseDefaultEntry.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkUseDefaultEntry.Location = new System.Drawing.Point(808, 604);
            this.chkUseDefaultEntry.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkUseDefaultEntry.Name = "chkUseDefaultEntry";
            this.chkUseDefaultEntry.Size = new System.Drawing.Size(144, 20);
            this.chkUseDefaultEntry.TabIndex = 205;
            this.chkUseDefaultEntry.Text = "Use default entry?";
            this.chkUseDefaultEntry.UseCustomBackColor = true;
            this.chkUseDefaultEntry.UseSelectable = true;
            // 
            // frmAccountReceivableAdjustments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkUseDefaultEntry);
            this.Controls.Add(this.metroLabel15);
            this.Controls.Add(this.txtCollectionTotal);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtCheckDetails);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.cbBank);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.txtSaleTransactionNo);
            this.Controls.Add(this.btnDeleteEntry);
            this.Controls.Add(this.btnAddEntry);
            this.Controls.Add(this.metroLabel12);
            this.Controls.Add(this.txtTotalCredit);
            this.Controls.Add(this.metroLabel13);
            this.Controls.Add(this.txtTotalDebit);
            this.Controls.Add(this.metroLabel11);
            this.Controls.Add(this.dgJournalEntry);
            this.Controls.Add(this.chkIsCash);
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
            this.Controls.Add(this.btnSearchSale);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtCollectionTransactionNo);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.txtCollectionId);
            this.Controls.Add(this.btnClose);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmAccountReceivableAdjustments";
            this.Size = new System.Drawing.Size(1541, 1183);
            this.Load += new System.EventHandler(this.frmAccountReceivableAdjustments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgJournalEntry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCollectionTotal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private MetroFramework.Controls.MetroButton btnSearchSale;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtCollectionTransactionNo;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTextBox txtCollectionId;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox txtSaleTransactionNo;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroTextBox txtCustomerName;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtCheckDetails;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroComboBox cbBank;
        private MetroFramework.Controls.MetroCheckBox chkIsCash;
        private MetroFramework.Controls.MetroLabel metroLabel15;
        private DevComponents.Editors.DoubleInput txtCollectionTotal;
        private MetroFramework.Controls.MetroCheckBox chkUseDefaultEntry;
    }
}
