namespace GeneralLedger.UserControls
{
    partial class SearchChartOfAccounts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.dgChartOfAccounts = new MetroFramework.Controls.MetroGrid();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strAcctSide = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strCOANameGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIDMasCOAGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strAcctType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearchChartOfAccounts = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnSearchChartOfAccounts = new MetroFramework.Controls.MetroButton();
            this.btnSearchChartOfAccountsSubsidiary = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.dgChartOfAccountsSubsidiary = new MetroFramework.Controls.MetroGrid();
            this.txtChartOfAccountsSubsidiaryDescription = new MetroFramework.Controls.MetroTextBox();
            this.txtChartOfAccountsDescription = new MetroFramework.Controls.MetroTextBox();
            this.txtChartOfAccountSubdiaryCode = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.txtChartOfAccountCode = new MetroFramework.Controls.MetroTextBox();
            this.btnSearchAddJournalEntry = new MetroFramework.Controls.MetroButton();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.txtDebit = new MetroFramework.Controls.MetroTextBox();
            this.txtCredit = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgChartOfAccounts)).BeginInit();
            this.metroPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgChartOfAccountsSubsidiary)).BeginInit();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.dgChartOfAccounts);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(10, 101);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(780, 222);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // dgChartOfAccounts
            // 
            this.dgChartOfAccounts.AllowUserToResizeRows = false;
            this.dgChartOfAccounts.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgChartOfAccounts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgChartOfAccounts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgChartOfAccounts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgChartOfAccounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgChartOfAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgChartOfAccounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.strCode,
            this.strName,
            this.strAcctSide,
            this.strCOANameGroup,
            this.intIDMasCOAGroup,
            this.strAcctType});
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgChartOfAccounts.DefaultCellStyle = dataGridViewCellStyle20;
            this.dgChartOfAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgChartOfAccounts.EnableHeadersVisualStyles = false;
            this.dgChartOfAccounts.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgChartOfAccounts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgChartOfAccounts.Location = new System.Drawing.Point(0, 0);
            this.dgChartOfAccounts.Name = "dgChartOfAccounts";
            this.dgChartOfAccounts.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgChartOfAccounts.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dgChartOfAccounts.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgChartOfAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgChartOfAccounts.Size = new System.Drawing.Size(780, 222);
            this.dgChartOfAccounts.TabIndex = 2;
            this.dgChartOfAccounts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgChartOfAccounts_CellClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // strCode
            // 
            this.strCode.HeaderText = "COA Code";
            this.strCode.Name = "strCode";
            this.strCode.ReadOnly = true;
            // 
            // strName
            // 
            this.strName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.strName.HeaderText = "Name";
            this.strName.Name = "strName";
            this.strName.ReadOnly = true;
            // 
            // strAcctSide
            // 
            this.strAcctSide.HeaderText = "Accounting Side";
            this.strAcctSide.Name = "strAcctSide";
            this.strAcctSide.ReadOnly = true;
            // 
            // strCOANameGroup
            // 
            this.strCOANameGroup.HeaderText = "COA Group";
            this.strCOANameGroup.Name = "strCOANameGroup";
            this.strCOANameGroup.ReadOnly = true;
            // 
            // intIDMasCOAGroup
            // 
            this.intIDMasCOAGroup.HeaderText = "intIDMasCOAGroup";
            this.intIDMasCOAGroup.Name = "intIDMasCOAGroup";
            this.intIDMasCOAGroup.ReadOnly = true;
            this.intIDMasCOAGroup.Visible = false;
            // 
            // strAcctType
            // 
            this.strAcctType.HeaderText = "Accounting Type";
            this.strAcctType.Name = "strAcctType";
            this.strAcctType.ReadOnly = true;
            // 
            // txtSearchChartOfAccounts
            // 
            // 
            // 
            // 
            this.txtSearchChartOfAccounts.CustomButton.Image = null;
            this.txtSearchChartOfAccounts.CustomButton.Location = new System.Drawing.Point(289, 1);
            this.txtSearchChartOfAccounts.CustomButton.Name = "";
            this.txtSearchChartOfAccounts.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtSearchChartOfAccounts.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSearchChartOfAccounts.CustomButton.TabIndex = 1;
            this.txtSearchChartOfAccounts.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSearchChartOfAccounts.CustomButton.UseSelectable = true;
            this.txtSearchChartOfAccounts.CustomButton.Visible = false;
            this.txtSearchChartOfAccounts.Lines = new string[0];
            this.txtSearchChartOfAccounts.Location = new System.Drawing.Point(204, 68);
            this.txtSearchChartOfAccounts.MaxLength = 32767;
            this.txtSearchChartOfAccounts.Name = "txtSearchChartOfAccounts";
            this.txtSearchChartOfAccounts.PasswordChar = '\0';
            this.txtSearchChartOfAccounts.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSearchChartOfAccounts.SelectedText = "";
            this.txtSearchChartOfAccounts.SelectionLength = 0;
            this.txtSearchChartOfAccounts.SelectionStart = 0;
            this.txtSearchChartOfAccounts.ShortcutsEnabled = true;
            this.txtSearchChartOfAccounts.Size = new System.Drawing.Size(311, 23);
            this.txtSearchChartOfAccounts.TabIndex = 1;
            this.txtSearchChartOfAccounts.UseSelectable = true;
            this.txtSearchChartOfAccounts.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSearchChartOfAccounts.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(15, 72);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(117, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Chart Of Accounts";
            // 
            // btnSearchChartOfAccounts
            // 
            this.btnSearchChartOfAccounts.Location = new System.Drawing.Point(530, 68);
            this.btnSearchChartOfAccounts.Name = "btnSearchChartOfAccounts";
            this.btnSearchChartOfAccounts.Size = new System.Drawing.Size(75, 23);
            this.btnSearchChartOfAccounts.TabIndex = 3;
            this.btnSearchChartOfAccounts.Text = "Search";
            this.btnSearchChartOfAccounts.UseSelectable = true;
            this.btnSearchChartOfAccounts.Click += new System.EventHandler(this.btnSearchChartOfAccounts_Click);
            // 
            // btnSearchChartOfAccountsSubsidiary
            // 
            this.btnSearchChartOfAccountsSubsidiary.Location = new System.Drawing.Point(530, 329);
            this.btnSearchChartOfAccountsSubsidiary.Name = "btnSearchChartOfAccountsSubsidiary";
            this.btnSearchChartOfAccountsSubsidiary.Size = new System.Drawing.Size(75, 23);
            this.btnSearchChartOfAccountsSubsidiary.TabIndex = 7;
            this.btnSearchChartOfAccountsSubsidiary.Text = "Search";
            this.btnSearchChartOfAccountsSubsidiary.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(15, 329);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(181, 19);
            this.metroLabel2.TabIndex = 6;
            this.metroLabel2.Text = "Chart Of Accounts Subsidiary";
            // 
            // metroTextBox1
            // 
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(289, 1);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.Lines = new string[0];
            this.metroTextBox1.Location = new System.Drawing.Point(204, 329);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = true;
            this.metroTextBox1.Size = new System.Drawing.Size(311, 23);
            this.metroTextBox1.TabIndex = 5;
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.dgChartOfAccountsSubsidiary);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(10, 358);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(780, 222);
            this.metroPanel2.TabIndex = 4;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // dgChartOfAccountsSubsidiary
            // 
            this.dgChartOfAccountsSubsidiary.AllowUserToResizeRows = false;
            this.dgChartOfAccountsSubsidiary.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgChartOfAccountsSubsidiary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgChartOfAccountsSubsidiary.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgChartOfAccountsSubsidiary.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgChartOfAccountsSubsidiary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgChartOfAccountsSubsidiary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgChartOfAccountsSubsidiary.DefaultCellStyle = dataGridViewCellStyle23;
            this.dgChartOfAccountsSubsidiary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgChartOfAccountsSubsidiary.EnableHeadersVisualStyles = false;
            this.dgChartOfAccountsSubsidiary.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgChartOfAccountsSubsidiary.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgChartOfAccountsSubsidiary.Location = new System.Drawing.Point(0, 0);
            this.dgChartOfAccountsSubsidiary.Name = "dgChartOfAccountsSubsidiary";
            this.dgChartOfAccountsSubsidiary.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgChartOfAccountsSubsidiary.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dgChartOfAccountsSubsidiary.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgChartOfAccountsSubsidiary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgChartOfAccountsSubsidiary.Size = new System.Drawing.Size(780, 222);
            this.dgChartOfAccountsSubsidiary.TabIndex = 2;
            this.dgChartOfAccountsSubsidiary.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgChartOfAccountsSubsidiary_CellClick);
            // 
            // txtChartOfAccountsSubsidiaryDescription
            // 
            // 
            // 
            // 
            this.txtChartOfAccountsSubsidiaryDescription.CustomButton.Image = null;
            this.txtChartOfAccountsSubsidiaryDescription.CustomButton.Location = new System.Drawing.Point(305, 1);
            this.txtChartOfAccountsSubsidiaryDescription.CustomButton.Name = "";
            this.txtChartOfAccountsSubsidiaryDescription.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtChartOfAccountsSubsidiaryDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtChartOfAccountsSubsidiaryDescription.CustomButton.TabIndex = 1;
            this.txtChartOfAccountsSubsidiaryDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtChartOfAccountsSubsidiaryDescription.CustomButton.UseSelectable = true;
            this.txtChartOfAccountsSubsidiaryDescription.CustomButton.Visible = false;
            this.txtChartOfAccountsSubsidiaryDescription.Lines = new string[0];
            this.txtChartOfAccountsSubsidiaryDescription.Location = new System.Drawing.Point(918, 187);
            this.txtChartOfAccountsSubsidiaryDescription.MaxLength = 32767;
            this.txtChartOfAccountsSubsidiaryDescription.Name = "txtChartOfAccountsSubsidiaryDescription";
            this.txtChartOfAccountsSubsidiaryDescription.PasswordChar = '\0';
            this.txtChartOfAccountsSubsidiaryDescription.ReadOnly = true;
            this.txtChartOfAccountsSubsidiaryDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtChartOfAccountsSubsidiaryDescription.SelectedText = "";
            this.txtChartOfAccountsSubsidiaryDescription.SelectionLength = 0;
            this.txtChartOfAccountsSubsidiaryDescription.SelectionStart = 0;
            this.txtChartOfAccountsSubsidiaryDescription.ShortcutsEnabled = true;
            this.txtChartOfAccountsSubsidiaryDescription.Size = new System.Drawing.Size(327, 23);
            this.txtChartOfAccountsSubsidiaryDescription.TabIndex = 15;
            this.txtChartOfAccountsSubsidiaryDescription.UseSelectable = true;
            this.txtChartOfAccountsSubsidiaryDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtChartOfAccountsSubsidiaryDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtChartOfAccountsDescription
            // 
            // 
            // 
            // 
            this.txtChartOfAccountsDescription.CustomButton.Image = null;
            this.txtChartOfAccountsDescription.CustomButton.Location = new System.Drawing.Point(305, 1);
            this.txtChartOfAccountsDescription.CustomButton.Name = "";
            this.txtChartOfAccountsDescription.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtChartOfAccountsDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtChartOfAccountsDescription.CustomButton.TabIndex = 1;
            this.txtChartOfAccountsDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtChartOfAccountsDescription.CustomButton.UseSelectable = true;
            this.txtChartOfAccountsDescription.CustomButton.Visible = false;
            this.txtChartOfAccountsDescription.Lines = new string[0];
            this.txtChartOfAccountsDescription.Location = new System.Drawing.Point(921, 132);
            this.txtChartOfAccountsDescription.MaxLength = 32767;
            this.txtChartOfAccountsDescription.Name = "txtChartOfAccountsDescription";
            this.txtChartOfAccountsDescription.PasswordChar = '\0';
            this.txtChartOfAccountsDescription.ReadOnly = true;
            this.txtChartOfAccountsDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtChartOfAccountsDescription.SelectedText = "";
            this.txtChartOfAccountsDescription.SelectionLength = 0;
            this.txtChartOfAccountsDescription.SelectionStart = 0;
            this.txtChartOfAccountsDescription.ShortcutsEnabled = true;
            this.txtChartOfAccountsDescription.Size = new System.Drawing.Size(327, 23);
            this.txtChartOfAccountsDescription.TabIndex = 14;
            this.txtChartOfAccountsDescription.UseSelectable = true;
            this.txtChartOfAccountsDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtChartOfAccountsDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtChartOfAccountsDescription.Click += new System.EventHandler(this.txtChartOfAccountsDescription_Click);
            // 
            // txtChartOfAccountSubdiaryCode
            // 
            // 
            // 
            // 
            this.txtChartOfAccountSubdiaryCode.CustomButton.Image = null;
            this.txtChartOfAccountSubdiaryCode.CustomButton.Location = new System.Drawing.Point(92, 1);
            this.txtChartOfAccountSubdiaryCode.CustomButton.Name = "";
            this.txtChartOfAccountSubdiaryCode.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtChartOfAccountSubdiaryCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtChartOfAccountSubdiaryCode.CustomButton.TabIndex = 1;
            this.txtChartOfAccountSubdiaryCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtChartOfAccountSubdiaryCode.CustomButton.UseSelectable = true;
            this.txtChartOfAccountSubdiaryCode.CustomButton.Visible = false;
            this.txtChartOfAccountSubdiaryCode.Lines = new string[0];
            this.txtChartOfAccountSubdiaryCode.Location = new System.Drawing.Point(801, 187);
            this.txtChartOfAccountSubdiaryCode.MaxLength = 32767;
            this.txtChartOfAccountSubdiaryCode.Name = "txtChartOfAccountSubdiaryCode";
            this.txtChartOfAccountSubdiaryCode.PasswordChar = '\0';
            this.txtChartOfAccountSubdiaryCode.ReadOnly = true;
            this.txtChartOfAccountSubdiaryCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtChartOfAccountSubdiaryCode.SelectedText = "";
            this.txtChartOfAccountSubdiaryCode.SelectionLength = 0;
            this.txtChartOfAccountSubdiaryCode.SelectionStart = 0;
            this.txtChartOfAccountSubdiaryCode.ShortcutsEnabled = true;
            this.txtChartOfAccountSubdiaryCode.Size = new System.Drawing.Size(114, 23);
            this.txtChartOfAccountSubdiaryCode.TabIndex = 13;
            this.txtChartOfAccountSubdiaryCode.UseSelectable = true;
            this.txtChartOfAccountSubdiaryCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtChartOfAccountSubdiaryCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(796, 163);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(176, 19);
            this.metroLabel6.TabIndex = 12;
            this.metroLabel6.Text = "Chart Of Account Subsidiary";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(796, 107);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(112, 19);
            this.metroLabel5.TabIndex = 11;
            this.metroLabel5.Text = "Chart Of Account";
            // 
            // txtChartOfAccountCode
            // 
            // 
            // 
            // 
            this.txtChartOfAccountCode.CustomButton.Image = null;
            this.txtChartOfAccountCode.CustomButton.Location = new System.Drawing.Point(92, 1);
            this.txtChartOfAccountCode.CustomButton.Name = "";
            this.txtChartOfAccountCode.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtChartOfAccountCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtChartOfAccountCode.CustomButton.TabIndex = 1;
            this.txtChartOfAccountCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtChartOfAccountCode.CustomButton.UseSelectable = true;
            this.txtChartOfAccountCode.CustomButton.Visible = false;
            this.txtChartOfAccountCode.Lines = new string[0];
            this.txtChartOfAccountCode.Location = new System.Drawing.Point(801, 132);
            this.txtChartOfAccountCode.MaxLength = 32767;
            this.txtChartOfAccountCode.Name = "txtChartOfAccountCode";
            this.txtChartOfAccountCode.PasswordChar = '\0';
            this.txtChartOfAccountCode.ReadOnly = true;
            this.txtChartOfAccountCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtChartOfAccountCode.SelectedText = "";
            this.txtChartOfAccountCode.SelectionLength = 0;
            this.txtChartOfAccountCode.SelectionStart = 0;
            this.txtChartOfAccountCode.ShortcutsEnabled = true;
            this.txtChartOfAccountCode.Size = new System.Drawing.Size(114, 23);
            this.txtChartOfAccountCode.TabIndex = 10;
            this.txtChartOfAccountCode.UseSelectable = true;
            this.txtChartOfAccountCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtChartOfAccountCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSearchAddJournalEntry
            // 
            this.btnSearchAddJournalEntry.Location = new System.Drawing.Point(960, 290);
            this.btnSearchAddJournalEntry.Name = "btnSearchAddJournalEntry";
            this.btnSearchAddJournalEntry.Size = new System.Drawing.Size(75, 23);
            this.btnSearchAddJournalEntry.TabIndex = 17;
            this.btnSearchAddJournalEntry.Text = "Add Entry";
            this.btnSearchAddJournalEntry.UseSelectable = true;
            this.btnSearchAddJournalEntry.Click += new System.EventHandler(this.btnSearchAddJournalEntry_Click);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(960, 221);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(45, 19);
            this.metroLabel8.TabIndex = 20;
            this.metroLabel8.Text = "Credit";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(801, 221);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(40, 19);
            this.metroLabel7.TabIndex = 19;
            this.metroLabel7.Text = "Debit";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(869, 290);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 22;
            this.btnClear.Text = "Clear Entry";
            this.btnClear.UseSelectable = true;
            this.btnClear.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // txtDebit
            // 
            // 
            // 
            // 
            this.txtDebit.CustomButton.Image = null;
            this.txtDebit.CustomButton.Location = new System.Drawing.Point(127, 1);
            this.txtDebit.CustomButton.Name = "";
            this.txtDebit.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtDebit.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDebit.CustomButton.TabIndex = 1;
            this.txtDebit.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDebit.CustomButton.UseSelectable = true;
            this.txtDebit.CustomButton.Visible = false;
            this.txtDebit.Lines = new string[0];
            this.txtDebit.Location = new System.Drawing.Point(801, 252);
            this.txtDebit.MaxLength = 32767;
            this.txtDebit.Name = "txtDebit";
            this.txtDebit.PasswordChar = '\0';
            this.txtDebit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDebit.SelectedText = "";
            this.txtDebit.SelectionLength = 0;
            this.txtDebit.SelectionStart = 0;
            this.txtDebit.ShortcutsEnabled = true;
            this.txtDebit.Size = new System.Drawing.Size(149, 23);
            this.txtDebit.TabIndex = 25;
            this.txtDebit.UseSelectable = true;
            this.txtDebit.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDebit.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtDebit.Leave += new System.EventHandler(this.txtDebit_Leave);
            // 
            // txtCredit
            // 
            // 
            // 
            // 
            this.txtCredit.CustomButton.Image = null;
            this.txtCredit.CustomButton.Location = new System.Drawing.Point(127, 1);
            this.txtCredit.CustomButton.Name = "";
            this.txtCredit.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCredit.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCredit.CustomButton.TabIndex = 1;
            this.txtCredit.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCredit.CustomButton.UseSelectable = true;
            this.txtCredit.CustomButton.Visible = false;
            this.txtCredit.Lines = new string[0];
            this.txtCredit.Location = new System.Drawing.Point(960, 252);
            this.txtCredit.MaxLength = 32767;
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.PasswordChar = '\0';
            this.txtCredit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCredit.SelectedText = "";
            this.txtCredit.SelectionLength = 0;
            this.txtCredit.SelectionStart = 0;
            this.txtCredit.ShortcutsEnabled = true;
            this.txtCredit.Size = new System.Drawing.Size(149, 23);
            this.txtCredit.TabIndex = 26;
            this.txtCredit.UseSelectable = true;
            this.txtCredit.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCredit.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtCredit.Leave += new System.EventHandler(this.txtCredit_Leave);
            // 
            // SearchChartOfAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 625);
            this.Controls.Add(this.txtCredit);
            this.Controls.Add(this.txtDebit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.btnSearchAddJournalEntry);
            this.Controls.Add(this.txtChartOfAccountsSubsidiaryDescription);
            this.Controls.Add(this.txtChartOfAccountsDescription);
            this.Controls.Add(this.txtChartOfAccountSubdiaryCode);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.txtChartOfAccountCode);
            this.Controls.Add(this.btnSearchChartOfAccountsSubsidiary);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroTextBox1);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.btnSearchChartOfAccounts);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtSearchChartOfAccounts);
            this.Controls.Add(this.metroPanel1);
            this.Name = "SearchChartOfAccounts";
            this.Text = "Search Chart Of Accounts";
            this.metroPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgChartOfAccounts)).EndInit();
            this.metroPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgChartOfAccountsSubsidiary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTextBox txtSearchChartOfAccounts;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton btnSearchChartOfAccounts;
        private MetroFramework.Controls.MetroGrid dgChartOfAccounts;
        private MetroFramework.Controls.MetroButton btnSearchChartOfAccountsSubsidiary;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroGrid dgChartOfAccountsSubsidiary;
        private MetroFramework.Controls.MetroTextBox txtChartOfAccountsSubsidiaryDescription;
        private MetroFramework.Controls.MetroTextBox txtChartOfAccountsDescription;
        private MetroFramework.Controls.MetroTextBox txtChartOfAccountSubdiaryCode;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox txtChartOfAccountCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn strCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn strName;
        private System.Windows.Forms.DataGridViewTextBoxColumn strAcctSide;
        private System.Windows.Forms.DataGridViewTextBoxColumn strCOANameGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIDMasCOAGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn strAcctType;
        private MetroFramework.Controls.MetroButton btnSearchAddJournalEntry;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroButton btnClear;
        private MetroFramework.Controls.MetroTextBox txtDebit;
        private MetroFramework.Controls.MetroTextBox txtCredit;
    }
}