
using System;
using NUnit.Framework;
using VS_Object_Mentor.ExcerciseTwo.Mocks;
using VS_Object_Mentor.ExcerciseTwo.Models;
using VS_Object_Mentor.ExcerciseTwo.Utils;

namespace VS_Object_Mentor.ExcerciseTwo
{
    [TestFixture]
    public class LibraryBorrowingTest{
        private Library library;
        private Receipt receipt;
        private Patron david;
        private BookCopy copy;
        private MockDataServices dataServices;

        [SetUp]
        public void setUp() {
            dataServices = new MockDataServices();
            library = new Library(dataServices);
            david = new Patron("david");
            dataServices.addPatron(david);
            dataServices.setBookToReturn(new BookTitle("isbn"));
            copy = library.acceptBook("isbn");
        }
        [Test]
        public void testCanBorrowBookThatLibraryHas() {
            receipt = library.borrow(copy.getId(), "david");
            Assert.AreEqual(Receipt.OK, receipt.getStatus());
        }
        [Test]
        public void testShouldSetCopyToBorrowed() {
            receipt = library.borrow(copy.getId(), "david");
            Assert.True(copy.isBorrowed());
        }
        [Test]
        public void testCanNotBorrowBookLibraryDoesNotHave() {
            receipt = library.borrow("isbnWeDontHave", "david");
            Assert.AreEqual(Receipt.UNKNOWN_BOOK, receipt.getStatus());
        }
        [Test]
        public void testCanBorrowTwoIfTwoInCatalog() {
            dataServices.setBookToReturn(new BookTitle("secondIsbn"));
            BookCopy copy2 = library.acceptBook("secondIsbn");
            receipt = library.borrow(copy.getId(), "david");
            Assert.AreEqual(Receipt.OK, receipt.getStatus());
            receipt = library.borrow(copy2.getId(), "david");
            Assert.AreEqual(Receipt.OK, receipt.getStatus());
        }
        [Test]
        public void testSetReturnDateTwoWeeksFromToday() {
            DateTime now = DateUtil.dateFromString(2006, 12, 19);
            DateTime returnDate = DateUtil.dateFromString(2007, 1, 2);

            library.setTimeSource(new MockTimeSource(now));
            receipt = library.borrow(copy.getId(), "david");
            Assert.AreEqual(returnDate, receipt.getDueDate());
        }
        [Test]
        public void testReceiptRemembersBorrowingPatron() {
            receipt = library.borrow(copy.getId(), "david");
            Assert.AreEqual(david, receipt.getBorrower());
        }
        [Test]
        public void testReceiptRemembersBorrowedCopy() {
            receipt = library.borrow(copy.getId(), "david");
            Assert.AreEqual("isbn", receipt.getCopy().getBookTitle().getIsbn());
        }
    }
}