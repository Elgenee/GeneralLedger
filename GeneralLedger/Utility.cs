using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger
{
    public class Utility
    {

        public Utility()
        {
           


        }


        public DateTime GetEndOfTheMonth(DateTime dateInput) 
        {
            var dayResult = DateTime.DaysInMonth(dateInput.Year, dateInput.Month);
            DateTime lastDateOfMonth = new DateTime(dateInput.Year, dateInput.Month, dayResult);
            return lastDateOfMonth;
        }
    }
}
