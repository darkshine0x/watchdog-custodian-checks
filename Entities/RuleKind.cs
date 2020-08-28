using System.ComponentModel;

namespace Watchdog.Entities
{
    public enum RuleKind
    {
        [Description("Maximale Abweichung AA Asset-Klasse")]
        AA_MAX_DIFF_ASSET_CLASS,
        [Description("Maximale Abweichung AA Währung")]
        AA_MAX_DIFF_CURRENCY,
        [Description("Minimales Rating")]
        MIN_RATING,
        [Description("Ausnahmeregelungen")]
        RULE_EXCEPTION,
        [Description("Nicht zugelassene Titelarten")]
        RESTRICTED_INSTRUMENT_TYPE,
        [Description("Maximale Abweichung Duration")]
        DUR_MAX_DIFF,
        [Description("Maximaler Tracking Error")]
        TRACKING_ERROR_MAX_DIFF,
        [Description("Maximaler Ratinganteil")]
        MAX_RATING_RATIO,
        [Description("Maximale Emittentenlimite")]
        MAX_ISSUER_LIMIT,
        [Description("Maximaler Leverage Asset-Klasse")]
        MAX_LEVERAGE_ASSET_CLASS,
        [Description("Maximaler Leverage Währung")]
        MAX_LEVERAGE_CURRENCY,
        [Description("Länderrestriktionen")]
        RESTRICTED_COUNTRY,
        [Description("Abweichung nur innerhalb AA-Bandbreiten")]
        AA_MAX_DIFF_RANGES
    }
}
