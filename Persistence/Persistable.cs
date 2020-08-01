using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchdog.Persistence
{
    interface Persistable
    {
        string GetTableName();
        
        List<string> GetTableHeader();

        double GetIndex();

        void SetIndex(double index);
    }
}
