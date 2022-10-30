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

namespace GeneralLedger.UserControls
{
    public partial class frmPurchaseOrderIndex : MetroUserControl
    {

        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }

        public frmPurchaseOrderIndex()
        {
            InitializeComponent();
            refreshForApproval();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }

        private void btnNewPurchaseOrder_Click(object sender, EventArgs e)
        {
            MetroTabPage metroTabPage = new MetroTabPage();
            metroTabPage.Text = "New Purchase Order";
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

            frmPurchaseOrder frmPurchaseOrder = new frmPurchaseOrder();
            frmPurchaseOrder.Parent = metroTabPage;
            frmPurchaseOrder.MetroTabPage = metroTabPage;
            frmPurchaseOrder.MetroTabControl = this.MetroTabControl;
            metroTabPage.Controls.Add(frmPurchaseOrder);
            MetroTabControl.TabPages.Add(metroTabPage);
            MetroTabControl.SelectedTab = metroTabPage;

        }

        private void superTabControl1_Enter(object sender, EventArgs e)
        {
            
        }

        private void superTabControl1_SelectedTabChanged(object sender, DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs e)
        {
   
            switch (e.NewValue.Name)
            {
                case "tabForApproval":
                    refreshForApproval();
                    break;
                case "tabPending":
                    refreshForPending();
                    break;
                default:
                    MessageBox.Show(e.NewValue.Name);
                    break;
            }
        }

        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }


        private void refreshForApproval() {

            try
            {
                PurchaseOrderBAL purOrdBAL = new PurchaseOrderBAL();
                List<PurchaseOrder> purchaseOrderListForApproval = purOrdBAL.spGetPurchaseOrderForApproval();


                if (purchaseOrderListForApproval.Count > 0)
                {
                    this.dgForApproval.RowCount = purchaseOrderListForApproval.Count;

                    for (int i = 0; i < purchaseOrderListForApproval.Count; i++)
                    {
                        this.dgForApproval.Rows[i].Cells["ForApprovalPOID"].Value = purchaseOrderListForApproval[i].ID;
                        this.dgForApproval.Rows[i].Cells["ForApprovalPONumber"].Value = purchaseOrderListForApproval[i].PONumber;
                        this.dgForApproval.Rows[i].Cells["ForApprovalDatePurchased"].Value = purchaseOrderListForApproval[i].DatePurchased;
                        this.dgForApproval.Rows[i].Cells["ForApprovalSupplier"].Value = purchaseOrderListForApproval[i].Supplier.Name;
                        this.dgForApproval.Rows[i].Cells["ForApprovalLocation"].Value = purchaseOrderListForApproval[i].Location.Name;
                        this.dgForApproval.Rows[i].Cells["ForApprovalTotalAmount"].Value = purchaseOrderListForApproval[i].GrandTotal;
                        this.dgForApproval.Rows[i].Cells["ForApprovalApproved"].Value = "Approve";
                    }

                    setRowNumber(this.dgForApproval);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }

        }


        private void refreshForPending()
        {

            try
            {
                PurchaseOrderBAL purOrdBAL = new PurchaseOrderBAL();
                List<PurchaseOrder> purchaseOrderListForPending = purOrdBAL.spGetPurchaseOrderForPending();


                if (purchaseOrderListForPending.Count > 0)
                {
                    this.dgPending.RowCount = purchaseOrderListForPending.Count;

                    for (int i = 0; i < purchaseOrderListForPending.Count; i++)
                    {
                        this.dgPending.Rows[i].Cells["dgPendingPOID"].Value = purchaseOrderListForPending[i].ID;
                        this.dgPending.Rows[i].Cells["dgPendingPONumber"].Value = purchaseOrderListForPending[i].PONumber;
                        this.dgPending.Rows[i].Cells["dgPendingDatePurchased"].Value = purchaseOrderListForPending[i].DatePurchased;
                        this.dgPending.Rows[i].Cells["dgPendingSupplier"].Value = purchaseOrderListForPending[i].Supplier.Name;
                        this.dgPending.Rows[i].Cells["dgPendingLocation"].Value = purchaseOrderListForPending[i].Location.Name;
                        this.dgPending.Rows[i].Cells["dgPendingTotalAmount"].Value = purchaseOrderListForPending[i].GrandTotal;
                        this.dgPending.Rows[i].Cells["dgPendingTotalQuantity"].Value = purchaseOrderListForPending[i].TotalQuantity;
                        this.dgPending.Rows[i].Cells["dgPendingTotalReceived"].Value = purchaseOrderListForPending[i].TotalReceived;
                        this.dgPending.Rows[i].Cells["dgPendingTotalRemaining"].Value = purchaseOrderListForPending[i].TotalQuantity - purchaseOrderListForPending[i].TotalReceived;
                        this.dgPending.Rows[i].Cells["dgPendingViewDetails"].Value = "View Details";
                        this.dgPending.Rows[i].Cells["dgPendingEdit"].Value = "Edit";
                        this.dgPending.Rows[i].Cells["dgPendingReceived"].Value = "Receive";
                        this.dgPending.Rows[i].Cells["dgPendingPay"].Value = "Pay";
                        this.dgPending.Rows[i].Cells["dgPendingCancel"].Value = "Cancel";
                    }
                    //dgPending
                    setRowNumber(this.dgPending);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void dgForApproval_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 )
            {
                //this.ForApprovalApproved

                if (e.ColumnIndex == this.ForApprovalApproved.Index)
                {
                    int intParser;
                    var POID = int.TryParse(this.dgForApproval["ForApprovalPOID", e.RowIndex].Value.ToString() , out intParser) ? intParser : 0;
                    string TransType = "update";
                    PurchaseOrderBAL purchaseOrderBAL = new PurchaseOrderBAL();
                    string result = purchaseOrderBAL.spManageApprovePurchaseOrder(POID, TransType, 1);


                    if (result != string.Empty)
                    {
                        //this.ID = Convert.ToInt32(result.Split(',')[0]);
                        //this.txtID.Text = result.Split(',')[0];
                        //RefreshGrid();
                        MessageBox.Show("Successfully saved");
                    }
                    //MessageBox.Show(PO.ID + " - " + PO.Supplier);
                }

            }
        }

        private void dgPending_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == this.dgPendingReceived.Index)
                {

                    MetroTabPage metroTabPage = new MetroTabPage();
                    metroTabPage.Text = "Receive Purchase Order";
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

                    int intParser;
                    var POID = int.TryParse(this.dgPending["dgPendingPOID", e.RowIndex].Value.ToString(), out intParser) ? intParser : 0;
                    var PONumber = this.dgPending["dgPendingPONumber", e.RowIndex].Value.ToString();
                    var TotalQuantity = int.TryParse(this.dgPending["dgPendingTotalQuantity", e.RowIndex].Value.ToString(), out intParser) ? intParser : 0;
                    var TotalReceived = int.TryParse(this.dgPending["dgPendingTotalReceived", e.RowIndex].Value.ToString(), out intParser) ? intParser : 0;
                    var TotalRemaining = int.TryParse(this.dgPending["dgPendingTotalRemaining", e.RowIndex].Value.ToString(), out intParser) ? intParser : 0;

                    formReceivePurchaseOrder frmReceivePurchaseOrder = new formReceivePurchaseOrder(POID, PONumber , TotalQuantity , TotalReceived , TotalRemaining);
                    frmReceivePurchaseOrder.Parent = metroTabPage;
                    frmReceivePurchaseOrder.MetroTabPage = metroTabPage;
                    frmReceivePurchaseOrder.MetroTabControl = this.MetroTabControl;
                    metroTabPage.Controls.Add(frmReceivePurchaseOrder);
                    MetroTabControl.TabPages.Add(metroTabPage);
                    MetroTabControl.SelectedTab = metroTabPage;


       
                }
            }
        }
    }
}
