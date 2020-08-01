using System.Collections.Generic;
using Watchdog.Persistence;

namespace Watchdog.Entities
{
    class Currency : Persistable
    {
        public static readonly string tableName = "wdt_currencies";
        public static readonly List<string> tableHeader = new List<string>()
        {
            "iso_code"
        };
        public static readonly Currency defaultCurrency = new Currency();
        public string IsoCode { get; set; }
        public double Index { get; set; }

        public Currency()
        {

        }

        public Currency(string isoCode)
        {
            IsoCode = isoCode;
        }

        public override string ToString()
        {
            return IsoCode;
        }

        public string GetTableName()
        {
            return tableName;
        }

        public List<string> GetTableHeader()
        {
            return tableHeader;
        }

        public static Persistable GetDefaultValue()
        {
            return defaultCurrency;
        }

        public double GetIndex()
        {
            return Index;
        }

        public void SetIndex(double index)
        {
            Index = index;
        }
    }
}
