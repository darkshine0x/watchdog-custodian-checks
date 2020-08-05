using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Watchdog.Entities;
using Watchdog.Persistence;

namespace Watchdog.Forms
{
    public partial class EditAssetAllocation : Form
    {
        public EditAssetAllocation(Fund fund = null)
        {
            InitializeComponent();
            LoadTable();
            if (fund != null)
            {
                LabelFund.Text = fund.Name;
            }
        }

        private Label GenerateLabel(string text)
        {
            Padding padding = Padding.Empty;
            Padding margin = new Padding(1, 0, 0, 1);
            return new Label
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

        private void LoadTable()
        {
            TableUtility tableUtility = new TableUtility(Globals.WatchdogAddIn.Application.ActiveWorkbook);
            List<AssetClass> assetClasses = tableUtility.ConvertRangeToAssetClass(tableUtility.ReadAllRows(AssetClass.GetDefaultValue().GetTableName()));
            List<Currency> currencies = tableUtility.ConvertRangeToCurrency(tableUtility.ReadAllRows(Currency.GetDefaultValue().GetTableName()));
            int numberOfColumns = assetClasses.Count + 1;
            int numberOfRows = currencies.Count + 1;
            tableLayoutPanel1.ColumnCount = numberOfColumns + 1;
            tableLayoutPanel1.RowCount = numberOfRows + 1;

            // First cell, should be empty
            tableLayoutPanel1.Controls.Add(GenerateLabel(string.Empty), 0, 0);

            Padding padding = Padding.Empty;

            // Add column labels for asset classes
            for (int col = 1; col < numberOfColumns; col++)
            {
                tableLayoutPanel1.Controls.Add(GenerateLabel(assetClasses[col - 1].Name), col, 0);
            }

            // Add total column
            tableLayoutPanel1.Controls.Add(GenerateLabel("Total"), numberOfColumns, 0);

            // Add row labels for currencies
            for (int row = 1; row < numberOfRows; row++)
            {
                tableLayoutPanel1.Controls.Add(GenerateLabel(currencies[row - 1].IsoCode), 0, row);
            }

            // Add total row
            tableLayoutPanel1.Controls.Add(GenerateLabel("Total"), 0, numberOfRows);

            // Add text boxes
            for (int row = 1; row < numberOfRows; row++)
            {
                for (int col = 1; col < numberOfColumns; col++)
                {
                    TextBox textBox = new TextBox
                    {
                        AutoSize = false,
                        Width = 200,
                        Height = 50,
                        Margin = new Padding(1, 0, 0, 0),
                        BorderStyle = BorderStyle.None,
                        TextAlign = HorizontalAlignment.Right
                    };
                    textBox.KeyUp += (tb, keyUp) =>
                    {
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
                tableLayoutPanel1.Controls.Add(GenerateLabel(""), numberOfColumns, row);
            }

            // Add total labels in last row
            for (int col = 1; col < numberOfColumns; col++)
            {
                tableLayoutPanel1.Controls.Add(GenerateLabel(""), col, numberOfRows);
            }
        }
    }
}
