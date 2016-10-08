using System;

namespace VS_Object_Mentor.ExcerciseTwo.Utils
{
    public class DateUtil
    {
        public static int daysLate(DateTime actualDate, DateTime dueDate)
        {
            return actualDate.CompareTo(dueDate);
        }

        public static DateTime dateFromString(int year, int month, int day)
        {
            return new DateTime(year, month, day);
        }
    }
}