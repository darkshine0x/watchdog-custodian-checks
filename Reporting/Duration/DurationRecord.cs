/*
 * Author: Jan Baumann
 * Version: 26.09.2020
 */

using Watchdog.Forms.Util;
using Watchdog.Persistence;

namespace Watchdog.Reporting.Duration
{
    /// <summary>
    /// Represents a target duration record.
    /// </summary>
    public class DurationRecord : Persistable
    {
        /// <summary>
        /// Currency to which the target duration applies.
        /// 
        /// This field does not make use of the Currency class explicitly. The reason is, that currencies can be summarized.
        /// For example could GBP, NOK, SEK and DKK be summarized to Non-Euro.
        /// </summary>
        [TableHeader("WÄHRUNG")]
        [PersistableField(0)]
        public string Currency { get; set; }

        /// <summary>
        /// Target duration value for the specified currency.
        /// </summary>
        [TableHeader("ZIEL-DURATION")]
        [PersistableField(1)]
        public double TargetDuration { get; set; }

        /// <summary>
        /// Primary key
        /// </summary>
        public double Index { get; set; }

        /// <summary>
        /// Implementation of <see cref="Persistable"/>
        /// 
        /// Gets the primary key.
        /// </summary>
        /// <returns>Primary key</returns>
        public double GetIndex()
        {
            return Index;
        }

        /// <summary>
        /// Implementation of <see cref="Persistable"/>
        /// 
        /// Returns the short name of the table.
        /// </summary>
        /// <returns>Short name</returns>
        public string GetShortName()
        {
            return "dr";
        }

        /// <summary>
        /// Implementation of <see cref="Persistable"/>
        /// 
        /// Returns the name of the table in which the objects are persisted.
        /// </summary>
        /// <returns>Table name</returns>
        public string GetTableName()
        {
            return "wdt_duration_record";
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
        /// Gets a default instance with no values set.
        /// </summary>
        /// <returns>Default instance</returns>
        public static Persistable GetDefaultValue()
        {
            return new DurationRecord();
        }
    }
}
