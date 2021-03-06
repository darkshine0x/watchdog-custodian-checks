﻿using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Watchdog.Entities;
using Watchdog.Forms.Util;
using Watchdog.Persistence;

namespace Watchdog.Forms.FundAdministration
{
    public partial class UserControlBanListCountries : UserControl, IPassedObject<Country>, IRuleUserControl
    {
        private DataGridView dataGridView;
        private Button addNewCountry;
        private TextBox ruleName;
        private BanList<Country> passedRule;

        public UserControlBanListCountries(BanList<Country> passedRule)
        {
            this.passedRule = passedRule;
            InitializeComponent();
            InitializeCustomComponents();
            TableUtility tableUtility = new TableUtility();
            tableUtility.CreateTable(Country.GetDefaultValue());
            InitializePassedRule();
        }

        private void InitializePassedRule()
        {
            if (passedRule != null)
            {
                ruleName.Text = passedRule.Name;
                foreach (Country country in passedRule.Banned)
                {
                    FormUtility.GetBindingSource(dataGridView).Add(country);
                }
            }
        }

        private void InitializeCustomComponents()
        {
            ruleName = FormUtility.CreateTextBox(20, 5);
            addNewCountry = FormUtility.CreateButton("Neues Land hinzufügen", 20, 65);
            addNewCountry.Click += (sender, e) => new AddCountryForm(this).Visible = true;
            dataGridView = FormUtility.CreateDataGridView(typeof(Country), 20, 210, 400, 1050);
            ToolStripMenuItem contextMenuItemDelete = FormUtility.CreateContextMenuItem("Löschen", (sender, e) =>
            {
                TableUtility tableUtility = new TableUtility();
                tableUtility.DeleteTableRow(GetSelectedCountry());
                dataGridView.Rows.Remove(dataGridView.SelectedRows[0]);
            });
            ToolStripMenuItem contextMenuItemEdit = FormUtility.CreateContextMenuItem("Bearbeiten", (sender, e) =>
            {
                _ = new AddCountryForm(GetSelectedCountry(), this)
                {
                    Visible = true
                };
            });
            FormUtility.AddContextMenu(dataGridView, contextMenuItemEdit, contextMenuItemDelete);
            FormUtility.AddControlsToForm(this, dataGridView, addNewCountry, ruleName); 
        }

        private Country GetSelectedCountry()
        {
            return dataGridView.SelectedRows[0].DataBoundItem as Country;
        }

        public Rule InvokeSubmission(RuleKind ruleKind)
        {
            if (passedRule != null)
            {
                passedRule.Name = ruleName.Text;
                BindingList<Country> changedBanList = (BindingList<Country>) FormUtility.GetBindingSource(dataGridView).List;
                passedRule.Banned = changedBanList.ToList();
                return passedRule;
            }
            BanList<Country> newBanList = new BanList<Country>(RuleKind.RESTRICTED_COUNTRY, ruleName.Text);
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                newBanList.Banned.Add(row.DataBoundItem as Country);
            }
            TableUtility tableUtility = new TableUtility();
            tableUtility.CreateTable(newBanList);
            tableUtility.InsertTableRow(newBanList);
            return newBanList;
        }

        public void OnSubmit(Country obj)
        {
            TableUtility tableUtility = new TableUtility();
            tableUtility.InsertTableRow(obj);
            FormUtility.GetBindingSource(dataGridView).Add(obj);
        }
    }
}
