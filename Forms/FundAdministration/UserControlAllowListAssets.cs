/*
 * Author: Jan Baumann
 * Version: 15.09.2020
 */

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Watchdog.Entities;
using Watchdog.Forms.Util;
using Watchdog.Persistence;

namespace Watchdog.Forms.FundAdministration
{
    /// <summary>
    /// Form for inserting or editing a rule for an <see cref="AllowList"/> with authorized assets.
    /// </summary>
    public partial class UserControlAllowListAssets : UserControl, IPassedObject<Asset>, IRuleUserControl
    {
        private DataGridView dataGridView;
        private Button addNewAsset;
        private TextBox ruleName;
        private AllowList passedRule;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public UserControlAllowListAssets(AllowList passedRule = null)
        {
            this.passedRule = passedRule;
            InitializeComponent();
            InitializeCustomComponents();
            TableUtility tableUtility = new TableUtility();
            tableUtility.CreateTable(Asset.GetDefaultValue());
            InitializePassedRule();
        }

        private void InitializePassedRule()
        {
            if (passedRule != null)
            {
                ruleName.Text = passedRule.Name;
                foreach (Asset asset in passedRule.Allowed)
                {
                    FormUtility.GetBindingSource(dataGridView).Add(asset);
                }
            }
        }

        /// <summary>
        /// Initialization of self-added controls
        /// </summary>
        private void InitializeCustomComponents()
        {
            ruleName = FormUtility.CreateTextBox(20, 5);
            addNewAsset = FormUtility.CreateButton("Neues Asset hinzufügen", 20, 65);
            addNewAsset.Click += (sender, e) => new AddAssetForm(this).Visible = true;
            dataGridView = FormUtility.CreateDataGridView(typeof(Asset), 20, 210, 400, 1050);
            ToolStripMenuItem contextMenuItemDelete = FormUtility.CreateContextMenuItem("Löschen", (sender, e) =>
            {
                TableUtility tableUtility = new TableUtility();
                tableUtility.DeleteTableRow(GetSelectedAsset());
                dataGridView.Rows.Remove(dataGridView.SelectedRows[0]);
            });
            ToolStripMenuItem contextMenuItemEdit = FormUtility.CreateContextMenuItem("Bearbeiten", (sender, e) =>
            {
                _ = new AddAssetForm(GetSelectedAsset(), this)
                {
                    Visible = true
                };
            });
            FormUtility.AddContextMenu(dataGridView, contextMenuItemEdit, contextMenuItemDelete);
            FormUtility.AddControlsToForm(this, dataGridView, addNewAsset, ruleName);
        }

        /// <summary>
        /// Implementation of <see cref="IPassedObject{T}"/>
        /// </summary>
        /// <param name="obj">From sub form passed object</param>
        public void OnSubmit(Asset obj)
        {
            TableUtility tableUtility = new TableUtility();
            tableUtility.InsertTableRow(obj);
            FormUtility.GetBindingSource(dataGridView).Add(obj);
        }

        /// <summary>
        /// Gets the current selected <see cref="Asset"/>in the <see cref="DataGridView"/>
        /// </summary>
        /// <returns>Selected asset</returns>
        private Asset GetSelectedAsset()
        {
            return dataGridView.SelectedRows[0].DataBoundItem as Asset;
        }

        /// <summary>
        /// Implementation of <see cref="IRuleUserControl"/>
        /// </summary>
        /// <param name="ruleKind">Selected <see cref="RuleKind"/></param>
        /// <returns>Newly created rule, in that case an <see cref="AllowList"/></returns>
        public Rule InvokeSubmission(RuleKind ruleKind)
        {
            if (passedRule != null)
            {
                passedRule.Name = ruleName.Text;
                BindingList<Asset> changedAllowList = (BindingList<Asset>) FormUtility.GetBindingSource(dataGridView).List;
                passedRule.Allowed = changedAllowList.ToList();
                return passedRule;
            }
            AllowList newAllowList = new AllowList(RuleKind.RULE_EXCEPTION, ruleName.Text);
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                newAllowList.Allowed.Add(row.DataBoundItem as Asset);
            }
            TableUtility tableUtility = new TableUtility();
            tableUtility.CreateTable(newAllowList);
            tableUtility.InsertTableRow(newAllowList);
            return newAllowList;
        }
    }
}
