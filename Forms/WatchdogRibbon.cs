﻿using Microsoft.Office.Tools.Ribbon;
using System.Data;
using System.Windows.Forms;
using Watchdog.Entities;
using Watchdog.Forms.FundAdministration;
using Watchdog.Forms.Settings;
using Watchdog.Reporting.Util;

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
            _ = new SettingsForm()
            {
                Visible = true
            };
        }

        private void ButtonRuleSet_Click(object sender, RibbonControlEventArgs e)
        {
            _ = new RuleAdministration()
            {
                Visible = true
            };
        }
    }
}
