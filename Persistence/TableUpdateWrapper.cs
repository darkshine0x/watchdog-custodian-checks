using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchdog.Persistence
{
    class TableUpdateWrapper
    {
        public int Index { get; }
        public string Attribute { get; }
        public string Value { get; }

        public TableUpdateWrapper(int index, string attribute, string value)
        {
            Index = index;
            Attribute = attribute;
            Value = value;
        }
    }
}
