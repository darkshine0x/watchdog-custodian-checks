using System.Collections.Generic;
using System.Windows.Forms;
using Watchdog.Entities;
using Watchdog.Forms.Util;

namespace Watchdog.Forms.FundAdministration
{
    public partial class UserControlNumericOneValue : UserControl, IRuleUserControl
    {
        public UserControlNumericOneValue()
        {
            InitializeComponent();
        }

        public void InvokeSubmission(RuleKind ruleKind)
        {
            throw new System.NotImplementedException();
        }
    }
}
