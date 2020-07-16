namespace Watchdog.Entities
{
    class Currency
    {
        public string IsoCode { get; }
        public int NumericValue { get; }

        public Currency(string isoCode, int numericValue)
        {
            IsoCode = isoCode;
            NumericValue = numericValue;
        }
    }
}
