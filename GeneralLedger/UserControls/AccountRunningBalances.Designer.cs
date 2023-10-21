namespace GeneralLedger.UserControls
{
    partial class AccountRunningBalances
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.btnClose = new MetroFramework.Controls.MetroTile();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtStrCoaCode = new MetroFramework.Controls.MetroTextBox();
            this.txtStrCoa = new MetroFramework.Controls.MetroTextBox();
            this.txtStrCoaSub = new MetroFramework.Controls.MetroTextBox();
            this.txtStrCoaSubCode = new MetroFramework.Controls.MetroTextBox();
            this.btnSearch = new MetroFramework.Controls.MetroButton();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnPreview = new MetroFramework.Controls.MetroButton();
            this.dtDateTo = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.dtDateFrom = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.ActiveControl = null;
            this.btnClose.Location = new System.Drawing.Point(1228, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 43);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.UseSelectable = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(31, 19);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(90, 20);
            this.metroLabel3.TabIndex = 9;
            this.metroLabel3.Text = "Account Title";
            // 
            // txtStrCoaCode
            // 
            // 
            // 
            // 
            this.txtStrCoaCode.CustomButton.Image = null;
            this.txtStrCoaCode.CustomButton.Location = new System.Drawing.Point(194, 2);
            this.txtStrCoaCode.CustomButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStrCoaCode.CustomButton.Name = "";
            this.txtStrCoaCode.CustomButton.Size = new System.Drawing.Size(20, 18);
            this.txtStrCoaCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtStrCoaCode.CustomButton.TabIndex = 1;
            this.txtStrCoaCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtStrCoaCode.CustomButton.UseSelectable = true;
            this.txtStrCoaCode.CustomButton.Visible = false;
            this.txtStrCoaCode.Enabled = false;
            this.txtStrCoaCode.Lines = new string[0];
            this.txtStrCoaCode.Location = new System.Drawing.Point(179, 19);
            this.txtStrCoaCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStrCoaCode.MaxLength = 32767;
            this.txtStrCoaCode.Name = "txtStrCoaCode";
            this.txtStrCoaCode.PasswordChar = '\0';
            this.txtStrCoaCode.ReadOnly = true;
            this.txtStrCoaCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtStrCoaCode.SelectedText = "";
            this.txtStrCoaCode.SelectionLength = 0;
            this.txtStrCoaCode.SelectionStart = 0;
            this.txtStrCoaCode.ShortcutsEnabled = true;
            this.txtStrCoaCode.Size = new System.Drawing.Size(244, 28);
            this.txtStrCoaCode.TabIndex = 8;
            this.txtStrCoaCode.UseSelectable = true;
            this.txtStrCoaCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtStrCoaCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtStrCoa
            // 
            // 
            // 
            // 
            this.txtStrCoa.CustomButton.Image = null;
            this.txtStrCoa.CustomButton.Location = new System.Drawing.Point(292, 2);
            this.txtStrCoa.CustomButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStrCoa.CustomButton.Name = "";
            this.txtStrCoa.CustomButton.Size = new System.Drawing.Size(20, 18);
            this.txtStrCoa.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtStrCoa.CustomButton.TabIndex = 1;
            this.txtStrCoa.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtStrCoa.CustomButton.UseSelectable = true;
            this.txtStrCoa.CustomButton.Visible = false;
            this.txtStrCoa.Enabled = false;
            this.txtStrCoa.Lines = new string[0];
            this.txtStrCoa.Location = new System.Drawing.Point(428, 19);
            this.txtStrCoa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStrCoa.MaxLength = 32767;
            this.txtStrCoa.Name = "txtStrCoa";
            this.txtStrCoa.PasswordChar = '\0';
            this.txtStrCoa.ReadOnly = true;
            this.txtStrCoa.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtStrCoa.SelectedText = "";
            this.txtStrCoa.SelectionLength = 0;
            this.txtStrCoa.SelectionStart = 0;
            this.txtStrCoa.ShortcutsEnabled = true;
            this.txtStrCoa.Size = new System.Drawing.Size(355, 28);
            this.txtStrCoa.TabIndex = 10;
            this.txtStrCoa.UseSelectable = true;
            this.txtStrCoa.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtStrCoa.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtStrCoaSub
            // 
            // 
            // 
            // 
            this.txtStrCoaSub.CustomButton.Image = null;
            this.txtStrCoaSub.CustomButton.Location = new System.Drawing.Point(292, 2);
            this.txtStrCoaSub.CustomButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStrCoaSub.CustomButton.Name = "";
            this.txtStrCoaSub.CustomButton.Size = new System.Drawing.Size(20, 18);
            this.txtStrCoaSub.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtStrCoaSub.CustomButton.TabIndex = 1;
            this.txtStrCoaSub.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtStrCoaSub.CustomButton.UseSelectable = true;
            this.txtStrCoaSub.CustomButton.Visible = false;
            this.txtStrCoaSub.Enabled = false;
            this.txtStrCoaSub.Lines = new string[0];
            this.txtStrCoaSub.Location = new System.Drawing.Point(428, 55);
            this.txtStrCoaSub.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStrCoaSub.MaxLength = 32767;
            this.txtStrCoaSub.Name = "txtStrCoaSub";
            this.txtStrCoaSub.PasswordChar = '\0';
            this.txtStrCoaSub.ReadOnly = true;
            this.txtStrCoaSub.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtStrCoaSub.SelectedText = "";
            this.txtStrCoaSub.SelectionLength = 0;
            this.txtStrCoaSub.SelectionStart = 0;
            this.txtStrCoaSub.ShortcutsEnabled = true;
            this.txtStrCoaSub.Size = new System.Drawing.Size(355, 28);
            this.txtStrCoaSub.TabIndex = 12;
            this.txtStrCoaSub.UseSelectable = true;
            this.txtStrCoaSub.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtStrCoaSub.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtStrCoaSubCode
            // 
            // 
            // 
            // 
            this.txtStrCoaSubCode.CustomButton.Image = null;
            this.txtStrCoaSubCode.CustomButton.Location = new System.Drawing.Point(194, 2);
            this.txtStrCoaSubCode.CustomButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStrCoaSubCode.CustomButton.Name = "";
            this.txtStrCoaSubCode.CustomButton.Size = new System.Drawing.Size(20, 18);
            this.txtStrCoaSubCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtStrCoaSubCode.CustomButton.TabIndex = 1;
            this.txtStrCoaSubCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtStrCoaSubCode.CustomButton.UseSelectable = true;
            this.txtStrCoaSubCode.CustomButton.Visible = false;
            this.txtStrCoaSubCode.Enabled = false;
            this.txtStrCoaSubCode.Lines = new string[0];
            this.txtStrCoaSubCode.Location = new System.Drawing.Point(179, 55);
            this.txtStrCoaSubCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStrCoaSubCode.MaxLength = 32767;
            this.txtStrCoaSubCode.Name = "txtStrCoaSubCode";
            this.txtStrCoaSubCode.PasswordChar = '\0';
            this.txtStrCoaSubCode.ReadOnly = true;
            this.txtStrCoaSubCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtStrCoaSubCode.SelectedText = "";
            this.txtStrCoaSubCode.SelectionLength = 0;
            this.txtStrCoaSubCode.SelectionStart = 0;
            this.txtStrCoaSubCode.ShortcutsEnabled = true;
            this.txtStrCoaSubCode.Size = new System.Drawing.Size(244, 28);
            this.txtStrCoaSubCode.TabIndex = 11;
            this.txtStrCoaSubCode.UseSelectable = true;
            this.txtStrCoaSubCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtStrCoaSubCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(790, 19);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(132, 28);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseSelectable = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "dsTotal";
            reportDataSource1.Value = null;
            reportDataSource2.Name = "dsISProvIT";
            reportDataSource2.Value = null;
            reportDataSource3.Name = "dsNetInc";
            reportDataSource3.Value = null;
            reportDataSource4.Name = "dsIncome";
            reportDataSource4.Value = null;
            reportDataSource5.Name = "dsExpense";
            reportDataSource5.Value = null;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GeneralLedger.Report.RDLC.GLIncomeStatement.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(4, 137);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1454, 625);
            this.reportViewer1.TabIndex = 20;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(929, 19);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(208, 28);
            this.btnPreview.TabIndex = 21;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseSelectable = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // dtDateTo
            // 
            this.dtDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateTo.Location = new System.Drawing.Point(503, 91);
            this.dtDateTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtDateTo.MinimumSize = new System.Drawing.Size(0, 30);
            this.dtDateTo.Name = "dtDateTo";
            this.dtDateTo.Size = new System.Drawing.Size(280, 30);
            this.dtDateTo.TabIndex = 25;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(432, 91);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(56, 20);
            this.metroLabel2.TabIndex = 24;
            this.metroLabel2.Text = "Date To";
            // 
            // dtDateFrom
            // 
            this.dtDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateFrom.Location = new System.Drawing.Point(179, 91);
            this.dtDateFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtDateFrom.MinimumSize = new System.Drawing.Size(0, 30);
            this.dtDateFrom.Name = "dtDateFrom";
            this.dtDateFrom.Size = new System.Drawing.Size(244, 30);
            this.dtDateFrom.TabIndex = 23;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(31, 91);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(74, 20);
            this.metroLabel1.TabIndex = 22;
            this.metroLabel1.Text = "Date From";
            // 
            // AccountRunningBalances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtDateTo);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.dtDateFrom);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtStrCoaSub);
            this.Controls.Add(this.txtStrCoaSubCode);
            this.Controls.Add(this.txtStrCoa);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.txtStrCoaCode);
            this.Controls.Add(this.btnClose);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AccountRunningBalances";
            this.Size = new System.Drawing.Size(1461, 766);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile btnClose;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtStrCoaCode;
        private MetroFramework.Controls.MetroTextBox txtStrCoa;
        private MetroFramework.Controls.MetroTextBox txtStrCoaSub;
        private MetroFramework.Controls.MetroTextBox txtStrCoaSubCode;
        private MetroFramework.Controls.MetroButton btnSearch;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private MetroFramework.Controls.MetroButton btnPreview;
        private MetroFramework.Controls.MetroDateTime dtDateTo;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroDateTime dtDateFrom;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}
