using Watchdog.Persistence;

namespace Watchdog.Entities
{
    class RatingAgency
    {
        public string Name { get; }

        public RatingAgency(string name)
        {
            Name = name;
        }
    }
}
