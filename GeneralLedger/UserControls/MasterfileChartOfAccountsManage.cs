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
using MetroFramework.Forms;


namespace GeneralLedger.UserControls
{
    public partial class MasterfileChartOfAccountsManage : MetroForm
    {
        public int intIDMasCoa { get; set; }
        public string strCode { get; set; }
        public string strMasCOAName { get; set; }
        public int intIDMasCOAGroup { get; set; }
        public string AccountingSide { get; set; }
        public string AccountingType { get; set; }
        public int intIDMasCoaSub { get; set; }
        public int ISOrdering { get; set; }

        public MasterfileChartOfAccountsManage()
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MasterfileChartOfAccountsManage_Load(object sender, EventArgs e)
        {
            COABAL coaBAL = new COABAL();
            List<COAGroup> coaGrp = coaBAL.getCoaGoup();
            this.cbCOAGroup.DataSource = coaGrp;
            this.cbCOAGroup.ValueMember = "ID";
            this.cbCOAGroup.DisplayMember = "strName";

            this.txtCoaCode.Text = strCode;
            this.txtDescription.Text = strMasCOAName;
            this.cbCOAGroup.SelectedValue = intIDMasCOAGroup;
            this.txtAccountingSide.Text = AccountingSide;
            this.txtAccountingType.Text = AccountingType;
            this.txtIncomeStatementOrdering.Text = ISOrdering.ToString();

            if (this.intIDMasCoa > 0)
            {
                viewCOASub();
            }
        }


