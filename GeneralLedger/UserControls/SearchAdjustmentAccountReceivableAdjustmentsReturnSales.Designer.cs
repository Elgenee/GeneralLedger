namespace GeneralLedger.UserControls
{
    partial class SearchAdjustmentAccountReceivableAdjustmentsReturnSales
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
            this.dgSearchAccountReceivableAdjustments = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountsReceivableAdjustmentsTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountsReceivableAdjustmentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountsReceivableAdjustmentTransactionNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountsReceivableAdjustmentTransactionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesTransactionNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesPoNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GLTranHeaderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UseDefaultEntry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgSearchAccountReceivableAdjustments)).BeginInit();
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
            // dgSearchAccountReceivableAdjustments
            // 
            this.dgSearchAccountReceivableAdjustments.AllowUserToAddRows = false;
            this.dgSearchAccountReceivableAdjustments.AllowUserToDeleteRows = false;
            this.dgSearchAccountReceivableAdjustments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgSearchAccountReceivableAdjustments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSearchAccountReceivableAdjustments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.AccountsReceivableAdjustmentsTypeId,
            this.AccountsReceivableAdjustmentType,
            this.AccountsReceivableAdjustmentTransactionNo,
            this.AccountsReceivableAdjustmentTransactionDate,
            this.TotalAmount,
            this.SalesId,
            this.SalesTransactionNo,
            this.SalesPoNo,
            this.Customer,
            this.GLTranHeaderID,
            this.Description,
            this.UseDefaultEntry});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgSearchAccountReceivableAdjustments.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgSearchAccountReceivableAdjustments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSearchAccountReceivableAdjustments.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgSearchAccountReceivableAdjustments.Location = new System.Drawing.Point(0, 0);
            this.dgSearchAccountReceivableAdjustments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgSearchAccountReceivableAdjustments.Name = "dgSearchAccountReceivableAdjustments";
            this.dgSearchAccountReceivableAdjustments.ReadOnly = true;
            this.dgSearchAccountReceivableAdjustments.RowHeadersWidth = 51;
            this.dgSearchAccountReceivableAdjustments.RowTemplate.Height = 30;
            this.dgSearchAccountReceivableAdjustments.Size = new System.Drawing.Size(1285, 478);
            this.dgSearchAccountReceivableAdjustments.TabIndex = 66;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.dgSearchAccountReceivableAdjustments);
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
            // AccountsReceivableAdjustmentsTypeId
            // 
            this.AccountsReceivableAdjustmentsTypeId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AccountsReceivableAdjustmentsTypeId.HeaderText = "AdjustmentsTypeId";
            this.AccountsReceivableAdjustmentsTypeId.MinimumWidth = 6;
            this.AccountsReceivableAdjustmentsTypeId.Name = "AccountsReceivableAdjustmentsTypeId";
            this.AccountsReceivableAdjustmentsTypeId.ReadOnly = true;
            this.AccountsReceivableAdjustmentsTypeId.Width = 152;
            // 
            // AccountsReceivableAdjustmentType
            // 
            this.AccountsReceivableAdjustmentType.HeaderText = "AdjustmentType";
            this.AccountsReceivableAdjustmentType.MinimumWidth = 6;
            this.AccountsReceivableAdjustmentType.Name = "AccountsReceivableAdjustmentType";
            this.AccountsReceivableAdjustmentType.ReadOnly = true;
            this.AccountsReceivableAdjustmentType.Width = 125;
            // 
            // AccountsReceivableAdjustmentTransactionNo
            // 
            this.AccountsReceivableAdjustmentTransactionNo.HeaderText = "AdjustmentTransactionNo";
            this.AccountsReceivableAdjustmentTransactionNo.MinimumWidth = 6;
            this.AccountsReceivableAdjustmentTransactionNo.Name = "AccountsReceivableAdjustmentTransactionNo";
            this.AccountsReceivableAdjustmentTransactionNo.ReadOnly = true;
            this.AccountsReceivableAdjustmentTransactionNo.Width = 125;
            // 
            // AccountsReceivableAdjustmentTransactionDate
            // 
            this.AccountsReceivableAdjustmentTransactionDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AccountsReceivableAdjustmentTransactionDate.HeaderText = "AdjustmentTransactionDate";
            this.AccountsReceivableAdjustmentTransactionDate.MinimumWidth = 6;
            this.AccountsReceivableAdjustmentTransactionDate.Name = "AccountsReceivableAdjustmentTransactionDate";
            this.AccountsReceivableAdjustmentTransactionDate.ReadOnly = true;
            this.AccountsReceivableAdjustmentTransactionDate.Width = 202;
            // 
            // TotalAmount
            // 
            this.TotalAmount.HeaderText = "TotalAmount";
            this.TotalAmount.MinimumWidth = 6;
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.ReadOnly = true;
            this.TotalAmount.Width = 125;
            // 
            // SalesId
            // 
            this.SalesId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SalesId.HeaderText = "SalesId";
            this.SalesId.MinimumWidth = 6;
            this.SalesId.Name = "SalesId";
            this.SalesId.ReadOnly = true;
            this.SalesId.Width = 82;
            // 
            // SalesTransactionNo
            // 
            this.SalesTransactionNo.HeaderText = "SalesTransactionNo";
            this.SalesTransactionNo.MinimumWidth = 6;
            this.SalesTransactionNo.Name = "SalesTransactionNo";
            this.SalesTransactionNo.ReadOnly = true;
            this.SalesTransactionNo.Width = 125;
            // 
            // SalesPoNo
            // 
            this.SalesPoNo.HeaderText = "SalesPoNo";
            this.SalesPoNo.MinimumWidth = 6;
            this.SalesPoNo.Name = "SalesPoNo";
            this.SalesPoNo.ReadOnly = true;
            this.SalesPoNo.Width = 125;
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
            // SearchAdjustmentAccountReceivableAdjustmentsReturnSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 644);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtCriteria);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroPanel1);
            this.Name = "SearchAdjustmentAccountReceivableAdjustmentsReturnSales";
            this.Text = "Search Accounts Receivable Adjustments - Return Sales";
            ((System.ComponentModel.ISupportInitialize)(this.dgSearchAccountReceivableAdjustments)).EndInit();
            this.metroPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnSearch;
        private MetroFramework.Controls.MetroTextBox txtCriteria;
        private MetroFramework.Controls.MetroButton btnSelect;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgSearchAccountReceivableAdjustments;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountsReceivableAdjustmentsTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountsReceivableAdjustmentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountsReceivableAdjustmentTransactionNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountsReceivableAdjustmentTransactionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesTransactionNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesPoNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn GLTranHeaderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn UseDefaultEntry;
    }
}