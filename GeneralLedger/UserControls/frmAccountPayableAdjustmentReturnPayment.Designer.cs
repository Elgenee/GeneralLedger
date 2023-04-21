namespace GeneralLedger.UserControls
{
    partial class frmAccountPayableAdjustmentReturnPayment
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
            this.btnSearchPayment = new MetroFramework.Controls.MetroButton();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.txtPaymentID = new MetroFramework.Controls.MetroTextBox();
            this.chkUseDefaultEntry = new MetroFramework.Controls.MetroCheckBox();
            this.txtPaymentCV = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.chkIsCash = new MetroFramework.Controls.MetroCheckBox();
            this.txtPurchaseTransactionNO = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.txtSupplier = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.cbBank = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.txtCheckDetails = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel15 = new MetroFramework.Controls.MetroLabel();
            this.txtTotal = new DevComponents.Editors.DoubleInput();
            this.txtPaymentSIDR = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel16 = new MetroFramework.Controls.MetroLabel();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dgJournalEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeleteEntry
            // 
            this.btnDeleteEntry.Location = new System.Drawing.Point(1169, 655);
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
            this.btnAddEntry.Location = new System.Drawing.Point(1028, 655);
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
            this.metroLabel12.Location = new System.Drawing.Point(1097, 1065);
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
            this.txtTotalCredit.Location = new System.Drawing.Point(1200, 1065);
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
            this.metroLabel13.Location = new System.Drawing.Point(808, 1065);
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
            this.txtTotalDebit.Location = new System.Drawing.Point(909, 1065);
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
            this.metroLabel11.Location = new System.Drawing.Point(43, 655);
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
            this.dgJournalEntry.Location = new System.Drawing.Point(37, 697);
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
            this.dgJournalEntry.TabIndex = 187;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(493, 1108);
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
            this.metroButton1.Location = new System.Drawing.Point(81, 1108);
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
            this.btnDelete.Location = new System.Drawing.Point(356, 1108);
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
            this.btnSave.Location = new System.Drawing.Point(219, 1108);
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
            this.metroLabel14.Text = "A/P Adjustment Type";
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
            this.txtDescription.Location = new System.Drawing.Point(235, 428);
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
            this.metroLabel9.Location = new System.Drawing.Point(43, 428);
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
            this.metroLabel5.Text = "A/P Adjustment Transaction Date";
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
            this.metroLabel4.Text = "A/P Adjustment Transaction No.";
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
            this.metroLabel3.Text = "A/P Adjustment Id";
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
            // btnSearchPayment
            // 
            this.btnSearchPayment.Location = new System.Drawing.Point(1178, 31);
            this.btnSearchPayment.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchPayment.Name = "btnSearchPayment";
            this.btnSearchPayment.Size = new System.Drawing.Size(132, 28);
            this.btnSearchPayment.TabIndex = 165;
            this.btnSearchPayment.Text = "Search Payment";
            this.btnSearchPayment.UseSelectable = true;
            this.btnSearchPayment.Click += new System.EventHandler(this.btnSearchPayment_Click);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(665, 36);
            this.metroLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(79, 20);
            this.metroLabel7.TabIndex = 160;
            this.metroLabel7.Text = "Payment ID";
            // 
            // txtPaymentID
            // 
            this.txtPaymentID.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtPaymentID.CustomButton.Image = null;
            this.txtPaymentID.CustomButton.Location = new System.Drawing.Point(239, 2);
            this.txtPaymentID.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtPaymentID.CustomButton.Name = "";
            this.txtPaymentID.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtPaymentID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPaymentID.CustomButton.TabIndex = 1;
            this.txtPaymentID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPaymentID.CustomButton.UseSelectable = true;
            this.txtPaymentID.CustomButton.Visible = false;
            this.txtPaymentID.Lines = new string[0];
            this.txtPaymentID.Location = new System.Drawing.Point(905, 36);
            this.txtPaymentID.Margin = new System.Windows.Forms.Padding(4);
            this.txtPaymentID.MaxLength = 32767;
            this.txtPaymentID.Name = "txtPaymentID";
            this.txtPaymentID.PasswordChar = '\0';
            this.txtPaymentID.ReadOnly = true;
            this.txtPaymentID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPaymentID.SelectedText = "";
            this.txtPaymentID.SelectionLength = 0;
            this.txtPaymentID.SelectionStart = 0;
            this.txtPaymentID.ShortcutsEnabled = true;
            this.txtPaymentID.Size = new System.Drawing.Size(265, 28);
            this.txtPaymentID.TabIndex = 159;
            this.txtPaymentID.UseCustomBackColor = true;
            this.txtPaymentID.UseSelectable = true;
            this.txtPaymentID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtPaymentID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // chkUseDefaultEntry
            // 
            this.chkUseDefaultEntry.AutoSize = true;
            this.chkUseDefaultEntry.Checked = true;
            this.chkUseDefaultEntry.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseDefaultEntry.DisplayFocus = true;
            this.chkUseDefaultEntry.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkUseDefaultEntry.Location = new System.Drawing.Point(808, 655);
            this.chkUseDefaultEntry.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkUseDefaultEntry.Name = "chkUseDefaultEntry";
            this.chkUseDefaultEntry.Size = new System.Drawing.Size(144, 20);
            this.chkUseDefaultEntry.TabIndex = 205;
            this.chkUseDefaultEntry.Text = "Use default entry?";
            this.chkUseDefaultEntry.UseCustomBackColor = true;
            this.chkUseDefaultEntry.UseSelectable = true;
            // 
            // txtPaymentCV
            // 
            // 
            // 
            // 
            this.txtPaymentCV.CustomButton.Image = null;
            this.txtPaymentCV.CustomButton.Location = new System.Drawing.Point(239, 2);
            this.txtPaymentCV.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtPaymentCV.CustomButton.Name = "";
            this.txtPaymentCV.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtPaymentCV.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPaymentCV.CustomButton.TabIndex = 1;
            this.txtPaymentCV.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPaymentCV.CustomButton.UseSelectable = true;
            this.txtPaymentCV.CustomButton.Visible = false;
            this.txtPaymentCV.Lines = new string[0];
            this.txtPaymentCV.Location = new System.Drawing.Point(907, 172);
            this.txtPaymentCV.Margin = new System.Windows.Forms.Padding(4);
            this.txtPaymentCV.MaxLength = 32767;
            this.txtPaymentCV.Name = "txtPaymentCV";
            this.txtPaymentCV.PasswordChar = '\0';
            this.txtPaymentCV.ReadOnly = true;
            this.txtPaymentCV.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPaymentCV.SelectedText = "";
            this.txtPaymentCV.SelectionLength = 0;
            this.txtPaymentCV.SelectionStart = 0;
            this.txtPaymentCV.ShortcutsEnabled = true;
            this.txtPaymentCV.Size = new System.Drawing.Size(265, 28);
            this.txtPaymentCV.TabIndex = 161;
            this.txtPaymentCV.UseCustomBackColor = true;
            this.txtPaymentCV.UseSelectable = true;
            this.txtPaymentCV.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPaymentCV.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(667, 172);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(93, 20);
            this.metroLabel1.TabIndex = 162;
            this.metroLabel1.Text = "Payment CV#";
            // 
            // chkIsCash
            // 
            this.chkIsCash.AutoSize = true;
            this.chkIsCash.DisplayFocus = true;
            this.chkIsCash.Enabled = false;
            this.chkIsCash.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkIsCash.Location = new System.Drawing.Point(1183, 180);
            this.chkIsCash.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkIsCash.Name = "chkIsCash";
            this.chkIsCash.Size = new System.Drawing.Size(56, 20);
            this.chkIsCash.TabIndex = 141;
            this.chkIsCash.Text = "Cash";
            this.chkIsCash.UseCustomBackColor = true;
            this.chkIsCash.UseSelectable = true;
            // 
            // txtPurchaseTransactionNO
            // 
            // 
            // 
            // 
            this.txtPurchaseTransactionNO.CustomButton.Image = null;
            this.txtPurchaseTransactionNO.CustomButton.Location = new System.Drawing.Point(239, 2);
            this.txtPurchaseTransactionNO.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtPurchaseTransactionNO.CustomButton.Name = "";
            this.txtPurchaseTransactionNO.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtPurchaseTransactionNO.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPurchaseTransactionNO.CustomButton.TabIndex = 1;
            this.txtPurchaseTransactionNO.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPurchaseTransactionNO.CustomButton.UseSelectable = true;
            this.txtPurchaseTransactionNO.CustomButton.Visible = false;
            this.txtPurchaseTransactionNO.Lines = new string[0];
            this.txtPurchaseTransactionNO.Location = new System.Drawing.Point(907, 84);
            this.txtPurchaseTransactionNO.Margin = new System.Windows.Forms.Padding(4);
            this.txtPurchaseTransactionNO.MaxLength = 32767;
            this.txtPurchaseTransactionNO.Name = "txtPurchaseTransactionNO";
            this.txtPurchaseTransactionNO.PasswordChar = '\0';
            this.txtPurchaseTransactionNO.ReadOnly = true;
            this.txtPurchaseTransactionNO.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPurchaseTransactionNO.SelectedText = "";
            this.txtPurchaseTransactionNO.SelectionLength = 0;
            this.txtPurchaseTransactionNO.SelectionStart = 0;
            this.txtPurchaseTransactionNO.ShortcutsEnabled = true;
            this.txtPurchaseTransactionNO.Size = new System.Drawing.Size(265, 28);
            this.txtPurchaseTransactionNO.TabIndex = 195;
            this.txtPurchaseTransactionNO.UseCustomBackColor = true;
            this.txtPurchaseTransactionNO.UseSelectable = true;
            this.txtPurchaseTransactionNO.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPurchaseTransactionNO.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(667, 84);
            this.metroLabel8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(165, 20);
            this.metroLabel8.TabIndex = 196;
            this.metroLabel8.Text = "Purchase Transaction No.";
            // 
            // txtSupplier
            // 
            // 
            // 
            // 
            this.txtSupplier.CustomButton.Image = null;
            this.txtSupplier.CustomButton.Location = new System.Drawing.Point(239, 2);
            this.txtSupplier.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtSupplier.CustomButton.Name = "";
            this.txtSupplier.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtSupplier.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSupplier.CustomButton.TabIndex = 1;
            this.txtSupplier.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSupplier.CustomButton.UseSelectable = true;
            this.txtSupplier.CustomButton.Visible = false;
            this.txtSupplier.Lines = new string[0];
            this.txtSupplier.Location = new System.Drawing.Point(907, 127);
            this.txtSupplier.Margin = new System.Windows.Forms.Padding(4);
            this.txtSupplier.MaxLength = 32767;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.PasswordChar = '\0';
            this.txtSupplier.ReadOnly = true;
            this.txtSupplier.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSupplier.SelectedText = "";
            this.txtSupplier.SelectionLength = 0;
            this.txtSupplier.SelectionStart = 0;
            this.txtSupplier.ShortcutsEnabled = true;
            this.txtSupplier.Size = new System.Drawing.Size(265, 28);
            this.txtSupplier.TabIndex = 197;
            this.txtSupplier.UseCustomBackColor = true;
            this.txtSupplier.UseSelectable = true;
            this.txtSupplier.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSupplier.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(667, 127);
            this.metroLabel10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(59, 20);
            this.metroLabel10.TabIndex = 198;
            this.metroLabel10.Text = "Supplier";
            // 
            // cbBank
            // 
            this.cbBank.BackColor = System.Drawing.SystemColors.Control;
            this.cbBank.Enabled = false;
            this.cbBank.FormattingEnabled = true;
            this.cbBank.ItemHeight = 24;
            this.cbBank.Location = new System.Drawing.Point(907, 265);
            this.cbBank.Margin = new System.Windows.Forms.Padding(4);
            this.cbBank.Name = "cbBank";
            this.cbBank.Size = new System.Drawing.Size(265, 30);
            this.cbBank.TabIndex = 199;
            this.cbBank.UseCustomBackColor = true;
            this.cbBank.UseSelectable = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(667, 265);
            this.metroLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(100, 20);
            this.metroLabel6.TabIndex = 200;
            this.metroLabel6.Text = "Bank Accounts";
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
            this.txtCheckDetails.Location = new System.Drawing.Point(907, 315);
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
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(667, 315);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(93, 20);
            this.metroLabel2.TabIndex = 202;
            this.metroLabel2.Text = "Check Details";
            // 
            // metroLabel15
            // 
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.Location = new System.Drawing.Point(664, 363);
            this.metroLabel15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Size = new System.Drawing.Size(90, 20);
            this.metroLabel15.TabIndex = 258;
            this.metroLabel15.Text = "Total Amount";
            // 
            // txtTotal
            // 
            // 
            // 
            // 
            this.txtTotal.BackgroundStyle.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotal.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.Control;
            this.txtTotal.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTotal.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtTotal.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTotal.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTotal.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTotal.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotal.Enabled = false;
            this.txtTotal.Increment = 1D;
            this.txtTotal.Location = new System.Drawing.Point(907, 363);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTotal.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(265, 28);
            this.txtTotal.TabIndex = 259;
            // 
            // txtPaymentSIDR
            // 
            // 
            // 
            // 
            this.txtPaymentSIDR.CustomButton.Image = null;
            this.txtPaymentSIDR.CustomButton.Location = new System.Drawing.Point(239, 2);
            this.txtPaymentSIDR.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtPaymentSIDR.CustomButton.Name = "";
            this.txtPaymentSIDR.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtPaymentSIDR.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPaymentSIDR.CustomButton.TabIndex = 1;
            this.txtPaymentSIDR.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPaymentSIDR.CustomButton.UseSelectable = true;
            this.txtPaymentSIDR.CustomButton.Visible = false;
            this.txtPaymentSIDR.Lines = new string[0];
            this.txtPaymentSIDR.Location = new System.Drawing.Point(907, 217);
            this.txtPaymentSIDR.Margin = new System.Windows.Forms.Padding(4);
            this.txtPaymentSIDR.MaxLength = 32767;
            this.txtPaymentSIDR.Name = "txtPaymentSIDR";
            this.txtPaymentSIDR.PasswordChar = '\0';
            this.txtPaymentSIDR.ReadOnly = true;
            this.txtPaymentSIDR.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPaymentSIDR.SelectedText = "";
            this.txtPaymentSIDR.SelectionLength = 0;
            this.txtPaymentSIDR.SelectionStart = 0;
            this.txtPaymentSIDR.ShortcutsEnabled = true;
            this.txtPaymentSIDR.Size = new System.Drawing.Size(265, 28);
            this.txtPaymentSIDR.TabIndex = 260;
            this.txtPaymentSIDR.UseCustomBackColor = true;
            this.txtPaymentSIDR.UseSelectable = true;
            this.txtPaymentSIDR.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPaymentSIDR.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel16
            // 
            this.metroLabel16.AutoSize = true;
            this.metroLabel16.Location = new System.Drawing.Point(667, 217);
            this.metroLabel16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Size = new System.Drawing.Size(99, 20);
            this.metroLabel16.TabIndex = 261;
            this.metroLabel16.Text = "Payment SI/DR";
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
            // frmAccountPayableAdjustmentReturnPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroLabel16);
            this.Controls.Add(this.txtPaymentSIDR);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.metroLabel15);
            this.Controls.Add(this.chkUseDefaultEntry);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtCheckDetails);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.cbBank);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.txtSupplier);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.txtPurchaseTransactionNO);
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
            this.Controls.Add(this.btnSearchPayment);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtPaymentCV);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.txtPaymentID);
            this.Controls.Add(this.btnClose);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmAccountPayableAdjustmentReturnPayment";
            this.Size = new System.Drawing.Size(1541, 1305);
            this.Load += new System.EventHandler(this.frmAccountReceivableAdjustments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgJournalEntry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).EndInit();
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
        private MetroFramework.Controls.MetroButton btnSearchPayment;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTextBox txtPaymentID;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private MetroFramework.Controls.MetroCheckBox chkUseDefaultEntry;
        private MetroFramework.Controls.MetroTextBox txtPaymentCV;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroCheckBox chkIsCash;
        private MetroFramework.Controls.MetroTextBox txtPurchaseTransactionNO;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox txtSupplier;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroComboBox cbBank;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox txtCheckDetails;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel15;
        private DevComponents.Editors.DoubleInput txtTotal;
        private MetroFramework.Controls.MetroTextBox txtPaymentSIDR;
        private MetroFramework.Controls.MetroLabel metroLabel16;
    }
}