        private void viewCOASub()
        {
            try
            {
                COABAL getcoasub = new COABAL();
                List<COASub> coasubdtl = getcoasub.getCOASub(this.intIDMasCoa);

                if ((coasubdtl != null) && coasubdtl.Count > 0)
                {
                    this.dtgSubCoa.ColumnCount = 4;


                    this.dtgSubCoa.RowCount = coasubdtl.Count;

                    this.dtgSubCoa.Columns[0].Name = "ID";
                    this.dtgSubCoa.Columns[1].Name = "intIDCOA";
                    this.dtgSubCoa.Columns[2].Name = "strCoaSubCode";
                    this.dtgSubCoa.Columns[3].Name = "strCoaSubName";
                 

                    for (int i = 0; i < coasubdtl.Count; i++)
                    {

                        this.dtgSubCoa.Rows[i].Cells[0].Value = coasubdtl[i].ID;
                        this.dtgSubCoa.Rows[i].Cells[1].Value = coasubdtl[i].intIDCOA;
                        this.dtgSubCoa.Rows[i].Cells[2].Value = coasubdtl[i].strCoaSubCode;
                        this.dtgSubCoa.Rows[i].Cells[3].Value = coasubdtl[i].strCoaSubName;

                    }

                    setRowNumber(this.dtgSubCoa);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnSaveCoa_Click(object sender, EventArgs e)
        {
            try
            {

                string TransType = (this.intIDMasCoa == 0) ? "insert" : "update";
                string CoaGroupID = (this.cbCOAGroup.SelectedItem == null) ? string.Empty : ((COAGroup)this.cbCOAGroup.SelectedItem).ID.ToString(); // get value from combo box
                Dictionary<string, string> param = new Dictionary<string, string>();

                param.Add("&ID", this.intIDMasCoa.ToString());
                param.Add("&COACode", this.txtCoaCode.Text);
                param.Add("&COADesc", this.txtDescription.Text);
                param.Add("&COASide", this.txtAccountingSide.Text);
                param.Add("&COAType", this.txtAccountingType.Text);
                param.Add("&COAGroupID", CoaGroupID);
                param.Add("&ISOrdering", this.txtIncomeStatementOrdering.Text);

                COABAL coaBal = new COABAL();
                string result = coaBal.ManageCOA(param, TransType);

                if (result != string.Empty)
                {
                    this.intIDMasCoa = Convert.ToInt32(result.Split(',')[0]);
                    //this.txtCOACode.Text = result.Split(',')[1];
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("Successfully Saved");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnSaveCoaSubsidiary_Click(object sender, EventArgs e)
        {
            try
            {


                string TransType = (this.intIDMasCoaSub == 0) ? "insert" : "update";


                Dictionary<string, string> param = new Dictionary<string, string>();

                
                param.Add("&ID", this.intIDMasCoaSub.ToString());
                param.Add("&COACode", this.intIDMasCoa.ToString());
                param.Add("&COASubCode", this.txtCoaSubCode.Text);
                param.Add("&COASubCodeName", this.txtCoaSubName.Text);


                COABAL coaBal = new COABAL();
                string result = coaBal.ManageCOASub(param, TransType);

                if (result != string.Empty)
                {
                    this.intIDMasCoaSub = Convert.ToInt32(result.Split(',')[0]);
                    this.txtIDCoaSub.Text = intIDMasCoaSub.ToString();
                    //this.txtCOACode.Text = result.Split(',')[1];
                    MessageBox.Show("Successfully Saved");
                    viewCOASub();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnDeleteCoaSubsidiary_Click(object sender, EventArgs e)
        {

            try
            {

                string TransType = "delete";
                Dictionary<string, string> param = new Dictionary<string, string>();


                param.Add("&ID", this.intIDMasCoaSub.ToString());
                param.Add("&COACode", this.intIDMasCoa.ToString());
                param.Add("&COASubCode", this.txtCoaSubCode.Text);
                param.Add("&COASubCodeName", this.txtCoaSubName.Text);


                COABAL coaBal = new COABAL();
                string result = coaBal.ManageCOASub(param, TransType);

                if (result != string.Empty)
                {
                    this.intIDMasCoaSub = Convert.ToInt32(result.Split(',')[0]);
                    this.txtIDCoaSub.Text = string.Empty;
                    this.txtCoaSubCode.Text = string.Empty;
                    this.txtCoaSubName.Text = string.Empty;
                    //this.txtCOACode.Text = result.Split(',')[1];
                    this.dtgSubCoa.Rows.Clear();
                    this.dtgSubCoa.Refresh();
                    MessageBox.Show("Successfully Deleted");
                    viewCOASub();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void dtgSubCoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                this.intIDMasCoaSub = Convert.ToInt32(dtgSubCoa.Rows[e.RowIndex].Cells[0].Value.ToString());
                this.txtIDCoaSub.Text = dtgSubCoa.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.txtCoaSubCode.Text = dtgSubCoa.Rows[e.RowIndex].Cells[2].Value.ToString();
                this.txtCoaSubName.Text = dtgSubCoa.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        private void btnDeleteCOA_Click(object sender, EventArgs e)
        {
            try
            {

                string TransType = "delete";
                string CoaGroupID = (this.cbCOAGroup.SelectedItem == null) ? string.Empty : ((COAGroup)this.cbCOAGroup.SelectedItem).ID.ToString(); // get value from combo box
                Dictionary<string, string> param = new Dictionary<string, string>();

                param.Add("&ID", this.intIDMasCoa.ToString());
                param.Add("&COACode", this.txtCoaCode.Text);
                param.Add("&COADesc", this.txtDescription.Text);
                param.Add("&COASide", this.txtAccountingSide.Text);
                param.Add("&COAType", this.txtAccountingType.Text);
                param.Add("&COAGroupID", CoaGroupID);

                COABAL coaBal = new COABAL();
                string result = coaBal.ManageCOA(param, TransType);

                if (result != string.Empty)
                {
                    this.intIDMasCoaSub = Convert.ToInt32(result.Split(',')[0]);
                    this.DialogResult = DialogResult.OK;
                    //this.txtCOACode.Text = result.Split(',')[1];
                    MessageBox.Show("Successfully Deleted");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnAddNewCoaSub_Click(object sender, EventArgs e)
        {
            this.intIDMasCoaSub = 0;
            this.txtIDCoaSub.Text = string.Empty;
            this.txtCoaSubName.Text = string.Empty;
            this.txtCoaSubCode.Text = string.Empty;
        }
    }
}
