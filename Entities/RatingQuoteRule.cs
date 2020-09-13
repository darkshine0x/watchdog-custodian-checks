using Watchdog.Persistence;

namespace Watchdog.Entities
{
    [JoinedTable("wdt_rating_quote_rules")]
    class RatingQuoteRule : Rule
    {
        [PersistableField(3)]
        public double RatingClass { get; set; }
        [PersistableField(4)]
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
