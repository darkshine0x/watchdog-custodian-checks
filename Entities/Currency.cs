using System.Collections.Generic;
using Watchdog.Persistence;

namespace Watchdog.Entities
{
    public class Currency : Persistable
    {
        public static readonly string tableName = "wdt_currencies";
        public static readonly Currency defaultCurrency = new Currency();
        [PersistableField]
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
