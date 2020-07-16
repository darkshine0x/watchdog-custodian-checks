using System.Collections.Generic;

namespace Watchdog.Entities
{
    class BanList<T> : Rule
    {
        public string Test { get; }
        public List<T> Banned { get; }

        public BanList(RuleKind ruleKind) : base(ruleKind)
        {
            Banned = new List<T>();
        }
    }
}
