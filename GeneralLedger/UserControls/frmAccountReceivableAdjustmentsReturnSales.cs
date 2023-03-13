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
    public partial class frmAccountReceivableAdjustmentsReturnSales : MetroUserControl
    {
        public MetroTabControl MetroTabControl { get; set; }
        public MetroTabPage MetroTabPage { get; set; }
        public AccountReceivableAdjustment AccountReceivableAdjustment { get; set; }
        public AccountReceivableAdjustmentsServices AccountReceivableAdjustmentsServices { get; set; }
        public AccountsReceivableAdjustmentsTypeServices AccountsReceivableAdjustmentsTypeServices { get; set; }

        public tblTBBatchHdrServices tblTBBatchHdrServices { get; set; }
        public GLTranServices GLTranServices { get; set; }
        public List<tblGLTranDetail> GLTranDetail { get; set; }

        public int ID { get; set; }

        public int SaleId { get; set; }
        public int IndexGrid { get; set; }
        public int GLTranHeader { get; set; }


        public frmAccountReceivableAdjustmentsReturnSales()
        {
            AccountsReceivableAdjustmentsTypeServices = new AccountsReceivableAdjustmentsTypeServices();
            AccountReceivableAdjustmentsServices = new AccountReceivableAdjustmentsServices();
            GLTranServices = new GLTranServices();
            GLTranDetail = new List<tblGLTranDetail>();
            AccountReceivableAdjustment = new AccountReceivableAdjustment();
            tblTBBatchHdrServices = new tblTBBatchHdrServices();
            InitializeComponent();
        }
    }
}
