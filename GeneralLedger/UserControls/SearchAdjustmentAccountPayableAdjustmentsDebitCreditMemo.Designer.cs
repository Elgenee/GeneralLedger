namespace GeneralLedger.UserControls
{
    partial class SearchAdjustmentAccountPayableAdjustmentsDebitCreditMemo
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
            this.btnSearch = new MetroFramework.Controls.MetroButton();
            this.txtCriteria = new MetroFramework.Controls.MetroTextBox();
            this.btnSelect = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.dgSearchAccountsPayableAdjustments = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountsPayableAdjustmentsTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountsPayableAdjustmentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountsPayableAdjustmentTransactionNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountsPayableAdjustmentTransactionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GLTranHeaderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UseDefaultEntry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgSearchAccountsPayableAdjustments)).BeginInit();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(501, 75);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(132, 28);
            this.btnSearch.TabIndex = 43;
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
            this.txtCriteria.Location = new System.Drawing.Point(226, 75);
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
            this.txtCriteria.TabIndex = 41;
            this.txtCriteria.UseSelectable = true;
            this.txtCriteria.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCriteria.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(641, 75);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(132, 28);
            this.btnSelect.TabIndex = 44;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseSelectable = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(53, 75);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(53, 20);
            this.metroLabel2.TabIndex = 42;
            this.metroLabel2.Text = "Criteria";
            // 
            // dgSearchAccountsPayableAdjustments
            // 
            this.dgSearchAccountsPayableAdjustments.AllowUserToAddRows = false;
            this.dgSearchAccountsPayableAdjustments.AllowUserToDeleteRows = false;
            this.dgSearchAccountsPayableAdjustments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgSearchAccountsPayableAdjustments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSearchAccountsPayableAdjustments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.AccountsPayableAdjustmentsTypeId,
            this.AccountsPayableAdjustmentType,
            this.AccountsPayableAdjustmentTransactionNo,
            this.AccountsPayableAdjustmentTransactionDate,
            this.Supplier,
            this.SupplierId,
            this.GLTranHeaderID,
            this.Description,
            this.UseDefaultEntry,
            this.TotalAmount});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgSearchAccountsPayableAdjustments.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgSearchAccountsPayableAdjustments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSearchAccountsPayableAdjustments.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgSearchAccountsPayableAdjustments.Location = new System.Drawing.Point(0, 0);
            this.dgSearchAccountsPayableAdjustments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgSearchAccountsPayableAdjustments.Name = "dgSearchAccountsPayableAdjustments";
            this.dgSearchAccountsPayableAdjustments.ReadOnly = true;
            this.dgSearchAccountsPayableAdjustments.RowHeadersWidth = 51;
            this.dgSearchAccountsPayableAdjustments.RowTemplate.Height = 30;
            this.dgSearchAccountsPayableAdjustments.Size = new System.Drawing.Size(1285, 478);
            this.dgSearchAccountsPayableAdjustments.TabIndex = 66;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.dgSearchAccountsPayableAdjustments);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 12;
            this.metroPanel1.Location = new System.Drawing.Point(44, 141);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1285, 478);
            this.metroPanel1.TabIndex = 40;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 13;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 62;
            // 
            // AccountsPayableAdjustmentsTypeId
            // 
            this.AccountsPayableAdjustmentsTypeId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AccountsPayableAdjustmentsTypeId.HeaderText = "AdjustmentsTypeId";
            this.AccountsPayableAdjustmentsTypeId.MinimumWidth = 6;
            this.AccountsPayableAdjustmentsTypeId.Name = "AccountsPayableAdjustmentsTypeId";
            this.AccountsPayableAdjustmentsTypeId.ReadOnly = true;
            this.AccountsPayableAdjustmentsTypeId.Width = 152;
            // 
            // AccountsPayableAdjustmentType
            // 
            this.AccountsPayableAdjustmentType.HeaderText = "AdjustmentType";
            this.AccountsPayableAdjustmentType.MinimumWidth = 6;
            this.AccountsPayableAdjustmentType.Name = "AccountsPayableAdjustmentType";
            this.AccountsPayableAdjustmentType.ReadOnly = true;
            this.AccountsPayableAdjustmentType.Width = 125;
            // 
            // AccountsPayableAdjustmentTransactionNo
            // 
            this.AccountsPayableAdjustmentTransactionNo.HeaderText = "AdjustmentTransactionNo";
            this.AccountsPayableAdjustmentTransactionNo.MinimumWidth = 6;
            this.AccountsPayableAdjustmentTransactionNo.Name = "AccountsPayableAdjustmentTransactionNo";
            this.AccountsPayableAdjustmentTransactionNo.ReadOnly = true;
            this.AccountsPayableAdjustmentTransactionNo.Width = 125;
            // 
            // AccountsPayableAdjustmentTransactionDate
            // 
            this.AccountsPayableAdjustmentTransactionDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AccountsPayableAdjustmentTransactionDate.HeaderText = "AdjustmentTransactionDate";
            this.AccountsPayableAdjustmentTransactionDate.MinimumWidth = 6;
            this.AccountsPayableAdjustmentTransactionDate.Name = "AccountsPayableAdjustmentTransactionDate";
            this.AccountsPayableAdjustmentTransactionDate.ReadOnly = true;
            this.AccountsPayableAdjustmentTransactionDate.Width = 202;
            // 
            // Supplier
            // 
            this.Supplier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Supplier.HeaderText = "Supplier";
            this.Supplier.MinimumWidth = 6;
            this.Supplier.Name = "Supplier";
            this.Supplier.ReadOnly = true;
            this.Supplier.Width = 86;
            // 
            // SupplierId
            // 
            this.SupplierId.HeaderText = "SupplierId";
            this.SupplierId.MinimumWidth = 6;
            this.SupplierId.Name = "SupplierId";
            this.SupplierId.ReadOnly = true;
            this.SupplierId.Width = 125;
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
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 125;
            // 
            // UseDefaultEntry
            // 
            this.UseDefaultEntry.HeaderText = "UseDefaultEntry";
            this.UseDefaultEntry.MinimumWidth = 6;
            this.UseDefaultEntry.Name = "UseDefaultEntry";
            this.UseDefaultEntry.ReadOnly = true;
            this.UseDefaultEntry.Width = 125;
            // 
            // TotalAmount
            // 
            this.TotalAmount.HeaderText = "TotalAmount";
            this.TotalAmount.MinimumWidth = 6;
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.ReadOnly = true;
            this.TotalAmount.Width = 125;
            // 
            // SearchAdjustmentAccountPayableAdjustmentsDebitCreditMemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 644);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtCriteria);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroPanel1);
            this.Name = "SearchAdjustmentAccountPayableAdjustmentsDebitCreditMemo";
            this.Text = "Search Accounts Payable Adjustments - Debit Credit Memo";
            ((System.ComponentModel.ISupportInitialize)(this.dgSearchAccountsPayableAdjustments)).EndInit();
            this.metroPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnSearch;
        private MetroFramework.Controls.MetroTextBox txtCriteria;
        private MetroFramework.Controls.MetroButton btnSelect;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgSearchAccountsPayableAdjustments;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountsPayableAdjustmentsTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountsPayableAdjustmentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountsPayableAdjustmentTransactionNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountsPayableAdjustmentTransactionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierId;
        private System.Windows.Forms.DataGridViewTextBoxColumn GLTranHeaderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn UseDefaultEntry;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
    }
}