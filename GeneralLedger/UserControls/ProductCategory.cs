using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using GeneralLedger.Tier.BO;
using GeneralLedger.Tier.BAL;
using System.Globalization;

namespace GeneralLedger.UserControls
{
    public partial class ProductCategory : MetroUserControl
    {
        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }

        public int IndexGrid { get; set; }

        public int ID { get; set; }



        public ProductCategory()
        {
            InitializeComponent();
        }
        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string TransType = (this.ID == 0) ? "insert" : "update";
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("&ID", this.ID.ToString());
                param.Add("&Name", this.txName.Text);

                ProductCategoryBAL ProductCategoryBAL = new ProductCategoryBAL();
                string result = ProductCategoryBAL.Manage(param, TransType);

                if (result != string.Empty)
                {
                    this.ID = Convert.ToInt32(result.Split(',')[0]);
                    this.txtID.Text = result.Split(',')[0];
                    RefreshGrid();
                    MessageBox.Show("Successfully saved");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }


        private void RefreshGrid() {

            ProductCategoryBAL ProductCategoryBAL = new ProductCategoryBAL();
            List<GeneralLedger.Tier.BO.ProductCategory> ProductCategoryList = ProductCategoryBAL.getProductCategory();


            if ((ProductCategoryList != null) && ProductCategoryList.Count > 0)
            {


                this.dgProductCategory.ColumnCount = 2;


                this.dgProductCategory.RowCount = ProductCategoryList.Count;

                //this.dtgCoa.Columns[0].Name = "ID";
                //this.dtgCoa.Columns[1].Name = "Code";
                //this.dtgCoa.Columns[2].Name = "Name";

                //this.dtgCoa.Columns[3].Name = "Accounting Side";
                //this.dtgCoa.Columns[4].Name = "IDMasCOAGroup";
                //this.dtgCoa.Columns[5].Name = "Accounting Group";
                //this.dtgCoa.Columns[6].Name = "Accounting Type";

                //this.dgProductCategory.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //this.dgProductCategory.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //this.dgTrialBalanceData.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                this.dgProductCategory.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None; // Keep it small
                this.dgProductCategory.Columns[0].Width = 100; // Set a fixed width for the first column

                // Set the second column (index 1) to AutoSizeMode.Fill and give it more weight
                this.dgProductCategory.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgProductCategory.Columns[1].FillWeight = 80; // Larger weight to make it dominant

                for (int i = 0; i < ProductCategoryList.Count; i++)
                {
                    this.dgProductCategory.Rows[i].Cells[0].Value = ProductCategoryList[i].ID;
                    this.dgProductCategory.Rows[i].Cells[1].Value = ProductCategoryList[i].Name;


                    setRowNumber(this.dgProductCategory);
                }

            }
            else
            {
                this.dgProductCategory.Rows.Clear();
                this.dgProductCategory.Refresh();
                MessageBox.Show("No Result");
            }

        }

        private void ProductCategory_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void dgProductCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {

                this.ID = Convert.ToInt32(dgProductCategory.Rows[e.RowIndex].Cells[0].Value.ToString());
                this.txtID.Text = dgProductCategory.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.txName.Text = dgProductCategory.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.ID = 0;
            this.txtID.Text = string.Empty;
            this.txName.Text = string.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string TransType =  "delete";
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("&ID", this.ID.ToString());
                param.Add("&Name", this.txName.Text);

                ProductCategoryBAL ProductCategoryBAL = new ProductCategoryBAL();
                string result = ProductCategoryBAL.Manage(param, TransType);

                if (result != string.Empty)
                {
                    this.ID = Convert.ToInt32(result.Split(',')[0]);
                    this.txtID.Text = result.Split(',')[0];
                    this.txName.Text = string.Empty;
                    RefreshGrid();
                    MessageBox.Show("Successfully deleted");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            ProductCategoryBAL ProductCategoryBAL = new ProductCategoryBAL();
            List<GeneralLedger.Tier.BO.ProductCategory> ProductCategoryList = ProductCategoryBAL.getProductCategoryByCriteria(this.txtCriteria.Text);


            if ((ProductCategoryList != null) && ProductCategoryList.Count > 0)
            {


                this.dgProductCategory.ColumnCount = 2;


                this.dgProductCategory.RowCount = ProductCategoryList.Count;

                //this.dtgCoa.Columns[0].Name = "ID";
                //this.dtgCoa.Columns[1].Name = "Code";
                //this.dtgCoa.Columns[2].Name = "Name";

                //this.dtgCoa.Columns[3].Name = "Accounting Side";
                //this.dtgCoa.Columns[4].Name = "IDMasCOAGroup";
                //this.dtgCoa.Columns[5].Name = "Accounting Group";
                //this.dtgCoa.Columns[6].Name = "Accounting Type";

                //this.dgProductCategory.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //this.dgProductCategory.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //this.dgTrialBalanceData.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                this.dgProductCategory.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None; // Keep it small
                this.dgProductCategory.Columns[0].Width = 100; // Set a fixed width for the first column

                // Set the second column (index 1) to AutoSizeMode.Fill and give it more weight
                this.dgProductCategory.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgProductCategory.Columns[1].FillWeight = 80; // Larger weight to make it dominant

                for (int i = 0; i < ProductCategoryList.Count; i++)
                {
                    this.dgProductCategory.Rows[i].Cells[0].Value = ProductCategoryList[i].ID;
                    this.dgProductCategory.Rows[i].Cells[1].Value = ProductCategoryList[i].Name;


                    setRowNumber(this.dgProductCategory);
                }

            }
            else
            {
                this.dgProductCategory.Rows.Clear();
                this.dgProductCategory.Refresh();
                MessageBox.Show("No Result");
            }
        }
    }
}
