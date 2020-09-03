using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Watchdog.Entities;
using Watchdog.Forms.Util;
using Watchdog.Persistence;

namespace Watchdog.Forms.FundAdministration
{
    public partial class AddFundForm : Form, IPassedForm
    {
        private int currentRowIndex;
        public AddFundForm()
        {
            InitializeComponent();
            LoadFundTable();
            FormUtility.AddValidation(buttonSubmit, textBoxCurrency, () =>
            {
                TableUtility tableUtility = new TableUtility();
                List<Range> currencyRange = tableUtility.ReadTableRow(Currency.GetDefaultValue(), new Dictionary<string, string>
                {
                    {"IsoCode", textBoxCurrency.Text.ToUpper() }
                }, QueryOperator.OR);

                if (currencyRange.Count == 0 || currencyRange.Count > 1)
                {
                    textBoxCurrency.BackColor = Color.Red;
                    return false;
                }
                Currency currency = tableUtility.ConvertRangesToObjects<Currency>(currencyRange)[0];
                Fund newFund = new Fund(textBoxFundName.Text, textBoxIsin.Text, textBoxCustodyNr.Text, currency);
                tableUtility.InsertTableRow(newFund);
                fundBinding.Add(newFund);
                return true;
            });
        }

        private void LoadFundTable()
        {
            TableUtility tableUtility = new TableUtility();
            tableUtility.CreateTable(Currency.GetDefaultValue());
            tableUtility.CreateTable(Fund.GetDefaultValue());
            List<Fund> fundList = tableUtility.ConvertRangesToObjects<Fund>(tableUtility.ReadAllRows(Fund.GetDefaultValue()));
            foreach (Fund fund in fundList)
            {
                fundBinding.Add(fund);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditFundClick(object sender, EventArgs e)
        {
            Fund fund = dataGridFunds.Rows[currentRowIndex].DataBoundItem as Fund;
            _ = new EditFund(this, fund)
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
            TableUtility tableUtility = new TableUtility();
            Persistable objectToDelete = dataGridFunds.Rows[currentRowIndex].DataBoundItem as Persistable;
            dataGridFunds.Rows.RemoveAt(currentRowIndex);
            tableUtility.DeleteTableRow(objectToDelete);
        }

        public void OnSubmit(List<string> passedValue = null, string reference = null)
        {
            LoadFundTable();
        }
    }
}
