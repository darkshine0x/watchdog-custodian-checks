using System.Collections.Generic;

namespace Watchdog.Entities
{
    public class BanList<T> : Rule
    {
        public string Test { get; }
        public List<T> Banned { get; }

        public BanList(RuleKind ruleKind, string name) : base(ruleKind, name)
        {
            Banned = new List<T>();
        }
    }
}
