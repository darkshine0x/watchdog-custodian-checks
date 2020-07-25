using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Watchdog.Persistence
{
    class TableUtility
    {
        private readonly string sequenceTableName = "wdt_sequence";
        private readonly Workbook workbook;

        public TableUtility(Workbook workbook)
        {
            this.workbook = workbook;
        }

        public  Workbook CreateMissingTable(Persistable persistable)
        {
            if (FindWorksheet(persistable.GetTableName()) != null) {
                return workbook;
            }
            CreateWorksheet(persistable);
            InsertRowCounter(persistable);
            return workbook;
        }

        private  Worksheet CreateSequenceTable()
        {
            Worksheet ws = FindWorksheet(sequenceTableName);
            if (ws != null)
            {
                return ws;
            }
            Worksheet createdSheet = CreateWorksheet(sequenceTableName, new List<string>() { "sequence" });
            createdSheet.Cells[2, 1].Value = 0;
            createdSheet.Cells[2, 2].Value = 0;
            createdSheet.AutoFilterMode = false;
            return createdSheet;
        }

        private  int InsertRowCounter(Persistable persistable)
        {
            Worksheet ws = FindWorksheet(sequenceTableName);
            if (ws == null)
            {
                ws = CreateSequenceTable();
            }
            int emptyColumn = FindFirstEmtpyColumn(sequenceTableName);
            ws.Cells[1, emptyColumn].Value = persistable.GetTableName();
            ws.Cells[2, emptyColumn].Value = 1;
            return emptyColumn;
        }

        private  int FindFirstEmtpyColumn(string tableName)
        {
            Worksheet ws = FindWorksheet(tableName);
            int c = 1;
            while (true)
            {
                if (ws.Cells[1, c].Value == null)
                {
                    return c;
                }
                c++;
            }
        }

        private  int FindColumn(Worksheet worksheet, string columnName)
        {
            int i = 1;
            foreach (Range cell in worksheet.UsedRange.Rows[1].Cells)
            {
                string cellValue = cell.Value.ToString();
                if (cellValue.Equals(columnName))
                {
                    return i;
                }
                i++;
            }

            if (i == 0)
            {
                throw new ArgumentException("Column does not exist in this table.");
            }

            return i;
        }

        private  int FindOrCreateRowCounterColumn(Persistable persistable)
        {
            Worksheet ws = FindWorksheet(sequenceTableName);
            if (ws == null)
            {
                CreateSequenceTable();
                return InsertRowCounter(persistable);
            }
            int c = 1;
            while (true)
            {
                if (persistable.GetTableName().Equals(ws.Cells[1, c].Value))
                {
                    return c;
                }
                if (ws.Cells[1, c].Value == null)
                {
                    return -1;
                }
                c++;
            }
        }

        private  double IncrementSequence()
        {
            Worksheet sequenceTable = CreateSequenceTable();
            double sequence = sequenceTable.Cells[2, 2].Value + 1;
            CreateSequenceTable().Cells[2, 2].Value = sequence;
            return sequence;
        }

        private  double IncrementRowCounter(Persistable persistable)
        {
            int column = FindOrCreateRowCounterColumn(persistable);
            Worksheet ws = FindWorksheet(sequenceTableName);
            double counter = ws.Cells[2, column].Value + 1;
            ws.Cells[2, column].Value = counter;
            return counter;
        }

        public  Worksheet FindWorksheet(string name)
        {
            try
            {
                return workbook.Worksheets[name];
            } 
            catch (Exception)
            {
                // MessageBox.Show(i.ToString());
                return null;
            }
        }

        public  Workbook InsertTableRow(Persistable persistable, List<string> data)
        {
            if (data.Count != persistable.GetTableHeader().Count)
            {
                throw new ArgumentException("The data row's length does not match the the number of table columns.");
            }
            Worksheet ws = FindWorksheet(persistable.GetTableName());
            if (ws == null)
            {
                MessageBox.Show("Tabelle existiert nicht.");
                return workbook;
            }
            double row = IncrementRowCounter(persistable);
            ws.Cells[row, 1].Value = IncrementSequence();
            for (int i = 0; i < data.Count; i++)
            {
                ws.Cells[row, i + 2].Value = data[i];
            }
            return workbook;
        }

        public  List<Range> ReadTableRow(string tableName, Dictionary<string, string> searchParameters, QueryOperator queryOperator)
        {
            List<Range> searchResult = new List<Range>();
            Worksheet worksheet = FindWorksheet(tableName);
            List<string> searchKeys = searchParameters.Keys.ToList();
            // HashSet<double> foundRows = new HashSet<double>();
            Dictionary<string, double> columnIndizes = new Dictionary<string, double>();
            foreach (string key in searchKeys)
            {
                double col = FindColumn(worksheet, key);
                columnIndizes.Add(key, col);
            }

            foreach (Range row in worksheet.UsedRange.Rows)
            {
                foreach (string key in columnIndizes.Keys.ToList())
                {
                    Range rowCell = row.Cells[1, columnIndizes[key]];
                    if (rowCell.Value == null)
                    {
                        break;
                    }
                    string cellValue = rowCell.Value.ToString();
                    bool breakIteration = false;
                    bool rowFound = false;
                    switch (queryOperator)
                    {
                        case QueryOperator.AND:
                            if (!cellValue.Equals(searchParameters[key]))
                            {
                                breakIteration = true;
                            }
                            rowFound = true;
                            break;

                        case QueryOperator.OR:
                            if (cellValue.Equals(searchParameters[key]))
                            {
                                searchResult.Add(row);
                                breakIteration = true;
                            } 
                            break;
                    }
                    if (breakIteration)
                    {
                        break;
                    }
                    if (rowFound)
                    {
                        searchResult.Add(row);
                        break;
                    }
                }
                
            }
            return searchResult;
        }

        public  bool DeleteTableRow(string tableName, Dictionary<string, string> searchParameters, QueryOperator queryOperator)
        {
            List<Range> searchResult = ReadTableRow(tableName, searchParameters, queryOperator);
            if (!searchResult.Any())
            {
                return true;
            }

            foreach (Range row in searchResult)
            {
                row.EntireRow.Delete();
            }
            return true;
        }

        public  bool UpdateTableRow(Persistable persistable, TableUpdateWrapper update)
        {
            Dictionary<string, string> searchParameters = new Dictionary<string, string>()
            {
                {"index", update.Index.ToString() }
            };
            List<Range> searchResult = ReadTableRow(persistable.GetTableName(), searchParameters, QueryOperator.OR);
            if (!searchResult.Any())
            {
                return false;
            }
            int columnNumber = persistable.GetTableHeader().IndexOf(update.Attribute);
            searchResult[0].Cells[1, columnNumber + 2] = update.Value;
            return true;
        }

        public  Worksheet CreateWorksheet(Persistable persistable)
        {
            return CreateWorksheet(persistable.GetTableName(), persistable.GetTableHeader());
        }

        public  Worksheet CreateWorksheet(string tableName, List<string> tableHeader)
        {
            Worksheet createdSheet = workbook.Sheets.Add();
            createdSheet.Name = tableName;
            createdSheet.Cells[1, 1].Value = "index";
            for (int i = 0; i < tableHeader.Count; i++)
            {
                createdSheet.Cells[1, i + 2].Value = tableHeader[i];
            }
            createdSheet.Rows[1].AutoFilter();
            createdSheet.Rows[1].Font.Bold = true;
            createdSheet.Application.ActiveWindow.SplitRow = 1;
            createdSheet.Application.ActiveWindow.FreezePanes = true;
            return createdSheet;
        }
    }
}
