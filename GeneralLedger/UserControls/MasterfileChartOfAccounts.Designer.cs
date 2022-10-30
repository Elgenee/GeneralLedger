namespace GeneralLedger.UserControls
{
    partial class MasterfileChartOfAccounts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtSeacrh = new MetroFramework.Controls.MetroTextBox();
            this.Search = new MetroFramework.Controls.MetroLabel();
            this.btnSearch = new MetroFramework.Controls.MetroButton();
            this.btnCreateNew = new MetroFramework.Controls.MetroButton();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.dtgCoa = new MetroFramework.Controls.MetroGrid();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strAcctSide = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strCOANameGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIDMasCOAGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strAcctType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCoa)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSeacrh
            // 
            // 
            // 
            // 
            this.txtSeacrh.CustomButton.Image = null;
            this.txtSeacrh.CustomButton.Location = new System.Drawing.Point(462, 2);
            this.txtSeacrh.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSeacrh.CustomButton.Name = "";
            this.txtSeacrh.CustomButton.Size = new System.Drawing.Size(50, 51);
            this.txtSeacrh.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSeacrh.CustomButton.TabIndex = 1;
            this.txtSeacrh.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSeacrh.CustomButton.UseSelectable = true;
            this.txtSeacrh.CustomButton.Visible = false;
            this.txtSeacrh.Lines = new string[0];
            this.txtSeacrh.Location = new System.Drawing.Point(312, 9);
            this.txtSeacrh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSeacrh.MaxLength = 32767;
            this.txtSeacrh.Name = "txtSeacrh";
            this.txtSeacrh.PasswordChar = '\0';
            this.txtSeacrh.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSeacrh.SelectedText = "";
            this.txtSeacrh.SelectionLength = 0;
            this.txtSeacrh.SelectionStart = 0;
            this.txtSeacrh.ShortcutsEnabled = true;
            this.txtSeacrh.Size = new System.Drawing.Size(342, 35);
            this.txtSeacrh.TabIndex = 2;
            this.txtSeacrh.UseSelectable = true;
            this.txtSeacrh.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSeacrh.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Search
            // 
            this.Search.AutoSize = true;
            this.Search.Location = new System.Drawing.Point(182, 9);
            this.Search.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(48, 19);
            this.Search.TabIndex = 3;
            this.Search.Text = "Search";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(656, 9);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(148, 35);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseSelectable = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCreateNew
            // 
            this.btnCreateNew.Location = new System.Drawing.Point(810, 9);
            this.btnCreateNew.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCreateNew.Name = "btnCreateNew";
            this.btnCreateNew.Size = new System.Drawing.Size(148, 35);
            this.btnCreateNew.TabIndex = 5;
            this.btnCreateNew.Text = "Create New";
            this.btnCreateNew.UseSelectable = true;
            this.btnCreateNew.Click += new System.EventHandler(this.btnCreateNew_Click);
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.Silver;
            this.metroPanel1.Controls.Add(this.dtgCoa);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 15;
            this.metroPanel1.Location = new System.Drawing.Point(10, 54);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1580, 657);
            this.metroPanel1.TabIndex = 6;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 15;
            // 
            // dtgCoa
            // 
            this.dtgCoa.AllowUserToAddRows = false;
            this.dtgCoa.AllowUserToDeleteRows = false;
            this.dtgCoa.AllowUserToResizeRows = false;
            this.dtgCoa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgCoa.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgCoa.BackgroundColor = System.Drawing.Color.White;
            this.dtgCoa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgCoa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtgCoa.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCoa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgCoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCoa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.strCode,
            this.strName,
            this.strAcctSide,
            this.strCOANameGroup,
            this.intIDMasCOAGroup,
            this.strAcctType});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgCoa.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgCoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgCoa.EnableHeadersVisualStyles = false;
            this.dtgCoa.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dtgCoa.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtgCoa.Location = new System.Drawing.Point(0, 0);
            this.dtgCoa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtgCoa.Name = "dtgCoa";
            this.dtgCoa.ReadOnly = true;
            this.dtgCoa.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCoa.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgCoa.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dtgCoa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCoa.Size = new System.Drawing.Size(1580, 657);
            this.dtgCoa.TabIndex = 3;
            this.dtgCoa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCoa_CellContentClick_1);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 52;
            // 
            // strCode
            // 
            this.strCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.strCode.HeaderText = "Code";
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
            this.strAcctSide.Width = 115;
            // 
            // strCOANameGroup
            // 
            this.strCOANameGroup.HeaderText = "strCOANameGroup";
            this.strCOANameGroup.Name = "strCOANameGroup";
            this.strCOANameGroup.ReadOnly = true;
            this.strCOANameGroup.Width = 139;
            // 
            // intIDMasCOAGroup
            // 
            this.intIDMasCOAGroup.HeaderText = "intIDMasCOAGroup";
            this.intIDMasCOAGroup.Name = "intIDMasCOAGroup";
            this.intIDMasCOAGroup.ReadOnly = true;
            this.intIDMasCOAGroup.Width = 143;
            // 
            // strAcctType
            // 
            this.strAcctType.HeaderText = "Accounting Type";
            this.strAcctType.Name = "strAcctType";
            this.strAcctType.ReadOnly = true;
            this.strAcctType.Width = 115;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
            this.btnClose.Image = global::GeneralLedger.Properties.Resources.cancel;
            this.btnClose.Location = new System.Drawing.Point(1637, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(154, 55);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnClose.TabIndex = 41;
            this.btnClose.Text = "Close Page";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // MasterfileChartOfAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.btnCreateNew);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.txtSeacrh);
            this.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.Name = "MasterfileChartOfAccounts";
            this.Size = new System.Drawing.Size(1805, 735);
            this.Load += new System.EventHandler(this.MasterfileChartOfAccounts_Load);
            this.metroPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCoa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTextBox txtSeacrh;
        private MetroFramework.Controls.MetroLabel Search;
        private MetroFramework.Controls.MetroButton btnSearch;
        private MetroFramework.Controls.MetroButton btnCreateNew;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroGrid dtgCoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn strCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn strName;
        private System.Windows.Forms.DataGridViewTextBoxColumn strAcctSide;
        private System.Windows.Forms.DataGridViewTextBoxColumn strCOANameGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIDMasCOAGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn strAcctType;
        private DevComponents.DotNetBar.ButtonX btnClose;
    }
}
