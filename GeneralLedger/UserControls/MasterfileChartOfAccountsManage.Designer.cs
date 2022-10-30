namespace GeneralLedger.UserControls
{
    partial class MasterfileChartOfAccountsManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtCoaCode = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtDescription = new MetroFramework.Controls.MetroTextBox();
            this.cbCOAGroup = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtAccountingSide = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.txtAccountingType = new MetroFramework.Controls.MetroTextBox();
            this.btnSaveCoa = new MetroFramework.Controls.MetroButton();
            this.btnDeleteCOA = new MetroFramework.Controls.MetroButton();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.dtgSubCoa = new MetroFramework.Controls.MetroGrid();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIDCOA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strCoaSubCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strCoaSubName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.txtCoaSubCode = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.txtCoaSubName = new MetroFramework.Controls.MetroTextBox();
            this.btnDeleteCoaSubsidiary = new MetroFramework.Controls.MetroButton();
            this.btnSaveCoaSubsidiary = new MetroFramework.Controls.MetroButton();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.txtIDCoaSub = new MetroFramework.Controls.MetroTextBox();
            this.btnAddNewCoaSub = new MetroFramework.Controls.MetroButton();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.txtIncomeStatementOrdering = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSubCoa)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCoaCode
            // 
            // 
            // 
            // 
            this.txtCoaCode.CustomButton.Image = null;
            this.txtCoaCode.CustomButton.Location = new System.Drawing.Point(174, 1);
            this.txtCoaCode.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCoaCode.CustomButton.Name = "";
            this.txtCoaCode.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtCoaCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCoaCode.CustomButton.TabIndex = 1;
            this.txtCoaCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCoaCode.CustomButton.UseSelectable = true;
            this.txtCoaCode.CustomButton.Visible = false;
            this.txtCoaCode.Lines = new string[0];
            this.txtCoaCode.Location = new System.Drawing.Point(312, 42);
            this.txtCoaCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCoaCode.MaxLength = 32767;
            this.txtCoaCode.Name = "txtCoaCode";
            this.txtCoaCode.PasswordChar = '\0';
            this.txtCoaCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCoaCode.SelectedText = "";
            this.txtCoaCode.SelectionLength = 0;
            this.txtCoaCode.SelectionStart = 0;
            this.txtCoaCode.ShortcutsEnabled = true;
            this.txtCoaCode.Size = new System.Drawing.Size(208, 35);
            this.txtCoaCode.TabIndex = 0;
            this.txtCoaCode.UseSelectable = true;
            this.txtCoaCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCoaCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(39, 42);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(74, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "COA Code";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(39, 86);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(107, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "COA Description";
            // 
            // txtDescription
            // 
            // 
            // 
            // 
            this.txtDescription.CustomButton.Image = null;
            this.txtDescription.CustomButton.Location = new System.Drawing.Point(628, 1);
            this.txtDescription.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDescription.CustomButton.Name = "";
            this.txtDescription.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDescription.CustomButton.TabIndex = 1;
            this.txtDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDescription.CustomButton.UseSelectable = true;
            this.txtDescription.CustomButton.Visible = false;
            this.txtDescription.Lines = new string[0];
            this.txtDescription.Location = new System.Drawing.Point(312, 86);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDescription.MaxLength = 32767;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PasswordChar = '\0';
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDescription.SelectedText = "";
            this.txtDescription.SelectionLength = 0;
            this.txtDescription.SelectionStart = 0;
            this.txtDescription.ShortcutsEnabled = true;
            this.txtDescription.Size = new System.Drawing.Size(662, 35);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.UseSelectable = true;
            this.txtDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // cbCOAGroup
            // 
            this.cbCOAGroup.FormattingEnabled = true;
            this.cbCOAGroup.ItemHeight = 23;
            this.cbCOAGroup.Location = new System.Drawing.Point(312, 131);
            this.cbCOAGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCOAGroup.Name = "cbCOAGroup";
            this.cbCOAGroup.Size = new System.Drawing.Size(330, 29);
            this.cbCOAGroup.TabIndex = 4;
            this.cbCOAGroup.UseSelectable = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(39, 131);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(79, 19);
            this.metroLabel3.TabIndex = 5;
            this.metroLabel3.Text = "COA Group";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(39, 185);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(85, 19);
            this.metroLabel4.TabIndex = 7;
            this.metroLabel4.Text = "Account Side";
            // 
            // txtAccountingSide
            // 
            // 
            // 
            // 
            this.txtAccountingSide.CustomButton.Image = null;
            this.txtAccountingSide.CustomButton.Location = new System.Drawing.Point(174, 1);
            this.txtAccountingSide.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAccountingSide.CustomButton.Name = "";
            this.txtAccountingSide.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtAccountingSide.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAccountingSide.CustomButton.TabIndex = 1;
            this.txtAccountingSide.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAccountingSide.CustomButton.UseSelectable = true;
            this.txtAccountingSide.CustomButton.Visible = false;
            this.txtAccountingSide.Lines = new string[0];
            this.txtAccountingSide.Location = new System.Drawing.Point(312, 185);
            this.txtAccountingSide.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAccountingSide.MaxLength = 32767;
            this.txtAccountingSide.Name = "txtAccountingSide";
            this.txtAccountingSide.PasswordChar = '\0';
            this.txtAccountingSide.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAccountingSide.SelectedText = "";
            this.txtAccountingSide.SelectionLength = 0;
            this.txtAccountingSide.SelectionStart = 0;
            this.txtAccountingSide.ShortcutsEnabled = true;
            this.txtAccountingSide.Size = new System.Drawing.Size(208, 35);
            this.txtAccountingSide.TabIndex = 6;
            this.txtAccountingSide.UseSelectable = true;
            this.txtAccountingSide.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAccountingSide.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(39, 237);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(105, 19);
            this.metroLabel5.TabIndex = 8;
            this.metroLabel5.Text = "Accounting Type";
            // 
            // txtAccountingType
            // 
            // 
            // 
            // 
            this.txtAccountingType.CustomButton.Image = null;
            this.txtAccountingType.CustomButton.Location = new System.Drawing.Point(174, 1);
            this.txtAccountingType.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAccountingType.CustomButton.Name = "";
            this.txtAccountingType.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtAccountingType.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAccountingType.CustomButton.TabIndex = 1;
            this.txtAccountingType.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAccountingType.CustomButton.UseSelectable = true;
            this.txtAccountingType.CustomButton.Visible = false;
            this.txtAccountingType.Lines = new string[0];
            this.txtAccountingType.Location = new System.Drawing.Point(312, 237);
            this.txtAccountingType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAccountingType.MaxLength = 32767;
            this.txtAccountingType.Name = "txtAccountingType";
            this.txtAccountingType.PasswordChar = '\0';
            this.txtAccountingType.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAccountingType.SelectedText = "";
            this.txtAccountingType.SelectionLength = 0;
            this.txtAccountingType.SelectionStart = 0;
            this.txtAccountingType.ShortcutsEnabled = true;
            this.txtAccountingType.Size = new System.Drawing.Size(208, 35);
            this.txtAccountingType.TabIndex = 9;
            this.txtAccountingType.UseSelectable = true;
            this.txtAccountingType.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAccountingType.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSaveCoa
            // 
            this.btnSaveCoa.Location = new System.Drawing.Point(312, 282);
            this.btnSaveCoa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSaveCoa.Name = "btnSaveCoa";
            this.btnSaveCoa.Size = new System.Drawing.Size(147, 35);
            this.btnSaveCoa.TabIndex = 10;
            this.btnSaveCoa.Text = "Save COA";
            this.btnSaveCoa.UseSelectable = true;
            this.btnSaveCoa.Click += new System.EventHandler(this.btnSaveCoa_Click);
            // 
            // btnDeleteCOA
            // 
            this.btnDeleteCOA.Location = new System.Drawing.Point(468, 282);
            this.btnDeleteCOA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeleteCOA.Name = "btnDeleteCOA";
            this.btnDeleteCOA.Size = new System.Drawing.Size(147, 35);
            this.btnDeleteCOA.TabIndex = 11;
            this.btnDeleteCOA.Text = "Delete COA";
            this.btnDeleteCOA.UseSelectable = true;
            this.btnDeleteCOA.Click += new System.EventHandler(this.btnDeleteCOA_Click);
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.dtgSubCoa);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 15;
            this.metroPanel1.Location = new System.Drawing.Point(9, 340);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1156, 303);
            this.metroPanel1.TabIndex = 13;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 15;
            // 
            // dtgSubCoa
            // 
            this.dtgSubCoa.AllowUserToResizeRows = false;
            this.dtgSubCoa.BackgroundColor = System.Drawing.Color.White;
            this.dtgSubCoa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgSubCoa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtgSubCoa.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgSubCoa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgSubCoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSubCoa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.intIDCOA,
            this.strCoaSubCode,
            this.strCoaSubName});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgSubCoa.DefaultCellStyle = dataGridViewCellStyle8;
            this.dtgSubCoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgSubCoa.EnableHeadersVisualStyles = false;
            this.dtgSubCoa.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dtgSubCoa.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtgSubCoa.Location = new System.Drawing.Point(0, 0);
            this.dtgSubCoa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtgSubCoa.Name = "dtgSubCoa";
            this.dtgSubCoa.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgSubCoa.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dtgSubCoa.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgSubCoa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSubCoa.Size = new System.Drawing.Size(1156, 303);
            this.dtgSubCoa.TabIndex = 13;
            this.dtgSubCoa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSubCoa_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // intIDCOA
            // 
            this.intIDCOA.HeaderText = "intIDCOA";
            this.intIDCOA.Name = "intIDCOA";
            this.intIDCOA.ReadOnly = true;
            // 
            // strCoaSubCode
            // 
            this.strCoaSubCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.strCoaSubCode.HeaderText = "Code";
            this.strCoaSubCode.Name = "strCoaSubCode";
            this.strCoaSubCode.ReadOnly = true;
            // 
            // strCoaSubName
            // 
            this.strCoaSubName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.strCoaSubName.HeaderText = "Name";
            this.strCoaSubName.Name = "strCoaSubName";
            this.strCoaSubName.ReadOnly = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(39, 708);
            this.metroLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(138, 19);
            this.metroLabel6.TabIndex = 15;
            this.metroLabel6.Text = "COA Subsidiary Code";
            // 
            // txtCoaSubCode
            // 
            // 
            // 
            // 
            this.txtCoaSubCode.CustomButton.Image = null;
            this.txtCoaSubCode.CustomButton.Location = new System.Drawing.Point(174, 1);
            this.txtCoaSubCode.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCoaSubCode.CustomButton.Name = "";
            this.txtCoaSubCode.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtCoaSubCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCoaSubCode.CustomButton.TabIndex = 1;
            this.txtCoaSubCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCoaSubCode.CustomButton.UseSelectable = true;
            this.txtCoaSubCode.CustomButton.Visible = false;
            this.txtCoaSubCode.Lines = new string[0];
            this.txtCoaSubCode.Location = new System.Drawing.Point(312, 708);
            this.txtCoaSubCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCoaSubCode.MaxLength = 32767;
            this.txtCoaSubCode.Name = "txtCoaSubCode";
            this.txtCoaSubCode.PasswordChar = '\0';
            this.txtCoaSubCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCoaSubCode.SelectedText = "";
            this.txtCoaSubCode.SelectionLength = 0;
            this.txtCoaSubCode.SelectionStart = 0;
            this.txtCoaSubCode.ShortcutsEnabled = true;
            this.txtCoaSubCode.Size = new System.Drawing.Size(208, 35);
            this.txtCoaSubCode.TabIndex = 14;
            this.txtCoaSubCode.UseSelectable = true;
            this.txtCoaSubCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCoaSubCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(39, 752);
            this.metroLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(171, 19);
            this.metroLabel7.TabIndex = 17;
            this.metroLabel7.Text = "COA Subsidiary Description";
            // 
            // txtCoaSubName
            // 
            // 
            // 
            // 
            this.txtCoaSubName.CustomButton.Image = null;
            this.txtCoaSubName.CustomButton.Location = new System.Drawing.Point(794, 1);
            this.txtCoaSubName.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCoaSubName.CustomButton.Name = "";
            this.txtCoaSubName.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtCoaSubName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCoaSubName.CustomButton.TabIndex = 1;
            this.txtCoaSubName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCoaSubName.CustomButton.UseSelectable = true;
            this.txtCoaSubName.CustomButton.Visible = false;
            this.txtCoaSubName.Lines = new string[0];
            this.txtCoaSubName.Location = new System.Drawing.Point(312, 752);
            this.txtCoaSubName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCoaSubName.MaxLength = 32767;
            this.txtCoaSubName.Name = "txtCoaSubName";
            this.txtCoaSubName.PasswordChar = '\0';
            this.txtCoaSubName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCoaSubName.SelectedText = "";
            this.txtCoaSubName.SelectionLength = 0;
            this.txtCoaSubName.SelectionStart = 0;
            this.txtCoaSubName.ShortcutsEnabled = true;
            this.txtCoaSubName.Size = new System.Drawing.Size(828, 35);
            this.txtCoaSubName.TabIndex = 16;
            this.txtCoaSubName.UseSelectable = true;
            this.txtCoaSubName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCoaSubName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnDeleteCoaSubsidiary
            // 
            this.btnDeleteCoaSubsidiary.Location = new System.Drawing.Point(741, 797);
            this.btnDeleteCoaSubsidiary.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeleteCoaSubsidiary.Name = "btnDeleteCoaSubsidiary";
            this.btnDeleteCoaSubsidiary.Size = new System.Drawing.Size(188, 35);
            this.btnDeleteCoaSubsidiary.TabIndex = 19;
            this.btnDeleteCoaSubsidiary.Text = "Delete COA Subsidiary";
            this.btnDeleteCoaSubsidiary.UseSelectable = true;
            this.btnDeleteCoaSubsidiary.Click += new System.EventHandler(this.btnDeleteCoaSubsidiary_Click);
            // 
            // btnSaveCoaSubsidiary
            // 
            this.btnSaveCoaSubsidiary.Location = new System.Drawing.Point(526, 797);
            this.btnSaveCoaSubsidiary.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSaveCoaSubsidiary.Name = "btnSaveCoaSubsidiary";
            this.btnSaveCoaSubsidiary.Size = new System.Drawing.Size(208, 35);
            this.btnSaveCoaSubsidiary.TabIndex = 18;
            this.btnSaveCoaSubsidiary.Text = "Save COA Subsidiary";
            this.btnSaveCoaSubsidiary.UseSelectable = true;
            this.btnSaveCoaSubsidiary.Click += new System.EventHandler(this.btnSaveCoaSubsidiary_Click);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(39, 663);
            this.metroLabel8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(21, 19);
            this.metroLabel8.TabIndex = 21;
            this.metroLabel8.Text = "ID";
            // 
            // txtIDCoaSub
            // 
            // 
            // 
            // 
            this.txtIDCoaSub.CustomButton.Image = null;
            this.txtIDCoaSub.CustomButton.Location = new System.Drawing.Point(174, 1);
            this.txtIDCoaSub.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIDCoaSub.CustomButton.Name = "";
            this.txtIDCoaSub.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtIDCoaSub.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtIDCoaSub.CustomButton.TabIndex = 1;
            this.txtIDCoaSub.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtIDCoaSub.CustomButton.UseSelectable = true;
            this.txtIDCoaSub.CustomButton.Visible = false;
            this.txtIDCoaSub.Lines = new string[0];
            this.txtIDCoaSub.Location = new System.Drawing.Point(312, 663);
            this.txtIDCoaSub.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIDCoaSub.MaxLength = 32767;
            this.txtIDCoaSub.Name = "txtIDCoaSub";
            this.txtIDCoaSub.PasswordChar = '\0';
            this.txtIDCoaSub.ReadOnly = true;
            this.txtIDCoaSub.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtIDCoaSub.SelectedText = "";
            this.txtIDCoaSub.SelectionLength = 0;
            this.txtIDCoaSub.SelectionStart = 0;
            this.txtIDCoaSub.ShortcutsEnabled = true;
            this.txtIDCoaSub.Size = new System.Drawing.Size(208, 35);
            this.txtIDCoaSub.TabIndex = 20;
            this.txtIDCoaSub.UseSelectable = true;
            this.txtIDCoaSub.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtIDCoaSub.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnAddNewCoaSub
            // 
            this.btnAddNewCoaSub.Location = new System.Drawing.Point(312, 797);
            this.btnAddNewCoaSub.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddNewCoaSub.Name = "btnAddNewCoaSub";
            this.btnAddNewCoaSub.Size = new System.Drawing.Size(208, 35);
            this.btnAddNewCoaSub.TabIndex = 22;
            this.btnAddNewCoaSub.Text = "Add New COA Subsidiary";
            this.btnAddNewCoaSub.UseSelectable = true;
            this.btnAddNewCoaSub.Click += new System.EventHandler(this.btnAddNewCoaSub_Click);
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(540, 185);
            this.metroLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(169, 19);
            this.metroLabel9.TabIndex = 24;
            this.metroLabel9.Text = "Income Satement Ordering";
            // 
            // txtIncomeStatementOrdering
            // 
            // 
            // 
            // 
            this.txtIncomeStatementOrdering.CustomButton.Image = null;
            this.txtIncomeStatementOrdering.CustomButton.Location = new System.Drawing.Point(89, 1);
            this.txtIncomeStatementOrdering.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIncomeStatementOrdering.CustomButton.Name = "";
            this.txtIncomeStatementOrdering.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtIncomeStatementOrdering.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtIncomeStatementOrdering.CustomButton.TabIndex = 1;
            this.txtIncomeStatementOrdering.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtIncomeStatementOrdering.CustomButton.UseSelectable = true;
            this.txtIncomeStatementOrdering.CustomButton.Visible = false;
            this.txtIncomeStatementOrdering.Lines = new string[0];
            this.txtIncomeStatementOrdering.Location = new System.Drawing.Point(797, 185);
            this.txtIncomeStatementOrdering.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIncomeStatementOrdering.MaxLength = 32767;
            this.txtIncomeStatementOrdering.Name = "txtIncomeStatementOrdering";
            this.txtIncomeStatementOrdering.PasswordChar = '\0';
            this.txtIncomeStatementOrdering.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtIncomeStatementOrdering.SelectedText = "";
            this.txtIncomeStatementOrdering.SelectionLength = 0;
            this.txtIncomeStatementOrdering.SelectionStart = 0;
            this.txtIncomeStatementOrdering.ShortcutsEnabled = true;
            this.txtIncomeStatementOrdering.Size = new System.Drawing.Size(123, 35);
            this.txtIncomeStatementOrdering.TabIndex = 23;
            this.txtIncomeStatementOrdering.UseSelectable = true;
            this.txtIncomeStatementOrdering.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtIncomeStatementOrdering.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // MasterfileChartOfAccountsManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(1174, 848);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.txtIncomeStatementOrdering);
            this.Controls.Add(this.btnAddNewCoaSub);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.txtIDCoaSub);
            this.Controls.Add(this.btnDeleteCoaSubsidiary);
            this.Controls.Add(this.btnSaveCoaSubsidiary);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.txtCoaSubName);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.txtCoaSubCode);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.btnDeleteCOA);
            this.Controls.Add(this.btnSaveCoa);
            this.Controls.Add(this.txtAccountingType);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.txtAccountingSide);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.cbCOAGroup);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtCoaCode);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MasterfileChartOfAccountsManage";
            this.Padding = new System.Windows.Forms.Padding(30, 92, 30, 31);
            this.Load += new System.EventHandler(this.MasterfileChartOfAccountsManage_Load);
            this.metroPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSubCoa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtCoaCode;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtDescription;
        private MetroFramework.Controls.MetroComboBox cbCOAGroup;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtAccountingSide;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox txtAccountingType;
        private MetroFramework.Controls.MetroButton btnSaveCoa;
        private MetroFramework.Controls.MetroButton btnDeleteCOA;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroGrid dtgSubCoa;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox txtCoaSubCode;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTextBox txtCoaSubName;
        private MetroFramework.Controls.MetroButton btnDeleteCoaSubsidiary;
        private MetroFramework.Controls.MetroButton btnSaveCoaSubsidiary;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIDCOA;
        private System.Windows.Forms.DataGridViewTextBoxColumn strCoaSubCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn strCoaSubName;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox txtIDCoaSub;
        private MetroFramework.Controls.MetroButton btnAddNewCoaSub;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroTextBox txtIncomeStatementOrdering;
    }
}
