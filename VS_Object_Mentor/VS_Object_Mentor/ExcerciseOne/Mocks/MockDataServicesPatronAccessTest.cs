using System.Collections.Generic;
using NUnit.Framework;
using VS_Object_Mentor.ExcerciseOne.Models;

namespace VS_Object_Mentor.ExcerciseOne.Mocks
{
    [TestFixture]
    public class MockDataServicesPatronAccessTest
    {
        [SetUp]
        public void setUp()
        {
            ds = new MockDataServices();
        }

        private MockDataServices ds = new MockDataServices();

        [Test]
        public void testAddAFew()
        {
            ds.addPatron(new Patron("Bob"));
            ds.addPatron(new Patron("Tim"));
            ds.addPatron(new Patron("Dean"));
            Assert.That(3, Is.EqualTo(ds.countActivePatrons()));
            var p1 = ds.findPatron("Tim");
            Assert.True(p1.hasId("Tim"));
        }

        [Test]
        public void testAddOne()
        {
            ds.addPatron(new Patron("Bob"));
            Assert.That(1, Is.EqualTo(ds.countActivePatrons()));
            var p1 = ds.findPatron("Bob");
            Assert.True(p1.hasId("Bob"));
        }

        [Test]
        public void testCreate()
        {
            Assert.That(0, Is.EqualTo(ds.countActivePatrons()));
        }

        [Test]
        public void testRetrieveNonexistant()
        {
            Assert.Throws<KeyNotFoundException>(() => ds.findPatron("nonesuch"));
        }
    }
}