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
    public partial class frmPurchase : MetroUserControl
    {

        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }
        public Purchase Purchase { get; set; }
        public PurchaseServices PurchaseServices { get; set; }
        public GLTranServices GLTranServices { get; set; }

        public int ID { get; set; }
        public int GLTranHeader { get; set; }
        public int SupplierId { get; set; }
        public List<tblGLTranDetail> GLTranDetail { get; set; }

        public int IndexGrid { get; set; }


        public frmPurchase()
        {
            InitializeComponent();
            PurchaseServices = new PurchaseServices();
            GLTranDetail = new List<tblGLTranDetail>();
            GLTranServices = new GLTranServices();
            GLTranHeader = 0;
            SupplierId = 0;
            this.Purchase = new Purchase();
            
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

                    Purchase = PurchaseServices.Add(Purchase);
                }
                else { 
                
                
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
    }
}
