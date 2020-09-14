using Watchdog.Forms.Util;
using Watchdog.Persistence;

namespace Watchdog.Entities
{
    public class Country : Persistable
    {
        private static readonly Persistable defaultValue = new Country();

        [PersistableField(0)]
        [TableHeader("NAME")]
        public string Name { get; set; }
        [PersistableField(1)]
        [TableHeader("ISO-CODE")]
        public string IsoCode { get; set; }
        public double Index { get; set; }

        public Country()
        {

        }

        public Country(string name, string isoCode)
        {
            Name = name;
            IsoCode = isoCode;
        }

        public double GetIndex()
        {
            return Index;
        }

        public string GetTableName()
        {
            return "wdt_countries";
        }

        public void SetIndex(double index)
        {
            Index = index;
        }

        public static Persistable GetDefaultValue()
        {
            return defaultValue;
        }

        public string GetShortName()
        {
            return "co";
        }
    }
}
