using System.Collections.Generic;
using Watchdog.Persistence;

namespace Watchdog.Entities
{
    public class Fund : Persistable
    {
        private static readonly string tableName = "wdt_funds";
        private static readonly Dictionary<string, string> tableMapping = new Dictionary<string, string>
        {
            {"name", "Name" },
            {"custody_nr", "CustodyAccountNumber" },
            {"isin", "Isin" },
            {"currency", "Currency" }
        };
        private static readonly Fund defaultFund = new Fund();
        public double Index { get; set; }
        [PersistableField]
        public string Name { get; set; }
        [PersistableField]
        public string Isin { get; set; }
        [PersistableField]
        public string CustodyAccountNumber { get; set; }
        [PersistableField]
        public Currency Currency { get; set; }
        public List<Position> Positions { get; }
        public List<Rule> Rules { get; }

        public Fund(string name, string isin, string custodyAccountNumber, Currency currency)
        {
            Name = name;
            Isin = isin;
            CustodyAccountNumber = custodyAccountNumber;
            Currency = currency;
            Positions = new List<Position>();
            Rules = new List<Rule>();
        }

        public Fund() 
        {
        }

        public string GetTableName()
        {
            return tableName;
        }

        public List<string> GetTableHeader()
        {
            return new List<string>(tableMapping.Keys);
        }

        public static Persistable GetDefaultValue()
        {
            return defaultFund;
        }

        public double GetIndex()
        {
            return Index;
        }

        public void SetIndex(double index)
        {
            Index = index;
        }

        public Dictionary<string, string> GetTableMapping()
        {
            return tableMapping;
        }
    }
}
