using NUnit.Framework;

namespace VS_Object_Mentor.ExcerciseTwo.Models
{
    [TestFixture]
    public class PatronTest
    {
        [SetUp]
        public void setUp()
        {
            patron = new Patron("1", "John", "Q", "Public", "street1", "street2", "city", "state", "zip", "8479991234");
        }

        private Patron patron;

        [Test]
        public void testAddress()
        {
            Assert.AreEqual("street1\nstreet2\ncity, state zip", patron.printAddress());
        }

        [Test]
        public void testAddressWithNoStreet2()
        {
            patron = new Patron("1", "John", "Q", "Public", "street1", null, "city", "state", "zip", "8479991234");
            Assert.AreEqual("street1\ncity, state zip", patron.printAddress());
        }

        [Test]
        public void testCreate()
        {
            Assert.NotNull(patron);
        }

        [Test]
        public void testFullName()
        {
            Assert.AreEqual("John Q. Public", patron.getFullName());
        }

        [Test]
        public void testFullNameWithNoMiddleName()
        {
            patron = new Patron("1", "John", null, "Public", null, null, null, null, null, null);
            Assert.AreEqual("John Public", patron.getFullName());
        }
    }
}