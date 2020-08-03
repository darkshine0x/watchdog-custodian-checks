using Microsoft.Office.Tools.Ribbon;

namespace Watchdog.Forms
{
    public partial class WatchdogRibbon
    {
        private void WatchdogRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void ButtonAddFundClick(object sender, RibbonControlEventArgs e)
        {
            _ = new AddFundForm
            {
                Visible = true
            };
        }

        private void ButtonSettings_Click(object sender, RibbonControlEventArgs e)
        {
            _ = new Settings()
            {
                Visible = true
            };
        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            _ = new EditAssetAllocation
            {
                Visible = true
            };
        }
    }
}
