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
    public partial class ProductBrand : MetroUserControl
    {
        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }
        public int IndexGrid { get; set; }
        public int ID { get; set; }
        public ProductBrand()
        {
            InitializeComponent();
        }

        private void ProductBrand_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        public void RefreshGrid() {

            ProductBrandBAL ProductBrandBAL = new ProductBrandBAL();
            List<GeneralLedger.Tier.BO.ProductBrand> ProductBrandList = ProductBrandBAL.getProductBrand();
            if ((ProductBrandList != null) && ProductBrandList.Count > 0)
            {


                this.dgProductBrand.ColumnCount = 2;


                this.dgProductBrand.RowCount = ProductBrandList.Count;

                //this.dtgCoa.Columns[0].Name = "ID";
                //this.dtgCoa.Columns[1].Name = "Code";
                //this.dtgCoa.Columns[2].Name = "Name";

                //this.dtgCoa.Columns[3].Name = "Accounting Side";
                //this.dtgCoa.Columns[4].Name = "IDMasCOAGroup";
                //this.dtgCoa.Columns[5].Name = "Accounting Group";
                //this.dtgCoa.Columns[6].Name = "Accounting Type";

                //this.dgProductCategory.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //this.dgProductBrand.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //this.dgTrialBalanceData.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                this.dgProductBrand.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None; // Keep it small
                this.dgProductBrand.Columns[0].Width = 100; // Set a fixed width for the first column

                // Set the second column (index 1) to AutoSizeMode.Fill and give it more weight
                this.dgProductBrand.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgProductBrand.Columns[1].FillWeight = 80; // Larger weight to make it dominant

                for (int i = 0; i < ProductBrandList.Count; i++)
                {
                    this.dgProductBrand.Rows[i].Cells[0].Value = ProductBrandList[i].ID;
                    this.dgProductBrand.Rows[i].Cells[1].Value = ProductBrandList[i].Name;


                    setRowNumber(this.dgProductBrand);
                }

            }
            else
            {
                this.dgProductBrand.Rows.Clear();
                this.dgProductBrand.Refresh();
                MessageBox.Show("No Result");
            }
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

                ProductBrandBAL ProductBrandBAL = new ProductBrandBAL();
                string result = ProductBrandBAL.Manage(param, TransType);

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

                ProductBrandBAL ProductBrandBAL = new ProductBrandBAL();
                string result = ProductBrandBAL.Manage(param, TransType);

                if (result != string.Empty)
                {
                    this.ID = Convert.ToInt32(result.Split(',')[0]);
                    this.txtID.Text = result.Split(',')[0];
                    RefreshGrid();
                    MessageBox.Show("Successfully deleted");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void dgProductBrand_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                this.ID = Convert.ToInt32(dgProductBrand.Rows[e.RowIndex].Cells[0].Value.ToString());
                this.txtID.Text = dgProductBrand.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.txName.Text = dgProductBrand.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ProductBrandBAL ProductBrandBAL = new ProductBrandBAL();
            List<GeneralLedger.Tier.BO.ProductBrand> ProductBrandList = ProductBrandBAL.getProductBrandByCriteria(this.txtCriteria.Text);
            if ((ProductBrandList != null) && ProductBrandList.Count > 0)
            {


                this.dgProductBrand.ColumnCount = 2;


                this.dgProductBrand.RowCount = ProductBrandList.Count;

                //this.dtgCoa.Columns[0].Name = "ID";
                //this.dtgCoa.Columns[1].Name = "Code";
                //this.dtgCoa.Columns[2].Name = "Name";

                //this.dtgCoa.Columns[3].Name = "Accounting Side";
                //this.dtgCoa.Columns[4].Name = "IDMasCOAGroup";
                //this.dtgCoa.Columns[5].Name = "Accounting Group";
                //this.dtgCoa.Columns[6].Name = "Accounting Type";

                //this.dgProductCategory.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //this.dgProductBrand.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //this.dgTrialBalanceData.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                this.dgProductBrand.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None; // Keep it small
                this.dgProductBrand.Columns[0].Width = 100; // Set a fixed width for the first column

                // Set the second column (index 1) to AutoSizeMode.Fill and give it more weight
                this.dgProductBrand.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgProductBrand.Columns[1].FillWeight = 80; // Larger weight to make it dominant

                for (int i = 0; i < ProductBrandList.Count; i++)
                {
                    this.dgProductBrand.Rows[i].Cells[0].Value = ProductBrandList[i].ID;
                    this.dgProductBrand.Rows[i].Cells[1].Value = ProductBrandList[i].Name;


                    setRowNumber(this.dgProductBrand);
                }

            }
            else
            {
                this.dgProductBrand.Rows.Clear();
                this.dgProductBrand.Refresh();
                MessageBox.Show("No Result");
            }
        }
    }
}
