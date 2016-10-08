using NUnit.Framework;
using VS_Object_Mentor.ExcerciseTwo.Data;
using VS_Object_Mentor.ExcerciseTwo.Mocks;
using VS_Object_Mentor.ExcerciseTwo.Models;

namespace VS_Object_Mentor.ExcerciseTwo
{
    [TestFixture]
    public class BookCatalogTest
    {
        [SetUp]
        public void setUp()
        {
            dataServices = new MockDataServices();
            catalog = new BookCatalog(dataServices);
        }

        private MockDataServices dataServices;
        private BookCatalog catalog;

        private BookCopy addCopy(string isbn)
        {
            dataServices.setBookToReturn(new BookTitle(isbn));
            return catalog.addCopy(isbn);
        }

        [Test]
        public void testAddBookShouldAddBookReturnedByIsbnService()
        {
            var bookCopy = addCopy("ISBN");
            Assert.AreEqual(dataServices.addedBookCopy.getBookTitle(), bookCopy
                .getBookTitle());
        }

        [Test]
        public void testAddBookShouldLookUpISBN()
        {
            addCopy("ISBN");
            Assert.AreEqual("ISBN", dataServices.wasLastCalledWithThisIsbn);
        }

        [Test]
        public void testCanFindMoreThanOneBook()
        {
            var copy1 = addCopy("ISBN");
            var copy2 = addCopy("ISBN");
            var copies = catalog.findAllCopies("ISBN");
            Assert.AreEqual(2, copies.Count);
            Assert.True(copies.Contains(copy1));
            Assert.True(copies.Contains(copy2));
        }

        [Test]
        public void testFindAvailableCopyReturnsCopyWhenOneCopyOfManyIsBorrowed()
        {
            addCopy("ISBN");
            addCopy("ISBN");
            var copies = catalog.findAllCopies("ISBN");
            var copy = copies[0];
            copy.setBorrowed(new Receipt(new Patron("borrower"),
                Receipt.BORROW_RECEIPT));
            Assert.NotNull(catalog.findAvailableCopy("ISBN"));
        }

        [Test]
        public void testShouldReturnCorrectBookAmongMany()
        {
            var copy1 = addCopy("ISBN 1");
            var copy2 = addCopy("ISBN 2");
            Assert.AreSame(copy1, catalog.findCopy("ISBN 1"));
            Assert.AreSame(copy2, catalog.findCopy("ISBN 2"));
        }

        [Test]
        public void testUnfoundISBN()
        {
            try
            {
                catalog.addCopy("NON-EXISTENT ISBN");
                Assert.Fail();
            }
            catch (IsbnDoesNotExistException e)
            {
            }
        }
    }
}