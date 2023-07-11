namespace GeneralLedger.UserControls
{
    partial class SearchProduct
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
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.dgProduct = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnSelect = new MetroFramework.Controls.MetroButton();
            this.btnSearch = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtCriteria = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.dgProduct);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(19, 107);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(952, 389);
            this.metroPanel1.TabIndex = 20;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // dgProduct
            // 
            this.dgProduct.AllowUserToAddRows = false;
            this.dgProduct.AllowUserToDeleteRows = false;
            this.dgProduct.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgProduct.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgProduct.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgProduct.Location = new System.Drawing.Point(0, 0);
            this.dgProduct.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgProduct.Name = "dgProduct";
            this.dgProduct.ReadOnly = true;
            this.dgProduct.RowTemplate.Height = 30;
            this.dgProduct.Size = new System.Drawing.Size(952, 389);
            this.dgProduct.TabIndex = 64;
            this.dgProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProduct_CellClick);
            this.dgProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProduct_CellClick);
            this.dgProduct.RowDividerDoubleClick += new System.Windows.Forms.DataGridViewRowDividerDoubleClickEventHandler(this.dgProduct_CellDoubleClick);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(466, 60);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(99, 23);
            this.btnSelect.TabIndex = 24;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseSelectable = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(361, 60);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(99, 23);
            this.btnSearch.TabIndex = 23;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseSelectable = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(25, 60);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(52, 19);
            this.metroLabel2.TabIndex = 22;
            this.metroLabel2.Text = "Criteria";
            // 
            // txtCriteria
            // 
            // 
            // 
            // 
            this.txtCriteria.CustomButton.Image = null;
            this.txtCriteria.CustomButton.Location = new System.Drawing.Point(119, 1);
            this.txtCriteria.CustomButton.Name = "";
            this.txtCriteria.CustomButton.Size = new System.Drawing.Size(14, 14);
            this.txtCriteria.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCriteria.CustomButton.TabIndex = 1;
            this.txtCriteria.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCriteria.CustomButton.UseSelectable = true;
            this.txtCriteria.CustomButton.Visible = false;
            this.txtCriteria.Lines = new string[0];
            this.txtCriteria.Location = new System.Drawing.Point(155, 60);
            this.txtCriteria.MaxLength = 32767;
            this.txtCriteria.Name = "txtCriteria";
            this.txtCriteria.PasswordChar = '\0';
            this.txtCriteria.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCriteria.SelectedText = "";
            this.txtCriteria.SelectionLength = 0;
            this.txtCriteria.SelectionStart = 0;
            this.txtCriteria.ShortcutsEnabled = true;
            this.txtCriteria.Size = new System.Drawing.Size(200, 23);
            this.txtCriteria.TabIndex = 21;
            this.txtCriteria.UseSelectable = true;
            this.txtCriteria.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCriteria.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // SearchProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 549);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtCriteria);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SearchProduct";
            this.Padding = new System.Windows.Forms.Padding(13, 39, 13, 13);
            this.Text = "Search Product";
            this.metroPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroButton btnSelect;
        private MetroFramework.Controls.MetroButton btnSearch;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtCriteria;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgProduct;
    }
}