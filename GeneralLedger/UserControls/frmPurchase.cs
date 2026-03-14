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
using System.Runtime.InteropServices.WindowsRuntime;

namespace GeneralLedger.UserControls
{
    public partial class frmPurchase : MetroUserControl
    {

        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }
        public Purchase Purchase { get; set; }
        public PurchaseServices PurchaseServices { get; set; }

        public PurchaseDetailServices PurchaseDetailServices { get; set; }
        public GLTranServices GLTranServices { get; set; }
        public tblTBBatchHdrServices tblTBBatchHdrServices { get; set; }

        public int ID { get; set; }
        public int GLTranHeader { get; set; }
        public int SupplierId { get; set; }
        public List<tblGLTranDetail> GLTranDetail { get; set; }

        public List<tblGLTranDetail> GLTranDetailInventoryEntry { get; set; }

        public int IndexGrid { get; set; }

        public int IndexGridInventory { get; set; }

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
            PurchaseDetailServices = new PurchaseDetailServices();

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

                if (this.PurchaseDetailsList.Count <= 0)
                {
                    MessageBox.Show("Please check the products");
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
                     AdditionalDescription = this.txtAdditionalDescription.Text,
                     Description = this.txtDescription.Text
                    };

                    Purchase = PurchaseServices.Add(Purchase, this.GLTranDetail, this.chkUseDefaultEntry.Checked, this.PurchaseDetailsList);
                    this.PurchaseDetailsList = Purchase.PurchaseDetails.ToList();

