using System.Collections.Generic;

namespace Watchdog.Entities
{
    class AssetAllocation
    {
        public Dictionary<AssetClass, double> AssetClasses { get; }
        public Dictionary<Currency, double> Currencies { get; }

        public AssetAllocation(Dictionary<AssetClass, double> assetClasses = null, Dictionary<Currency, double> currencies = null)
        {
            if (assetClasses != null)
            {
                AssetClasses = assetClasses;
            } else
            {
                AssetClasses = new Dictionary<AssetClass, double>();
            }

            if (currencies != null)
            {
                Currencies = currencies;
            } else
            {
                Currencies = new Dictionary<Currency, double>();
            }
        }
    }
}
