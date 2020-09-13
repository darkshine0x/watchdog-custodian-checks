using System.Collections.Generic;
using Watchdog.Persistence;

namespace Watchdog.Entities
{
    [JoinedTable("wdt_ban_list")]
    public class BanList<T> : Rule
    {
        [PersistableField(3)]
        [MultiValue]
        public List<T> Banned { get; set; }

        public BanList()
        {

        }

        public BanList(RuleKind ruleKind, string name) : base(ruleKind, name)
        {
            Banned = new List<T>();
        }
    }
}
