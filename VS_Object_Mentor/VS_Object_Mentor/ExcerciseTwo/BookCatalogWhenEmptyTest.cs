using NUnit.Framework;
using VS_Object_Mentor.ExcerciseTwo.Mocks;

namespace VS_Object_Mentor.ExcerciseTwo
{
    [TestFixture]
    public class BookCatalogWhenEmptyTest {

        private MockDataServices fakeBookRepository;
        private BookCatalog catalog;

        [SetUp]
        public void setUp() {
            fakeBookRepository = new MockDataServices();
            catalog = new BookCatalog(fakeBookRepository);
        }

        public void testShouldBeEmpty() {
            Assert.That(0, Is.EqualTo(catalog.bookCount()), "expected empty catalog");
        }

        public void testContainsTitleShouldReturnFalse(){
            Assert.False(catalog.containsTitle("book"));
        }

        public void testFindAvailableCopyShouldReturnNull(){
            Assert.Null(catalog.findAvailableCopy("book"));
        }

    }
}
