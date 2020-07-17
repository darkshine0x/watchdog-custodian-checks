using Watchdog.Persistence;

namespace Watchdog.Entities
{
    class RatingAgency : Persistable
    {
        private static readonly string tableName = "wdt_rating_agencies";
        public string Name { get; }

        public RatingAgency(string name)
        {
            Name = name;
        }

        public string GetTableName()
        {
            return tableName;
        }
    }
}
