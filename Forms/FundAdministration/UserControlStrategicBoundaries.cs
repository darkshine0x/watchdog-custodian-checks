using System.Drawing;
using System.Windows.Forms;
using Watchdog.Entities;
using Watchdog.Forms.Util;
using Watchdog.Persistence;

namespace Watchdog.Forms.FundAdministration
{
    public partial class UserControlStrategicBoundaries : UserControl, IRuleUserControl
    {
        private Label labelName;
        private TextBox textBoxName;
        private Label labelRuleDescription;

        public UserControlStrategicBoundaries()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        public void InitializeCustomComponents()
        {
            labelName = new Label
            {
                Text = "Name",
                Location = new Point(20, 20),
                AutoSize = true
            };
            textBoxName = FormUtility.CreateTextBox(300, 20);
            labelRuleDescription = new Label
            {
                Text = "Die Asset Allocation muss innerhalb der strategischen Bandbreiten sein.",
                Location = new Point(20, 130),
                AutoSize = true
            };
            FormUtility.AddControlsToForm(this, labelName, textBoxName, labelRuleDescription);

        }

        public Rule InvokeSubmission(RuleKind ruleKind)
        {
            Rule rule = new Rule(ruleKind, textBoxName.Text);
            TableUtility tableUtility = new TableUtility();
            tableUtility.CreateTable(rule);
            tableUtility.InsertTableRow(rule);
            return rule;
        }
    }
}
