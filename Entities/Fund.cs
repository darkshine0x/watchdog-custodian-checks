using System.Collections.Generic;
using Watchdog.Persistence;

namespace Watchdog.Entities
{
    class Fund : Persistable
    {
        private static readonly string tableName = "wdt_funds";
        private static readonly List<string> tableHeader = new List<string>()
        {
            "name",
            "custody_nr",
            "isin",
            "currency"
        };
        private static readonly Fund defaultFund = new Fund();
        public string Name { get; set; }
        public string Isin { get; }
        public string CustodyAccountNumber { get; }
        public Currency Currency { get; }
        public List<Position> Positions { get; }
        public List<Rule> Rules { get; }
        public AssetAllocation AssetAllocation { get; }

        public Fund(string name, string isin, string custodyAccountNumber, Currency currency)
        {
            Name = name;
            Isin = isin;
            CustodyAccountNumber = custodyAccountNumber;
            Currency = currency;
            Positions = new List<Position>();
            Rules = new List<Rule>();
            AssetAllocation = new AssetAllocation();
        }

        private Fund() { }

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
            return defaultFund;
        }
    }
}
