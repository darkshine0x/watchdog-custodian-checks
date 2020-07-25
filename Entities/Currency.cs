using System.Collections.Generic;
using Watchdog.Persistence;

namespace Watchdog.Entities
{
    class Currency : Persistable
    {
        private static string tableName = "wdt_currency";
        public string IsoCode { get; }
        public int NumericValue { get; }

        public Currency(string isoCode, int numericValue)
        {
            IsoCode = isoCode;
            NumericValue = numericValue;
        }

        public string GetTableName()
        {
            return tableName;
        }

        public List<string> GetTableHeader()
        {
            return null;
        }
    }
}
