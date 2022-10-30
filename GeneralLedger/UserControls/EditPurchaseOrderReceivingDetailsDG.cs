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
using GeneralLedger.Tier.BAL;
using GeneralLedger.Tier.BO;


namespace GeneralLedger.UserControls
{
    public partial class EditPurchaseOrderReceivingDetailsDG : MetroForm
    {

        public PurchaseOrderReceivingStatusDetails purchaseOrderReceivingStatusDetails { get; set; }

        public bool IsReceived { get; set; }
        public EditPurchaseOrderReceivingDetailsDG()
        {
            InitializeComponent();
            purchaseOrderReceivingStatusDetails = new PurchaseOrderReceivingStatusDetails();
            purchaseOrderReceivingStatusDetails.ProductColor = new Tier.BO.ProductColor();
            purchaseOrderReceivingStatusDetails.ProductSize = new Tier.BO.ProductSize();
            purchaseOrderReceivingStatusDetails.ReceivingStatus = new Tier.BO.ReceivingStatus();
            this.txtQuantityReceived.IsInputReadOnly = true;
            this.txtQuantityReceived.ShowUpDown = false;
            this.txtQuantityReceived.BackgroundStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtQuantityReceived.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.ControlLight;

            if (chkIsReceived.Checked)
            {
                this.txtQuantityReceived.IsInputReadOnly = false;
                this.txtQuantityReceived.ShowUpDown = true;
                this.txtQuantityReceived.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
                this.txtQuantityReceived.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.Window;
            }
            else
            {

                this.txtQuantityReceived.IsInputReadOnly = true;
                this.txtQuantityReceived.ShowUpDown = false;
                this.txtQuantityReceived.BackgroundStyle.BackColor = System.Drawing.SystemColors.ControlLight;
                this.txtQuantityReceived.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.ControlLight;
            }

        }

        private void EditPurchaseOrderReceivingDetailsDG_Load(object sender, EventArgs e)
        {
            this.txtPurchaseOrderDetailID.Text = purchaseOrderReceivingStatusDetails.PurchaseOrderDetailID.ToString();
            this.txtProductName.Text = purchaseOrderReceivingStatusDetails.ProductName;
            this.txtProductColor.Text = purchaseOrderReceivingStatusDetails.ProductColor.Name;
            this.txtProductSize.Text = purchaseOrderReceivingStatusDetails.ProductSize.Name;
            this.txtProductUnit.Text = purchaseOrderReceivingStatusDetails.Unit;
            this.txtQuantity.Text = purchaseOrderReceivingStatusDetails.Quantity.ToString();
            this.txtQuantityReceived.Text = purchaseOrderReceivingStatusDetails.QuantityReceived.ToString();
            this.txtRemaining.Text = purchaseOrderReceivingStatusDetails.QuantityRemaining.ToString();
            this.txtReceivingStatus.Text = purchaseOrderReceivingStatusDetails.ReceivingStatus.Name;

        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsReceived.Checked)
            {
                this.txtQuantityReceived.IsInputReadOnly = false;
                this.txtQuantityReceived.ShowUpDown = true;
                this.txtQuantityReceived.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
                this.txtQuantityReceived.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.Window;
            }
            else
            {
      
                this.txtQuantityReceived.IsInputReadOnly = true;
                this.txtQuantityReceived.ShowUpDown = false;
                this.txtQuantityReceived.BackgroundStyle.BackColor = System.Drawing.SystemColors.ControlLight;
                this.txtQuantityReceived.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.ControlLight;
            }
        }

