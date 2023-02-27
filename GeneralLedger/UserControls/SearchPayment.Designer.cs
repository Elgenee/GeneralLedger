namespace GeneralLedger.UserControls
{
    partial class SearchPayment
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
            this.dgSearchPayment = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentCV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentSIDR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentTransactionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsCash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseTransactionNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PONo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseSIDR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankAccountId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GLTranHeaderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UseDefaultEntry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgSearchPayment)).BeginInit();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(489, 82);
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
            this.txtCriteria.Location = new System.Drawing.Point(214, 82);
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
            this.btnSelect.Location = new System.Drawing.Point(629, 82);
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
            this.metroLabel2.Location = new System.Drawing.Point(41, 82);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(53, 20);
            this.metroLabel2.TabIndex = 42;
            this.metroLabel2.Text = "Criteria";
            // 
            // dgSearchPayment
            // 
            this.dgSearchPayment.AllowUserToAddRows = false;
            this.dgSearchPayment.AllowUserToDeleteRows = false;
            this.dgSearchPayment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgSearchPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSearchPayment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.PaymentCV,
            this.PaymentSIDR,
            this.PaymentTransactionDate,
            this.PaymentTotalAmount,
            this.IsCash,
            this.PurchaseId,
            this.SupplierId,
            this.Supplier,
            this.PurchaseTransactionNo,
            this.PONo,
            this.PurchaseSIDR,
            this.PurchaseTotalAmount,
            this.BankAccountId,
            this.BankAccount,
            this.CheckDetails,
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
            this.dgSearchPayment.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgSearchPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSearchPayment.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgSearchPayment.Location = new System.Drawing.Point(0, 0);
            this.dgSearchPayment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgSearchPayment.Name = "dgSearchPayment";
            this.dgSearchPayment.ReadOnly = true;
            this.dgSearchPayment.RowHeadersWidth = 51;
            this.dgSearchPayment.RowTemplate.Height = 30;
            this.dgSearchPayment.Size = new System.Drawing.Size(1285, 478);
            this.dgSearchPayment.TabIndex = 66;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.dgSearchPayment);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 12;
            this.metroPanel1.Location = new System.Drawing.Point(32, 148);
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
            // PaymentCV
            // 
            this.PaymentCV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PaymentCV.HeaderText = "PaymentCV";
            this.PaymentCV.MinimumWidth = 6;
            this.PaymentCV.Name = "PaymentCV";
            this.PaymentCV.ReadOnly = true;
            this.PaymentCV.Width = 107;
            // 
            // PaymentSIDR
            // 
            this.PaymentSIDR.HeaderText = "PaymentSIDR";
            this.PaymentSIDR.MinimumWidth = 6;
            this.PaymentSIDR.Name = "PaymentSIDR";
            this.PaymentSIDR.ReadOnly = true;
            this.PaymentSIDR.Width = 125;
            // 
            // PaymentTransactionDate
            // 
            this.PaymentTransactionDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PaymentTransactionDate.HeaderText = "PaymentTransactionDate";
            this.PaymentTransactionDate.MinimumWidth = 6;
            this.PaymentTransactionDate.Name = "PaymentTransactionDate";
            this.PaymentTransactionDate.ReadOnly = true;
            this.PaymentTransactionDate.Width = 189;
            // 
            // PaymentTotalAmount
            // 
            this.PaymentTotalAmount.HeaderText = "PaymentTotalAmount";
            this.PaymentTotalAmount.MinimumWidth = 6;
            this.PaymentTotalAmount.Name = "PaymentTotalAmount";
            this.PaymentTotalAmount.ReadOnly = true;
            this.PaymentTotalAmount.Width = 125;
            // 
            // IsCash
            // 
            this.IsCash.HeaderText = "IsCash";
            this.IsCash.MinimumWidth = 6;
            this.IsCash.Name = "IsCash";
            this.IsCash.ReadOnly = true;
            this.IsCash.Width = 125;
            // 
            // PurchaseId
            // 
            this.PurchaseId.HeaderText = "PurchaseId";
            this.PurchaseId.MinimumWidth = 6;
            this.PurchaseId.Name = "PurchaseId";
            this.PurchaseId.ReadOnly = true;
            this.PurchaseId.Width = 125;
            // 
            // SupplierId
            // 
            this.SupplierId.HeaderText = "SupplierId";
            this.SupplierId.MinimumWidth = 6;
            this.SupplierId.Name = "SupplierId";
            this.SupplierId.ReadOnly = true;
            this.SupplierId.Width = 125;
            // 
            // Supplier
            // 
            this.Supplier.HeaderText = "Supplier";
            this.Supplier.MinimumWidth = 6;
            this.Supplier.Name = "Supplier";
            this.Supplier.ReadOnly = true;
            this.Supplier.Width = 125;
            // 
            // PurchaseTransactionNo
            // 
            this.PurchaseTransactionNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PurchaseTransactionNo.HeaderText = "PurchaseTransactionNo";
            this.PurchaseTransactionNo.MinimumWidth = 6;
            this.PurchaseTransactionNo.Name = "PurchaseTransactionNo";
            this.PurchaseTransactionNo.ReadOnly = true;
            this.PurchaseTransactionNo.Width = 182;
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
            // PurchaseSIDR
            // 
            this.PurchaseSIDR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PurchaseSIDR.HeaderText = "PurchaseSIDR";
            this.PurchaseSIDR.MinimumWidth = 6;
            this.PurchaseSIDR.Name = "PurchaseSIDR";
            this.PurchaseSIDR.ReadOnly = true;
            this.PurchaseSIDR.Width = 125;
            // 
            // PurchaseTotalAmount
            // 
            this.PurchaseTotalAmount.HeaderText = "PurchaseTotalAmount";
            this.PurchaseTotalAmount.MinimumWidth = 6;
            this.PurchaseTotalAmount.Name = "PurchaseTotalAmount";
            this.PurchaseTotalAmount.ReadOnly = true;
            this.PurchaseTotalAmount.Width = 125;
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
            // CheckDetails
            // 
            this.CheckDetails.HeaderText = "CheckDetails";
            this.CheckDetails.MinimumWidth = 6;
            this.CheckDetails.Name = "CheckDetails";
            this.CheckDetails.ReadOnly = true;
            this.CheckDetails.Width = 125;
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
            // SearchPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 655);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtCriteria);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroPanel1);
            this.Name = "SearchPayment";
            this.Text = "Search Payment";
            ((System.ComponentModel.ISupportInitialize)(this.dgSearchPayment)).EndInit();
            this.metroPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnSearch;
        private MetroFramework.Controls.MetroTextBox txtCriteria;
        private MetroFramework.Controls.MetroButton btnSelect;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgSearchPayment;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentCV;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentSIDR;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentTransactionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsCash;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseTransactionNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PONo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseSIDR;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankAccountId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn GLTranHeaderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UseDefaultEntry;
    }
}