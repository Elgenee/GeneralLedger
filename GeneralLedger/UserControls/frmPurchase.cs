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
using DevComponents.DotNetBar.Controls;

namespace GeneralLedger.UserControls
{
    public partial class frmPurchase : MetroUserControl
    {

        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }
        public Purchase Purchase { get; set; }
        public PurchaseServices PurchaseServices { get; set; }
        public GLTranServices GLTranServices { get; set; }

        public tblTBBatchHdrServices tblTBBatchHdrServices { get; set; }

        public int ID { get; set; }
        public int GLTranHeader { get; set; }
        public int SupplierId { get; set; }
        public List<tblGLTranDetail> GLTranDetail { get; set; }
        public int IndexGrid { get; set; }

        public List<PurchaseDetail> PurchaseDetailsList  { get; set; }

        public frmPurchase()
        {
            InitializeComponent();
            PurchaseServices = new PurchaseServices();
            GLTranDetail = new List<tblGLTranDetail>();
            GLTranServices = new GLTranServices();
            PurchaseDetailsList = new List<PurchaseDetail>();
            GLTranHeader = 0;
            SupplierId = 0;
            this.Purchase = new Purchase();
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
                if (this.SupplierId == 0)
                {
                    MessageBox.Show("Please select supplier...");
                    return;
                }

                int intParser;
                decimal decimalParser;

                var isLock = tblTBBatchHdrServices.CheckIfLock(this.dtTransactionDate.Value);

                if (isLock)
                {
                    MessageBox.Show("Already lock...");
                    return;
                }

                string TransType = (this.ID == 0) ? "insert" : "update";

                if (TransType.Equals("insert"))
                {
                    Purchase = new Purchase {
                     Id = this.ID,
                     PONo = this.txtPONo.Text,
                     SIDR = this.txtSIDR.Text,
                     TRANo = this.txtTransactionNo.Text,
                     intIDSupplier = this.SupplierId,
                     Total = decimal.TryParse(this.txtTotal.Text, out decimalParser) ? decimalParser : 0,
                     TransactionDate = this.dtTransactionDate.Value,
                     Description = this.txtDescription.Text
                    };

                    Purchase = PurchaseServices.Add(Purchase, this.GLTranDetail, this.chkUseDefaultEntry.Checked);

                    if (Purchase != null)
                    {
                        MessageBox.Show("Successfully saved");
                    }
                }
                else {

                    Purchase.PONo = this.txtPONo.Text;
                    Purchase.SIDR = this.txtSIDR.Text;
                    Purchase.TRANo = this.txtTransactionNo.Text;
                    Purchase.intIDSupplier = this.SupplierId;
                    Purchase.Description = this.txtDescription.Text;
                    Purchase.Total = decimal.TryParse(this.txtTotal.Text, out decimalParser) ? decimalParser : 0;
                    Purchase.TransactionDate = this.dtTransactionDate.Value;
                    Purchase = PurchaseServices.Update(Purchase, this.GLTranDetail, this.chkUseDefaultEntry.Checked);

                    if (Purchase != null)
                    {
                        MessageBox.Show("Successfully saved");
                    }

                }
                GLTranHeader = Purchase.tblGLTranHeaders.Select(h => h.ID).SingleOrDefault();
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

                this.ID = Purchase.Id;
                this.txtID.Text = Purchase.Id.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnSearchSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                double doubleParser;
                SearchSupplier ss = new SearchSupplier();
                ss.BringToFront();
                ss.TopMost = true;
                DialogResult res = ss.ShowDialog(this);

                if (res == DialogResult.OK)
                {
                    //this.ID = sc.customerName.ID;
                    //this.txtID.Text = sc.customerName.ID.ToString();
                    //this.ID = ss.Supplier.ID;
                    this.txtSupplierID.Text = ss.Supplier.ID.ToString();
                    this.txtSupplierName.Text = ss.Supplier.Name;
                    this.SupplierId = ss.Supplier.ID;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void chkUseDefaultEntry_Click(object sender, EventArgs e)
        {
            if (this.chkUseDefaultEntry.Checked)
            {
                this.btnAddEntry.Enabled = false;
                this.btnDeleteEntry.Enabled = false;
            }
            else
            {
                this.btnAddEntry.Enabled = true;
                this.btnDeleteEntry.Enabled = true;
            }
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

        private void dgJournalEntry_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.IndexGrid = e.RowIndex;
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
                SearchPurchase sp = new SearchPurchase();
                sp.BringToFront();
                sp.TopMost = true;
                sp.IsPurchase = true;
                DialogResult res = sp.ShowDialog(this);

                if (res == DialogResult.OK)
                {
                    this.ID = sp.Purchase.Id;
                    this.Purchase.Id = sp.Purchase.Id;
                    this.txtID.Text = sp.Purchase.Id.ToString();
                    this.txtTransactionNo.Text = sp.Purchase.TRANo;
                    this.txtPONo.Text = sp.Purchase.PONo;
                    this.dtTransactionDate.Value = (DateTime)sp.Purchase.TransactionDate;
                    this.txtTotal.Text = sp.Purchase.Total.ToString();
                    this.txtDescription.Text = sp.Purchase.Description.ToString();
                    this.txtSIDR.Text = sp.Purchase.SIDR.ToString();
                    this.txtSupplierID.Text = sp.Purchase.intIDSupplier.ToString();
                    this.SupplierId = sp.Purchase.Supplier.Id;
                    this.txtSupplierName.Text = sp.Purchase.Supplier.strName;
                    this.GLTranHeader = sp.Purchase.tblGLTranHeaders.Select(h => h.ID).FirstOrDefault();
                    this.chkUseDefaultEntry.Checked = (bool)sp.Purchase.tblGLTranHeaders.Select(h => h.blnUseDefaultEntry).FirstOrDefault();
                    this.GLTranDetail = GLTranServices.GetGLEntryById(this.GLTranHeader).SelectMany(h => h.tblGLTranDetails).ToList();


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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int intParser;
                decimal decimalParser;

                var isLock = tblTBBatchHdrServices.CheckIfLock(this.dtTransactionDate.Value);

                if (isLock)
                {
                    MessageBox.Show("Already lock...");
                    return;
                }

                string TransType = (this.ID > 0) ? "delete" : String.Empty;
                if (TransType.Equals("delete"))
                {
                    Purchase = new Purchase
                    {
                        Id = this.ID,
                        PONo = this.txtPONo.Text,
                        SIDR = this.txtSIDR.Text,
                        TRANo = this.txtTransactionNo.Text,
                        intIDSupplier = this.SupplierId,
                        Total = decimal.TryParse(this.txtTotal.Text, out decimalParser) ? decimalParser : 0,
                        TransactionDate = this.dtTransactionDate.Value,
                        Description = this.txtDescription.Text
                    };

                   PurchaseServices.Remove(Purchase);

                    if (Purchase != null)
                    {
                        this.ID = 0;
                        this.txtID.Text = string.Empty;
                        this.Purchase.Id = 0;
                        this.txtTransactionNo.Text = String.Empty;
                        this.txtPONo.Text = String.Empty;
                        this.txtTotal.Text = String.Empty;
                        this.txtDescription.Text = String.Empty;
                        this.txtSIDR.Text = String.Empty;
                        this.txtSupplierID.Text = String.Empty;
                        this.SupplierId = 0;
                        this.txtSupplierName.Text = String.Empty;
                        this.GLTranHeader = 0;
                        this.txtTotalDebit.Text = string.Empty;
                        this.txtTotalCredit.Text = string.Empty;
                        this.chkUseDefaultEntry.Checked = true;
                        this.dgJournalEntry.Rows.Clear();
                        this.dgJournalEntry.Refresh();
                        this.GLTranDetail.Clear();
                        GLTranDetail = new List<tblGLTranDetail>();
                        MessageBox.Show("Successfully deleted");

                    }

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
            this.Purchase.Id = 0;
            this.txtTransactionNo.Text = String.Empty;
            this.txtPONo.Text = String.Empty;
            this.txtTotal.Text = String.Empty;
            this.txtDescription.Text = String.Empty;
            this.txtSIDR.Text = String.Empty;
            this.txtSupplierID.Text = String.Empty;
            this.SupplierId = 0;
            this.txtSupplierName.Text = String.Empty;
            this.GLTranHeader = 0;
            this.txtTotalDebit.Text = string.Empty;
            this.txtTotalCredit.Text = string.Empty;
            this.chkUseDefaultEntry.Checked = true;
            this.dgJournalEntry.Rows.Clear();
            this.dgJournalEntry.Refresh();
            this.GLTranDetail.Clear();
            GLTranDetail = new List<tblGLTranDetail>();

        }

        private void btnViewLedger_Click(object sender, EventArgs e)
        {

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
        
            frmChooseProduct frmChooseProduct = new frmChooseProduct();
            frmChooseProduct.BringToFront();
            frmChooseProduct.TopMost = true;
            DialogResult res = frmChooseProduct.ShowDialog(this);

            if (res == DialogResult.OK)
            {

                var convertPurchaseDetail = new PurchaseDetail
                {
                     ProductId = frmChooseProduct.Product.Id,
                     //assign frmChooseProduct.Product to Product
                     Product = frmChooseProduct.Product,
                     //UnitPrice = frmChooseProduct.Product.curUnitPrice,
                     Quantity = frmChooseProduct.ProductQuantity,
                     TotalPrice = frmChooseProduct.ProductTotalQuantityPrice
                };

                this.PurchaseDetailsList.Add(convertPurchaseDetail);

                if (PurchaseDetailsList.Count > 0)
                {

                    this.dgInventory.Rows.Clear();
                    this.dgInventory.Refresh();

                }

            }
        }
    }
}
