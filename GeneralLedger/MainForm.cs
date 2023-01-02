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
using MetroFramework.Controls;
using GeneralLedger.UserControls;
using System.Runtime.InteropServices;

namespace GeneralLedger
{
    public partial class MainForm : MetroForm
    {
        const int LEADING_SPACE = 12;
        const int CLOSE_SPACE = 15;
        const int CLOSE_AREA = 15;
        public MainForm()
        {

            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.metroTabControlMain.Parent = this;
            this.metroTabControlMain.Dock = DockStyle.Top;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

   
        }



        private void MetroTabControlMain_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void btnChartOfAccounts_Click(object sender, EventArgs e)
        {
            MetroTabPage metroTabPage = new MetroTabPage();
            metroTabPage.Text = "Chart Of Accounts";
            
            MasterfileChartOfAccounts masterfileChartOfAccounts = new MasterfileChartOfAccounts();
            masterfileChartOfAccounts.Parent = metroTabPage;
            masterfileChartOfAccounts.MetroTabPage = metroTabPage;
            masterfileChartOfAccounts.MetroTabControl = this.metroTabControlMain;
            metroTabPage.Controls.Add(masterfileChartOfAccounts);
            metroTabControlMain.TabPages.Add(metroTabPage);
            metroTabControlMain.SelectedTab = metroTabPage;


        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            // get the inital length
            int tabLength = metroTabControlMain.ItemSize.Width;

            // measure the text in each tab and make adjustment to the size
            for (int i = 0; i < this.metroTabControlMain.TabPages.Count; i++)
            {
                TabPage currentPage = metroTabControlMain.TabPages[i];

                int currentTabLength = TextRenderer.MeasureText(currentPage.Text, metroTabControlMain.Font).Width;
                // adjust the length for what text is written
                currentTabLength += LEADING_SPACE + CLOSE_SPACE + CLOSE_AREA;

                if (currentTabLength > tabLength)
                {
                    tabLength = currentTabLength;
                }
            }

            // create the new size
            Size newTabSize = new Size(tabLength, metroTabControlMain.ItemSize.Height);
            metroTabControlMain.ItemSize = newTabSize;

        }

        private void btnJournalEntry_Click(object sender, EventArgs e)
        {
            MetroTabPage metroTabPage = new MetroTabPage();
            metroTabPage.Text = "Journal Entry";
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


            JournalEntry journalEntry = new JournalEntry();
            journalEntry.Parent = metroTabPage;
            journalEntry.MetroTabPage = metroTabPage;
            journalEntry.AutoScroll = true;
            
            
            journalEntry.MetroTabControl = this.metroTabControlMain;
            
            metroTabPage.Controls.Add(journalEntry);
            metroTabControlMain.TabPages.Add(metroTabPage);
            metroTabControlMain.SelectedTab = metroTabPage;
            
        }