                    if (Purchase != null)
                    {
                        MessageBox.Show("Successfully saved");
                        this.txtDescription.Text = Purchase.Description;
                    }
                }
                else {

                    Purchase.PONo = this.txtPONo.Text;
                    Purchase.SIDR = this.txtSIDR.Text;
                    Purchase.TRANo = this.txtTransactionNo.Text;
                    Purchase.intIDSupplier = this.SupplierId;
                    Purchase.AdditionalDescription = this.txtAdditionalDescription.Text;
                    Purchase.Description = this.txtDescription.Text;
                    Purchase.Total = decimal.TryParse(this.txtTotal.Text, out decimalParser) ? decimalParser : 0;
                    Purchase.TransactionDate = this.dtTransactionDate.Value;       
                    Purchase = PurchaseServices.Update(Purchase, this.GLTranDetail, this.chkUseDefaultEntry.Checked, this.PurchaseDetailsList);
                    this.PurchaseDetailsList = Purchase.PurchaseDetails.ToList();
                    if (Purchase != null)
                    {
                        if (this.PurchaseDetailsList.Count <= 0)
                        {
                            this.txtPurchaseTotal.Text = string.Empty;
                        }
                        MessageBox.Show("Successfully saved");
                        this.txtDescription.Text = Purchase.Description;

                    }

                }
                //GLTranHeader = Purchase.tblGLTranHeaders.Select(h => h.ID).SingleOrDefault();
                //my local 11 is purchase ID and for the server is 9
                this.GLTranDetail = GLTranServices.GetGLEntryByPurchaseId(Purchase.Id, 9).SelectMany(h => h.tblGLTranDetails).ToList();
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

                this.GLTranDetailInventoryEntry = GLTranServices.GetGLEntryByPurchaseId(Purchase.Id, 1011).SelectMany(h => h.tblGLTranDetails).ToList();
                if (GLTranDetailInventoryEntry.Count > 0)
                {
                 
                    this.dgInventoryEntry.ColumnCount = 6;
                    this.dgInventoryEntry.RowCount = GLTranDetailInventoryEntry.Count;
                    //this.dgChartOfAccountsSubsidiary.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //this.dgChartOfAccountsSubsidiary.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    this.dgInventoryEntry.Columns[0].Name = "COA";
                    this.dgInventoryEntry.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    this.dgInventoryEntry.Columns[1].Name = "COA Code";
                    this.dgInventoryEntry.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgInventoryEntry.Columns[2].Name = "COA Subsidiary";
                    this.dgInventoryEntry.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgInventoryEntry.Columns[3].Name = "COA Subsidiary Code";
                    this.dgInventoryEntry.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgInventoryEntry.Columns[4].Name = "Debit";
                    this.dgInventoryEntry.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dgInventoryEntry.Columns[5].Name = "Credit";
                    this.dgInventoryEntry.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    this.dgInventoryEntry.Columns[0].ReadOnly = true;
                    this.dgInventoryEntry.Columns[1].ReadOnly = true;
                    this.dgInventoryEntry.Columns[2].ReadOnly = true;
                    this.dgInventoryEntry.Columns[3].ReadOnly = true;
                    this.dgInventoryEntry.Columns[4].ReadOnly = true;
                    this.dgInventoryEntry.Columns[5].ReadOnly = true;
                    this.dgInventoryEntry.Columns[1].Visible = false;
                    this.dgInventoryEntry.Columns[3].Visible = false;

                    for (int i = 0; i < GLTranDetailInventoryEntry.Count; i++)
                    {

                        this.dgInventoryEntry.Rows[i].Cells[0].Value = GLTranDetailInventoryEntry[i].tblMasCOA.strName;
                        this.dgInventoryEntry.Rows[i].Cells[1].Value = GLTranDetailInventoryEntry[i].tblMasCOA.strCode;
                        this.dgInventoryEntry.Rows[i].Cells[2].Value = GLTranDetailInventoryEntry[i].tblMasCOASub.strName;
                        this.dgInventoryEntry.Rows[i].Cells[3].Value = GLTranDetailInventoryEntry[i].tblMasCOASub.strCode;
                        this.dgInventoryEntry.Rows[i].Cells[4].Value = string.Format("{0:0.00}", GLTranDetailInventoryEntry[i].curDebit);
                        this.dgInventoryEntry.Rows[i].Cells[5].Value = string.Format("{0:0.00}", GLTranDetailInventoryEntry[i].curCredit);

                        this.dgInventoryEntry.Rows[i].Cells[0].ReadOnly = true;
                        this.dgInventoryEntry.Rows[i].Cells[1].ReadOnly = true;
                        this.dgInventoryEntry.Rows[i].Cells[2].ReadOnly = true;
                        this.dgInventoryEntry.Rows[i].Cells[3].ReadOnly = true;
                        this.dgInventoryEntry.Rows[i].Cells[4].ReadOnly = true;
                        this.dgInventoryEntry.Rows[i].Cells[5].ReadOnly = true;
                    }

                    setRowNumber(this.dgInventoryEntry);

                    this.txtTotalInventoryDebit.Text = string.Format("{0:0.00}", GLTranDetailInventoryEntry.Sum(g => g.curDebit));
                    this.txtTotalInventoryCredit.Text = string.Format("{0:0.00}", GLTranDetailInventoryEntry.Sum(g => g.curCredit));
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
                    this.txtAdditionalDescription.Text = sp.Purchase.AdditionalDescription.ToString();
                    this.txtDescription.Text = sp.Purchase.Description.ToString();
                    this.txtSIDR.Text = sp.Purchase.SIDR.ToString();
                    this.txtSupplierID.Text = sp.Purchase.intIDSupplier.ToString();
                    this.SupplierId = sp.Purchase.Supplier.Id;
                    this.txtSupplierName.Text = sp.Purchase.Supplier.strName;
                    this.GLTranHeader = sp.Purchase.tblGLTranHeaders.Select(h => h.ID).FirstOrDefault();
                    this.chkUseDefaultEntry.Checked = (bool)sp.Purchase.tblGLTranHeaders.Select(h => h.blnUseDefaultEntry).FirstOrDefault();
                    this.GLTranDetail = GLTranServices.GetGLEntryById(this.GLTranHeader).SelectMany(h => h.tblGLTranDetails).ToList();
                    this.PurchaseDetailsList = PurchaseDetailServices.GetPurchaseDetailProductByPurchaseId(this.ID).SelectMany(pr => pr.PurchaseDetails).ToList();
                    //this.Purchase.PurchaseDetails.Concat(this.PurchaseDetailsList);

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


                    if (PurchaseDetailsList.Count > 0)
                    {

                        this.dgProduct.Rows.Clear();
                        this.dgProduct.Refresh();
                        //this.dgProduct.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        this.dgProduct.RowCount = PurchaseDetailsList.Count;
                        this.dgProduct.ColumnCount = 30;
                        this.dgProduct.Columns[0].Name = "ID";
                        this.dgProduct.Columns[0].Visible = false;
                        this.dgProduct.Columns[1].Name = "Product Name";
                        this.dgProduct.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        this.dgProduct.Columns[2].Visible = false;
                        this.dgProduct.Columns[2].Name = "Description";
                        this.dgProduct.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        this.dgProduct.Columns[3].Name = "Product Characteristic ID";
                        this.dgProduct.Columns[3].Visible = false;
                        this.dgProduct.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        this.dgProduct.Columns[4].Name = "Product Characteristic Name";
                        this.dgProduct.Columns[4].Visible = false;
                        this.dgProduct.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        this.dgProduct.Columns[5].Name = "Product Category ID";
                        this.dgProduct.Columns[5].Visible = false;
                        this.dgProduct.Columns[6].Name = "Product Category Name";
                        this.dgProduct.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        this.dgProduct.Columns[7].Name = "Product Type ID";
                        this.dgProduct.Columns[7].Visible = false;
                        this.dgProduct.Columns[8].Name = "Product Type Name";
                        this.dgProduct.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        this.dgProduct.Columns[9].Name = "Product Brand ID";
                        this.dgProduct.Columns[9].Visible = false;
                        this.dgProduct.Columns[10].Name = "Product Brand Name";
                        this.dgProduct.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        this.dgProduct.Columns[11].Name = "Per Piece Box";
                        this.dgProduct.Columns[11].Visible = false;
                        this.dgProduct.Columns[12].Name = "Location ID";
                        this.dgProduct.Columns[12].Visible = false;
                        this.dgProduct.Columns[13].Name = "Location Name";
                        this.dgProduct.Columns[13].Visible = false;
                        this.dgProduct.Columns[14].Name = "Product Color ID";
                        this.dgProduct.Columns[14].Visible = false;
                        this.dgProduct.Columns[15].Name = "Product Color Name";
                        this.dgProduct.Columns[16].Name = "Product Size ID";
                        this.dgProduct.Columns[16].Visible = false;
                        this.dgProduct.Columns[17].Name = "Product Size Name";
                        this.dgProduct.Columns[18].Name = "Product Unit ID";
                        this.dgProduct.Columns[18].Visible = false;
                        this.dgProduct.Columns[19].Name = "Product Unit Name";
                        this.dgProduct.Columns[20].Name = "Code";
                        this.dgProduct.Columns[20].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        this.dgProduct.Columns[21].Name = "PR";
                        this.dgProduct.Columns[22].Name = "PCD";
                        this.dgProduct.Columns[23].Name = "MFLM";
                        this.dgProduct.Columns[24].Name = "Pattern";
                        this.dgProduct.Columns[25].Name = "OffsetCenterBase";
                        this.dgProduct.Columns[25].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        this.dgProduct.Columns[26].Name = "Origin";
                        this.dgProduct.Columns[27].Name = "Unit Price";
                        this.dgProduct.Columns[28].Name = "Quantity";
                        this.dgProduct.Columns[29].Name = "Total Quantity Price";
                        this.Purchase.PurchaseDetails.Clear();

                        for (int i = 0; i < PurchaseDetailsList.Count; i++)
                        {
                            //display all the data in productList to the datagridview
                            PurchaseDetail purchaseDetail = PurchaseDetailsList[i];
                            var product = purchaseDetail.Product;
                            this.Purchase.PurchaseDetails.Add(purchaseDetail);
                            this.dgProduct.Rows[i].Cells[0].Value = purchaseDetail.Id;
                            this.dgProduct.Rows[i].Cells[1].Value = product?.strProductName ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[2].Value = product?.strDescription ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[3].Value = product?.ProductCharacteristic?.Id ?? 0;
                            this.dgProduct.Rows[i].Cells[4].Value = product?.ProductCharacteristic?.strName ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[5].Value = product?.ProductCategory?.Id ?? 0;
                            this.dgProduct.Rows[i].Cells[6].Value = product?.ProductCategory?.strName ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[7].Value = product?.ProductType?.Id ?? 0;
                            this.dgProduct.Rows[i].Cells[8].Value = product?.ProductType?.strName ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[9].Value = product?.ProductBrand?.Id ?? 0;
                            this.dgProduct.Rows[i].Cells[10].Value = product?.ProductBrand?.strName ?? string.Empty;
                            //this.dgProduct.Rows[i].Cells[11].Value = product?.PerPieceBox ?? 0;
                            //this.dgProduct.Rows[i].Cells[12].Value = product?.Location?.ID ?? 0;
                            //this.dgProduct.Rows[i].Cells[13].Value = product?.Location?.Name ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[14].Value = product?.ProductColor?.Id ?? 0;
                            this.dgProduct.Rows[i].Cells[15].Value = product?.ProductColor?.strName ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[16].Value = product?.ProductSize?.Id ?? 0;
                            this.dgProduct.Rows[i].Cells[17].Value = product?.ProductSize?.strName ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[18].Value = product?.ProductUnit?.Id ?? 0;
                            this.dgProduct.Rows[i].Cells[19].Value = product?.ProductUnit?.strName ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[20].Value = product?.strCode ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[21].Value = product?.strPR ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[22].Value = product?.strPCD ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[23].Value = product?.strMFLM ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[24].Value = product?.strPattern ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[25].Value = product?.strOffsetCenterBore ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[26].Value = product?.strOrigin ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[27].Value = purchaseDetail.UnitPrice ?? 0;
                            this.dgProduct.Rows[i].Cells[28].Value = purchaseDetail.Quantity ?? 0;
                            this.dgProduct.Rows[i].Cells[29].Value = purchaseDetail.TotalPrice != null ? purchaseDetail.TotalPrice : 0m;
                            //this.dgProduct.Rows[i].Cells[27].Value = product?.curUnitPrice ?? 0;
                        }

                        setRowNumber(this.dgJournalEntry);
                        this.txtPurchaseTotal.Text = string.Format("{0:0.00}", PurchaseDetailsList.Sum(g => g.TotalPrice));
                        this.txtTotal.Text = string.Format("{0:0.00}", PurchaseDetailsList.Sum(g => g.TotalPrice));
                    }


                    this.GLTranDetailInventoryEntry = GLTranServices.GetGLEntryByPurchaseId(Purchase.Id, 1011).SelectMany(h => h.tblGLTranDetails).ToList();
                    if (GLTranDetailInventoryEntry.Count > 0)
                    {

                        this.dgInventoryEntry.ColumnCount = 6;
                        this.dgInventoryEntry.RowCount = GLTranDetailInventoryEntry.Count;
                        //this.dgChartOfAccountsSubsidiary.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        //this.dgChartOfAccountsSubsidiary.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        this.dgInventoryEntry.Columns[0].Name = "COA";
                        this.dgInventoryEntry.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        this.dgInventoryEntry.Columns[1].Name = "COA Code";
                        this.dgInventoryEntry.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.dgInventoryEntry.Columns[2].Name = "COA Subsidiary";
                        this.dgInventoryEntry.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.dgInventoryEntry.Columns[3].Name = "COA Subsidiary Code";
                        this.dgInventoryEntry.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.dgInventoryEntry.Columns[4].Name = "Debit";
                        this.dgInventoryEntry.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.dgInventoryEntry.Columns[5].Name = "Credit";
                        this.dgInventoryEntry.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        this.dgInventoryEntry.Columns[0].ReadOnly = true;
                        this.dgInventoryEntry.Columns[1].ReadOnly = true;
                        this.dgInventoryEntry.Columns[2].ReadOnly = true;
                        this.dgInventoryEntry.Columns[3].ReadOnly = true;
                        this.dgInventoryEntry.Columns[4].ReadOnly = true;
                        this.dgInventoryEntry.Columns[5].ReadOnly = true;
                        this.dgInventoryEntry.Columns[1].Visible = false;
                        this.dgInventoryEntry.Columns[3].Visible = false;

                        for (int i = 0; i < GLTranDetailInventoryEntry.Count; i++)
                        {

                            this.dgInventoryEntry.Rows[i].Cells[0].Value = GLTranDetailInventoryEntry[i].tblMasCOA.strName;
                            this.dgInventoryEntry.Rows[i].Cells[1].Value = GLTranDetailInventoryEntry[i].tblMasCOA.strCode;
                            this.dgInventoryEntry.Rows[i].Cells[2].Value = GLTranDetailInventoryEntry[i].tblMasCOASub.strName;
                            this.dgInventoryEntry.Rows[i].Cells[3].Value = GLTranDetailInventoryEntry[i].tblMasCOASub.strCode;
                            this.dgInventoryEntry.Rows[i].Cells[4].Value = string.Format("{0:0.00}", GLTranDetailInventoryEntry[i].curDebit);
                            this.dgInventoryEntry.Rows[i].Cells[5].Value = string.Format("{0:0.00}", GLTranDetailInventoryEntry[i].curCredit);

                            this.dgInventoryEntry.Rows[i].Cells[0].ReadOnly = true;
                            this.dgInventoryEntry.Rows[i].Cells[1].ReadOnly = true;
                            this.dgInventoryEntry.Rows[i].Cells[2].ReadOnly = true;
                            this.dgInventoryEntry.Rows[i].Cells[3].ReadOnly = true;
                            this.dgInventoryEntry.Rows[i].Cells[4].ReadOnly = true;
                            this.dgInventoryEntry.Rows[i].Cells[5].ReadOnly = true;
                        }

                        setRowNumber(this.dgInventoryEntry);

                        this.txtTotalInventoryDebit.Text = string.Format("{0:0.00}", GLTranDetailInventoryEntry.Sum(g => g.curDebit));
                        this.txtTotalInventoryCredit.Text = string.Format("{0:0.00}", GLTranDetailInventoryEntry.Sum(g => g.curCredit));
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

                   PurchaseServices.Remove(Purchase, this.PurchaseDetailsList);

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
                        this.dgProduct.Rows.Clear();
                        this.dgProduct.Refresh();
                        this.PurchaseDetailsList = new List<PurchaseDetail>();
                        this.GLTranDetailInventoryEntry.Clear();
                        this.dgInventoryEntry.Rows.Clear();
                        this.dgInventoryEntry.Refresh();
                        this.dgJournalEntry.Rows.Clear();
                        this.dgJournalEntry.Refresh();
                        this.GLTranDetail.Clear();
                        this.txtPurchaseTotal.Text = string.Empty;
                        this.txtTotalInventoryCredit.Text = string.Empty;
                        this.txtTotalInventoryDebit.Text = string.Empty;
                        this.txtAdditionalDescription.Text = string.Empty;
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
            this.dgProduct.Rows.Clear();
            this.dgProduct.Refresh();
            this.PurchaseDetailsList = new List<PurchaseDetail>();
            this.GLTranDetailInventoryEntry.Clear();
            this.dgInventoryEntry.Rows.Clear();
            this.dgInventoryEntry.Refresh();
            this.dgJournalEntry.Rows.Clear();
            this.dgJournalEntry.Refresh();
            this.GLTranDetail.Clear();
            this.txtPurchaseTotal.Text = string.Empty;
            this.txtAdditionalDescription.Text = string.Empty;
            GLTranDetail = new List<tblGLTranDetail>();
    


        }

        private void btnViewLedger_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.ID == 0)
                {
                    MessageBox.Show("Please select transaction first...");
                    return;
                }

                //var result = SalesCustomerLedgerServices.GetSalesCustomerLedger(this.Sale.Id);

                MetroTabPage metroTabPage = new MetroTabPage();
                metroTabPage.Text = "Purchase Ledger";
                metroTabPage.AutoScroll = true;
                metroTabPage.HorizontalScrollbar = true;
                metroTabPage.HorizontalScrollbarBarColor = true;
                metroTabPage.HorizontalScrollbarHighlightOnWheel = true;
                metroTabPage.HorizontalScrollbarSize = 15;
                metroTabPage.UseStyleColors = true;
                metroTabPage.VerticalScrollbar = true;
                metroTabPage.VerticalScrollbarBarColor = true;
                metroTabPage.VerticalScrollbarHighlightOnWheel = true;
                metroTabPage.VerticalScrollbarSize = 15;
                //metroTabPage.Size = new System.Drawing.Size(1200, 1013);
                metroTabPage.Style = MetroFramework.MetroColorStyle.Orange;
                metroTabPage.Location = new System.Drawing.Point(4, 38);
                metroTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);

                frmPurchaseLedger frmPurchaseLedger = new frmPurchaseLedger(this.ID);
                frmPurchaseLedger.Parent = metroTabPage;
                frmPurchaseLedger.MetroTabPage = metroTabPage;
                frmPurchaseLedger.AutoScroll = true;
                frmPurchaseLedger.MetroTabControl = this.MetroTabControl;

                metroTabPage.Controls.Add(frmPurchaseLedger);
                MetroTabControl.TabPages.Add(metroTabPage);
                MetroTabControl.SelectedTab = metroTabPage;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
        
            frmChooseProduct frmChooseProduct = new frmChooseProduct();
            frmChooseProduct.BringToFront();
            frmChooseProduct.TopMost = true;
            frmChooseProduct.IsPurchase = true;
            DialogResult res = frmChooseProduct.ShowDialog(this);

            if (res == DialogResult.OK)
            {

                var convertPurchaseDetail = new PurchaseDetail
                {
                     ProductId = frmChooseProduct.Product.Id,
                     //assign frmChooseProduct.Product to Product
                     Product = frmChooseProduct.Product,
                     //UnitPrice = frmChooseProduct.Product.curUnitPrice,
                     UnitPrice = frmChooseProduct.ProductTotalUnitPrice,
                     Quantity = frmChooseProduct.ProductQuantity,
                     TotalPrice = frmChooseProduct.ProductTotalQuantityPrice,
                };

                if (!(PurchaseDetailsList.Any(p => p.ProductId == convertPurchaseDetail.ProductId)))
                {
                    this.PurchaseDetailsList.Add(convertPurchaseDetail);
                }
                else
                {
                    MessageBox.Show("Please product already added");
                    return;
                }
             

                if (PurchaseDetailsList.Count > 0)
                {

                    this.dgProduct.Rows.Clear();
                    this.dgProduct.Refresh();
                    //this.dgProduct.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    this.dgProduct.RowCount = PurchaseDetailsList.Count;
                    this.dgProduct.ColumnCount = 30;
                    this.dgProduct.Columns[0].Name = "ID";
                    this.dgProduct.Columns[0].Visible = false;
                    this.dgProduct.Columns[1].Name = "Product Name";
                    this.dgProduct.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[2].Visible = false;
                    this.dgProduct.Columns[2].Name = "Description";
                    this.dgProduct.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[3].Name = "Product Characteristic ID";
                    this.dgProduct.Columns[3].Visible = false;
                    this.dgProduct.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[4].Name = "Product Characteristic Name";
                    this.dgProduct.Columns[4].Visible = false;
                    this.dgProduct.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[5].Name = "Product Category ID";
                    this.dgProduct.Columns[5].Visible = false;
                    this.dgProduct.Columns[6].Name = "Product Category Name";
                    this.dgProduct.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[7].Name = "Product Type ID";
                    this.dgProduct.Columns[7].Visible = false;
                    this.dgProduct.Columns[8].Name = "Product Type Name";
                    this.dgProduct.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[9].Name = "Product Brand ID";
                    this.dgProduct.Columns[9].Visible = false;
                    this.dgProduct.Columns[10].Name = "Product Brand Name";
                    this.dgProduct.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[11].Name = "Per Piece Box";
                    this.dgProduct.Columns[11].Visible = false;
                    this.dgProduct.Columns[12].Name = "Location ID";
                    this.dgProduct.Columns[12].Visible = false;
                    this.dgProduct.Columns[13].Name = "Location Name";
                    this.dgProduct.Columns[13].Visible = false;
                    this.dgProduct.Columns[14].Name = "Product Color ID";
                    this.dgProduct.Columns[14].Visible = false;
                    this.dgProduct.Columns[15].Name = "Product Color Name";
                    this.dgProduct.Columns[16].Name = "Product Size ID";
                    this.dgProduct.Columns[16].Visible = false;
                    this.dgProduct.Columns[17].Name = "Product Size Name";
                    this.dgProduct.Columns[18].Name = "Product Unit ID";
                    this.dgProduct.Columns[18].Visible = false;
                    this.dgProduct.Columns[19].Name = "Product Unit Name";
                    this.dgProduct.Columns[20].Name = "Code";
                    this.dgProduct.Columns[20].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[21].Name = "PR";
                    this.dgProduct.Columns[22].Name = "PCD";
                    this.dgProduct.Columns[23].Name = "MFLM";
                    this.dgProduct.Columns[24].Name = "Pattern";
                    this.dgProduct.Columns[25].Name = "OffsetCenterBase";
                    this.dgProduct.Columns[25].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[26].Name = "Origin";
                    this.dgProduct.Columns[27].Name = "Unit Price";
                    this.dgProduct.Columns[28].Name = "Quantity";
                    this.dgProduct.Columns[29].Name = "Total Quantity Price";

                    for (int i = 0; i < PurchaseDetailsList.Count; i++)
                    {
                        //display all the data in productList to the datagridview
                        PurchaseDetail purchaseDetail = PurchaseDetailsList[i];
                        var product = purchaseDetail.Product;
                        this.dgProduct.Rows[i].Cells[0].Value = purchaseDetail.Id;
                        this.dgProduct.Rows[i].Cells[1].Value = product?.strProductName ?? string.Empty;
                        this.dgProduct.Rows[i].Cells[2].Value = product?.strDescription ?? string.Empty;
                        //this.dgProduct.Rows[i].Cells[3].Value = purchaseDetail.Product.ProductCharacteristic.Id;
                        //this.dgProduct.Rows[i].Cells[4].Value = purchaseDetail.Product.ProductCharacteristic.strName;
                        this.dgProduct.Rows[i].Cells[5].Value = product?.ProductCategory?.Id ?? 0;
                        this.dgProduct.Rows[i].Cells[6].Value = product?.ProductCategory?.strName ?? string.Empty;
                        this.dgProduct.Rows[i].Cells[7].Value = product?.ProductType?.Id ?? 0;
                        this.dgProduct.Rows[i].Cells[8].Value = product?.ProductType?.strName ?? string.Empty;
                        this.dgProduct.Rows[i].Cells[9].Value = product?.ProductBrand?.Id ?? 0;
                        this.dgProduct.Rows[i].Cells[10].Value = product?.ProductBrand?.strName ?? string.Empty;
                        //this.dgProduct.Rows[i].Cells[11].Value = product.PerPieceBox;
                        //this.dgProduct.Rows[i].Cells[12].Value = product.Location.ID;
                        //this.dgProduct.Rows[i].Cells[13].Value = product.Location.Name;pl
                        this.dgProduct.Rows[i].Cells[14].Value = product?.ProductColor?.Id ?? 0;
                        this.dgProduct.Rows[i].Cells[15].Value = product?.ProductColor?.strName ?? string.Empty;
                        this.dgProduct.Rows[i].Cells[16].Value = product?.ProductSize?.Id ?? 0;
                        this.dgProduct.Rows[i].Cells[17].Value = product?.ProductSize?.strName ?? string.Empty;
                        this.dgProduct.Rows[i].Cells[18].Value = product?.ProductUnit?.Id ?? 0;
                        this.dgProduct.Rows[i].Cells[19].Value = product?.ProductUnit?.strName ?? string.Empty;
                        this.dgProduct.Rows[i].Cells[20].Value = product?.strCode ?? string.Empty;
                        this.dgProduct.Rows[i].Cells[21].Value = product?.strPR ?? string.Empty;
                        this.dgProduct.Rows[i].Cells[22].Value = product?.strPCD ?? string.Empty;
                        this.dgProduct.Rows[i].Cells[23].Value = product?.strMFLM ?? string.Empty;
                        this.dgProduct.Rows[i].Cells[24].Value = product?.strPattern ?? string.Empty;
                        this.dgProduct.Rows[i].Cells[25].Value = product?.strOffsetCenterBore ?? string.Empty;
                        this.dgProduct.Rows[i].Cells[26].Value = product?.strOrigin ?? string.Empty;
                        this.dgProduct.Rows[i].Cells[27].Value = purchaseDetail.UnitPrice ?? 0;
                        this.dgProduct.Rows[i].Cells[28].Value = purchaseDetail.Quantity ?? 0;
                        this.dgProduct.Rows[i].Cells[29].Value = purchaseDetail.TotalPrice != null ? purchaseDetail.TotalPrice : 0m;
                        //this.dgProduct.Rows[i].Cells[27].Value = product.curUnitPrice;
                    }

                    setRowNumber(this.dgJournalEntry);
                    this.txtPurchaseTotal.Text = string.Format("{0:0.00}", PurchaseDetailsList.Sum(g => g.TotalPrice));
                    this.txtTotal.Text = string.Format("{0:0.00}", PurchaseDetailsList.Sum(g => g.TotalPrice));
                }
            }
        }

        private void dgProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.IndexGridInventory = e.RowIndex;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {


                if (PurchaseDetailsList.Count > 0)
                {
                    this.PurchaseDetailsList.RemoveAt(this.IndexGridInventory);
                    this.dgProduct.Rows.Clear();
                    this.dgProduct.Refresh();

                    if (PurchaseDetailsList.Count == 0)
                    {
                        return;
                    }
                    //this.dgProduct.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    this.dgProduct.RowCount = PurchaseDetailsList.Count;
                    this.dgProduct.ColumnCount = 30;
                    this.dgProduct.Columns[0].Name = "ID";
                    this.dgProduct.Columns[0].Visible = false;
                    this.dgProduct.Columns[1].Name = "Product Name";
                    this.dgProduct.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[2].Visible = false;
                    this.dgProduct.Columns[2].Name = "Description";
                    this.dgProduct.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[3].Name = "Product Characteristic ID";
                    this.dgProduct.Columns[3].Visible = false;
                    this.dgProduct.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[4].Name = "Product Characteristic Name";
                    this.dgProduct.Columns[4].Visible = false;
                    this.dgProduct.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[5].Name = "Product Category ID";
                    this.dgProduct.Columns[5].Visible = false;
                    this.dgProduct.Columns[6].Name = "Product Category Name";
                    this.dgProduct.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[7].Name = "Product Type ID";
                    this.dgProduct.Columns[7].Visible = false;
                    this.dgProduct.Columns[8].Name = "Product Type Name";
                    this.dgProduct.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[9].Name = "Product Brand ID";
                    this.dgProduct.Columns[9].Visible = false;
                    this.dgProduct.Columns[10].Name = "Product Brand Name";
                    this.dgProduct.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[11].Name = "Per Piece Box";
                    this.dgProduct.Columns[11].Visible = false;
                    this.dgProduct.Columns[12].Name = "Location ID";
                    this.dgProduct.Columns[12].Visible = false;
                    this.dgProduct.Columns[13].Name = "Location Name";
                    this.dgProduct.Columns[13].Visible = false;
                    this.dgProduct.Columns[14].Name = "Product Color ID";
                    this.dgProduct.Columns[14].Visible = false;
                    this.dgProduct.Columns[15].Name = "Product Color Name";
                    this.dgProduct.Columns[16].Name = "Product Size ID";
                    this.dgProduct.Columns[16].Visible = false;
                    this.dgProduct.Columns[17].Name = "Product Size Name";
                    this.dgProduct.Columns[18].Name = "Product Unit ID";
                    this.dgProduct.Columns[18].Visible = false;
                    this.dgProduct.Columns[19].Name = "Product Unit Name";
                    this.dgProduct.Columns[20].Name = "Code";
                    this.dgProduct.Columns[20].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[21].Name = "PR";
                    this.dgProduct.Columns[22].Name = "PCD";
                    this.dgProduct.Columns[23].Name = "MFLM";
                    this.dgProduct.Columns[24].Name = "Pattern";
                    this.dgProduct.Columns[25].Name = "OffsetCenterBase";
                    this.dgProduct.Columns[25].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[26].Name = "Origin";
                    this.dgProduct.Columns[27].Name = "Unit Price";
                    this.dgProduct.Columns[28].Name = "Quantity";
                    this.dgProduct.Columns[29].Name = "Total Quantity Price";

                    for (int i = 0; i < PurchaseDetailsList.Count; i++)
                    {
                        //display all the data in productList to the datagridview
                        PurchaseDetail purchaseDetail = PurchaseDetailsList[i];
                        this.dgProduct.Rows[i].Cells[0].Value = purchaseDetail.Id;
                        this.dgProduct.Rows[i].Cells[1].Value = purchaseDetail.Product.strProductName;
                        this.dgProduct.Rows[i].Cells[2].Value = purchaseDetail.Product.strDescription;
                        //this.dgProduct.Rows[i].Cells[3].Value = purchaseDetail.Product.ProductCharacteristic.Id;
                        //this.dgProduct.Rows[i].Cells[4].Value = purchaseDetail.Product.ProductCharacteristic.strName;
                        this.dgProduct.Rows[i].Cells[5].Value = purchaseDetail.Product.ProductCategory.Id;
                        this.dgProduct.Rows[i].Cells[6].Value = purchaseDetail.Product.ProductCategory.strName;
                        this.dgProduct.Rows[i].Cells[7].Value = purchaseDetail.Product.ProductType.Id;
                        this.dgProduct.Rows[i].Cells[8].Value = purchaseDetail.Product.ProductType.strName;
                        this.dgProduct.Rows[i].Cells[9].Value = purchaseDetail.Product.ProductBrand.Id;
                        this.dgProduct.Rows[i].Cells[10].Value = purchaseDetail.Product.ProductBrand.strName;
                        //this.dgProduct.Rows[i].Cells[11].Value = product.PerPieceBox;
                        //this.dgProduct.Rows[i].Cells[12].Value = product.Location.ID;
                        //this.dgProduct.Rows[i].Cells[13].Value = product.Location.Name;
                        this.dgProduct.Rows[i].Cells[14].Value = purchaseDetail.Product.ProductColor.Id;
                        this.dgProduct.Rows[i].Cells[15].Value = purchaseDetail.Product.ProductColor.strName;
                        this.dgProduct.Rows[i].Cells[16].Value = purchaseDetail.Product.ProductSize.Id;
                        this.dgProduct.Rows[i].Cells[17].Value = purchaseDetail.Product.ProductSize.strName;
                        this.dgProduct.Rows[i].Cells[18].Value = purchaseDetail.Product.ProductUnit.Id;
                        this.dgProduct.Rows[i].Cells[19].Value = purchaseDetail.Product.ProductUnit.strName;
                        this.dgProduct.Rows[i].Cells[20].Value = purchaseDetail.Product.strCode;
                        this.dgProduct.Rows[i].Cells[21].Value = purchaseDetail.Product.strPR;
                        this.dgProduct.Rows[i].Cells[22].Value = purchaseDetail.Product.strPCD;
                        this.dgProduct.Rows[i].Cells[23].Value = purchaseDetail.Product.strMFLM;
                        this.dgProduct.Rows[i].Cells[24].Value = purchaseDetail.Product.strPattern;
                        this.dgProduct.Rows[i].Cells[25].Value = purchaseDetail.Product.strOffsetCenterBore;
                        this.dgProduct.Rows[i].Cells[26].Value = purchaseDetail.Product.strOrigin;
                        this.dgProduct.Rows[i].Cells[27].Value = purchaseDetail.UnitPrice;
                        this.dgProduct.Rows[i].Cells[28].Value = purchaseDetail.Quantity;
                        this.dgProduct.Rows[i].Cells[29].Value = purchaseDetail.TotalPrice;
                        //this.dgProduct.Rows[i].Cells[27].Value = product.curUnitPrice;
                    }

                    setRowNumber(this.dgJournalEntry);
                    this.txtPurchaseTotal.Text = string.Format("{0:0.00}", PurchaseDetailsList.Sum(g => g.TotalPrice));
                }

            }
            catch (Exception ex)
            {

               MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}
