namespace GeneralLedger.UserControls
{
    partial class frmAgent
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
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtCustomerName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.txtID = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtContact = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel17 = new MetroFramework.Controls.MetroLabel();
            this.txtStartingDebit = new DevComponents.Editors.DoubleInput();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtAddress = new MetroFramework.Controls.MetroTextBox();
            this.btnFind = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.btnDelete = new MetroFramework.Controls.MetroButton();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartingDebit)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
            this.btnClose.Image = global::GeneralLedger.Properties.Resources.cancel;
            this.btnClose.Location = new System.Drawing.Point(618, 37);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 36);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnClose.TabIndex = 94;
            this.btnClose.Text = "Close Page";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(14, 72);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(45, 19);
            this.metroLabel1.TabIndex = 93;
            this.metroLabel1.Text = "Name";
            // 
            // txtCustomerName
            // 
            // 
            // 
            // 
            this.txtCustomerName.CustomButton.Image = null;
            this.txtCustomerName.CustomButton.Location = new System.Drawing.Point(367, 1);
            this.txtCustomerName.CustomButton.Name = "";
            this.txtCustomerName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCustomerName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCustomerName.CustomButton.TabIndex = 1;
            this.txtCustomerName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCustomerName.CustomButton.UseSelectable = true;
            this.txtCustomerName.CustomButton.Visible = false;
            this.txtCustomerName.Lines = new string[0];
            this.txtCustomerName.Location = new System.Drawing.Point(161, 72);
            this.txtCustomerName.MaxLength = 32767;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.PasswordChar = '\0';
            this.txtCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCustomerName.SelectedText = "";
            this.txtCustomerName.SelectionLength = 0;
            this.txtCustomerName.SelectionStart = 0;
            this.txtCustomerName.ShortcutsEnabled = true;
            this.txtCustomerName.Size = new System.Drawing.Size(389, 23);
            this.txtCustomerName.TabIndex = 92;
            this.txtCustomerName.UseSelectable = true;
            this.txtCustomerName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCustomerName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.Location = new System.Drawing.Point(14, 37);
            this.metroLabel12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(60, 19);
            this.metroLabel12.TabIndex = 91;
            this.metroLabel12.Text = "Agent ID";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.ControlLight;
            // 
            // 
            // 
            this.txtID.CustomButton.Image = null;
            this.txtID.CustomButton.Location = new System.Drawing.Point(367, 1);
            this.txtID.CustomButton.Name = "";
            this.txtID.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtID.CustomButton.TabIndex = 1;
            this.txtID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtID.CustomButton.UseSelectable = true;
            this.txtID.CustomButton.Visible = false;
            this.txtID.Enabled = false;
            this.txtID.Lines = new string[0];
            this.txtID.Location = new System.Drawing.Point(161, 37);
            this.txtID.MaxLength = 32767;
            this.txtID.Name = "txtID";
            this.txtID.PasswordChar = '\0';
            this.txtID.ReadOnly = true;
            this.txtID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtID.SelectedText = "";
            this.txtID.SelectionLength = 0;
            this.txtID.SelectionStart = 0;
            this.txtID.ShortcutsEnabled = true;
            this.txtID.Size = new System.Drawing.Size(389, 23);
            this.txtID.TabIndex = 90;
            this.txtID.UseCustomBackColor = true;
            this.txtID.UseSelectable = true;
            this.txtID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(14, 147);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(54, 19);
            this.metroLabel3.TabIndex = 96;
            this.metroLabel3.Text = "Contact";
            // 
            // txtContact
            // 
            // 
            // 
            // 
            this.txtContact.CustomButton.Image = null;
            this.txtContact.CustomButton.Location = new System.Drawing.Point(237, 1);
            this.txtContact.CustomButton.Name = "";
            this.txtContact.CustomButton.Size = new System.Drawing.Size(151, 151);
            this.txtContact.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtContact.CustomButton.TabIndex = 1;
            this.txtContact.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtContact.CustomButton.UseSelectable = true;
            this.txtContact.CustomButton.Visible = false;
            this.txtContact.Lines = new string[0];
            this.txtContact.Location = new System.Drawing.Point(161, 147);
            this.txtContact.MaxLength = 32767;
            this.txtContact.Multiline = true;
            this.txtContact.Name = "txtContact";
            this.txtContact.PasswordChar = '\0';
            this.txtContact.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtContact.SelectedText = "";
            this.txtContact.SelectionLength = 0;
            this.txtContact.SelectionStart = 0;
            this.txtContact.ShortcutsEnabled = true;
            this.txtContact.Size = new System.Drawing.Size(389, 153);
            this.txtContact.TabIndex = 95;
            this.txtContact.UseSelectable = true;
            this.txtContact.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtContact.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel17
            // 
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.Location = new System.Drawing.Point(14, 109);
            this.metroLabel17.Name = "metroLabel17";
            this.metroLabel17.Size = new System.Drawing.Size(90, 19);
            this.metroLabel17.TabIndex = 98;
            this.metroLabel17.Text = "Starting Debit";
            // 
            // txtStartingDebit
            // 
            // 
            // 
            // 
            this.txtStartingDebit.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtStartingDebit.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtStartingDebit.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtStartingDebit.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtStartingDebit.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtStartingDebit.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtStartingDebit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtStartingDebit.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtStartingDebit.Increment = 1D;
            this.txtStartingDebit.Location = new System.Drawing.Point(161, 109);
            this.txtStartingDebit.Margin = new System.Windows.Forms.Padding(2);
            this.txtStartingDebit.MinimumSize = new System.Drawing.Size(0, 23);
            this.txtStartingDebit.Name = "txtStartingDebit";
            this.txtStartingDebit.ShowUpDown = true;
            this.txtStartingDebit.Size = new System.Drawing.Size(389, 23);
            this.txtStartingDebit.TabIndex = 97;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(14, 317);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(56, 19);
            this.metroLabel4.TabIndex = 100;
            this.metroLabel4.Text = "Address";
            // 
            // txtAddress
            // 
            // 
            // 
            // 
            this.txtAddress.CustomButton.Image = null;
            this.txtAddress.CustomButton.Location = new System.Drawing.Point(237, 1);
            this.txtAddress.CustomButton.Name = "";
            this.txtAddress.CustomButton.Size = new System.Drawing.Size(151, 151);
            this.txtAddress.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAddress.CustomButton.TabIndex = 1;
            this.txtAddress.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAddress.CustomButton.UseSelectable = true;
            this.txtAddress.CustomButton.Visible = false;
            this.txtAddress.Lines = new string[0];
            this.txtAddress.Location = new System.Drawing.Point(161, 317);
            this.txtAddress.MaxLength = 32767;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PasswordChar = '\0';
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAddress.SelectedText = "";
            this.txtAddress.SelectionLength = 0;
            this.txtAddress.SelectionStart = 0;
            this.txtAddress.ShortcutsEnabled = true;
            this.txtAddress.Size = new System.Drawing.Size(389, 153);
            this.txtAddress.TabIndex = 99;
            this.txtAddress.UseSelectable = true;
            this.txtAddress.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAddress.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(508, 504);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(99, 23);
            this.btnFind.TabIndex = 104;
            this.btnFind.Text = "Find";
            this.btnFind.UseSelectable = true;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(198, 504);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(99, 23);
            this.metroButton1.TabIndex = 103;
            this.metroButton1.Text = "Add";
            this.metroButton1.UseSelectable = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(404, 504);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 23);
            this.btnDelete.TabIndex = 102;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseSelectable = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(301, 504);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 23);
            this.btnSave.TabIndex = 101;
            this.btnSave.Text = "Save";
            this.btnSave.UseSelectable = true;
            // 
            // frmAgent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.metroLabel17);
            this.Controls.Add(this.txtStartingDebit);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.metroLabel12);
            this.Controls.Add(this.txtID);
            this.Name = "frmAgent";
            this.Size = new System.Drawing.Size(856, 559);
            ((System.ComponentModel.ISupportInitialize)(this.txtStartingDebit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnClose;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtCustomerName;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroTextBox txtID;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtContact;
        private MetroFramework.Controls.MetroLabel metroLabel17;
        private DevComponents.Editors.DoubleInput txtStartingDebit;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtAddress;
        private MetroFramework.Controls.MetroButton btnFind;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton btnDelete;
        private MetroFramework.Controls.MetroButton btnSave;
    }
}
