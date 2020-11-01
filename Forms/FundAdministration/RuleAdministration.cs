/*
 * Author: Jan Baumann
 * Version: 06.09.2020
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Watchdog.Entities;
using Watchdog.Forms.Util;
using Watchdog.Persistence;

namespace Watchdog.Forms.FundAdministration
{
    /// <summary>
    /// Form for administrating investment rules.
    /// 
    /// Functions:
    /// <para>- Adding new rules</para>
    /// <para>- Edit rules</para>
    /// <para>- Deleting rules</para>
    /// </summary>
    public partial class RuleAdministration : Form, IPassedObject<Rule>
    {
        private TableLayoutPanel tableLayoutPanel;
        private ContextMenuStrip contextMenu;
        private Label title;
        private Button submitButton;
        private Button cancelButton;
        private Button addNewRuleButton;
        private Rule passedRule;

        /// <summary>
        /// Form constructor.
        /// </summary>
        public RuleAdministration()
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadRules();
        }

        /// <summary>
        /// Initialization of components, which are added programmatically and not via Designer.
        /// </summary>
        private void InitializeCustomComponents()
        {
            title = FormUtility.CreateTitle("Regelverwaltung");
            tableLayoutPanel = FormUtility.CreateTableLayoutPanel(43, 180, 1060, 2980);
            ToolStripMenuItem itemDelete = FormUtility.CreateContextMenuItem("Löschen", DeleteRuleRow);
            ToolStripMenuItem itemEdit = FormUtility.CreateContextMenuItem("Bearbeiten", EditRuleRow);
            contextMenu = contextMenu = FormUtility.CreateContextMenu(itemEdit, itemDelete);
            contextMenu.Opening += (sender, e) =>
            {
                ContextMenuStrip ctxMenu = sender as ContextMenuStrip;
                int row = tableLayoutPanel.GetRow(ctxMenu.SourceControl);
                Rule rule = tableLayoutPanel.GetControlFromPosition(0, row).DataBindings[0].DataSource as Rule;
                if (rule.RuleKind == RuleKind.AA_MAX_DIFF_RANGES)
                {
                    contextMenu.Items[0].Enabled = false;
                }
                else
                {
                    contextMenu.Items[0].Enabled = true;
                }

            };

            submitButton = FormUtility.CreateButton("Bestätigen");
            submitButton.Location = new Point(ClientSize.Width - submitButton.Width - 500, ClientSize.Height - submitButton.Height - 30);
            submitButton.Click += new EventHandler(ButtonSubmitClick);

            cancelButton = FormUtility.CreateButton("Abbrechen");
            cancelButton.Location = new Point(ClientSize.Width - cancelButton.Width - 30, ClientSize.Height - cancelButton.Height - 30);
            cancelButton.Click += new EventHandler(ButtonCloseClick);

            addNewRuleButton = FormUtility.CreateButton("Neue Regel hinzufügen");
            addNewRuleButton.Location = new Point(ClientSize.Width - addNewRuleButton.Width - 30, 30);
            addNewRuleButton.Click += new EventHandler(AddNewRuleClick);

            FormUtility.AddControlsToForm(this, title, tableLayoutPanel, submitButton, cancelButton, addNewRuleButton);
        }

        /// <summary>
        /// Adds a new <see cref="Rule"/> to the table (including checkboxes). 
        /// </summary>
        /// <param name="rule"><see cref="Rule"/></param>
        private void AddRule(Rule rule)
        {
            int rowCount = tableLayoutPanel.RowCount++;
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

            for (int col = 1; col < tableLayoutPanel.ColumnCount; col++)
            {
                CheckBox checkBox = new CheckBox
                {
                    AutoSize = false,
                    Height = 50,
                    Width = 50,
                    BackColor = Color.White,
                    CheckAlign = ContentAlignment.MiddleCenter,
                    Margin = margin
                };
                Fund columnFund = tableLayoutPanel.GetControlFromPosition(col, 0).DataBindings[0].DataSource as Fund;
                if (rule.FundList.Contains(columnFund))
                {
                    checkBox.Checked = true;
                }
                tableLayoutPanel.Controls.Add(checkBox);
            }

            FormUtility.BindObjectToControl(ruleLabel, rule);
            FormUtility.AddControlWithContextMenu(tableLayoutPanel, contextMenu, ruleLabel, 0, rowCount);
        }

        /// <summary>
        /// Loading of the table content. 1st dimension <see cref="Rule"/>, 2nd dimension <see cref="Fund"/>
        /// </summary>
        private void LoadRules()
        {
            TableUtility tableUtility = new TableUtility();
            List<Fund> fundList = tableUtility.ConvertRangesToObjects<Fund>(tableUtility.ReadAllRows(Fund.GetDefaultValue()));
            List<Rule> ruleList = tableUtility.ConvertRangesToObjects<Rule>(tableUtility.ReadAllRows(Rule.GetDefaultValue()));
            tableLayoutPanel.ColumnCount = fundList.Count + 1;
            Padding margin = new Padding(1, 0, 0, 1);

            tableLayoutPanel.Controls.Add(new Label
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
                tableLayoutPanel.Controls.Add(fundLabel, col + 1, 0);
            }

            foreach (Rule rule in ruleList)
            {
                AddRule(rule);
            }
        }

        /// <summary>
        /// Deletes rule from the table and database.
        /// </summary>
        /// <param name="sender"><see cref="ToolStripMenuItem"/> Clicked menu item</param>
        /// <param name="e"><see cref="EventArgs"/></param>
        public void DeleteRuleRow(object sender, EventArgs e)
        {
            Control firstControl = GetClickedRuleElement(sender);
            TableUtility tableUtility = new TableUtility();
            tableUtility.DeleteTableRow(firstControl.DataBindings[0].DataSource as Rule);
            FormUtility.DeleteTableRow(tableLayoutPanel, firstControl);
        }

        public void EditRuleRow(object sender, EventArgs e)
        {
            Control firstControl = GetClickedRuleElement(sender);
            passedRule = firstControl.DataBindings[0].DataSource as Rule;
            _ = new AddRule(this, passedRule)
            {
                Visible = true
            };
        }

        private Control GetClickedRuleElement(object sender)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            ContextMenuStrip contextMenu = menuItem.Owner as ContextMenuStrip;
            int row = tableLayoutPanel.GetRow(contextMenu.SourceControl);
            return tableLayoutPanel.GetControlFromPosition(0, row);
        }

        /// <summary>
        /// Called method when the user clicks on the button for adding a new rule.
        /// After that, a new form opens.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"><see cref="EventArgs"/></param>
        private void AddNewRuleClick(object sender, EventArgs e)
        {
            _ = new AddRule(this)
            {
                Visible = true
            };
        }

        /// <summary>
        /// Called method when the user clicks on the cancel button.
        /// </summary>
        /// <param name="sender">Clicked Button</param>
        /// <param name="e"><see cref="EventArgs"/></param>
        private void ButtonCloseClick(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Called method when the user clicks on the submit button.
        /// At first, all checkboxes are inspected, if they are checked or not. Then the rules will be merged in the database.
        /// They can be merged directly. It is imopossible to add new rules directly in the table. Therefore they must already 
        /// be persisted.
        /// </summary>
        /// <param name="sender">Clicked button</param>
        /// <param name="e"><see cref="EventArgs"/></param>
        private void ButtonSubmitClick(object sender, EventArgs e)
        {
            TableUtility tableUtility = new TableUtility();
            for (int row = 1; row < tableLayoutPanel.RowCount; row++)
            {
                Rule boundRule = tableLayoutPanel.GetControlFromPosition(0, row).DataBindings[0].DataSource as Rule;
                boundRule.FundList.Clear();

                for (int col = 1; col < tableLayoutPanel.ColumnCount; col++)
                {
                    Fund boundFund = tableLayoutPanel.GetControlFromPosition(col, 0).DataBindings[0].DataSource as Fund;
                    CheckBox checkBox = tableLayoutPanel.GetControlFromPosition(col, row) as CheckBox;
                    if (checkBox.Checked)
                    {
                        boundRule.FundList.Add(boundFund);
                    }
                }
                tableUtility.MergeTableRow(boundRule);
            }
            Close();
        }

        /// <summary>
        /// Implementation of <see cref="IPassedObject{T}"/>.
        /// </summary>
        /// <param name="obj">Passed object from the calling form</param>
        public void OnSubmit(Rule obj)
        {
            if (obj != passedRule)
            {
                AddRule(obj);
            }
        }
    }
}
