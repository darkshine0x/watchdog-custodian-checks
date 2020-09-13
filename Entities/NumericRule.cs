using Watchdog.Persistence;

namespace Watchdog.Entities
{
    [JoinedTable("wdt_numeric_rules")]
    public class NumericRule : Rule
    {
        [PersistableField(3)]
        public double NumericValue { get; set; }

        public NumericRule()
        {

        }

        public NumericRule(double numericValue, RuleKind ruleKind, string name) : base(ruleKind, name)
        {
            NumericValue = numericValue;
        }

        
    }
}
