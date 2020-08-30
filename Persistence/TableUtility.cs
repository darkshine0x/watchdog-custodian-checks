using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Watchdog.Persistence
{
    public class TableUtility
    {
        private readonly string sequenceTableName = "wdt_sequence";
        private readonly Workbook workbook;

        public TableUtility() : this(Globals.WatchdogAddIn.Application.ActiveWorkbook)
        {

        }

        public TableUtility(Workbook workbook)
        {
            this.workbook = workbook;
        }

        public void CreateTable(Persistable persistable)
        {
            string joinedTable = IsJoinedTable(persistable);
            Worksheet ws;
            if (joinedTable != "")
            {
                ws = FindWorksheet(joinedTable);
            }
            else
            {
                ws = FindWorksheet(persistable.GetTableName());
            }
            if (ws != null)
            {
                return;
            }
            CreateTableWorksheet(persistable);
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

        private  int InsertRowCounter(string tableName)
        {
            Worksheet ws = FindWorksheet(sequenceTableName);
            if (ws == null)
            {
                ws = CreateSequenceTable();
            }
            int emptyColumn = FindFirstEmtpyColumn(sequenceTableName);
            ws.Cells[1, emptyColumn].Value = tableName;
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

        private int FindOrCreateRowCounterColumn(string tableName)
        {
            Worksheet ws = FindWorksheet(sequenceTableName);
            if (ws == null)
            {
                CreateSequenceTable();
                return InsertRowCounter(tableName);
            }
            int c = 1;
            while (true)
            {
                if (tableName.Equals(ws.Cells[1, c].Value))
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

        private  double ChangeRowCounter(string tableName, bool decrement)
        {
            int column = FindOrCreateRowCounterColumn(tableName);
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

        public double InsertTableRow(Persistable persistable)
        {
            string tableName = IsJoinedTable(persistable);
            if (tableName == "")
            {
                tableName = persistable.GetTableName();
            }
            double row;
            double sequence = persistable.GetIndex();
            Worksheet ws = FindWorksheet(tableName);
            if (sequence == 0)
            {
                row = ChangeRowCounter(tableName, false);
                sequence = IncrementSequence();
                persistable.SetIndex(sequence);
            }
            else
            {
                row = ReadTableRow(persistable).Row;
            }
            ws.Cells[row, 1].Value = sequence;
            int colCounter = 2;
            foreach (PropertyInfo property in GetPropertiesByAttribute(persistable, typeof(PersistableField)))
            {
                Type propertyType = property.PropertyType;
                if (!propertyType.IsPrimitive && propertyType != typeof(string) && !propertyType.IsEnum) 
                {
                    MultiValue multiValueProperty = property.GetCustomAttribute<MultiValue>();
                    if (multiValueProperty != null)
                    {
                        var items = property.GetValue(persistable);
                        string content = "";
                        foreach (Persistable item in items as IEnumerable<Persistable>)
                        {
                            content += item.GetIndex() + ";";
                        }
                        ws.Cells[row, colCounter].Value = content;
                    }
                    else
                    {
                        Persistable nestedObject = property.GetValue(persistable) as Persistable;
                        ws.Cells[row, colCounter].Value = nestedObject.GetIndex();
                    }
                }
                else
                {
                    ws.Cells[row, colCounter].Value = property.GetValue(persistable);
                }
                colCounter++;
            }
            return sequence;
        }

        private string IsJoinedTable(Persistable persistable)
        {
            if (Attribute.GetCustomAttribute(persistable.GetType(), typeof(JoinedTable), false) is JoinedTable attribute)
            {
                return attribute.Name;
            }
            return "";
        }

        private Type[] IsJoinedTableBaseClass(Type type)
        {
            if (Attribute.GetCustomAttribute(type, typeof(JoinedTableBase), false) is JoinedTableBase attribute)
            {
                return attribute.DerivedTypes;
            }
            return new Type[0];
        } 

        private List<PropertyInfo> GetPropertiesByAttribute(Persistable persistable, Type attributeType)
        {
            PropertyInfo[] properties = persistable.GetType().GetProperties();
            List<PropertyInfo> multiValueProperties = new List<PropertyInfo>();
            foreach (PropertyInfo property in properties)
            {
                if (property.GetCustomAttributes(attributeType, false).Length != 0)
                {
                    multiValueProperties.Add(property);
                }
            }
            return multiValueProperties;
        }

        private Persistable GetDefaultObject(Type type)
        {
            Persistable persistable = Activator.CreateInstance(type) as Persistable;
            return persistable;
        }

        public List<Range> ReadAllRows(Persistable persistable)
        {
            List<Range> searchResult = new List<Range>();
            Type[] derivedTypes = IsJoinedTableBaseClass(persistable.GetType());
            if (derivedTypes.Length != 0)
            {
                foreach (Type derivedType in derivedTypes)
                {
                    List<Range> subList = ReadAllRows(GetDefaultObject(derivedType));
                    searchResult.AddRange(subList);
                }
            }

            string joinedTable = IsJoinedTable(persistable);
            Worksheet worksheet;
            if (joinedTable != "")
            {
                worksheet = FindWorksheet(joinedTable);
            } 
            else
            {
                worksheet = FindWorksheet(persistable.GetTableName());
            }
            if (worksheet == null)
            {
                return searchResult;
            }
            Range rows = worksheet.UsedRange.Rows;
            for (int index = 2; index < rows.Count + 1; index++)
            {
                searchResult.Add(rows[index]);
            }
            return searchResult;
        }

        public  List<Range> ReadTableRow(Persistable persistable, Dictionary<string, string> searchParameters, QueryOperator queryOperator)
        {
            List<Range> searchResult = new List<Range>();
            Worksheet worksheet;
            string joinedTable = IsJoinedTable(persistable);
            if (joinedTable != "")
            {
                worksheet = FindWorksheet(joinedTable);
            }
            else
            {
                worksheet = FindWorksheet(persistable.GetTableName());
            }
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
            string joinedTable = IsJoinedTable(persistable);
            Worksheet worksheet;
            if (joinedTable != "")
            {
                worksheet = FindWorksheet(joinedTable);
            }
            else
            {
                worksheet = FindWorksheet(persistable.GetTableName());
            }
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

        private Type GetTypeByTableName(Type[] types, string tableName)
        {
            foreach (Type type in types)
            {
                Persistable persistable = Activator.CreateInstance(type) as Persistable;
                string objTableName = IsJoinedTable(persistable);
                if (objTableName.Equals(tableName))
                {
                    return type;
                }
            }
            return null;
        }

        public T RowToObject<T>(Range row) where T : Persistable, new()
        {
            if (row == null)
            {
                return default;
            }
            T obj = new T();
            Type[] derivedTypes = IsJoinedTableBaseClass(obj.GetType());
            if (derivedTypes.Length != 0)
            {
                string tableName = row.Worksheet.Name;
                Type type = GetTypeByTableName(derivedTypes, tableName);
                MethodInfo method = typeof(TableUtility).GetMethod("RowToObject");
                MethodInfo genericMethod = method.MakeGenericMethod(type);
                Range[] parameters = new Range[1];
                parameters[0] = row;
                T generatedObject = (T) genericMethod.Invoke(this, parameters);
                return generatedObject;
            }
            obj.SetIndex(row.Cells[1, 1].Value);
            List<PropertyInfo> persistableProperties = GetPropertiesByAttribute(obj, typeof(PersistableField));
            int col = 2;
            foreach (PropertyInfo property in persistableProperties)
            {
                Type propertyType = property.PropertyType;
                if (!propertyType.IsPrimitive && propertyType != typeof(string))
                {
                    if (propertyType.IsEnum)
                    {
                        double enumKey = row.Cells[1, col].Value;
                        property.SetValue(obj, Enum.Parse(propertyType, enumKey.ToString()));
                        col++;
                        continue;
                    }
                    
                    Range[] parameters = new Range[1];

                    MultiValue multiValueAttr = property.GetCustomAttribute<MultiValue>(true);
                    if (multiValueAttr != null)
                    {
                        Type genericType = property.PropertyType.GetGenericArguments()[0];
                        Type propertyTypeWithoutGenericType = propertyType.GetGenericTypeDefinition();
                        Type listType = propertyTypeWithoutGenericType.MakeGenericType(genericType);
                        object propertyList = Activator.CreateInstance(listType);
                        string content = row.Cells[1, col].Value;
                        string[] splitContent = content.Split(';');
                        foreach (string stringIndex in splitContent)
                        {
                            if (string.IsNullOrEmpty(stringIndex))
                            {
                                break;
                            }
                            double.TryParse(stringIndex, out double index);
                            Persistable searchObject = GetDefaultObject(genericType);
                            searchObject.SetIndex(index);
                            parameters[0] = ReadTableRow(searchObject);
                            MethodInfo recMethod = typeof(TableUtility).GetMethod("RowToObject");
                            MethodInfo recGenericMethod = recMethod.MakeGenericMethod(genericType);
                            Persistable generatedListItem = recGenericMethod.Invoke(this, parameters) as Persistable;
                            ((IList) propertyList).Add(generatedListItem);
                        }
                        property.SetValue(obj, propertyList);
                        continue;
                    }
                    MethodInfo method = typeof(TableUtility).GetMethod("RowToObject");
                    MethodInfo genericMethod = method.MakeGenericMethod(propertyType);
                    Persistable foreignObject = Activator.CreateInstance(propertyType) as Persistable;
                    double foreignKey = row.Cells[1, col].Value;
                    foreignObject.SetIndex(row.Cells[1, col].Value);
                    Range foreignRow = ReadTableRow(foreignObject);
                    parameters[0] = foreignRow;
                    Persistable generatedObject = genericMethod.Invoke(this, parameters) as Persistable;
                    property.SetValue(obj, generatedObject);
                } 
                else
                {
                    property.SetValue(obj, row.Cells[1, col].Value);
                }
                col++;
            }
            return obj;
        }

        public bool DeleteTableRow(Persistable persistable)
        {
            string joinedTable = IsJoinedTable(persistable);
            if (joinedTable != "")
            {
                ChangeRowCounter(joinedTable, true);
            }
            else
            {
                ChangeRowCounter(persistable.GetTableName(), true);
            }
            Range result = ReadTableRow(persistable);
            if (result == null)
            {
                return false;
            }
            result.EntireRow.Delete();
            return true;
        }

        public bool UpdateTableRow(Persistable persistable, TableUpdateWrapper update)
        {
            Dictionary<string, string> searchParameters = new Dictionary<string, string>()
            {
                {"index", update.Index.ToString() }
            };
            List<Range> searchResult = ReadTableRow(persistable, searchParameters, QueryOperator.OR);
            if (!searchResult.Any())
            {
                return false;
            }
            List<PropertyInfo> persistableProperty = GetPropertiesByAttribute(persistable, typeof(PersistableField));
            List<string> columns = persistableProperty.ConvertAll(new Converter<PropertyInfo, string>(x => {return x.Name; }));
            int columnNumber = columns.IndexOf(update.Attribute);
            searchResult[0].Cells[1, columnNumber + 2] = update.Value;
            return true;
        }

        public bool MergeTableRow(Persistable persistable)
        {
            Range searchResult = ReadTableRow(persistable);
            if (searchResult == null)
            {
                return false;
            }
            InsertTableRow(persistable);
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
            string joinedTable = IsJoinedTable(persistable);
            if (joinedTable != "")
            {
                newWorksheet.Name = joinedTable;
                InsertRowCounter(joinedTable);
            }
            else
            {
                newWorksheet.Name = persistable.GetTableName();
                InsertRowCounter(persistable.GetTableName());
            }
            newWorksheet.Cells[1, 1].Value = "index";
            int colCounter = 2;
            List<PropertyInfo> persistableProperties = GetPropertiesByAttribute(persistable, typeof(PersistableField));
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
