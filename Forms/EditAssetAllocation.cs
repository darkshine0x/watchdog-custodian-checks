using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Watchdog.Entities;
using Watchdog.Persistence;

namespace Watchdog.Forms
{
    // Plan zum Updaten der Tabelle. Wenn die Tabelle geladen wird, soll in die jeweilige Textbox gleich der zugehörige Wert geladen werden.
    public partial class EditAssetAllocation : Form
    {
        private readonly Fund fund;
        private bool updateable;
        private double totalRow;
        private double totalCol;

        public EditAssetAllocation(Fund fund = null)
        {
            InitializeComponent();
            if (fund != null)
            {
                this.fund = fund;
                LabelFund.Text = fund.Name;
            }
            LoadTable();
            CalcTotals();
            
        }

        private Label GenerateLabel<T>(string text, T bindingObject) where T : Persistable
        {
            Padding padding = Padding.Empty;
            Padding margin = new Padding(1, 0, 0, 1);
            Label label =  new Label
            {
                Text = text,
                Width = 200,
                Height = 50,
                Margin = margin,
                Padding = padding,
                BackColor = Color.White,
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font(Font, Font.Style | FontStyle.Bold)
            };
            if (bindingObject != null)
            {
                Binding binding = new Binding(string.Empty, bindingObject, string.Empty);
                label.DataBindings.Add(binding);
            }
            return label;
        }

        private double GetColumnSum(int col)
        {
            double sum = 0;
            for (int row = 1; row < tableLayoutPanel1.RowCount - 1; row++)
            {
                TextBox textBox = tableLayoutPanel1.GetControlFromPosition(col, row) as TextBox;
                double.TryParse(textBox.Text, out double number);
                sum += number;
            }
            return sum;
        }

        private double GetRowSum(int row)
        {
            double sum = 0;
            for (int col = 1; col < tableLayoutPanel1.ColumnCount - 1; col++)
            {
                TextBox textBox = tableLayoutPanel1.GetControlFromPosition(col, row) as TextBox;
                double.TryParse(textBox.Text, out double number);
                sum += number;
            }
            return sum;
        }

        private double GetTotalSum()
        {
            double sum = 0;
            for (int row = 1; row < tableLayoutPanel1.RowCount - 1; row++)
            {
                int col = tableLayoutPanel1.ColumnCount - 1;
                Label rowSum = tableLayoutPanel1.GetControlFromPosition(col, row) as Label;
                double.TryParse(rowSum.Text, out double number);
                sum += number;
            }
            return sum;
        }

        private AssetAllocationEntry GetAssetAllocationEntry(AssetClass assetClass, Currency currency)
        {
            TableUtility tableUtility = new TableUtility(Globals.WatchdogAddIn.Application.ActiveWorkbook);
            List<AssetAllocationEntry> entries = tableUtility.ConvertRangesToObjects<AssetAllocationEntry>(tableUtility.ReadAllRows(AssetAllocationEntry.GetDefaultValue().GetTableName()));
            var entryQuery = from entry in entries
                             where entry.AssetClass.Name.Equals(assetClass.Name)
                             where entry.Currency.IsoCode.Equals(currency.IsoCode)
                             where entry.Fund.Index == fund.Index
                             select entry;

            List<AssetAllocationEntry> list = entryQuery.ToList();
            if (list.Count == 0)
            {
                return null;
            }
            return entryQuery.ToList()[0];
        }

        private void LoadTable()
        {
            TableUtility tableUtility = new TableUtility(Globals.WatchdogAddIn.Application.ActiveWorkbook);
            List<AssetClass> assetClasses = tableUtility.ConvertRangesToObjects<AssetClass>(tableUtility.ReadAllRows(AssetClass.GetDefaultValue().GetTableName()));
            List<Currency> currencies = tableUtility.ConvertRangesToObjects<Currency>(tableUtility.ReadAllRows(Currency.GetDefaultValue().GetTableName()));
            int numberOfColumns = assetClasses.Count + 1;
            int numberOfRows = currencies.Count + 1;
            tableLayoutPanel1.ColumnCount = numberOfColumns + 1;
            tableLayoutPanel1.RowCount = numberOfRows + 1;

            // First cell, should be empty
            tableLayoutPanel1.Controls.Add(GenerateLabel<Persistable>(string.Empty, null), 0, 0);

            Padding padding = Padding.Empty;

            // Add column labels for asset classes
            for (int col = 1; col < numberOfColumns; col++)
            {
                AssetClass assetClass = assetClasses[col - 1];
                Label columnLabel = GenerateLabel(assetClass.Name, assetClass);
                tableLayoutPanel1.Controls.Add(columnLabel, col, 0);
            }

            // Add total column
            tableLayoutPanel1.Controls.Add(GenerateLabel<Persistable>("Total", null), numberOfColumns, 0);

            // Add row labels for currencies
            for (int row = 1; row < numberOfRows; row++)
            {
                Currency currency = currencies[row - 1];
                Label rowLabel = GenerateLabel(currency.IsoCode, currency);
                tableLayoutPanel1.Controls.Add(rowLabel, 0, row);
            }

            // Add total row
            tableLayoutPanel1.Controls.Add(GenerateLabel<Persistable>("Total", null), 0, numberOfRows);

            // Add text boxes
            for (int row = 1; row < numberOfRows; row++)
            {
                for (int col = 1; col < numberOfColumns; col++)
                {
                    AssetClass assetClass = tableLayoutPanel1.GetControlFromPosition(col, 0).DataBindings[0].DataSource as AssetClass;
                    Currency currency = tableLayoutPanel1.GetControlFromPosition(0, row).DataBindings[0].DataSource as Currency;
                    TextBox textBox = new TextBox
                    {
                        AutoSize = false,
                        Width = 200,
                        Height = 50,
                        Margin = new Padding(1, 0, 0, 0),
                        BorderStyle = BorderStyle.None,
                        TextAlign = HorizontalAlignment.Right
                    };

                    AssetAllocationEntry entry = GetAssetAllocationEntry(assetClass, currency);
                    if (entry != null)
                    {
                        updateable = true;
                        textBox.Text = entry.Value.ToString();
                        Binding binding = new Binding(string.Empty, entry, string.Empty);
                        textBox.DataBindings.Add(binding);
                    }

                    textBox.KeyUp += (tb, keyUp) =>
                    {
                        CalcTotals(tb);
                    };
                    textBox.KeyUp += (tb, keyUp) =>
                    {
                        TextBox t = tb as TextBox;
                        bool cellContentIsNumber = double.TryParse(t.Text, out _);
                        if (!cellContentIsNumber)
                        {
                            t.Clear();
                        }
                    };
                    tableLayoutPanel1.Controls.Add(textBox);
                }
            }

            // Add total labels in last column
            for (int row = 1; row < numberOfRows + 1; row++)
            {
                tableLayoutPanel1.Controls.Add(GenerateLabel<Persistable>("", null), numberOfColumns, row);
            }

            // Add total labels in last row
            for (int col = 1; col < numberOfColumns; col++)
            {
                tableLayoutPanel1.Controls.Add(GenerateLabel<Persistable>("", null), col, numberOfRows);
            }
        }

