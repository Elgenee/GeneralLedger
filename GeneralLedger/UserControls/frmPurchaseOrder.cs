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
    public partial class frmPurchaseOrder : MetroUserControl
    {

        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }
        public List<Product> ListOfProducts { get; set; }
        public int Index { get; set; }

        public Product Product { get; set; }

        public int ID { get; set; }

        public frmPurchaseOrder()
        {
            InitializeComponent();
            ListOfProducts = new List<Product>();
            this.Index = -1;
        }

        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        private void btnChooseProduct_Click(object sender, EventArgs e)
        {
            try
            {
                SearchChooseProduct scp = new SearchChooseProduct();
                scp.BringToFront();
                scp.TopMost = true;
                DialogResult res = scp.ShowDialog(this);

                if (res == DialogResult.OK)
                {
                    int selectedProductDetailID = scp.Product.ProductDetails[0].ID;


                    if (ListOfProducts.Where(p => p.ProductDetails.Exists(pd => pd.ID == selectedProductDetailID)).Count() > 0)
                    {
                        MessageBox.Show("Already Exist");
                        return;
                    }

                    this.ListOfProducts.Add(scp.Product);

                    if (ListOfProducts.Count > 0)
                    {
                        this.dgPurchaseOrderDetails.RowCount = ListOfProducts.Count;

                        for (int i = 0; i < ListOfProducts.Count; i++)
                        {
                            this.dgPurchaseOrderDetails.Rows[i].Cells["ProductDetailsID"].Value = ListOfProducts[i].ProductDetails[0].ID;
                            this.dgPurchaseOrderDetails.Rows[i].Cells["ProductName"].Value = ListOfProducts[i].ProductName;
                            this.dgPurchaseOrderDetails.Rows[i].Cells["ProductColor"].Value = ListOfProducts[i].ProductDetails[0].ProductColor.Name;
                            this.dgPurchaseOrderDetails.Rows[i].Cells["ProductSize"].Value = ListOfProducts[i].ProductDetails[0].ProductSize.Name;
                            this.dgPurchaseOrderDetails.Rows[i].Cells["CurStock"].Value = ListOfProducts[i].ProductDetails[0].CurStock;
                            this.dgPurchaseOrderDetails.Rows[i].Cells["ActStock"].Value = ListOfProducts[i].ProductDetails[0].ActStock;
                            this.dgPurchaseOrderDetails.Rows[i].Cells["Quantity"].Value = ListOfProducts[i].ProductDetails[0].Quantity;
                            this.dgPurchaseOrderDetails.Rows[i].Cells["QuantityReceived"].Value = ListOfProducts[i].ProductDetails[0].QuantityReceived;
                            this.dgPurchaseOrderDetails.Rows[i].Cells["Cost"].Value = ListOfProducts[i].ProductDetails[0].Cost.ToString("N", CultureInfo.InvariantCulture);
                            this.dgPurchaseOrderDetails.Rows[i].Cells["SubTotal"].Value = ListOfProducts[i].ProductDetails[0].Subtotal.ToString("N", CultureInfo.InvariantCulture);

                        }
                        setRowNumber(this.dgPurchaseOrderDetails);
                        computation();
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
         }


        private void computation() {

            decimal decimalParser;

            var totalQuantity = this.ListOfProducts.Sum(p => p.ProductDetails.Sum(pd => pd.Quantity));
            var subTotal = this.ListOfProducts.Sum(p => p.ProductDetails.Sum(pd => pd.Subtotal));
            var discountPecentage = decimal.TryParse(this.txtDiscountPercentage.Text, out decimalParser) ? decimalParser / 100 : 0;
            var discountAmount = decimal.TryParse(this.txtDiscountAmount.Text, out decimalParser) ? decimalParser : 0;
            var totalReceived = this.ListOfProducts.Sum(p => p.ProductDetails.Sum(pd => pd.QuantityReceived));

            var grandTotal = subTotal - (subTotal * discountPecentage);
            grandTotal -= discountAmount;

            this.lblTotalQuantity.Text = totalQuantity.ToString();
            this.lblSubtotal.Text = subTotal.ToString("N", CultureInfo.InvariantCulture);
            this.lblGrandtotal.Text = grandTotal.ToString("N", CultureInfo.InvariantCulture);
            this.lblTotalReceived.Text = totalReceived.ToString();

            if (this.chkHasPayment.Checked)
            {
                var amountpaid = decimal.TryParse(this.txtAmountPaid.Text, out decimalParser) ? decimalParser : 0;
                var result = (grandTotal - amountpaid);
               

                if (result < 0)
                {
                    result *= -1;
                    this.lblChange.Text = result.ToString("N", CultureInfo.InvariantCulture);
                    this.chkAddBalanceToSupplier.Visible = true;
                }
                else
                {
                    result = 0;
                    this.lblChange.Text = result.ToString("N", CultureInfo.InvariantCulture);
                    this.chkAddBalanceToSupplier.Visible = false;
                }
            }


        }
        private void frmPurchaseOrder_Load(object sender, EventArgs e)
        {

            try
            {
                LocationBAL locationBAL = new LocationBAL();
                List<GeneralLedger.Tier.BO.Location> locationList = locationBAL.getLocation();

                this.cbLocation.DataSource = locationList;
                this.cbLocation.ValueMember = "ID";
                this.cbLocation.DisplayMember = "Name";


                SupplierBAL supplierBAL = new SupplierBAL();
                List<GeneralLedger.Tier.BO.Supplier> supplierList = supplierBAL.getSupplier(string.Empty);

                this.cbSupplier.DataSource = supplierList;
                this.cbSupplier.ValueMember = "ID";
                this.cbSupplier.DisplayMember = "Name";
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

        private void txtDiscountAmount_ValueChanged(object sender, EventArgs e)
        {
            computation();
        }

        private void txtDiscountPercentage_ValueChanged(object sender, EventArgs e)
        {
            computation();
        }

        private void chkHasPayment_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.chkHasPayment.Checked)
            {
                this.txtAmountPaid.Enabled = true;
            }
            else
            {
                this.txtAmountPaid.Enabled = false;
            }
        }

        private void txtAmountPaid_ValueChanged(object sender, EventArgs e)
        {
            //decimal decimalParser;
            //var grandtotal = decimal.TryParse(this.lblGrandtotal.Text, out decimalParser) ? decimalParser : 0;
            //var amountpaid = decimal.TryParse(this.txtAmountPaid.Text, out decimalParser) ? decimalParser : 0;
            //var result = grandtotal - amountpaid;
            //this.lblChange.Text = result.ToString();
            computation();
        }

        private void dgPurchaseOrderDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Index = e.RowIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void dgPurchaseOrderDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Index = e.RowIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {

            try
            {
                int intParser;
                decimal decimalParser;
                if (this.Index < 0)
                {
                    MessageBox.Show("Please Select Product");
                    return;
                }

                Product = new Product
                {
                    ProductName = this.dgPurchaseOrderDetails.Rows[this.Index].Cells["ProductName"].Value.ToString(),
                    ProductDetails = new List<SearchProductAndColorAndSize>() {
                       new SearchProductAndColorAndSize {
                           ID = int.TryParse(this.dgPurchaseOrderDetails.Rows[this.Index].Cells["ProductDetailsID"].Value.ToString() , out intParser) ? intParser : 0,
                           ProductColor = new Tier.BO.ProductColor {
                                Name = this.dgPurchaseOrderDetails.Rows[this.Index].Cells["ProductColor"].Value.ToString()
                           },
                           ProductSize = new Tier.BO.ProductSize {
                               Name = this.dgPurchaseOrderDetails.Rows[this.Index].Cells["ProductSize"].Value.ToString()
                           },
                           CurStock =  int.TryParse(this.dgPurchaseOrderDetails.Rows[this.Index].Cells["CurStock"].Value.ToString() , out intParser) ? intParser : 0,
                           ActStock = int.TryParse(this.dgPurchaseOrderDetails.Rows[this.Index].Cells["ActStock"].Value.ToString() , out intParser) ? intParser : 0,
                           Cost = decimal.TryParse(this.dgPurchaseOrderDetails.Rows[this.Index].Cells["Cost"].Value.ToString(), out decimalParser) ? decimalParser : 0,
                           Quantity = int.TryParse(this.dgPurchaseOrderDetails.Rows[this.Index].Cells["Quantity"].Value.ToString() , out intParser) ? intParser : 0,
                           QuantityReceived = int.TryParse(this.dgPurchaseOrderDetails.Rows[this.Index].Cells["QuantityReceived"].Value.ToString() , out intParser) ? intParser : 0,
                           Subtotal =  decimal.TryParse(this.dgPurchaseOrderDetails.Rows[this.Index].Cells["SubTotal"].Value.ToString(), out decimalParser) ? decimalParser : 0,
                        }
                    }
                };


                EditPurchaseOrderProduct epop = new EditPurchaseOrderProduct();
                epop.BringToFront();
                epop.TopMost = true;
                epop.Product = this.Product;
                DialogResult res = epop.ShowDialog(this);

                if (res == DialogResult.OK)
                {
                    var obj = this.ListOfProducts.
                        FirstOrDefault(p => p.ProductDetails.Any(pd => pd.ID.Equals(epop.Product.ProductDetails[0].ID)));

                  

                    if (obj != null)
                    {
                        obj.ProductDetails[0].Quantity = epop.Product.ProductDetails[0].Quantity;
                        obj.ProductDetails[0].Cost = epop.Product.ProductDetails[0].Cost;
                        obj.ProductDetails[0].Subtotal = epop.Product.ProductDetails[0].Subtotal;
                        obj.ProductDetails[0].QuantityReceived = epop.Product.ProductDetails[0].QuantityReceived;

                        if (ListOfProducts.Count > 0)
                        {

                            this.dgPurchaseOrderDetails.Refresh();
                            this.dgPurchaseOrderDetails.Rows.Clear();
                            this.dgPurchaseOrderDetails.RowCount = ListOfProducts.Count;

                            for (int i = 0; i < ListOfProducts.Count; i++)
                            {
                                this.dgPurchaseOrderDetails.Rows[i].Cells["ProductDetailsID"].Value = ListOfProducts[i].ProductDetails[0].ID;
                                this.dgPurchaseOrderDetails.Rows[i].Cells["ProductName"].Value = ListOfProducts[i].ProductName;
                                this.dgPurchaseOrderDetails.Rows[i].Cells["ProductColor"].Value = ListOfProducts[i].ProductDetails[0].ProductColor.Name;
                                this.dgPurchaseOrderDetails.Rows[i].Cells["ProductSize"].Value = ListOfProducts[i].ProductDetails[0].ProductSize.Name;
                                this.dgPurchaseOrderDetails.Rows[i].Cells["CurStock"].Value = ListOfProducts[i].ProductDetails[0].CurStock;
                                this.dgPurchaseOrderDetails.Rows[i].Cells["ActStock"].Value = ListOfProducts[i].ProductDetails[0].ActStock;
                                this.dgPurchaseOrderDetails.Rows[i].Cells["Quantity"].Value = ListOfProducts[i].ProductDetails[0].Quantity;
                                this.dgPurchaseOrderDetails.Rows[i].Cells["QuantityReceived"].Value = ListOfProducts[i].ProductDetails[0].QuantityReceived;
                                this.dgPurchaseOrderDetails.Rows[i].Cells["Cost"].Value = ListOfProducts[i].ProductDetails[0].Cost.ToString("N", CultureInfo.InvariantCulture);
                                this.dgPurchaseOrderDetails.Rows[i].Cells["SubTotal"].Value = ListOfProducts[i].ProductDetails[0].Subtotal.ToString("N", CultureInfo.InvariantCulture);

                            }


                            setRowNumber(this.dgPurchaseOrderDetails);
                            computation();
                        }
                    }
                }

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
                int intParser;
                decimal decimalParser;
                if (this.Index < 0)
                {
                    MessageBox.Show("Please Select Product");
                    return;
                }

                int ProductDetailID = ListOfProducts[Index].ProductDetails[0].ID;
                var obj = this.ListOfProducts.
                      FindIndex(p => p.ProductDetails.Any(pd => pd.ID.Equals(ProductDetailID)));

                this.ListOfProducts.RemoveAt(obj);

                if (ListOfProducts.Count > -1)
                {

                    this.dgPurchaseOrderDetails.Refresh();
                    this.dgPurchaseOrderDetails.Rows.Clear();
                    this.dgPurchaseOrderDetails.RowCount = ListOfProducts.Count;

                    for (int i = 0; i < ListOfProducts.Count; i++)
                    {
                        this.dgPurchaseOrderDetails.Rows[i].Cells["ProductDetailsID"].Value = ListOfProducts[i].ProductDetails[0].ID;
                        this.dgPurchaseOrderDetails.Rows[i].Cells["ProductName"].Value = ListOfProducts[i].ProductName;
                        this.dgPurchaseOrderDetails.Rows[i].Cells["ProductColor"].Value = ListOfProducts[i].ProductDetails[0].ProductColor.Name;
                        this.dgPurchaseOrderDetails.Rows[i].Cells["ProductSize"].Value = ListOfProducts[i].ProductDetails[0].ProductSize.Name;
                        this.dgPurchaseOrderDetails.Rows[i].Cells["CurStock"].Value = ListOfProducts[i].ProductDetails[0].CurStock;
                        this.dgPurchaseOrderDetails.Rows[i].Cells["ActStock"].Value = ListOfProducts[i].ProductDetails[0].ActStock;
                        this.dgPurchaseOrderDetails.Rows[i].Cells["Quantity"].Value = ListOfProducts[i].ProductDetails[0].Quantity;
                        this.dgPurchaseOrderDetails.Rows[i].Cells["QuantityReceived"].Value = ListOfProducts[i].ProductDetails[0].QuantityReceived;
                        this.dgPurchaseOrderDetails.Rows[i].Cells["Cost"].Value = ListOfProducts[i].ProductDetails[0].Cost.ToString("N", CultureInfo.InvariantCulture);
                        this.dgPurchaseOrderDetails.Rows[i].Cells["SubTotal"].Value = ListOfProducts[i].ProductDetails[0].Subtotal.ToString("N", CultureInfo.InvariantCulture);

                    }


                    setRowNumber(this.dgPurchaseOrderDetails);
                    computation();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }
     
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                decimal decimalParser;

                int SupplierID = (this.cbSupplier.SelectedItem == null) ? 0 : ((Tier.BO.Supplier)this.cbSupplier.SelectedItem).ID;
                int LocationID = (this.cbLocation.SelectedItem == null) ? 0 : ((Tier.BO.Location)this.cbLocation.SelectedItem).ID;


                string TransType = (this.ID == 0) ? "insert" : "update";

                var purchaseOrder = new PurchaseOrder {
                      ID = this.ID,
                      DatePurchased = this.dtBatchDate.Text,
                      PONumber = this.txtPONumber.Text,
                      SupplierID = SupplierID,
                      LocationID = LocationID,        
                      ListOfProduct = this.ListOfProducts,
                      TotalQuantity = decimal.TryParse(this.lblTotalQuantity.Text , out decimalParser) ? decimalParser : 0,
                      TotalReceived = decimal.TryParse(this.lblTotalReceived.Text, out decimalParser) ? decimalParser : 0,
                      SubTotal = decimal.TryParse(this.lblSubtotal.Text, out decimalParser) ? decimalParser : 0,
                      DiscountAmount = decimal.TryParse(this.txtDiscountAmount.Text , out decimalParser)? decimalParser : 0,
                      DiscountPercentage = decimal.TryParse(this.txtDiscountPercentage.Text, out decimalParser) ? decimalParser : 0,
                      GrandTotal = decimal.TryParse(this.lblGrandtotal.Text, out decimalParser) ? decimalParser : 0,
                      HasPayment = this.chkHasPayment.Checked,
                      AmountPaid = decimal.TryParse(this.txtAmountPaid.Text, out decimalParser) ? decimalParser : 0,
                      Change = decimal.TryParse(this.lblChange.Text, out decimalParser) ? decimalParser : 0,
                      AddBalanceToSupplier = this.chkAddBalanceToSupplier.Checked,
                      Approved = this.chkApproved.Checked,
                      CreatedBy = 1 //admin
                };


                PurchaseOrderBAL purchaseOrderBAL = new PurchaseOrderBAL();
                string result = purchaseOrderBAL.Manage(purchaseOrder, TransType);



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
