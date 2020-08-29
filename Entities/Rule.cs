using Watchdog.Persistence;

namespace Watchdog.Entities
{
    [JoinedTableBase(typeof(NumericRule), typeof(AllowList<Asset>))]
    public class Rule : Persistable
    {
        private static readonly string tableName = "wdt_rules";
        [PersistableField]
        public RuleKind RuleKind { get; set; }
        [PersistableField]
        public string Name { get; set; }
        public double Index { get; set; }

        public Rule()
        {

        }

        public Rule(RuleKind ruleKind, string name)
        {
            RuleKind = ruleKind;
            Name = name;
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
