
using System.Collections.Generic;
using NUnit.Framework;
using VS_Object_Mentor.ExcerciseTwo.Mocks;
using VS_Object_Mentor.ExcerciseTwo.Models;

namespace VS_Object_Mentor.ExcerciseTwo
{
    [TestFixture]
    public class BookCatalogWithOneCopyTest {

        private BookCatalog catalog;

        [SetUp]
        public void setUp(){
            MockDataServices fakeBookRepository = new MockDataServices();
            catalog = new BookCatalog(fakeBookRepository);
            BookTitle bookTitle = new BookTitle("ISBN");
            fakeBookRepository.setBookToReturn(bookTitle);
            catalog.addCopy("ISBN");
        }

        [Test]
        public void testFindCopyShouldReturnNullForUnaddedBooks() {
            Assert.Throws<KeyNotFoundException>(()=> catalog
                .findCopy("NOT ISBN"),"expected null for unrecognized ISBN");
        }
        [Test]
        public void TestFindCopyShouldReturnCopyForCorrectIsbn() {
            Assert.NotNull(catalog
                .findCopy("ISBN"), "expected copy for recognized ISBN");
        }
        [Test]
        public void testContainsTitleShouldReturnTrueForCorrectISBN(){
            Assert.True( catalog
            .containsTitle("ISBN"), "expected true for recognized ISBN");
        }

        [Test]
        public void testContainsTitleShouldReturnFalseForIncorrectISBN() {
            Assert.False(catalog
            .containsTitle("NOT ISBN"), "expected false for unrecognized ISBN");
        }

        [Test]
        public void testFindAvailableCopyReturnsNullWhenCopyIsBorrowed() {
            List<BookCopy> copies = catalog.findAllCopies("ISBN");
            BookCopy copy = (BookCopy) copies[0];
            copy.setBorrowed(new Receipt(new Patron("borrower"),
            Receipt.BORROW_RECEIPT));
            Assert.AreEqual(null, catalog.findAvailableCopy("ISBN"));
        }

        [Test]
        public void testFindAvailableCopyReturnsCopyWhenCopyIsNotBorrowed(){
            Assert.NotNull(catalog.findAvailableCopy("ISBN"));
        }

    }
}
