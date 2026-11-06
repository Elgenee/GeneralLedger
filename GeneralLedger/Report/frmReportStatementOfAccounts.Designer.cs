namespace GeneralLedger.Report
{
    partial class frmReportStatementOfAccounts
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.lblCustomer = new MetroFramework.Controls.MetroLabel();
            this.txtCustomerName = new MetroFramework.Controls.MetroTextBox();
            this.btnSearchCustomer = new MetroFramework.Controls.MetroButton();
            this.lblDateAsOf = new MetroFramework.Controls.MetroLabel();
            this.dtDateAsOf = new MetroFramework.Controls.MetroDateTime();
            this.btnPreview = new MetroFramework.Controls.MetroButton();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            //
            // metroPanel1
            //
            this.metroPanel1.Controls.Add(this.lblCustomer);
            this.metroPanel1.Controls.Add(this.txtCustomerName);
            this.metroPanel1.Controls.Add(this.btnSearchCustomer);
            this.metroPanel1.Controls.Add(this.lblDateAsOf);
            this.metroPanel1.Controls.Add(this.dtDateAsOf);
            this.metroPanel1.Controls.Add(this.btnPreview);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 12;
            this.metroPanel1.Location = new System.Drawing.Point(27, 74);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1074, 104);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 13;
            //
            // lblCustomer
            //
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(16, 16);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(69, 20);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Customer";
            //
            // txtCustomerName
            //
            this.txtCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerName.BackColor = System.Drawing.SystemColors.Control;
            this.txtCustomerName.CustomButton.Image = null;
            this.txtCustomerName.CustomButton.Location = new System.Drawing.Point(672, 2);
            this.txtCustomerName.CustomButton.Name = "";
            this.txtCustomerName.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtCustomerName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCustomerName.CustomButton.TabIndex = 1;
            this.txtCustomerName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCustomerName.CustomButton.UseSelectable = true;
            this.txtCustomerName.CustomButton.Visible = false;
            this.txtCustomerName.Lines = new string[0];
            this.txtCustomerName.Location = new System.Drawing.Point(120, 16);
            this.txtCustomerName.MaxLength = 32767;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.PasswordChar = '\0';
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCustomerName.SelectedText = "";
            this.txtCustomerName.SelectionLength = 0;
            this.txtCustomerName.SelectionStart = 0;
            this.txtCustomerName.ShortcutsEnabled = true;
            this.txtCustomerName.Size = new System.Drawing.Size(698, 28);
            this.txtCustomerName.TabIndex = 1;
            this.txtCustomerName.TabStop = false;
            this.txtCustomerName.UseCustomBackColor = true;
            this.txtCustomerName.UseSelectable = true;
            this.txtCustomerName.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
            this.txtCustomerName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            //
            // btnSearchCustomer
            //
            this.btnSearchCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchCustomer.Location = new System.Drawing.Point(834, 16);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(200, 28);
            this.btnSearchCustomer.TabIndex = 2;
            this.btnSearchCustomer.Text = "Search Customer";
            this.btnSearchCustomer.UseSelectable = true;
            this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);
            //
            // lblDateAsOf
            //
            this.lblDateAsOf.AutoSize = true;
            this.lblDateAsOf.Location = new System.Drawing.Point(16, 58);
            this.lblDateAsOf.Name = "lblDateAsOf";
            this.lblDateAsOf.Size = new System.Drawing.Size(75, 20);
            this.lblDateAsOf.TabIndex = 3;
            this.lblDateAsOf.Text = "Date As Of";
            //
            // dtDateAsOf
            //
            this.dtDateAsOf.CustomFormat = "MM/dd/yyyy";
            this.dtDateAsOf.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateAsOf.Location = new System.Drawing.Point(120, 56);
            this.dtDateAsOf.MinimumSize = new System.Drawing.Size(0, 30);
            this.dtDateAsOf.Name = "dtDateAsOf";
            this.dtDateAsOf.Size = new System.Drawing.Size(220, 30);
            this.dtDateAsOf.TabIndex = 4;
            //
            // btnPreview
            //
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(834, 56);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(200, 30);
            this.btnPreview.TabIndex = 5;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseSelectable = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            //
            // reportViewer1
            //
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GeneralLedger.Report.RDLC.rptReportStatementOfAccounts.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(27, 178);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1074, 473);
            this.reportViewer1.TabIndex = 1;
            //
            // frmReportStatementOfAccounts
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 676);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.metroPanel1);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "frmReportStatementOfAccounts";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Text = "Statement of Accounts";
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroLabel lblCustomer;
        private MetroFramework.Controls.MetroTextBox txtCustomerName;
        private MetroFramework.Controls.MetroButton btnSearchCustomer;
        private MetroFramework.Controls.MetroLabel lblDateAsOf;
        private MetroFramework.Controls.MetroDateTime dtDateAsOf;
        private MetroFramework.Controls.MetroButton btnPreview;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}
