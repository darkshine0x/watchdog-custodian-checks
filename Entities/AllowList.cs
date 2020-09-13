using System.Collections.Generic;
using Watchdog.Persistence;

namespace Watchdog.Entities
{
    [JoinedTable("wdt_allowlist")]
    public class AllowList : Rule
    {
        [PersistableField(3)]
        [MultiValue]
        public List<Asset> Allowed { get; set; }

        public AllowList()
        {

        }

        public AllowList(RuleKind ruleKind, string name) : base(ruleKind, name)
        {
            Allowed = new List<Asset>();
        }
    }
}
