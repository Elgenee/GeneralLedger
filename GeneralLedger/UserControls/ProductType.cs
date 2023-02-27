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
    public partial class ProductType : MetroUserControl
    {
        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }

        public int IndexGrid { get; set; }

        public int ID { get; set; }

        public ProductType()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                string TransType = (this.ID == 0) ? "insert" : "update";
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("&ID", this.ID.ToString());
                param.Add("&Name", this.txName.Text);

                ProductTypeBAL ProductTypeBAL = new ProductTypeBAL();
                string result = ProductTypeBAL.Manage(param, TransType);

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


        private void RefreshGrid()
        {

            ProductTypeBAL ProductTypeBAL = new ProductTypeBAL();
            List<GeneralLedger.Tier.BO.ProductType> ProductTypeList = ProductTypeBAL.getProductType();


            if ((ProductTypeList != null) && ProductTypeList.Count > 0)
            {


                this.dgProductType.ColumnCount = 2;


                this.dgProductType.RowCount = ProductTypeList.Count;

                //this.dtgCoa.Columns[0].Name = "ID";
                //this.dtgCoa.Columns[1].Name = "Code";
                //this.dtgCoa.Columns[2].Name = "Name";

                //this.dtgCoa.Columns[3].Name = "Accounting Side";
                //this.dtgCoa.Columns[4].Name = "IDMasCOAGroup";
                //this.dtgCoa.Columns[5].Name = "Accounting Group";
                //this.dtgCoa.Columns[6].Name = "Accounting Type";

                //this.dgProductCategory.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgProductType.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //this.dgTrialBalanceData.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i = 0; i < ProductTypeList.Count; i++)
                {
                    this.dgProductType.Rows[i].Cells[0].Value = ProductTypeList[i].ID;
                    this.dgProductType.Rows[i].Cells[1].Value = ProductTypeList[i].Name;
                   

                    setRowNumber(this.dgProductType);
                }

            }
            else
            {
                this.dgProductType.Rows.Clear();
                this.dgProductType.Refresh();
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
        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                string TransType =  "delete";
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("&ID", this.ID.ToString());
                param.Add("&Name", this.txName.Text);

                ProductTypeBAL ProductTypeBAL = new ProductTypeBAL();
                string result = ProductTypeBAL.Manage(param, TransType);

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

        private void ProductType_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        //TODO:on click datagridview
        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        if (e.ColumnIndex == this.colDelete.Index)
        //        {
        //            var pallet = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as PrimalPallet;
        //            this.DeletePalletByID(pallet.ID);
        //        }
        //        else if (e.ColumnIndex == this.colEdit.Index)
        //        {
        //            var pallet = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as PrimalPallet;
        //            // etc.
        //        }
        //    }
        //}
        //this.dgProductType.Rows[i].Cells[2].Value = "Edit";

        private void dgProductType_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            
            if (e.RowIndex >= 0)
            {
               
      

                this.ID = Convert.ToInt32(dgProductType.Rows[e.RowIndex].Cells[0].Value.ToString());
                this.txtID.Text = dgProductType.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.txName.Text = dgProductType.Rows[e.RowIndex].Cells[1].Value.ToString();
            }

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.ID = 0;
            this.txtID.Text = string.Empty;
            this.txName.Text = string.Empty;
        }
    }
}
