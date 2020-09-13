/*
 * Author: Jan Baumann
 * Version: 12.09.2020
 */

using System.Drawing;
using System.Windows.Forms;
using Watchdog.Entities;
using Watchdog.Forms.Util;
using Watchdog.Persistence;

namespace Watchdog.Forms.FundAdministration
{
    /// <summary>
    /// Form for entering properties for a new <see cref="Asset"/>
    /// </summary>
    public partial class AddAssetForm : Form
    {
        private TableLayoutPanel tableLayoutPanel;
        private TextBox textBoxAssetId;
        private TextBox textBoxIsin;
        private TextBox textBoxName;
        private Button submitButton;
        private Button cancelButton;
        private readonly IPassedObject<Asset> passedObject;
        private readonly Asset asset;

        /// <summary>
        /// Constructor with emty text boxes when a new asset has to be added.
        /// </summary>
        /// <param name="passedObject"><see cref="IPassedObject{T}"/></param>
        public AddAssetForm(IPassedObject<Asset> passedObject)
        {
            this.passedObject = passedObject;
            InitializeComponent();
            InitializeCustomComponents();
        }

        /// <summary>
        /// Constructor with pre-filled text boxes for editing an existing asset.
        /// </summary>
        /// <param name="asset"><see cref="Asset"/></param>
        /// <param name="passedObject"><see cref="IPassedObject{T}"/></param>
        public AddAssetForm(Asset asset, IPassedObject<Asset> passedObject) : this(passedObject)
        {
            this.asset = asset;
            textBoxAssetId.Text = asset.AssetId.ToString();
            textBoxIsin.Text = asset.Isin;
            textBoxName.Text = asset.Name;
        }

        /// <summary>
        /// Initialization of self-added controls
        /// </summary>
        private void InitializeCustomComponents()
        {
            tableLayoutPanel = FormUtility.CreateTableLayoutPanel(50, 80, 300, 800);
            tableLayoutPanel.BackColor = SystemColors.Control;
            textBoxAssetId = FormUtility.CreateTextBox();
            textBoxIsin = FormUtility.CreateTextBox();
            textBoxName = FormUtility.CreateTextBox();
            submitButton = FormUtility.CreateButton("Bestätigen", 80, 460);
            cancelButton = FormUtility.CreateButton("Abbrechen", 780, 460);
            FormUtility.AddValidation(submitButton, textBoxAssetId, () =>
            {
                bool isInt = int.TryParse(textBoxAssetId.Text, out int assetId);
                if (isInt)
                {
                    if (asset != null)
                    {
                        asset.AssetId = assetId;
                        asset.Isin = textBoxIsin.Text;
                        asset.Name = textBoxName.Text;
                        TableUtility tableUtility = new TableUtility();
                        tableUtility.MergeTableRow(asset);
                        Close();
                        return true;
                    }
                    Asset createdAsset = new Asset(assetId, textBoxIsin.Text, textBoxName.Text);
                    passedObject.OnSubmit(createdAsset);
                    Close();
                    return true;
                }
                return false;
            });
            cancelButton.Click += (sender, e) => Close();
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.Controls.Add(new Label { Text = "Asset-ID", Height = 80, Width = 200 }, 0, 0);
            tableLayoutPanel.Controls.Add(textBoxAssetId, 1, 0);
            tableLayoutPanel.Controls.Add(new Label { Text = "ISIN", Height = 80, Width = 200 }, 0, 1);
            tableLayoutPanel.Controls.Add(textBoxIsin, 1, 1);
            tableLayoutPanel.Controls.Add(new Label { Text = "Name", Height = 80, Width = 200 }, 0, 2);
            tableLayoutPanel.Controls.Add(textBoxName, 1, 2);
            FormUtility.AddControlsToForm(this, tableLayoutPanel, submitButton, cancelButton);
        }
    }
}
