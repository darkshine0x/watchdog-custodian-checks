using System.Collections.Generic;
using Watchdog.Persistence;

namespace Watchdog.Entities
{
    class Currency
    {
        public string IsoCode { get; }

        public Currency(string isoCode)
        {
            IsoCode = isoCode;
        }
    }
}
