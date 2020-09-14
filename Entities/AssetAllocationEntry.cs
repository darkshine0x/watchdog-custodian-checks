using Watchdog.Persistence;

namespace Watchdog.Entities
{
    public class AssetAllocationEntry : Persistable
    {
        private readonly static AssetAllocationEntry defaultValue = new AssetAllocationEntry();

        [PersistableField(0)]
        public AssetClass AssetClass { get; set; }
        [PersistableField(1)]
        public Currency Currency { get; set; }
        [PersistableField(2)]
        public Fund Fund { get; set; }
        [PersistableField(3)]
        public double StrategicMinValue { get; set; }
        [PersistableField(4)]
        public double StrategicOptValue { get; set; }
        [PersistableField(5)]
        public double StrategicMaxValue { get; set; }
        public double Index { get; set; }

        public AssetAllocationEntry() { }

        public string GetTableName()
        {
            return "wdt_asset_allocation_entries";
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
            return "ae";
        }
    }
}
