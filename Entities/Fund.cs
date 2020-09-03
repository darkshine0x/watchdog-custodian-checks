﻿using System.Collections.Generic;
using Watchdog.Persistence;

namespace Watchdog.Entities
{
    public class Fund : Persistable
    {
        private static readonly string tableName = "wdt_funds";
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

        public Fund(string name, string isin, string custodyAccountNumber, Currency currency)
        {
            Name = name;
            Isin = isin;
            CustodyAccountNumber = custodyAccountNumber;
            Currency = currency;
            Positions = new List<Position>();
        }

        public Fund() 
        {
        }

        public string GetTableName()
        {
            return tableName;
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

        public override bool Equals(object obj)
        {
            return obj is Fund fund &&
                   Index == fund.Index &&
                   Name == fund.Name &&
                   Isin == fund.Isin &&
                   CustodyAccountNumber == fund.CustodyAccountNumber &&
                   EqualityComparer<Currency>.Default.Equals(Currency, fund.Currency);
        }

        public override int GetHashCode()
        {
            int hashCode = 1867242755;
            hashCode = hashCode * -1521134295 + Index.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Isin);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CustodyAccountNumber);
            hashCode = hashCode * -1521134295 + EqualityComparer<Currency>.Default.GetHashCode(Currency);
            return hashCode;
        }
    }
}
