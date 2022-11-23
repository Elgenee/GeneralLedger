namespace GeneralLedger.UserControls
{
    partial class frmPurchaseOrderIndex
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchaseOrderIndex));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Order = new DevComponents.DotNetBar.Controls.DataGridViewMaskedTextBoxAdvColumn();
            this.Date = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.Part = new DevComponents.DotNetBar.Controls.DataGridViewMaskedTextBoxAdvColumn();
            this.Spec = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.dataGridViewX2 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Feedback = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.tabHasZeroQty = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.tabCombo = new DevComponents.DotNetBar.SuperTabItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel4 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.dgPending = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dgPendingPOID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPendingPONumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPendingDatePurchased = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPendingSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPendingLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPendingTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPendingTotalQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPendingTotalReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPendingTotalRemaining = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPendingViewDetails = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.dgPendingEdit = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.dgPendingReceived = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.dgPendingPay = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.dgPendingCancel = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.tabPending = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.dgForApproval = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ForApprovalPOID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ForApprovalPONumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ForApprovalDatePurchased = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ForApprovalSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ForApprovalLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ForApprovalTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ForApprovalApproved = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.tabForApproval = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel5 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.dataGridViewX3 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.tabCompleted = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel7 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.dataGridViewX5 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.tabBadRecord = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel6 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.dataGridViewX4 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.tabCancelled = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel3 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.metroLabel14 = new MetroFramework.Controls.MetroLabel();
            this.cbBank = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBox2 = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBox3 = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.dtBatchDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroDateTime1 = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBox4 = new MetroFramework.Controls.MetroComboBox();
            this.btnAddEntry = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.btnNewPurchaseOrder = new MetroFramework.Controls.MetroButton();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).BeginInit();
            this.superTabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPending)).BeginInit();
            this.superTabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgForApproval)).BeginInit();
            this.superTabControlPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX3)).BeginInit();
            this.superTabControlPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX5)).BeginInit();
            this.superTabControlPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX4)).BeginInit();
            this.SuspendLayout();
            // 
            // Order
            // 
            this.Order.AllowPromptAsInput = false;
            this.Order.AsciiOnly = true;
            this.Order.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Order.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.Order.BackgroundStyle.Class = "TextBoxBorder";
            this.Order.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Order.BeepOnError = true;
            this.Order.ButtonClear.DisplayPosition = 9;
            this.Order.ButtonClear.Visible = true;
            this.Order.ButtonCustom.Visible = true;
            this.Order.Culture = new System.Globalization.CultureInfo("en-US");
            this.Order.DataPropertyName = "Order";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Order.DefaultCellStyle = dataGridViewCellStyle1;
            this.Order.FocusHighlightEnabled = true;
            this.Order.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Order.HeaderText = "Order";
            this.Order.HidePromptOnLeave = true;
            this.Order.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Order.Mask = "\\#0000";
            this.Order.MinimumWidth = 6;
            this.Order.Name = "Order";
            this.Order.PasswordChar = '\0';
            this.Order.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Order.Text = "#";
            this.Order.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Order.Width = 120;
            // 
            // Date
            // 
            this.Date.AutoAdvance = true;
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            // 
            // 
            // 
            this.Date.BackgroundStyle.BackColor = System.Drawing.Color.White;
            this.Date.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.Date.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Date.BackgroundStyle.TextColor = System.Drawing.SystemColors.WindowText;
            this.Date.ButtonClear.DisplayPosition = 2;
            this.Date.ButtonClear.Visible = true;
            this.Date.ButtonCustom.DisplayPosition = 1;
            this.Date.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("Date.ButtonCustom.Image")));
            this.Date.ButtonCustom.Visible = true;
            this.Date.ButtonDropDown.Visible = true;
            this.Date.DataPropertyName = "Date";
            this.Date.Format = DevComponents.Editors.eDateTimePickerFormat.Long;
            this.Date.HeaderText = "Date";
            this.Date.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.Date.MinimumWidth = 6;
            // 
            // 
            // 
            // 
            // 
            // 
            this.Date.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.Date.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.Date.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Date.MonthCalendar.DisplayMonth = new System.DateTime(2010, 5, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.Date.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Date.Name = "Date";
            this.Date.ShowUpDown = true;
            this.Date.Width = 230;
            // 
            // Part
            // 
            this.Part.AllowPromptAsInput = false;
            this.Part.AsciiOnly = true;
            this.Part.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Part.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.Part.BackgroundStyle.Class = "TextBoxBorder";
            this.Part.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Part.BeepOnError = true;
            this.Part.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("Part.ButtonCustom.Image")));
            this.Part.ButtonCustom.Visible = true;
            this.Part.ButtonDropDown.Visible = true;
            this.Part.Culture = new System.Globalization.CultureInfo("en-US");
            this.Part.DataPropertyName = "Part";
            this.Part.FocusHighlightEnabled = true;
            this.Part.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Part.HeaderText = "Part";
            this.Part.HidePromptOnLeave = true;
            this.Part.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Part.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.Part.Mask = "00->LLL-0000-L";
            this.Part.MinimumWidth = 6;
            this.Part.Name = "Part";
            this.Part.PasswordChar = '\0';
            this.Part.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Part.Text = "  -   -    -";
            this.Part.Width = 130;
            // 
            // Spec
            // 
            // 
            // 
            // 
            this.Spec.BackgroundStyle.BackColor = System.Drawing.Color.White;
            this.Spec.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.Spec.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Spec.BackgroundStyle.TextColor = System.Drawing.SystemColors.WindowText;
            this.Spec.DataPropertyName = "Spec";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Spec.DefaultCellStyle = dataGridViewCellStyle2;
            this.Spec.FillWeight = 50F;
            this.Spec.HeaderText = "Spec";
            this.Spec.Increment = 1D;
            this.Spec.MinimumWidth = 6;
            this.Spec.Name = "Spec";
            this.Spec.ShowUpDown = true;
            this.Spec.Width = 81;
            // 
            // dataGridViewX2
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewX2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Order,
            this.Date,
            this.Part,
            this.Spec,
            this.Feedback});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewX2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX2.EnableHeadersVisualStyles = false;
            this.dataGridViewX2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX2.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewX2.Name = "dataGridViewX2";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX2.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewX2.RowHeadersWidth = 51;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.dataGridViewX2.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewX2.RowTemplate.Height = 24;
            this.dataGridViewX2.Size = new System.Drawing.Size(1362, 466);
            this.dataGridViewX2.TabIndex = 0;
            // 
            // Feedback
            // 
            this.Feedback.Checked = false;
            this.Feedback.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.Feedback.CheckValue = "N";
            this.Feedback.CheckValueChecked = "Y";
            this.Feedback.CheckValueUnchecked = "N";
            this.Feedback.DataPropertyName = "Feedback";
            this.Feedback.HeaderText = "Feedback";
            this.Feedback.MinimumWidth = 6;
            this.Feedback.Name = "Feedback";
            this.Feedback.ThreeState = true;
            this.Feedback.Width = 161;
            // 
            // tabHasZeroQty
            // 
            this.tabHasZeroQty.AttachedControl = this.superTabControlPanel2;
            this.tabHasZeroQty.GlobalItem = false;
            this.tabHasZeroQty.Name = "tabHasZeroQty";
            this.tabHasZeroQty.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabHasZeroQty.Text = "Has 0 Qty";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.dataGridViewX2);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 26);
            this.superTabControlPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(1362, 466);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.tabHasZeroQty;
            // 
            // tabCombo
            // 
            this.tabCombo.GlobalItem = false;
            this.tabCombo.Name = "tabCombo";
            this.tabCombo.Text = "CheckBoxX\r\nComboBoxEx";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Print");
            this.imageList1.Images.SetKeyName(1, "User");
            this.imageList1.Images.SetKeyName(2, "Canada");
            this.imageList1.Images.SetKeyName(3, "France");
            this.imageList1.Images.SetKeyName(4, "Sweden");
            this.imageList1.Images.SetKeyName(5, "Spain");
            this.imageList1.Images.SetKeyName(6, "Mexico");
            this.imageList1.Images.SetKeyName(7, "Germany");
            this.imageList1.Images.SetKeyName(8, "Ireland");
            this.imageList1.Images.SetKeyName(9, "Switzerland");
            this.imageList1.Images.SetKeyName(10, "UK");
            this.imageList1.Images.SetKeyName(11, "USA");
            this.imageList1.Images.SetKeyName(12, "Venezuela");
            this.imageList1.Images.SetKeyName(13, "Argentina");
            this.imageList1.Images.SetKeyName(14, "Brazil");
            this.imageList1.Images.SetKeyName(15, "Austria");
            this.imageList1.Images.SetKeyName(16, "Italy");
            this.imageList1.Images.SetKeyName(17, "Portugal");
            this.imageList1.Images.SetKeyName(18, "Denmark");
            this.imageList1.Images.SetKeyName(19, "Belgium");
            this.imageList1.Images.SetKeyName(20, "Finland");
            this.imageList1.Images.SetKeyName(21, "Poland");
            this.imageList1.Images.SetKeyName(22, "SecHigh");
            this.imageList1.Images.SetKeyName(23, "SecMedium");
            this.imageList1.Images.SetKeyName(24, "SecLow");
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // superTabControl1
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Name = "";
            this.superTabControl1.ControlBox.Name = "";
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.Controls.Add(this.superTabControlPanel1);
            this.superTabControl1.Controls.Add(this.superTabControlPanel4);
            this.superTabControl1.Controls.Add(this.superTabControlPanel5);
            this.superTabControl1.Controls.Add(this.superTabControlPanel7);
            this.superTabControl1.Controls.Add(this.superTabControlPanel6);
            this.superTabControl1.Controls.Add(this.superTabControlPanel2);
            this.superTabControl1.Controls.Add(this.superTabControlPanel3);
            this.superTabControl1.HorizontalText = false;
            this.superTabControl1.Location = new System.Drawing.Point(23, 206);
            this.superTabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superTabControl1.SelectedTabIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(1362, 493);
            this.superTabControl1.TabIndex = 113;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabForApproval,
            this.tabHasZeroQty,
            this.tabPending,
            this.tabCompleted,
            this.tabCancelled,
            this.tabBadRecord});
            this.superTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
            this.superTabControl1.Text = "superTabControl1";
            this.superTabControl1.SelectedTabChanged += new System.EventHandler<DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs>(this.superTabControl1_SelectedTabChanged);
            this.superTabControl1.Enter += new System.EventHandler(this.superTabControl1_Enter);
            // 
            // superTabControlPanel4
            // 
            this.superTabControlPanel4.Controls.Add(this.dgPending);
            this.superTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel4.Location = new System.Drawing.Point(0, 26);
            this.superTabControlPanel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.superTabControlPanel4.Name = "superTabControlPanel4";
            this.superTabControlPanel4.Size = new System.Drawing.Size(1362, 466);
            this.superTabControlPanel4.TabIndex = 0;
            this.superTabControlPanel4.TabItem = this.tabPending;
            // 
            // dgPending
            // 
            this.dgPending.AllowUserToAddRows = false;
            this.dgPending.AllowUserToDeleteRows = false;
            this.dgPending.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPending.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgPending.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPending.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgPendingPOID,
            this.dgPendingPONumber,
            this.dgPendingDatePurchased,
            this.dgPendingSupplier,
            this.dgPendingLocation,
            this.dgPendingTotalAmount,
            this.dgPendingTotalQuantity,
            this.dgPendingTotalReceived,
            this.dgPendingTotalRemaining,
            this.dgPendingViewDetails,
            this.dgPendingEdit,
            this.dgPendingReceived,
            this.dgPendingPay,
            this.dgPendingCancel});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPending.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgPending.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPending.EnableHeadersVisualStyles = false;
            this.dgPending.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgPending.Location = new System.Drawing.Point(0, 0);
            this.dgPending.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgPending.Name = "dgPending";
            this.dgPending.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPending.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgPending.RowHeadersWidth = 51;
            this.dgPending.RowTemplate.Height = 30;
            this.dgPending.Size = new System.Drawing.Size(1362, 466);
            this.dgPending.TabIndex = 90;
            this.dgPending.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPending_CellContentClick);
            // 
            // dgPendingPOID
            // 
            this.dgPendingPOID.HeaderText = "ID";
            this.dgPendingPOID.MinimumWidth = 6;
            this.dgPendingPOID.Name = "dgPendingPOID";
            this.dgPendingPOID.ReadOnly = true;
            this.dgPendingPOID.Width = 125;
            // 
            // dgPendingPONumber
            // 
            this.dgPendingPONumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgPendingPONumber.HeaderText = "PO Number";
            this.dgPendingPONumber.MinimumWidth = 6;
            this.dgPendingPONumber.Name = "dgPendingPONumber";
            this.dgPendingPONumber.ReadOnly = true;
            this.dgPendingPONumber.Width = 102;
            // 
            // dgPendingDatePurchased
            // 
            this.dgPendingDatePurchased.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgPendingDatePurchased.HeaderText = "Date Purchased";
            this.dgPendingDatePurchased.MinimumWidth = 6;
            this.dgPendingDatePurchased.Name = "dgPendingDatePurchased";
            this.dgPendingDatePurchased.ReadOnly = true;
            this.dgPendingDatePurchased.Width = 128;
            // 
            // dgPendingSupplier
            // 
            this.dgPendingSupplier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgPendingSupplier.HeaderText = "Supplier";
            this.dgPendingSupplier.MinimumWidth = 6;
            this.dgPendingSupplier.Name = "dgPendingSupplier";
            this.dgPendingSupplier.ReadOnly = true;
            this.dgPendingSupplier.Width = 89;
            // 
            // dgPendingLocation
            // 
            this.dgPendingLocation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgPendingLocation.HeaderText = "Location";
            this.dgPendingLocation.MinimumWidth = 6;
            this.dgPendingLocation.Name = "dgPendingLocation";
            this.dgPendingLocation.ReadOnly = true;
            this.dgPendingLocation.Width = 91;
            // 
            // dgPendingTotalAmount
            // 
            this.dgPendingTotalAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgPendingTotalAmount.HeaderText = "Total Amount";
            this.dgPendingTotalAmount.MinimumWidth = 6;
            this.dgPendingTotalAmount.Name = "dgPendingTotalAmount";
            this.dgPendingTotalAmount.ReadOnly = true;
            this.dgPendingTotalAmount.Width = 111;
            // 
            // dgPendingTotalQuantity
            // 
            this.dgPendingTotalQuantity.HeaderText = "TotalQuantity";
            this.dgPendingTotalQuantity.MinimumWidth = 6;
            this.dgPendingTotalQuantity.Name = "dgPendingTotalQuantity";
            this.dgPendingTotalQuantity.ReadOnly = true;
            this.dgPendingTotalQuantity.Width = 125;
            // 
            // dgPendingTotalReceived
            // 
            this.dgPendingTotalReceived.HeaderText = "TotalReceived";
            this.dgPendingTotalReceived.MinimumWidth = 6;
            this.dgPendingTotalReceived.Name = "dgPendingTotalReceived";
            this.dgPendingTotalReceived.ReadOnly = true;
            this.dgPendingTotalReceived.Width = 125;
            // 
            // dgPendingTotalRemaining
            // 
            this.dgPendingTotalRemaining.HeaderText = "TotalRemaining";
            this.dgPendingTotalRemaining.MinimumWidth = 6;
            this.dgPendingTotalRemaining.Name = "dgPendingTotalRemaining";
            this.dgPendingTotalRemaining.ReadOnly = true;
            this.dgPendingTotalRemaining.Width = 125;
            // 
            // dgPendingViewDetails
            // 
            this.dgPendingViewDetails.HeaderText = "";
            this.dgPendingViewDetails.MinimumWidth = 6;
            this.dgPendingViewDetails.Name = "dgPendingViewDetails";
            this.dgPendingViewDetails.ReadOnly = true;
            this.dgPendingViewDetails.Text = null;
            this.dgPendingViewDetails.Width = 125;
            // 
            // dgPendingEdit
            // 
            this.dgPendingEdit.HeaderText = "";
            this.dgPendingEdit.MinimumWidth = 6;
            this.dgPendingEdit.Name = "dgPendingEdit";
            this.dgPendingEdit.ReadOnly = true;
            this.dgPendingEdit.Text = null;
            this.dgPendingEdit.Width = 125;
            // 
            // dgPendingReceived
            // 
            this.dgPendingReceived.HeaderText = "";
            this.dgPendingReceived.MinimumWidth = 6;
            this.dgPendingReceived.Name = "dgPendingReceived";
            this.dgPendingReceived.ReadOnly = true;
            this.dgPendingReceived.Text = null;
            this.dgPendingReceived.Width = 125;
            // 
            // dgPendingPay
            // 
            this.dgPendingPay.HeaderText = "";
            this.dgPendingPay.MinimumWidth = 6;
            this.dgPendingPay.Name = "dgPendingPay";
            this.dgPendingPay.ReadOnly = true;
            this.dgPendingPay.Text = null;
            this.dgPendingPay.Width = 125;
            // 
            // dgPendingCancel
            // 
            this.dgPendingCancel.HeaderText = "";
            this.dgPendingCancel.MinimumWidth = 6;
            this.dgPendingCancel.Name = "dgPendingCancel";
            this.dgPendingCancel.ReadOnly = true;
            this.dgPendingCancel.Text = null;
            this.dgPendingCancel.Width = 125;
            // 
            // tabPending
            // 
            this.tabPending.AttachedControl = this.superTabControlPanel4;
            this.tabPending.GlobalItem = false;
            this.tabPending.Name = "tabPending";
            this.tabPending.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.tabPending.Text = "Pending";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.dgForApproval);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 29);
            this.superTabControlPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(1362, 464);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.tabForApproval;
            // 
            // dgForApproval
            // 
            this.dgForApproval.AllowUserToAddRows = false;
            this.dgForApproval.AllowUserToDeleteRows = false;
            this.dgForApproval.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgForApproval.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgForApproval.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgForApproval.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ForApprovalPOID,
            this.ForApprovalPONumber,
            this.ForApprovalDatePurchased,
            this.ForApprovalSupplier,
            this.ForApprovalLocation,
            this.ForApprovalTotalAmount,
            this.ForApprovalApproved});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgForApproval.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgForApproval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgForApproval.EnableHeadersVisualStyles = false;
            this.dgForApproval.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgForApproval.Location = new System.Drawing.Point(0, 0);
            this.dgForApproval.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgForApproval.Name = "dgForApproval";
            this.dgForApproval.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgForApproval.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgForApproval.RowHeadersWidth = 51;
            this.dgForApproval.RowTemplate.Height = 30;
            this.dgForApproval.Size = new System.Drawing.Size(1362, 464);
            this.dgForApproval.TabIndex = 89;
            this.dgForApproval.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgForApproval_CellContentClick);
            // 
            // ForApprovalPOID
            // 
            this.ForApprovalPOID.HeaderText = "ID";
            this.ForApprovalPOID.MinimumWidth = 6;
            this.ForApprovalPOID.Name = "ForApprovalPOID";
            this.ForApprovalPOID.ReadOnly = true;
            this.ForApprovalPOID.Width = 125;
            // 
            // ForApprovalPONumber
            // 
            this.ForApprovalPONumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ForApprovalPONumber.HeaderText = "PO Number";
            this.ForApprovalPONumber.MinimumWidth = 6;
            this.ForApprovalPONumber.Name = "ForApprovalPONumber";
            this.ForApprovalPONumber.ReadOnly = true;
            this.ForApprovalPONumber.Width = 102;
            // 
            // ForApprovalDatePurchased
            // 
            this.ForApprovalDatePurchased.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ForApprovalDatePurchased.HeaderText = "Date Purchased";
            this.ForApprovalDatePurchased.MinimumWidth = 6;
            this.ForApprovalDatePurchased.Name = "ForApprovalDatePurchased";
            this.ForApprovalDatePurchased.ReadOnly = true;
            this.ForApprovalDatePurchased.Width = 128;
            // 
            // ForApprovalSupplier
            // 
            this.ForApprovalSupplier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ForApprovalSupplier.HeaderText = "Supplier";
            this.ForApprovalSupplier.MinimumWidth = 6;
            this.ForApprovalSupplier.Name = "ForApprovalSupplier";
            this.ForApprovalSupplier.ReadOnly = true;
            this.ForApprovalSupplier.Width = 89;
            // 
            // ForApprovalLocation
            // 
            this.ForApprovalLocation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ForApprovalLocation.HeaderText = "Location";
            this.ForApprovalLocation.MinimumWidth = 6;
            this.ForApprovalLocation.Name = "ForApprovalLocation";
            this.ForApprovalLocation.ReadOnly = true;
            this.ForApprovalLocation.Width = 91;
            // 
            // ForApprovalTotalAmount
            // 
            this.ForApprovalTotalAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ForApprovalTotalAmount.HeaderText = "Total Amount";
            this.ForApprovalTotalAmount.MinimumWidth = 6;
            this.ForApprovalTotalAmount.Name = "ForApprovalTotalAmount";
            this.ForApprovalTotalAmount.ReadOnly = true;
            this.ForApprovalTotalAmount.Width = 111;
            // 
            // ForApprovalApproved
            // 
            this.ForApprovalApproved.HeaderText = "";
            this.ForApprovalApproved.MinimumWidth = 6;
            this.ForApprovalApproved.Name = "ForApprovalApproved";
            this.ForApprovalApproved.ReadOnly = true;
            this.ForApprovalApproved.Text = null;
            this.ForApprovalApproved.Width = 125;
            // 
            // tabForApproval
            // 
            this.tabForApproval.AttachedControl = this.superTabControlPanel1;
            this.tabForApproval.GlobalItem = false;
            this.tabForApproval.Name = "tabForApproval";
            this.tabForApproval.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.tabForApproval.Text = "For Approval";
            // 
            // superTabControlPanel5
            // 
            this.superTabControlPanel5.Controls.Add(this.dataGridViewX3);
            this.superTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel5.Location = new System.Drawing.Point(0, 26);
            this.superTabControlPanel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.superTabControlPanel5.Name = "superTabControlPanel5";
            this.superTabControlPanel5.Size = new System.Drawing.Size(1362, 466);
            this.superTabControlPanel5.TabIndex = 0;
            this.superTabControlPanel5.TabItem = this.tabCompleted;
            // 
            // dataGridViewX3
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewX3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX3.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewX3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX3.EnableHeadersVisualStyles = false;
            this.dataGridViewX3.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX3.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewX3.Name = "dataGridViewX3";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridViewX3.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewX3.RowHeadersWidth = 51;
            this.dataGridViewX3.RowTemplate.Height = 35;
            this.dataGridViewX3.Size = new System.Drawing.Size(1362, 466);
            this.dataGridViewX3.TabIndex = 3;
            // 
            // tabCompleted
            // 
            this.tabCompleted.AttachedControl = this.superTabControlPanel5;
            this.tabCompleted.GlobalItem = false;
            this.tabCompleted.Name = "tabCompleted";
            this.tabCompleted.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.tabCompleted.Text = "Completed";
            // 
            // superTabControlPanel7
            // 
            this.superTabControlPanel7.Controls.Add(this.dataGridViewX5);
            this.superTabControlPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel7.Location = new System.Drawing.Point(0, 26);
            this.superTabControlPanel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.superTabControlPanel7.Name = "superTabControlPanel7";
            this.superTabControlPanel7.Size = new System.Drawing.Size(1362, 466);
            this.superTabControlPanel7.TabIndex = 0;
            this.superTabControlPanel7.TabItem = this.tabBadRecord;
            // 
            // dataGridViewX5
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX5.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewX5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX5.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewX5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX5.EnableHeadersVisualStyles = false;
            this.dataGridViewX5.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX5.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewX5.Name = "dataGridViewX5";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridViewX5.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewX5.RowHeadersWidth = 51;
            this.dataGridViewX5.RowTemplate.Height = 35;
            this.dataGridViewX5.Size = new System.Drawing.Size(1362, 466);
            this.dataGridViewX5.TabIndex = 3;
            // 
            // tabBadRecord
            // 
            this.tabBadRecord.AttachedControl = this.superTabControlPanel7;
            this.tabBadRecord.GlobalItem = false;
            this.tabBadRecord.Name = "tabBadRecord";
            this.tabBadRecord.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.tabBadRecord.Text = "Bad Record";
            // 
            // superTabControlPanel6
            // 
            this.superTabControlPanel6.Controls.Add(this.dataGridViewX4);
            this.superTabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel6.Location = new System.Drawing.Point(0, 26);
            this.superTabControlPanel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.superTabControlPanel6.Name = "superTabControlPanel6";
            this.superTabControlPanel6.Size = new System.Drawing.Size(1362, 466);
            this.superTabControlPanel6.TabIndex = 0;
            this.superTabControlPanel6.TabItem = this.tabCancelled;
            // 
            // dataGridViewX4
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX4.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewX4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX4.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewX4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX4.EnableHeadersVisualStyles = false;
            this.dataGridViewX4.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX4.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewX4.Name = "dataGridViewX4";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridViewX4.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewX4.RowHeadersWidth = 51;
            this.dataGridViewX4.RowTemplate.Height = 35;
            this.dataGridViewX4.Size = new System.Drawing.Size(1362, 466);
            this.dataGridViewX4.TabIndex = 3;
            // 
            // tabCancelled
            // 
            this.tabCancelled.AttachedControl = this.superTabControlPanel6;
            this.tabCancelled.GlobalItem = false;
            this.tabCancelled.Name = "tabCancelled";
            this.tabCancelled.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.tabCancelled.Text = "Cancelled";
            // 
            // superTabControlPanel3
            // 
            this.superTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel3.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.superTabControlPanel3.Name = "superTabControlPanel3";
            this.superTabControlPanel3.Size = new System.Drawing.Size(1362, 493);
            this.superTabControlPanel3.TabIndex = 0;
            // 
            // metroLabel14
            // 
            this.metroLabel14.AutoSize = true;
            this.metroLabel14.Location = new System.Drawing.Point(29, 46);
            this.metroLabel14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Size = new System.Drawing.Size(67, 20);
            this.metroLabel14.TabIndex = 115;
            this.metroLabel14.Text = "Locations";
            // 
            // cbBank
            // 
            this.cbBank.FormattingEnabled = true;
            this.cbBank.ItemHeight = 24;
            this.cbBank.Location = new System.Drawing.Point(196, 46);
            this.cbBank.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbBank.Name = "cbBank";
            this.cbBank.Size = new System.Drawing.Size(232, 30);
            this.cbBank.TabIndex = 114;
            this.cbBank.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(477, 46);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(70, 20);
            this.metroLabel1.TabIndex = 117;
            this.metroLabel1.Text = "Issued by:";
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 24;
            this.metroComboBox1.Location = new System.Drawing.Point(587, 46);
            this.metroComboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(232, 30);
            this.metroComboBox1.TabIndex = 116;
            this.metroComboBox1.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(879, 46);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(66, 20);
            this.metroLabel2.TabIndex = 119;
            this.metroLabel2.Text = "Products:";
            // 
            // metroComboBox2
            // 
            this.metroComboBox2.FormattingEnabled = true;
            this.metroComboBox2.ItemHeight = 24;
            this.metroComboBox2.Location = new System.Drawing.Point(1012, 46);
            this.metroComboBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.metroComboBox2.Name = "metroComboBox2";
            this.metroComboBox2.Size = new System.Drawing.Size(232, 30);
            this.metroComboBox2.TabIndex = 118;
            this.metroComboBox2.UseSelectable = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(879, 100);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(98, 20);
            this.metroLabel3.TabIndex = 121;
            this.metroLabel3.Text = "Receive Status";
            // 
            // metroComboBox3
            // 
            this.metroComboBox3.FormattingEnabled = true;
            this.metroComboBox3.ItemHeight = 24;
            this.metroComboBox3.Location = new System.Drawing.Point(1012, 100);
            this.metroComboBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.metroComboBox3.Name = "metroComboBox3";
            this.metroComboBox3.Size = new System.Drawing.Size(232, 30);
            this.metroComboBox3.TabIndex = 120;
            this.metroComboBox3.UseSelectable = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(28, 100);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(74, 20);
            this.metroLabel4.TabIndex = 123;
            this.metroLabel4.Text = "Date From";
            // 
            // dtBatchDate
            // 
            this.dtBatchDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBatchDate.Location = new System.Drawing.Point(196, 98);
            this.dtBatchDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtBatchDate.MinimumSize = new System.Drawing.Size(0, 30);
            this.dtBatchDate.Name = "dtBatchDate";
            this.dtBatchDate.Size = new System.Drawing.Size(232, 30);
            this.dtBatchDate.TabIndex = 122;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(476, 102);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(56, 20);
            this.metroLabel5.TabIndex = 125;
            this.metroLabel5.Text = "Date To";
            // 
            // metroDateTime1
            // 
            this.metroDateTime1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.metroDateTime1.Location = new System.Drawing.Point(587, 100);
            this.metroDateTime1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.metroDateTime1.MinimumSize = new System.Drawing.Size(0, 30);
            this.metroDateTime1.Name = "metroDateTime1";
            this.metroDateTime1.Size = new System.Drawing.Size(232, 30);
            this.metroDateTime1.TabIndex = 124;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(29, 147);
            this.metroLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(102, 20);
            this.metroLabel6.TabIndex = 127;
            this.metroLabel6.Text = "Payment Status";
            // 
            // metroComboBox4
            // 
            this.metroComboBox4.FormattingEnabled = true;
            this.metroComboBox4.ItemHeight = 24;
            this.metroComboBox4.Location = new System.Drawing.Point(196, 147);
            this.metroComboBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.metroComboBox4.Name = "metroComboBox4";
            this.metroComboBox4.Size = new System.Drawing.Size(232, 30);
            this.metroComboBox4.TabIndex = 126;
            this.metroComboBox4.UseSelectable = true;
            // 
            // btnAddEntry
            // 
            this.btnAddEntry.Location = new System.Drawing.Point(568, 159);
            this.btnAddEntry.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddEntry.Name = "btnAddEntry";
            this.btnAddEntry.Size = new System.Drawing.Size(132, 28);
            this.btnAddEntry.TabIndex = 128;
            this.btnAddEntry.Text = "Search";
            this.btnAddEntry.UseSelectable = true;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(715, 159);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(132, 28);
            this.metroButton1.TabIndex = 129;
            this.metroButton1.Text = "Clear";
            this.metroButton1.UseSelectable = true;
            // 
            // btnNewPurchaseOrder
            // 
            this.btnNewPurchaseOrder.Location = new System.Drawing.Point(867, 159);
            this.btnNewPurchaseOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNewPurchaseOrder.Name = "btnNewPurchaseOrder";
            this.btnNewPurchaseOrder.Size = new System.Drawing.Size(204, 28);
            this.btnNewPurchaseOrder.TabIndex = 130;
            this.btnNewPurchaseOrder.Text = "New Purchase Order";
            this.btnNewPurchaseOrder.UseSelectable = true;
            this.btnNewPurchaseOrder.Click += new System.EventHandler(this.btnNewPurchaseOrder_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
            this.btnClose.Image = global::GeneralLedger.Properties.Resources.cancel;
            this.btnClose.Location = new System.Drawing.Point(1315, 25);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(137, 44);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnClose.TabIndex = 112;
            this.btnClose.Text = "Close Page";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmPurchaseOrderIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnNewPurchaseOrder);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.btnAddEntry);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroComboBox4);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroDateTime1);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.dtBatchDate);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroComboBox3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroComboBox2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroComboBox1);
            this.Controls.Add(this.metroLabel14);
            this.Controls.Add(this.cbBank);
            this.Controls.Add(this.superTabControl1);
            this.Controls.Add(this.btnClose);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmPurchaseOrderIndex";
            this.Size = new System.Drawing.Size(1454, 712);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).EndInit();
            this.superTabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPending)).EndInit();
            this.superTabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgForApproval)).EndInit();
            this.superTabControlPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX3)).EndInit();
            this.superTabControlPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX5)).EndInit();
            this.superTabControlPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.Controls.DataGridViewMaskedTextBoxAdvColumn Order;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn Date;
        private DevComponents.DotNetBar.Controls.DataGridViewMaskedTextBoxAdvColumn Part;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn Spec;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX2;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Feedback;
        private DevComponents.DotNetBar.SuperTabItem tabHasZeroQty;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem tabCombo;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem tabForApproval;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel3;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel4;
        private DevComponents.DotNetBar.SuperTabItem tabPending;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel5;
        private DevComponents.DotNetBar.SuperTabItem tabCompleted;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel7;
        private DevComponents.DotNetBar.SuperTabItem tabBadRecord;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel6;
        private DevComponents.DotNetBar.SuperTabItem tabCancelled;
        private MetroFramework.Controls.MetroLabel metroLabel14;
        private MetroFramework.Controls.MetroComboBox cbBank;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroComboBox metroComboBox2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox metroComboBox3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroDateTime dtBatchDate;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroDateTime metroDateTime1;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroComboBox metroComboBox4;
        private MetroFramework.Controls.MetroButton btnAddEntry;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton btnNewPurchaseOrder;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX3;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX5;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX4;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgForApproval;
        private System.Windows.Forms.DataGridViewTextBoxColumn ForApprovalPOID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ForApprovalPONumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ForApprovalDatePurchased;
        private System.Windows.Forms.DataGridViewTextBoxColumn ForApprovalSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn ForApprovalLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ForApprovalTotalAmount;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn ForApprovalApproved;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgPending;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPendingPOID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPendingPONumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPendingDatePurchased;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPendingSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPendingLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPendingTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPendingTotalQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPendingTotalReceived;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPendingTotalRemaining;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn dgPendingViewDetails;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn dgPendingEdit;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn dgPendingReceived;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn dgPendingPay;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn dgPendingCancel;
    }
}
