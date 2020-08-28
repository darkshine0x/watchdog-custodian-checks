using System;
using System.Windows.Forms;

namespace Watchdog.Forms.FundAdministration
{
    public partial class RuleAdministration : Form
    {
        public RuleAdministration()
        {
            InitializeComponent();
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
