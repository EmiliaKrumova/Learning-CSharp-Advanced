using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateModifier
{
    public static class DateModifier
    {
		
       
		public static int DifferenceBetweenDates(string date1,string date2)
		{
			DateTime start = DateTime.Parse(date1);
            DateTime end = DateTime.Parse(date2);

            TimeSpan diff = end - start;
            

            return Math.Abs(diff.Days);
        }

        // Difference in days, hours, and minutes.

       // TimeSpan ts = EndDate - StartDate;

        // Difference in days.

       // int differenceInDays = ts.Days; // This is in int
       // double differenceInDays = ts.TotalDays; // This is in double

        // Difference in Hours.
      //  int differenceInHours = ts.Hours; // This is in int
      //  double differenceInHours = ts.TotalHours; // This is in double

        // Difference in Minutes.
      //  int differenceInMinutes = ts.Minutes; // This is in int
       // double differenceInMinutes = ts.TotalMinutes; // This is in double

    }
}
