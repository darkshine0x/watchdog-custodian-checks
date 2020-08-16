using System.Collections.Generic;
using Watchdog.Persistence;

namespace Watchdog.Entities
{
    public class AssetClass : Persistable
    {
        private static readonly string tableName = "wdt_asset_classes";
        private static readonly Dictionary<string, string> tableMapping = new Dictionary<string, string>
        {
            { "name", "Name"}
        };
        private static readonly AssetClass defaultAssetClass = new AssetClass();

        public string Name { get; set; }
        public double Index { get; set; }

        public AssetClass()
        {

        }

        public AssetClass(string name)
        {
            Name = name;
        }

        public string GetTableName()
        {
            return tableName;
        }

        public List<string> GetTableHeader()
        {
            return new List<string>(tableMapping.Keys);
        }

        public override string ToString()
        {
            return Name;
        }

        public static Persistable GetDefaultValue()
        {
            return defaultAssetClass;
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
