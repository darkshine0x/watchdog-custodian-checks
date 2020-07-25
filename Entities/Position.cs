using Watchdog.Persistence;

namespace Watchdog.Entities
{
    class Position
    {
        public int Id { get; }
        public double Amount { get; }
        public double AccruedInterest { get; }
        public double MarketValue { get; }
        public Asset Asset { get; }
        public Currency PosCurrency { get; }
        public Position[] Legs { get; }

        public Position(int id, double amount, double accruedInterest, double marketValue, Asset asset, Currency posCurrency)
        {
            Id = id;
            Amount = amount;
            AccruedInterest = accruedInterest;
            MarketValue = marketValue;
            Asset = asset;
            PosCurrency = posCurrency;
            Legs = new Position[2];
        }
    }
}
