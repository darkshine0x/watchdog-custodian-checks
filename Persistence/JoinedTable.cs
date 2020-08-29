using System;

namespace Watchdog.Persistence
{
    [AttributeUsage(AttributeTargets.Class)]
    class JoinedTable : Attribute
    {
        public string Name { get; set; }

        public JoinedTable(string name)
        {
            Name = name;
        }
    }
}
