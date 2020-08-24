using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Watchdog.Entities;
using Watchdog.Persistence;

namespace Watchdog.Forms
{
    public partial class AddFundForm : Form
    {
        private int currentRowIndex;
        public AddFundForm()
        {
            InitializeComponent();
            LoadFundTable();
            TableUtility tableUtility = new TableUtility(Globals.WatchdogAddIn.Application.ActiveWorkbook);
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            TableUtility tableUtility = new TableUtility(Globals.WatchdogAddIn.Application.ActiveWorkbook);
            tableUtility.CreateMissingTable(Currency.GetDefaultValue());
            tableUtility.CreateMissingTable(Fund.GetDefaultValue());
            textBoxCurrency.BackColor = Color.Empty;
            List<Range> currencyRange = tableUtility.ReadTableRow(Currency.GetDefaultValue().GetTableName(), new Dictionary<string, string>
            {
                {"iso_code", textBoxCurrency.Text }
            }, QueryOperator.OR);
            
            if (currencyRange.Count == 0 || currencyRange.Count > 1)
            {
                textBoxCurrency.BackColor = Color.Red;
                return;
            }

            Currency currency = tableUtility.ConvertRangesToObjects<Currency>(currencyRange)[0];
            Fund newFund = new Fund(textBoxFundName.Text, textBoxIsin.Text, textBoxCustodyNr.Text, currency);
            List<string> currencyData = new List<string>()
            {
                currency.IsoCode
            };
            tableUtility.InsertTableRow(currency, currencyData);
            List<string> fundData = new List<string>()
            {
                newFund.Name,
                newFund.CustodyAccountNumber,
                newFund.Isin,
                currency.GetIndex().ToString()
            };
            tableUtility.InsertTableRow(newFund, fundData);
            fundBinding.Add(newFund);
        }

        private void LoadFundTable()
        {
            TableUtility tableUtility = new TableUtility(Globals.WatchdogAddIn.Application.ActiveWorkbook);
            List<Fund> fundList = tableUtility.ConvertRangesToObjects<Fund>(tableUtility.ReadAllRows(Fund.GetDefaultValue().GetTableName()));
            foreach (Fund fund in fundList)
            {
                fundBinding.Add(fund);
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
            tableUtility.DeleteTableRow(objectToDelete, objectToDelete.GetIndex());
        }
    }
}
