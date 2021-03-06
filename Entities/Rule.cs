﻿using System.Collections.Generic;
using Watchdog.Persistence;

namespace Watchdog.Entities
{
    [JoinedTableBase(typeof(NumericRule), typeof(AllowList), typeof(RatingQuoteRule), typeof(BanList<AssetKind>), typeof(BanList<Country>))]
    public class Rule : Persistable
    {
        [PersistableField(0)]
        public RuleKind RuleKind { get; set; }
        [PersistableField(1)]
        public string Name { get; set; }
        [PersistableField(2)]
        [MultiValue]
        public List<Fund> FundList { get; set; }
        public double Index { get; set; }

        public Rule()
        {
            FundList = new List<Fund>();
        }

        public Rule(RuleKind ruleKind, string name)
        {
            RuleKind = ruleKind;
            Name = name;
            FundList = new List<Fund>();
        }

        public virtual string GetTableName()
        {
            return "wdt_rules";
        }

        public double GetIndex()
        {
            return Index;
        }

        public void SetIndex(double index)
        {
            Index = index;
        }

        public static Persistable GetDefaultValue()
        {
            return new Rule();
        }

        public string GetShortName()
        {
            return "rule";
        }
    }
}
