using NUnit.Framework;
using VS_Object_Mentor.Models.One;

namespace Test.One
{
    [TestFixture]
    public class PatronTest
    {
        [Test]
        public void testCreate()
        {
            var address = new Address("street1", "street2", "city", "state", "zip");
            Assert.NotNull(new Patron("1", "John", "Q", "Public", address, "8479991234"));
        }
    }
}