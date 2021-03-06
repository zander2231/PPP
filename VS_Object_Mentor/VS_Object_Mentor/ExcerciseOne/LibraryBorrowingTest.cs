using System;
using NUnit.Framework;
using VS_Object_Mentor.ExcerciseOne.Mocks;
using VS_Object_Mentor.ExcerciseOne.Models;

namespace VS_Object_Mentor.ExcerciseOne
{
    [TestFixture]
    public class LibraryBorrowingTest
    {
        [SetUp]
        public void setUp()
        {
            ds = new MockDataServices();
            l = new Library(ds);
            p = new Patron("p");
            ds.addPatron(p);
            ds.setBookToReturn(new BookTitle("isbn"));
            b = l.acceptBook("isbn");
        }

        private Library l;
        private Receipt r;
        private Patron p;
        private Book b;
        private MockDataServices ds;

        [Test]
        public void testCanBorrowBookThatLibraryHas()
        {
            r = l.borrow(b.getId(), "p");
            Assert.That(Receipt.OK, Is.EqualTo(r.getStatus()));
            Assert.True(b.isBorrowed());
        }

        [Test]
        public void testCanBorrowTwoIfTwoInCatalog()
        {
            ds.setBookToReturn(new BookTitle("secondIsbn"));
            var copy2 = l.acceptBook("secondIsbn");
            r = l.borrow(b.getId(), "p");
            Assert.That(Receipt.OK, Is.EqualTo(r.getStatus()));
            r = l.borrow(copy2.getId(), "p");
            Assert.That(Receipt.OK, Is.EqualTo(r.getStatus()));
        }

        [Test]
        public void testCanNotBorrowBookLibraryDoesNotHave()
        {
            r = l.borrow("isbnWeDontHave", "p");
            Assert.That(Receipt.NO_SUCH_BOOK, Is.EqualTo(r.getStatus()));
        }

        [Test]
        public void testReceiptRemembersBorrowedCopy()
        {
            r = l.borrow(b.getId(), "p");
            Assert.That("isbn", Is.EqualTo(r.getCopy().getTitle().getIsbn()));
        }

        [Test]
        public void testReceiptRemembersBorrowingPatron()
        {
            r = l.borrow(b.getId(), "p");
            Assert.That(p, Is.EqualTo(r.getPatron()));
        }

        [Test]
        public void testSetReturnDateTwoWeeksFromToday()
        {
            var now = new DateTime(2006, 12, 19);
            var returnDate = new DateTime(2007, 1, 2);

            l.setTmpDate(now);
            r = l.borrow(b.getId(), "p");
            Assert.That(returnDate, Is.EqualTo(r.getDate()));
        }
    }
}