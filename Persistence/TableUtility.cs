using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Watchdog.Persistence
{
    public class TableUtility
    {
        private readonly string sequenceTableName = "wdt_sequence";
        private readonly Workbook workbook;

        public TableUtility(Workbook workbook)
        {
            this.workbook = workbook;
        }

        public void CreateTable(Persistable persistable)
        {
            if (FindWorksheet(persistable.GetTableName()) != null)
            {
                return;
            }
            CreateTableWorksheet(persistable);
            InsertRowCounter(persistable);
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

        private int FindOrCreateRowCounterColumn(Persistable persistable)
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

        private  double ChangeRowCounter(Persistable persistable, bool decrement)
        {
            int column = FindOrCreateRowCounterColumn(persistable);
            Worksheet ws = FindWorksheet(sequenceTableName);
            double counter = ws.Cells[2, column].Value;
            if (decrement)
            {
                counter--;
            } else
            {
                counter++;
            }
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
                return null;
            }
        }

        public Workbook InsertTableRow(Persistable persistable)
        {
            Worksheet ws = FindWorksheet(persistable.GetTableName());
            if (ws == null)
            {
                MessageBox.Show("Tabelle existiert nicht.");
                return workbook;
            }
            double row = ChangeRowCounter(persistable, false);
            double sequence = IncrementSequence();
            ws.Cells[row, 1].Value = sequence;
            persistable.SetIndex(sequence);
            int colCounter = 2;
            foreach (PropertyInfo property in GetPersistableProperties(persistable))
            {
                Type propertyType = property.PropertyType;
                if (!propertyType.IsPrimitive && propertyType != typeof(string)) {
                    Persistable nestedObject = property.GetValue(persistable) as Persistable;
                    ws.Cells[row, colCounter].Value = nestedObject.GetIndex();
                } else
                {
                    ws.Cells[row, colCounter].Value = property.GetValue(persistable);
                }
                colCounter++;
            }
            return workbook;
        }

        private List<PropertyInfo> GetPersistableProperties(Persistable persistable)
        {
            PropertyInfo[] properties = persistable.GetType().GetProperties();
            List<PropertyInfo> persistableProperties = new List<PropertyInfo>();
            foreach (PropertyInfo property in properties)
            {
                if (property.GetCustomAttributes(typeof(PersistableField), false).Length != 0)
                {
                    persistableProperties.Add(property);
                }
            }
            return persistableProperties;
        }

        public List<Range> ReadAllRows(Persistable persistable)
        {
            List<Range> searchResult = new List<Range>();
            Worksheet worksheet = FindWorksheet(persistable.GetTableName());
            if (worksheet == null)
            {
                return null;
            }
            Range rows = worksheet.UsedRange.Rows;
            for (int index = 2; index < rows.Count + 1; index++)
            {
                searchResult.Add(rows[index]);
            }
            return searchResult;
        }

        public  List<Range> ReadTableRow(string tableName, Dictionary<string, string> searchParameters, QueryOperator queryOperator)
        {
            List<Range> searchResult = new List<Range>();
            Worksheet worksheet = FindWorksheet(tableName);
            List<string> searchKeys = searchParameters.Keys.ToList();
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

        public Range ReadTableRow(Persistable persistable)
        {
            Worksheet worksheet = FindWorksheet(persistable.GetTableName());
            foreach (Range row in worksheet.UsedRange.Rows)
            {
                double.TryParse(row.Cells[1, 1].Value.ToString(), out double rowIndex);
                if (rowIndex == persistable.GetIndex())
                {
                    return row;
                }
            }
            return null;
        }

        public List<T> ConvertRangesToObjects<T>(List<Range> ranges) where T : Persistable, new()
        {
            List<T> list = new List<T>();
            if (ranges == null)
            {
                return list;
            }
            foreach (Range row in ranges)
            {
                list.Add(RowToObject<T>(row));
            }
            return list;
        }

        public T RowToObject<T>(Range row) where T : Persistable, new()
        {
            if (row == null)
            {
                return default;
            }
            T obj = new T();
            obj.SetIndex(row.Cells[1, 1].Value);
            List<PropertyInfo> persistableProperties = GetPersistableProperties(obj);
            int col = 2;
            foreach (PropertyInfo property in persistableProperties)
            {
                Type propertyType = property.PropertyType;
                if (!propertyType.IsPrimitive && propertyType != typeof(string))
                {
                    Persistable foreignObject = Activator.CreateInstance(propertyType) as Persistable;
                    double foreignKey = row.Cells[1, col].Value;
                    foreignObject.SetIndex(row.Cells[1, col].Value);
                    Range foreignRow = ReadTableRow(foreignObject);
                    MethodInfo method = typeof(TableUtility).GetMethod("RowToObject");
                    MethodInfo genericMethod = method.MakeGenericMethod(propertyType);
                    Range[] parameters = new Range[1];
                    parameters[0] = foreignRow;
                    Persistable generatedObject = genericMethod.Invoke(this, parameters) as Persistable;
                    property.SetValue(obj, generatedObject);
                } else
                {
                    property.SetValue(obj, row.Cells[1, col].Value);
                }
                col++;
            }
            return obj;
        }

        public bool DeleteTableRow(Persistable persistable)
        {
            Range result = ReadTableRow(persistable);
            if (result == null)
            {
                return false;
            }
            result.EntireRow.Delete();
            ChangeRowCounter(persistable, true);
            return true;
        }

        public bool UpdateTableRow(Persistable persistable, TableUpdateWrapper update)
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

        public Worksheet CreateWorksheet(string tableName, List<string> tableHeader)
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
            createdSheet.Visible = XlSheetVisibility.xlSheetHidden;
            return createdSheet;
        }

        public Worksheet CreateTableWorksheet(Persistable persistable)
        {
            Worksheet newWorksheet = workbook.Sheets.Add();
            newWorksheet.Name = persistable.GetTableName();
            newWorksheet.Cells[1, 1].Value = "index";
            int colCounter = 2;
            List<PropertyInfo> persistableProperties = GetPersistableProperties(persistable);
            foreach (PropertyInfo property in persistableProperties)
            {
                newWorksheet.Cells[1, colCounter].Value = property.Name;
                colCounter++;
            }
            newWorksheet.Rows[1].AutoFilter();
            newWorksheet.Rows[1].Font.Bold = true;
            newWorksheet.Application.ActiveWindow.SplitRow = 1;
            newWorksheet.Application.ActiveWindow.FreezePanes = true;
            newWorksheet.Visible = XlSheetVisibility.xlSheetHidden;
            return newWorksheet;
        }
    }
}
