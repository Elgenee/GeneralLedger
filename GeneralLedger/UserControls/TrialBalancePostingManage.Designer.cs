namespace GeneralLedger.UserControls
{
    partial class TrialBalancePostingManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtBatchDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtRemarks = new MetroFramework.Controls.MetroTextBox();
            this.btnPostBatchDate = new MetroFramework.Controls.MetroButton();
            this.btnPreviewTrialBalance = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.dgTrialBalance = new MetroFramework.Controls.MetroGrid();
            this.txtBegBalance = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtDebit = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.txtCredit = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.txtEndBalance = new MetroFramework.Controls.MetroTextBox();
            this.btnUnlock = new MetroFramework.Controls.MetroButton();
            this.btnLock = new MetroFramework.Controls.MetroButton();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTrialBalance)).BeginInit();
            this.SuspendLayout();
            // 
            // dtBatchDate
            // 
            this.dtBatchDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBatchDate.Location = new System.Drawing.Point(183, 91);
            this.dtBatchDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtBatchDate.MinimumSize = new System.Drawing.Size(0, 30);
            this.dtBatchDate.Name = "dtBatchDate";
            this.dtBatchDate.Size = new System.Drawing.Size(265, 30);
            this.dtBatchDate.TabIndex = 5;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(78, 91);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(76, 20);
            this.metroLabel1.TabIndex = 6;
            this.metroLabel1.Text = "Batch Date";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(78, 134);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(62, 20);
            this.metroLabel2.TabIndex = 7;
            this.metroLabel2.Text = "Remarks";
            // 
            // txtRemarks
            // 
            // 
            // 
            // 
            this.txtRemarks.CustomButton.Image = null;
            this.txtRemarks.CustomButton.Location = new System.Drawing.Point(348, 2);
            this.txtRemarks.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtRemarks.CustomButton.Name = "";
            this.txtRemarks.CustomButton.Size = new System.Drawing.Size(57, 57);
            this.txtRemarks.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtRemarks.CustomButton.TabIndex = 1;
            this.txtRemarks.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtRemarks.CustomButton.UseSelectable = true;
            this.txtRemarks.CustomButton.Visible = false;
            this.txtRemarks.Lines = new string[0];
            this.txtRemarks.Location = new System.Drawing.Point(183, 134);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(4);
            this.txtRemarks.MaxLength = 32767;
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.PasswordChar = '\0';
            this.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRemarks.SelectedText = "";
            this.txtRemarks.SelectionLength = 0;
            this.txtRemarks.SelectionStart = 0;
            this.txtRemarks.ShortcutsEnabled = true;
            this.txtRemarks.Size = new System.Drawing.Size(408, 62);
            this.txtRemarks.TabIndex = 8;
            this.txtRemarks.UseSelectable = true;
            this.txtRemarks.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtRemarks.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnPostBatchDate
            // 
            this.btnPostBatchDate.Location = new System.Drawing.Point(183, 204);
            this.btnPostBatchDate.Margin = new System.Windows.Forms.Padding(4);
            this.btnPostBatchDate.Name = "btnPostBatchDate";
            this.btnPostBatchDate.Size = new System.Drawing.Size(132, 28);
            this.btnPostBatchDate.TabIndex = 9;
            this.btnPostBatchDate.Text = "Post Batch Date";
            this.btnPostBatchDate.UseSelectable = true;
            this.btnPostBatchDate.Visible = false;
            this.btnPostBatchDate.Click += new System.EventHandler(this.btnPostBatchDate_Click);
            // 
            // btnPreviewTrialBalance
            // 
            this.btnPreviewTrialBalance.Location = new System.Drawing.Point(640, 78);
            this.btnPreviewTrialBalance.Margin = new System.Windows.Forms.Padding(4);
            this.btnPreviewTrialBalance.Name = "btnPreviewTrialBalance";
            this.btnPreviewTrialBalance.Size = new System.Drawing.Size(233, 59);
            this.btnPreviewTrialBalance.TabIndex = 10;
            this.btnPreviewTrialBalance.Text = "Preview Trial Balance";
            this.btnPreviewTrialBalance.UseSelectable = true;
            this.btnPreviewTrialBalance.Click += new System.EventHandler(this.btnPreviewTrialBalance_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(640, 144);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(4);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(233, 59);
            this.metroButton1.TabIndex = 12;
            this.metroButton1.Text = "Preview Closing Trial Balance";
            this.metroButton1.UseSelectable = true;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.dgTrialBalance);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 12;
            this.metroPanel1.Location = new System.Drawing.Point(6, 240);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1531, 454);
            this.metroPanel1.TabIndex = 13;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 13;
            // 
            // dgTrialBalance
            // 
            this.dgTrialBalance.AllowUserToResizeRows = false;
            this.dgTrialBalance.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgTrialBalance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgTrialBalance.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgTrialBalance.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTrialBalance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgTrialBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgTrialBalance.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgTrialBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTrialBalance.EnableHeadersVisualStyles = false;
            this.dgTrialBalance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgTrialBalance.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgTrialBalance.Location = new System.Drawing.Point(0, 0);
            this.dgTrialBalance.Margin = new System.Windows.Forms.Padding(4);
            this.dgTrialBalance.Name = "dgTrialBalance";
            this.dgTrialBalance.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTrialBalance.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgTrialBalance.RowHeadersWidth = 51;
            this.dgTrialBalance.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgTrialBalance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTrialBalance.Size = new System.Drawing.Size(1531, 454);
            this.dgTrialBalance.TabIndex = 2;
            // 
            // txtBegBalance
            // 
            // 
            // 
            // 
            this.txtBegBalance.CustomButton.Image = null;
            this.txtBegBalance.CustomButton.Location = new System.Drawing.Point(138, 2);
            this.txtBegBalance.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtBegBalance.CustomButton.Name = "";
            this.txtBegBalance.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtBegBalance.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBegBalance.CustomButton.TabIndex = 1;
            this.txtBegBalance.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBegBalance.CustomButton.UseSelectable = true;
            this.txtBegBalance.CustomButton.Visible = false;
            this.txtBegBalance.Enabled = false;
            this.txtBegBalance.Lines = new string[0];
            this.txtBegBalance.Location = new System.Drawing.Point(364, 726);
            this.txtBegBalance.Margin = new System.Windows.Forms.Padding(4);
            this.txtBegBalance.MaxLength = 32767;
            this.txtBegBalance.Name = "txtBegBalance";
            this.txtBegBalance.PasswordChar = '\0';
            this.txtBegBalance.ReadOnly = true;
            this.txtBegBalance.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBegBalance.SelectedText = "";
            this.txtBegBalance.SelectionLength = 0;
            this.txtBegBalance.SelectionStart = 0;
            this.txtBegBalance.ShortcutsEnabled = true;
            this.txtBegBalance.Size = new System.Drawing.Size(164, 28);
            this.txtBegBalance.TabIndex = 14;
            this.txtBegBalance.UseSelectable = true;
            this.txtBegBalance.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBegBalance.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(254, 726);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(85, 20);
            this.metroLabel3.TabIndex = 15;
            this.metroLabel3.Text = "Beg Balance";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(554, 726);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(42, 20);
            this.metroLabel4.TabIndex = 17;
            this.metroLabel4.Text = "Debit";
            // 
            // txtDebit
            // 
            // 
            // 
            // 
            this.txtDebit.CustomButton.Image = null;
            this.txtDebit.CustomButton.Location = new System.Drawing.Point(138, 2);
            this.txtDebit.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtDebit.CustomButton.Name = "";
            this.txtDebit.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtDebit.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDebit.CustomButton.TabIndex = 1;
            this.txtDebit.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDebit.CustomButton.UseSelectable = true;
            this.txtDebit.CustomButton.Visible = false;
            this.txtDebit.Enabled = false;
            this.txtDebit.Lines = new string[0];
            this.txtDebit.Location = new System.Drawing.Point(610, 726);
            this.txtDebit.Margin = new System.Windows.Forms.Padding(4);
            this.txtDebit.MaxLength = 32767;
            this.txtDebit.Name = "txtDebit";
            this.txtDebit.PasswordChar = '\0';
            this.txtDebit.ReadOnly = true;
            this.txtDebit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDebit.SelectedText = "";
            this.txtDebit.SelectionLength = 0;
            this.txtDebit.SelectionStart = 0;
            this.txtDebit.ShortcutsEnabled = true;
            this.txtDebit.Size = new System.Drawing.Size(164, 28);
            this.txtDebit.TabIndex = 16;
            this.txtDebit.UseSelectable = true;
            this.txtDebit.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDebit.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(802, 726);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(46, 20);
            this.metroLabel5.TabIndex = 19;
            this.metroLabel5.Text = "Credit";
            // 
            // txtCredit
            // 
            // 
            // 
            // 
            this.txtCredit.CustomButton.Image = null;
            this.txtCredit.CustomButton.Location = new System.Drawing.Point(138, 2);
            this.txtCredit.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtCredit.CustomButton.Name = "";
            this.txtCredit.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtCredit.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCredit.CustomButton.TabIndex = 1;
            this.txtCredit.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCredit.CustomButton.UseSelectable = true;
            this.txtCredit.CustomButton.Visible = false;
            this.txtCredit.Enabled = false;
            this.txtCredit.Lines = new string[0];
            this.txtCredit.Location = new System.Drawing.Point(865, 726);
            this.txtCredit.Margin = new System.Windows.Forms.Padding(4);
            this.txtCredit.MaxLength = 32767;
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.PasswordChar = '\0';
            this.txtCredit.ReadOnly = true;
            this.txtCredit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCredit.SelectedText = "";
            this.txtCredit.SelectionLength = 0;
            this.txtCredit.SelectionStart = 0;
            this.txtCredit.ShortcutsEnabled = true;
            this.txtCredit.Size = new System.Drawing.Size(164, 28);
            this.txtCredit.TabIndex = 18;
            this.txtCredit.UseSelectable = true;
            this.txtCredit.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCredit.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(1055, 726);
            this.metroLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(85, 20);
            this.metroLabel6.TabIndex = 21;
            this.metroLabel6.Text = "End Balance";
            // 
            // txtEndBalance
            // 
            // 
            // 
            // 
            this.txtEndBalance.CustomButton.Image = null;
            this.txtEndBalance.CustomButton.Location = new System.Drawing.Point(138, 2);
            this.txtEndBalance.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtEndBalance.CustomButton.Name = "";
            this.txtEndBalance.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtEndBalance.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtEndBalance.CustomButton.TabIndex = 1;
            this.txtEndBalance.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtEndBalance.CustomButton.UseSelectable = true;
            this.txtEndBalance.CustomButton.Visible = false;
            this.txtEndBalance.Enabled = false;
            this.txtEndBalance.Lines = new string[0];
            this.txtEndBalance.Location = new System.Drawing.Point(1175, 726);
            this.txtEndBalance.Margin = new System.Windows.Forms.Padding(4);
            this.txtEndBalance.MaxLength = 32767;
            this.txtEndBalance.Name = "txtEndBalance";
            this.txtEndBalance.PasswordChar = '\0';
            this.txtEndBalance.ReadOnly = true;
            this.txtEndBalance.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEndBalance.SelectedText = "";
            this.txtEndBalance.SelectionLength = 0;
            this.txtEndBalance.SelectionStart = 0;
            this.txtEndBalance.ShortcutsEnabled = true;
            this.txtEndBalance.Size = new System.Drawing.Size(164, 28);
            this.txtEndBalance.TabIndex = 20;
            this.txtEndBalance.UseSelectable = true;
            this.txtEndBalance.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtEndBalance.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnUnlock
            // 
            this.btnUnlock.Location = new System.Drawing.Point(463, 204);
            this.btnUnlock.Margin = new System.Windows.Forms.Padding(4);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(132, 28);
            this.btnUnlock.TabIndex = 44;
            this.btnUnlock.Text = "Unlock";
            this.btnUnlock.UseSelectable = true;
            this.btnUnlock.Visible = false;
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            // 
            // btnLock
            // 
            this.btnLock.Location = new System.Drawing.Point(323, 204);
            this.btnLock.Margin = new System.Windows.Forms.Padding(4);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(132, 28);
            this.btnLock.TabIndex = 43;
            this.btnLock.Text = "Lock";
            this.btnLock.UseSelectable = true;
            this.btnLock.Visible = false;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // TrialBalancePostingManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1542, 800);
            this.Controls.Add(this.btnUnlock);
            this.Controls.Add(this.btnLock);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.txtEndBalance);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.txtCredit);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.txtDebit);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.txtBegBalance);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.btnPreviewTrialBalance);
            this.Controls.Add(this.btnPostBatchDate);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.dtBatchDate);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TrialBalancePostingManage";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Text = "Trial Balance Posting Manage";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.metroPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTrialBalance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroDateTime dtBatchDate;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtRemarks;
        private MetroFramework.Controls.MetroButton btnPostBatchDate;
        private MetroFramework.Controls.MetroButton btnPreviewTrialBalance;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroGrid dgTrialBalance;
        private MetroFramework.Controls.MetroTextBox txtBegBalance;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtDebit;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox txtCredit;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox txtEndBalance;
        private MetroFramework.Controls.MetroButton btnUnlock;
        private MetroFramework.Controls.MetroButton btnLock;
    }
}