using System.Collections.Generic;

namespace Watchdog.Persistence
{
    public interface Persistable
    {
        string GetTableName();
        
        List<string> GetTableHeader();

        double GetIndex();

        void SetIndex(double index);

        Dictionary<string, string> GetTableMapping();
    }
}
