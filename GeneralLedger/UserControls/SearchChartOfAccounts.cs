using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using GeneralLedger.Tier.BAL;
using GeneralLedger.Tier.BO;
using System.Globalization;

namespace GeneralLedger.UserControls
{
    public partial class SearchChartOfAccounts : MetroForm
    {
        public int intIDMasCOA { get; set; }
        public int intIDMasCOASUB { get; set; }
        public GLTranDetail GLTranDetail { get; set; }
        public int IDGLTranHeader { get; set; }

        public SearchChartOfAccounts()
        {
            InitializeComponent();
            GLTranDetail = null;
            this.intIDMasCOA = 0;
            this.intIDMasCOASUB = 0;
            this.IDGLTranHeader = 0;
        }

        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        private void btnSearchChartOfAccounts_Click(object sender, EventArgs e)
        {
            try
            {
                COABAL coaBal = new COABAL();
                List<COA> coa = coaBal.getCOA(this.txtSearchChartOfAccounts.Text);

                if ((coa != null) && coa.Count > 0)
                {

                    this.dgChartOfAccounts.ColumnCount = 7;


                    this.dgChartOfAccounts.RowCount = coa.Count;


                    for (int i = 0; i < coa.Count; i++)
                    {
                        this.dgChartOfAccounts.Rows[i].Cells[0].Value = coa[i].ID;
                        this.dgChartOfAccounts.Rows[i].Cells[1].Value = coa[i].strCode;
                        this.dgChartOfAccounts.Rows[i].Cells[2].Value = coa[i].strName;
                        this.dgChartOfAccounts.Rows[i].Cells[3].Value = coa[i].strAcctSide;
                        this.dgChartOfAccounts.Rows[i].Cells[4].Value = coa[i].strCOANameGroup;
                        this.dgChartOfAccounts.Rows[i].Cells[5].Value = coa[i].intIDMasCOAGroup;
                        this.dgChartOfAccounts.Rows[i].Cells[6].Value = coa[i].strAcctType;
                    }

                    setRowNumber(this.dgChartOfAccounts);
                }
                else
                {
                    this.dgChartOfAccounts.Rows.Clear();
                    this.dgChartOfAccounts.Refresh();
                    MessageBox.Show("No Result");

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void dgChartOfAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0)
                {

                    this.intIDMasCOA = Int32.Parse(this.dgChartOfAccounts.Rows[e.RowIndex].Cells[0].Value.ToString());
                    this.txtChartOfAccountCode.Text = this.dgChartOfAccounts.Rows[e.RowIndex].Cells[1].Value.ToString();
                    this.txtChartOfAccountsDescription.Text = this.dgChartOfAccounts.Rows[e.RowIndex].Cells[2].Value.ToString();


                    COABAL getcoasub = new COABAL();
                    List<COASub> coasubdtl = getcoasub.getCOASub(this.intIDMasCOA);

                    if ((coasubdtl != null) && coasubdtl.Count > 0)
                    {
                        this.dgChartOfAccountsSubsidiary.ColumnCount = 4;


                        this.dgChartOfAccountsSubsidiary.RowCount = coasubdtl.Count;

                        this.dgChartOfAccountsSubsidiary.Columns[0].Name = "ID";
                        this.dgChartOfAccountsSubsidiary.Columns[1].Name = "COA";
                        this.dgChartOfAccountsSubsidiary.Columns[2].Name = "COA Subsidiary Code";
                        this.dgChartOfAccountsSubsidiary.Columns[3].Name = "COA Subsidiary Name";
                        this.dgChartOfAccountsSubsidiary.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.dgChartOfAccountsSubsidiary.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;



                        for (int i = 0; i < coasubdtl.Count; i++)
                        {

                            this.dgChartOfAccountsSubsidiary.Rows[i].Cells[0].Value = coasubdtl[i].ID;
                            this.dgChartOfAccountsSubsidiary.Rows[i].Cells[1].Value = coasubdtl[i].intIDCOA;
                            this.dgChartOfAccountsSubsidiary.Rows[i].Cells[2].Value = coasubdtl[i].strCoaSubCode;
                            this.dgChartOfAccountsSubsidiary.Rows[i].Cells[3].Value = coasubdtl[i].strCoaSubName;
                        }

                        setRowNumber(this.dgChartOfAccountsSubsidiary);


                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void txtChartOfAccountsDescription_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchCOASelect_Click(object sender, EventArgs e)
        {

        }

        private void dgChartOfAccountsSubsidiary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0)
                {

                    this.intIDMasCOASUB = Int32.Parse(this.dgChartOfAccountsSubsidiary.Rows[e.RowIndex].Cells[0].Value.ToString());
                    this.txtChartOfAccountSubdiaryCode.Text = this.dgChartOfAccountsSubsidiary.Rows[e.RowIndex].Cells[2].Value.ToString();
                    this.txtChartOfAccountsSubsidiaryDescription.Text = this.dgChartOfAccountsSubsidiary.Rows[e.RowIndex].Cells[3].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void btnSearchAddJournalEntry_Click(object sender, EventArgs e)
        {
            Double doubleParser;
            try
            {
                if (intIDMasCOA == 0)
                {
                    MessageBox.Show("Please Select Chart Of Accounts");
                    return;
                }
                GLTranDetail = new GLTranDetail {
                    intIDGLTranHeader = this.IDGLTranHeader,
                    intIDCOA = this.intIDMasCOA,
                    intIDCOASub = this.intIDMasCOASUB,
                    COA = new COA {
                        ID = this.intIDMasCOA,
                        strCode = this.txtChartOfAccountCode.Text,
                        strName = this.txtChartOfAccountsDescription.Text
                    },
                    COASub = new COASub {
                        ID = this.intIDMasCOASUB,
                        strCoaSubCode = this.txtChartOfAccountSubdiaryCode.Text,
                        strCoaSubName = this.txtChartOfAccountsSubsidiaryDescription.Text
                    },
                    curCredit = double.TryParse(this.txtCredit.Text , out doubleParser) ? doubleParser : 0,
                    curDebit = double.TryParse(this.txtDebit.Text, out doubleParser) ? doubleParser : 0,
                };

                this.DialogResult = DialogResult.OK;
            
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.intIDMasCOA = 0;
            this.intIDMasCOASUB = 0;
            this.txtChartOfAccountCode.Text = string.Empty;
            this.txtChartOfAccountsDescription.Text = string.Empty;
            this.txtChartOfAccountSubdiaryCode.Text = string.Empty;
            this.txtChartOfAccountsSubsidiaryDescription.Text = string.Empty;
            //this.txtCredit.Text = string.Empty;
            this.txtCredit.Text = string.Empty;
            this.txtDebit.Text = string.Empty;
        }

        private void metroTextBox2_Leave(object sender, EventArgs e)
        {

        }

        private void txtDebit_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(this.txtDebit.Text, out value))
                this.txtDebit.Text = value.ToString("N", CultureInfo.InvariantCulture);
            // this.txtDebit.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", value);
            else
                this.txtDebit.Text = String.Empty;
        }

        private void txtCredit_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(this.txtCredit.Text, out value))
                this.txtCredit.Text = value.ToString("N", CultureInfo.InvariantCulture);

            //this.txtCredit.Text = value.ToString();
            else
                this.txtCredit.Text = String.Empty;
        }
    }
}
