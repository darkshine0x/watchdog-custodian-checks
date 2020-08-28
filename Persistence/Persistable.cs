using System.Collections.Generic;

namespace Watchdog.Persistence
{
    public interface Persistable
    {
        string GetTableName();

        double GetIndex();

        void SetIndex(double index);
    }
}
