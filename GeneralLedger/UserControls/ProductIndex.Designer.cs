namespace GeneralLedger.UserControls
{
    partial class ProductIndex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductIndex));
            this.dgProductSize = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.gdID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.Delete = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.btnAddProduct = new MetroFramework.Controls.MetroButton();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductSize)).BeginInit();
            this.SuspendLayout();
            // 
            // dgProductSize
            // 
            this.dgProductSize.AllowUserToDeleteRows = false;
            this.dgProductSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgProductSize.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProductSize.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gdID,
            this.gdName,
            this.Edit,
            this.Delete});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgProductSize.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgProductSize.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgProductSize.Location = new System.Drawing.Point(21, 71);
            this.dgProductSize.Name = "dgProductSize";
            this.dgProductSize.ReadOnly = true;
            this.dgProductSize.RowTemplate.Height = 30;
            this.dgProductSize.Size = new System.Drawing.Size(1430, 577);
            this.dgProductSize.TabIndex = 60;
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
            // Edit
            // 
            this.Edit.HeaderText = "Edit";
            this.Edit.Image = ((System.Drawing.Image)(resources.GetObject("Edit.Image")));
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Text = null;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = null;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(21, 29);
            this.btnAddProduct.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(179, 35);
            this.btnAddProduct.TabIndex = 61;
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.UseSelectable = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
            this.buttonX1.Image = global::GeneralLedger.Properties.Resources.cancel;
            this.buttonX1.Location = new System.Drawing.Point(1520, 29);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(154, 55);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.buttonX1.TabIndex = 62;
            this.buttonX1.Text = "Close Page";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // ProductIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.dgProductSize);
            this.Name = "ProductIndex";
            this.Size = new System.Drawing.Size(1689, 673);
            this.Load += new System.EventHandler(this.ProductIndex_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgProductSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgProductSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn gdID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gdName;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn Edit;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn Delete;
        private MetroFramework.Controls.MetroButton btnAddProduct;
        private DevComponents.DotNetBar.ButtonX buttonX1;
    }
}
