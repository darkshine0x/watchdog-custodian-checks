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
        private DataGridView dataGridFunds;

        public AddFundForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadFundTable();
        }

        private void InitializeCustomComponents()
        {
            dataGridFunds = FormUtility.CreateDataGridView(typeof(Fund), 80, 580);
            Controls.Add(dataGridFunds);
            ToolStripMenuItem itemDelete = FormUtility.CreateContextMenuItem("Löschen", DeleteFundClick);
            ToolStripMenuItem itemEditFund = FormUtility.CreateContextMenuItem("Fonds bearbeiten", EditFundClick);
            FormUtility.AddContextMenu(dataGridFunds, itemDelete, itemEditFund);
            FormUtility.GetBindingSource(dataGridFunds).Clear();
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
                FormUtility.GetBindingSource(dataGridFunds).Add(newFund);
                return true;
            });
        }

        private void LoadFundTable()
        {
            FormUtility.GetBindingSource(dataGridFunds).Clear();
            TableUtility tableUtility = new TableUtility();
            tableUtility.CreateTable(Currency.GetDefaultValue());
            tableUtility.CreateTable(Fund.GetDefaultValue());
            List<Fund> fundList = tableUtility.ConvertRangesToObjects<Fund>(tableUtility.ReadAllRows(Fund.GetDefaultValue()));
            foreach (Fund fund in fundList)
            {
                FormUtility.GetBindingSource(dataGridFunds).Add(fund);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditFundClick(object sender, EventArgs e)
        {
            Fund fund = dataGridFunds.SelectedRows[0].DataBoundItem as Fund;
            _ = new EditFund(this, fund)
            {
                Visible = true
            };
        }

        private void DeleteFundClick(object sender, EventArgs e)
        {
            TableUtility tableUtility = new TableUtility();
            DataGridViewRow selectedRow = dataGridFunds.SelectedRows[0];
            Persistable objectToDelete = selectedRow.DataBoundItem as Persistable;
            dataGridFunds.Rows.RemoveAt(selectedRow.Index);
            tableUtility.DeleteTableRow(objectToDelete);
        }

        public void OnSubmit(List<string> passedValue = null, string reference = null)
        {
            LoadFundTable();
        }
    }
}
