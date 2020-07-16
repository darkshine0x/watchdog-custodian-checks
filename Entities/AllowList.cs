using System.Collections.Generic;

namespace Watchdog.Entities
{
    class AllowList<T> : Rule
    {
        public List<T> Allowed { get; }

        public AllowList(RuleKind ruleKind) : base(ruleKind)
        {
            Allowed = new List<T>();
        }
    }
}
