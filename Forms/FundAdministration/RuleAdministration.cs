using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Watchdog.Entities;
using Watchdog.Persistence;

namespace Watchdog.Forms.FundAdministration
{
    public partial class RuleAdministration : Form
    {
        public RuleAdministration()
        {
            InitializeComponent();
            LoadRules();
        }

        private void LoadRules()
        {
            TableUtility tableUtility = new TableUtility();
            List<Rule> rules = tableUtility.ConvertRangesToObjects<Rule>(tableUtility.ReadAllRows(Rule.GetDefaultValue()));
            foreach (Rule rule in rules)
            {
                tableLayoutPanel1.Controls.Add(new TextBox
                {
                    Text = rule.RuleKind.ToString()
                });
            }
        }

        private void AddNewRuleClick(object sender, EventArgs e)
        {
            _ = new AddRule
            {
                Visible = true
            };
        }

        private void SubmitClick(object sender, EventArgs e)
        {

        }

        private void CancelClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
