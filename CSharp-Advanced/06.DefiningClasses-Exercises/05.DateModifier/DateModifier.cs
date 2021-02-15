using System;
using System.Collections.Generic;
using System.Text;

namespace _05.DateModifier
{
    public static class DateModifier
    {
        public static int GetDiffBetweenDatesInDays(string dateOneStr, string dateTwoStr)
        {
            DateTime dateOne = DateTime.Parse(dateOneStr);
            DateTime dateTwo = DateTime.Parse(dateTwoStr);

            TimeSpan diff = dateOne - dateTwo;
            return Math.Abs(diff.Days);

        }
    }
}
