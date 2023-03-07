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
using GeneralLedger.Persistence.Services;
using GeneralLedger.Core.Domain;


namespace GeneralLedger.UserControls
{
    public partial class frmPayment : MetroUserControl
    {
        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }
        public Payment Payment { get; set; }
        public PaymentServices PaymentServices { get; set; }
        public GLTranServices GLTranServices { get; set; }
        public int ID { get; set; }
        public int PurchaseId { get; set; }
        public List<tblGLTranDetail> GLTranDetail { get; set; }

        public tblTBBatchHdrServices tblTBBatchHdrServices { get; set; }
        public int IndexGrid { get; set; }
        public int GLTranHeader { get; set; }


        //TODO:add total purchase when searching
        public frmPayment()
        {
            InitializeComponent();
            PaymentServices = new PaymentServices();
            GLTranServices = new GLTranServices();
            GLTranDetail = new List<tblGLTranDetail>();
            PurchaseId = 0;
            this.Payment = new Payment();
            tblTBBatchHdrServices = new tblTBBatchHdrServices();
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
                if (this.PurchaseId == 0)
                {
                    MessageBox.Show("Please select purchase...");
                    return;
                }

                if (this.GLTranDetail.Sum(d => d.curCredit) != this.GLTranDetail.Sum(d => d.curDebit))
                {
                    MessageBox.Show("Disbal journal entry");
                    return;
                }


                int intParser;
                decimal decimalParser;


                var isLock = tblTBBatchHdrServices.CheckIfLock(this.dtPaymentTransactionDate.Value);

                if (isLock)
                {
                    MessageBox.Show("Already lock...");
                    return;
                }

                string TransType = (this.ID == 0) ? "insert" : "update";
                int? bankId = null;

                bankId = (this.cbBank.SelectedItem == null) ? 0 : ((Tier.BO.Bank)this.cbBank.SelectedItem).ID;

                if (TransType.Equals("insert"))
                {
                    Payment = new Payment { 
                         Id = this.ID,
                         PaymentCV = this.txtPaymentCV.Text,
                         PaymentSIDR = this.txtPaymentSIDR.Text,
                         PaymentTransactionDate = this.dtPaymentTransactionDate.Value,
                         PaymentTotal = decimal.TryParse(this.txtPaymentTotal.Text, out decimalParser) ? decimalParser : 0,
                         PaymentCheckDetail = this.txtCheckDetails.Text,
                         PaymentBankId = bankId,
                         PaymentIsCash = this.chkIsCash.Checked,
                         PaymentDescription = this.txtDescription.Text,
                         PurchaseId = int.TryParse(this.txtPurchaseId.Text , out intParser)? intParser :0
                    };

                    Payment = PaymentServices.Add(Payment, this.GLTranDetail, this.chkUseDefaultEntry.Checked);

                    if (Payment != null)
                    {
                        MessageBox.Show("Successfully saved");
                    }
                }
                else
                {
                    Payment.Id = this.ID;
                    Payment.PaymentCV = this.txtPaymentCV.Text;
                    Payment.PaymentSIDR = this.txtPaymentSIDR.Text;
                    Payment.PaymentTransactionDate = this.dtPaymentTransactionDate.Value;
                    Payment.PaymentTotal = decimal.TryParse(this.txtPaymentTotal.Text, out decimalParser) ? decimalParser : 0;
                    Payment.PaymentCheckDetail = this.txtCheckDetails.Text;
                    Payment.PaymentBankId = bankId;
                    Payment.PaymentIsCash = this.chkIsCash.Checked;
                    Payment.PaymentDescription = this.txtDescription.Text;
                    Payment.PurchaseId = int.TryParse(this.txtPurchaseId.Text, out intParser) ? intParser : 0;
                    Payment = PaymentServices.Update(Payment, this.GLTranDetail, this.chkUseDefaultEntry.Checked);
                }

                GLTranHeader = Payment.tblGLTranHeaders.Select(h => h.ID).SingleOrDefault();
                this.GLTranDetail = GLTranServices.GetGLEntryById(GLTranHeader).SelectMany(h => h.tblGLTranDetails).ToList();
                if (GLTranDetail.Count > 0)
                {

                    this.dgJournalEntry.ColumnCount = 6;
                    this.dgJournalEntry.RowCount = GLTranDetail.Count;
                    //this.dgChartOfAccountsSubsidiary.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //this.dgChartOfAccountsSubsidiary.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    this.dgJournalEntry.Columns[0].Name = "COA";
                    this.dgJournalEntry.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    this.dgJournalEntry.Columns[1].Name = "COA Code";
                    this.dgJournalEntry.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgJournalEntry.Columns[2].Name = "COA Subsidiary";
                    this.dgJournalEntry.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgJournalEntry.Columns[3].Name = "COA Subsidiary Code";
                    this.dgJournalEntry.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgJournalEntry.Columns[4].Name = "Debit";
                    this.dgJournalEntry.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgJournalEntry.Columns[5].Name = "Credit";
                    this.dgJournalEntry.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    this.dgJournalEntry.Columns[0].ReadOnly = true;
                    this.dgJournalEntry.Columns[1].ReadOnly = true;
                    this.dgJournalEntry.Columns[2].ReadOnly = true;
                    this.dgJournalEntry.Columns[3].ReadOnly = true;
                    this.dgJournalEntry.Columns[4].ReadOnly = true;
                    this.dgJournalEntry.Columns[5].ReadOnly = true;
                    this.dgJournalEntry.Columns[1].Visible = false;
                    this.dgJournalEntry.Columns[3].Visible = false;

                    for (int i = 0; i < GLTranDetail.Count; i++)
                    {

                        this.dgJournalEntry.Rows[i].Cells[0].Value = GLTranDetail[i].tblMasCOA.strName;
                        this.dgJournalEntry.Rows[i].Cells[1].Value = GLTranDetail[i].tblMasCOA.strCode;
                        this.dgJournalEntry.Rows[i].Cells[2].Value = GLTranDetail[i].tblMasCOASub.strName;
                        this.dgJournalEntry.Rows[i].Cells[3].Value = GLTranDetail[i].tblMasCOASub.strCode;
                        this.dgJournalEntry.Rows[i].Cells[4].Value = string.Format("{0:0.00}", GLTranDetail[i].curDebit);
                        this.dgJournalEntry.Rows[i].Cells[5].Value = string.Format("{0:0.00}", GLTranDetail[i].curCredit);

                        this.dgJournalEntry.Rows[i].Cells[0].ReadOnly = true;
                        this.dgJournalEntry.Rows[i].Cells[1].ReadOnly = true;
                        this.dgJournalEntry.Rows[i].Cells[2].ReadOnly = true;
                        this.dgJournalEntry.Rows[i].Cells[3].ReadOnly = true;
                        this.dgJournalEntry.Rows[i].Cells[4].ReadOnly = true;
                        this.dgJournalEntry.Rows[i].Cells[5].ReadOnly = true;
                    }

                    setRowNumber(this.dgJournalEntry);

                    this.txtTotalDebit.Text = string.Format("{0:0.00}", GLTranDetail.Sum(g => g.curDebit));
                    this.txtTotalCredit.Text = string.Format("{0:0.00}", GLTranDetail.Sum(g => g.curCredit));
                }
                else
                {
                    this.dgJournalEntry.Rows.Clear();
                    this.dgJournalEntry.Refresh();
                    this.GLTranDetail.Clear();
                    this.txtTotalDebit.Text = string.Empty;
                    this.txtTotalCredit.Text = string.Empty;
                }

                this.ID = Payment.Id;
                this.txtPaymentId.Text = Payment.Id.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void cbBank_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmPayment_Load(object sender, EventArgs e)
        {

            BankBAL bankBAL = new BankBAL();
            var bankList = bankBAL.getBank(string.Empty);
            this.cbBank.DataSource = bankList;
            this.cbBank.ValueMember = "ID";
            this.cbBank.DisplayMember = "Name";
        }

        private void btnSearchSale_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchPurchase_Click(object sender, EventArgs e)
        {

            try
            {
                SearchPurchase sp = new SearchPurchase();
                sp.BringToFront();
                sp.TopMost = true;
                DialogResult res = sp.ShowDialog(this);

                if (res == DialogResult.OK)
                {
                    this.PurchaseId = sp.Purchase.Id;
                    this.txtPurchaseId.Text = sp.Purchase.Id.ToString();
                    this.txtSupplier.Text = sp.Purchase.Supplier.strName;
                    this.txtPurchasePONo.Text = sp.Purchase.PONo;
                    this.txtPurchaseSIDR.Text = sp.Purchase.SIDR;
                    this.txtPurchaseTotal.Text = sp.Purchase.Total.ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void txtPaymentTotal_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            SearchChartOfAccounts sca = new SearchChartOfAccounts();
            sca.IDGLTranHeader = GLTranHeader;
            sca.BringToFront();
            sca.TopMost = true;
            DialogResult res = sca.ShowDialog(this);

            if (res == DialogResult.OK)
            {

                var convertGLTranDetailDomain = new tblGLTranDetail
                {
                    intIDGLTranHeader = sca.GLTranDetail.intIDGLTranHeader,
                    intIDMasCoa = sca.GLTranDetail.intIDCOA,
                    intIDMasCoaSub = sca.GLTranDetail.intIDCOASub,
                    curCredit = Convert.ToDecimal(sca.GLTranDetail.curCredit),
                    curDebit = Convert.ToDecimal(sca.GLTranDetail.curDebit),
                    tblMasCOA = new tblMasCOA
                    {
                        ID = sca.GLTranDetail.COA.ID,
                        strCode = sca.GLTranDetail.COA.strCode,
                        strName = sca.GLTranDetail.COA.strName
                    },
                    tblMasCOASub = new tblMasCOASub
                    {
                        ID = sca.GLTranDetail.COASub.ID,
                        strCode = sca.GLTranDetail.COASub.strCoaSubCode,
                        strName = sca.GLTranDetail.COASub.strCoaSubName
                    }
                };

                GLTranDetail.Add(convertGLTranDetailDomain);

                if (GLTranDetail.Count > 0)
                {
                    this.dgJournalEntry.Rows.Clear();
                    this.dgJournalEntry.Refresh();

                    this.dgJournalEntry.ColumnCount = 6;
                    this.dgJournalEntry.RowCount = this.GLTranDetail.Count;

                    //this.dgChartOfAccountsSubsidiary.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //this.dgChartOfAccountsSubsidiary.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    this.dgJournalEntry.Columns[0].Name = "COA";
                    this.dgJournalEntry.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgJournalEntry.Columns[1].Name = "COA Code";
                    this.dgJournalEntry.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgJournalEntry.Columns[2].Name = "COA Subsidiary";
                    this.dgJournalEntry.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgJournalEntry.Columns[3].Name = "COA Subsidiary Code";
                    this.dgJournalEntry.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgJournalEntry.Columns[4].Name = "Debit";
                    this.dgJournalEntry.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgJournalEntry.Columns[5].Name = "Credit";
                    this.dgJournalEntry.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                    this.dgJournalEntry.Columns[0].ReadOnly = true;
                    this.dgJournalEntry.Columns[1].ReadOnly = true;
                    this.dgJournalEntry.Columns[2].ReadOnly = true;
                    this.dgJournalEntry.Columns[3].ReadOnly = true;
                    this.dgJournalEntry.Columns[4].ReadOnly = true;
                    this.dgJournalEntry.Columns[5].ReadOnly = true;
                    this.dgJournalEntry.Columns[1].Visible = false;
                    this.dgJournalEntry.Columns[3].Visible = false;

                    for (int i = 0; i < GLTranDetail.Count; i++)
                    {
                        this.dgJournalEntry.Rows[i].Cells[0].Value = GLTranDetail[i].tblMasCOA.strName;
                        this.dgJournalEntry.Rows[i].Cells[1].Value = GLTranDetail[i].tblMasCOA.strCode;
                        this.dgJournalEntry.Rows[i].Cells[2].Value = GLTranDetail[i].tblMasCOASub.strName;
                        this.dgJournalEntry.Rows[i].Cells[3].Value = GLTranDetail[i].tblMasCOASub.strCode;
                        this.dgJournalEntry.Rows[i].Cells[4].Value = string.Format("{0:0.00}", GLTranDetail[i].curDebit);
                        this.dgJournalEntry.Rows[i].Cells[5].Value = string.Format("{0:0.00}", GLTranDetail[i].curCredit);
                    }

                    setRowNumber(this.dgJournalEntry);

                    this.txtTotalDebit.Text = string.Format("{0:0.00}", GLTranDetail.Sum(g => g.curDebit));
                    this.txtTotalCredit.Text = string.Format("{0:0.00}", GLTranDetail.Sum(g => g.curCredit));
                }
            }
        }

        private void btnDeleteEntry_Click(object sender, EventArgs e)
        {
            try
            {
                if (GLTranDetail.Count > 0)
                {
                    GLTranDetail.RemoveAt(this.IndexGrid);
                    this.dgJournalEntry.Rows.Clear();
                    this.dgJournalEntry.Refresh();

                    if (this.GLTranDetail.Count == 0)
                    {
                        return;
                    }

                    this.dgJournalEntry.ColumnCount = 6;
                    this.dgJournalEntry.RowCount = this.GLTranDetail.Count;

                    this.dgJournalEntry.Columns[0].Name = "COA";
                    this.dgJournalEntry.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgJournalEntry.Columns[1].Name = "COA Code";
                    this.dgJournalEntry.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgJournalEntry.Columns[2].Name = "COA Subsidiary";
                    this.dgJournalEntry.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgJournalEntry.Columns[3].Name = "COA SubsidiaryCode";
                    this.dgJournalEntry.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgJournalEntry.Columns[4].Name = "Debit";
                    this.dgJournalEntry.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgJournalEntry.Columns[5].Name = "Credit";
                    this.dgJournalEntry.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    for (int i = 0; i < GLTranDetail.Count; i++)
                    {
                        this.dgJournalEntry.Rows[i].Cells[0].Value = GLTranDetail[i].tblMasCOA.strName;
                        this.dgJournalEntry.Rows[i].Cells[1].Value = GLTranDetail[i].tblMasCOA.strCode;
                        this.dgJournalEntry.Rows[i].Cells[2].Value = GLTranDetail[i].tblMasCOASub.strName;
                        this.dgJournalEntry.Rows[i].Cells[3].Value = GLTranDetail[i].tblMasCOASub.strCode;
                        this.dgJournalEntry.Rows[i].Cells[4].Value = string.Format("{0:0.00}", GLTranDetail[i].curDebit);
                        this.dgJournalEntry.Rows[i].Cells[5].Value = string.Format("{0:0.00}", GLTranDetail[i].curCredit);
                    }

                    setRowNumber(this.dgJournalEntry);

                    this.txtTotalDebit.Text = string.Format("{0:0.00}", GLTranDetail.Sum(g => g.curDebit));
                    this.txtTotalCredit.Text = string.Format("{0:0.00}", GLTranDetail.Sum(g => g.curCredit));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                SearchPayment sp = new SearchPayment();
                sp.BringToFront();
                sp.TopMost = true;
                DialogResult res = sp.ShowDialog(this);

                if (res == DialogResult.OK)
                {
                    this.ID = sp.Payment.Id;
                    this.Payment.Id = sp.Payment.Id;
                    this.txtPaymentId.Text = sp.Payment.Id.ToString();
                    this.txtPaymentCV.Text = sp.Payment.PaymentCV;
                    this.txtPaymentSIDR.Text = sp.Payment.PaymentSIDR;
                    this.dtPaymentTransactionDate.Value = (DateTime)sp.Payment.PaymentTransactionDate;
                    this.txtPaymentTotal.Text = sp.Payment.PaymentTotal.ToString();
                    this.chkIsCash.Checked = (bool)sp.Payment.PaymentIsCash;
                    this.txtDescription.Text = sp.Payment.PaymentDescription;
                    this.PurchaseId = (int)sp.Payment.PurchaseId;
                    this.txtPurchaseId.Text = sp.Payment.PurchaseId.ToString();
                    this.txtSupplier.Text = sp.Payment.Purchase.Supplier.strName;
                    this.txtPurchasePONo.Text = sp.Payment.Purchase.PONo.ToString();
                    this.txtPurchaseSIDR.Text = sp.Payment.Purchase.SIDR.ToString();
                    this.txtPurchaseTotal.Text = sp.Payment.Purchase.Total.ToString();
                    this.cbBank.SelectedValue = sp.Payment.PaymentBankId;
                    this.txtCheckDetails.Text = sp.Payment.PaymentCheckDetail;
                    this.GLTranHeader = sp.Payment.tblGLTranHeaders.Select(h => h.ID).FirstOrDefault();
                    this.GLTranDetail = GLTranServices.GetGLEntryById(this.GLTranHeader).SelectMany(h => h.tblGLTranDetails).ToList();
                    this.chkUseDefaultEntry.Checked = (bool)sp.Payment.tblGLTranHeaders.Select(h => h.blnUseDefaultEntry).FirstOrDefault();


                    if (GLTranDetail.Count > 0)
                    {

                        this.dgJournalEntry.ColumnCount = 6;
                        this.dgJournalEntry.RowCount = GLTranDetail.Count;
                        //this.dgChartOfAccountsSubsidiary.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        //this.dgChartOfAccountsSubsidiary.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        this.dgJournalEntry.Columns[0].Name = "COA";
                        this.dgJournalEntry.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        this.dgJournalEntry.Columns[1].Name = "COA Code";
                        this.dgJournalEntry.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.dgJournalEntry.Columns[2].Name = "COA Subsidiary";
                        this.dgJournalEntry.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.dgJournalEntry.Columns[3].Name = "COA Subsidiary Code";
                        this.dgJournalEntry.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.dgJournalEntry.Columns[4].Name = "Debit";
                        this.dgJournalEntry.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.dgJournalEntry.Columns[5].Name = "Credit";
                        this.dgJournalEntry.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        this.dgJournalEntry.Columns[0].ReadOnly = true;
                        this.dgJournalEntry.Columns[1].ReadOnly = true;
                        this.dgJournalEntry.Columns[2].ReadOnly = true;
                        this.dgJournalEntry.Columns[3].ReadOnly = true;
                        this.dgJournalEntry.Columns[4].ReadOnly = true;
                        this.dgJournalEntry.Columns[5].ReadOnly = true;
                        this.dgJournalEntry.Columns[1].Visible = false;
                        this.dgJournalEntry.Columns[3].Visible = false;

                        for (int i = 0; i < GLTranDetail.Count; i++)
                        {

                            this.dgJournalEntry.Rows[i].Cells[0].Value = GLTranDetail[i].tblMasCOA.strName;
                            this.dgJournalEntry.Rows[i].Cells[1].Value = GLTranDetail[i].tblMasCOA.strCode;
                            this.dgJournalEntry.Rows[i].Cells[2].Value = GLTranDetail[i].tblMasCOASub.strName;
                            this.dgJournalEntry.Rows[i].Cells[3].Value = GLTranDetail[i].tblMasCOASub.strCode;
                            this.dgJournalEntry.Rows[i].Cells[4].Value = string.Format("{0:0.00}", GLTranDetail[i].curDebit);
                            this.dgJournalEntry.Rows[i].Cells[5].Value = string.Format("{0:0.00}", GLTranDetail[i].curCredit);

                            this.dgJournalEntry.Rows[i].Cells[0].ReadOnly = true;
                            this.dgJournalEntry.Rows[i].Cells[1].ReadOnly = true;
                            this.dgJournalEntry.Rows[i].Cells[2].ReadOnly = true;
                            this.dgJournalEntry.Rows[i].Cells[3].ReadOnly = true;
                            this.dgJournalEntry.Rows[i].Cells[4].ReadOnly = true;
                            this.dgJournalEntry.Rows[i].Cells[5].ReadOnly = true;
                        }

                        setRowNumber(this.dgJournalEntry);

                        this.txtTotalDebit.Text = string.Format("{0:0.00}", GLTranDetail.Sum(g => g.curDebit));
                        this.txtTotalCredit.Text = string.Format("{0:0.00}", GLTranDetail.Sum(g => g.curCredit));
                    }
                    else
                    {
                        this.dgJournalEntry.Rows.Clear();
                        this.dgJournalEntry.Refresh();
                        this.GLTranDetail.Clear();
                        this.txtTotalDebit.Text = string.Empty;
                        this.txtTotalCredit.Text = string.Empty;
                    }

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
