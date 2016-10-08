using NUnit.Framework;
using VS_Object_Mentor.ExcerciseTwo.Models;

namespace VS_Object_Mentor.ExcerciseTwo.Mocks
{
    [TestFixture]
    public class MockDataServicesBookAccessTest
    {
        [Test]
        public void testAddCopyShouldCreateUniqueId()
        {
            var dataServices = new MockDataServices();
            var id1 = dataServices.
                addCopy(new BookTitle("isbn")).getId();
            var id2 = dataServices.addCopy(
                new BookTitle("isbn")).getId();
            Assert.False(id1.Equals(id2));
        }
    }
}