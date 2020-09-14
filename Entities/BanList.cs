using System.Collections.Generic;
using Watchdog.Persistence;

namespace Watchdog.Entities
{
    [JoinedTable("wdt_bl")]
    public class BanList<T> : Rule where T : Persistable, new()
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

        public override string GetTableName()
        {
            T obj = new T();
            string name = "wdt_bl" + "_" + obj.GetShortName();
            return name;
        }
    }
}
