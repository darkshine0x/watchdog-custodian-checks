﻿using System.Collections.Generic;
using Watchdog.Persistence;

namespace Watchdog.Entities
{
    public class AssetAllocationEntry : Persistable
    {
        private readonly string tableName = "wdt_asset_allocation_entries";
        private readonly Dictionary<string, string> tableMapping = new Dictionary<string, string>
        {
            {"asset_class_index", "AssetClass" },
            {"currency_index", "Currency" },
            {"min_value", "StrategicMinValue" },
            {"opt_value", "StrategicOptValue" },
            {"max_value", "StrategicMaxValue" },
            {"fund_index", "Fund" }
        };
        private readonly static AssetAllocationEntry defaultValue = new AssetAllocationEntry();
        [PersistableField]
        public AssetClass AssetClass { get; set; }
        [PersistableField]
        public Currency Currency { get; set; }
        [PersistableField]
        public Fund Fund { get; set; }
        [PersistableField]
        public double StrategicMinValue { get; set; }
        [PersistableField]
        public double StrategicOptValue { get; set; }
        [PersistableField]
        public double StrategicMaxValue { get; set; }
        public double Index { get; set; }

        public AssetAllocationEntry() { }

        public string GetTableName()
        {
            return tableName;
        }

        public List<string> GetTableHeader()
        {
            return new List<string>(tableMapping.Keys);
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

        public static Persistable GetDefaultValue()
        {
            return defaultValue;
        }
    }
}