        private void btnTrialBalance_Click(object sender, EventArgs e)
        {
           
            MetroTabPage metroTabPage = new MetroTabPage();
            metroTabPage.Text = "Trial Balance";
            TrialBalancePosting trialBalancePosting = new TrialBalancePosting();
            trialBalancePosting.Parent = metroTabPage;
            trialBalancePosting.MetroTabPage = metroTabPage;
            trialBalancePosting.MetroTabControl = this.metroTabControlMain;
            metroTabPage.Controls.Add(trialBalancePosting);
            metroTabControlMain.TabPages.Add(metroTabPage);
            metroTabControlMain.SelectedTab = metroTabPage;
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {

            MetroTabPage metroTabPage = new MetroTabPage();
            metroTabPage.Text = "Reports";
            Reports reports = new Reports();
            reports.Parent = metroTabPage;
            reports.MetroTabPage = metroTabPage;
            reports.metroTabControlMain = this.metroTabControlMain;
            reports.MetroTabControl = this.metroTabControlMain;
            metroTabPage.Controls.Add(reports);
            metroTabControlMain.TabPages.Add(metroTabPage);
            metroTabControlMain.SelectedTab = metroTabPage;
        }

        private void metroTabPageHome_Click(object sender, EventArgs e)
        {

        }

        private void btnProductCategory_Click(object sender, EventArgs e)
        {



            MetroTabPage metroTabPage = new MetroTabPage();
            metroTabPage.Text = "Product Category";
            ProductCategory productCategory = new ProductCategory();
            productCategory.Parent = metroTabPage;
            productCategory.MetroTabPage = metroTabPage;
            productCategory.MetroTabControl = this.metroTabControlMain;
            metroTabPage.Controls.Add(productCategory);
            metroTabControlMain.TabPages.Add(metroTabPage);
            metroTabControlMain.SelectedTab = metroTabPage;
        }

        private void btnProductType_Click(object sender, EventArgs e)
        {
            MetroTabPage metroTabPage = new MetroTabPage();
            metroTabPage.Text = "Product Type";
            ProductType productType = new ProductType();
            productType.Parent = metroTabPage;
            productType.MetroTabPage = metroTabPage;
            productType.MetroTabControl = this.metroTabControlMain;
            metroTabPage.Controls.Add(productType);
            metroTabControlMain.TabPages.Add(metroTabPage);
            metroTabControlMain.SelectedTab = metroTabPage;


        }

        private void metroTabControlMain_DrawItem_1(object sender, DrawItemEventArgs e)
        {
            //This code will render a "x" mark at the end of the Tab caption. 
            e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - CLOSE_AREA, e.Bounds.Top + 4);
            e.Graphics.DrawString(this.metroTabControlMain.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + LEADING_SPACE, e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }

        private void metroTabControlMain_CustomPaint(object sender, MetroFramework.Drawing.MetroPaintEventArgs e)
        {
            
          
        }

        private void metroTabControlMain_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void btnProductBrand_Click(object sender, EventArgs e)
        {


            MetroTabPage metroTabPage = new MetroTabPage();
            metroTabPage.Text = "Product Brand";
            ProductBrand productBrand = new ProductBrand();
            productBrand.Parent = metroTabPage;
            productBrand.MetroTabPage = metroTabPage;
            productBrand.MetroTabControl = this.metroTabControlMain;
            metroTabPage.Controls.Add(productBrand);
            metroTabControlMain.TabPages.Add(metroTabPage);
            metroTabControlMain.SelectedTab = metroTabPage;

        }

        private void btnProductColor_Click(object sender, EventArgs e)
        {
            MetroTabPage metroTabPage = new MetroTabPage();
            metroTabPage.Text = "Product Color";
            ProductColor productColor = new ProductColor();
            productColor.Parent = metroTabPage;
            productColor.MetroTabPage = metroTabPage;
            productColor.MetroTabControl = this.metroTabControlMain;
            metroTabPage.Controls.Add(productColor);
            metroTabControlMain.TabPages.Add(metroTabPage);
            metroTabControlMain.SelectedTab = metroTabPage;
        }

        private void ProductSize_Click(object sender, EventArgs e)
        {
            MetroTabPage metroTabPage = new MetroTabPage();
            metroTabPage.Text = "Product Size";
            ProductSize productSize = new ProductSize();
            productSize.Parent = metroTabPage;
            productSize.MetroTabPage = metroTabPage;
            productSize.MetroTabControl = this.metroTabControlMain;
            metroTabPage.Controls.Add(productSize);
            metroTabControlMain.TabPages.Add(metroTabPage);
            metroTabControlMain.SelectedTab = metroTabPage;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            //MetroTabPage metroTabPage = new MetroTabPage();
            //metroTabPage.Text = "Product";
            //ProductIndex productIndex = new ProductIndex();
            //productIndex.Parent = metroTabPage;
            //productIndex.MetroTabPage = metroTabPage;
            //productIndex.MetroTabControl = this.metroTabControlMain;
            //metroTabPage.Controls.Add(productIndex);
            //metroTabControlMain.TabPages.Add(metroTabPage);
            //metroTabControlMain.SelectedTab = metroTabPage;

            MetroTabPage metroTabPage = new MetroTabPage();
            metroTabPage.Text = "Add Product";
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
            //metroTabPage.Style = MetroFramework.MetroColorStyle.Orange;
            //metroTabPage.Location = new System.Drawing.Point(15, 38);
            //metroTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            AddProduct addProduct = new AddProduct();
            addProduct.Parent = metroTabPage;
            addProduct.MetroTabPage = metroTabPage;
            addProduct.MetroTabControl = this.metroTabControlMain;
            metroTabPage.Controls.Add(addProduct);
            metroTabControlMain.TabPages.Add(metroTabPage);
            metroTabControlMain.SelectedTab = metroTabPage;


        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {

            MetroTabPage metroTabPage = new MetroTabPage();
            metroTabPage.Text = "Supplier";
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
            frmSupplier supplier = new frmSupplier();
            supplier.Parent = metroTabPage;
            supplier.MetroTabPage = metroTabPage;
            supplier.MetroTabControl = this.metroTabControlMain;
            metroTabPage.Controls.Add(supplier);
            metroTabControlMain.TabPages.Add(metroTabPage);
            metroTabControlMain.SelectedTab = metroTabPage;

        }

        private void btnBankAccounts_Click(object sender, EventArgs e)
        {
            MetroTabPage metroTabPage = new MetroTabPage();
            metroTabPage.Text = "Bank";
            Bank supplier = new Bank();
            supplier.Parent = metroTabPage;
            supplier.MetroTabPage = metroTabPage;
            supplier.MetroTabControl = this.metroTabControlMain;
            metroTabPage.Controls.Add(supplier);
            metroTabControlMain.TabPages.Add(metroTabPage);
            metroTabControlMain.SelectedTab = metroTabPage;
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            MetroTabPage metroTabPage = new MetroTabPage();
            metroTabPage.Text = "Customer";
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
            frmCustomer frmCustomer = new frmCustomer();
            frmCustomer.Parent = metroTabPage;
            frmCustomer.MetroTabPage = metroTabPage;
            frmCustomer.MetroTabControl = this.metroTabControlMain;
            metroTabPage.Controls.Add(frmCustomer);
            metroTabControlMain.TabPages.Add(metroTabPage);
            metroTabControlMain.SelectedTab = metroTabPage;
        }

        private void btnPriceType_Click(object sender, EventArgs e)
        {
            MetroTabPage metroTabPage = new MetroTabPage();
            metroTabPage.Text = "Price Type";
            PriceType priceType = new PriceType();
            priceType.Parent = metroTabPage;
            priceType.MetroTabPage = metroTabPage;
            priceType.MetroTabControl = this.metroTabControlMain;
            metroTabPage.Controls.Add(priceType);
            metroTabControlMain.TabPages.Add(metroTabPage);
            metroTabControlMain.SelectedTab = metroTabPage;
        }

        private void btnLocation_Click(object sender, EventArgs e)
        {
            MetroTabPage metroTabPage = new MetroTabPage();
            metroTabPage.Text = "Location";
            frmLocation frmlocation = new frmLocation();
            frmlocation.Parent = metroTabPage;
            frmlocation.MetroTabPage = metroTabPage;
            frmlocation.MetroTabControl = this.metroTabControlMain;
            metroTabPage.Controls.Add(frmlocation);
            metroTabControlMain.TabPages.Add(metroTabPage);
            metroTabControlMain.SelectedTab = metroTabPage;
        }

        private void metroLink3_Click(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            MetroTabPage metroTabPage = new MetroTabPage();
            metroTabPage.Text = "Purchase Order";
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

            frmPurchaseOrderIndex frmPurchaseOrderIndex = new frmPurchaseOrderIndex();
            frmPurchaseOrderIndex.Parent = metroTabPage;
            frmPurchaseOrderIndex.MetroTabPage = metroTabPage;
            frmPurchaseOrderIndex.MetroTabControl = this.metroTabControlMain;
            metroTabPage.Controls.Add(frmPurchaseOrderIndex);
            metroTabControlMain.TabPages.Add(metroTabPage);
            metroTabControlMain.SelectedTab = metroTabPage;
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            MetroTabPage metroTabPage = new MetroTabPage();
            metroTabPage.Text = "Sale";
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


            frmSales frmSales = new frmSales();
            frmSales.Parent = metroTabPage;
            frmSales.MetroTabPage = metroTabPage;
            frmSales.AutoScroll = true;


            frmSales.MetroTabControl = this.metroTabControlMain;

            metroTabPage.Controls.Add(frmSales);
            metroTabControlMain.TabPages.Add(metroTabPage);
            metroTabControlMain.SelectedTab = metroTabPage;
        }

        private void btnAgents_Click(object sender, EventArgs e)
        {
            MetroTabPage metroTabPage = new MetroTabPage();
            metroTabPage.Text = "Agent";
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

            frmAgent frmAgent = new frmAgent();
            frmAgent.Parent = metroTabPage;
            frmAgent.MetroTabPage = metroTabPage;
            frmAgent.AutoScroll = true;


            frmAgent.MetroTabControl = this.metroTabControlMain;

            metroTabPage.Controls.Add(frmAgent);
            metroTabControlMain.TabPages.Add(metroTabPage);
            metroTabControlMain.SelectedTab = metroTabPage;

        }

        private void metroTile5_Click(object sender, EventArgs e)
        {

            MetroTabPage metroTabPage = new MetroTabPage();
            metroTabPage.Text = "Collection";
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

            frmCollection frmCollection = new frmCollection();
            frmCollection.Parent = metroTabPage;
            frmCollection.MetroTabPage = metroTabPage;
            frmCollection.AutoScroll = true;


            frmCollection.MetroTabControl = this.metroTabControlMain;

            metroTabPage.Controls.Add(frmCollection);
            metroTabControlMain.TabPages.Add(metroTabPage);
            metroTabControlMain.SelectedTab = metroTabPage;

        }

        private void metroTile8_Click(object sender, EventArgs e)
        {

            MetroTabPage metroTabPage = new MetroTabPage();
            metroTabPage.Text = "A/R Adjustments";
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

            frmAccountReceivableAdjustments frmAccountReceivableAdjustments = new frmAccountReceivableAdjustments();
            frmAccountReceivableAdjustments.Parent = metroTabPage;
            frmAccountReceivableAdjustments.MetroTabPage = metroTabPage;
            frmAccountReceivableAdjustments.AutoScroll = true;


            frmAccountReceivableAdjustments.MetroTabControl = this.metroTabControlMain;

            metroTabPage.Controls.Add(frmAccountReceivableAdjustments);
            metroTabControlMain.TabPages.Add(metroTabPage);
            metroTabControlMain.SelectedTab = metroTabPage;

        }

        private void metroTile7_Click(object sender, EventArgs e)
        {

            MetroTabPage metroTabPage = new MetroTabPage();
            metroTabPage.Text = "Purchase";
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

            frmPurchase frmPurchase = new frmPurchase();
            frmPurchase.Parent = metroTabPage;
            frmPurchase.MetroTabPage = metroTabPage;
            frmPurchase.AutoScroll = true;

            frmPurchase.MetroTabControl = this.metroTabControlMain;

            metroTabPage.Controls.Add(frmPurchase);
            metroTabControlMain.TabPages.Add(metroTabPage);
            metroTabControlMain.SelectedTab = metroTabPage;
        }
    }
}
