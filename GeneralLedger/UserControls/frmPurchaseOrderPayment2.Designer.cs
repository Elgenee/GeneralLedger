namespace GeneralLedger.UserControls
{
    partial class frmPurchaseOrderPayment2
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.dtReceivedDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroDateTime1 = new MetroFramework.Controls.MetroDateTime();
            this.lblSubtotal = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.lblGrandtotal = new MetroFramework.Controls.MetroLabel();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.txtDiscountPercentage = new DevComponents.Editors.DoubleInput();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.txtDiscountAmount = new DevComponents.Editors.DoubleInput();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.lblChange = new MetroFramework.Controls.MetroLabel();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.chkAddBalanceToSupplier = new MetroFramework.Controls.MetroCheckBox();
            this.txtMemo = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(29, 51);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(38, 20);
            this.metroLabel1.TabIndex = 142;
            this.metroLabel1.Text = "Date";
            // 
            // dtReceivedDate
            // 
            this.dtReceivedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReceivedDate.Location = new System.Drawing.Point(214, 51);
            this.dtReceivedDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtReceivedDate.MinimumSize = new System.Drawing.Size(0, 30);
            this.dtReceivedDate.Name = "dtReceivedDate";
            this.dtReceivedDate.Size = new System.Drawing.Size(453, 30);
            this.dtReceivedDate.TabIndex = 141;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(29, 97);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(99, 20);
            this.metroLabel2.TabIndex = 144;
            this.metroLabel2.Text = "Date Received";
            // 
            // metroDateTime1
            // 
            this.metroDateTime1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.metroDateTime1.Location = new System.Drawing.Point(214, 97);
            this.metroDateTime1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.metroDateTime1.MinimumSize = new System.Drawing.Size(0, 30);
            this.metroDateTime1.Name = "metroDateTime1";
            this.metroDateTime1.Size = new System.Drawing.Size(453, 30);
            this.metroDateTime1.TabIndex = 143;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblSubtotal.Location = new System.Drawing.Point(214, 148);
            this.lblSubtotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(345, 38);
            this.lblSubtotal.TabIndex = 146;
            this.lblSubtotal.Text = "0.00";
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // metroLabel4
            // 
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(28, 158);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(83, 38);
            this.metroLabel4.TabIndex = 145;
            this.metroLabel4.Text = "Total Amount";
            // 
            // lblGrandtotal
            // 
            this.lblGrandtotal.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblGrandtotal.Location = new System.Drawing.Point(299, 302);
            this.lblGrandtotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGrandtotal.Name = "lblGrandtotal";
            this.lblGrandtotal.Size = new System.Drawing.Size(345, 38);
            this.lblGrandtotal.TabIndex = 155;
            this.lblGrandtotal.Text = "0.00";
            this.lblGrandtotal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // metroLabel11
            // 
            this.metroLabel11.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel11.Location = new System.Drawing.Point(29, 302);
            this.metroLabel11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(190, 38);
            this.metroLabel11.TabIndex = 154;
            this.metroLabel11.Text = "Grand Total";
            // 
            // metroLabel9
            // 
            this.metroLabel9.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel9.Location = new System.Drawing.Point(207, 250);
            this.metroLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(85, 38);
            this.metroLabel9.TabIndex = 153;
            this.metroLabel9.Text = "(%)";
            // 
            // txtDiscountPercentage
            // 
            // 
            // 
            // 
            this.txtDiscountPercentage.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtDiscountPercentage.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtDiscountPercentage.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtDiscountPercentage.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtDiscountPercentage.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtDiscountPercentage.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDiscountPercentage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDiscountPercentage.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDiscountPercentage.Increment = 1D;
            this.txtDiscountPercentage.Location = new System.Drawing.Point(299, 250);
            this.txtDiscountPercentage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiscountPercentage.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtDiscountPercentage.Name = "txtDiscountPercentage";
            this.txtDiscountPercentage.ShowUpDown = true;
            this.txtDiscountPercentage.Size = new System.Drawing.Size(345, 28);
            this.txtDiscountPercentage.TabIndex = 152;
            // 
            // metroLabel8
            // 
            this.metroLabel8.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel8.Location = new System.Drawing.Point(207, 204);
            this.metroLabel8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(85, 38);
            this.metroLabel8.TabIndex = 151;
            this.metroLabel8.Text = "(N/A)";
            // 
            // txtDiscountAmount
            // 
            // 
            // 
            // 
            this.txtDiscountAmount.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtDiscountAmount.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtDiscountAmount.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtDiscountAmount.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtDiscountAmount.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtDiscountAmount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDiscountAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDiscountAmount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDiscountAmount.Increment = 1D;
            this.txtDiscountAmount.Location = new System.Drawing.Point(299, 204);
            this.txtDiscountAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiscountAmount.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtDiscountAmount.Name = "txtDiscountAmount";
            this.txtDiscountAmount.ShowUpDown = true;
            this.txtDiscountAmount.Size = new System.Drawing.Size(345, 28);
            this.txtDiscountAmount.TabIndex = 150;
            // 
            // metroLabel7
            // 
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel7.Location = new System.Drawing.Point(29, 204);
            this.metroLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(190, 38);
            this.metroLabel7.TabIndex = 149;
            this.metroLabel7.Text = "Discount";
            // 
            // lblChange
            // 
            this.lblChange.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblChange.Location = new System.Drawing.Point(299, 339);
            this.lblChange.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(345, 38);
            this.lblChange.TabIndex = 157;
            this.lblChange.Text = "0.00";
            this.lblChange.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // metroLabel12
            // 
            this.metroLabel12.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel12.Location = new System.Drawing.Point(29, 339);
            this.metroLabel12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(190, 38);
            this.metroLabel12.TabIndex = 156;
            this.metroLabel12.Text = "Change";
            // 
            // chkAddBalanceToSupplier
            // 
            this.chkAddBalanceToSupplier.AutoSize = true;
            this.chkAddBalanceToSupplier.DisplayFocus = true;
            this.chkAddBalanceToSupplier.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkAddBalanceToSupplier.Location = new System.Drawing.Point(214, 394);
            this.chkAddBalanceToSupplier.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkAddBalanceToSupplier.Name = "chkAddBalanceToSupplier";
            this.chkAddBalanceToSupplier.Size = new System.Drawing.Size(186, 20);
            this.chkAddBalanceToSupplier.TabIndex = 158;
            this.chkAddBalanceToSupplier.Text = "Add Balance to Supplier";
            this.chkAddBalanceToSupplier.UseSelectable = true;
            this.chkAddBalanceToSupplier.Visible = false;
            // 
            // txtMemo
            // 
            // 
            // 
            // 
            this.txtMemo.CustomButton.Image = null;
            this.txtMemo.CustomButton.Location = new System.Drawing.Point(338, 1);
            this.txtMemo.CustomButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMemo.CustomButton.Name = "";
            this.txtMemo.CustomButton.Size = new System.Drawing.Size(63, 57);
            this.txtMemo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMemo.CustomButton.TabIndex = 1;
            this.txtMemo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMemo.CustomButton.UseSelectable = true;
            this.txtMemo.CustomButton.Visible = false;
            this.txtMemo.Lines = new string[0];
            this.txtMemo.Location = new System.Drawing.Point(214, 485);
            this.txtMemo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMemo.MaxLength = 32767;
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.PasswordChar = '\0';
            this.txtMemo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMemo.SelectedText = "";
            this.txtMemo.SelectionLength = 0;
            this.txtMemo.SelectionStart = 0;
            this.txtMemo.ShortcutsEnabled = true;
            this.txtMemo.Size = new System.Drawing.Size(452, 73);
            this.txtMemo.TabIndex = 160;
            this.txtMemo.UseSelectable = true;
            this.txtMemo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMemo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(29, 485);
            this.metroLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(49, 20);
            this.metroLabel6.TabIndex = 159;
            this.metroLabel6.Text = "Memo";
            // 
            // frmPurchaseOrderPayment2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.chkAddBalanceToSupplier);
            this.Controls.Add(this.lblChange);
            this.Controls.Add(this.metroLabel12);
            this.Controls.Add(this.lblGrandtotal);
            this.Controls.Add(this.metroLabel11);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.txtDiscountPercentage);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.txtDiscountAmount);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroDateTime1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.dtReceivedDate);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmPurchaseOrderPayment2";
            this.Size = new System.Drawing.Size(933, 757);
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroDateTime dtReceivedDate;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroDateTime metroDateTime1;
        private MetroFramework.Controls.MetroLabel lblSubtotal;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel lblGrandtotal;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private DevComponents.Editors.DoubleInput txtDiscountPercentage;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private DevComponents.Editors.DoubleInput txtDiscountAmount;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel lblChange;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroCheckBox chkAddBalanceToSupplier;
        private MetroFramework.Controls.MetroTextBox txtMemo;
        private MetroFramework.Controls.MetroLabel metroLabel6;
    }
}
