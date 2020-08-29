using System.Collections.Generic;

namespace Watchdog.Entities
{
    public class AllowList<T> : Rule
    {
        public List<T> Allowed { get; }

        public AllowList()
        {

        }
        public AllowList(RuleKind ruleKind, string name) : base(ruleKind, name)
        {
            Allowed = new List<T>();
        }
    }
}
