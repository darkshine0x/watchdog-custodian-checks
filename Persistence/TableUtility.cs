/*
 * Author: Jan Baumann
 * Version: 11.09.2020
 */

using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Watchdog.Persistence
{
    /// <summary>
    /// This class contains all the persistence functionality.
    /// 
    /// By default, the current active workbook you're working on will be used
    /// for applying the persistence functions.
    /// 
    /// There is an in-built object mapper. Important: The corresponding classes
    /// have to be implement the <see cref="Persistable"/> interface. All properties
    /// that have to be persisted need be marked correctly and need to have a getter
    /// and setter. Also they need be marked with the correct attribute. For lists 
    /// you need to use the <see cref="MultiValue"/> attribute. For properties with a 
    /// single value, use the <see cref="PersistableField"/> property.
    /// 
    /// There are a few limitations. Generic classes cannot be handled by the object 
    /// mapper at the moment. Dictionaries also lead to unexpected errors. If an operation 
    /// fails, there will be no rollback.
    /// </summary>
    public class TableUtility
    {
        private readonly string sequenceTableName = "wdt_sequence";
        private readonly Workbook workbook;

        /// <summary>
        /// Default constructor, which selects the current active workbook.
        /// </summary>
        public TableUtility() : this(Globals.WatchdogAddIn.Application.ActiveWorkbook)
        {

        }

        /// <summary>
        /// Default with customizable workbook.
        /// </summary>
        /// <param name="workbook">Workbook, in which the operations should take place</param>
        public TableUtility(Workbook workbook)
        {
            this.workbook = workbook;
        }

        /// <summary>
        /// Checks if there is already an exisiting table (<see cref="Worksheet"/>) according to the object, which needs to persisted.
        /// If not, a table will be created.
        /// </summary>
        /// <param name="persistable"><see cref="Persistable"/> default object</param>
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

        /// <summary>
        /// Creates a sequence table which holds the index counter and the row counters for the data tables.
        /// </summary>
        /// <returns>Sequence <see cref="Worksheet"/></returns>
        private Worksheet CreateSequenceTable()
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

        /// <summary>
        /// Inserts a new row counter column in the sequence table.
        /// </summary>
        /// <param name="tableName">Table name</param>
        /// <returns></returns>
        private int InsertRowCounter(string tableName)
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

        /// <summary>
        /// Finds the first emtpy column in a worksheet.
        /// </summary>
        /// <param name="tableName">Table name</param>
        /// <returns>Column index</returns>
        private int FindFirstEmtpyColumn(string tableName)
        {
            Worksheet ws = FindWorksheet(tableName);
            return ws.UsedRange.Rows[1].Cells.Count + 1;
        }

        /// <summary>
        /// Finds certain column by it's name (value in the first row).
        /// The column name is usually the property name.
        /// </summary>
        /// <param name="worksheet"><see cref="Worksheet"/></param>
        /// <param name="columnName">Column name</param>
        /// <returns>Column index</returns>
        private int FindColumn(Worksheet worksheet, string columnName)
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

        /// <summary>
        /// Finds the row counter, if there isn't any, a new will be created.
        /// </summary>
        /// <param name="tableName">Table name</param>
        /// <returns>Row index</returns>
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

        /// <summary>
        /// Increments the the sequence by one.
        /// </summary>
        /// <returns>Incremented sequence value</returns>
        private double IncrementSequence()
        {
            Worksheet sequenceTable = CreateSequenceTable();
            double sequence = sequenceTable.Cells[2, 2].Value + 1;
            CreateSequenceTable().Cells[2, 2].Value = sequence;
            return sequence;
        }

        /// <summary>
        /// Increments or decrements the corresponding row counter by one.
        /// </summary>
        /// <param name="tableName">Table name</param>
        /// <param name="decrement"><code>true</code> if it should decrement, else <code>false</code></param>
        /// <returns></returns>
        private double ChangeRowCounter(string tableName, bool decrement)
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

        /// <summary>
        /// Finds a worksheet by name.
        /// </summary>
        /// <param name="name">Worksheet name</param>
        /// <returns><see cref="Worksheet"/></returns>
        public Worksheet FindWorksheet(string name)
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

        /// <summary>
        /// Persists a new object.
        /// The index will be set as well.
        /// </summary>
        /// <param name="persistable">Object to be persisted</param>
        /// <returns>Index of the object</returns>
        public double InsertTableRow(Persistable persistable)
        {
            string tableName = IsJoinedTable(persistable);
            if (tableName == "")
            {
                tableName = persistable.GetTableName();
            }
            double row = ChangeRowCounter(tableName, false);
            double sequence = IncrementSequence();
            persistable.SetIndex(sequence);
            Worksheet ws = FindWorksheet(tableName);
            ws.Cells[row, 1].Value = sequence;
            Range rowToInsert = ws.Rows[row];
            ReplaceRange(persistable, rowToInsert);
            return sequence;
        }

        /// <summary>
        /// Refreshes an table row with the actual object data.
        /// </summary>
        /// <param name="persistable">Persisted object</param>
        /// <param name="row">Row with the new data</param>
        /// <returns><code>True</code> if update is successful, else <code>false</code></returns>
        private bool ReplaceRange(Persistable persistable, Range row)
        {
            string tableName = IsJoinedTable(persistable);
            if (tableName == "")
            {
                tableName = persistable.GetTableName();
            }
            if (row.Worksheet.Name != tableName)
            {
                return false;
            }
            int colCounter = 2;
            List<PropertyInfo> properties = SortPersistableFieldList(GetPropertiesByAttribute(persistable, typeof(PersistableField)));
            foreach (PropertyInfo property in properties)
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
                            if (item.GetIndex() != 0)
                            {
                                content += item.GetIndex() + ";";
                            }
                        }
                        row.Cells[1, colCounter].Value = content;
                    }
                    else
                    {
                        Persistable nestedObject = property.GetValue(persistable) as Persistable;
                        row.Cells[1, colCounter].Value = nestedObject.GetIndex();
                    }
                }
                else
                {
                    row.Cells[1, colCounter].Value = property.GetValue(persistable);
                }
                colCounter++;
            }
            return true;
        }

        /// <summary>
        /// Checks if the class of the passed object is a subclass.
        /// </summary>
        /// <param name="persistable"><see cref="Persistable"/> default object</param>
        /// <returns>If subclass, then it returns the table name, else an empty string</returns>
        private string IsJoinedTable(Persistable persistable)
        {
            if (Attribute.GetCustomAttribute(persistable.GetType(), typeof(JoinedTable), false) is JoinedTable attribute)
            {
                if (persistable.GetType().IsGenericType)
                {
                    return persistable.GetTableName();
                }
                return attribute.Name;
            }
            return "";
        }

        /// <summary>
        /// Checks if the class of the passed object is a base class
        /// </summary>
        /// <param name="type">Type to check</param>
        /// <returns>Array of the derived types</returns>
        private Type[] JoinedTableBaseClassGetSubClasses(Type type)
        {
            if (Attribute.GetCustomAttribute(type, typeof(JoinedTableBase), false) is JoinedTableBase attribute)
            {
                return attribute.DerivedTypes;
            }
            return new Type[0];
        }

        private bool IsJoinedTableBaseClass(Type type)
        {
            if (Attribute.GetCustomAttribute(type, typeof(JoinedTableBase), false) is JoinedTableBase attribute)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets a list of properties, which are marked with the specified attribute.
        /// </summary>
        /// <param name="persistable">Object to check (can be default object)</param>
        /// <param name="attributeType">Type of the marking attribute</param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates an instance of the specified type.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Object of type <see cref="Persistable"/></returns>
        private Persistable GetDefaultObject(Type type)
        {
            Persistable persistable = Activator.CreateInstance(type) as Persistable;
            return persistable;
        }

        /// <summary>
        /// Gets all the rows of a certain table.
        /// If the type is a base class, the tables of the subclasses will also
        /// be taken into account.
        /// </summary>
        /// <param name="persistable"><see cref="Persistable"/> object</param>
        /// <returns>List of all ranges</returns>
        public List<Range> ReadAllRows(Persistable persistable)
        {
            List<Range> searchResult = new List<Range>();
            bool isJoinedTableBaseClass = IsJoinedTableBaseClass(persistable.GetType());
            if (isJoinedTableBaseClass)
            {
                Type[] derivedTypes = JoinedTableBaseClassGetSubClasses(persistable.GetType());
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

        /// <summary>
        /// Searches a table row with search parameters.
        /// The search parameters have to passed with a dictionary. The keys are the 
        /// column names and the values are the search parameters.
        /// </summary>
        /// <param name="persistable"><see cref="Persistable"/>object (to get to the correct table)</param>
        /// <param name="searchParameters">Search parameters</param>
        /// <param name="queryOperator"><see cref="QueryOperator"/></param>
        /// <returns>List with found rows</returns>
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

        /// <summary>
        /// Gets the table row of the specified object based on its index.
        /// </summary>
        /// <param name="persistable"><see cref="Persistable"/> object</param>
        /// <returns>Table row</returns>
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
            int rowIndex = BinarySearchTable(persistable);
            if (rowIndex < 0)
            {
                return null;
            }
            return worksheet.UsedRange.Rows[rowIndex];
        }

        /// <summary>
        /// Binary search implementation for finding the table row based on the object index.
        /// </summary>
        /// <param name="persistable"></param>
        /// <returns></returns>
        private int BinarySearchTable(Persistable persistable)
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

            Range firstColumn = worksheet.UsedRange.Columns[1];
            int left = 2, right = firstColumn.Cells.Count, mid = left + (right - left) / 2;
            double target = persistable.GetIndex();
            while (left <= right)
            {
                double cellValue = worksheet.Cells[mid, 1].Value;
                if (target == cellValue)
                {
                    return mid;
                }
                if (target < cellValue)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return -1;
        }

        /// <summary>
        /// Maps multiple table rows to objects.
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="ranges">Table rows</param>
        /// <returns>Object list</returns>
        public List<T> ConvertRangesToObjects<T>(List<Range> ranges) where T : Persistable, new()
        {
            List<T> list = new List<T>();
            if (ranges == null || ranges.Count == 0)
            {
                return list;
            }
            foreach (Range row in ranges)
            {
                list.Add(RowToObject<T>(row));
            }
            return list;
        }

        /// <summary>
        /// Gets object type based on the table name.
        /// The table names will be cross checked with a subset of types.
        /// </summary>
        /// <param name="types">Types for cross check</param>
        /// <param name="tableName">Table name</param>
        /// <returns>Found type</returns>
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

        /// <summary>
        /// Converts a single row to an object.
        /// 
        /// The method iterates over all marked properties. Is the property itself an 
        /// object again, the object mapping is processed recursively.
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="row">Table row</param>
        /// <returns>Object</returns>
        public T RowToObject<T>(Range row) where T : Persistable, new()
        {
            if (row == null)
            {
                return default;
            }
            T obj = new T();
            bool isJoinedTableBaseClass = IsJoinedTableBaseClass(obj.GetType());
            if (isJoinedTableBaseClass)
            {
                Type[] derivedTypes = JoinedTableBaseClassGetSubClasses(obj.GetType());
                string tableName = row.Worksheet.Name;
                Type type = GetTypeByTableName(derivedTypes, tableName);
                if (type != null)
                {
                    MethodInfo method = typeof(TableUtility).GetMethod("RowToObject");
                    MethodInfo genericMethod = method.MakeGenericMethod(type);
                    Range[] parameters = new Range[1];
                    parameters[0] = row;
                    T generatedObject = (T)genericMethod.Invoke(this, parameters);
                    return generatedObject;
                }
            }

            bool isNaN = double.IsNaN(row.Cells[1, 1].Value);
            if (!isNaN)
            {
                obj.SetIndex(row.Cells[1, 1].Value);
            }
            else
            {
                return default;
            }
            List<PropertyInfo> persistableProperties = SortPersistableFieldList(GetPropertiesByAttribute(obj, typeof(PersistableField)));
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
                        if (content != null)
                        {
                            string[] splitContent = content.Split(';');
                            for (int arrayIndex = 0; arrayIndex < splitContent.Length; arrayIndex++)
                            {
                                string stringIndex = splitContent[arrayIndex];
                                if (string.IsNullOrEmpty(stringIndex))
                                {
                                    continue;
                                }
                                double.TryParse(splitContent[arrayIndex], out double index);
                                Persistable searchObject = GetDefaultObject(genericType);
                                searchObject.SetIndex(index);
                                Range foundRow = ReadTableRow(searchObject);
                                if (foundRow == null || double.IsNaN(foundRow.Cells[1, 1].Value))
                                {
                                    splitContent[arrayIndex] = string.Empty;
                                    continue;
                                }
                                parameters[0] = ReadTableRow(searchObject);
                                MethodInfo recMethod = typeof(TableUtility).GetMethod("RowToObject");
                                MethodInfo recGenericMethod = recMethod.MakeGenericMethod(genericType);
                                Persistable generatedListItem = recGenericMethod.Invoke(this, parameters) as Persistable;
                                ((IList)propertyList).Add(generatedListItem);
                            }
                            content = string.Join(";", splitContent);
                            content += ";";
                            row.Cells[1, col].Value = content;
                        }
                        property.SetValue(obj, propertyList);
                        col++;
                        continue;
                    }
                    MethodInfo method = typeof(TableUtility).GetMethod("RowToObject");
                    MethodInfo genericMethod = method.MakeGenericMethod(propertyType);
                    Persistable foreignObject = Activator.CreateInstance(propertyType) as Persistable;
                    double foreignKey = row.Cells[1, col].Value;
                    foreignObject.SetIndex(row.Cells[1, col].Value);
                    Range foreignRow = ReadTableRow(foreignObject);
                    if (foreignRow == null || double.IsNaN(foreignRow.Cells[1, 1].Value))
                    {
                        break;
                    }
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

        /// <summary>
        /// Deletes the corresponding table row of the passed object.
        /// </summary>
        /// <param name="persistable"><see cref="Persistable"/> object</param>
        /// <returns></returns>
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

        /// <summary>
        /// Updates an existing row with the new object data.
        /// </summary>
        /// <param name="persistable"><see cref="Persistable"/> object with updated data</param>
        /// <returns><code>True</code> if merge is successful, else <code>false</code></returns>
        public bool MergeTableRow(Persistable persistable)
        {
            Range searchResult = ReadTableRow(persistable);
            if (searchResult == null)
            {
                return false;
            }
            else
            {
                ReplaceRange(persistable, searchResult);
                return true;
            }
        }

        /// <summary>
        /// Creates a new worksheet with a custom header and table name.
        /// </summary>
        /// <param name="tableName">Table name</param>
        /// <param name="tableHeader">Column headers</param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates a new worksheet based on the specified table namen given by the object.
        /// For each marked property a column header will be inserted.
        /// </summary>
        /// <param name="persistable"><see cref="Persistable"/> default object</param>
        /// <returns>New <see cref="Worksheet"/></returns>
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
            List<PropertyInfo> persistableProperties = SortPersistableFieldList(GetPropertiesByAttribute(persistable, typeof(PersistableField)));
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

        /// <summary>
        /// Sort properties marked with the <see cref="PersistableField"/> attribute by its order number.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Sorted list</returns>
        private List<PropertyInfo> SortPersistableFieldList(List<PropertyInfo> list)
        {
            return list.OrderBy(property => property.GetCustomAttribute<PersistableField>(true).Order).ToList();
        }
    }
}
