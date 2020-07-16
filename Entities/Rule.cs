namespace Watchdog.Entities
{
    class Rule
    {
        public RuleKind RuleKind { get; }

        public Rule(RuleKind ruleKind)
        {
            RuleKind = ruleKind;
        }
    }
}
