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

namespace GeneralLedger.UserControls
{
    public partial class MasterfileChartOfAccounts : MetroUserControl
    {

        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }

        public MasterfileChartOfAccounts()
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

        private void MasterfileChartOfAccounts_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                COABAL coaBal = new COABAL();
                List<COA> coa = coaBal.getCOA(this.txtSeacrh.Text);

                if ((coa != null) && coa.Count > 0)
                {
                    this.dtgCoa.ColumnCount = 8;
                    
                  
                    this.dtgCoa.RowCount = coa.Count;

                    //this.dtgCoa.Columns[0].Name = "ID";
                    //this.dtgCoa.Columns[1].Name = "Code";
                    //this.dtgCoa.Columns[2].Name = "Name";
             
                    //this.dtgCoa.Columns[3].Name = "Accounting Side";
                    //this.dtgCoa.Columns[4].Name = "IDMasCOAGroup";
                    //this.dtgCoa.Columns[5].Name = "Accounting Group";
                    //this.dtgCoa.Columns[6].Name = "Accounting Type";

                    for (int i = 0; i < coa.Count; i++)
                    {
                        this.dtgCoa.Rows[i].Cells[0].Value = coa[i].ID;
                        this.dtgCoa.Rows[i].Cells[1].Value = coa[i].strCode;
                        this.dtgCoa.Rows[i].Cells[2].Value = coa[i].strName;
                        this.dtgCoa.Rows[i].Cells[3].Value = coa[i].strAcctSide;
                        this.dtgCoa.Rows[i].Cells[4].Value = coa[i].strCOANameGroup;
                        this.dtgCoa.Rows[i].Cells[5].Value = coa[i].intIDMasCOAGroup;
                        this.dtgCoa.Rows[i].Cells[6].Value = coa[i].strAcctType;
                        this.dtgCoa.Rows[i].Cells[7].Value = coa[i].ISOrdering;
                    }
                   
                    setRowNumber(this.dtgCoa);
                }
                else
                {
                    this.dtgCoa.Rows.Clear();
                    this.dtgCoa.Refresh();
                    MessageBox.Show("No Result");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
 
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            MasterfileChartOfAccountsManage mfca = new MasterfileChartOfAccountsManage();
            mfca.BringToFront();
            mfca.TopMost = true;
            DialogResult res =  mfca.ShowDialog(this);

            if (res == DialogResult.OK)
            {
                COABAL coaBal = new COABAL();
                List<COA> coa = coaBal.getCOA(string.Empty);
                this.dtgCoa.Rows.Clear();
                this.dtgCoa.Refresh();

            }
        }

        private void dtgCoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dtgCoa_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dtgCoa_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex >= 0)
                {

                    MasterfileChartOfAccountsManage cfa = new MasterfileChartOfAccountsManage();
                    cfa.intIDMasCoa = Int32.Parse(dtgCoa.Rows[e.RowIndex].Cells[0].Value.ToString());
                    cfa.strCode = dtgCoa.Rows[e.RowIndex].Cells[1].Value.ToString();
                    cfa.strMasCOAName = dtgCoa.Rows[e.RowIndex].Cells[2].Value.ToString();
                    cfa.intIDMasCOAGroup = Int32.Parse(dtgCoa.Rows[e.RowIndex].Cells[5].Value.ToString());
                    cfa.AccountingSide = dtgCoa.Rows[e.RowIndex].Cells[3].Value.ToString();
                    cfa.AccountingType = dtgCoa.Rows[e.RowIndex].Cells[6].Value.ToString();
                    cfa.ISOrdering = Int32.Parse(dtgCoa.Rows[e.RowIndex].Cells[7].Value.ToString());


                    cfa.BringToFront();
                    //cfa.TopMost = true;
                    DialogResult res =  cfa.ShowDialog(this);
                    if (res == DialogResult.OK)
                    {
                        COABAL coaBal = new COABAL();
                        List<COA> coa = coaBal.getCOA(string.Empty);
                        this.dtgCoa.Rows.Clear();
                        this.dtgCoa.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }
    }
}
