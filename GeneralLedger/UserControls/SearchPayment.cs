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
    public partial class SearchPayment : MetroForm
    {

        public Payment Payment { get; set; }
        public PaymentServices PaymentServices { get; set; }
        public int Index { get; set; }
        public SearchPayment()
        {
            InitializeComponent();
            PaymentServices = new PaymentServices();
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
                var paymentResult = PaymentServices.GetPaymentWithPurchaseBank(this.txtCriteria.Text);
                if ((paymentResult != null) && paymentResult.Count > 0)
                {
                    //this.dgSearchCustomer.ColumnCount = 9; string.Format("{0:0.00}", saleResult[i].Total)
                    this.dgSearchPayment.RowCount = paymentResult.Count;

                    for (int i = 0; i < paymentResult.Count; i++)
                    {

                        this.dgSearchPayment.Rows[i].Cells["ID"].Value = paymentResult[i].Id;
                        this.dgSearchPayment.Rows[i].Cells["PaymentCV"].Value = paymentResult[i].PaymentCV;
                        this.dgSearchPayment.Rows[i].Cells["PaymentSIDR"].Value = paymentResult[i].PaymentSIDR;
                        this.dgSearchPayment.Rows[i].Cells["PaymentTransactionDate"].Value = paymentResult[i].PaymentTransactionDate.Value.ToShortDateString();
                        this.dgSearchPayment.Rows[i].Cells["PaymentTotalAmount"].Value = string.Format("{0:0.00}", paymentResult[i].PaymentTotal);
                        this.dgSearchPayment.Rows[i].Cells["IsCash"].Value = paymentResult[i].PaymentIsCash;
                        this.dgSearchPayment.Rows[i].Cells["PurchaseId"].Value = paymentResult[i].PurchaseId;
                        this.dgSearchPayment.Rows[i].Cells["SupplierId"].Value = paymentResult[i].Purchase.intIDSupplier;
                        this.dgSearchPayment.Rows[i].Cells["Supplier"].Value = paymentResult[i].Purchase.Supplier.strName;
                        this.dgSearchPayment.Rows[i].Cells["PurchaseTransactionNo"].Value = paymentResult[i].Purchase.TRANo;
                        this.dgSearchPayment.Rows[i].Cells["PONo"].Value = paymentResult[i].Purchase.PONo;
                        this.dgSearchPayment.Rows[i].Cells["PurchaseSIDR"].Value = paymentResult[i].Purchase.SIDR;
                        this.dgSearchPayment.Rows[i].Cells["PurchaseTotalAmount"].Value = paymentResult[i].Purchase.Total;
                        this.dgSearchPayment.Rows[i].Cells["BankAccountId"].Value = paymentResult[i].Bank.Id;
                        this.dgSearchPayment.Rows[i].Cells["BankAccount"].Value = paymentResult[i].Bank.strName;
                        this.dgSearchPayment.Rows[i].Cells["CheckDetails"].Value = paymentResult[i].PaymentCheckDetail;
                        this.dgSearchPayment.Rows[i].Cells["Description"].Value = paymentResult[i].PaymentDescription;
                        this.dgSearchPayment.Rows[i].Cells["GLTranHeaderID"].Value = paymentResult[i].tblGLTranHeaders.Select(h => h.ID).FirstOrDefault();
                        this.dgSearchPayment.Rows[i].Cells["UseDefaultEntry"].Value = paymentResult[i].tblGLTranHeaders.Select(h => h.blnUseDefaultEntry).FirstOrDefault();

                    }

                    setRowNumber(this.dgSearchPayment);
                }
                else
                {

                    this.dgSearchPayment.Rows.Clear();
                    this.dgSearchPayment.Refresh();
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
                this.Index = this.dgSearchPayment.CurrentCell.RowIndex;

                if (Index >= 0)
                {
                    this.Payment = new Payment { 
                        Id = Int32.Parse(this.dgSearchPayment.Rows[this.Index].Cells["ID"].Value.ToString()),
                        PaymentCV = this.dgSearchPayment.Rows[this.Index].Cells["PaymentCV"].Value.ToString(),
                        PaymentSIDR = this.dgSearchPayment.Rows[this.Index].Cells["PaymentSIDR"].Value.ToString(),
                        PaymentTransactionDate = Convert.ToDateTime(this.dgSearchPayment.Rows[this.Index].Cells["PaymentTransactionDate"].Value.ToString()),
                        PaymentTotal = Convert.ToDecimal(this.dgSearchPayment.Rows[this.Index].Cells["PaymentTotalAmount"].Value.ToString()),
                        PaymentIsCash = Convert.ToBoolean(this.dgSearchPayment.Rows[this.Index].Cells["IsCash"].Value.ToString()),
                        PurchaseId = Int32.Parse(this.dgSearchPayment.Rows[this.Index].Cells["PurchaseId"].Value.ToString()),
                        Purchase = new Purchase { 
                             Id = Int32.Parse(this.dgSearchPayment.Rows[this.Index].Cells["PurchaseId"].Value.ToString()),
                             TRANo = this.dgSearchPayment.Rows[this.Index].Cells["PurchaseTransactionNo"].Value.ToString(),
                             intIDSupplier = Int32.Parse(this.dgSearchPayment.Rows[this.Index].Cells["SupplierId"].Value.ToString()),
                             Supplier = new Supplier {
                                 Id = Int32.Parse(this.dgSearchPayment.Rows[this.Index].Cells["SupplierId"].Value.ToString()),
                                 strName = this.dgSearchPayment.Rows[this.Index].Cells["Supplier"].Value.ToString(),
                             },
                             PONo = this.dgSearchPayment.Rows[this.Index].Cells["PONo"].Value.ToString(),
                             SIDR = this.dgSearchPayment.Rows[this.Index].Cells["PurchaseSIDR"].Value.ToString(),
                             Total = Convert.ToDecimal(this.dgSearchPayment.Rows[this.Index].Cells["PurchaseTotalAmount"].Value.ToString())
                        },
                        PaymentBankId = Int32.Parse(this.dgSearchPayment.Rows[this.Index].Cells["BankAccountId"].Value.ToString()),
                        Bank = new Core.Domain.Bank { 
                             Id = Int32.Parse(this.dgSearchPayment.Rows[this.Index].Cells["BankAccountId"].Value.ToString()),
                             strAccountName = this.dgSearchPayment.Rows[this.Index].Cells["BankAccount"].Value.ToString(),

                        },
                        PaymentCheckDetail = this.dgSearchPayment.Rows[this.Index].Cells["CheckDetails"].Value.ToString(),
                        PaymentDescription = this.dgSearchPayment.Rows[this.Index].Cells["Description"].Value.ToString(),
                        tblGLTranHeaders = new List<tblGLTranHeader> {
                            new tblGLTranHeader {
                             ID = Int32.Parse(this.dgSearchPayment.Rows[this.Index].Cells["GLTranHeaderID"].Value.ToString()),
                             blnUseDefaultEntry = bool.Parse(this.dgSearchPayment.Rows[this.Index].Cells["UseDefaultEntry"].Value.ToString())
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