        private void txtQuantityReceived_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnAddColorAndSize_Click(object sender, EventArgs e)
        {
            int intParser;

            int NewReceivedQuantity = int.TryParse(this.txtQuantityReceived.Text, out intParser) ? intParser : 0;

            if (this.chkIsReceived.Checked)
            {
                if (NewReceivedQuantity < purchaseOrderReceivingStatusDetails.QuantityReceived)
                {
                    MessageBox.Show("New quantity received value must not be less than the current value");
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //TODO:saving purchase order receiving
            int intParser;
            int Quantity = int.TryParse(this.txtQuantity.Text, out intParser) ? intParser : 0;
            int NewReceivedQuantity = int.TryParse(this.txtQuantityReceived.Text, out intParser) ? intParser : 0;

            if (this.chkIsReceived.Checked)
            {
                if (NewReceivedQuantity == purchaseOrderReceivingStatusDetails.QuantityReceived)
                {
                    MessageBox.Show("New Quantity Received is equal to the Current Quantity Received");
                    return;
                }

                if (NewReceivedQuantity > Quantity)
                {
                    MessageBox.Show("Quantity received { "+ NewReceivedQuantity + " } is greater than the quantity ordered { "+ Quantity  + " }");
                    this.txtQuantityReceived.Text = purchaseOrderReceivingStatusDetails.QuantityReceived.ToString();
                    this.txtReceivingStatus.Text = purchaseOrderReceivingStatusDetails.ReceivingStatus.Name;
                    return;
                }

                if (NewReceivedQuantity < purchaseOrderReceivingStatusDetails.QuantityReceived)
                {
                    MessageBox.Show("New quantity received { " + NewReceivedQuantity + " } value must not be less than the current value { "+ purchaseOrderReceivingStatusDetails.QuantityReceived + " }");
                    this.txtQuantityReceived.Text = purchaseOrderReceivingStatusDetails.QuantityReceived.ToString();
                    this.txtReceivingStatus.Text = purchaseOrderReceivingStatusDetails.ReceivingStatus.Name;
                    return;
                }
                purchaseOrderReceivingStatusDetails.AddedQuantityReceived = NewReceivedQuantity - purchaseOrderReceivingStatusDetails.QuantityReceived;
                purchaseOrderReceivingStatusDetails.QuantityReceived = NewReceivedQuantity;
                int QuantityRemaining = int.TryParse(this.txtRemaining.Text, out intParser) ? intParser : 0;
                purchaseOrderReceivingStatusDetails.QuantityRemaining = QuantityRemaining;
               


                //Get data on dbo.PurchaseOrderReceivingStatus
                if (NewReceivedQuantity == Quantity)
                {
                    purchaseOrderReceivingStatusDetails.ReceivingStatus.ID = 3;
                    purchaseOrderReceivingStatusDetails.ReceivingStatus.Name = "All Received";
                }

                if (NewReceivedQuantity == 0)
                {
                    purchaseOrderReceivingStatusDetails.ReceivingStatus.ID = 1;
                    purchaseOrderReceivingStatusDetails.ReceivingStatus.Name = "None Received";
                }

                if (NewReceivedQuantity > 0 && NewReceivedQuantity < Quantity)
                {
                    purchaseOrderReceivingStatusDetails.ReceivingStatus.ID = 2;
                    purchaseOrderReceivingStatusDetails.ReceivingStatus.Name = "Partially Received";
                }

                IsReceived = this.chkIsReceived.Checked;


                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void txtQuantityReceived_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtQuantityReceived_KeyPress(object sender, KeyEventArgs e)
        {

        }

        private void checkReceived() {

            if (this.chkIsReceived.Checked)
            {

                int intParser;

                int Quantity = int.TryParse(this.txtQuantity.Text, out intParser) ? intParser : 0;
                int NewReceivedQuantity = int.TryParse(this.txtQuantityReceived.Text, out intParser) ? intParser : 0;
                int QuantityRemaining = int.TryParse(this.txtRemaining.Text, out intParser) ? intParser : 0;

                //if (NewReceivedQuantity > Quantity)
                //{
                //    MessageBox.Show("Quantity received is greater than the quantity ordered");
                //    this.txtQuantityReceived.Text = purchaseOrderReceivingStatusDetails.QuantityReceived.ToString();
                  
                //}

                //if (NewReceivedQuantity < purchaseOrderReceivingStatusDetails.QuantityReceived)
                //{
                //    MessageBox.Show("New quantity received value must not be less than the current value");
                //    this.txtQuantityReceived.Text = purchaseOrderReceivingStatusDetails.QuantityReceived.ToString();
                  
                //}

                int result = Quantity - NewReceivedQuantity;
                this.txtRemaining.Text = result.ToString();

                if (NewReceivedQuantity == Quantity)
                {
                    this.txtReceivingStatus.Text = "All Received";
                }

                if (NewReceivedQuantity == 0)
                {
                    this.txtReceivingStatus.Text = "None Received";
                }

                if (NewReceivedQuantity > 0 && NewReceivedQuantity < Quantity)
                {
                    this.txtReceivingStatus.Text = "Partially Received";
                }

            }
        }

        private void txtQuantityReceived_KeyPress(object sender, EventArgs e)
        {
            try
            {
  
                checkReceived();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}
