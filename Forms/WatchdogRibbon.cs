using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private void ButtonEditFundClick(object sender, RibbonControlEventArgs e)
        {

        }
    }
}
