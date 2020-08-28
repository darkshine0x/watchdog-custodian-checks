using System.Collections.Generic;
using Watchdog.Persistence;

namespace Watchdog.Entities
{
    public class Rule : Persistable
    {
        private static readonly string tableName = "wdt_rules";
        [PersistableField]
        public RuleKind RuleKind { get; set; }
        public double Index { get; set; }

        public Rule()
        {

        }

        public Rule(RuleKind ruleKind)
        {
            RuleKind = ruleKind;
        }

        public string GetTableName()
        {
            return tableName;
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
    }
}
