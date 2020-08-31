using System.Collections.Generic;
using System.Windows.Forms;
using Watchdog.Entities;
using Watchdog.Forms.Util;
using Watchdog.Persistence;

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
            bool parsingSuccessful = double.TryParse(textBoxValue.Text, out double value);
            if (!parsingSuccessful)
            {
                MessageBox.Show("Bitte eine gültige Zahl eingeben.");
                return;
            }
            TableUtility tableUtility = new TableUtility();
            Rule newRule = new NumericRule(value, ruleKind, textBoxDescription.Text);
            newRule.FundList.Add(new Fund("fund1", "ch09", "09-99999", new Currency("CHF")));
            tableUtility.CreateTable(newRule);
            tableUtility.CreateTable(Currency.GetDefaultValue());
            tableUtility.CreateTable(Fund.GetDefaultValue());
            foreach (Fund f in newRule.FundList)
            {
                tableUtility.InsertTableRow(f.Currency);
                tableUtility.InsertTableRow(f);
            }
            tableUtility.InsertTableRow(newRule);
            List<Rule> list = tableUtility.ConvertRangesToObjects<Rule>(tableUtility.ReadAllRows(newRule));
        }
    }
}
