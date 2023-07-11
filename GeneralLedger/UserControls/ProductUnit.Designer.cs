namespace GeneralLedger.UserControls
{
    partial class ProductUnit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgProductUnit = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.gdID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.txName = new MetroFramework.Controls.MetroTextBox();
            this.txtID = new MetroFramework.Controls.MetroTextBox();
            this.btnDelete = new MetroFramework.Controls.MetroButton();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductUnit)).BeginInit();
            this.SuspendLayout();
            // 
            // dgProductUnit
            // 
            this.dgProductUnit.AllowUserToAddRows = false;
            this.dgProductUnit.AllowUserToDeleteRows = false;
            this.dgProductUnit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgProductUnit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProductUnit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gdID,
            this.gdName});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgProductUnit.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgProductUnit.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgProductUnit.Location = new System.Drawing.Point(331, 20);
            this.dgProductUnit.Margin = new System.Windows.Forms.Padding(2);
            this.dgProductUnit.Name = "dgProductUnit";
            this.dgProductUnit.ReadOnly = true;
            this.dgProductUnit.RowTemplate.Height = 28;
            this.dgProductUnit.Size = new System.Drawing.Size(392, 133);
            this.dgProductUnit.TabIndex = 48;
            this.dgProductUnit.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProductUnit_CellClick);
            // 
            // gdID
            // 
            this.gdID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gdID.HeaderText = "ID";
            this.gdID.Name = "gdID";
            this.gdID.ReadOnly = true;
            // 
            // gdName
            // 
            this.gdName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gdName.HeaderText = "Name";
            this.gdName.Name = "gdName";
            this.gdName.ReadOnly = true;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
            this.btnClose.Image = global::GeneralLedger.Properties.Resources.cancel;
            this.btnClose.Location = new System.Drawing.Point(736, 19);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 36);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnClose.TabIndex = 47;
            this.btnClose.Text = "Close Page";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(7, 83);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(99, 23);
            this.metroButton1.TabIndex = 46;
            this.metroButton1.Text = "Add";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // txName
            // 
            // 
            // 
            // 
            this.txName.CustomButton.Image = null;
            this.txName.CustomButton.Location = new System.Drawing.Point(161, 1);
            this.txName.CustomButton.Name = "";
            this.txName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txName.CustomButton.TabIndex = 1;
            this.txName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txName.CustomButton.UseSelectable = true;
            this.txName.CustomButton.Visible = false;
            this.txName.Lines = new string[0];
            this.txName.Location = new System.Drawing.Point(83, 53);
            this.txName.MaxLength = 32767;
            this.txName.Name = "txName";
            this.txName.PasswordChar = '\0';
            this.txName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txName.SelectedText = "";
            this.txName.SelectionLength = 0;
            this.txName.SelectionStart = 0;
            this.txName.ShortcutsEnabled = true;
            this.txName.Size = new System.Drawing.Size(183, 23);
            this.txName.TabIndex = 45;
            this.txName.UseSelectable = true;
            this.txName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.ControlLight;
            // 
            // 
            // 
            this.txtID.CustomButton.Image = null;
            this.txtID.CustomButton.Location = new System.Drawing.Point(161, 1);
            this.txtID.CustomButton.Name = "";
            this.txtID.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtID.CustomButton.TabIndex = 1;
            this.txtID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtID.CustomButton.UseSelectable = true;
            this.txtID.CustomButton.Visible = false;
            this.txtID.Enabled = false;
            this.txtID.Lines = new string[0];
            this.txtID.Location = new System.Drawing.Point(83, 20);
            this.txtID.MaxLength = 32767;
            this.txtID.Name = "txtID";
            this.txtID.PasswordChar = '\0';
            this.txtID.ReadOnly = true;
            this.txtID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtID.SelectedText = "";
            this.txtID.SelectionLength = 0;
            this.txtID.SelectionStart = 0;
            this.txtID.ShortcutsEnabled = true;
            this.txtID.Size = new System.Drawing.Size(183, 23);
            this.txtID.TabIndex = 44;
            this.txtID.UseCustomBackColor = true;
            this.txtID.UseSelectable = true;
            this.txtID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(213, 83);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 23);
            this.btnDelete.TabIndex = 43;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(110, 83);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 23);
            this.btnSave.TabIndex = 42;
            this.btnSave.Text = "Save";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(32, 49);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(45, 19);
            this.metroLabel2.TabIndex = 50;
            this.metroLabel2.Text = "Name";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(32, 20);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(21, 19);
            this.metroLabel1.TabIndex = 49;
            this.metroLabel1.Text = "ID";
            // 
            // ProductUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.dgProductUnit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.txName);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProductUnit";
            this.Size = new System.Drawing.Size(854, 289);
            this.Load += new System.EventHandler(this.ProductUnit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgProductUnit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgProductUnit;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroTextBox txName;
        private MetroFramework.Controls.MetroTextBox txtID;
        private MetroFramework.Controls.MetroButton btnDelete;
        private MetroFramework.Controls.MetroButton btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn gdID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gdName;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}
