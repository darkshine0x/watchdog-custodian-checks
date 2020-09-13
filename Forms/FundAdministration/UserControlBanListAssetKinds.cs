using System.Collections.Generic;
using System.Windows.Forms;
using Watchdog.Entities;
using Watchdog.Forms.Util;
using Watchdog.Persistence;

namespace Watchdog.Forms.FundAdministration
{
    public partial class UserControlBanListAssetKinds : UserControl, IPassedForm, IRuleUserControl
    {
        private DataGridView dataGridView;
        private Button addNewAssetKind;
        private TextBox ruleName;
        private AssetKind selectedAssetKind;

        public UserControlBanListAssetKinds()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        public void OnSubmit(List<string> passedValue = null, string reference = null)
        {
            TableUtility tableUtility = new TableUtility();
            switch (reference)
            {
                case "asset_kind":
                    tableUtility.CreateTable(AssetKind.GetDefaultValue());
                    AssetKind newAssetKind = new AssetKind(passedValue[0]);
                    tableUtility.InsertTableRow(newAssetKind);
                    FormUtility.GetBindingSource(dataGridView).Add(newAssetKind);
                    break;

                case "asset_kind_edit":
                    selectedAssetKind.Description = passedValue[0];
                    tableUtility.MergeTableRow(selectedAssetKind);
                    break;
            }
        }

        private void InitializeCustomComponents()
        {
            ruleName = FormUtility.CreateTextBox(20, 5);
            addNewAssetKind = FormUtility.CreateButton("Neue Titelart hinzufügen", 20, 65);
            addNewAssetKind.Click += (sender, e) => new OneAttributeForm(this, "Titelart", "asset_kind").Visible = true;
            dataGridView = FormUtility.CreateDataGridView(typeof(AssetKind), 20, 210, 400, 1050);
            ToolStripMenuItem contextMenuItemDelete = FormUtility.CreateContextMenuItem("Löschen", (sender, e) => 
            {
                TableUtility tableUtility = new TableUtility();
                tableUtility.DeleteTableRow(GetSelectedAssetKind());
                dataGridView.Rows.Remove(dataGridView.SelectedRows[0]);
            });
            ToolStripMenuItem contextMenuItemEdit = FormUtility.CreateContextMenuItem("Bearbeiten", (sender, e) => 
            {
                selectedAssetKind = GetSelectedAssetKind();
                _ = new OneAttributeForm(this, "Titelart", "asset_kind_edit", selectedAssetKind.Description)
                {
                    Visible = true
                };
            });
            FormUtility.AddContextMenu(dataGridView, contextMenuItemEdit, contextMenuItemDelete);
            FormUtility.AddControlsToForm(this, dataGridView, addNewAssetKind, ruleName);
        }

        private AssetKind GetSelectedAssetKind()
        {
            return dataGridView.SelectedRows[0].DataBoundItem as AssetKind;
        }

        public Rule InvokeSubmission(RuleKind ruleKind)
        {
            BanList<AssetKind> newBanList = new BanList<AssetKind>(RuleKind.RESTRICTED_INSTRUMENT_TYPE, ruleName.Text);
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                newBanList.Banned.Add(row.DataBoundItem as AssetKind);
            }
            TableUtility tableUtility = new TableUtility();
            tableUtility.CreateTable(newBanList);
            tableUtility.InsertTableRow(newBanList);
            return newBanList;
        }
    }
}
