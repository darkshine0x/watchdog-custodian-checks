namespace Watchdog.Entities
{
    class AssetClass
    {
        public string Name { get; }
        public int NumericValue { get; }

        public AssetClass(string name, int numericValue)
        {
            Name = name;
            NumericValue = numericValue;
        }
    }
}
