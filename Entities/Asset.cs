using System.Collections.Generic;
using Watchdog.Persistence;

namespace Watchdog.Entities
{
    class Asset
    {
        public int Id { get; }
        public int SecurityNumber { get; }
        public string Isin { get; }
        public string Name { get; }
        public string AssetType { get; }
        public string InstrumentGroup { get; }
        public string SpecialType { get; }
        public string Timing { get; }
        public string TkAssetType { get; }
        public string PmCategory { get; }
        public string PmClassification { get; }
        public string PmSubtype { get; }
        public string PmRegion { get; }
        public string PmDomicile { get; }
        public string PmBranch { get; }
        public string PmCurrencyRiskGroup { get; }
        public string PmCurrency { get; }
        public string PmRiskChf { get; }
        public string PmRiskEur { get; }
        public string PmRiskUsd { get; }
        public bool PmBuyRestriction { get; }
        public Asset Underlying { get; }
        public Issuer Issuer { get; }
        public List<Rating> Ratings { get; }
        public AssetClass AssetClass { get; }

        public Asset(Dictionary<string, string> classes, Issuer issuer, AssetClass assetClass, Asset underlying = null, List<Rating> ratings = null)
        {
            classes.TryGetValue("id", out string dictValue);
            Id = int.Parse(dictValue);
            classes.TryGetValue("security_number", out dictValue);
            SecurityNumber = int.Parse(dictValue);
            classes.TryGetValue("isin", out dictValue);
            Isin = dictValue;
            classes.TryGetValue("name", out dictValue);
            Name = dictValue;
            classes.TryGetValue("asset_type", out dictValue); 
            AssetType = dictValue;
            classes.TryGetValue("instrument_group", out dictValue);
            InstrumentGroup = dictValue;
            classes.TryGetValue("special_type", out dictValue);
            SpecialType = dictValue;
            classes.TryGetValue("timing", out dictValue);
            Timing = dictValue;
            classes.TryGetValue("tk_asset_type", out dictValue);
            TkAssetType = dictValue;
            classes.TryGetValue("pm_category", out dictValue);
            PmCategory = dictValue;
            classes.TryGetValue("pm_classification", out dictValue);
            PmClassification = dictValue;
            classes.TryGetValue("pm_subtype", out dictValue);
            PmSubtype = dictValue;
            classes.TryGetValue("pm_region", out dictValue);
            PmRegion = dictValue;
            classes.TryGetValue("pm_domicile", out dictValue);
            PmDomicile = dictValue;
            classes.TryGetValue("pm_branch", out dictValue);
            PmBranch = dictValue;
            classes.TryGetValue("pm_currency_risk_group", out dictValue);
            PmCurrencyRiskGroup = dictValue;
            classes.TryGetValue("pm_currency", out dictValue);
            PmCurrency = dictValue;
            classes.TryGetValue("pm_risk_chf", out dictValue);
            PmRiskChf = dictValue;
            classes.TryGetValue("pm_risk_eur", out dictValue);
            PmRiskEur = dictValue;
            classes.TryGetValue("pm_risk_usd", out dictValue);
            PmRiskUsd = dictValue;
            classes.TryGetValue("pm_buy_restriction", out dictValue);
            if (dictValue.ToLower().Equals("ja"))
            {
                PmBuyRestriction = true;
            }
            AssetClass = assetClass;
            Underlying = underlying;
            Issuer = issuer;
            if (ratings != null)
            {
                Ratings = ratings;
            } else
            {
                Ratings = new List<Rating>();
            }
        }
    }
}
