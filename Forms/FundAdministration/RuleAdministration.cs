using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Watchdog.Entities;
using Watchdog.Forms.Util;
using Watchdog.Persistence;

namespace Watchdog.Forms.FundAdministration
{
    public partial class RuleAdministration : Form, IPassedObject<Rule>
    {
        public RuleAdministration()
        {
            InitializeComponent();
            LoadRules();
        }

        private void AddRule(Rule rule)
        {
            int rowCount = tableLayoutPanel1.RowCount++;
            Padding margin = new Padding(1, 0, 0, 1);
            Label ruleLabel = new Label
            {
                AutoSize = false,
                Width = 500,
                Height = 50,
                Text = rule.Name,
                BackColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Margin = margin
            };

            for (int col = 1; col < tableLayoutPanel1.ColumnCount; col++)
            {
                tableLayoutPanel1.Controls.Add(new CheckBox
                {
                    AutoSize = false,
                    Height = 50,
                    Width = 50,
                    BackColor = Color.White,
                    CheckAlign = ContentAlignment.MiddleCenter,
                    Margin = margin
                }, col, rowCount);
            }

            FormUtility.BindObjectToControl(ruleLabel, rule);
            tableLayoutPanel1.Controls.Add(ruleLabel, 0, rowCount);
        }

        private void LoadRules()
        {
            TableUtility tableUtility = new TableUtility();
            List<Fund> fundList = tableUtility.ConvertRangesToObjects<Fund>(tableUtility.ReadAllRows(Fund.GetDefaultValue()));
            List<Rule> ruleList = tableUtility.ConvertRangesToObjects<Rule>(tableUtility.ReadAllRows(Rule.GetDefaultValue()));
            tableLayoutPanel1.ColumnCount = fundList.Count + 1;
            Padding margin = new Padding(1, 0, 0, 1);

            tableLayoutPanel1.Controls.Add(new Label
            {
                AutoSize = false,
                BackColor = Color.White,
                Width = 500,
                Height = 500,
                Margin = margin
            }, 0, 0);

            for (int col = 0; col < fundList.Count; col++)
            {
                // Adding fund labels (columns)
                Label fundLabel = new VerticalLabel(-90)
                {
                    AutoSize = false,
                    Height = 500,
                    Width = 50,
                    Text = fundList[col].Name,
                    BackColor = Color.White,
                    TextAlign = ContentAlignment.BottomLeft,
                    Margin = margin
                };
                FormUtility.BindObjectToControl(fundLabel, fundList[col]);
                tableLayoutPanel1.Controls.Add(fundLabel, col + 1, 0);
            }

            foreach (Rule rule in ruleList)
            {
                AddRule(rule);
            }
        }

        private void AddNewRuleClick(object sender, EventArgs e)
        {
            _ = new AddRule(this)
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

        public void OnSubmit(Rule obj)
        {
            AddRule(obj);
        }
    }
}
