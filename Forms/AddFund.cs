using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Watchdog.Entities;
using Watchdog.Persistence;
using static System.Windows.Forms.DataGridView;

namespace Watchdog.Forms
{
    public partial class AddFundForm : Form
    {
        private int currentRowIndex;
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

        private void ClickEditAA(object sender, EventArgs e)
        {
            Fund fund = dataGridFunds.Rows[currentRowIndex].DataBoundItem as Fund;
            _ = new EditAssetAllocation(fund)
            {
                Visible = true
            };
        }

        private void DataGridFundsMouseDown(object sender, MouseEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            if (e.Button == MouseButtons.Right)
            {
                currentRowIndex = FormUtility.DataGridViewMouseDownContextMenu(dataGridView, e);
            }
        }

        private void DeleteFundClick(object sender, EventArgs e)
        {
            TableUtility tableUtility = new TableUtility(Globals.WatchdogAddIn.Application.ActiveWorkbook);
            Persistable objectToDelete = dataGridFunds.Rows[currentRowIndex].DataBoundItem as Persistable;
            dataGridFunds.Rows.RemoveAt(currentRowIndex);
            tableUtility.DeleteTableRow(objectToDelete.GetTableName(), objectToDelete.GetIndex());
        }
    }
}
