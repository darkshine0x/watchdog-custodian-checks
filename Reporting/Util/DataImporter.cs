using Microsoft.Office.Interop.Excel;
using System.Data;
using Watchdog.Persistence;
using DataTable = System.Data.DataTable;

namespace Watchdog.Reporting.Util
{
    public class DataImporter
    {
        private readonly string inputTable;
        private DataSet data;

        public DataImporter(string inputTable = "INPUT")
        {
            this.inputTable = inputTable;
        }

        public void LoadTable()
        {
            TableUtility tableUtility = new TableUtility();
            Worksheet ws = tableUtility.FindWorksheet(inputTable);
            Range usedRange = ws.UsedRange;
            // usedRange.Columns.ClearFormats();
            // usedRange.Rows.ClearFormats();
            data = new DataSet();
            DataTable dataTable = new DataTable();
            for (int colCounter = 1; colCounter != usedRange.Columns.Count + 1; colCounter++) {
                DataColumn headerCol = new DataColumn();
                Range cell = usedRange[1, colCounter];
                headerCol.ColumnName = cell.Value2.ToString();
                dataTable.Columns.Add(headerCol);
            }

            // Iterate over rows
            for (int row = 2; row != usedRange.Rows.Count + 1; row++)
            {
                DataRow dataRow = dataTable.NewRow();
                for (int col = 1; col != usedRange.Columns.Count + 1; col++)
                {
                    Range cell = usedRange[row, col];
                    dataRow[col - 1] = cell.Value2;
                }
                dataTable.Rows.Add(dataRow);
            }

            data.Tables.Add(dataTable);
        }

        public DataSet GetData()
        {
            return data;
        }
    }
}
