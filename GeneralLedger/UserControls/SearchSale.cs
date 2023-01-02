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
using GeneralLedger.Persistence.Services;
using GeneralLedger.Core.Domain;


namespace GeneralLedger.UserControls
{
    public partial class SearchSale : MetroForm
    {
        public Sale Sale { get; set; }
        public SaleServices SaleServices { get; set; }
        //public GeneralLedger.Tier.BO.customerName customerName { get; set; }
        public int Index { get; set; }

        public SearchSale()
        {
            InitializeComponent();
            SaleServices = new SaleServices();
        }

        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var saleResult = SaleServices.GetSaleWithCustomerAgent(this.txtCriteria.Text);
                //List<GeneralLedger.Tier.BO.customerName> customerList = customerBAL.getCustomer(this.txtCriteria.Text);

                if ((saleResult != null) && saleResult.Count > 0)
                {
                    //this.dgSearchCustomer.ColumnCount = 9;
                    this.dgSearchSale.RowCount = saleResult.Count;
                 
                    for (int i = 0; i < saleResult.Count; i++)
                    {

                        this.dgSearchSale.Rows[i].Cells["ID"].Value = saleResult[i].Id;
                        this.dgSearchSale.Rows[i].Cells["TransactionNo"].Value = saleResult[i].TRANo;
                        this.dgSearchSale.Rows[i].Cells["PONo"].Value = saleResult[i].PONo;
                        this.dgSearchSale.Rows[i].Cells["TransactionDate"].Value = saleResult[i].TransactionDate.Value.ToShortDateString();
                        this.dgSearchSale.Rows[i].Cells["Total"].Value = string.Format("{0:0.00}", saleResult[i].Total);
                        this.dgSearchSale.Rows[i].Cells["CustomerId"].Value = saleResult[i].Customer.Id;
                        this.dgSearchSale.Rows[i].Cells["Customer"].Value = saleResult[i].Customer.strName;
                        this.dgSearchSale.Rows[i].Cells["Terms"].Value = saleResult[i].Customer.intTerms;
                        this.dgSearchSale.Rows[i].Cells["AgentId"].Value = saleResult[i].Agent.Id;
                        this.dgSearchSale.Rows[i].Cells["Agent"].Value = saleResult[i].Agent.Name;
                        this.dgSearchSale.Rows[i].Cells["Description"].Value = saleResult[i].Description;
                        this.dgSearchSale.Rows[i].Cells["GLTranHeaderID"].Value = saleResult[i].tblGLTranHeaders.Select(h => h.ID).FirstOrDefault();
                        this.dgSearchSale.Rows[i].Cells["UseDefaultEntry"].Value = saleResult[i].tblGLTranHeaders.Select(h => h.blnUseDefaultEntry).FirstOrDefault();

                    }

                    setRowNumber(this.dgSearchSale);
                }
                else
                {

                    this.dgSearchSale.Rows.Clear();
                    this.dgSearchSale.Refresh();
                    MessageBox.Show("No Result");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

            try
            {
                this.Index = this.dgSearchSale.CurrentCell.RowIndex;

                if (Index >= 0)
                {
                    this.Sale = new Sale { 
                         Id = Int32.Parse(this.dgSearchSale.Rows[this.Index].Cells["ID"].Value.ToString()),
                         TRANo = this.dgSearchSale.Rows[this.Index].Cells["TransactionNo"].Value.ToString(),
                         PONo = this.dgSearchSale.Rows[this.Index].Cells["PONo"].Value.ToString(),
                         TransactionDate = Convert.ToDateTime(this.dgSearchSale.Rows[this.Index].Cells["TransactionDate"].Value.ToString()),
                         Total = Convert.ToDecimal(this.dgSearchSale.Rows[this.Index].Cells["Total"].Value.ToString()),
                         intIdCustomer = Int32.Parse(this.dgSearchSale.Rows[this.Index].Cells["CustomerId"].Value.ToString()),
                         intIdAgent = Int32.Parse(this.dgSearchSale.Rows[this.Index].Cells["AgentId"].Value.ToString()),
                         Description = this.dgSearchSale.Rows[this.Index].Cells["Description"].Value.ToString(),
                         Agent = new Agent { 
                            Id = Int32.Parse(this.dgSearchSale.Rows[this.Index].Cells["AgentId"].Value.ToString()),
                            Name = this.dgSearchSale.Rows[this.Index].Cells["Agent"].Value.ToString()
                         },
                         Customer = new Customer { 
                             Id = Int32.Parse(this.dgSearchSale.Rows[this.Index].Cells["CustomerId"].Value.ToString()),
                             strName = this.dgSearchSale.Rows[this.Index].Cells["Customer"].Value.ToString(),
                             intTerms = Int32.Parse(this.dgSearchSale.Rows[this.Index].Cells["Terms"].Value.ToString())
                         },
                        tblGLTranHeaders = new List<tblGLTranHeader> {
                            new tblGLTranHeader {
                             ID = Int32.Parse(this.dgSearchSale.Rows[this.Index].Cells["GLTranHeaderID"].Value.ToString()),
                             blnUseDefaultEntry = bool.Parse(this.dgSearchSale.Rows[this.Index].Cells["UseDefaultEntry"].Value.ToString())
                            }
                         }
                    };
       
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Select item");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }

        }
    }
}
