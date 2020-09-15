using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Watchdog.Entities;
using Watchdog.Forms.Util;

namespace Watchdog.Forms.FundAdministration
{
    public partial class AddRule : Form
    {
        private IPassedObject<Rule> parentForm;
        private Rule rule;

        public AddRule(IPassedObject<Rule> parentForm, Rule rule = null)
        {
            this.parentForm = parentForm;
            this.rule = rule;
            InitializeComponent();
            LoadRuleKinds();
        }

        private void LoadRuleKinds()
        {
            List<DropDownItem<RuleKind>> list = new List<DropDownItem<RuleKind>>();
            if (rule != null)
            {
                list.Add(GetDropDownItemFromRuleKind(rule.RuleKind));
                comboBoxRuleKind.Enabled = false;
            }
            else
            {
                foreach (RuleKind ruleKind in Enum.GetValues(typeof(RuleKind)))
                {
                    list.Add(GetDropDownItemFromRuleKind(ruleKind));
                }
            }
            ruleKindBindingSource.DataSource = list;
        }

        private DropDownItem<RuleKind> GetDropDownItemFromRuleKind(RuleKind ruleKind)
        {
            Type enumType = typeof(RuleKind);
            DescriptionAttribute attribute = enumType.GetMember(ruleKind.ToString()).FirstOrDefault(x => x.DeclaringType == enumType).GetCustomAttribute<DescriptionAttribute>();
            DropDownItem<RuleKind> item = new DropDownItem<RuleKind>
            {
                Value = ruleKind,
                Description = attribute.Description
            };
            return item;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadUserControl(object sender, EventArgs e)
        {
            if (!(comboBoxRuleKind.SelectedItem is DropDownItem<RuleKind> ruleKindItem))
            {
                return;
            }
            FormUtility.ClearPanel(panelUserControl);
            switch (ruleKindItem.Value)
            {
                case RuleKind.AA_MAX_DIFF_ASSET_CLASS:
                case RuleKind.AA_MAX_DIFF_CURRENCY:
                case RuleKind.DUR_MAX_DIFF:
                case RuleKind.TRACKING_ERROR_MAX_DIFF:
                case RuleKind.MAX_ISSUER_LIMIT:
                case RuleKind.MAX_LEVERAGE_ASSET_CLASS:
                case RuleKind.MAX_LEVERAGE_CURRENCY:
                case RuleKind.MIN_RATING:
                    panelUserControl.Controls.Add(new UserControlNumericOneValue(rule as NumericRule));
                    break;

                case RuleKind.RULE_EXCEPTION:
                    panelUserControl.Controls.Add(new UserControlAllowListAssets());
                    break;

                case RuleKind.MAX_RATING_RATIO:
                    panelUserControl.Controls.Add(new UserControlRatingQuote());
                    break;

                case RuleKind.AA_MAX_DIFF_RANGES:
                    panelUserControl.Controls.Add(new UserControlStrategicBoundaries());
                    break;

                case RuleKind.RESTRICTED_INSTRUMENT_TYPE:
                    panelUserControl.Controls.Add(new UserControlBanListAssetKinds());
                    break;

                case RuleKind.RESTRICTED_COUNTRY:
                    panelUserControl.Controls.Add(new UserControlBanListCountries());
                    break;
            }

        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            IRuleUserControl userControl = panelUserControl.Controls[0] as IRuleUserControl;
            DropDownItem<RuleKind> ruleKindItem = comboBoxRuleKind.SelectedItem as DropDownItem<RuleKind>;
            Rule newRule = userControl.InvokeSubmission(ruleKindItem.Value);
            parentForm.OnSubmit(newRule);
            Close();
        }
    }
}
