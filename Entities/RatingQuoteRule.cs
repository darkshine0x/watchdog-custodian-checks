using Watchdog.Persistence;

namespace Watchdog.Entities
{
    [JoinedTable("wdt_rating_quote_rules")]
    class RatingQuoteRule : Rule
    {
        public double RatingClass { get; set; }
        public double MaxRatio { get; set; }

        public RatingQuoteRule()
        {

        }

        public RatingQuoteRule(double ratingClass, double maxRatio, RuleKind ruleKind, string name) : base(ruleKind, name)
        {
            RatingClass = ratingClass;
            MaxRatio = maxRatio;
        }
    }
}
