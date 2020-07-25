using Watchdog.Persistence;

namespace Watchdog.Entities
{
    public class RuleKind
    {
        public string Description { get; }
        public string RuleCode { get; }
        public int NumericValue { get; }

        private RuleKind(string description, string ruleCode, int numericValue)
        {
            Description = description;
            RuleCode = ruleCode;
            NumericValue = numericValue;
        }

        public static readonly RuleKind aa_max_diff_asset_class = new RuleKind("Maximale Abweichung AA Asset-Klasse", "aa_max_diff_asset_class", 1);
        public static readonly RuleKind aa_max_diff_currency = new RuleKind("Maximale Abweichung AA Währung", "aa_max_diff_currency", 2);
        public static readonly RuleKind min_rating = new RuleKind("Minimales Rating", "min_rating", 3);
        public static readonly RuleKind rule_exception = new RuleKind("Ausnahmeregelungen", "rule_exception", 4);
        public static readonly RuleKind restricted_instrument_type = new RuleKind("Nicht zugelassene Titelarten", "restricted_instrument_type", 5);
        public static readonly RuleKind dur_max_diff = new RuleKind("Maximale Abweichung Duration", "dur_max_diff", 6);
        public static readonly RuleKind tracking_error_max_diff = new RuleKind("Maximaler Tracking Error", "tracking_error_max_diff", 7);
        public static readonly RuleKind max_rating_ratio = new RuleKind("Maximaler Ratinganteil", "max_rating_ratio", 8);
        public static readonly RuleKind max_issuer_limit = new RuleKind("Maximale Emittentenlimite (Klumpenrisiken)", "max_issuer_limit", 9);
        public static readonly RuleKind max_leverage_asset_class = new RuleKind("Maximaler Leverage Asset-Klasse", "max_leverage_asset_class", 10);
        public static readonly RuleKind max_leverage_currency = new RuleKind("Maximaler Leverage Währung", "max_leverage_currency", 11);
        public static readonly RuleKind restricted_country = new RuleKind("Länderrestriktionen", "restricted_country", 12);
    }
}
