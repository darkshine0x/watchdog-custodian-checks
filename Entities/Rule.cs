using System.Collections.Generic;
using Watchdog.Persistence;

namespace Watchdog.Entities
{
    public class Rule : Persistable
    {
        private static readonly string tableName = "wdt_rules";
        private static readonly Dictionary<string, string> tableMapping = new Dictionary<string, string>
        {
            {"rule_kind", "RuleKind" },
        };

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

        public List<string> GetTableHeader()
        {
            List<string> header = new List<string>();
            header.AddRange(tableMapping.Keys);
            return header;
        }

        public double GetIndex()
        {
            return Index;
        }

        public void SetIndex(double index)
        {
            Index = index;
        }

        public Dictionary<string, string> GetTableMapping()
        {
            return tableMapping;
        }

        public static Persistable GetDefaultValue()
        {
            return new Rule();
        }
    }
}
