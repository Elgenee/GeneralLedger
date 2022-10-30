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
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datBatchDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new MetroFramework.Controls.MetroButton();
            this.btnPostNew = new MetroFramework.Controls.MetroButton();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTrialBalanceData)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(18, 49);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(83, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Period From";
            // 
            // lblPeriodTo
            // 
            this.lblPeriodTo.AutoSize = true;
            this.lblPeriodTo.Location = new System.Drawing.Point(459, 49);
            this.lblPeriodTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPeriodTo.Name = "lblPeriodTo";
            this.lblPeriodTo.Size = new System.Drawing.Size(64, 19);
            this.lblPeriodTo.TabIndex = 3;
            this.lblPeriodTo.Text = "Period To";
            // 
            // dpPeriodFrom
            // 
            this.dpPeriodFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpPeriodFrom.Location = new System.Drawing.Point(152, 49);
            this.dpPeriodFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dpPeriodFrom.MinimumSize = new System.Drawing.Size(0, 29);
            this.dpPeriodFrom.Name = "dpPeriodFrom";
            this.dpPeriodFrom.Size = new System.Drawing.Size(298, 29);
            this.dpPeriodFrom.TabIndex = 5;
            // 
            // dpPeriodTo
            // 
            this.dpPeriodTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpPeriodTo.Location = new System.Drawing.Point(564, 49);
            this.dpPeriodTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dpPeriodTo.MinimumSize = new System.Drawing.Size(0, 29);
            this.dpPeriodTo.Name = "dpPeriodTo";
            this.dpPeriodTo.Size = new System.Drawing.Size(298, 29);
            this.dpPeriodTo.TabIndex = 6;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.dgTrialBalanceData);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 15;
            this.metroPanel1.Location = new System.Drawing.Point(21, 118);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1120, 605);
            this.metroPanel1.TabIndex = 7;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 15;
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
            this.Remarks});
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
            this.dgTrialBalanceData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.dgTrialBalanceData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgTrialBalanceData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTrialBalanceData.Size = new System.Drawing.Size(1120, 605);
            this.dgTrialBalanceData.TabIndex = 2;
            this.dgTrialBalanceData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTrialBalanceData_CellClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // datBatchDate
            // 
            this.datBatchDate.HeaderText = "datBatchDate";
            this.datBatchDate.Name = "datBatchDate";
            this.datBatchDate.ReadOnly = true;
            // 
            // Remarks
            // 
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(873, 49);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(148, 35);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseSelectable = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPostNew
            // 
            this.btnPostNew.Location = new System.Drawing.Point(1044, 49);
            this.btnPostNew.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPostNew.Name = "btnPostNew";
            this.btnPostNew.Size = new System.Drawing.Size(148, 35);
            this.btnPostNew.TabIndex = 19;
            this.btnPostNew.Text = "Post New";
            this.btnPostNew.UseSelectable = true;
            this.btnPostNew.Click += new System.EventHandler(this.btnPostNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
            this.btnClose.Image = global::GeneralLedger.Properties.Resources.cancel;
            this.btnClose.Location = new System.Drawing.Point(1287, 13);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(154, 55);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnClose.TabIndex = 40;
            this.btnClose.Text = "Close Page";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // TrialBalancePosting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPostNew);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.dpPeriodTo);
            this.Controls.Add(this.dpPeriodFrom);
            this.Controls.Add(this.lblPeriodTo);
            this.Controls.Add(this.metroLabel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TrialBalancePosting";
            this.Size = new System.Drawing.Size(1456, 788);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn datBatchDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private DevComponents.DotNetBar.ButtonX btnClose;
    }
}
