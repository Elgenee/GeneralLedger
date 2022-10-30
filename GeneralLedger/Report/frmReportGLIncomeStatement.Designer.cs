namespace GeneralLedger.Report
{
    partial class frmReportGLIncomeStatement
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rptISTotalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptISProvisionITBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptISNetIncomeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptISIncomeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptISExpensesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.dtBatchDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.rptISTotalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptISProvisionITBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptISNetIncomeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptISIncomeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptISExpensesBindingSource)).BeginInit();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rptISTotalBindingSource
            // 
            this.rptISTotalBindingSource.DataSource = typeof(GeneralLedger.Tier.BO.rptISTotal);
            // 
            // rptISProvisionITBindingSource
            // 
            this.rptISProvisionITBindingSource.DataSource = typeof(GeneralLedger.Tier.BO.rptISProvisionIT);
            // 
            // rptISNetIncomeBindingSource
            // 
            this.rptISNetIncomeBindingSource.DataSource = typeof(GeneralLedger.Tier.BO.rptISNetIncome);
            // 
            // rptISIncomeBindingSource
            // 
            this.rptISIncomeBindingSource.DataSource = typeof(GeneralLedger.Tier.BO.rptISIncome);
            // 
            // rptISExpensesBindingSource
            // 
            this.rptISExpensesBindingSource.DataSource = typeof(GeneralLedger.Tier.BO.rptISExpenses);
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.metroButton1);
            this.metroPanel1.Controls.Add(this.dtBatchDate);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 15;
            this.metroPanel1.Location = new System.Drawing.Point(30, 92);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1371, 57);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 15;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(543, 10);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(234, 35);
            this.metroButton1.TabIndex = 6;
            this.metroButton1.Text = "Preview";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // dtBatchDate
            // 
            this.dtBatchDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBatchDate.Location = new System.Drawing.Point(234, 10);
            this.dtBatchDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtBatchDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtBatchDate.Name = "dtBatchDate";
            this.dtBatchDate.Size = new System.Drawing.Size(298, 29);
            this.dtBatchDate.TabIndex = 5;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(57, 6);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(97, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "For the  Month";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsTotal";
            reportDataSource1.Value = this.rptISTotalBindingSource;
            reportDataSource2.Name = "dsISProvIT";
            reportDataSource2.Value = this.rptISProvisionITBindingSource;
            reportDataSource3.Name = "dsNetInc";
            reportDataSource3.Value = this.rptISNetIncomeBindingSource;
            reportDataSource4.Name = "dsIncome";
            reportDataSource4.Value = this.rptISIncomeBindingSource;
            reportDataSource5.Name = "dsExpense";
            reportDataSource5.Value = this.rptISExpensesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GeneralLedger.Report.RDLC.GLIncomeStatement.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(30, 149);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1371, 680);
            this.reportViewer1.TabIndex = 1;
            // 
            // frmReportGLIncomeStatement
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1431, 860);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.metroPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmReportGLIncomeStatement";
            this.Padding = new System.Windows.Forms.Padding(30, 92, 30, 31);
            this.Text = "GL Income Statement";
            this.Load += new System.EventHandler(this.frmReportGLIncomeStatement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rptISTotalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptISProvisionITBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptISNetIncomeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptISIncomeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptISExpensesBindingSource)).EndInit();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroDateTime dtBatchDate;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource rptISTotalBindingSource;
        private System.Windows.Forms.BindingSource rptISProvisionITBindingSource;
        private System.Windows.Forms.BindingSource rptISNetIncomeBindingSource;
        private System.Windows.Forms.BindingSource rptISIncomeBindingSource;
        private System.Windows.Forms.BindingSource rptISExpensesBindingSource;
    }
}