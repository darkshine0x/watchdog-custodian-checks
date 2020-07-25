using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchdog.Entities;

namespace Watchdog.Persistence
{
    class FundPersister
    {
        private static readonly Workbook workbook = Globals.WatchdogAddIn.Application.ActiveWorkbook;

        public static bool Create(Fund fund)
        {
            // TableUtility.CreateMissingTable(workbook, "wdt_funds", fund.GetTableHeader());
            return true;
        }
    }


}
