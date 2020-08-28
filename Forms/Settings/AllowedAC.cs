using System.Collections.Generic;
using System.Windows.Forms;
using Watchdog.Persistence;
using Watchdog.Entities;
using System;
using Watchdog.Forms.Util;

namespace Watchdog.Forms.Settings
{
    public partial class UserControlAllowedACAndCurrencies : UserControl, IPassedForm
    {
        private int currentRowIndex;
        private DataGridView currentDataGridView;

        public UserControlAllowedACAndCurrencies()
        {
            InitializeComponent();
            LoadAssetClasses();
            LoadCurrencies();
        }

        private void LoadCurrencies()
        {
            TableUtility tableUtility = new TableUtility();
            List<Currency> currencyList = tableUtility.ConvertRangesToObjects<Currency>(tableUtility.ReadAllRows(Currency.GetDefaultValue()));
            foreach (Currency currency in currencyList)
            {
                currencyBindingSource.Add(currency);
            }
        }

        private void LoadAssetClasses()
        {
            TableUtility tableUtility = new TableUtility();
            List<AssetClass> assetClassList = tableUtility.ConvertRangesToObjects<AssetClass>(tableUtility.ReadAllRows(AssetClass.GetDefaultValue()));
            foreach (AssetClass assetClass in assetClassList)
            {
                assetClassBindingSource.Add(assetClass);
            }
        }

        private void AddAssetClass(string assetClassName)
        {
            TableUtility tableUtility = new TableUtility();
            tableUtility.CreateTable(AssetClass.GetDefaultValue());
            AssetClass assetClass = new AssetClass
            {
                Name = assetClassName
            };
            tableUtility.InsertTableRow(assetClass);
            assetClassBindingSource.Add(assetClass);
        }

        private void AddCurrency(string currencyIsoCode)
        {
            TableUtility tableUtility = new TableUtility();
            tableUtility.CreateTable(Currency.GetDefaultValue());
            Currency currency = new Currency
            {
                IsoCode = currencyIsoCode
            };
            tableUtility.InsertTableRow(currency);
            currencyBindingSource.Add(currency);
        }

        private void ButtonNewAssetClass_Click(object sender, EventArgs e)
        {
            _ = new OneAttributeForm(this, "Asset-Klasse", "asset_class")
            {
                Visible = true
            };
        }

        public void OnSubmit(List<string> passedValue, string reference)
        {
            switch (reference)
            {
                case "asset_class":
                    AddAssetClass(passedValue[0]);
                    break;

                case "currency":
                    AddCurrency(passedValue[0].ToUpper());
                    break;
            }
        }

        private void ButtonNewCurrency_Click(object sender, EventArgs e)
        {
            _ = new OneAttributeForm(this, "Währung", "currency")
            {
                Visible = true
            };
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            TableUtility tableUtility = new TableUtility();
            Persistable objectToDelete = currentDataGridView.Rows[currentRowIndex].DataBoundItem as Persistable;
            currentDataGridView.Rows.RemoveAt(currentRowIndex);
            tableUtility.DeleteTableRow(objectToDelete);
        }

        private void SetRowIndex(object sender, MouseEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            currentRowIndex = FormUtility.DataGridViewMouseDownContextMenu(dataGridView, e);
            currentDataGridView = dataGridView;
        }
    }
}
