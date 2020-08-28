using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Watchdog.Entities;
using Watchdog.Persistence;

namespace Watchdog.Forms.FundAdministration
{
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
                Width = 150,
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
                FlowLayoutPanel panel = tableLayoutPanel1.GetControlFromPosition(col, row) as FlowLayoutPanel;
                double.TryParse(panel.Controls[1].Text, out double number);
                sum += number;
            }
            return sum;
        }

        private double GetRowSum(int row)
        {
            double sum = 0;
            for (int col = 1; col < tableLayoutPanel1.ColumnCount - 1; col++)
            {
                FlowLayoutPanel panel = tableLayoutPanel1.GetControlFromPosition(col, row) as FlowLayoutPanel;
                double.TryParse(panel.Controls[1].Text, out double number);
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
            List<AssetAllocationEntry> entries = tableUtility.ConvertRangesToObjects<AssetAllocationEntry>(tableUtility.ReadAllRows(AssetAllocationEntry.GetDefaultValue()));
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
            List<AssetClass> assetClasses = tableUtility.ConvertRangesToObjects<AssetClass>(tableUtility.ReadAllRows(AssetClass.GetDefaultValue()));
            List<Currency> currencies = tableUtility.ConvertRangesToObjects<Currency>(tableUtility.ReadAllRows(Currency.GetDefaultValue()));
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
                    Padding paddingOneLeft = new Padding(1, 0, 0, 0);
                    FlowLayoutPanel panel = new FlowLayoutPanel
                    {
                        Margin = paddingOneLeft,
                        Height = 50,
                        Width = 150
                    };


                    for (int i = 0; i < 3; i++)
                    {
                        TextBox textBox = new TextBox
                        {
                            AutoSize = false,
                            Width = 50,
                            Height = 50,
                            Margin = padding,
                            BorderStyle = BorderStyle.None,
                            TextAlign = HorizontalAlignment.Right
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
                        panel.Controls.Add(textBox);
                    }
                    panel.Controls[1].KeyUp += (tb, keyUp) =>
                    {
                        TextBox textBox = tb as TextBox;
                        FlowLayoutPanel flowPanel = ((TextBox)tb).Parent as FlowLayoutPanel;
                        CalcTotals(flowPanel);
                    };

                    AssetAllocationEntry entry = GetAssetAllocationEntry(assetClass, currency);
                    if (entry != null)
                    {
                        updateable = true;
                        panel.Controls[0].Text = entry.StrategicMinValue.ToString();
                        panel.Controls[1].Text = entry.StrategicOptValue.ToString();
                        panel.Controls[2].Text = entry.StrategicMaxValue.ToString();
                        Binding binding = new Binding(string.Empty, entry, string.Empty);
                        panel.DataBindings.Add(binding);
                    }

                    
                    tableLayoutPanel1.Controls.Add(panel);
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
            TableLayoutPanelCellPosition position = tableLayoutPanel1.GetPositionFromControl(tb as FlowLayoutPanel);
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
            totalCol = 0;
            totalRow = 0;
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
            tableUtility.CreateTable(AssetAllocationEntry.GetDefaultValue());
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
                    FlowLayoutPanel panel = tableLayoutPanel1.GetControlFromPosition(col, row) as FlowLayoutPanel;
                    double[] assetAllocationRange = new double[3];

                    for (int i = 0; i < 3; i++)
                    {
                        bool parsingSuccessful = double.TryParse(panel.Controls[i].Text, out double value);
                        if (!parsingSuccessful)
                        {
                            value = 0;
                        }
                        assetAllocationRange[i] = value;
                    }
                    
                    
                    if (updateable)
                    {
                        AssetAllocationEntry entry = tableLayoutPanel1.GetControlFromPosition(col, row).DataBindings[0].DataSource as AssetAllocationEntry;
                        TableUpdateWrapper update = new TableUpdateWrapper(entry.Index, "min_value", panel.Controls[0].Text);
                        tableUtility.UpdateTableRow(entry, update);
                        update = new TableUpdateWrapper(entry.Index, "opt_value", panel.Controls[1].Text);
                        tableUtility.UpdateTableRow(entry, update);
                        update = new TableUpdateWrapper(entry.Index, "max_value", panel.Controls[2].Text);
                        tableUtility.UpdateTableRow(entry, update);

                    } else
                    {
                        AssetAllocationEntry assetAllocationEntry = new AssetAllocationEntry
                        {
                            AssetClass = tableLayoutPanel1.GetControlFromPosition(col, 0).DataBindings[0].DataSource as AssetClass,
                            Currency = tableLayoutPanel1.GetControlFromPosition(0, row).DataBindings[0].DataSource as Currency,
                            StrategicMinValue = assetAllocationRange[0],
                            StrategicOptValue = assetAllocationRange[1],
                            StrategicMaxValue = assetAllocationRange[2],
                            Fund = fund
                        };
                        tableUtility.InsertTableRow(assetAllocationEntry);
                    }
                }
            }
            Close();
        }
    }
}
