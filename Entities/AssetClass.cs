using Watchdog.Forms.Util;
using Watchdog.Persistence;

namespace Watchdog.Entities
{
    public class AssetClass : Persistable
    {
        private static readonly string tableName = "wdt_asset_classes";
        private static readonly AssetClass defaultAssetClass = new AssetClass();

        [PersistableField]
        [TableHeader("ASSET-KLASSE", 400)]
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
    }
}
