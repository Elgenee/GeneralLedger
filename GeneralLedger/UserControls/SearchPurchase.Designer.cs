namespace GeneralLedger.UserControls
{
    partial class SearchPurchase
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
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.dgSearchPurchase = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnSearch = new MetroFramework.Controls.MetroButton();
            this.txtCriteria = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.btnSelect = new MetroFramework.Controls.MetroButton();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PONo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRANo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SIDR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Terms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdditionalDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GLTranHeaderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UseDefaultEntry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSearchPurchase)).BeginInit();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.dgSearchPurchase);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(29, 114);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(964, 388);
            this.metroPanel1.TabIndex = 35;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // dgSearchPurchase
            // 
            this.dgSearchPurchase.AllowUserToAddRows = false;
            this.dgSearchPurchase.AllowUserToDeleteRows = false;
            this.dgSearchPurchase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgSearchPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSearchPurchase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.PONo,
            this.TRANo,
            this.TransactionDate,
            this.SupplierID,
            this.Supplier,
            this.SIDR,
            this.Total,
            this.Terms,
            this.AdditionalDescription,
            this.Description,
            this.GLTranHeaderID,
            this.UseDefaultEntry});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgSearchPurchase.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgSearchPurchase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSearchPurchase.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgSearchPurchase.Location = new System.Drawing.Point(0, 0);
            this.dgSearchPurchase.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgSearchPurchase.Name = "dgSearchPurchase";
            this.dgSearchPurchase.ReadOnly = true;
            this.dgSearchPurchase.RowHeadersWidth = 51;
            this.dgSearchPurchase.RowTemplate.Height = 30;
            this.dgSearchPurchase.Size = new System.Drawing.Size(964, 388);
            this.dgSearchPurchase.TabIndex = 66;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(372, 60);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(99, 23);
            this.btnSearch.TabIndex = 38;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseSelectable = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCriteria
            // 
            // 
            // 
            // 
            this.txtCriteria.CustomButton.Image = null;
            this.txtCriteria.CustomButton.Location = new System.Drawing.Point(134, 1);
            this.txtCriteria.CustomButton.Name = "";
            this.txtCriteria.CustomButton.Size = new System.Drawing.Size(16, 17);
            this.txtCriteria.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCriteria.CustomButton.TabIndex = 1;
            this.txtCriteria.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCriteria.CustomButton.UseSelectable = true;
            this.txtCriteria.CustomButton.Visible = false;
            this.txtCriteria.Lines = new string[0];
            this.txtCriteria.Location = new System.Drawing.Point(166, 60);
            this.txtCriteria.MaxLength = 32767;
            this.txtCriteria.Name = "txtCriteria";
            this.txtCriteria.PasswordChar = '\0';
            this.txtCriteria.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCriteria.SelectedText = "";
            this.txtCriteria.SelectionLength = 0;
            this.txtCriteria.SelectionStart = 0;
            this.txtCriteria.ShortcutsEnabled = true;
            this.txtCriteria.Size = new System.Drawing.Size(200, 23);
            this.txtCriteria.TabIndex = 36;
            this.txtCriteria.UseSelectable = true;
            this.txtCriteria.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCriteria.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(36, 60);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(52, 19);
            this.metroLabel2.TabIndex = 37;
            this.metroLabel2.Text = "Criteria";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(477, 60);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(99, 23);
            this.btnSelect.TabIndex = 39;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseSelectable = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 62;
            // 
            // PONo
            // 
            this.PONo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PONo.HeaderText = "PONo";
            this.PONo.MinimumWidth = 6;
            this.PONo.Name = "PONo";
            this.PONo.ReadOnly = true;
            this.PONo.Width = 61;
            // 
            // TRANo
            // 
            this.TRANo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TRANo.HeaderText = "TRANo";
            this.TRANo.MinimumWidth = 6;
            this.TRANo.Name = "TRANo";
            this.TRANo.ReadOnly = true;
            this.TRANo.Width = 68;
            // 
            // TransactionDate
            // 
            this.TransactionDate.HeaderText = "TransactionDate";
            this.TransactionDate.MinimumWidth = 6;
            this.TransactionDate.Name = "TransactionDate";
            this.TransactionDate.ReadOnly = true;
            this.TransactionDate.Width = 125;
            // 
            // SupplierID
            // 
            this.SupplierID.HeaderText = "SupplierID";
            this.SupplierID.MinimumWidth = 6;
            this.SupplierID.Name = "SupplierID";
            this.SupplierID.ReadOnly = true;
            this.SupplierID.Width = 125;
            // 
            // Supplier
            // 
            this.Supplier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Supplier.HeaderText = "Supplier";
            this.Supplier.MinimumWidth = 6;
            this.Supplier.Name = "Supplier";
            this.Supplier.ReadOnly = true;
            this.Supplier.Width = 70;
            // 
            // SIDR
            // 
            this.SIDR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SIDR.HeaderText = "SIDR";
            this.SIDR.MinimumWidth = 6;
            this.SIDR.Name = "SIDR";
            this.SIDR.ReadOnly = true;
            this.SIDR.Width = 58;
            // 
            // Total
            // 
            this.Total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Total.HeaderText = "Total";
            this.Total.MinimumWidth = 6;
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 56;
            // 
            // Terms
            // 
            this.Terms.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Terms.HeaderText = "Terms";
            this.Terms.MinimumWidth = 6;
            this.Terms.Name = "Terms";
            this.Terms.ReadOnly = true;
            this.Terms.Width = 61;
            // 
            // AdditionalDescription
            // 
            this.AdditionalDescription.HeaderText = "AdditionalDescription";
            this.AdditionalDescription.Name = "AdditionalDescription";
            this.AdditionalDescription.ReadOnly = true;
            this.AdditionalDescription.Visible = false;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Visible = false;
            this.Description.Width = 85;
            // 
            // GLTranHeaderID
            // 
            this.GLTranHeaderID.HeaderText = "GLTranHeaderID";
            this.GLTranHeaderID.MinimumWidth = 6;
            this.GLTranHeaderID.Name = "GLTranHeaderID";
            this.GLTranHeaderID.ReadOnly = true;
            this.GLTranHeaderID.Visible = false;
            this.GLTranHeaderID.Width = 125;
            // 
            // UseDefaultEntry
            // 
            this.UseDefaultEntry.HeaderText = "UseDefaultEntry";
            this.UseDefaultEntry.MinimumWidth = 6;
            this.UseDefaultEntry.Name = "UseDefaultEntry";
            this.UseDefaultEntry.ReadOnly = true;
            this.UseDefaultEntry.Width = 125;
            // 
            // SearchPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 524);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtCriteria);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.btnSelect);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SearchPurchase";
            this.Padding = new System.Windows.Forms.Padding(15, 49, 15, 16);
            this.Text = "SearchPurchase";
            this.metroPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSearchPurchase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgSearchPurchase;
        private MetroFramework.Controls.MetroButton btnSearch;
        private MetroFramework.Controls.MetroTextBox txtCriteria;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton btnSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PONo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRANo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn SIDR;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Terms;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdditionalDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn GLTranHeaderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UseDefaultEntry;
    }
}