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
    public partial class ProductUnit : MetroUserControl
    {
        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }
        public int IndexGrid { get; set; }
        public int ID { get; set; }
        public ProductUnit()
        {
            InitializeComponent();
        }

        public void RefreshGrid() {

            ProductUnitBAL ProductUnitBAL = new ProductUnitBAL();
            List<GeneralLedger.Tier.BO.ProductUnit> ProductionUnitList = ProductUnitBAL.getProductUnit();
            if ((ProductionUnitList != null) && ProductionUnitList.Count > 0)
            {


                this.dgProductUnit.ColumnCount = 2;


                this.dgProductUnit.RowCount = ProductionUnitList.Count;

                //this.dtgCoa.Columns[0].Name = "ID";
                //this.dtgCoa.Columns[1].Name = "Code";
                //this.dtgCoa.Columns[2].Name = "Name";

                //this.dtgCoa.Columns[3].Name = "Accounting Side";
                //this.dtgCoa.Columns[4].Name = "IDMasCOAGroup";
                //this.dtgCoa.Columns[5].Name = "Accounting Group";
                //this.dtgCoa.Columns[6].Name = "Accounting Type";

                //this.dgProductCategory.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgProductUnit.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //this.dgTrialBalanceData.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i = 0; i < ProductionUnitList.Count; i++)
                {
                    this.dgProductUnit.Rows[i].Cells[0].Value = ProductionUnitList[i].ID;
                    this.dgProductUnit.Rows[i].Cells[1].Value = ProductionUnitList[i].Name;


                    setRowNumber(this.dgProductUnit);
                }

            }
            else
            {
                this.dgProductUnit.Rows.Clear();
                this.dgProductUnit.Refresh();
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

                ProductUnitBAL ProductUnitBAL = new ProductUnitBAL();
                string result = ProductUnitBAL.Manage(param, TransType);

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

                ProductUnitBAL ProductUnitBAL = new ProductUnitBAL();
                string result = ProductUnitBAL.Manage(param, TransType);

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

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }

        private void ProductUnit_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void dgProductUnit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                this.ID = Convert.ToInt32(dgProductUnit.Rows[e.RowIndex].Cells[0].Value.ToString());
                this.txtID.Text = dgProductUnit.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.txName.Text = dgProductUnit.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }
    }
}
