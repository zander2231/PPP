using System;
using VS_Object_Mentor.ExcerciseTwo.Utils;

namespace VS_Object_Mentor.ExcerciseTwo.Mocks
{
    public class MockTimeSource : TimeSource
    {
        private DateTime time;

        public MockTimeSource(DateTime time)
        {
            this.time = time;
        }

        public MockTimeSource(string dateString, int year, int month, int day)
        {
            time = DateUtil.dateFromString(year, month, day);
        }

        public DateTime getTime()
        {
            return time;
        }
    }
}
