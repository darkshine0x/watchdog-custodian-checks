using System.Collections.Generic;
using Watchdog.Forms.Util;
using Watchdog.Persistence;

namespace Watchdog.Entities
{
    public class Currency : Persistable
    {
        public static readonly string tableName = "wdt_currencies";
        public static readonly Currency defaultCurrency = new Currency();
        [PersistableField(0)]
        [TableHeader("ISO-CODE")]
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

        public override bool Equals(object obj)
        {
            return obj is Currency currency &&
                   IsoCode == currency.IsoCode;
        }

        public override int GetHashCode()
        {
            return -565693813 + EqualityComparer<string>.Default.GetHashCode(IsoCode);
        }
    }
}
