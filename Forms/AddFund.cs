using Microsoft.Office.Interop.Excel;
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
            LoadFundTable(Fund.GetDefaultValue());
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
            dataGridFunds.Rows.Add(data.ToArray());
        }

        private void LoadFundTable(Persistable persistable)
        {
            TableUtility tableUtility = new TableUtility(Globals.WatchdogAddIn.Application.ActiveWorkbook);
            List<Range> ranges = tableUtility.ReadAllRows(persistable.GetTableName());
            if (ranges == null)
            {
                return;
            }
            List<string[]> dataSets = tableUtility.ConvertRanges(ranges);
            foreach (string[] dataSet in dataSets)
            {
                dataGridFunds.Rows.Add(dataSet);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
