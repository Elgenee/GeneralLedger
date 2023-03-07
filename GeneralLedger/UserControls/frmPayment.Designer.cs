namespace GeneralLedger.UserControls
{
    partial class frmPayment
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
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.txtCheckDetails = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel14 = new MetroFramework.Controls.MetroLabel();
            this.cbBank = new MetroFramework.Controls.MetroComboBox();
            this.chkIsCash = new MetroFramework.Controls.MetroCheckBox();
            this.txtDescription = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.dtPaymentTransactionDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtPaymentCV = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtPaymentId = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtPurchasePONo = new MetroFramework.Controls.MetroTextBox();
            this.btnSearchPurchase = new MetroFramework.Controls.MetroButton();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.txtPurchaseSIDR = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtSupplier = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.txtPurchaseId = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel15 = new MetroFramework.Controls.MetroLabel();
            this.txtPaymentSIDR = new MetroFramework.Controls.MetroTextBox();
            this.txtPaymentTotal = new DevComponents.Editors.DoubleInput();
            this.metroLabel16 = new MetroFramework.Controls.MetroLabel();
            this.txtPurchaseTotal = new DevComponents.Editors.DoubleInput();
            ((System.ComponentModel.ISupportInitialize)(this.dgJournalEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaymentTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchaseTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // chkUseDefaultEntry
            // 
            this.chkUseDefaultEntry.AutoSize = true;
            this.chkUseDefaultEntry.Checked = true;
            this.chkUseDefaultEntry.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseDefaultEntry.DisplayFocus = true;
            this.chkUseDefaultEntry.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkUseDefaultEntry.Location = new System.Drawing.Point(835, 626);
            this.chkUseDefaultEntry.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkUseDefaultEntry.Name = "chkUseDefaultEntry";
            this.chkUseDefaultEntry.Size = new System.Drawing.Size(144, 20);
            this.chkUseDefaultEntry.TabIndex = 196;
            this.chkUseDefaultEntry.Text = "Use default entry?";
            this.chkUseDefaultEntry.UseCustomBackColor = true;
            this.chkUseDefaultEntry.UseSelectable = true;
            // 
            // btnDeleteEntry
            // 
            this.btnDeleteEntry.Location = new System.Drawing.Point(1171, 626);
            this.btnDeleteEntry.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteEntry.Name = "btnDeleteEntry";
            this.btnDeleteEntry.Size = new System.Drawing.Size(132, 28);
            this.btnDeleteEntry.TabIndex = 195;
            this.btnDeleteEntry.Text = "Delete Entry";
            this.btnDeleteEntry.UseSelectable = true;
            this.btnDeleteEntry.Click += new System.EventHandler(this.btnDeleteEntry_Click);
            // 
            // btnAddEntry
            // 
            this.btnAddEntry.Location = new System.Drawing.Point(1029, 626);
            this.btnAddEntry.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddEntry.Name = "btnAddEntry";
            this.btnAddEntry.Size = new System.Drawing.Size(132, 28);
            this.btnAddEntry.TabIndex = 194;
            this.btnAddEntry.Text = "Add Entry";
            this.btnAddEntry.UseSelectable = true;
            this.btnAddEntry.Click += new System.EventHandler(this.btnAddEntry_Click);
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.Location = new System.Drawing.Point(1099, 1036);
            this.metroLabel12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(78, 20);
            this.metroLabel12.TabIndex = 193;
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
            this.txtTotalCredit.Location = new System.Drawing.Point(1203, 1036);
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
            this.txtTotalCredit.TabIndex = 192;
            this.txtTotalCredit.UseSelectable = true;
            this.txtTotalCredit.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTotalCredit.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.Location = new System.Drawing.Point(811, 1036);
            this.metroLabel13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(74, 20);
            this.metroLabel13.TabIndex = 191;
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
            this.txtTotalDebit.Location = new System.Drawing.Point(912, 1036);
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
            this.txtTotalDebit.TabIndex = 190;
            this.txtTotalDebit.UseSelectable = true;
            this.txtTotalDebit.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTotalDebit.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(59, 626);
            this.metroLabel11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(90, 20);
            this.metroLabel11.TabIndex = 189;
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
            this.dgJournalEntry.Location = new System.Drawing.Point(40, 667);
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
            this.dgJournalEntry.TabIndex = 188;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(496, 1078);
            this.btnFind.Margin = new System.Windows.Forms.Padding(4);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(132, 28);
            this.btnFind.TabIndex = 187;
            this.btnFind.Text = "Find";
            this.btnFind.UseSelectable = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(83, 1078);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(4);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(132, 28);
            this.metroButton1.TabIndex = 186;
            this.metroButton1.Text = "Add";
            this.metroButton1.UseSelectable = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(356, 1078);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(132, 28);
            this.btnDelete.TabIndex = 185;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(220, 1078);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(132, 28);
            this.btnSave.TabIndex = 184;
            this.btnSave.Text = "Save";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(621, 345);
            this.metroLabel10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(93, 20);
            this.metroLabel10.TabIndex = 183;
            this.metroLabel10.Text = "Check Details";
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
            this.txtCheckDetails.Location = new System.Drawing.Point(871, 345);
            this.txtCheckDetails.Margin = new System.Windows.Forms.Padding(4);
            this.txtCheckDetails.MaxLength = 32767;
            this.txtCheckDetails.Name = "txtCheckDetails";
            this.txtCheckDetails.PasswordChar = '\0';
            this.txtCheckDetails.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCheckDetails.SelectedText = "";
            this.txtCheckDetails.SelectionLength = 0;
            this.txtCheckDetails.SelectionStart = 0;
            this.txtCheckDetails.ShortcutsEnabled = true;
            this.txtCheckDetails.Size = new System.Drawing.Size(267, 28);
            this.txtCheckDetails.TabIndex = 182;
            this.txtCheckDetails.UseSelectable = true;
            this.txtCheckDetails.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCheckDetails.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel14
            // 
            this.metroLabel14.AutoSize = true;
            this.metroLabel14.Location = new System.Drawing.Point(621, 293);
            this.metroLabel14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Size = new System.Drawing.Size(100, 20);
            this.metroLabel14.TabIndex = 181;
            this.metroLabel14.Text = "Bank Accounts";
            // 
            // cbBank
            // 
            this.cbBank.FormattingEnabled = true;
            this.cbBank.ItemHeight = 24;
            this.cbBank.Location = new System.Drawing.Point(871, 293);
            this.cbBank.Margin = new System.Windows.Forms.Padding(4);
            this.cbBank.Name = "cbBank";
            this.cbBank.Size = new System.Drawing.Size(265, 30);
            this.cbBank.TabIndex = 180;
            this.cbBank.UseSelectable = true;
            this.cbBank.SelectedIndexChanged += new System.EventHandler(this.cbBank_SelectedIndexChanged);
            // 
            // chkIsCash
            // 
            this.chkIsCash.AutoSize = true;
            this.chkIsCash.DisplayFocus = true;
            this.chkIsCash.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkIsCash.Location = new System.Drawing.Point(284, 293);
            this.chkIsCash.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkIsCash.Name = "chkIsCash";
            this.chkIsCash.Size = new System.Drawing.Size(56, 20);
            this.chkIsCash.TabIndex = 179;
            this.chkIsCash.Text = "Cash";
            this.chkIsCash.UseSelectable = true;
            // 
            // txtDescription
            // 
            // 
            // 
            // 
            this.txtDescription.CustomButton.Image = null;
            this.txtDescription.CustomButton.Location = new System.Drawing.Point(714, 2);
            this.txtDescription.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.CustomButton.Name = "";
            this.txtDescription.CustomButton.Size = new System.Drawing.Size(207, 207);
            this.txtDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDescription.CustomButton.TabIndex = 1;
            this.txtDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDescription.CustomButton.UseSelectable = true;
            this.txtDescription.CustomButton.Visible = false;
            this.txtDescription.Lines = new string[0];
            this.txtDescription.Location = new System.Drawing.Point(236, 399);
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
            this.txtDescription.Size = new System.Drawing.Size(924, 212);
            this.txtDescription.TabIndex = 178;
            this.txtDescription.UseSelectable = true;
            this.txtDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(43, 399);
            this.metroLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(79, 20);
            this.metroLabel9.TabIndex = 177;
            this.metroLabel9.Text = "Description";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(43, 239);
            this.metroLabel8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(147, 20);
            this.metroLabel8.TabIndex = 176;
            this.metroLabel8.Text = "Payment Total Amount";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(43, 185);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(168, 20);
            this.metroLabel5.TabIndex = 174;
            this.metroLabel5.Text = "Payment Transaction Date";
            // 
            // dtPaymentTransactionDate
            // 
            this.dtPaymentTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPaymentTransactionDate.Location = new System.Drawing.Point(285, 185);
            this.dtPaymentTransactionDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtPaymentTransactionDate.MinimumSize = new System.Drawing.Size(0, 30);
            this.dtPaymentTransactionDate.Name = "dtPaymentTransactionDate";
            this.dtPaymentTransactionDate.Size = new System.Drawing.Size(265, 30);
            this.dtPaymentTransactionDate.TabIndex = 173;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(40, 89);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(93, 20);
            this.metroLabel4.TabIndex = 172;
            this.metroLabel4.Text = "Payment CV#";
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
            this.txtPaymentCV.Location = new System.Drawing.Point(284, 89);
            this.txtPaymentCV.Margin = new System.Windows.Forms.Padding(4);
            this.txtPaymentCV.MaxLength = 32767;
            this.txtPaymentCV.Name = "txtPaymentCV";
            this.txtPaymentCV.PasswordChar = '\0';
            this.txtPaymentCV.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPaymentCV.SelectedText = "";
            this.txtPaymentCV.SelectionLength = 0;
            this.txtPaymentCV.SelectionStart = 0;
            this.txtPaymentCV.ShortcutsEnabled = true;
            this.txtPaymentCV.Size = new System.Drawing.Size(265, 28);
            this.txtPaymentCV.TabIndex = 171;
            this.txtPaymentCV.UseSelectable = true;
            this.txtPaymentCV.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPaymentCV.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(40, 38);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(79, 20);
            this.metroLabel3.TabIndex = 170;
            this.metroLabel3.Text = "Payment ID";
            // 
            // txtPaymentId
            // 
            this.txtPaymentId.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtPaymentId.CustomButton.Image = null;
            this.txtPaymentId.CustomButton.Location = new System.Drawing.Point(239, 2);
            this.txtPaymentId.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtPaymentId.CustomButton.Name = "";
            this.txtPaymentId.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtPaymentId.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPaymentId.CustomButton.TabIndex = 1;
            this.txtPaymentId.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPaymentId.CustomButton.UseSelectable = true;
            this.txtPaymentId.CustomButton.Visible = false;
            this.txtPaymentId.Lines = new string[0];
            this.txtPaymentId.Location = new System.Drawing.Point(284, 38);
            this.txtPaymentId.Margin = new System.Windows.Forms.Padding(4);
            this.txtPaymentId.MaxLength = 32767;
            this.txtPaymentId.Name = "txtPaymentId";
            this.txtPaymentId.PasswordChar = '\0';
            this.txtPaymentId.ReadOnly = true;
            this.txtPaymentId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPaymentId.SelectedText = "";
            this.txtPaymentId.SelectionLength = 0;
            this.txtPaymentId.SelectionStart = 0;
            this.txtPaymentId.ShortcutsEnabled = true;
            this.txtPaymentId.Size = new System.Drawing.Size(265, 28);
            this.txtPaymentId.TabIndex = 169;
            this.txtPaymentId.UseCustomBackColor = true;
            this.txtPaymentId.UseSelectable = true;
            this.txtPaymentId.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtPaymentId.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(621, 135);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(54, 20);
            this.metroLabel2.TabIndex = 168;
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
            this.txtPurchasePONo.Location = new System.Drawing.Point(871, 135);
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
            this.txtPurchasePONo.TabIndex = 167;
            this.txtPurchasePONo.UseCustomBackColor = true;
            this.txtPurchasePONo.UseSelectable = true;
            this.txtPurchasePONo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPurchasePONo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSearchPurchase
            // 
            this.btnSearchPurchase.Location = new System.Drawing.Point(1147, 38);
            this.btnSearchPurchase.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchPurchase.Name = "btnSearchPurchase";
            this.btnSearchPurchase.Size = new System.Drawing.Size(132, 28);
            this.btnSearchPurchase.TabIndex = 166;
            this.btnSearchPurchase.Text = "Search Purchase";
            this.btnSearchPurchase.UseSelectable = true;
            this.btnSearchPurchase.Click += new System.EventHandler(this.btnSearchPurchase_Click);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(621, 185);
            this.metroLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(103, 20);
            this.metroLabel6.TabIndex = 165;
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
            this.txtPurchaseSIDR.Location = new System.Drawing.Point(873, 185);
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
            this.txtPurchaseSIDR.TabIndex = 164;
            this.txtPurchaseSIDR.UseCustomBackColor = true;
            this.txtPurchaseSIDR.UseSelectable = true;
            this.txtPurchaseSIDR.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPurchaseSIDR.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(621, 89);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(59, 20);
            this.metroLabel1.TabIndex = 163;
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
            this.txtSupplier.Location = new System.Drawing.Point(871, 89);
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
            this.txtSupplier.TabIndex = 162;
            this.txtSupplier.UseCustomBackColor = true;
            this.txtSupplier.UseSelectable = true;
            this.txtSupplier.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSupplier.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(621, 38);
            this.metroLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(83, 20);
            this.metroLabel7.TabIndex = 161;
            this.metroLabel7.Text = "Purchase ID";
            // 
            // txtPurchaseId
            // 
            this.txtPurchaseId.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtPurchaseId.CustomButton.Image = null;
            this.txtPurchaseId.CustomButton.Location = new System.Drawing.Point(242, 2);
            this.txtPurchaseId.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtPurchaseId.CustomButton.Name = "";
            this.txtPurchaseId.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtPurchaseId.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPurchaseId.CustomButton.TabIndex = 1;
            this.txtPurchaseId.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPurchaseId.CustomButton.UseSelectable = true;
            this.txtPurchaseId.CustomButton.Visible = false;
            this.txtPurchaseId.Lines = new string[0];
            this.txtPurchaseId.Location = new System.Drawing.Point(871, 38);
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
            this.txtPurchaseId.Size = new System.Drawing.Size(268, 28);
            this.txtPurchaseId.TabIndex = 160;
            this.txtPurchaseId.UseCustomBackColor = true;
            this.txtPurchaseId.UseSelectable = true;
            this.txtPurchaseId.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtPurchaseId.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel15
            // 
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.Location = new System.Drawing.Point(40, 135);
            this.metroLabel15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Size = new System.Drawing.Size(99, 20);
            this.metroLabel15.TabIndex = 198;
            this.metroLabel15.Text = "Payment SI/DR";
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
            this.txtPaymentSIDR.Location = new System.Drawing.Point(284, 135);
            this.txtPaymentSIDR.Margin = new System.Windows.Forms.Padding(4);
            this.txtPaymentSIDR.MaxLength = 32767;
            this.txtPaymentSIDR.Name = "txtPaymentSIDR";
            this.txtPaymentSIDR.PasswordChar = '\0';
            this.txtPaymentSIDR.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPaymentSIDR.SelectedText = "";
            this.txtPaymentSIDR.SelectionLength = 0;
            this.txtPaymentSIDR.SelectionStart = 0;
            this.txtPaymentSIDR.ShortcutsEnabled = true;
            this.txtPaymentSIDR.Size = new System.Drawing.Size(265, 28);
            this.txtPaymentSIDR.TabIndex = 197;
            this.txtPaymentSIDR.UseSelectable = true;
            this.txtPaymentSIDR.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPaymentSIDR.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtPaymentTotal
            // 
            // 
            // 
            // 
            this.txtPaymentTotal.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtPaymentTotal.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtPaymentTotal.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtPaymentTotal.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtPaymentTotal.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtPaymentTotal.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtPaymentTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPaymentTotal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtPaymentTotal.Increment = 1D;
            this.txtPaymentTotal.Location = new System.Drawing.Point(284, 239);
            this.txtPaymentTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPaymentTotal.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtPaymentTotal.Name = "txtPaymentTotal";
            this.txtPaymentTotal.ShowUpDown = true;
            this.txtPaymentTotal.Size = new System.Drawing.Size(263, 28);
            this.txtPaymentTotal.TabIndex = 175;
            this.txtPaymentTotal.ValueChanged += new System.EventHandler(this.txtPaymentTotal_ValueChanged);
            // 
            // metroLabel16
            // 
            this.metroLabel16.AutoSize = true;
            this.metroLabel16.Location = new System.Drawing.Point(621, 239);
            this.metroLabel16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Size = new System.Drawing.Size(151, 20);
            this.metroLabel16.TabIndex = 206;
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
            this.txtPurchaseTotal.Location = new System.Drawing.Point(871, 239);
            this.txtPurchaseTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPurchaseTotal.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtPurchaseTotal.Name = "txtPurchaseTotal";
            this.txtPurchaseTotal.Size = new System.Drawing.Size(267, 28);
            this.txtPurchaseTotal.TabIndex = 205;
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroLabel16);
            this.Controls.Add(this.txtPurchaseTotal);
            this.Controls.Add(this.metroLabel15);
            this.Controls.Add(this.txtPaymentSIDR);
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
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.txtCheckDetails);
            this.Controls.Add(this.metroLabel14);
            this.Controls.Add(this.cbBank);
            this.Controls.Add(this.chkIsCash);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.txtPaymentTotal);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.dtPaymentTransactionDate);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.txtPaymentCV);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.txtPaymentId);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtPurchasePONo);
            this.Controls.Add(this.btnSearchPurchase);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.txtPurchaseSIDR);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtSupplier);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.txtPurchaseId);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmPayment";
            this.Size = new System.Drawing.Size(1537, 1141);
            this.Load += new System.EventHandler(this.frmPayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgJournalEntry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaymentTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchaseTotal)).EndInit();
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
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroTextBox txtCheckDetails;
        private MetroFramework.Controls.MetroLabel metroLabel14;
        private MetroFramework.Controls.MetroComboBox cbBank;
        private MetroFramework.Controls.MetroCheckBox chkIsCash;
        private MetroFramework.Controls.MetroTextBox txtDescription;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroDateTime dtPaymentTransactionDate;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtPaymentCV;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtPaymentId;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtPurchasePONo;
        private MetroFramework.Controls.MetroButton btnSearchPurchase;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox txtPurchaseSIDR;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtSupplier;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTextBox txtPurchaseId;
        private MetroFramework.Controls.MetroLabel metroLabel15;
        private MetroFramework.Controls.MetroTextBox txtPaymentSIDR;
        private DevComponents.Editors.DoubleInput txtPaymentTotal;
        private MetroFramework.Controls.MetroLabel metroLabel16;
        private DevComponents.Editors.DoubleInput txtPurchaseTotal;
    }
}
