using Watchdog.Persistence;

namespace Watchdog.Entities
{
    public class RatingAgency
    {
        public string Name { get; }

        public RatingAgency(string name)
        {
            Name = name;
        }
    }
}
