using System;
using System.Globalization;
using NUnit.Framework;

namespace VS_Object_Mentor.ExcerciseTwo.Utils
{
    [TestFixture]
    public class DateUtilTest
    {
        [Test]
        public void testDateFromString()
        {
            var d = DateUtil.dateFromString(2000, 1, 1);
            Calendar c = new GregorianCalendar();
            Assert.AreEqual(d, c.ToDateTime(2000, 1,1,0,0,0,0));
        }

        [Test]
        public void testDaysLateWhenEarly()

        {
            var due = DateUtil.dateFromString(2000,1,1);
            var actual = DateUtil.
                dateFromString(1999,12,31);
            Assert.AreEqual(-1, DateUtil.daysLate(actual, due));
        }

        [Test]
        public void testDaysLateWhenOneSecondFromTwoDaysLate()
        {
            var due = DateUtil.dateFromString(2006,11,5);
            DateTime actual =
                new GregorianCalendar().ToDateTime(2006, 11, 6, 23, 59, 59,0);
            Assert.AreEqual(1, DateUtil.daysLate(
                actual, due));
        }

        [Test]
        public void testDaysLateWhenTwoHoursLateCrossingMidnight()
        {
            DateTime due = new GregorianCalendar().ToDateTime(2000, 1, 1, 23, 0, 0,0);
            DateTime actual =
                new GregorianCalendar().ToDateTime(2000, 1, 2, 1, 0, 0,0);
            Assert.AreEqual(1, DateUtil.daysLate(
                actual, due));
        }

        [Test]
        public void testDaysLateWithNoTimes()
        {
            var due = DateUtil.dateFromString(2000, 1, 1);
            var actual = DateUtil.
                dateFromString(2000,1,2);
            Assert.AreEqual(1, DateUtil.daysLate(actual, due));
        }
    }
}