using Watchdog.Forms.Util;
using Watchdog.Persistence;

namespace Watchdog.Entities
{
    public class AssetKind : Persistable
    {
        private static readonly AssetKind defaultValue = new AssetKind();
        [PersistableField(0)]
        [TableHeader("BESCHREIBUNG", 600)]
        public string Description { get; set; }
        public double Index { get; set; }

        public AssetKind()
        {

        }

        public AssetKind(string description)
        {
            Description = description;
        }

        public string GetTableName()
        {
            return "wdt_asset_kinds";
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

        public string GetShortName()
        {
            return "ak";
        }
    }
}
