namespace Watchdog.Entities
{
    public class RuleKind
    {
        public string Description { get; }

        private RuleKind(string description)
        {
            Description = description;
        }

        public static readonly RuleKind AA_MAX_DIFF_ASSET_CLASS = new RuleKind("Maximale Abweichung AA Asset-Klasse");
        public static readonly RuleKind AA_MAX_DIFF_CURRENCY = new RuleKind("Maximale Abweichung AA Währung");
        public static readonly RuleKind MIN_RATING = new RuleKind("Minimales Rating");
        public static readonly RuleKind RULE_EXCEPTION = new RuleKind("Ausnahmeregelungen");
        public static readonly RuleKind RESTRICTED_INSTRUMENT_TYPE = new RuleKind("Nicht zugelassene Titelarten");
        public static readonly RuleKind MAX_DIFF_DUR = new RuleKind("Maximale Abweichung Duration");
        public static readonly RuleKind MAX_DIFF_TRACKING_ERROR = new RuleKind("Maximaler Tracking Error");
        public static readonly RuleKind MAX_RATING_RATIO = new RuleKind("Maximaler Ratinganteil");
        public static readonly RuleKind MAX_ISSUER_LIMIT = new RuleKind("Maximale Emittentenlimite (Klumpenrisiken)");
        public static readonly RuleKind MAX_LEVERAGE_ASSET_CLASS = new RuleKind("Maximaler Leverage Asset-Klasse");
        public static readonly RuleKind MAX_LEVERAGE_CURRENCY = new RuleKind("Maximaler Leverage Währung");
        public static readonly RuleKind RESTRICTED_COUNTRY = new RuleKind("Länderrestriktionen");
    }
}
