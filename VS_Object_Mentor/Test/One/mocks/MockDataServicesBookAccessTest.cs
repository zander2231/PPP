using NUnit.Framework;
using VS_Object_Mentor.Models.One;

namespace Test.One.mocks
{
    [TestFixture]
    public class MockDataServicesBookAccessTest
    {
        [Test]
        public void testAddCopyCreateUniqueId()
        {
            var g = new MockDataServices();
            var id1 = g.addBook(new BookTitle("isbn")).getId();
            var id2 = g.addBook(new BookTitle("isbn")).getId();
            Assert.False(id1.Equals(id2));
        }
    }
}