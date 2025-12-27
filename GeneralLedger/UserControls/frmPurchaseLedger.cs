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
    public partial class frmPurchaseLedger : MetroUserControl
    {

        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }
        public int Id { get; set; }
        public string TransactionNo { get; set; }
        public string CustomerName { get; set; }
        public string POno { get; set; }
        public decimal Total { get; set; }
        public DateTime TransactionDate { get; set; }
        public PurchaseServices PurchaseServices { get; set; }

        public PurchaseSupplierLedgerServices PurchaseSupplierLedgerServices { get; set; }

        public frmPurchaseLedger(int id)
        {
            this.Id = id;
            PurchaseServices = new PurchaseServices();
            PurchaseSupplierLedgerServices = new PurchaseSupplierLedgerServices();
            InitializeComponent();
           
        }

        //private void frmSalesLedger_Load(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var purchase = this.PurchaseServices.GetPurchaseWithSupplier(this.Id);
        //        this.txtID.Text = purchase.Id.ToString();
        //        this.txtTransactionNo.Text = purchase.TRANo;
        //        this.txtPONo.Text = purchase.PONo;
        //        this.dtTransactionDate.Value = (DateTime)purchase.TransactionDate;
        //        this.txtTotal.Text = string.Format("{0:0.00}", purchase.Total);
        //        this.txtSupplierName.Text = purchase.Supplier.strName;
        //        //this.txtAgent.Text = sale.Agent.Name;

        //        var saleLedger = this.SalesCustomerLedgerServices.GetSalesCustomerLedger(this.Id).ToList();

        //        var runningBalance = saleLedger.OrderByDescending(l => l.ID).Select(l => l.curRunningBalance).FirstOrDefault();
        //        this.txtRunningBalance.Text = string.Format("{0:0.00}", runningBalance);

        //        if (saleLedger != null && saleLedger.Count() > 0) {
        //            this.dtgPurchaseLedger.RowCount = saleLedger.Count();

        //            for (int i = 0; i < saleLedger.Count(); i++)
        //            {
        //                this.dtgPurchaseLedger.Rows[i].Cells["ID"].Value = saleLedger[i].ID;
        //                this.dtgPurchaseLedger.Rows[i].Cells["intIdSalesCustomerLedgerTransactionType"].Value = saleLedger[i].intIdSalesCustomerLedgerTransctionType;
        //                this.dtgPurchaseLedger.Rows[i].Cells["strType"].Value = saleLedger[i].strType;
        //                this.dtgPurchaseLedger.Rows[i].Cells["intIdSales"].Value = saleLedger[i].intIdSales;
        //                this.dtgPurchaseLedger.Rows[i].Cells["intIdCollection"].Value = saleLedger[i].intIdCollection;
        //                this.dtgPurchaseLedger.Rows[i].Cells["intIdAccountReceivableAdjustment"].Value = saleLedger[i].intIdAccountReceivableAdjustment;
        //                this.dtgPurchaseLedger.Rows[i].Cells["strTransactionNo"].Value = saleLedger[i].strTransactionNo;
        //                this.dtgPurchaseLedger.Rows[i].Cells["datDateTransaction"].Value = saleLedger[i].datDateTransaction.Value.ToShortDateString();
        //                this.dtgPurchaseLedger.Rows[i].Cells["curTotalAmount"].Value = string.Format("{0:0.00}", saleLedger[i].curTotalAmount);
        //                this.dtgPurchaseLedger.Rows[i].Cells["curRunningBalance"].Value = string.Format("{0:0.00}", saleLedger[i].curRunningBalance);
        //            }
        //        }
        //        else
        //        {
        //            this.dtgPurchaseLedger.Rows.Clear();
        //            this.dtgPurchaseLedger.Refresh();
        //            MessageBox.Show("No Result");
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.dtgPurchaseLedger.Rows.Clear();
                this.dtgPurchaseLedger.Refresh();

                var purchase = this.PurchaseServices.GetPurchaseWithSupplier(this.Id);
                this.txtID.Text = purchase.Id.ToString();
                this.txtTransactionNo.Text = purchase.TRANo;
                this.txtPONo.Text = purchase.PONo;
                this.dtTransactionDate.Value = (DateTime)purchase.TransactionDate;
                this.txtTotal.Text = string.Format("{0:0.00}", purchase.Total);
                this.txtSupplierName.Text = purchase.Supplier.strName;

                var purchaseLedger = this.PurchaseSupplierLedgerServices.GetPurchaseSupplierLedger(this.Id).ToList();

                var runningBalance = purchaseLedger.OrderByDescending(l => l.ID).Select(l => l.curRunningBalance).FirstOrDefault();
                this.txtRunningBalance.Text = string.Format("{0:0.00}", runningBalance);

                if (purchaseLedger != null && purchaseLedger.Count() > 0)
                {
                    this.dtgPurchaseLedger.RowCount = purchaseLedger.Count();

                    for (int i = 0; i < purchaseLedger.Count(); i++)
                    {
                        this.dtgPurchaseLedger.Rows[i].Cells["ID"].Value = purchaseLedger[i].ID;
                        this.dtgPurchaseLedger.Rows[i].Cells["intIdPurchaseCustomerLedgerTransctionType"].Value = purchaseLedger[i].intIdPurchaseCustomerLedgerTransctionType;
                        this.dtgPurchaseLedger.Rows[i].Cells["strType"].Value = purchaseLedger[i].strType;
                        this.dtgPurchaseLedger.Rows[i].Cells["intIdPurchase"].Value = purchaseLedger[i].intIdPurchase;
                        this.dtgPurchaseLedger.Rows[i].Cells["intIdPayment"].Value = purchaseLedger[i].intIdPayment;
                        this.dtgPurchaseLedger.Rows[i].Cells["intIdAccountPayableAdjustment"].Value = purchaseLedger[i].intIdAccountPayableAdjustment;
                        this.dtgPurchaseLedger.Rows[i].Cells["strTransactionNo"].Value = purchaseLedger[i].strTransactionNo;
                        this.dtgPurchaseLedger.Rows[i].Cells["datDateTransaction"].Value = purchaseLedger[i].datDateTransaction.Value.ToShortDateString();
                        this.dtgPurchaseLedger.Rows[i].Cells["curTotalAmount"].Value = string.Format("{0:0.00}", purchaseLedger[i].curTotalAmount);
                        this.dtgPurchaseLedger.Rows[i].Cells["curRunningBalance"].Value = string.Format("{0:0.00}", purchaseLedger[i].curRunningBalance);
                    }
                }
                else
                {
                    this.dtgPurchaseLedger.Rows.Clear();
                    this.dtgPurchaseLedger.Refresh();
                    MessageBox.Show("No Result");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void frmPurchaseLedger_Load(object sender, EventArgs e)
        {
            //Implement GetPurchaseSupplierLedger
            try
            {
                var purchase = this.PurchaseServices.GetPurchaseWithSupplier(this.Id);
                this.txtID.Text = purchase.Id.ToString();
                this.txtTransactionNo.Text = purchase.TRANo;
                this.txtPONo.Text = purchase.PONo;
                this.dtTransactionDate.Value = (DateTime)purchase.TransactionDate;
                this.txtTotal.Text = string.Format("{0:0.00}", purchase.Total);
                this.txtSupplierName.Text = purchase.Supplier.strName;

                var purchaseLedger = this.PurchaseSupplierLedgerServices.GetPurchaseSupplierLedger(this.Id).ToList();

                var runningBalance = purchaseLedger.OrderByDescending(l => l.ID).Select(l => l.curRunningBalance).FirstOrDefault();
                this.txtRunningBalance.Text = string.Format("{0:0.00}", runningBalance);

                if (purchaseLedger != null && purchaseLedger.Count() > 0)
                {
                    this.dtgPurchaseLedger.RowCount = purchaseLedger.Count();

                    for (int i = 0; i < purchaseLedger.Count(); i++)
                    {
                        this.dtgPurchaseLedger.Rows[i].Cells["ID"].Value = purchaseLedger[i].ID;
                        this.dtgPurchaseLedger.Rows[i].Cells["intIdPurchaseCustomerLedgerTransctionType"].Value = purchaseLedger[i].intIdPurchaseCustomerLedgerTransctionType;
                        this.dtgPurchaseLedger.Rows[i].Cells["strType"].Value = purchaseLedger[i].strType;
                        this.dtgPurchaseLedger.Rows[i].Cells["intIdPurchase"].Value = purchaseLedger[i].intIdPurchase;
                        this.dtgPurchaseLedger.Rows[i].Cells["intIdPayment"].Value = purchaseLedger[i].intIdPayment;
                        this.dtgPurchaseLedger.Rows[i].Cells["intIdAccountPayableAdjustment"].Value = purchaseLedger[i].intIdAccountPayableAdjustment;
                        this.dtgPurchaseLedger.Rows[i].Cells["strTransactionNo"].Value = purchaseLedger[i].strTransactionNo;
                        this.dtgPurchaseLedger.Rows[i].Cells["datDateTransaction"].Value = purchaseLedger[i].datDateTransaction.Value.ToShortDateString();
                        this.dtgPurchaseLedger.Rows[i].Cells["curTotalAmount"].Value = string.Format("{0:0.00}", purchaseLedger[i].curTotalAmount);
                        this.dtgPurchaseLedger.Rows[i].Cells["curRunningBalance"].Value = string.Format("{0:0.00}", purchaseLedger[i].curRunningBalance);
                    }
                }
                else
                {
                    this.dtgPurchaseLedger.Rows.Clear();
                    this.dtgPurchaseLedger.Refresh();
                    MessageBox.Show("No Result");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }



        }
    }
}
