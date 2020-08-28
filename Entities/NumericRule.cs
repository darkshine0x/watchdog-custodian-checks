using Watchdog.Persistence;

namespace Watchdog.Entities
{
    public class NumericRule : Rule
    {
        [PersistableField]
        public double NumericValue { get; set; }

        public NumericRule(double numericValue, RuleKind ruleKind) : base(ruleKind)
        {
            NumericValue = numericValue;
        }

        
    }
}
