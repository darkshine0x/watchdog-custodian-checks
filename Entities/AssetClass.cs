using Watchdog.Persistence;

namespace Watchdog.Entities
{
    class AssetClass : Persistable
    {
        private static readonly string tableName = "wdt_asset_classes";
        public string Name { get; }
        public int NumericValue { get; }

        public AssetClass(string name, int numericValue)
        {
            Name = name;
            NumericValue = numericValue;
        }

        public string GetTableName()
        {
            return tableName;
        }
    }
}
