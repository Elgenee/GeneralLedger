namespace GeneralLedger.UserControls
{
    partial class JournalEntry
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.cbBookType = new MetroFramework.Controls.MetroComboBox();
            this.spGLGetBookTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.generalLedgerDataSet1 = new GeneralLedger.GeneralLedgerDataSet1();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.txtID = new MetroFramework.Controls.MetroTextBox();
            this.txtDescription = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtTransactionCode = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.dtBatchDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtTransactionNo = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.dgJournalEntry = new MetroFramework.Controls.MetroGrid();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.btnDeleteEntry = new MetroFramework.Controls.MetroButton();
            this.btnAddEntry = new MetroFramework.Controls.MetroButton();
            this.txtTotalDebit = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.txtTotalCredit = new MetroFramework.Controls.MetroTextBox();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.btnDelete = new MetroFramework.Controls.MetroButton();
            this.btnFind = new MetroFramework.Controls.MetroButton();
            this.btnAdd = new MetroFramework.Controls.MetroButton();
            this.spGLGetBookTypeTableAdapter = new GeneralLedger.GeneralLedgerDataSet1TableAdapters.spGLGetBookTypeTableAdapter();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spGLGetBookTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.generalLedgerDataSet1)).BeginInit();
            this.metroPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgJournalEntry)).BeginInit();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.metroPanel1.Controls.Add(this.metroLabel8);
            this.metroPanel1.Controls.Add(this.cbBookType);
            this.metroPanel1.Controls.Add(this.metroLabel7);
            this.metroPanel1.Controls.Add(this.txtID);
            this.metroPanel1.Controls.Add(this.txtDescription);
            this.metroPanel1.Controls.Add(this.metroLabel4);
            this.metroPanel1.Controls.Add(this.metroLabel3);
            this.metroPanel1.Controls.Add(this.txtTransactionCode);
            this.metroPanel1.Controls.Add(this.metroLabel2);
            this.metroPanel1.Controls.Add(this.dtBatchDate);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Controls.Add(this.txtTransactionNo);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 15;
            this.metroPanel1.Location = new System.Drawing.Point(12, 8);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1493, 371);
            this.metroPanel1.TabIndex = 2;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 15;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(1015, 7);
            this.metroLabel8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(70, 19);
            this.metroLabel8.TabIndex = 15;
            this.metroLabel8.Text = "Book Type";
            // 
            // cbBookType
            // 
            this.cbBookType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.spGLGetBookTypeBindingSource, "ID", true));
            this.cbBookType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.spGLGetBookTypeBindingSource, "strName", true));
            this.cbBookType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.spGLGetBookTypeBindingSource, "strName", true));
            this.cbBookType.FormattingEnabled = true;
            this.cbBookType.ItemHeight = 23;
            this.cbBookType.Location = new System.Drawing.Point(1148, 7);
            this.cbBookType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbBookType.Name = "cbBookType";
            this.cbBookType.Size = new System.Drawing.Size(330, 29);
            this.cbBookType.TabIndex = 14;
            this.cbBookType.UseSelectable = true;
            // 
            // spGLGetBookTypeBindingSource
            // 
            this.spGLGetBookTypeBindingSource.DataMember = "spGLGetBookType";
            this.spGLGetBookTypeBindingSource.DataSource = this.generalLedgerDataSet1;
            // 
            // generalLedgerDataSet1
            // 
            this.generalLedgerDataSet1.DataSetName = "GeneralLedgerDataSet1";
            this.generalLedgerDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(16, 7);
            this.metroLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(21, 19);
            this.metroLabel7.TabIndex = 11;
            this.metroLabel7.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.ControlLight;
            // 
            // 
            // 
            this.txtID.CustomButton.Image = null;
            this.txtID.CustomButton.Location = new System.Drawing.Point(240, 1);
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
            this.txtID.Location = new System.Drawing.Point(182, 7);
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
            this.txtID.Size = new System.Drawing.Size(274, 35);
            this.txtID.TabIndex = 10;
            this.txtID.UseCustomBackColor = true;
            this.txtID.UseSelectable = true;
            this.txtID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtDescription
            // 
            // 
            // 
            // 
            this.txtDescription.CustomButton.Image = null;
            this.txtDescription.CustomButton.Location = new System.Drawing.Point(1034, 2);
            this.txtDescription.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDescription.CustomButton.Name = "";
            this.txtDescription.CustomButton.Size = new System.Drawing.Size(259, 259);
            this.txtDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDescription.CustomButton.TabIndex = 1;
            this.txtDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDescription.CustomButton.UseSelectable = true;
            this.txtDescription.CustomButton.Visible = false;
            this.txtDescription.Lines = new string[0];
            this.txtDescription.Location = new System.Drawing.Point(182, 102);
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
            this.txtDescription.Size = new System.Drawing.Size(1296, 264);
            this.txtDescription.TabIndex = 9;
            this.txtDescription.UseSelectable = true;
            this.txtDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(16, 102);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(74, 19);
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.Text = "Description";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(16, 52);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(109, 19);
            this.metroLabel3.TabIndex = 7;
            this.metroLabel3.Text = "Transaction Code";
            // 
            // txtTransactionCode
            // 
            this.txtTransactionCode.BackColor = System.Drawing.SystemColors.ControlLight;
            // 
            // 
            // 
            this.txtTransactionCode.CustomButton.Image = null;
            this.txtTransactionCode.CustomButton.Location = new System.Drawing.Point(240, 1);
            this.txtTransactionCode.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTransactionCode.CustomButton.Name = "";
            this.txtTransactionCode.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtTransactionCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTransactionCode.CustomButton.TabIndex = 1;
            this.txtTransactionCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTransactionCode.CustomButton.UseSelectable = true;
            this.txtTransactionCode.CustomButton.Visible = false;
            this.txtTransactionCode.Enabled = false;
            this.txtTransactionCode.Lines = new string[0];
            this.txtTransactionCode.Location = new System.Drawing.Point(182, 52);
            this.txtTransactionCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTransactionCode.MaxLength = 32767;
            this.txtTransactionCode.Name = "txtTransactionCode";
            this.txtTransactionCode.PasswordChar = '\0';
            this.txtTransactionCode.ReadOnly = true;
            this.txtTransactionCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTransactionCode.SelectedText = "";
            this.txtTransactionCode.SelectionLength = 0;
            this.txtTransactionCode.SelectionStart = 0;
            this.txtTransactionCode.ShortcutsEnabled = true;
            this.txtTransactionCode.Size = new System.Drawing.Size(274, 35);
            this.txtTransactionCode.TabIndex = 6;
            this.txtTransactionCode.UseCustomBackColor = true;
            this.txtTransactionCode.UseSelectable = true;
            this.txtTransactionCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTransactionCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(527, 52);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(72, 19);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "Batch Date";
            // 
            // dtBatchDate
            // 
            this.dtBatchDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBatchDate.Location = new System.Drawing.Point(693, 52);
            this.dtBatchDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtBatchDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtBatchDate.Name = "dtBatchDate";
            this.dtBatchDate.Size = new System.Drawing.Size(298, 29);
            this.dtBatchDate.TabIndex = 4;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(527, 7);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(98, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Transaction No.";
            // 
            // txtTransactionNo
            // 
            // 
            // 
            // 
            this.txtTransactionNo.CustomButton.Image = null;
            this.txtTransactionNo.CustomButton.Location = new System.Drawing.Point(264, 1);
            this.txtTransactionNo.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTransactionNo.CustomButton.Name = "";
            this.txtTransactionNo.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtTransactionNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTransactionNo.CustomButton.TabIndex = 1;
            this.txtTransactionNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTransactionNo.CustomButton.UseSelectable = true;
            this.txtTransactionNo.CustomButton.Visible = false;
            this.txtTransactionNo.Lines = new string[0];
            this.txtTransactionNo.Location = new System.Drawing.Point(693, 7);
            this.txtTransactionNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTransactionNo.MaxLength = 32767;
            this.txtTransactionNo.Name = "txtTransactionNo";
            this.txtTransactionNo.PasswordChar = '\0';
            this.txtTransactionNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTransactionNo.SelectedText = "";
            this.txtTransactionNo.SelectionLength = 0;
            this.txtTransactionNo.SelectionStart = 0;
            this.txtTransactionNo.ShortcutsEnabled = true;
            this.txtTransactionNo.Size = new System.Drawing.Size(298, 35);
            this.txtTransactionNo.TabIndex = 2;
            this.txtTransactionNo.UseSelectable = true;
            this.txtTransactionNo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTransactionNo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroPanel3
            // 
            this.metroPanel3.Controls.Add(this.dgJournalEntry);
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 15;
            this.metroPanel3.Location = new System.Drawing.Point(12, 434);
            this.metroPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(1493, 426);
            this.metroPanel3.TabIndex = 4;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 15;
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
            this.dgJournalEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgJournalEntry.EnableHeadersVisualStyles = false;
            this.dgJournalEntry.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgJournalEntry.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgJournalEntry.Location = new System.Drawing.Point(0, 0);
            this.dgJournalEntry.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.dgJournalEntry.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgJournalEntry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgJournalEntry.Size = new System.Drawing.Size(1493, 426);
            this.dgJournalEntry.TabIndex = 2;
            this.dgJournalEntry.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgJournalEntry_CellClick);
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(12, 400);
            this.metroLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(85, 19);
            this.metroLabel9.TabIndex = 13;
            this.metroLabel9.Text = "Journal Entry";
            this.metroLabel9.Click += new System.EventHandler(this.metroLabel9_Click);
            // 
            // btnDeleteEntry
            // 
            this.btnDeleteEntry.Location = new System.Drawing.Point(489, 389);
            this.btnDeleteEntry.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeleteEntry.Name = "btnDeleteEntry";
            this.btnDeleteEntry.Size = new System.Drawing.Size(148, 35);
            this.btnDeleteEntry.TabIndex = 18;
            this.btnDeleteEntry.Text = "Delete Entry";
            this.btnDeleteEntry.UseSelectable = true;
            this.btnDeleteEntry.Click += new System.EventHandler(this.btnDeleteEntry_Click);
            // 
            // btnAddEntry
            // 
            this.btnAddEntry.Location = new System.Drawing.Point(331, 389);
            this.btnAddEntry.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddEntry.Name = "btnAddEntry";
            this.btnAddEntry.Size = new System.Drawing.Size(148, 35);
            this.btnAddEntry.TabIndex = 17;
            this.btnAddEntry.Text = "Add Entry";
            this.btnAddEntry.UseSelectable = true;
            this.btnAddEntry.Click += new System.EventHandler(this.btnAddEntry_Click);
            // 
            // txtTotalDebit
            // 
            // 
            // 
            // 
            this.txtTotalDebit.CustomButton.Image = null;
            this.txtTotalDebit.CustomButton.Location = new System.Drawing.Point(140, 1);
            this.txtTotalDebit.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTotalDebit.CustomButton.Name = "";
            this.txtTotalDebit.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtTotalDebit.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTotalDebit.CustomButton.TabIndex = 1;
            this.txtTotalDebit.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTotalDebit.CustomButton.UseSelectable = true;
            this.txtTotalDebit.CustomButton.Visible = false;
            this.txtTotalDebit.Lines = new string[0];
            this.txtTotalDebit.Location = new System.Drawing.Point(950, 895);
            this.txtTotalDebit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTotalDebit.MaxLength = 32767;
            this.txtTotalDebit.Name = "txtTotalDebit";
            this.txtTotalDebit.PasswordChar = '\0';
            this.txtTotalDebit.ReadOnly = true;
            this.txtTotalDebit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTotalDebit.SelectedText = "";
            this.txtTotalDebit.SelectionLength = 0;
            this.txtTotalDebit.SelectionStart = 0;
            this.txtTotalDebit.ShortcutsEnabled = true;
            this.txtTotalDebit.Size = new System.Drawing.Size(174, 35);
            this.txtTotalDebit.TabIndex = 19;
            this.txtTotalDebit.UseSelectable = true;
            this.txtTotalDebit.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTotalDebit.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(834, 895);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(71, 19);
            this.metroLabel5.TabIndex = 20;
            this.metroLabel5.Text = "Total Debit";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(1160, 895);
            this.metroLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(76, 19);
            this.metroLabel6.TabIndex = 22;
            this.metroLabel6.Text = "Total Credit";
            // 
            // txtTotalCredit
            // 
            // 
            // 
            // 
            this.txtTotalCredit.CustomButton.Image = null;
            this.txtTotalCredit.CustomButton.Location = new System.Drawing.Point(140, 1);
            this.txtTotalCredit.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTotalCredit.CustomButton.Name = "";
            this.txtTotalCredit.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtTotalCredit.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTotalCredit.CustomButton.TabIndex = 1;
            this.txtTotalCredit.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTotalCredit.CustomButton.UseSelectable = true;
            this.txtTotalCredit.CustomButton.Visible = false;
            this.txtTotalCredit.Lines = new string[0];
            this.txtTotalCredit.Location = new System.Drawing.Point(1275, 895);
            this.txtTotalCredit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTotalCredit.MaxLength = 32767;
            this.txtTotalCredit.Name = "txtTotalCredit";
            this.txtTotalCredit.PasswordChar = '\0';
            this.txtTotalCredit.ReadOnly = true;
            this.txtTotalCredit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTotalCredit.SelectedText = "";
            this.txtTotalCredit.SelectionLength = 0;
            this.txtTotalCredit.SelectionStart = 0;
            this.txtTotalCredit.ShortcutsEnabled = true;
            this.txtTotalCredit.Size = new System.Drawing.Size(174, 35);
            this.txtTotalCredit.TabIndex = 21;
            this.txtTotalCredit.UseSelectable = true;
            this.txtTotalCredit.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTotalCredit.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(160, 895);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(148, 35);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(318, 895);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(148, 35);
            this.btnDelete.TabIndex = 24;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(476, 895);
            this.btnFind.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(148, 35);
            this.btnFind.TabIndex = 25;
            this.btnFind.Text = "Find";
            this.btnFind.UseSelectable = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(4, 895);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(148, 35);
            this.btnAdd.TabIndex = 26;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseSelectable = true;
            this.btnAdd.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // spGLGetBookTypeTableAdapter
            // 
            this.spGLGetBookTypeTableAdapter.ClearBeforeFill = true;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
            this.btnClose.Image = global::GeneralLedger.Properties.Resources.cancel;
            this.btnClose.Location = new System.Drawing.Point(1525, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(154, 55);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnClose.TabIndex = 39;
            this.btnClose.Text = "Close Page";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // JournalEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.txtTotalCredit);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.txtTotalDebit);
            this.Controls.Add(this.btnDeleteEntry);
            this.Controls.Add(this.btnAddEntry);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.metroPanel3);
            this.Controls.Add(this.metroPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "JournalEntry";
            this.Size = new System.Drawing.Size(1700, 1200);
            this.Load += new System.EventHandler(this.JournalEntry_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spGLGetBookTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.generalLedgerDataSet1)).EndInit();
            this.metroPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgJournalEntry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTextBox txtDescription;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtTransactionCode;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroDateTime dtBatchDate;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtTransactionNo;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroGrid dgJournalEntry;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroButton btnDeleteEntry;
        private MetroFramework.Controls.MetroButton btnAddEntry;
        private MetroFramework.Controls.MetroTextBox txtTotalDebit;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox txtTotalCredit;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroButton btnDelete;
        private MetroFramework.Controls.MetroButton btnFind;
        private MetroFramework.Controls.MetroButton btnAdd;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTextBox txtID;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroComboBox cbBookType;
        private System.Windows.Forms.BindingSource spGLGetBookTypeBindingSource;
        private GeneralLedgerDataSet1 generalLedgerDataSet1;
        private GeneralLedgerDataSet1TableAdapters.spGLGetBookTypeTableAdapter spGLGetBookTypeTableAdapter;
        private DevComponents.DotNetBar.ButtonX btnClose;
    }
}
