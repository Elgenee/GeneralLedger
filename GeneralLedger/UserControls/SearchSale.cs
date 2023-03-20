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
                int intParser;
                if ((saleResult != null) && saleResult.Count > 0)
                {
                    //this.dgSearchCustomer.ColumnCount = 9;
                    this.dgSearchSale.RowCount = saleResult.Count;
                 
                    for (int i = 0; i < saleResult.Count; i++)
                    {

                        this.dgSearchSale.Rows[i].Cells["ID"].Value = ReferenceEquals(saleResult[i].Id, DBNull.Value) ? 0 : saleResult[i].Id; 
                        this.dgSearchSale.Rows[i].Cells["TransactionNo"].Value = saleResult[i].TRANo;
                        this.dgSearchSale.Rows[i].Cells["PONo"].Value = saleResult[i].PONo;
                        this.dgSearchSale.Rows[i].Cells["TransactionDate"].Value = saleResult[i].TransactionDate.Value.ToShortDateString();
                        this.dgSearchSale.Rows[i].Cells["Total"].Value = string.Format("{0:0.00}", saleResult[i].Total);
                        this.dgSearchSale.Rows[i].Cells["CustomerId"].Value = saleResult[i].Customer.Id;
                        this.dgSearchSale.Rows[i].Cells["Customer"].Value = saleResult[i].Customer.strName;
                        this.dgSearchSale.Rows[i].Cells["Terms"].Value = ReferenceEquals(saleResult[i].Terms, DBNull.Value) ? 0 : saleResult[i].Terms;  
                        this.dgSearchSale.Rows[i].Cells["AgentId"].Value = saleResult[i].Agent.Id;
                        this.dgSearchSale.Rows[i].Cells["Agent"].Value = saleResult[i].Agent.Name;
                        this.dgSearchSale.Rows[i].Cells["Description"].Value = saleResult[i].Description;
                        this.dgSearchSale.Rows[i].Cells["GLTranHeaderID"].Value = saleResult[i].tblGLTranHeaders.Select(h => h.ID).FirstOrDefault();
                        this.dgSearchSale.Rows[i].Cells["UseDefaultEntry"].Value = saleResult[i].tblGLTranHeaders.Select(h => h.blnUseDefaultEntry).FirstOrDefault();
                        this.dgSearchSale.Rows[i].Cells["SOPAmount"].Value = saleResult[i].SOPAmount;
                        this.dgSearchSale.Rows[i].Cells["CFAmount"].Value = saleResult[i].CFAmount;
                        this.dgSearchSale.Rows[i].Cells["COMMAmount"].Value = saleResult[i].COMMAmount;
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
                    var test = DateTime.MinValue;
                    var id = ReferenceEquals(this.dgSearchSale.Rows[this.Index].Cells["ID"].Value, DBNull.Value) ? 0 : Convert.ToInt32(this.dgSearchSale.Rows[this.Index].Cells["ID"].Value);  
                    var TRANo = ReferenceEquals(this.dgSearchSale.Rows[this.Index].Cells["TransactionNo"].Value, DBNull.Value) ? string.Empty : Convert.ToString(this.dgSearchSale.Rows[this.Index].Cells["TransactionNo"].Value);
                    var PONo = ReferenceEquals(this.dgSearchSale.Rows[this.Index].Cells["PONo"].Value, DBNull.Value) ? string.Empty : Convert.ToString(this.dgSearchSale.Rows[this.Index].Cells["PONo"].Value);  
                    var TransactionDate = ReferenceEquals(this.dgSearchSale.Rows[this.Index].Cells["TransactionDate"].Value, DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(this.dgSearchSale.Rows[this.Index].Cells["TransactionDate"].Value); 
                    var Total = ReferenceEquals(this.dgSearchSale.Rows[this.Index].Cells["Total"].Value, DBNull.Value) ? 0 : Convert.ToDecimal(this.dgSearchSale.Rows[this.Index].Cells["Total"].Value); 
                    var intIdCustomer = ReferenceEquals(this.dgSearchSale.Rows[this.Index].Cells["CustomerId"].Value, DBNull.Value) ? 0 : Convert.ToInt32(this.dgSearchSale.Rows[this.Index].Cells["CustomerId"].Value);  
                    var intIdAgent = ReferenceEquals(this.dgSearchSale.Rows[this.Index].Cells["AgentId"].Value, DBNull.Value) ? 0 : Convert.ToInt32(this.dgSearchSale.Rows[this.Index].Cells["AgentId"].Value);  
                    var Description = ReferenceEquals(this.dgSearchSale.Rows[this.Index].Cells["Description"].Value, DBNull.Value) ? string.Empty : Convert.ToString(this.dgSearchSale.Rows[this.Index].Cells["Description"].Value);  
                    var Terms = ReferenceEquals(this.dgSearchSale.Rows[this.Index].Cells["Terms"].Value , DBNull.Value) ? 0: Convert.ToInt32(this.dgSearchSale.Rows[this.Index].Cells["Terms"].Value);
                    var AgentId = ReferenceEquals(this.dgSearchSale.Rows[this.Index].Cells["AgentId"].Value, DBNull.Value) ? 0 : Convert.ToInt32(this.dgSearchSale.Rows[this.Index].Cells["AgentId"].Value);
                    var AgentName = ReferenceEquals(this.dgSearchSale.Rows[this.Index].Cells["Agent"].Value, DBNull.Value) ? string.Empty : Convert.ToString(this.dgSearchSale.Rows[this.Index].Cells["Agent"].Value);
                    var CustomerId = ReferenceEquals(this.dgSearchSale.Rows[this.Index].Cells["CustomerId"].Value, DBNull.Value) ? 0 : Convert.ToInt32(this.dgSearchSale.Rows[this.Index].Cells["CustomerId"].Value);
                    var Customer = ReferenceEquals(this.dgSearchSale.Rows[this.Index].Cells["Customer"].Value, DBNull.Value) ? string.Empty : Convert.ToString(this.dgSearchSale.Rows[this.Index].Cells["Customer"].Value);
                    var CustomerTerms = ReferenceEquals(this.dgSearchSale.Rows[this.Index].Cells["Terms"].Value, DBNull.Value) ? 0 : Convert.ToInt32(this.dgSearchSale.Rows[this.Index].Cells["Terms"].Value);
                    var GLTranHeaderID = ReferenceEquals(this.dgSearchSale.Rows[this.Index].Cells["GLTranHeaderID"].Value, DBNull.Value) ? 0 : Convert.ToInt32(this.dgSearchSale.Rows[this.Index].Cells["GLTranHeaderID"].Value);
                    var DefaultEntry = ReferenceEquals(this.dgSearchSale.Rows[this.Index].Cells["UseDefaultEntry"].Value, DBNull.Value) ? false : Convert.ToBoolean(this.dgSearchSale.Rows[this.Index].Cells["UseDefaultEntry"].Value);
                    var SOPAmount = ReferenceEquals(this.dgSearchSale.Rows[this.Index].Cells["SOPAmount"].Value, DBNull.Value) ? 0 : Convert.ToDecimal(this.dgSearchSale.Rows[this.Index].Cells["SOPAmount"].Value);
                    var CFAmount = ReferenceEquals(this.dgSearchSale.Rows[this.Index].Cells["CFAmount"].Value, DBNull.Value) ? 0 : Convert.ToDecimal(this.dgSearchSale.Rows[this.Index].Cells["CFAmount"].Value);
                    var COMMAmount = ReferenceEquals(this.dgSearchSale.Rows[this.Index].Cells["COMMAmount"].Value, DBNull.Value) ? 0 : Convert.ToDecimal(this.dgSearchSale.Rows[this.Index].Cells["COMMAmount"].Value);

                    this.Sale = new Sale { 
                         Id = id,
                         TRANo = TRANo,
                         PONo = PONo,
                         TransactionDate = TransactionDate,
                         Total = Total,
                         intIdCustomer = intIdCustomer,
                         intIdAgent = intIdAgent,
                         Description = Description,
                         Terms = Terms,
                         SOPAmount = SOPAmount,
                         CFAmount = CFAmount,
                         COMMAmount = COMMAmount,
                        Agent = new Agent
                        {
                            Id = AgentId,
                            Name = AgentName
                        },
                        Customer = new Customer
                        {
                            Id = CustomerId,
                            strName = Customer,
                            intTerms = CustomerTerms
                        },
                        tblGLTranHeaders = new List<tblGLTranHeader> {
                            new tblGLTranHeader {
                             ID = GLTranHeaderID,
                             blnUseDefaultEntry = DefaultEntry
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
