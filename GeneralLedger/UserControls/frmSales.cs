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
    public partial class frmSales :  MetroUserControl
    {
        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }

        public Sale Sale { get; set; }
        public SaleServices SaleServices { get; set; }
        public GLTranServices GLTranServices { get; set; }
        public SalesCustomerLedgerServices SalesCustomerLedgerServices { get; set; }

        public SaleDetailServices SaleDetailServices { get; set; }

        public tblTBBatchHdrServices tblTBBatchHdrServices { get; set; }
        public int ID { get; set; }

        public int GLTranHeader { get; set; }

        public int CustomerId { get; set; }

        public int AgentId { get; set; }

        public List<tblGLTranDetail> GLTranDetail { get; set; }

        public List<SalesDetail> SalesDetailsList { get; set; }

        public int IndexGrid { get; set; }

        public int IndexGridInventory { get; set; }

        public List<tblGLTranDetail> GLTranDetailInventoryEntry { get; set; }

        public frmSales()
        {
            InitializeComponent();
            SaleServices = new SaleServices();
            GLTranDetail = new List<tblGLTranDetail>();
            GLTranServices = new GLTranServices();
            GLTranHeader = 0;
            CustomerId = 0;
            AgentId = 0;
            this.Sale = new Sale();
            SalesCustomerLedgerServices = new SalesCustomerLedgerServices();
            tblTBBatchHdrServices = new tblTBBatchHdrServices();
            SalesDetailsList = new List<SalesDetail>();
            SaleDetailServices = new SaleDetailServices();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                double doubleParser;
                SearchCustomer sc = new SearchCustomer();
                sc.BringToFront();
                sc.TopMost = true;
                DialogResult res = sc.ShowDialog(this);

                if (res == DialogResult.OK)
                {
                    this.CustomerId = sc.Customer.ID;
                    this.txtCustomerID.Text = sc.Customer.ID.ToString(); 
                    this.txtCustomerName.Text = sc.Customer.Name;
                    this.txtTerms.Text = sc.Customer.Terms.ToString();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnSearchAgent_Click(object sender, EventArgs e)
        {
            try
            {
                double doubleParser;
                SearchAgent sa = new SearchAgent();
                sa.BringToFront();
                sa.TopMost = true;
                DialogResult res = sa.ShowDialog(this);

                if (res == DialogResult.OK)
                {
                    this.AgentId = sa.Agent.Id;
                    this.txtAgentID.Text = sa.Agent.Id.ToString();
                    this.txtAgent.Text = sa.Agent.Name;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        //private void btnSave_Click(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        if (this.AgentId == 0)
        //        { 
        //            MessageBox.Show("Please select agent..." );
        //            return;
        //         }

        //        if (this.CustomerId == 0) {
        //            MessageBox.Show("Please select customer...");
        //            return;
        //        }

        //        if (this.GLTranDetail.Sum(d => d.curCredit) != this.GLTranDetail.Sum(d => d.curDebit))
        //        {
        //            MessageBox.Show("Disbal journal entry");
        //            return;
        //        }

        //        if (this.SalesDetailsList.Count <= 0)
        //        {

        //            MessageBox.Show("Please check the products");
        //            return;
        //        }


        //        int intParser;
        //        decimal decimalParser;

        //        var isLock = tblTBBatchHdrServices.CheckIfLock(this.dtTransactionDate.Value);

        //        if (isLock)
        //        {
        //            MessageBox.Show("Already lock...");
        //            return;
        //        }


        //        string TransType = (this.ID == 0) ? "insert" : "update";
        //        if (TransType.Equals("insert"))
        //        {
        //            Sale = new Sale
        //            {
        //                Id = this.ID,
        //                PONo = this.txtPONo.Text,
        //                TRANo = this.txtTransactionNo.Text,
        //                intIdAgent = this.AgentId,
        //                intIdCustomer = this.CustomerId,
        //                Terms = int.TryParse(this.txtTerms.Text , out intParser) ? intParser : 0,
        //                Total = decimal.TryParse(this.txtTotal.Text, out decimalParser) ? decimalParser : 0,
        //                TransactionDate = this.dtTransactionDate.Value,
        //                SOPAmount = decimal.TryParse(this.txtSOPAmount.Text, out decimalParser) ? decimalParser : 0,
        //                COMMAmount = decimal.TryParse(this.txtCOMMAmount.Text, out decimalParser) ? decimalParser : 0,
        //                CFAmount = decimal.TryParse(this.txtCFAmount.Text, out decimalParser) ? decimalParser : 0,
        //                Description = this.txtDescription.Text
        //            };

        //            if (Sale.Total < (Sale.CFAmount + Sale.COMMAmount + Sale.SOPAmount))
        //            {
        //                MessageBox.Show("Please check amount");
        //                return;
        //            }

        //            Sale = SaleServices.Add(Sale, this.GLTranDetail , this.chkUseDefaultEntry.Checked , this.SalesDetailsList);

        //            if (Sale != null)
        //            {
        //                MessageBox.Show("Successfully saved");

        //            }
        //        }
        //        else
        //        {

        //            Sale.PONo = this.txtPONo.Text;
        //            Sale.TRANo = this.txtTransactionNo.Text;
        //            Sale.intIdAgent = this.AgentId;
        //            Sale.intIdCustomer = this.CustomerId;
        //            Sale.Terms = int.TryParse(this.txtTerms.Text, out intParser) ? intParser : 0;
        //            Sale.Total = decimal.TryParse(this.txtTotal.Text, out decimalParser) ? decimalParser : 0;
        //            Sale.TransactionDate = this.dtTransactionDate.Value;
        //            Sale.SOPAmount = decimal.TryParse(this.txtSOPAmount.Text, out decimalParser) ? decimalParser : 0;
        //            Sale.COMMAmount = decimal.TryParse(this.txtCOMMAmount.Text, out decimalParser) ? decimalParser : 0;
        //            Sale.CFAmount = decimal.TryParse(this.txtCFAmount.Text, out decimalParser) ? decimalParser:0;
        //            Sale.Description = this.txtDescription.Text;
        //            Sale = SaleServices.Update(Sale, this.GLTranDetail, this.chkUseDefaultEntry.Checked, this.SalesDetailsList);

        //            if (Sale.Total < (Sale.CFAmount + Sale.COMMAmount + Sale.SOPAmount))
        //            {
        //                MessageBox.Show("Please check amount");
        //                return;
        //            }
        //            if (Sale != null)
        //            {
        //                MessageBox.Show("Successfully saved");
        //            }
        //        }

        //        //GLTranHeader = Sale.tblGLTranHeaders.Select(h => h.ID).SingleOrDefault();
        //        this.GLTranDetail = GLTranServices.GetGLEntryBySalesId(Sale.Id , 6).SelectMany(h => h.tblGLTranDetails).ToList();
        //        if (GLTranDetail.Count > 0)
        //        {

        //            this.dgJournalEntry.ColumnCount = 6;
        //            this.dgJournalEntry.RowCount = GLTranDetail.Count;
        //            //this.dgChartOfAccountsSubsidiary.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //            //this.dgChartOfAccountsSubsidiary.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //            this.dgJournalEntry.Columns[0].Name = "COA";
        //            this.dgJournalEntry.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //            this.dgJournalEntry.Columns[1].Name = "COA Code";
        //            this.dgJournalEntry.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //            this.dgJournalEntry.Columns[2].Name = "COA Subsidiary";
        //            this.dgJournalEntry.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //            this.dgJournalEntry.Columns[3].Name = "COA Subsidiary Code";
        //            this.dgJournalEntry.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //            this.dgJournalEntry.Columns[4].Name = "Debit";
        //            this.dgJournalEntry.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //            this.dgJournalEntry.Columns[5].Name = "Credit";
        //            this.dgJournalEntry.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //            this.dgJournalEntry.Columns[0].ReadOnly = true;
        //            this.dgJournalEntry.Columns[1].ReadOnly = true;
        //            this.dgJournalEntry.Columns[2].ReadOnly = true;
        //            this.dgJournalEntry.Columns[3].ReadOnly = true;
        //            this.dgJournalEntry.Columns[4].ReadOnly = true;
        //            this.dgJournalEntry.Columns[5].ReadOnly = true;
        //            this.dgJournalEntry.Columns[1].Visible = false;
        //            this.dgJournalEntry.Columns[3].Visible = false;

        //            for (int i = 0; i < GLTranDetail.Count; i++)
        //            {

        //                this.dgJournalEntry.Rows[i].Cells[0].Value = GLTranDetail[i].tblMasCOA.strName;
        //                this.dgJournalEntry.Rows[i].Cells[1].Value = GLTranDetail[i].tblMasCOA.strCode;
        //                this.dgJournalEntry.Rows[i].Cells[2].Value = GLTranDetail[i].tblMasCOASub.strName;
        //                this.dgJournalEntry.Rows[i].Cells[3].Value = GLTranDetail[i].tblMasCOASub.strCode;
        //                this.dgJournalEntry.Rows[i].Cells[4].Value = string.Format("{0:0.00}", GLTranDetail[i].curDebit);
        //                this.dgJournalEntry.Rows[i].Cells[5].Value = string.Format("{0:0.00}", GLTranDetail[i].curCredit);

        //                this.dgJournalEntry.Rows[i].Cells[0].ReadOnly = true;
        //                this.dgJournalEntry.Rows[i].Cells[1].ReadOnly = true;
        //                this.dgJournalEntry.Rows[i].Cells[2].ReadOnly = true;
        //                this.dgJournalEntry.Rows[i].Cells[3].ReadOnly = true;
        //                this.dgJournalEntry.Rows[i].Cells[4].ReadOnly = true;
        //                this.dgJournalEntry.Rows[i].Cells[5].ReadOnly = true;
        //            }

        //            setRowNumber(this.dgJournalEntry);

        //            this.txtTotalDebit.Text = string.Format("{0:0.00}", GLTranDetail.Sum(g => g.curDebit));
        //            this.txtTotalCredit.Text = string.Format("{0:0.00}", GLTranDetail.Sum(g => g.curCredit));
        //        }
        //        else
        //        {
        //            this.dgJournalEntry.Rows.Clear();
        //            this.dgJournalEntry.Refresh();
        //            this.GLTranDetail.Clear();
        //            this.txtTotalDebit.Text = string.Empty;
        //            this.txtTotalCredit.Text = string.Empty;
        //        }


        //        this.GLTranDetailInventoryEntry = GLTranServices.GetGLEntryBySalesId(Sale.Id, 1011).SelectMany(h => h.tblGLTranDetails).ToList();
        //        if (GLTranDetailInventoryEntry.Count > 0)
        //        {

        //            this.dgInventoryEntry.ColumnCount = 6;
        //            this.dgInventoryEntry.RowCount = GLTranDetailInventoryEntry.Count;
        //            //this.dgChartOfAccountsSubsidiary.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //            //this.dgChartOfAccountsSubsidiary.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //            this.dgInventoryEntry.Columns[0].Name = "COA";
        //            this.dgInventoryEntry.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //            this.dgInventoryEntry.Columns[1].Name = "COA Code";
        //            this.dgInventoryEntry.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //            this.dgInventoryEntry.Columns[2].Name = "COA Subsidiary";
        //            this.dgInventoryEntry.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //            this.dgInventoryEntry.Columns[3].Name = "COA Subsidiary Code";
        //            this.dgInventoryEntry.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //            this.dgInventoryEntry.Columns[4].Name = "Debit";
        //            this.dgInventoryEntry.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //            this.dgInventoryEntry.Columns[5].Name = "Credit";
        //            this.dgInventoryEntry.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //            this.dgInventoryEntry.Columns[0].ReadOnly = true;
        //            this.dgInventoryEntry.Columns[1].ReadOnly = true;
        //            this.dgInventoryEntry.Columns[2].ReadOnly = true;
        //            this.dgInventoryEntry.Columns[3].ReadOnly = true;
        //            this.dgInventoryEntry.Columns[4].ReadOnly = true;
        //            this.dgInventoryEntry.Columns[5].ReadOnly = true;
        //            this.dgInventoryEntry.Columns[1].Visible = false;
        //            this.dgInventoryEntry.Columns[3].Visible = false;

        //            for (int i = 0; i < GLTranDetailInventoryEntry.Count; i++)
        //            {

        //                this.dgInventoryEntry.Rows[i].Cells[0].Value = GLTranDetailInventoryEntry[i].tblMasCOA.strName;
        //                this.dgInventoryEntry.Rows[i].Cells[1].Value = GLTranDetailInventoryEntry[i].tblMasCOA.strCode;
        //                this.dgInventoryEntry.Rows[i].Cells[2].Value = GLTranDetailInventoryEntry[i].tblMasCOASub.strName;
        //                this.dgInventoryEntry.Rows[i].Cells[3].Value = GLTranDetailInventoryEntry[i].tblMasCOASub.strCode;
        //                this.dgInventoryEntry.Rows[i].Cells[4].Value = string.Format("{0:0.00}", GLTranDetailInventoryEntry[i].curDebit);
        //                this.dgInventoryEntry.Rows[i].Cells[5].Value = string.Format("{0:0.00}", GLTranDetailInventoryEntry[i].curCredit);

        //                this.dgInventoryEntry.Rows[i].Cells[0].ReadOnly = true;
        //                this.dgInventoryEntry.Rows[i].Cells[1].ReadOnly = true;
        //                this.dgInventoryEntry.Rows[i].Cells[2].ReadOnly = true;
        //                this.dgInventoryEntry.Rows[i].Cells[3].ReadOnly = true;
        //                this.dgInventoryEntry.Rows[i].Cells[4].ReadOnly = true;
        //                this.dgInventoryEntry.Rows[i].Cells[5].ReadOnly = true;
        //            }
        //            setRowNumber(this.dgJournalEntry);
        //            this.txtTotalInventoryDebit.Text = string.Format("{0:0.00}", GLTranDetailInventoryEntry.Sum(g => g.curDebit));
        //            this.txtTotalCredit.Text = string.Format("{0:0.00}", GLTranDetailInventoryEntry.Sum(g => g.curCredit));
        //        }

        //        this.ID = Sale.Id;
        //        this.txtID.Text = Sale.Id.ToString();
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show("Error:" + ex.Message);
        //    }
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (this.AgentId == 0)
                {
                    MessageBox.Show("Please select agent...");
                    return;
                }

                if (this.CustomerId == 0)
                {
                    MessageBox.Show("Please select customer...");
                    return;
                }

                if (this.GLTranDetail.Sum(d => d.curCredit) != this.GLTranDetail.Sum(d => d.curDebit))
                {
                    MessageBox.Show("Disbal journal entry");
                    return;
                }

                if (this.SalesDetailsList.Count <= 0)
                {

                    MessageBox.Show("Please check the products");
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
                    Sale = new Sale
                    {
                        Id = this.ID,
                        PONo = this.txtPONo.Text,
                        TRANo = this.txtTransactionNo.Text,
                        intIdAgent = this.AgentId,
                        intIdCustomer = this.CustomerId,
                        Terms = int.TryParse(this.txtTerms.Text, out intParser) ? intParser : 0,
                        Total = decimal.TryParse(this.txtTotal.Text, out decimalParser) ? decimalParser : 0,
                        TransactionDate = this.dtTransactionDate.Value,
                        SOPAmount = decimal.TryParse(this.txtSOPAmount.Text, out decimalParser) ? decimalParser : 0,
                        COMMAmount = decimal.TryParse(this.txtCOMMAmount.Text, out decimalParser) ? decimalParser : 0,
                        CFAmount = decimal.TryParse(this.txtCFAmount.Text, out decimalParser) ? decimalParser : 0,
                        AdditionalDescription = this.txtAdditionalDescription.Text,
                        Description = this.txtDescription.Text
                    };

                    if (Sale.Total < (Sale.CFAmount + Sale.COMMAmount + Sale.SOPAmount))
                    {
                        MessageBox.Show("Please check amount");
                        return;
                    }

                    Sale = SaleServices.Add(Sale, this.GLTranDetail, this.chkUseDefaultEntry.Checked, this.SalesDetailsList);
                    this.SalesDetailsList = Sale.SalesDetails.ToList();

                    if (Sale != null)
                    {
                        MessageBox.Show("Successfully saved");
                        this.txtDescription.Text = Sale.Description;

                    }
                }
                else
                {

                    Sale.PONo = this.txtPONo.Text;
                    Sale.TRANo = this.txtTransactionNo.Text;
                    Sale.intIdAgent = this.AgentId;
                    Sale.intIdCustomer = this.CustomerId;
                    Sale.Terms = int.TryParse(this.txtTerms.Text, out intParser) ? intParser : 0;
                    Sale.Total = decimal.TryParse(this.txtTotal.Text, out decimalParser) ? decimalParser : 0;
                    Sale.TransactionDate = this.dtTransactionDate.Value;
                    Sale.SOPAmount = decimal.TryParse(this.txtSOPAmount.Text, out decimalParser) ? decimalParser : 0;
                    Sale.COMMAmount = decimal.TryParse(this.txtCOMMAmount.Text, out decimalParser) ? decimalParser : 0;
                    Sale.CFAmount = decimal.TryParse(this.txtCFAmount.Text, out decimalParser) ? decimalParser : 0;
                    Sale.Description = this.txtDescription.Text;
                    Sale.AdditionalDescription = this.txtAdditionalDescription.Text;
                    Sale = SaleServices.Update(Sale, this.GLTranDetail, this.chkUseDefaultEntry.Checked, this.SalesDetailsList);
                    this.SalesDetailsList = Sale.SalesDetails.ToList();

                    if (Sale.Total < (Sale.CFAmount + Sale.COMMAmount + Sale.SOPAmount))
                    {
                        MessageBox.Show("Please check amount");
                        return;
                    }
                    if (Sale != null)
                    {
                        MessageBox.Show("Successfully saved");
                        this.txtDescription.Text = Sale.Description;
                    }
                }

                //GLTranHeader = Sale.tblGLTranHeaders.Select(h => h.ID).SingleOrDefault();
                this.GLTranDetail = GLTranServices.GetGLEntryBySalesId(Sale.Id, 6).SelectMany(h => h.tblGLTranDetails).ToList();
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


                this.GLTranDetailInventoryEntry = GLTranServices.GetGLEntryBySalesId(Sale.Id, 1011).SelectMany(h => h.tblGLTranDetails).ToList();
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
                    setRowNumber(this.dgJournalEntry);
                    this.txtTotalInventoryDebit.Text = string.Format("{0:0.00}", GLTranDetailInventoryEntry.Sum(g => g.curDebit));
                    this.txtTotalInventoryCredit.Text = string.Format("{0:0.00}", GLTranDetailInventoryEntry.Sum(g => g.curCredit));
                }

                this.ID = Sale.Id;
                this.txtID.Text = Sale.Id.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }


   

        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

      
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                SearchSale sje = new SearchSale();
                sje.BringToFront();
                sje.TopMost = true;
                sje.IsSales = true;
                DialogResult res = sje.ShowDialog(this);

                if (res == DialogResult.OK)
                {

                    this.ID = sje.Sale.Id;
                    this.Sale.Id = sje.Sale.Id;

                    //this.Sale.agentName.Id = sje.Sale.agentName.Id;
                    //this.Sale.agentName.Name = sje.Sale.agentName.Name;
                    //this.Sale.TRANo = sje.Sale.TRANo;
                    //this.Sale.PONo = sje.Sale.PONo;
                    //this.Sale.Total = sje.Sale.Total;
                    //this.Sale.customerName.Id = sje.Sale.customerName.Id;
                    //this.Sale.customerName.strName = sje.Sale.customerName.strName;

                    this.txtID.Text = Sale.Id.ToString();
                    this.AgentId = sje.Sale.Agent.Id;
                    this.CustomerId = sje.Sale.Customer.Id;
                    this.txtPONo.Text = sje.Sale.PONo;
                    this.txtTransactionNo.Text = sje.Sale.TRANo;
                    this.dtTransactionDate.Value = (DateTime)sje.Sale.TransactionDate;
                    this.txtDescription.Text = sje.Sale.Description;
                    this.txtAdditionalDescription.Text = sje.Sale.AdditionalDescription;
                    this.txtTotal.Text = sje.Sale.Total.ToString();
                    this.txtCustomerID.Text = sje.Sale.Customer.Id.ToString();
                    this.txtCustomerName.Text = sje.Sale.Customer.strName;
                    this.txtAgentID.Text = sje.Sale.Agent.Id.ToString();
                    this.txtAgent.Text = sje.Sale.Agent.Name.ToString();
                    this.txtTerms.Text = sje.Sale.Terms.ToString();
                    this.GLTranHeader = sje.Sale.tblGLTranHeaders.Select(h => h.ID).FirstOrDefault();
                    this.chkUseDefaultEntry.Checked = (bool)sje.Sale.tblGLTranHeaders.Select(h => h.blnUseDefaultEntry).FirstOrDefault();
                    this.GLTranDetail = GLTranServices.GetGLEntryById(this.GLTranHeader).SelectMany(h => h.tblGLTranDetails).ToList();
                    this.txtSOPAmount.Text = sje.Sale.SOPAmount.ToString();
                    this.txtCFAmount.Text = sje.Sale.CFAmount.ToString();
                    this.txtCOMMAmount.Text = sje.Sale.COMMAmount.ToString();
                    this.SalesDetailsList = SaleDetailServices.GetSalesDetailProductBySalesId(this.ID).SelectMany(pr => pr.SalesDetails).ToList();
                

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

                    if (SalesDetailsList.Count > 0)
                    {
                        this.dgProduct.Rows.Clear();
                        this.dgProduct.Refresh();
                        //this.dgProduct.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        this.dgProduct.RowCount = SalesDetailsList.Count;
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
                        Sale.SalesDetails.Clear();

                        for (int i = 0; i < SalesDetailsList.Count; i++)
                        {
                            //display all the data in productList to the datagridview
                            SalesDetail SalesDetail = SalesDetailsList[i];
                            this.Sale.SalesDetails.Add(SalesDetail);
                            this.dgProduct.Rows[i].Cells[0].Value = SalesDetail.Id;
                            this.dgProduct.Rows[i].Cells[1].Value = SalesDetail.Product?.strProductName ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[2].Value = SalesDetail.Product?.strDescription ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[3].Value = 0;
                            this.dgProduct.Rows[i].Cells[4].Value = string.Empty;
                            this.dgProduct.Rows[i].Cells[5].Value = SalesDetail.Product?.ProductCategory?.Id ?? 0;
                            this.dgProduct.Rows[i].Cells[6].Value = SalesDetail.Product?.ProductCategory?.strName ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[7].Value = SalesDetail.Product?.ProductType?.Id ?? 0;
                            this.dgProduct.Rows[i].Cells[8].Value = SalesDetail.Product?.ProductType?.strName ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[9].Value = SalesDetail.Product?.ProductBrand?.Id ?? 0;
                            this.dgProduct.Rows[i].Cells[10].Value = SalesDetail.Product?.ProductBrand?.strName ?? string.Empty;
                            //this.dgProduct.Rows[i].Cells[11].Value = product.PerPieceBox;
                            //this.dgProduct.Rows[i].Cells[12].Value = product.Location.ID;
                            //this.dgProduct.Rows[i].Cells[13].Value = product.Location.Name;
                            this.dgProduct.Rows[i].Cells[14].Value = SalesDetail.Product?.ProductColor?.Id ?? 0;
                            this.dgProduct.Rows[i].Cells[15].Value = SalesDetail.Product?.ProductColor?.strName ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[16].Value = SalesDetail.Product?.ProductSize?.Id ?? 0;
                            this.dgProduct.Rows[i].Cells[17].Value = SalesDetail.Product?.ProductSize?.strName ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[18].Value = SalesDetail.Product?.ProductUnit?.Id ?? 0;
                            this.dgProduct.Rows[i].Cells[19].Value = SalesDetail.Product?.ProductUnit?.strName ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[20].Value = SalesDetail.Product?.strCode ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[21].Value = SalesDetail.Product?.strPR ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[22].Value = SalesDetail.Product?.strPCD ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[23].Value = SalesDetail.Product?.strMFLM ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[24].Value = SalesDetail.Product?.strPattern ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[25].Value = SalesDetail.Product?.strOffsetCenterBore ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[26].Value = SalesDetail.Product?.strOrigin ?? string.Empty;
                            this.dgProduct.Rows[i].Cells[27].Value = SalesDetail.UnitPrice ?? 0;
                            this.dgProduct.Rows[i].Cells[28].Value = SalesDetail.Quantity ?? 0;
                            this.dgProduct.Rows[i].Cells[29].Value = SalesDetail.TotalPrice ?? 0;
                            //this.dgProduct.Rows[i].Cells[27].Value = product.curUnitPrice;
                        }

                        setRowNumber(this.dgJournalEntry);
                        this.txtSalesTotal.Text = string.Format("{0:0.00}", SalesDetailsList.Sum(g => g.TotalPrice));
                        //this.txtTotal.Text = string.Format("{0:0.00}", SalesDetailsList.Sum(g => g.TotalPrice));
                    }


                    this.GLTranDetailInventoryEntry = GLTranServices.GetGLEntryBySalesId(Sale.Id, 1011).SelectMany(h => h.tblGLTranDetails).ToList();
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

        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            //if (this.ID == 0 )
            //{
            //    MessageBox.Show("Please save transaction first before editing entry");
            //    return;
            //}

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
                     tblMasCOA = new tblMasCOA {
                         ID = sca.GLTranDetail.COA.ID,
                         strCode = sca.GLTranDetail.COA.strCode,
                         strName = sca.GLTranDetail.COA.strName
                     },
                     tblMasCOASub = new tblMasCOASub { 
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
                    Sale = new Sale
                    {
                        Id = this.ID,
                        PONo = this.txtPONo.Text,
                        TRANo = this.txtTransactionNo.Text,
                        intIdAgent = this.AgentId,
                        intIdCustomer = this.CustomerId,
                        Total = decimal.TryParse(this.txtTotal.Text, out decimalParser) ? decimalParser : 0,
                        TransactionDate = this.dtTransactionDate.Value,
                        Description = this.txtDescription.Text
                    };

                    SaleServices.Remove(Sale, this.SalesDetailsList);

                    if (Sale != null)
                    {
                        this.ID = 0;
                        this.txtID.Text = string.Empty;
                        this.txtPONo.Text = string.Empty;
                        this.txtTransactionNo.Text = string.Empty;
                        this.AgentId = 0;
                        this.CustomerId = 0;
                        this.txtAgent.Text = string.Empty;
                        this.txtCustomerID.Text = string.Empty;
                        this.txtAgentID.Text = string.Empty;
                        this.txtCustomerName.Text = string.Empty;
                        this.txtTerms.Text = string.Empty;
                        this.dgProduct.Rows.Clear();
                        this.dgProduct.Refresh();
                        this.SalesDetailsList = new List<SalesDetail>();
                        this.GLTranDetailInventoryEntry.Clear();
                        this.dgInventoryEntry.Rows.Clear();
                        this.dgInventoryEntry.Refresh();
                        this.dgJournalEntry.Rows.Clear();
                        this.dgJournalEntry.Refresh();
                        this.GLTranDetail.Clear();
                        this.GLTranHeader = 0;
                        this.txtTotalDebit.Text = string.Empty;
                        this.txtTotalCredit.Text = string.Empty;
                        this.txtTotal.Text = string.Empty;
                        this.txtDescription.Text = string.Empty;
                        this.txtCFAmount.Text = String.Empty;
                        this.txtCOMMAmount.Text = String.Empty;
                        this.txtSOPAmount.Text = String.Empty;
                        this.txtTotalInventoryCredit.Text = string.Empty;
                        this.txtTotalInventoryDebit.Text = string.Empty;
                        this.txtSalesTotal.Text = string.Empty;
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
            this.txtPONo.Text = string.Empty;
            this.txtTransactionNo.Text = string.Empty;
            this.AgentId = 0;
            this.CustomerId = 0;
            this.txtAgent.Text = string.Empty;
            this.txtCustomerID.Text = string.Empty;
            this.txtAgentID.Text = string.Empty;
            this.txtCustomerName.Text = string.Empty;
            this.txtTerms.Text = string.Empty;
            this.dgProduct.Rows.Clear();
            this.dgProduct.Refresh();
            this.SalesDetailsList = new List<SalesDetail>();
            this.GLTranDetailInventoryEntry.Clear();
            this.dgInventoryEntry.Rows.Clear();
            this.dgInventoryEntry.Refresh();
            this.dgJournalEntry.Rows.Clear();
            this.dgJournalEntry.Refresh();
            this.GLTranDetail.Clear();
            this.GLTranHeader = 0;
            this.txtTotalDebit.Text = string.Empty;
            this.txtTotalCredit.Text = string.Empty;
            this.txtTotal.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            this.txtCFAmount.Text = String.Empty;
            this.txtCOMMAmount.Text = String.Empty;
            this.txtSOPAmount.Text = String.Empty;
            this.txtTotalInventoryCredit.Text = string.Empty;
            this.txtTotalInventoryDebit.Text = string.Empty;
            this.txtSalesTotal.Text = string.Empty;
            this.txtAdditionalDescription.Text = string.Empty;
            GLTranDetail = new List<tblGLTranDetail>();
            this.Sale.SalesDetails = new List<SalesDetail>();
            GLTranDetailInventoryEntry = new List<tblGLTranDetail>();
           

        }

        private void frmSales_Load(object sender, EventArgs e)
        {

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
                metroTabPage.Text = "Sales Ledger";
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

                frmSalesLedger frmSalesLedger = new frmSalesLedger(this.ID);
                frmSalesLedger.Parent = metroTabPage;
                frmSalesLedger.MetroTabPage = metroTabPage;
                frmSalesLedger.AutoScroll = true;
                frmSalesLedger.MetroTabControl = this.MetroTabControl;
  
                metroTabPage.Controls.Add(frmSalesLedger);
                MetroTabControl.TabPages.Add(metroTabPage);
                MetroTabControl.SelectedTab = metroTabPage;
               
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

        private void btnChooseProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {

            frmChooseProduct frmChooseProduct = new frmChooseProduct();
            frmChooseProduct.BringToFront();
            frmChooseProduct.TopMost = true;
            frmChooseProduct.IsSales = true;
            DialogResult res = frmChooseProduct.ShowDialog(this);

            if (res == DialogResult.OK)
            {
                var convertSaleDetail = new SalesDetail
                {
                    ProductId = frmChooseProduct.Product.Id,
                    Product = frmChooseProduct.Product,
                    UnitPrice = frmChooseProduct.ProductTotalUnitPrice,
                    Quantity = frmChooseProduct.ProductQuantity,
                    TotalPrice = frmChooseProduct.ProductTotalQuantityPrice,
                };

                if (!SalesDetailsList.Any(p => p.ProductId == convertSaleDetail.ProductId))
                {
                    this.SalesDetailsList.Add(convertSaleDetail);
                }
                else
                {
                    MessageBox.Show("Product already added");
                    return;
                }

                if (SalesDetailsList.Count > 0)
                {
                    this.dgProduct.Rows.Clear();
                    this.dgProduct.Refresh();
                    this.dgProduct.RowCount = SalesDetailsList.Count;
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
                    //this.dgProduct.Columns[27].Name = "Selling Price";
                    this.dgProduct.Columns[28].Name = "Quantity";
                    this.dgProduct.Columns[29].Name = "Total Quantity Price";

                    for (int i = 0; i < SalesDetailsList.Count; i++)
                    {
                        SalesDetail saleDetail = SalesDetailsList[i];
                        this.dgProduct.Rows[i].Cells[0].Value = saleDetail.Id;
                        this.dgProduct.Rows[i].Cells[1].Value = saleDetail.Product?.strProductName ?? string.Empty;
                        this.dgProduct.Rows[i].Cells[2].Value = saleDetail.Product?.strDescription ?? string.Empty;
                        //this.dgProduct.Rows[i].Cells[3].Value = saleDetail.Product.ProductCharacteristic.Id;
                        //this.dgProduct.Rows[i].Cells[4].Value = saleDetail.Product.ProductCharacteristic.strName;
                        //this.dgProduct.Rows[i].Cells[5].Value = saleDetail.Product.ProductCategory.Id;
                        //this.dgProduct.Rows[i].Cells[6].Value = saleDetail.Product.ProductCategory.strName;
                        this.dgProduct.Rows[i].Cells[7].Value = saleDetail.Product.ProductType.Id;
                        this.dgProduct.Rows[i].Cells[8].Value = saleDetail.Product.ProductType.strName;
                        this.dgProduct.Rows[i].Cells[9].Value = saleDetail.Product.ProductBrand.Id;
                        this.dgProduct.Rows[i].Cells[10].Value = saleDetail.Product.ProductBrand.strName;
                        //this.dgProduct.Rows[i].Cells[11].Value = product.PerPieceBox;
                        //this.dgProduct.Rows[i].Cells[12].Value = product.Location.ID;
                        //this.dgProduct.Rows[i].Cells[13].Value = product.Location.Name;
                        this.dgProduct.Rows[i].Cells[14].Value = saleDetail.Product?.ProductColor?.Id ?? 0;
                        this.dgProduct.Rows[i].Cells[15].Value = saleDetail.Product?.ProductColor?.strName ?? string.Empty;
                        this.dgProduct.Rows[i].Cells[16].Value = saleDetail.Product?.ProductSize?.Id ?? 0;
                        this.dgProduct.Rows[i].Cells[17].Value = saleDetail.Product?.ProductSize?.strName ?? string.Empty;
                        this.dgProduct.Rows[i].Cells[18].Value = saleDetail.Product.ProductUnit.Id;
                        this.dgProduct.Rows[i].Cells[19].Value = saleDetail.Product?.ProductUnit?.strName ?? string.Empty;
                        this.dgProduct.Rows[i].Cells[20].Value = saleDetail.Product?.strCode ?? string.Empty;
                        this.dgProduct.Rows[i].Cells[21].Value = saleDetail.Product?.strPR ?? string.Empty;
                        this.dgProduct.Rows[i].Cells[22].Value = saleDetail.Product?.strPCD ?? string.Empty;
                        this.dgProduct.Rows[i].Cells[23].Value = saleDetail.Product?.strMFLM ?? string.Empty;
                        this.dgProduct.Rows[i].Cells[24].Value = saleDetail.Product?.strPattern ?? string.Empty;
                        this.dgProduct.Rows[i].Cells[25].Value = saleDetail.Product?.strOffsetCenterBore ?? string.Empty;
                        this.dgProduct.Rows[i].Cells[26].Value = saleDetail.Product?.strOrigin ?? string.Empty;
                        //this.dgProduct.Rows[i].Cells[27].Value = saleDetail.Product.curSellingPrice;
                        this.dgProduct.Rows[i].Cells[28].Value = saleDetail.Quantity ?? 0;
                        this.dgProduct.Rows[i].Cells[29].Value = saleDetail.TotalPrice ?? 0;
                        //this.dgProduct.Rows[i].Cells[27].Value = product.curUnitPrice;
                    }

                    setRowNumber(this.dgJournalEntry);
                    this.txtSalesTotal.Text = string.Format("{0:0.00}", SalesDetailsList.Sum(g => g.TotalPrice));
                    //this.txtTotal.Text = string.Format("{0:0.00}", SalesDetailsList.Sum(g => g.TotalPrice));
                }
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {


                if (SalesDetailsList.Count > 0)
                {
                    this.SalesDetailsList.RemoveAt(this.IndexGridInventory);
                    this.dgProduct.Rows.Clear();
                    this.dgProduct.Refresh();

                    if (SalesDetailsList.Count == 0)
                    {
                        return;
                    }
                    //this.dgProduct.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    this.dgProduct.RowCount = SalesDetailsList.Count;
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

                    for (int i = 0; i < SalesDetailsList.Count; i++)
                    {
                        //display all the data in productList to the datagridview
                        SalesDetail saleDetail = SalesDetailsList[i];
                        this.dgProduct.Rows[i].Cells[0].Value = saleDetail.Id;
                        this.dgProduct.Rows[i].Cells[1].Value = saleDetail.Product.strProductName;
                        this.dgProduct.Rows[i].Cells[2].Value = saleDetail.Product.strDescription;
                        //this.dgProduct.Rows[i].Cells[3].Value = saleDetail.Product.ProductCharacteristic.Id;
                        //this.dgProduct.Rows[i].Cells[4].Value = saleDetail.Product.ProductCharacteristic.strName;
                        this.dgProduct.Rows[i].Cells[5].Value = saleDetail.Product.ProductCategory.Id;
                        this.dgProduct.Rows[i].Cells[6].Value = saleDetail.Product.ProductCategory.strName;
                        this.dgProduct.Rows[i].Cells[7].Value = saleDetail.Product.ProductType.Id;
                        this.dgProduct.Rows[i].Cells[8].Value = saleDetail.Product.ProductType.strName;
                        this.dgProduct.Rows[i].Cells[9].Value = saleDetail.Product.ProductBrand.Id;
                        this.dgProduct.Rows[i].Cells[10].Value = saleDetail.Product.ProductBrand.strName;
                        //this.dgProduct.Rows[i].Cells[11].Value = product.PerPieceBox;
                        //this.dgProduct.Rows[i].Cells[12].Value = product.Location.ID;
                        //this.dgProduct.Rows[i].Cells[13].Value = product.Location.Name;
                        this.dgProduct.Rows[i].Cells[14].Value = saleDetail.Product.ProductColor.Id;
                        this.dgProduct.Rows[i].Cells[15].Value = saleDetail.Product.ProductColor.strName;
                        this.dgProduct.Rows[i].Cells[16].Value = saleDetail.Product.ProductSize.Id;
                        this.dgProduct.Rows[i].Cells[17].Value = saleDetail.Product.ProductSize.strName;
                        this.dgProduct.Rows[i].Cells[18].Value = saleDetail.Product.ProductUnit.Id;
                        this.dgProduct.Rows[i].Cells[19].Value = saleDetail.Product.ProductUnit.strName;
                        this.dgProduct.Rows[i].Cells[20].Value = saleDetail.Product.strCode;
                        this.dgProduct.Rows[i].Cells[21].Value = saleDetail.Product.strPR;
                        this.dgProduct.Rows[i].Cells[22].Value = saleDetail.Product.strPCD;
                        this.dgProduct.Rows[i].Cells[23].Value = saleDetail.Product.strMFLM;
                        this.dgProduct.Rows[i].Cells[24].Value = saleDetail.Product.strPattern;
                        this.dgProduct.Rows[i].Cells[25].Value = saleDetail.Product.strOffsetCenterBore;
                        this.dgProduct.Rows[i].Cells[26].Value = saleDetail.Product.strOrigin;
                        this.dgProduct.Rows[i].Cells[27].Value = saleDetail.UnitPrice;
                        this.dgProduct.Rows[i].Cells[28].Value = saleDetail.Quantity;
                        this.dgProduct.Rows[i].Cells[29].Value = saleDetail.TotalPrice;
                        //this.dgProduct.Rows[i].Cells[27].Value = product.curUnitPrice;
                    }

                    setRowNumber(this.dgJournalEntry);
                    this.txtSalesTotal.Text = string.Format("{0:0.00}", SalesDetailsList.Sum(g => g.TotalPrice));
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
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

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == '/')
            {
                e.Handled = true; // Suppress the '/' character
            }
        }
    }
}
