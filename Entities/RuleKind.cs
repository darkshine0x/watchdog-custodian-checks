using Watchdog.Persistence;

namespace Watchdog.Entities
{
    public class RuleKind : Persistable
    {
        private static readonly string tableName = "wdt_rule_kinds";
        public string Description { get; }
        public int NumericValue { get; }

        private RuleKind(string description, int numericValue)
        {
            Description = description;
            NumericValue = numericValue;
        }

        public static readonly RuleKind aa_max_diff_asset_class = new RuleKind("Maximale Abweichung AA Asset-Klasse", 1);
        public static readonly RuleKind aa_max_diff_currency = new RuleKind("Maximale Abweichung AA Währung", 2);
        public static readonly RuleKind min_rating = new RuleKind("Minimales Rating", 3);
        public static readonly RuleKind rule_exception = new RuleKind("Ausnahmeregelungen", 4);
        public static readonly RuleKind restricted_instrument_type = new RuleKind("Nicht zugelassene Titelarten", 5);
        public static readonly RuleKind dur_max_diff = new RuleKind("Maximale Abweichung Duration", 6);
        public static readonly RuleKind tracking_error_max_diff = new RuleKind("Maximaler Tracking Error", 7);
        public static readonly RuleKind max_rating_ratio = new RuleKind("Maximaler Ratinganteil", 8);
        public static readonly RuleKind max_issuer_limit = new RuleKind("Maximale Emittentenlimite (Klumpenrisiken)", 9);
        public static readonly RuleKind max_leverage_asset_class = new RuleKind("Maximaler Leverage Asset-Klasse", 10);
        public static readonly RuleKind max_leverage_currency = new RuleKind("Maximaler Leverage Währung", 11);
        public static readonly RuleKind restricted_country = new RuleKind("Länderrestriktionen", 12);

        public string GetTableName()
        {
            return tableName;
        }
    }
}
