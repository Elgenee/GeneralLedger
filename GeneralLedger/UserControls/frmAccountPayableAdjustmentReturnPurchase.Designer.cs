namespace GeneralLedger.UserControls
{
    partial class frmAccountPayableAdjustmentReturnPurchase
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.txtPurchaseId = new MetroFramework.Controls.MetroTextBox();
            this.chkUseDefaultEntry = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel16 = new MetroFramework.Controls.MetroLabel();
            this.txtPurchaseTotal = new DevComponents.Editors.DoubleInput();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtPurchasePONo = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.txtPurchaseSIDR = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtSupplier = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.txtInventoryPurchaseTotal = new MetroFramework.Controls.MetroTextBox();
            this.btnDeleteProduct = new MetroFramework.Controls.MetroButton();
            this.btnAddProduct = new MetroFramework.Controls.MetroButton();
            this.metroLabel17 = new MetroFramework.Controls.MetroLabel();
            this.dgProduct = new MetroFramework.Controls.MetroGrid();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.txtTotalInventoryCredit = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel15 = new MetroFramework.Controls.MetroLabel();
            this.txtTotalInventoryDebit = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel18 = new MetroFramework.Controls.MetroLabel();
            this.dgInventoryEntry = new MetroFramework.Controls.MetroGrid();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dgJournalEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchaseTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgInventoryEntry)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeleteEntry
            // 
            this.btnDeleteEntry.Location = new System.Drawing.Point(1169, 529);
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
            this.btnAddEntry.Location = new System.Drawing.Point(1028, 529);
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
            this.metroLabel12.Location = new System.Drawing.Point(1097, 939);
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
            this.txtTotalCredit.Location = new System.Drawing.Point(1209, 939);
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
            this.metroLabel13.Location = new System.Drawing.Point(808, 939);
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
            this.txtTotalDebit.Location = new System.Drawing.Point(909, 939);
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
            this.metroLabel11.Location = new System.Drawing.Point(43, 529);
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
            this.dgJournalEntry.Location = new System.Drawing.Point(37, 571);
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
            this.btnFind.Location = new System.Drawing.Point(467, 1959);
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
            this.metroButton1.Location = new System.Drawing.Point(53, 1959);
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
            this.btnDelete.Location = new System.Drawing.Point(328, 1959);
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
            this.btnSave.Location = new System.Drawing.Point(192, 1959);
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
            this.txtDescription.Location = new System.Drawing.Point(235, 302);
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
            this.metroLabel9.Location = new System.Drawing.Point(43, 302);
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
            this.btnSearchPayment.Location = new System.Drawing.Point(1179, 36);
            this.btnSearchPayment.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchPayment.Name = "btnSearchPayment";
            this.btnSearchPayment.Size = new System.Drawing.Size(132, 28);
            this.btnSearchPayment.TabIndex = 165;
            this.btnSearchPayment.Text = "Search Purchase";
            this.btnSearchPayment.UseSelectable = true;
            this.btnSearchPayment.Click += new System.EventHandler(this.btnSearchPayment_Click);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(659, 36);
            this.metroLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(83, 20);
            this.metroLabel7.TabIndex = 160;
            this.metroLabel7.Text = "Purchase ID";
            // 
            // txtPurchaseId
            // 
            this.txtPurchaseId.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtPurchaseId.CustomButton.Image = null;
            this.txtPurchaseId.CustomButton.Location = new System.Drawing.Point(239, 2);
            this.txtPurchaseId.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtPurchaseId.CustomButton.Name = "";
            this.txtPurchaseId.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtPurchaseId.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPurchaseId.CustomButton.TabIndex = 1;
            this.txtPurchaseId.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPurchaseId.CustomButton.UseSelectable = true;
            this.txtPurchaseId.CustomButton.Visible = false;
            this.txtPurchaseId.Lines = new string[0];
            this.txtPurchaseId.Location = new System.Drawing.Point(901, 36);
            this.txtPurchaseId.Margin = new System.Windows.Forms.Padding(4);
            this.txtPurchaseId.MaxLength = 32767;
            this.txtPurchaseId.Name = "txtPurchaseId";
            this.txtPurchaseId.PasswordChar = '\0';
            this.txtPurchaseId.ReadOnly = true;
            this.txtPurchaseId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPurchaseId.SelectedText = "";
            this.txtPurchaseId.SelectionLength = 0;
            this.txtPurchaseId.SelectionStart = 0;
            this.txtPurchaseId.ShortcutsEnabled = true;
            this.txtPurchaseId.Size = new System.Drawing.Size(265, 28);
            this.txtPurchaseId.TabIndex = 159;
            this.txtPurchaseId.UseCustomBackColor = true;
            this.txtPurchaseId.UseSelectable = true;
            this.txtPurchaseId.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtPurchaseId.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // chkUseDefaultEntry
            // 
            this.chkUseDefaultEntry.AutoSize = true;
            this.chkUseDefaultEntry.Checked = true;
            this.chkUseDefaultEntry.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseDefaultEntry.DisplayFocus = true;
            this.chkUseDefaultEntry.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkUseDefaultEntry.Location = new System.Drawing.Point(808, 529);
            this.chkUseDefaultEntry.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkUseDefaultEntry.Name = "chkUseDefaultEntry";
            this.chkUseDefaultEntry.Size = new System.Drawing.Size(144, 20);
            this.chkUseDefaultEntry.TabIndex = 205;
            this.chkUseDefaultEntry.Text = "Use default entry?";
            this.chkUseDefaultEntry.UseCustomBackColor = true;
            this.chkUseDefaultEntry.UseSelectable = true;
            // 
            // metroLabel16
            // 
            this.metroLabel16.AutoSize = true;
            this.metroLabel16.Location = new System.Drawing.Point(659, 234);
            this.metroLabel16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Size = new System.Drawing.Size(151, 20);
            this.metroLabel16.TabIndex = 214;
            this.metroLabel16.Text = "Purchase Total Amount";
            // 
            // txtPurchaseTotal
            // 
            // 
            // 
            // 
            this.txtPurchaseTotal.BackgroundStyle.BackColor = System.Drawing.SystemColors.Control;
            this.txtPurchaseTotal.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.Control;
            this.txtPurchaseTotal.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtPurchaseTotal.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtPurchaseTotal.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtPurchaseTotal.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtPurchaseTotal.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtPurchaseTotal.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtPurchaseTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPurchaseTotal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtPurchaseTotal.Increment = 1D;
            this.txtPurchaseTotal.Location = new System.Drawing.Point(901, 234);
            this.txtPurchaseTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPurchaseTotal.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtPurchaseTotal.Name = "txtPurchaseTotal";
            this.txtPurchaseTotal.Size = new System.Drawing.Size(267, 28);
            this.txtPurchaseTotal.TabIndex = 213;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(659, 130);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(54, 20);
            this.metroLabel2.TabIndex = 212;
            this.metroLabel2.Text = "PO No.";
            // 
            // txtPurchasePONo
            // 
            this.txtPurchasePONo.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtPurchasePONo.CustomButton.Image = null;
            this.txtPurchasePONo.CustomButton.Location = new System.Drawing.Point(241, 2);
            this.txtPurchasePONo.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtPurchasePONo.CustomButton.Name = "";
            this.txtPurchasePONo.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtPurchasePONo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPurchasePONo.CustomButton.TabIndex = 1;
            this.txtPurchasePONo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPurchasePONo.CustomButton.UseSelectable = true;
            this.txtPurchasePONo.CustomButton.Visible = false;
            this.txtPurchasePONo.Lines = new string[0];
            this.txtPurchasePONo.Location = new System.Drawing.Point(901, 130);
            this.txtPurchasePONo.Margin = new System.Windows.Forms.Padding(4);
            this.txtPurchasePONo.MaxLength = 32767;
            this.txtPurchasePONo.Name = "txtPurchasePONo";
            this.txtPurchasePONo.PasswordChar = '\0';
            this.txtPurchasePONo.ReadOnly = true;
            this.txtPurchasePONo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPurchasePONo.SelectedText = "";
            this.txtPurchasePONo.SelectionLength = 0;
            this.txtPurchasePONo.SelectionStart = 0;
            this.txtPurchasePONo.ShortcutsEnabled = true;
            this.txtPurchasePONo.Size = new System.Drawing.Size(267, 28);
            this.txtPurchasePONo.TabIndex = 211;
            this.txtPurchasePONo.UseCustomBackColor = true;
            this.txtPurchasePONo.UseSelectable = true;
            this.txtPurchasePONo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPurchasePONo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(659, 180);
            this.metroLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(103, 20);
            this.metroLabel6.TabIndex = 210;
            this.metroLabel6.Text = "Purchase SI/DR";
            // 
            // txtPurchaseSIDR
            // 
            // 
            // 
            // 
            this.txtPurchaseSIDR.CustomButton.Image = null;
            this.txtPurchaseSIDR.CustomButton.Location = new System.Drawing.Point(241, 2);
            this.txtPurchaseSIDR.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtPurchaseSIDR.CustomButton.Name = "";
            this.txtPurchaseSIDR.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtPurchaseSIDR.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPurchaseSIDR.CustomButton.TabIndex = 1;
            this.txtPurchaseSIDR.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPurchaseSIDR.CustomButton.UseSelectable = true;
            this.txtPurchaseSIDR.CustomButton.Visible = false;
            this.txtPurchaseSIDR.Lines = new string[0];
            this.txtPurchaseSIDR.Location = new System.Drawing.Point(901, 180);
            this.txtPurchaseSIDR.Margin = new System.Windows.Forms.Padding(4);
            this.txtPurchaseSIDR.MaxLength = 32767;
            this.txtPurchaseSIDR.Name = "txtPurchaseSIDR";
            this.txtPurchaseSIDR.PasswordChar = '\0';
            this.txtPurchaseSIDR.ReadOnly = true;
            this.txtPurchaseSIDR.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPurchaseSIDR.SelectedText = "";
            this.txtPurchaseSIDR.SelectionLength = 0;
            this.txtPurchaseSIDR.SelectionStart = 0;
            this.txtPurchaseSIDR.ShortcutsEnabled = true;
            this.txtPurchaseSIDR.Size = new System.Drawing.Size(267, 28);
            this.txtPurchaseSIDR.TabIndex = 209;
            this.txtPurchaseSIDR.UseCustomBackColor = true;
            this.txtPurchaseSIDR.UseSelectable = true;
            this.txtPurchaseSIDR.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPurchaseSIDR.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(659, 84);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(59, 20);
            this.metroLabel1.TabIndex = 208;
            this.metroLabel1.Text = "Supplier";
            // 
            // txtSupplier
            // 
            this.txtSupplier.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtSupplier.CustomButton.Image = null;
            this.txtSupplier.CustomButton.Location = new System.Drawing.Point(241, 2);
            this.txtSupplier.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtSupplier.CustomButton.Name = "";
            this.txtSupplier.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtSupplier.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSupplier.CustomButton.TabIndex = 1;
            this.txtSupplier.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSupplier.CustomButton.UseSelectable = true;
            this.txtSupplier.CustomButton.Visible = false;
            this.txtSupplier.Lines = new string[0];
            this.txtSupplier.Location = new System.Drawing.Point(901, 84);
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
            this.txtSupplier.Size = new System.Drawing.Size(267, 28);
            this.txtSupplier.TabIndex = 207;
            this.txtSupplier.UseCustomBackColor = true;
            this.txtSupplier.UseSelectable = true;
            this.txtSupplier.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSupplier.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(1075, 1426);
            this.metroLabel10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(98, 20);
            this.metroLabel10.TabIndex = 220;
            this.metroLabel10.Text = "Purchase Total";
            // 
            // txtInventoryPurchaseTotal
            // 
            // 
            // 
            // 
            this.txtInventoryPurchaseTotal.CustomButton.Image = null;
            this.txtInventoryPurchaseTotal.CustomButton.Location = new System.Drawing.Point(129, 2);
            this.txtInventoryPurchaseTotal.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtInventoryPurchaseTotal.CustomButton.Name = "";
            this.txtInventoryPurchaseTotal.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtInventoryPurchaseTotal.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtInventoryPurchaseTotal.CustomButton.TabIndex = 1;
            this.txtInventoryPurchaseTotal.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtInventoryPurchaseTotal.CustomButton.UseSelectable = true;
            this.txtInventoryPurchaseTotal.CustomButton.Visible = false;
            this.txtInventoryPurchaseTotal.Lines = new string[0];
            this.txtInventoryPurchaseTotal.Location = new System.Drawing.Point(1203, 1426);
            this.txtInventoryPurchaseTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtInventoryPurchaseTotal.MaxLength = 32767;
            this.txtInventoryPurchaseTotal.Name = "txtInventoryPurchaseTotal";
            this.txtInventoryPurchaseTotal.PasswordChar = '\0';
            this.txtInventoryPurchaseTotal.ReadOnly = true;
            this.txtInventoryPurchaseTotal.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtInventoryPurchaseTotal.SelectedText = "";
            this.txtInventoryPurchaseTotal.SelectionLength = 0;
            this.txtInventoryPurchaseTotal.SelectionStart = 0;
            this.txtInventoryPurchaseTotal.ShortcutsEnabled = true;
            this.txtInventoryPurchaseTotal.Size = new System.Drawing.Size(155, 28);
            this.txtInventoryPurchaseTotal.TabIndex = 219;
            this.txtInventoryPurchaseTotal.UseSelectable = true;
            this.txtInventoryPurchaseTotal.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtInventoryPurchaseTotal.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.Location = new System.Drawing.Point(1167, 1013);
            this.btnDeleteProduct.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(132, 28);
            this.btnDeleteProduct.TabIndex = 218;
            this.btnDeleteProduct.Text = "Delete Product";
            this.btnDeleteProduct.UseSelectable = true;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(1027, 1013);
            this.btnAddProduct.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(132, 28);
            this.btnAddProduct.TabIndex = 217;
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.UseSelectable = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // metroLabel17
            // 
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.Location = new System.Drawing.Point(55, 1022);
            this.metroLabel17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel17.Name = "metroLabel17";
            this.metroLabel17.Size = new System.Drawing.Size(68, 20);
            this.metroLabel17.TabIndex = 216;
            this.metroLabel17.Text = "Inventory";
            // 
            // dgProduct
            // 
            this.dgProduct.AllowUserToResizeRows = false;
            this.dgProduct.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgProduct.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgProduct.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgProduct.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgProduct.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgProduct.EnableHeadersVisualStyles = false;
            this.dgProduct.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgProduct.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgProduct.Location = new System.Drawing.Point(37, 1055);
            this.dgProduct.Margin = new System.Windows.Forms.Padding(4);
            this.dgProduct.Name = "dgProduct";
            this.dgProduct.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProduct.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgProduct.RowHeadersWidth = 51;
            this.dgProduct.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProduct.Size = new System.Drawing.Size(1327, 341);
            this.dgProduct.TabIndex = 215;
            this.dgProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProduct_CellClick);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(1097, 1874);
            this.metroLabel8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(78, 20);
            this.metroLabel8.TabIndex = 226;
            this.metroLabel8.Text = "Total Credit";
            // 
            // txtTotalInventoryCredit
            // 
            // 
            // 
            // 
            this.txtTotalInventoryCredit.CustomButton.Image = null;
            this.txtTotalInventoryCredit.CustomButton.Location = new System.Drawing.Point(129, 2);
            this.txtTotalInventoryCredit.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalInventoryCredit.CustomButton.Name = "";
            this.txtTotalInventoryCredit.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtTotalInventoryCredit.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTotalInventoryCredit.CustomButton.TabIndex = 1;
            this.txtTotalInventoryCredit.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTotalInventoryCredit.CustomButton.UseSelectable = true;
            this.txtTotalInventoryCredit.CustomButton.Visible = false;
            this.txtTotalInventoryCredit.Lines = new string[0];
            this.txtTotalInventoryCredit.Location = new System.Drawing.Point(1203, 1874);
            this.txtTotalInventoryCredit.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalInventoryCredit.MaxLength = 32767;
            this.txtTotalInventoryCredit.Name = "txtTotalInventoryCredit";
            this.txtTotalInventoryCredit.PasswordChar = '\0';
            this.txtTotalInventoryCredit.ReadOnly = true;
            this.txtTotalInventoryCredit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTotalInventoryCredit.SelectedText = "";
            this.txtTotalInventoryCredit.SelectionLength = 0;
            this.txtTotalInventoryCredit.SelectionStart = 0;
            this.txtTotalInventoryCredit.ShortcutsEnabled = true;
            this.txtTotalInventoryCredit.Size = new System.Drawing.Size(155, 28);
            this.txtTotalInventoryCredit.TabIndex = 225;
            this.txtTotalInventoryCredit.UseSelectable = true;
            this.txtTotalInventoryCredit.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTotalInventoryCredit.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel15
            // 
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.Location = new System.Drawing.Point(805, 1874);
            this.metroLabel15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Size = new System.Drawing.Size(74, 20);
            this.metroLabel15.TabIndex = 224;
            this.metroLabel15.Text = "Total Debit";
            // 
            // txtTotalInventoryDebit
            // 
            // 
            // 
            // 
            this.txtTotalInventoryDebit.CustomButton.Image = null;
            this.txtTotalInventoryDebit.CustomButton.Location = new System.Drawing.Point(129, 2);
            this.txtTotalInventoryDebit.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalInventoryDebit.CustomButton.Name = "";
            this.txtTotalInventoryDebit.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtTotalInventoryDebit.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTotalInventoryDebit.CustomButton.TabIndex = 1;
            this.txtTotalInventoryDebit.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTotalInventoryDebit.CustomButton.UseSelectable = true;
            this.txtTotalInventoryDebit.CustomButton.Visible = false;
            this.txtTotalInventoryDebit.Lines = new string[0];
            this.txtTotalInventoryDebit.Location = new System.Drawing.Point(909, 1874);
            this.txtTotalInventoryDebit.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalInventoryDebit.MaxLength = 32767;
            this.txtTotalInventoryDebit.Name = "txtTotalInventoryDebit";
            this.txtTotalInventoryDebit.PasswordChar = '\0';
            this.txtTotalInventoryDebit.ReadOnly = true;
            this.txtTotalInventoryDebit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTotalInventoryDebit.SelectedText = "";
            this.txtTotalInventoryDebit.SelectionLength = 0;
            this.txtTotalInventoryDebit.SelectionStart = 0;
            this.txtTotalInventoryDebit.ShortcutsEnabled = true;
            this.txtTotalInventoryDebit.Size = new System.Drawing.Size(155, 28);
            this.txtTotalInventoryDebit.TabIndex = 223;
            this.txtTotalInventoryDebit.UseSelectable = true;
            this.txtTotalInventoryDebit.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTotalInventoryDebit.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel18
            // 
            this.metroLabel18.AutoSize = true;
            this.metroLabel18.Location = new System.Drawing.Point(55, 1465);
            this.metroLabel18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel18.Name = "metroLabel18";
            this.metroLabel18.Size = new System.Drawing.Size(105, 20);
            this.metroLabel18.TabIndex = 222;
            this.metroLabel18.Text = "Inventory Entry";
            // 
            // dgInventoryEntry
            // 
            this.dgInventoryEntry.AllowUserToResizeRows = false;
            this.dgInventoryEntry.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgInventoryEntry.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgInventoryEntry.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgInventoryEntry.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgInventoryEntry.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgInventoryEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgInventoryEntry.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgInventoryEntry.EnableHeadersVisualStyles = false;
            this.dgInventoryEntry.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgInventoryEntry.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgInventoryEntry.Location = new System.Drawing.Point(37, 1504);
            this.dgInventoryEntry.Margin = new System.Windows.Forms.Padding(4);
            this.dgInventoryEntry.Name = "dgInventoryEntry";
            this.dgInventoryEntry.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgInventoryEntry.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgInventoryEntry.RowHeadersWidth = 51;
            this.dgInventoryEntry.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgInventoryEntry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgInventoryEntry.Size = new System.Drawing.Size(1327, 341);
            this.dgInventoryEntry.TabIndex = 221;
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
            // frmAccountPayableAdjustmentReturnPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.txtTotalInventoryCredit);
            this.Controls.Add(this.metroLabel15);
            this.Controls.Add(this.txtTotalInventoryDebit);
            this.Controls.Add(this.metroLabel18);
            this.Controls.Add(this.dgInventoryEntry);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.txtInventoryPurchaseTotal);
            this.Controls.Add(this.btnDeleteProduct);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.metroLabel17);
            this.Controls.Add(this.dgProduct);
            this.Controls.Add(this.metroLabel16);
            this.Controls.Add(this.txtPurchaseTotal);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtPurchasePONo);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.txtPurchaseSIDR);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtSupplier);
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
            this.Controls.Add(this.btnSearchPayment);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.txtPurchaseId);
            this.Controls.Add(this.btnClose);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmAccountPayableAdjustmentReturnPurchase";
            this.Size = new System.Drawing.Size(1760, 2197);
            this.Load += new System.EventHandler(this.frmAccountReceivableAdjustments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgJournalEntry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchaseTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgInventoryEntry)).EndInit();
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
        private MetroFramework.Controls.MetroTextBox txtPurchaseId;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private MetroFramework.Controls.MetroCheckBox chkUseDefaultEntry;
        private MetroFramework.Controls.MetroLabel metroLabel16;
        private DevComponents.Editors.DoubleInput txtPurchaseTotal;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtPurchasePONo;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox txtPurchaseSIDR;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtSupplier;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroTextBox txtInventoryPurchaseTotal;
        private MetroFramework.Controls.MetroButton btnDeleteProduct;
        private MetroFramework.Controls.MetroButton btnAddProduct;
        private MetroFramework.Controls.MetroLabel metroLabel17;
        private MetroFramework.Controls.MetroGrid dgProduct;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox txtTotalInventoryCredit;
        private MetroFramework.Controls.MetroLabel metroLabel15;
        private MetroFramework.Controls.MetroTextBox txtTotalInventoryDebit;
        private MetroFramework.Controls.MetroLabel metroLabel18;
        private MetroFramework.Controls.MetroGrid dgInventoryEntry;
    }
}
