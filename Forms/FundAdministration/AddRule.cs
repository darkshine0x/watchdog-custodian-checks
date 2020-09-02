using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Watchdog.Entities;
using Watchdog.Forms.Util;

namespace Watchdog.Forms.FundAdministration
{
    public partial class AddRule : Form
    {
        public AddRule(RuleAdministration r)
        {
            InitializeComponent();
            LoadRuleKinds();
        }

        private void LoadRuleKinds()
        {
            List<DropDownItem<RuleKind>> list = new List<DropDownItem<RuleKind>>();
            foreach (RuleKind ruleKind in Enum.GetValues(typeof(RuleKind)))
            {
                Type enumType = typeof(RuleKind);
                object[] attributeList = enumType.GetMember(ruleKind.ToString()).FirstOrDefault(x => x.DeclaringType == enumType).GetCustomAttributes(typeof(DescriptionAttribute), false);
                DescriptionAttribute attribute = attributeList[0] as DescriptionAttribute;
                DropDownItem <RuleKind> item = new DropDownItem<RuleKind>
                {
                    Value = ruleKind,
                    Description = attribute.Description
                };
                list.Add(item);
            }
            ruleKindBindingSource.DataSource = list;
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
                    panelUserControl.Controls.Add(new UserControlNumericOneValue());
                    break;
            }

        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            IRuleUserControl userControl = panelUserControl.Controls[0] as IRuleUserControl;
            DropDownItem<RuleKind> ruleKindItem = comboBoxRuleKind.SelectedItem as DropDownItem<RuleKind>;
            userControl.InvokeSubmission(ruleKindItem.Value);
            Close();
        }
    }
}
