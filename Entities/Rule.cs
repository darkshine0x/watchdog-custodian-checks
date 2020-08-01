using System.Collections.Generic;
using Watchdog.Persistence;

namespace Watchdog.Entities
{
    class Rule : Persistable
    {
        private static readonly string tableName = "wdt_rules";
        public RuleKind RuleKind { get; }
        public double Index { get; set; }

        public Rule(RuleKind ruleKind)
        {
            RuleKind = ruleKind;
        }

        public string GetTableName()
        {
            return tableName;
        }

        public List<string> GetTableHeader()
        {
            throw new System.NotImplementedException();
        }

        public double GetIndex()
        {
            return Index;
        }

        public void SetIndex(double index)
        {
            Index = index;
        }
    }
}
