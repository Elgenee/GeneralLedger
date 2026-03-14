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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data.Entity.Infrastructure;

namespace GeneralLedger.UserControls
{
    public partial class frmInventoryAdjustmentDMCM : MetroUserControl
    {
        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }
        public InventoryAdjustment InventoryAdjustment { get; set; }
        public InventoryAdjustmentServices InventoryAdjustmentServices { get; set; }
        public InventoryAdjustmentDetailServices InventoryAdjustmentDetailServices { get; set; }

        public InventoryAdjustmentTypeServices InventoryAdjustmentTypeServices { get; set; }
        public int ID { get; set; }
        public List<tblGLTranDetail> GLTranDetail { get; set; }
        public int IndexGridInventory { get; set; }
        public List<InventoryAdjustmentDetail> InventoryAdjustmentDetailsList { get; set; }


        public frmInventoryAdjustmentDMCM()
        {
            InventoryAdjustmentServices = new InventoryAdjustmentServices();
            InventoryAdjustmentDetailsList = new List<InventoryAdjustmentDetail>();
            GLTranDetail = new List<tblGLTranDetail>();
            InventoryAdjustmentTypeServices = new InventoryAdjustmentTypeServices();
            this.InventoryAdjustment = new InventoryAdjustment();
            this.InventoryAdjustmentDetailServices = new InventoryAdjustmentDetailServices();
            InitializeComponent();
           
        }

        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
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


                if (InventoryAdjustmentDetailsList.Count > 0)
                {
                    this.InventoryAdjustmentDetailsList.RemoveAt(this.IndexGridInventory);
                    this.dgProduct.Rows.Clear();
                    this.dgProduct.Refresh();

                    if (InventoryAdjustmentDetailsList.Count == 0)
                    {
                        return;
                    }
                    //this.dgProduct.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    this.dgProduct.RowCount = InventoryAdjustmentDetailsList.Count;
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

                    for (int i = 0; i < InventoryAdjustmentDetailsList.Count; i++)
                    {
                        //display all the data in productList to the datagridview
                        InventoryAdjustmentDetail inventoryAdjustmentDetailsList = InventoryAdjustmentDetailsList[i];
                        this.dgProduct.Rows[i].Cells[0].Value = inventoryAdjustmentDetailsList.Id;
                        this.dgProduct.Rows[i].Cells[1].Value = inventoryAdjustmentDetailsList.Product.strProductName;
                        this.dgProduct.Rows[i].Cells[2].Value = inventoryAdjustmentDetailsList.Product.strDescription;
                        //this.dgProduct.Rows[i].Cells[3].Value = saleDetail.Product.ProductCharacteristic.Id;
                        //this.dgProduct.Rows[i].Cells[4].Value = saleDetail.Product.ProductCharacteristic.strName;
                        this.dgProduct.Rows[i].Cells[5].Value = inventoryAdjustmentDetailsList.Product.ProductCategory.Id;
                        this.dgProduct.Rows[i].Cells[6].Value = inventoryAdjustmentDetailsList.Product.ProductCategory.strName;
                        this.dgProduct.Rows[i].Cells[7].Value = inventoryAdjustmentDetailsList.Product.ProductType.Id;
                        this.dgProduct.Rows[i].Cells[8].Value = inventoryAdjustmentDetailsList.Product.ProductType.strName;
                        this.dgProduct.Rows[i].Cells[9].Value = inventoryAdjustmentDetailsList.Product.ProductBrand.Id;
                        this.dgProduct.Rows[i].Cells[10].Value = inventoryAdjustmentDetailsList.Product.ProductBrand.strName;
                        //this.dgProduct.Rows[i].Cells[11].Value = product.PerPieceBox;
                        //this.dgProduct.Rows[i].Cells[12].Value = product.Location.ID;
                        //this.dgProduct.Rows[i].Cells[13].Value = product.Location.Name;
                        this.dgProduct.Rows[i].Cells[14].Value = inventoryAdjustmentDetailsList.Product.ProductColor.Id;
                        this.dgProduct.Rows[i].Cells[15].Value = inventoryAdjustmentDetailsList.Product.ProductColor.strName;
                        this.dgProduct.Rows[i].Cells[16].Value = inventoryAdjustmentDetailsList.Product.ProductSize.Id;
                        this.dgProduct.Rows[i].Cells[17].Value = inventoryAdjustmentDetailsList.Product.ProductSize.strName;
                        this.dgProduct.Rows[i].Cells[18].Value = inventoryAdjustmentDetailsList.Product.ProductUnit.Id;
                        this.dgProduct.Rows[i].Cells[19].Value = inventoryAdjustmentDetailsList.Product.ProductUnit.strName;
                        this.dgProduct.Rows[i].Cells[20].Value = inventoryAdjustmentDetailsList.Product.strCode;
                        this.dgProduct.Rows[i].Cells[21].Value = inventoryAdjustmentDetailsList.Product.strPR;
                        this.dgProduct.Rows[i].Cells[22].Value = inventoryAdjustmentDetailsList.Product.strPCD;
                        this.dgProduct.Rows[i].Cells[23].Value = inventoryAdjustmentDetailsList.Product.strMFLM;
                        this.dgProduct.Rows[i].Cells[24].Value = inventoryAdjustmentDetailsList.Product.strPattern;
                        this.dgProduct.Rows[i].Cells[25].Value = inventoryAdjustmentDetailsList.Product.strOffsetCenterBore;
                        this.dgProduct.Rows[i].Cells[26].Value = inventoryAdjustmentDetailsList.Product.strOrigin;
                        this.dgProduct.Rows[i].Cells[27].Value = inventoryAdjustmentDetailsList.UnitPrice;
                        this.dgProduct.Rows[i].Cells[28].Value = inventoryAdjustmentDetailsList.Quantity;
                        this.dgProduct.Rows[i].Cells[29].Value = inventoryAdjustmentDetailsList.TotalPrice;
                        //this.dgProduct.Rows[i].Cells[27].Value = product.curUnitPrice;
                    }

                    //setRowNumber(this.dgJournalEntry);
                    //this.txtSalesTotal.Text = string.Format("{0:0.00}", SalesDetailsList.Sum(g => g.TotalPrice));
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }



        private void btnAddProduct_Click(object sender, EventArgs e)
        {

            frmChooseProductInventoryAdjustment frmChooseProduct = new frmChooseProductInventoryAdjustment();
            frmChooseProduct.BringToFront();
            frmChooseProduct.TopMost = true;
            frmChooseProduct.IsSales = true;
            DialogResult res = frmChooseProduct.ShowDialog(this);

            if (res == DialogResult.OK)
            {
                var convertInventoryAdjustmentDetail = new InventoryAdjustmentDetail
                {
                    ProductId = frmChooseProduct.Product.Id,
                    Product = frmChooseProduct.Product,
                    UnitPrice = frmChooseProduct.ProductTotalUnitPrice,
                    Quantity = frmChooseProduct.ProductQuantity,
                    TotalPrice = frmChooseProduct.ProductTotalQuantityPrice,
                };

                if (!InventoryAdjustmentDetailsList.Any(p => p.ProductId == convertInventoryAdjustmentDetail.ProductId))
                {
                    this.InventoryAdjustmentDetailsList.Add(convertInventoryAdjustmentDetail);
                }
                else
                {
                    MessageBox.Show("Product already added");
                    return;
                }

                if (InventoryAdjustmentDetailsList.Count > 0)
                {
                    this.dgProduct.Rows.Clear();
                    this.dgProduct.Refresh();
                    this.dgProduct.RowCount = InventoryAdjustmentDetailsList.Count;
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

                    for (int i = 0; i < InventoryAdjustmentDetailsList.Count; i++)
                    {
                        InventoryAdjustmentDetail inventoryAdjustmentDetail = InventoryAdjustmentDetailsList[i];
                        this.dgProduct.Rows[i].Cells[0].Value = inventoryAdjustmentDetail.Id;
                        this.dgProduct.Rows[i].Cells[1].Value = inventoryAdjustmentDetail.Product.strProductName;
                        this.dgProduct.Rows[i].Cells[2].Value = inventoryAdjustmentDetail.Product.strDescription;
                        //this.dgProduct.Rows[i].Cells[3].Value = saleDetail.Product.ProductCharacteristic.Id;
                        //this.dgProduct.Rows[i].Cells[4].Value = saleDetail.Product.ProductCharacteristic.strName;
                        //this.dgProduct.Rows[i].Cells[5].Value = saleDetail.Product.ProductCategory.Id;
                        //this.dgProduct.Rows[i].Cells[6].Value = saleDetail.Product.ProductCategory.strName;
                        this.dgProduct.Rows[i].Cells[7].Value = inventoryAdjustmentDetail.Product.ProductType.Id;
                        this.dgProduct.Rows[i].Cells[8].Value = inventoryAdjustmentDetail.Product.ProductType.strName;
                        this.dgProduct.Rows[i].Cells[9].Value = inventoryAdjustmentDetail.Product.ProductBrand.Id;
                        this.dgProduct.Rows[i].Cells[10].Value = inventoryAdjustmentDetail.Product.ProductBrand.strName;
                        //this.dgProduct.Rows[i].Cells[11].Value = product.PerPieceBox;
                        //this.dgProduct.Rows[i].Cells[12].Value = product.Location.ID;
                        //this.dgProduct.Rows[i].Cells[13].Value = product.Location.Name;
                        this.dgProduct.Rows[i].Cells[14].Value = inventoryAdjustmentDetail.Product?.ProductColor?.Id ?? 0;
                        this.dgProduct.Rows[i].Cells[15].Value = inventoryAdjustmentDetail.Product?.ProductColor?.strName ?? string.Empty;
                        this.dgProduct.Rows[i].Cells[16].Value = inventoryAdjustmentDetail.Product?.ProductSize?.Id ?? 0;
                        this.dgProduct.Rows[i].Cells[17].Value = inventoryAdjustmentDetail.Product?.ProductSize?.strName ?? string.Empty;
                        this.dgProduct.Rows[i].Cells[18].Value = inventoryAdjustmentDetail.Product?.ProductUnit?.Id ?? 0;
                        this.dgProduct.Rows[i].Cells[19].Value = inventoryAdjustmentDetail.Product?.ProductUnit?.strName ?? string.Empty;
                        this.dgProduct.Rows[i].Cells[20].Value = inventoryAdjustmentDetail.Product.strCode;
                        this.dgProduct.Rows[i].Cells[21].Value = inventoryAdjustmentDetail.Product.strPR;
                        this.dgProduct.Rows[i].Cells[22].Value = inventoryAdjustmentDetail.Product.strPCD;
                        this.dgProduct.Rows[i].Cells[23].Value = inventoryAdjustmentDetail.Product.strMFLM;
                        this.dgProduct.Rows[i].Cells[24].Value = inventoryAdjustmentDetail.Product.strPattern;
                        this.dgProduct.Rows[i].Cells[25].Value = inventoryAdjustmentDetail.Product.strOffsetCenterBore;
                        this.dgProduct.Rows[i].Cells[26].Value = inventoryAdjustmentDetail.Product.strOrigin;
                        //this.dgProduct.Rows[i].Cells[27].Value = saleDetail.Product.curSellingPrice;
                        this.dgProduct.Rows[i].Cells[28].Value = inventoryAdjustmentDetail.Quantity;
                        this.dgProduct.Rows[i].Cells[29].Value = inventoryAdjustmentDetail.TotalPrice;
                        //this.dgProduct.Rows[i].Cells[27].Value = product.curUnitPrice;
                    }

                    //setRowNumber(this.dgJournalEntry);
                    //this.txtSalesTotal.Text = string.Format("{0:0.00}", SalesDetailsList.Sum(g => g.TotalPrice));
                    //this.txtTotal.Text = string.Format("{0:0.00}", SalesDetailsList.Sum(g => g.TotalPrice));
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (InventoryAdjustmentDetailsList.Count <= 0)
                {
                    MessageBox.Show("Please check the products");
                    return;
                }

                bool isInsert = (this.ID == 0);

                if (isInsert)
                {
                    InventoryAdjustment = new InventoryAdjustment
                    {
                        TransactionNo = txtTransactionNo.Text,
                        InventoryAdjustmentTypeId = cbAdjustmentType.SelectedValue as int?,
                        TransactionDate = dtAdjustmentTransactionDate.Value,
                        Description = txtDescription.Text
                        //InventoryAdjustmentDetails = InventoryAdjustmentDetailsList
                    };

                    InventoryAdjustment = InventoryAdjustmentServices.Add(InventoryAdjustment, GLTranDetail, true, this.InventoryAdjustmentDetailsList);
                    this.InventoryAdjustmentDetailsList = InventoryAdjustment.InventoryAdjustmentDetails.ToList();

                    if (InventoryAdjustment != null)
                    {
                        MessageBox.Show("Inventory Adjustment added successfully.");
                        this.txtDescription.Text = InventoryAdjustment.Description;
                    }
                   
                }
                else
                {
                    //InventoryAdjustment = new InventoryAdjustment
                    //{
                    //    Id = this.ID,
                    //    TransactionNo = txtTransactionNo.Text,
                    //    InventoryAdjustmentTypeId = cbAdjustmentType.SelectedValue as int?,
                    //    TransactionDate = dtAdjustmentTransactionDate.Value,
                    //    Description = txtDescription.Text
                    //    //InventoryAdjustmentDetails = InventoryAdjustmentDetailsList
                    //};

                    InventoryAdjustment.TransactionNo = txtTransactionNo.Text;
                    InventoryAdjustment.InventoryAdjustmentTypeId = cbAdjustmentType.SelectedValue as int?;
                    InventoryAdjustment.TransactionDate = dtAdjustmentTransactionDate.Value;
                    InventoryAdjustment.Description = txtDescription.Text;

                    InventoryAdjustment = InventoryAdjustmentServices.Update(InventoryAdjustment, GLTranDetail, true, InventoryAdjustmentDetailsList);
                    this.InventoryAdjustmentDetailsList = InventoryAdjustment.InventoryAdjustmentDetails.ToList();

                    if (InventoryAdjustment != null)
                    {
                        this.txtDescription.Text = InventoryAdjustment.Description;
                        MessageBox.Show("Inventory Adjustment updated successfully.");

                    }
             
                }

                this.ID = InventoryAdjustment.Id;
                this.txtID.Text = InventoryAdjustment.Id.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {          

            // Only proceed if there is a valid record to delete
            string TransType = (this.ID > 0) ? "delete" : string.Empty;
            if (TransType.Equals("delete"))
            {
                // Prepare the InventoryAdjustment object (if needed, update fields here)
                InventoryAdjustment = new InventoryAdjustment
                {
                    Id = this.ID,
                    TransactionNo = this.InventoryAdjustment.TransactionNo,
                    TransactionDate = this.InventoryAdjustment.TransactionDate,
                    InventoryAdjustmentTypeId = this.InventoryAdjustment.InventoryAdjustmentTypeId,
                    Description = this.InventoryAdjustment.Description
                };

                // Remove the inventory adjustment and its details
                InventoryAdjustmentServices.Remove(InventoryAdjustment, InventoryAdjustmentDetailsList);

                if (InventoryAdjustment != null)
                {
                    this.ID = 0;
                    this.txtID.Text = string.Empty;
                    this.InventoryAdjustment.Id = 0;
                    this.txtTransactionNo.Text = string.Empty;
                    this.txtDescription.Text = string.Empty;
                    //this.InventoryAdjustment.TransactionNo = string.Empty;
                    //this.InventoryAdjustment.Description = string.Empty;
                    this.dgProduct.Rows.Clear();
                    this.dgProduct.Refresh();
                    this.InventoryAdjustmentDetailsList = new List<InventoryAdjustmentDetail>();

                    MessageBox.Show("Successfully deleted");
                }
     
            }
        }

        private void frmInventoryAdjustmentDMCM_Load(object sender, EventArgs e)
        {
            var inventoryAdjustmentTypeList = InventoryAdjustmentTypeServices.GetInventoryAdjustmentType();
            this.cbAdjustmentType.DataSource = inventoryAdjustmentTypeList;
            this.cbAdjustmentType.ValueMember = "Id";
            this.cbAdjustmentType.DisplayMember = "Name";
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                SearchInventoryAdjustmentDMCM sp = new SearchInventoryAdjustmentDMCM();
                sp.BringToFront();
                sp.TopMost = true;
                DialogResult res = sp.ShowDialog(this);


                if (res == DialogResult.OK && sp.InventoryAdjustment != null)
                {
                    this.ID = sp.InventoryAdjustment.Id;
                    this.InventoryAdjustment.Id = sp.InventoryAdjustment.Id;
                    this.txtID.Text = sp.InventoryAdjustment.Id.ToString();
                    this.txtTransactionNo.Text = sp.InventoryAdjustment.TransactionNo;
                    this.dtAdjustmentTransactionDate.Value = sp.InventoryAdjustment.TransactionDate ?? DateTime.Now;
                    this.cbAdjustmentType.SelectedValue = sp.InventoryAdjustment.InventoryAdjustmentTypeId ?? 0;
                    this.txtDescription.Text = sp.InventoryAdjustment.Description;
                    this.InventoryAdjustmentDetailsList = InventoryAdjustmentDetailServices.GetInventoryAdjustmentDetailById(this.ID).SelectMany(pr => pr.InventoryAdjustmentDetails).ToList();
                    this.dgProduct.Rows.Clear();
                    this.dgProduct.Refresh();

                    if (InventoryAdjustmentDetailsList == null || InventoryAdjustmentDetailsList.Count == 0)
                        return;

                    this.dgProduct.RowCount = InventoryAdjustmentDetailsList.Count;
                    this.dgProduct.ColumnCount = 30;

                    this.dgProduct.Columns[0].Name = "ID";
                    this.dgProduct.Columns[0].Visible = false;
                    this.dgProduct.Columns[1].Name = "Product Name";
                    this.dgProduct.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dgProduct.Columns[2].Name = "Description";
                    this.dgProduct.Columns[2].Visible = false;
                    this.dgProduct.Columns[3].Name = "Product Characteristic ID";
                    this.dgProduct.Columns[3].Visible = false;
                    this.dgProduct.Columns[4].Name = "Product Characteristic Name";
                    this.dgProduct.Columns[4].Visible = false;
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
                    this.InventoryAdjustment.InventoryAdjustmentDetails.Clear();

                    for (int i = 0; i < InventoryAdjustmentDetailsList.Count; i++)
                    {
                        var detail = InventoryAdjustmentDetailsList[i];
                        var product = detail.Product;
                        this.InventoryAdjustment.InventoryAdjustmentDetails.Add(detail);

                        this.dgProduct.Rows[i].Cells[0].Value = detail.Id;
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
                        // this.dgProduct.Rows[i].Cells[11].Value = product?.PerPieceBox ?? 0;
                        // this.dgProduct.Rows[i].Cells[12].Value = product?.Location?.ID ?? 0;
                        // this.dgProduct.Rows[i].Cells[13].Value = product?.Location?.Name ?? string.Empty;
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
                        this.dgProduct.Rows[i].Cells[27].Value = detail.UnitPrice ?? 0;
                        this.dgProduct.Rows[i].Cells[28].Value = detail.Quantity ?? 0;
                        this.dgProduct.Rows[i].Cells[29].Value = detail.TotalPrice ?? 0;
                    }

                    setRowNumber(this.dgProduct);
                }

                //if (res == DialogResult.OK)
                //{
                //    this.ID = sp.Purchase.Id;
                //    this.Purchase.Id = sp.Purchase.Id;
                //    this.txtID.Text = sp.Purchase.Id.ToString();
                //    this.txtTransactionNo.Text = sp.Purchase.TRANo;
                //    this.txtPONo.Text = sp.Purchase.PONo;
                //    this.dtTransactionDate.Value = (DateTime)sp.Purchase.TransactionDate;
                //    this.txtTotal.Text = sp.Purchase.Total.ToString();
                //    this.txtAdditionalDescription.Text = sp.Purchase.AdditionalDescription.ToString();
                //    this.txtDescription.Text = sp.Purchase.Description.ToString();
                //    this.txtSIDR.Text = sp.Purchase.SIDR.ToString();
                //    this.txtSupplierID.Text = sp.Purchase.intIDSupplier.ToString();
                //    this.SupplierId = sp.Purchase.Supplier.Id;
                //    this.txtSupplierName.Text = sp.Purchase.Supplier.strName;
                //    this.GLTranHeader = sp.Purchase.tblGLTranHeaders.Select(h => h.ID).FirstOrDefault();
                //    this.chkUseDefaultEntry.Checked = (bool)sp.Purchase.tblGLTranHeaders.Select(h => h.blnUseDefaultEntry).FirstOrDefault();
                //    this.GLTranDetail = GLTranServices.GetGLEntryById(this.GLTranHeader).SelectMany(h => h.tblGLTranDetails).ToList();
                //    this.PurchaseDetailsList = PurchaseDetailServices.GetPurchaseDetailProductByPurchaseId(this.ID).SelectMany(pr => pr.PurchaseDetails).ToList();
                //    //this.Purchase.PurchaseDetails.Concat(this.PurchaseDetailsList);

                //    if (GLTranDetail.Count > 0)
                //    {

                //        this.dgJournalEntry.ColumnCount = 6;
                //        this.dgJournalEntry.RowCount = GLTranDetail.Count;
                //        //this.dgChartOfAccountsSubsidiary.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //        //this.dgChartOfAccountsSubsidiary.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //        this.dgJournalEntry.Columns[0].Name = "COA";
                //        this.dgJournalEntry.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //        this.dgJournalEntry.Columns[1].Name = "COA Code";
                //        this.dgJournalEntry.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //        this.dgJournalEntry.Columns[2].Name = "COA Subsidiary";
                //        this.dgJournalEntry.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //        this.dgJournalEntry.Columns[3].Name = "COA Subsidiary Code";
                //        this.dgJournalEntry.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //        this.dgJournalEntry.Columns[4].Name = "Debit";
                //        this.dgJournalEntry.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //        this.dgJournalEntry.Columns[5].Name = "Credit";
                //        this.dgJournalEntry.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //        this.dgJournalEntry.Columns[0].ReadOnly = true;
                //        this.dgJournalEntry.Columns[1].ReadOnly = true;
                //        this.dgJournalEntry.Columns[2].ReadOnly = true;
                //        this.dgJournalEntry.Columns[3].ReadOnly = true;
                //        this.dgJournalEntry.Columns[4].ReadOnly = true;
                //        this.dgJournalEntry.Columns[5].ReadOnly = true;
                //        this.dgJournalEntry.Columns[1].Visible = false;
                //        this.dgJournalEntry.Columns[3].Visible = false;

                //        for (int i = 0; i < GLTranDetail.Count; i++)
                //        {

                //            this.dgJournalEntry.Rows[i].Cells[0].Value = GLTranDetail[i].tblMasCOA.strName;
                //            this.dgJournalEntry.Rows[i].Cells[1].Value = GLTranDetail[i].tblMasCOA.strCode;
                //            this.dgJournalEntry.Rows[i].Cells[2].Value = GLTranDetail[i].tblMasCOASub.strName;
                //            this.dgJournalEntry.Rows[i].Cells[3].Value = GLTranDetail[i].tblMasCOASub.strCode;
                //            this.dgJournalEntry.Rows[i].Cells[4].Value = string.Format("{0:0.00}", GLTranDetail[i].curDebit);
                //            this.dgJournalEntry.Rows[i].Cells[5].Value = string.Format("{0:0.00}", GLTranDetail[i].curCredit);

                //            this.dgJournalEntry.Rows[i].Cells[0].ReadOnly = true;
                //            this.dgJournalEntry.Rows[i].Cells[1].ReadOnly = true;
                //            this.dgJournalEntry.Rows[i].Cells[2].ReadOnly = true;
                //            this.dgJournalEntry.Rows[i].Cells[3].ReadOnly = true;
                //            this.dgJournalEntry.Rows[i].Cells[4].ReadOnly = true;
                //            this.dgJournalEntry.Rows[i].Cells[5].ReadOnly = true;
                //        }

                //        setRowNumber(this.dgJournalEntry);

                //        this.txtTotalDebit.Text = string.Format("{0:0.00}", GLTranDetail.Sum(g => g.curDebit));
                //        this.txtTotalCredit.Text = string.Format("{0:0.00}", GLTranDetail.Sum(g => g.curCredit));
                //    }
                //    else
                //    {
                //        this.dgJournalEntry.Rows.Clear();
                //        this.dgJournalEntry.Refresh();
                //        this.GLTranDetail.Clear();
                //        this.txtTotalDebit.Text = string.Empty;
                //        this.txtTotalCredit.Text = string.Empty;
                //    }


                //    if (PurchaseDetailsList.Count > 0)
                //    {

                //        this.dgProduct.Rows.Clear();
                //        this.dgProduct.Refresh();
                //        //this.dgProduct.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                //        this.dgProduct.RowCount = PurchaseDetailsList.Count;
                //        this.dgProduct.ColumnCount = 30;
                //        this.dgProduct.Columns[0].Name = "ID";
                //        this.dgProduct.Columns[0].Visible = false;
                //        this.dgProduct.Columns[1].Name = "Product Name";
                //        this.dgProduct.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //        this.dgProduct.Columns[2].Visible = false;
                //        this.dgProduct.Columns[2].Name = "Description";
                //        this.dgProduct.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //        this.dgProduct.Columns[3].Name = "Product Characteristic ID";
                //        this.dgProduct.Columns[3].Visible = false;
                //        this.dgProduct.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //        this.dgProduct.Columns[4].Name = "Product Characteristic Name";
                //        this.dgProduct.Columns[4].Visible = false;
                //        this.dgProduct.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //        this.dgProduct.Columns[5].Name = "Product Category ID";
                //        this.dgProduct.Columns[5].Visible = false;
                //        this.dgProduct.Columns[6].Name = "Product Category Name";
                //        this.dgProduct.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //        this.dgProduct.Columns[7].Name = "Product Type ID";
                //        this.dgProduct.Columns[7].Visible = false;
                //        this.dgProduct.Columns[8].Name = "Product Type Name";
                //        this.dgProduct.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //        this.dgProduct.Columns[9].Name = "Product Brand ID";
                //        this.dgProduct.Columns[9].Visible = false;
                //        this.dgProduct.Columns[10].Name = "Product Brand Name";
                //        this.dgProduct.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //        this.dgProduct.Columns[11].Name = "Per Piece Box";
                //        this.dgProduct.Columns[11].Visible = false;
                //        this.dgProduct.Columns[12].Name = "Location ID";
                //        this.dgProduct.Columns[12].Visible = false;
                //        this.dgProduct.Columns[13].Name = "Location Name";
                //        this.dgProduct.Columns[13].Visible = false;
                //        this.dgProduct.Columns[14].Name = "Product Color ID";
                //        this.dgProduct.Columns[14].Visible = false;
                //        this.dgProduct.Columns[15].Name = "Product Color Name";
                //        this.dgProduct.Columns[16].Name = "Product Size ID";
                //        this.dgProduct.Columns[16].Visible = false;
                //        this.dgProduct.Columns[17].Name = "Product Size Name";
                //        this.dgProduct.Columns[18].Name = "Product Unit ID";
                //        this.dgProduct.Columns[18].Visible = false;
                //        this.dgProduct.Columns[19].Name = "Product Unit Name";
                //        this.dgProduct.Columns[20].Name = "Code";
                //        this.dgProduct.Columns[20].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //        this.dgProduct.Columns[21].Name = "PR";
                //        this.dgProduct.Columns[22].Name = "PCD";
                //        this.dgProduct.Columns[23].Name = "MFLM";
                //        this.dgProduct.Columns[24].Name = "Pattern";
                //        this.dgProduct.Columns[25].Name = "OffsetCenterBase";
                //        this.dgProduct.Columns[25].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //        this.dgProduct.Columns[26].Name = "Origin";
                //        this.dgProduct.Columns[27].Name = "Unit Price";
                //        this.dgProduct.Columns[28].Name = "Quantity";
                //        this.dgProduct.Columns[29].Name = "Total Quantity Price";

                //        for (int i = 0; i < PurchaseDetailsList.Count; i++)
                //        {
                //            //display all the data in productList to the datagridview
                //            PurchaseDetail purchaseDetail = PurchaseDetailsList[i];
                //            var product = purchaseDetail.Product;
                //            this.Purchase.PurchaseDetails.Add(purchaseDetail);
                //            this.dgProduct.Rows[i].Cells[0].Value = purchaseDetail.Id;
                //            this.dgProduct.Rows[i].Cells[1].Value = product?.strProductName ?? string.Empty;
                //            this.dgProduct.Rows[i].Cells[2].Value = product?.strDescription ?? string.Empty;
                //            this.dgProduct.Rows[i].Cells[3].Value = product?.ProductCharacteristic?.Id ?? 0;
                //            this.dgProduct.Rows[i].Cells[4].Value = product?.ProductCharacteristic?.strName ?? string.Empty;
                //            this.dgProduct.Rows[i].Cells[5].Value = product?.ProductCategory?.Id ?? 0;
                //            this.dgProduct.Rows[i].Cells[6].Value = product?.ProductCategory?.strName ?? string.Empty;
                //            this.dgProduct.Rows[i].Cells[7].Value = product?.ProductType?.Id ?? 0;
                //            this.dgProduct.Rows[i].Cells[8].Value = product?.ProductType?.strName ?? string.Empty;
                //            this.dgProduct.Rows[i].Cells[9].Value = product?.ProductBrand?.Id ?? 0;
                //            this.dgProduct.Rows[i].Cells[10].Value = product?.ProductBrand?.strName ?? string.Empty;
                //            //this.dgProduct.Rows[i].Cells[11].Value = product?.PerPieceBox ?? 0;
                //            //this.dgProduct.Rows[i].Cells[12].Value = product?.Location?.ID ?? 0;
                //            //this.dgProduct.Rows[i].Cells[13].Value = product?.Location?.Name ?? string.Empty;
                //            this.dgProduct.Rows[i].Cells[14].Value = product?.ProductColor?.Id ?? 0;
                //            this.dgProduct.Rows[i].Cells[15].Value = product?.ProductColor?.strName ?? string.Empty;
                //            this.dgProduct.Rows[i].Cells[16].Value = product?.ProductSize?.Id ?? 0;
                //            this.dgProduct.Rows[i].Cells[17].Value = product?.ProductSize?.strName ?? string.Empty;
                //            this.dgProduct.Rows[i].Cells[18].Value = product?.ProductUnit?.Id ?? 0;
                //            this.dgProduct.Rows[i].Cells[19].Value = product?.ProductUnit?.strName ?? string.Empty;
                //            this.dgProduct.Rows[i].Cells[20].Value = product?.strCode ?? string.Empty;
                //            this.dgProduct.Rows[i].Cells[21].Value = product?.strPR ?? string.Empty;
                //            this.dgProduct.Rows[i].Cells[22].Value = product?.strPCD ?? string.Empty;
                //            this.dgProduct.Rows[i].Cells[23].Value = product?.strMFLM ?? string.Empty;
                //            this.dgProduct.Rows[i].Cells[24].Value = product?.strPattern ?? string.Empty;
                //            this.dgProduct.Rows[i].Cells[25].Value = product?.strOffsetCenterBore ?? string.Empty;
                //            this.dgProduct.Rows[i].Cells[26].Value = product?.strOrigin ?? string.Empty;
                //            this.dgProduct.Rows[i].Cells[27].Value = purchaseDetail.UnitPrice ?? 0;
                //            this.dgProduct.Rows[i].Cells[28].Value = purchaseDetail.Quantity ?? 0;
                //            this.dgProduct.Rows[i].Cells[29].Value = purchaseDetail.TotalPrice != null ? purchaseDetail.TotalPrice : 0m;
                //            //this.dgProduct.Rows[i].Cells[27].Value = product?.curUnitPrice ?? 0;
                //        }

                //        setRowNumber(this.dgJournalEntry);
                //        this.txtPurchaseTotal.Text = string.Format("{0:0.00}", PurchaseDetailsList.Sum(g => g.TotalPrice));
                //        this.txtTotal.Text = string.Format("{0:0.00}", PurchaseDetailsList.Sum(g => g.TotalPrice));
                //    }


                //    this.GLTranDetailInventoryEntry = GLTranServices.GetGLEntryByPurchaseId(Purchase.Id, 1011).SelectMany(h => h.tblGLTranDetails).ToList();
                //    if (GLTranDetailInventoryEntry.Count > 0)
                //    {

                //        this.dgInventoryEntry.ColumnCount = 6;
                //        this.dgInventoryEntry.RowCount = GLTranDetailInventoryEntry.Count;
                //        //this.dgChartOfAccountsSubsidiary.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //        //this.dgChartOfAccountsSubsidiary.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //        this.dgInventoryEntry.Columns[0].Name = "COA";
                //        this.dgInventoryEntry.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //        this.dgInventoryEntry.Columns[1].Name = "COA Code";
                //        this.dgInventoryEntry.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //        this.dgInventoryEntry.Columns[2].Name = "COA Subsidiary";
                //        this.dgInventoryEntry.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //        this.dgInventoryEntry.Columns[3].Name = "COA Subsidiary Code";
                //        this.dgInventoryEntry.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //        this.dgInventoryEntry.Columns[4].Name = "Debit";
                //        this.dgInventoryEntry.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //        this.dgInventoryEntry.Columns[5].Name = "Credit";
                //        this.dgInventoryEntry.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //        this.dgInventoryEntry.Columns[0].ReadOnly = true;
                //        this.dgInventoryEntry.Columns[1].ReadOnly = true;
                //        this.dgInventoryEntry.Columns[2].ReadOnly = true;
                //        this.dgInventoryEntry.Columns[3].ReadOnly = true;
                //        this.dgInventoryEntry.Columns[4].ReadOnly = true;
                //        this.dgInventoryEntry.Columns[5].ReadOnly = true;
                //        this.dgInventoryEntry.Columns[1].Visible = false;
                //        this.dgInventoryEntry.Columns[3].Visible = false;

                //        for (int i = 0; i < GLTranDetailInventoryEntry.Count; i++)
                //        {

                //            this.dgInventoryEntry.Rows[i].Cells[0].Value = GLTranDetailInventoryEntry[i].tblMasCOA.strName;
                //            this.dgInventoryEntry.Rows[i].Cells[1].Value = GLTranDetailInventoryEntry[i].tblMasCOA.strCode;
                //            this.dgInventoryEntry.Rows[i].Cells[2].Value = GLTranDetailInventoryEntry[i].tblMasCOASub.strName;
                //            this.dgInventoryEntry.Rows[i].Cells[3].Value = GLTranDetailInventoryEntry[i].tblMasCOASub.strCode;
                //            this.dgInventoryEntry.Rows[i].Cells[4].Value = string.Format("{0:0.00}", GLTranDetailInventoryEntry[i].curDebit);
                //            this.dgInventoryEntry.Rows[i].Cells[5].Value = string.Format("{0:0.00}", GLTranDetailInventoryEntry[i].curCredit);

                //            this.dgInventoryEntry.Rows[i].Cells[0].ReadOnly = true;
                //            this.dgInventoryEntry.Rows[i].Cells[1].ReadOnly = true;
                //            this.dgInventoryEntry.Rows[i].Cells[2].ReadOnly = true;
                //            this.dgInventoryEntry.Rows[i].Cells[3].ReadOnly = true;
                //            this.dgInventoryEntry.Rows[i].Cells[4].ReadOnly = true;
                //            this.dgInventoryEntry.Rows[i].Cells[5].ReadOnly = true;
                //        }

                //        setRowNumber(this.dgInventoryEntry);

                //        this.txtTotalInventoryDebit.Text = string.Format("{0:0.00}", GLTranDetailInventoryEntry.Sum(g => g.curDebit));
                //        this.txtTotalInventoryCredit.Text = string.Format("{0:0.00}", GLTranDetailInventoryEntry.Sum(g => g.curCredit));
                //    }
                //}

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnDeleteProduct_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (InventoryAdjustmentDetailsList.Count > 0)
                {
                    this.InventoryAdjustmentDetailsList.RemoveAt(this.IndexGridInventory);
                    this.dgProduct.Rows.Clear();
                    this.dgProduct.Refresh();

                    if (InventoryAdjustmentDetailsList.Count == 0)
                    {
                        return;
                    }
                    //this.dgProduct.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    this.dgProduct.RowCount = InventoryAdjustmentDetailsList.Count;
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

                    for (int i = 0; i < InventoryAdjustmentDetailsList.Count; i++)
                    {
                        //display all the data in productList to the datagridview
                        InventoryAdjustmentDetail inventoryAdjustmentDetailsList = InventoryAdjustmentDetailsList[i];
                        var product = inventoryAdjustmentDetailsList.Product;

                        this.dgProduct.Rows[i].Cells[0].Value = inventoryAdjustmentDetailsList.Id;
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
                        // this.dgProduct.Rows[i].Cells[11].Value = product?.PerPieceBox ?? 0;
                        // this.dgProduct.Rows[i].Cells[12].Value = product?.Location?.ID ?? 0;
                        // this.dgProduct.Rows[i].Cells[13].Value = product?.Location?.Name ?? string.Empty;
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
                        this.dgProduct.Rows[i].Cells[27].Value = inventoryAdjustmentDetailsList.UnitPrice ?? 0;
                        this.dgProduct.Rows[i].Cells[28].Value = inventoryAdjustmentDetailsList.Quantity ?? 0;
                        this.dgProduct.Rows[i].Cells[29].Value = inventoryAdjustmentDetailsList.TotalPrice ?? 0;
                        //this.dgProduct.Rows[i].Cells[27].Value = product.curUnitPrice;
                    }

                    //setRowNumber(this.dgJournalEntry);
                    //this.txtSalesTotal.Text = string.Format("{0:0.00}", SalesDetailsList.Sum(g => g.TotalPrice));
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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.ID = 0;
            this.txtID.Text = string.Empty;
            this.InventoryAdjustment.Id = 0;
            this.txtTransactionNo.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            this.dgProduct.Rows.Clear();
            this.dgProduct.Refresh();
            this.InventoryAdjustmentDetailsList = new List<InventoryAdjustmentDetail>();
        }
    }
}
