namespace GeneralLedger.UserControls
{
    partial class SearchCollection
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
            this.dgSearchSale = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnSearch = new MetroFramework.Controls.MetroButton();
            this.txtCriteria = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.btnSelect = new MetroFramework.Controls.MetroButton();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleTransactionNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PONo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsCash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankAccountId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GLTranHeaderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UseDefaultEntry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSearchSale)).BeginInit();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.dgSearchSale);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 12;
            this.metroPanel1.Location = new System.Drawing.Point(39, 145);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1285, 478);
            this.metroPanel1.TabIndex = 35;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 13;
            // 
            // dgSearchSale
            // 
            this.dgSearchSale.AllowUserToAddRows = false;
            this.dgSearchSale.AllowUserToDeleteRows = false;
            this.dgSearchSale.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgSearchSale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSearchSale.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.TransactionNo,
            this.TransactionDate,
            this.SalesID,
            this.SaleTransactionNo,
            this.PONo,
            this.Customer,
            this.Total,
            this.IsCash,
            this.CheckDetail,
            this.BankAccountId,
            this.BankAccount,
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
            this.dgSearchSale.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgSearchSale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSearchSale.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgSearchSale.Location = new System.Drawing.Point(0, 0);
            this.dgSearchSale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgSearchSale.Name = "dgSearchSale";
            this.dgSearchSale.ReadOnly = true;
            this.dgSearchSale.RowHeadersWidth = 51;
            this.dgSearchSale.RowTemplate.Height = 30;
            this.dgSearchSale.Size = new System.Drawing.Size(1285, 478);
            this.dgSearchSale.TabIndex = 66;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(496, 79);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(132, 28);
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
            this.txtCriteria.CustomButton.Location = new System.Drawing.Point(241, 2);
            this.txtCriteria.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtCriteria.CustomButton.Name = "";
            this.txtCriteria.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtCriteria.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCriteria.CustomButton.TabIndex = 1;
            this.txtCriteria.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCriteria.CustomButton.UseSelectable = true;
            this.txtCriteria.CustomButton.Visible = false;
            this.txtCriteria.Lines = new string[0];
            this.txtCriteria.Location = new System.Drawing.Point(221, 79);
            this.txtCriteria.Margin = new System.Windows.Forms.Padding(4);
            this.txtCriteria.MaxLength = 32767;
            this.txtCriteria.Name = "txtCriteria";
            this.txtCriteria.PasswordChar = '\0';
            this.txtCriteria.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCriteria.SelectedText = "";
            this.txtCriteria.SelectionLength = 0;
            this.txtCriteria.SelectionStart = 0;
            this.txtCriteria.ShortcutsEnabled = true;
            this.txtCriteria.Size = new System.Drawing.Size(267, 28);
            this.txtCriteria.TabIndex = 36;
            this.txtCriteria.UseSelectable = true;
            this.txtCriteria.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCriteria.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(48, 79);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(53, 20);
            this.metroLabel2.TabIndex = 37;
            this.metroLabel2.Text = "Criteria";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(636, 79);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(132, 28);
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
            // TransactionNo
            // 
            this.TransactionNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TransactionNo.HeaderText = "TransactionNo";
            this.TransactionNo.MinimumWidth = 6;
            this.TransactionNo.Name = "TransactionNo";
            this.TransactionNo.ReadOnly = true;
            this.TransactionNo.Width = 125;
            // 
            // TransactionDate
            // 
            this.TransactionDate.HeaderText = "TransactionDate";
            this.TransactionDate.MinimumWidth = 6;
            this.TransactionDate.Name = "TransactionDate";
            this.TransactionDate.ReadOnly = true;
            this.TransactionDate.Width = 125;
            // 
            // SalesID
            // 
            this.SalesID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SalesID.HeaderText = "SalesID";
            this.SalesID.MinimumWidth = 6;
            this.SalesID.Name = "SalesID";
            this.SalesID.ReadOnly = true;
            this.SalesID.Width = 84;
            // 
            // SaleTransactionNo
            // 
            this.SaleTransactionNo.HeaderText = "SaleTransactionNo";
            this.SaleTransactionNo.MinimumWidth = 6;
            this.SaleTransactionNo.Name = "SaleTransactionNo";
            this.SaleTransactionNo.ReadOnly = true;
            this.SaleTransactionNo.Width = 125;
            // 
            // PONo
            // 
            this.PONo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PONo.HeaderText = "PONo";
            this.PONo.MinimumWidth = 6;
            this.PONo.Name = "PONo";
            this.PONo.ReadOnly = true;
            this.PONo.Width = 73;
            // 
            // Customer
            // 
            this.Customer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Customer.HeaderText = "Customer";
            this.Customer.MinimumWidth = 6;
            this.Customer.Name = "Customer";
            this.Customer.ReadOnly = true;
            this.Customer.Width = 93;
            // 
            // Total
            // 
            this.Total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Total.HeaderText = "Total";
            this.Total.MinimumWidth = 6;
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 67;
            // 
            // IsCash
            // 
            this.IsCash.HeaderText = "IsCash";
            this.IsCash.MinimumWidth = 6;
            this.IsCash.Name = "IsCash";
            this.IsCash.ReadOnly = true;
            this.IsCash.Width = 125;
            // 
            // CheckDetail
            // 
            this.CheckDetail.HeaderText = "CheckDetail";
            this.CheckDetail.MinimumWidth = 6;
            this.CheckDetail.Name = "CheckDetail";
            this.CheckDetail.ReadOnly = true;
            this.CheckDetail.Width = 125;
            // 
            // BankAccountId
            // 
            this.BankAccountId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.BankAccountId.HeaderText = "BankAccountId";
            this.BankAccountId.MinimumWidth = 6;
            this.BankAccountId.Name = "BankAccountId";
            this.BankAccountId.ReadOnly = true;
            this.BankAccountId.Width = 126;
            // 
            // BankAccount
            // 
            this.BankAccount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.BankAccount.HeaderText = "BankAccount";
            this.BankAccount.MinimumWidth = 6;
            this.BankAccount.Name = "BankAccount";
            this.BankAccount.ReadOnly = true;
            this.BankAccount.Width = 115;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Visible = false;
            this.Description.Width = 104;
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
            // SearchCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 645);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtCriteria);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.btnSelect);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SearchCollection";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Text = "Search Collection";
            this.metroPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSearchSale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgSearchSale;
        private MetroFramework.Controls.MetroButton btnSearch;
        private MetroFramework.Controls.MetroTextBox txtCriteria;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton btnSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleTransactionNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PONo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsCash;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankAccountId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn GLTranHeaderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UseDefaultEntry;
    }
}