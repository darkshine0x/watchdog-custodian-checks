namespace Watchdog.Entities
{
    public class AssetAllocationEntry
    {
        private AssetClass AssetClass { get; set; }
        private Currency Currency { get; set; }
        private double Value { get; set; }

        public AssetAllocationEntry() { }
    }
}
