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
    public partial class formReceivePurchaseOrder :  MetroUserControl
    {

        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }
        public int ID { get; set; }

        public formReceivePurchaseOrder(int PurchaseOrderID , string PurchaseOrderNumber , int TotalQuantity , int TotalReceived , int TotalRemaining)
        {

            try
            {
                InitializeComponent();
                this.txtPurchaseOrderID.Text = PurchaseOrderID.ToString();
                this.txtPurchaseOrderNumber.Text = PurchaseOrderNumber;
                this.lblTotalProducts.Text = TotalQuantity.ToString();
                this.lblTotalReceived.Text = TotalReceived.ToString();
                this.lblTotalRemaining.Text = TotalRemaining.ToString();

                PurchaseOrderReceivingBAL purchaseOrderReceivingBAL = new PurchaseOrderReceivingBAL();
                List<PurchaseOrderReceivingStatusDetails> purchaseOrderReceivingStatusDetailsList = purchaseOrderReceivingBAL.GetPurchaseOrderReceivingStatusDetails(PurchaseOrderID);
                if (purchaseOrderReceivingStatusDetailsList.Count > 0)
                {
                    this.dgPurchaseOrderReceivingDetails.RowCount = purchaseOrderReceivingStatusDetailsList.Count;

                    for (int i = 0; i < purchaseOrderReceivingStatusDetailsList.Count; i++)
                    {
                        this.dgPurchaseOrderReceivingDetails.Rows[i].Cells["dgPurchaseOrderDetailID"].Value = purchaseOrderReceivingStatusDetailsList[i].PurchaseOrderDetailID;
                        this.dgPurchaseOrderReceivingDetails.Rows[i].Cells["dgProductDetailID"].Value = purchaseOrderReceivingStatusDetailsList[i].PurchaseOrderDetailID;
                        this.dgPurchaseOrderReceivingDetails.Rows[i].Cells["dgProductName"].Value = purchaseOrderReceivingStatusDetailsList[i].ProductName;
                        this.dgPurchaseOrderReceivingDetails.Rows[i].Cells["dgProductColor"].Value = purchaseOrderReceivingStatusDetailsList[i].ProductColor.Name;
                        this.dgPurchaseOrderReceivingDetails.Rows[i].Cells["dgProductSize"].Value = purchaseOrderReceivingStatusDetailsList[i].ProductSize.Name;
                        this.dgPurchaseOrderReceivingDetails.Rows[i].Cells["dgProductUnit"].Value = purchaseOrderReceivingStatusDetailsList[i].Unit;
                        this.dgPurchaseOrderReceivingDetails.Rows[i].Cells["dgQuantity"].Value = purchaseOrderReceivingStatusDetailsList[i].Quantity;
                        this.dgPurchaseOrderReceivingDetails.Rows[i].Cells["dgQuantityReceived"].Value = purchaseOrderReceivingStatusDetailsList[i].QuantityReceived;
                        this.dgPurchaseOrderReceivingDetails.Rows[i].Cells["dgQuantityRemaining"].Value = purchaseOrderReceivingStatusDetailsList[i].QuantityRemaining;
                        this.dgPurchaseOrderReceivingDetails.Rows[i].Cells["dgReceivedStatusID"].Value = purchaseOrderReceivingStatusDetailsList[i].ReceivingStatus.ID;
                        this.dgPurchaseOrderReceivingDetails.Rows[i].Cells["dgReceivedStatus"].Value = purchaseOrderReceivingStatusDetailsList[i].ReceivingStatus.Name;
                        this.dgPurchaseOrderReceivingDetails.Rows[i].Cells["dgAddedQuantityReceived"].Value = purchaseOrderReceivingStatusDetailsList[i].AddedQuantityReceived;
                        this.dgPurchaseOrderReceivingDetails.Rows[i].Cells["dgIsReceived"].Value = false;
                        this.dgPurchaseOrderReceivingDetails.Rows[i].Cells["Receive"].Value = "Receive";
                        this.dgPurchaseOrderReceivingDetails.Rows[i].Cells["ViewHistory"].Value = "View History";
                        //this.dgPurchaseOrderReceivingDetails.Rows[i].Cells["dgIsReceived"].Value = true;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
          

        }

        public formReceivePurchaseOrder()
        {
            InitializeComponent();


        }

        private void formReceivePurchaseOrder_Load(object sender, EventArgs e)
        {

            LocationBAL locationBAL = new LocationBAL();
            List<GeneralLedger.Tier.BO.Location> locationList = locationBAL.getLocation();

            this.cbLocation.DataSource = locationList;
            this.cbLocation.ValueMember = "ID";
            this.cbLocation.DisplayMember = "Name";
        }

        private void dgPurchaseOrderReceivingDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                int intParser;
                if (e.RowIndex >= 0)
                {
                    EditPurchaseOrderReceivingDetailsDG editPurchaseOrderReceivingDetailsDG = new EditPurchaseOrderReceivingDetailsDG();
                    editPurchaseOrderReceivingDetailsDG.BringToFront();
                    editPurchaseOrderReceivingDetailsDG.TopMost = true;

                    editPurchaseOrderReceivingDetailsDG.purchaseOrderReceivingStatusDetails.PurchaseOrderDetailID = int.TryParse(this.dgPurchaseOrderReceivingDetails.Rows[e.RowIndex].Cells["dgPurchaseOrderDetailID"].Value.ToString(), out intParser) ? intParser : 0;
                    editPurchaseOrderReceivingDetailsDG.purchaseOrderReceivingStatusDetails.ProductName = this.dgPurchaseOrderReceivingDetails.Rows[e.RowIndex].Cells["dgProductName"].Value.ToString();
                    editPurchaseOrderReceivingDetailsDG.purchaseOrderReceivingStatusDetails.ProductColor.Name = this.dgPurchaseOrderReceivingDetails.Rows[e.RowIndex].Cells["dgProductColor"].Value.ToString();
                    editPurchaseOrderReceivingDetailsDG.purchaseOrderReceivingStatusDetails.ProductSize.Name = this.dgPurchaseOrderReceivingDetails.Rows[e.RowIndex].Cells["dgProductSize"].Value.ToString();
                    editPurchaseOrderReceivingDetailsDG.purchaseOrderReceivingStatusDetails.Unit = this.dgPurchaseOrderReceivingDetails.Rows[e.RowIndex].Cells["dgProductUnit"].Value.ToString();
                    editPurchaseOrderReceivingDetailsDG.purchaseOrderReceivingStatusDetails.Quantity = int.TryParse(this.dgPurchaseOrderReceivingDetails.Rows[e.RowIndex].Cells["dgQuantity"].Value.ToString(), out intParser) ? intParser : 0;
                    editPurchaseOrderReceivingDetailsDG.purchaseOrderReceivingStatusDetails.QuantityReceived = int.TryParse(this.dgPurchaseOrderReceivingDetails.Rows[e.RowIndex].Cells["dgQuantityReceived"].Value.ToString(), out intParser) ? intParser : 0;
                    editPurchaseOrderReceivingDetailsDG.purchaseOrderReceivingStatusDetails.QuantityRemaining = int.TryParse(this.dgPurchaseOrderReceivingDetails.Rows[e.RowIndex].Cells["dgQuantityRemaining"].Value.ToString(), out intParser) ? intParser : 0;
                    editPurchaseOrderReceivingDetailsDG.purchaseOrderReceivingStatusDetails.ReceivingStatus.Name = this.dgPurchaseOrderReceivingDetails.Rows[e.RowIndex].Cells["dgReceivedStatus"].Value.ToString();
                    editPurchaseOrderReceivingDetailsDG.purchaseOrderReceivingStatusDetails.AddedQuantityReceived = int.TryParse(this.dgPurchaseOrderReceivingDetails.Rows[e.RowIndex].Cells["dgAddedQuantityReceived"].Value.ToString(), out intParser) ? intParser : 0;

                    DialogResult res = editPurchaseOrderReceivingDetailsDG.ShowDialog(this);

                    if (res == DialogResult.OK)
                    {
                        
                        this.dgPurchaseOrderReceivingDetails.Rows[e.RowIndex].Cells["dgQuantityReceived"].Value = editPurchaseOrderReceivingDetailsDG.purchaseOrderReceivingStatusDetails.QuantityReceived;
                        this.dgPurchaseOrderReceivingDetails.Rows[e.RowIndex].Cells["dgQuantityRemaining"].Value = editPurchaseOrderReceivingDetailsDG.purchaseOrderReceivingStatusDetails.QuantityRemaining;
                        this.dgPurchaseOrderReceivingDetails.Rows[e.RowIndex].Cells["dgIsReceived"].Value = editPurchaseOrderReceivingDetailsDG.IsReceived;
                        this.dgPurchaseOrderReceivingDetails.Rows[e.RowIndex].Cells["dgReceivedStatus"].Value = editPurchaseOrderReceivingDetailsDG.purchaseOrderReceivingStatusDetails.ReceivingStatus.Name;
                        this.dgPurchaseOrderReceivingDetails.Rows[e.RowIndex].Cells["dgReceivedStatusID"].Value = editPurchaseOrderReceivingDetailsDG.purchaseOrderReceivingStatusDetails.ReceivingStatus.ID;
                        this.dgPurchaseOrderReceivingDetails.Rows[e.RowIndex].Cells["dgAddedQuantityReceived"].Value = editPurchaseOrderReceivingDetailsDG.purchaseOrderReceivingStatusDetails.AddedQuantityReceived;

                        sumDataGrid();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }


        }


        private void sumDataGrid() {

            int TotalReceived = 0;
            int TotalRemaining = 0;


            for (int i = 0; i < this.dgPurchaseOrderReceivingDetails.Rows.Count; i++)
            {
                TotalReceived += Convert.ToInt32(dgPurchaseOrderReceivingDetails.Rows[i].Cells["dgQuantityReceived"].Value);
                TotalRemaining += Convert.ToInt32(dgPurchaseOrderReceivingDetails.Rows[i].Cells["dgQuantityRemaining"].Value);

            }


            this.lblTotalReceived.Text = TotalReceived.ToString();
            this.lblTotalRemaining.Text = TotalRemaining.ToString();


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var purchaseOrderReceivingStatusDetailsList = new List<PurchaseOrderReceivingStatusDetails>();
                int intParser;
                bool boolParser;
                int LocationID = (this.cbLocation.SelectedItem == null) ? 0 : ((Tier.BO.Location)this.cbLocation.SelectedItem).ID;

                string TransType = "insert";

                if (this.dgPurchaseOrderReceivingDetails.RowCount > 0 )
                {

                    for (int i = 0; i < this.dgPurchaseOrderReceivingDetails.RowCount; i++)
                    {
                        var a = this.dgPurchaseOrderReceivingDetails.Rows[i].Cells["dgIsReceived"].Value.ToString();
                        var purchaseOrderReceivingStatusDetails = new PurchaseOrderReceivingStatusDetails {
                             PurchaseOrderDetailID = int.TryParse(this.dgPurchaseOrderReceivingDetails.Rows[i].Cells["dgPurchaseOrderDetailID"].Value.ToString(), out intParser) ? intParser : 0,
                              Quantity = int.TryParse(this.dgPurchaseOrderReceivingDetails.Rows[i].Cells["dgQuantity"].Value.ToString(), out intParser) ? intParser : 0,
                              QuantityReceived = int.TryParse(this.dgPurchaseOrderReceivingDetails.Rows[i].Cells["dgQuantityReceived"].Value.ToString(), out intParser) ? intParser : 0,
                              QuantityRemaining = int.TryParse(this.dgPurchaseOrderReceivingDetails.Rows[i].Cells["dgQuantityRemaining"].Value.ToString(), out intParser) ? intParser : 0,
                              ReceivingStatusID = int.TryParse(this.dgPurchaseOrderReceivingDetails.Rows[i].Cells["dgReceivedStatusID"].Value.ToString(), out intParser) ? intParser : 0,
                              AddedQuantityReceived = int.TryParse(this.dgPurchaseOrderReceivingDetails.Rows[i].Cells["dgAddedQuantityReceived"].Value.ToString(), out intParser) ? intParser : 0,
                              IsReceived = bool.TryParse(this.dgPurchaseOrderReceivingDetails.Rows[i].Cells["dgIsReceived"].Value.ToString(), out boolParser) ? boolParser : false,

                        };

            
                        purchaseOrderReceivingStatusDetailsList.Add(purchaseOrderReceivingStatusDetails);
                    }
                }


                var purchaseOrderReceiving = new PurchaseOrderReceiving
                {
                     PurchaseOrderID = int.TryParse(this.txtPurchaseOrderID.Text, out intParser) ? intParser : 0,
                     DateReceived = this.dtReceivedDate.Text,
                     LocationID = LocationID,
                     Address = this.txtAddress.Text,
                     Memo = this.txtMemo.Text,
                     TotalQuantity = int.TryParse(this.lblTotalProducts.Text, out intParser) ? intParser : 0,
                     TotalReceived = int.TryParse(this.lblTotalReceived.Text, out intParser) ? intParser : 0,
                     TotalRemaining = int.TryParse(this.lblTotalRemaining.Text, out intParser) ? intParser : 0,
                     PurchaseOrderReceivingStatusDetailsList = purchaseOrderReceivingStatusDetailsList

                };

                PurchaseOrderReceivingBAL purchaseOrderReceivingBAL = new PurchaseOrderReceivingBAL();
                string result =  purchaseOrderReceivingBAL.Manage(purchaseOrderReceiving, TransType);
                if (result != string.Empty)
                {
                    this.ID = Convert.ToInt32(result.Split(',')[0]);
                    //this.txtID.Text = result.Split(',')[0];
                    //RefreshGrid();
                    MessageBox.Show("Successfully saved");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}
