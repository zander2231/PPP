using NUnit.Framework;
using VS_Object_Mentor.ExcerciseTwo.Mocks;
using VS_Object_Mentor.ExcerciseTwo.Models;
using VS_Object_Mentor.ExcerciseTwo.Utils;

namespace VS_Object_Mentor.ExcerciseTwo
{
    [TestFixture]
    public class LibraryReturnCopyTest
    {
        [SetUp]
        public void setUp()
        {
            var dataServices = new MockDataServices();
            library = new Library(dataServices);
            dataServices.setBookToReturn(new BookTitle("isbn"));
            copy = library.acceptBook("isbn");
            copyId = copy.getId();
        }

        private Library library;
        private string copyId;
        private BookCopy copy;

        public void testShouldSetStatusToUnBorrowedBookOnAttemptToReturnUnBorrowedBook()
        {
            var returnReceipt = library.returnCopy(copyId);
            Assert.Equals(Receipt.UNBORROWED_BOOK, returnReceipt.getStatus());
            Assert.Equals(copy, returnReceipt.getCopy());
        }

        public void testShouldHaveFineAndBeLateIfOneDayLate()
        {
            var borrowDate = DateUtil.dateFromString(2006, 12, 19);
            var returnDate = DateUtil.dateFromString(2007, 1, 3); // fifteen days later.
            library.setTimeSource(new MockTimeSource(borrowDate));
            library.borrow(copyId, "dean");
            library.setTimeSource(new MockTimeSource(returnDate));
            var receipt = library.returnCopy(copyId);

            Assert.Equals(Receipt.LATE, receipt.getStatus());
            Assert.Equals(new Money(50), receipt.getFine());
        }

        [Test]
        public void testCanReturnOnTimeBookThatWasBorrowed()
        {
            library.borrow(copyId, "dean");
            var returnReceipt = library.returnCopy(copyId);
            Assert.AreEqual(new Money(0), returnReceipt.getFine());
            Assert.AreEqual(copy, returnReceipt.getCopy());
            Assert.False(returnReceipt.getCopy().isBorrowed());
            Assert.AreEqual(Receipt.OK, returnReceipt.getStatus());
        }

        [Test]
        public void testShouldHaveFineAndBeLateIfTwoDaysLate()
        {
            var borrowDate = DateUtil.dateFromString(2006, 12, 19);
            var returnDate = DateUtil.dateFromString(2007, 1, 4); // sixteen days later.
            library.setTimeSource(new MockTimeSource(borrowDate));
            library.borrow(copyId, "dean");
            library.setTimeSource(new MockTimeSource(returnDate));
            var receipt = library.returnCopy(copyId);

            Assert.AreEqual(Receipt.LATE, receipt.getStatus());
            Assert.AreEqual(new Money(100), receipt.getFine());
        }

        [Test]
        public void testShouldSetStatusToUnknownBookOnAttemptToReturnUnknownBook()
        {
            var returnReceipt = library.returnCopy("unknown terrible string");
            Assert.AreEqual(Receipt.UNKNOWN_BOOK, returnReceipt.getStatus());
        }
    }
}