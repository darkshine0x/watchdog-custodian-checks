using System.Collections.Generic;

namespace Watchdog.Entities
{
    class Issuer
    {
        public int Id { get; }
        public string Name { get; }
        public string Domicile { get; }
        public List<Rating> Ratings { get; }

        public Issuer(int id, string name, string domicile, List<Rating> ratings = null)
        {
            Id = id;
            Name = name;
            Domicile = domicile;
            if (ratings != null)
            {
                Ratings = ratings;
            } else
            {
                Ratings = new List<Rating>();
            }
        }
    }
}
