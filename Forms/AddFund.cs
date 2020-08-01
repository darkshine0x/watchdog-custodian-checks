using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Watchdog.Entities;
using Watchdog.Persistence;

namespace Watchdog.Forms
{
    public partial class AddFundForm : Form
    {
        public AddFundForm()
        {
            InitializeComponent();
            LoadFundTable();
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            TableUtility tableUtility = new TableUtility(Globals.WatchdogAddIn.Application.ActiveWorkbook);
            Fund newFund = new Fund(textBoxFundName.Text, textBoxIsin.Text, textBoxCustodyNr.Text, new Currency(textBoxCurrency.Text));
            tableUtility.CreateMissingTable(newFund);
            List<string> data = new List<string>()
            {
                textBoxFundName.Text,
                textBoxCustodyNr.Text,
                textBoxIsin.Text,
                textBoxCurrency.Text
            };
            tableUtility.InsertTableRow(newFund, data);
            fundBindingSource.Add(newFund);
        }

        private void LoadFundTable()
        {
            TableUtility tableUtility = new TableUtility(Globals.WatchdogAddIn.Application.ActiveWorkbook);
            List<Fund> fundList = tableUtility.ConvertRangeToFund(tableUtility.ReadAllRows(Fund.GetDefaultValue().GetTableName()));
            foreach (Fund fund in fundList)
            {
                fundBindingSource.Add(fund);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FundBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void DataGridFunds_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu contextMenu = new ContextMenu();
                dataGridFunds.ContextMenu = contextMenu;
                contextMenu.MenuItems.Add("Fonds bearbeiten");
                contextMenu.MenuItems.Add("Asset Allocation bearbeiten");
                contextMenu.MenuItems.Add("Fonds löschen");
                contextMenu.Show(dataGridFunds, dataGridFunds.PointToClient(Cursor.Position));
            }
        }
    }
}
