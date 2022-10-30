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
    public partial class AddProduct : MetroUserControl
    {
        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }
        public int ID { get; set; }
        public AddProduct()
        {
            InitializeComponent();
            //UserControlTesting userControlTesting = new UserControlTesting();
            //userControlTesting.Parent = this.metroPanel1;
            //userControlTesting.Dock = DockStyle.Fill;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.MetroTabControl.TabPages.Remove(MetroTabPage);
        }

        private void btnAddColorAndSize_Click(object sender, EventArgs e)
        {
            SearchProductColor sca = new SearchProductColor();
            sca.BringToFront();
            sca.TopMost = true;
            DialogResult res = sca.ShowDialog(this);
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {

        }
    }
}
