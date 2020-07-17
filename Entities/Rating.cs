using Watchdog.Persistence;

namespace Watchdog.Entities
{
    class Rating : Persistable
    {
        private static readonly string tableName = "wdt_ratings";
        public string RatingCode { get; }
        public int RatingNumericValue { get; }

        public Rating(string ratingCode, int ratingNumericValue)
        {
            RatingCode = ratingCode;
            RatingNumericValue = ratingNumericValue;
        }

        public string GetTableName()
        {
            return tableName;
        }
    }
}
