using Watchdog.Persistence;

namespace Watchdog.Entities
{
    class Currency : Persistable
    {
        private static readonly string tableName = "wdt_currencies";
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
    }
}
