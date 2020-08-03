namespace Watchdog.Forms
{
    partial class WatchdogRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public WatchdogRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">"true", wenn verwaltete Ressourcen gelöscht werden sollen, andernfalls "false".</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WatchdogRibbon));
            this.tabCustodianCheck = this.Factory.CreateRibbonTab();
            this.groupFundAdmin = this.Factory.CreateRibbonGroup();
            this.buttonAddFund = this.Factory.CreateRibbonButton();
            this.buttonSettings = this.Factory.CreateRibbonButton();
            this.button1 = this.Factory.CreateRibbonButton();
            this.tabCustodianCheck.SuspendLayout();
            this.groupFundAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCustodianCheck
            // 
            this.tabCustodianCheck.Groups.Add(this.groupFundAdmin);
            this.tabCustodianCheck.Label = "Depotbank";
            this.tabCustodianCheck.Name = "tabCustodianCheck";
            // 
            // groupFundAdmin
            // 
            this.groupFundAdmin.Items.Add(this.buttonAddFund);
            this.groupFundAdmin.Items.Add(this.buttonSettings);
            this.groupFundAdmin.Items.Add(this.button1);
            this.groupFundAdmin.Label = "Fondsadministration";
            this.groupFundAdmin.Name = "groupFundAdmin";
            // 
            // buttonAddFund
            // 
            this.buttonAddFund.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.buttonAddFund.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddFund.Image")));
            this.buttonAddFund.Label = "Fonds administrieren";
            this.buttonAddFund.Name = "buttonAddFund";
            this.buttonAddFund.ShowImage = true;
            this.buttonAddFund.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ButtonAddFundClick);
            // 
            // buttonSettings
            // 
            this.buttonSettings.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.buttonSettings.Image = ((System.Drawing.Image)(resources.GetObject("buttonSettings.Image")));
            this.buttonSettings.Label = "Einstellungen";
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.ShowImage = true;
            this.buttonSettings.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ButtonSettings_Click);
            // 
            // button1
            // 
            this.button1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Label = "Asset Allocation bearbeiten";
            this.button1.Name = "button1";
            this.button1.ShowImage = true;
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // WatchdogRibbon
            // 
            this.Name = "WatchdogRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tabCustodianCheck);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.WatchdogRibbon_Load);
            this.tabCustodianCheck.ResumeLayout(false);
            this.tabCustodianCheck.PerformLayout();
            this.groupFundAdmin.ResumeLayout(false);
            this.groupFundAdmin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabCustodianCheck;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupFundAdmin;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonAddFund;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonSettings;
    }
}
