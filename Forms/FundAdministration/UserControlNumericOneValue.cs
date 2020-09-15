/*
 * Author: Jan Baumann
 * Version: 12.09.2020
 */

using System.Windows.Forms;
using Watchdog.Entities;
using Watchdog.Forms.Util;
using Watchdog.Persistence;

namespace Watchdog.Forms.FundAdministration
{
    /// <summary>
    /// User Control for adding a new rules which only need a name and a numeric value.
    /// </summary>
    public partial class UserControlNumericOneValue : UserControl, IRuleUserControl
    {
        private NumericRule passedRule;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="passedRule"><see cref="NumericRule"/> if a rule has to be edited</param>
        public UserControlNumericOneValue(NumericRule passedRule = null)
        {
            this.passedRule = passedRule;
            InitializeComponent();
            InitializePassedRule();
        }

        /// <summary>
        /// Pre fill the textboxes with the rules information, if one is passed.
        /// </summary>
        private void InitializePassedRule()
        {
            if (passedRule != null)
            {
                textBoxDescription.Text = passedRule.Name;
                textBoxValue.Text = passedRule.NumericValue.ToString();
            }
        }

        /// <summary>
        /// Implementation of <see cref="IRuleUserControl"/>. This method is called by the parent form 
        /// for invoking the addition of a new rule.
        /// </summary>
        /// <param name="ruleKind"><see cref="RuleKind"/></param>
        /// <returns>New <see cref="Rule"/></returns>
        public Rule InvokeSubmission(RuleKind ruleKind)
        {
            bool parsingSuccessful = double.TryParse(textBoxValue.Text, out double value);
            if (!parsingSuccessful)
            {
                MessageBox.Show("Bitte eine gültige Zahl eingeben.");
                return null;
            }
            if (passedRule != null)
            {
                passedRule.Name = textBoxDescription.Text;
                passedRule.NumericValue = value;
                return passedRule;
            }
            TableUtility tableUtility = new TableUtility();
            Rule newRule = new NumericRule(value, ruleKind, textBoxDescription.Text);
            tableUtility.CreateTable(newRule);
            tableUtility.InsertTableRow(newRule);
            return newRule;
        }
    }
}
