namespace GeneralLedger.UserControls
{
    partial class TrialBalancePosting
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.lblPeriodTo = new MetroFramework.Controls.MetroLabel();
            this.dpPeriodFrom = new MetroFramework.Controls.MetroDateTime();
            this.dpPeriodTo = new MetroFramework.Controls.MetroDateTime();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.dgTrialBalanceData = new MetroFramework.Controls.MetroGrid();
            this.btnSearch = new MetroFramework.Controls.MetroButton();
            this.btnPostNew = new MetroFramework.Controls.MetroButton();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnLock = new MetroFramework.Controls.MetroButton();
            this.btnUnlock = new MetroFramework.Controls.MetroButton();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datBatchDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTrialBalanceData)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(16, 39);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(84, 20);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Period From";
            // 
            // lblPeriodTo
            // 
            this.lblPeriodTo.AutoSize = true;
            this.lblPeriodTo.Location = new System.Drawing.Point(408, 39);
            this.lblPeriodTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPeriodTo.Name = "lblPeriodTo";
            this.lblPeriodTo.Size = new System.Drawing.Size(66, 20);
            this.lblPeriodTo.TabIndex = 3;
            this.lblPeriodTo.Text = "Period To";
            // 
            // dpPeriodFrom
            // 
            this.dpPeriodFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpPeriodFrom.Location = new System.Drawing.Point(135, 39);
            this.dpPeriodFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dpPeriodFrom.MinimumSize = new System.Drawing.Size(0, 30);
            this.dpPeriodFrom.Name = "dpPeriodFrom";
            this.dpPeriodFrom.Size = new System.Drawing.Size(265, 30);
            this.dpPeriodFrom.TabIndex = 5;
            // 
            // dpPeriodTo
            // 
            this.dpPeriodTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpPeriodTo.Location = new System.Drawing.Point(501, 39);
            this.dpPeriodTo.Margin = new System.Windows.Forms.Padding(4);
            this.dpPeriodTo.MinimumSize = new System.Drawing.Size(0, 30);
            this.dpPeriodTo.Name = "dpPeriodTo";
            this.dpPeriodTo.Size = new System.Drawing.Size(265, 30);
            this.dpPeriodTo.TabIndex = 6;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.dgTrialBalanceData);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 12;
            this.metroPanel1.Location = new System.Drawing.Point(16, 140);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1158, 563);
            this.metroPanel1.TabIndex = 7;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 13;
            // 
            // dgTrialBalanceData
            // 
            this.dgTrialBalanceData.AllowUserToResizeRows = false;
            this.dgTrialBalanceData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgTrialBalanceData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgTrialBalanceData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgTrialBalanceData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTrialBalanceData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgTrialBalanceData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTrialBalanceData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.datBatchDate,
            this.Remarks,
            this.Lock});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgTrialBalanceData.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgTrialBalanceData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTrialBalanceData.EnableHeadersVisualStyles = false;
            this.dgTrialBalanceData.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgTrialBalanceData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgTrialBalanceData.Location = new System.Drawing.Point(0, 0);
            this.dgTrialBalanceData.Margin = new System.Windows.Forms.Padding(4);
            this.dgTrialBalanceData.Name = "dgTrialBalanceData";
            this.dgTrialBalanceData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTrialBalanceData.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgTrialBalanceData.RowHeadersWidth = 51;
            this.dgTrialBalanceData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgTrialBalanceData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTrialBalanceData.Size = new System.Drawing.Size(1158, 563);
            this.dgTrialBalanceData.TabIndex = 2;
            this.dgTrialBalanceData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTrialBalanceData_CellClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(776, 39);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(132, 28);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseSelectable = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPostNew
            // 
            this.btnPostNew.Location = new System.Drawing.Point(494, 92);
            this.btnPostNew.Margin = new System.Windows.Forms.Padding(4);
            this.btnPostNew.Name = "btnPostNew";
            this.btnPostNew.Size = new System.Drawing.Size(132, 28);
            this.btnPostNew.TabIndex = 19;
            this.btnPostNew.Text = "Post New";
            this.btnPostNew.UseSelectable = true;
            this.btnPostNew.Visible = false;
            this.btnPostNew.Click += new System.EventHandler(this.btnPostNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
            this.btnClose.Image = global::GeneralLedger.Properties.Resources.cancel;
            this.btnClose.Location = new System.Drawing.Point(1037, 15);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(137, 44);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnClose.TabIndex = 40;
            this.btnClose.Text = "Close Page";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // btnLock
            // 
            this.btnLock.Location = new System.Drawing.Point(634, 92);
            this.btnLock.Margin = new System.Windows.Forms.Padding(4);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(132, 28);
            this.btnLock.TabIndex = 41;
            this.btnLock.Text = "Lock";
            this.btnLock.UseSelectable = true;
            this.btnLock.Visible = false;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // btnUnlock
            // 
            this.btnUnlock.Location = new System.Drawing.Point(774, 92);
            this.btnUnlock.Margin = new System.Windows.Forms.Padding(4);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(132, 28);
            this.btnUnlock.TabIndex = 42;
            this.btnUnlock.Text = "Unlock";
            this.btnUnlock.UseSelectable = true;
            this.btnUnlock.Visible = false;
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Width = 125;
            // 
            // datBatchDate
            // 
            this.datBatchDate.HeaderText = "datBatchDate";
            this.datBatchDate.MinimumWidth = 6;
            this.datBatchDate.Name = "datBatchDate";
            this.datBatchDate.ReadOnly = true;
            this.datBatchDate.Width = 125;
            // 
            // Remarks
            // 
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.MinimumWidth = 6;
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            this.Remarks.Width = 125;
            // 
            // Lock
            // 
            this.Lock.HeaderText = "Lock";
            this.Lock.MinimumWidth = 6;
            this.Lock.Name = "Lock";
            this.Lock.Width = 125;
            // 
            // TrialBalancePosting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnUnlock);
            this.Controls.Add(this.btnLock);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPostNew);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.dpPeriodTo);
            this.Controls.Add(this.dpPeriodFrom);
            this.Controls.Add(this.lblPeriodTo);
            this.Controls.Add(this.metroLabel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TrialBalancePosting";
            this.Size = new System.Drawing.Size(1197, 738);
            this.Load += new System.EventHandler(this.TrialBalancePosting_Load);
            this.metroPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTrialBalanceData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel lblPeriodTo;
        private MetroFramework.Controls.MetroDateTime dpPeriodFrom;
        private MetroFramework.Controls.MetroDateTime dpPeriodTo;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroGrid dgTrialBalanceData;
        private MetroFramework.Controls.MetroButton btnSearch;
        private MetroFramework.Controls.MetroButton btnPostNew;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private MetroFramework.Controls.MetroButton btnLock;
        private MetroFramework.Controls.MetroButton btnUnlock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn datBatchDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lock;
    }
}
