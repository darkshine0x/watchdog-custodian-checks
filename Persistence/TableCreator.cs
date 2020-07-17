using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Watchdog.Persistence
{
    class TableCreator
    {
        public static Sheets CreateMissingTables(Workbook workbook, List<string> classes)
        {
            List<string> worksheetNames = new List<string>();
            Sheets worksheets = workbook.Sheets;
            foreach (Worksheet ws in worksheets)
            {
                string worksheetName = ws.Name;
                if (worksheetName.Contains("wdt_"))
                {
                    worksheetNames.Add(ws.Name);
                }
            }
            IEnumerable<string> difference = classes.Except(worksheetNames);
            bool diff = difference.Any();
            if (!diff)
            {
                return worksheets;
            }
            
            foreach (string name in difference)
            {
                Worksheet createdSheet = worksheets.Add();
                createdSheet.Name = name;
            }
            return worksheets;
        }
    }
}
