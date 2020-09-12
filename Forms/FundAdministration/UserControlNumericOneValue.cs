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
    /// User Control for adding a new rules which only need a name and a numeric value-
    /// </summary>
    public partial class UserControlNumericOneValue : UserControl, IRuleUserControl
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlNumericOneValue()
        {
            InitializeComponent();
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
            TableUtility tableUtility = new TableUtility();
            Rule newRule = new NumericRule(value, ruleKind, textBoxDescription.Text);
            tableUtility.CreateTable(newRule);
            tableUtility.InsertTableRow(newRule);
            return newRule;
        }
    }
}
