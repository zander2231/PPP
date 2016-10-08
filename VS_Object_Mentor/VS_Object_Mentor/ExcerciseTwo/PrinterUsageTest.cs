using NUnit.Framework;
using VS_Object_Mentor.ExcerciseTwo.Models;

namespace VS_Object_Mentor.ExcerciseTwo
{
    [TestFixture]
    public class PrinterUsageTest
    {
        [SetUp]
        public void setUp()
        {
            patron = new Patron("bob");
            printUsage = new PrintUsage(patron);
        }

        private PrintUsage printUsage;
        private Patron patron;

        [Test]
        public void testAcoupleRecordsProcessed()
        {
            var printRecord = new PrintRecord(3);
            printUsage.pagePrinted(printRecord);
            printUsage.pagePrinted(printRecord);
            Assert.AreEqual(6*5, printUsage.charges());
        }

        [Test]
        public void testNothingProcessed()
        {
            Assert.AreEqual(0, printUsage.charges());
        }

        [Test]
        public void testOneRecordProcessed()
        {
            var printRecord = new PrintRecord(3);
            printUsage.pagePrinted(printRecord);
            Assert.AreEqual(3*5, printUsage.charges());
        }
    }
}