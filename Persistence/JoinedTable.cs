/*
 * Author: Jan Baumann
 * Version: 27.09.2020
 */

using System;

namespace Watchdog.Persistence
{
    /// <summary>
    /// Attribute for marking an entity as a joined table.
    /// 
    /// This attribute is used by the base class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    class JoinedTable : Attribute
    {
        /// <summary>
        /// Name of the subclass.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Attribute constructor.
        /// </summary>
        /// <param name="name">Name of the base class</param>
        public JoinedTable(string name)
        {
            Name = name;
        }
    }
}
