using Watchdog.Forms.Util;
using Watchdog.Persistence;

namespace Watchdog.Entities
{
    public class Asset : Persistable
    {
        private static readonly string tableName = "wdt_assets";
        private static readonly Persistable defaultValue = new Asset();

        [PersistableField(0)]
        [TableHeader("ASSET-ID")]
        public double AssetId { get; set; }
        [PersistableField(1)]
        [TableHeader("ISIN")]
        public string Isin { get; set; }
        [PersistableField(2)]
        [TableHeader("NAME", 600)]
        public string Name { get; set; }

        public double Index { get; set; }

        public Asset()
        {

        }

        public Asset(double assetId, string isin, string name)
        {
            AssetId = assetId;
            Isin = isin;
            Name = name;
        }

        public string GetTableName()
        {
            return tableName;
        }

        public double GetIndex()
        {
            return Index;
        }

        public void SetIndex(double index)
        {
            Index = index;
        }

        public static Persistable GetDefaultValue()
        {
            return defaultValue;
        }
    }
}