        private void CalcTotals(object tb)
        {
            int numberOfRows = tableLayoutPanel1.RowCount - 1;
            int numberOfColumns = tableLayoutPanel1.ColumnCount - 1;
            TableLayoutPanelCellPosition position = tableLayoutPanel1.GetPositionFromControl(tb as TextBox);
            Label totalAssetClass = tableLayoutPanel1.GetControlFromPosition(position.Column, numberOfRows) as Label;
            Label totalCurrency = tableLayoutPanel1.GetControlFromPosition(numberOfColumns, position.Row) as Label;
            Label total = tableLayoutPanel1.GetControlFromPosition(numberOfColumns, numberOfRows) as Label;
            double rowSum = GetRowSum(position.Row);
            double columnSum = GetColumnSum(position.Column);
            totalCurrency.Text = rowSum.ToString();
            totalAssetClass.Text = columnSum.ToString();
            double totalSum = GetTotalSum();
            total.Text = totalSum.ToString();
        }

        private void CalcTotals()
        {
            for (int col = 1; col < tableLayoutPanel1.ColumnCount - 1; col++)
            {
                double colSum = GetColumnSum(col);
                totalCol += colSum;
                Label label = tableLayoutPanel1.GetControlFromPosition(col, tableLayoutPanel1.RowCount - 1) as Label;
                label.Text = colSum.ToString();
            }
            for (int row = 1; row < tableLayoutPanel1.RowCount - 1; row++)
            {
                double rowSum = GetRowSum(row);
                totalRow += rowSum;
                Label label = tableLayoutPanel1.GetControlFromPosition(tableLayoutPanel1.ColumnCount - 1, row) as Label;
                label.Text = rowSum.ToString();
            }
            tableLayoutPanel1.GetControlFromPosition(tableLayoutPanel1.ColumnCount - 1, tableLayoutPanel1.RowCount - 1).Text = totalCol.ToString();
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            TableUtility tableUtility = new TableUtility(Globals.WatchdogAddIn.Application.ActiveWorkbook);
            tableUtility.CreateMissingTable(AssetAllocationEntry.GetDefaultValue());
            CalcTotals();
            if (totalRow != 100 || totalCol != 100)
            {
                MessageBox.Show("Gesamttotal muss 100% sein.");
                return;
            }
            for (int col = 1; col < tableLayoutPanel1.ColumnCount - 1; col++)
            {
                for (int row = 1; row < tableLayoutPanel1.RowCount - 1; row++)
                {
                    bool parsingSuccessful = double.TryParse(tableLayoutPanel1.GetControlFromPosition(col, row).Text, out double value);
                    if (!parsingSuccessful)
                    {
                        value = 0;
                    }
                    if (updateable)
                    {
                        AssetAllocationEntry entry = tableLayoutPanel1.GetControlFromPosition(col, row).DataBindings[0].DataSource as AssetAllocationEntry;
                        TableUpdateWrapper update = new TableUpdateWrapper(entry.Index, "value", tableLayoutPanel1.GetControlFromPosition(col, row).Text);
                        tableUtility.UpdateTableRow(entry, update);
                    } else
                    {
                        AssetAllocationEntry assetAllocationEntry = new AssetAllocationEntry
                        {
                            AssetClass = tableLayoutPanel1.GetControlFromPosition(col, 0).DataBindings[0].DataSource as AssetClass,
                            Currency = tableLayoutPanel1.GetControlFromPosition(0, row).DataBindings[0].DataSource as Currency,
                            Value = value,
                            Fund = fund
                        };
                        tableUtility.InsertTableRow(assetAllocationEntry, new List<string>
                    {
                        assetAllocationEntry.AssetClass.Index.ToString(),
                        assetAllocationEntry.Currency.Index.ToString(),
                        value.ToString(),
                        fund.Index.ToString()
                    });
                    }
                }
            }
            Close();
        }
    }
}
