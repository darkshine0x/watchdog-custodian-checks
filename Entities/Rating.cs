namespace Watchdog.Entities
{
    class Rating
    {
        public string RatingCode { get; }
        public int RatingNumericValue { get; }

        public Rating(string ratingCode, int ratingNumericValue)
        {
            RatingCode = ratingCode;
            RatingNumericValue = ratingNumericValue;
        }
    }
}
