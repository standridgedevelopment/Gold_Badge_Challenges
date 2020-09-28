using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsDepartment
{
    public static class TableBuilder
    {
        private const int TableWidth = 80;
        public static void PrintRow(params string[] columns)
        {
            int columnWidth = (TableWidth - columns.Length) / columns.Length;

            string row = columns.Aggregate(" ", (seperator, columnText) => seperator  + seperator);

        }
        
        
    }
}