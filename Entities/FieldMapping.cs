/*
 * Author: Jan Baumann
 * Version: 01.10.2020
 */

using Watchdog.Persistence;

namespace Watchdog.Entities
{
    /// <summary>
    /// This class represents the field mapping settings for the data input field required by the checks.
    /// 
    /// So for instance, if the duration check needs the the Currency from the input file. You have to 
    /// declare in which column (by storing the cell of the header) the information is found.
    /// </summary>
    public class FieldMapping : Persistable
    {
        /// <summary>
        /// Identifier for the mapping.
        /// </summary>
        [PersistableField(0)]
        public string FieldName { get; set; }

        /// <summary>
        /// Cell, for example 'A2'
        /// </summary>
        [PersistableField(1)]
        public string InputFieldCell { get; set; }

        /// <summary>
        /// Field mapping for type for finding the mappings faster in the table.
        /// </summary>
        [PersistableField(2)]
        public FieldMappingType FieldMappingType { get; set; }

        /// <summary>
        /// Primary key
        /// </summary>
        public double Index { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public FieldMapping()
        {

        }

        /// <summary>
        /// Constructor with direct object intialization.
        /// </summary>
        /// <param name="fieldName">Field name, basically the name of the text box</param>
        /// <param name="inputFielCell">Excel cell, for example 'A2'</param>
        /// <param name="fieldMappingType"><see cref="FieldMappingType"/></param>
        public FieldMapping(string fieldName, string inputFielCell, FieldMappingType fieldMappingType)
        {
            FieldName = fieldName;
            InputFieldCell = inputFielCell;
            FieldMappingType = fieldMappingType;
        }

        /// <summary>
        /// Implementation of <see cref="Persistable"/>
        /// 
        /// Returns the primary key.
        /// </summary>
        /// <returns>Primary key</returns>
        public double GetIndex()
        {
            return Index;
        }

        /// <summary>
        /// Implementation of <see cref="Persistable"/>
        /// 
        /// Returns the short name, needed for subtables.
        /// </summary>
        /// <returns>Short name</returns>
        public string GetShortName()
        {
            return "fm";
        }

        /// <summary>
        /// Implementation of <see cref="Persistable"/>
        /// 
        /// Gets the table name.
        /// </summary>
        /// <returns>Table name</returns>
        public string GetTableName()
        {
            return "wdt_field_mapping";
        }

        /// <summary>
        /// Implementation of <see cref="Persistable"/>
        /// 
        /// Sets the primary key.
        /// </summary>
        /// <param name="index">Primary key</param>
        public void SetIndex(double index)
        {
            Index = index;
        }

        /// <summary>
        /// Gets default object.
        /// </summary>
        /// <returns>Default object</returns>
        public static Persistable GetDefaultValue()
        {
            return new FieldMapping();
        }
    }
}
