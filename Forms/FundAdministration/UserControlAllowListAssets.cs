using System.Windows.Forms;
using Watchdog.Entities;
using Watchdog.Forms.Util;
using Watchdog.Persistence;

namespace Watchdog.Forms.FundAdministration
{
    public partial class UserControlAllowListAssets : UserControl, IPassedObject<Asset>, IRuleUserControl
    {
        private DataGridView dataGridView;
        private Button addNewAsset;
        private TextBox ruleName;

        public UserControlAllowListAssets()
        {
            InitializeComponent();
            InitializeCustomComponents();
            TableUtility tableUtility = new TableUtility();
            tableUtility.CreateTable(Asset.GetDefaultValue());
        }

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

        public void OnSubmit(Asset obj)
        {
            TableUtility tableUtility = new TableUtility();
            tableUtility.InsertTableRow(obj);
            FormUtility.GetBindingSource(dataGridView).Add(obj);
        }

        private Asset GetSelectedAsset()
        {
            return dataGridView.SelectedRows[0].DataBoundItem as Asset;
        }

        public Rule InvokeSubmission(RuleKind ruleKind)
        {
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
