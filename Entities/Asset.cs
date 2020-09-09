using Watchdog.Forms.Util;

namespace Watchdog.Entities
{
    public class Asset
    {
        [TableHeader("ASSET-ID")]
        public int AssetId { get; set; }
        [TableHeader("ISIN")]
        public string Isin { get; set; }
        [TableHeader("NAME", 600)]
        public string Name { get; set; }

        public int Index { get; set; }

        public Asset(int assetId, string isin, string name)
        {
            AssetId = assetId;
            Isin = isin;
            Name = name;
        }
    }
}
