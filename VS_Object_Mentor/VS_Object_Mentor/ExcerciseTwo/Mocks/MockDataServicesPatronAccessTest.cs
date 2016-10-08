using System.Collections.Generic;
using NUnit.Framework;
using VS_Object_Mentor.ExcerciseTwo.Models;

namespace VS_Object_Mentor.ExcerciseTwo.Mocks
{
    [TestFixture]
    public class MockDataServicesPatronAccessTest {

        MockDataServices patrons;

        [SetUp]
        protected void setUp() {
            patrons = new MockDataServices();
        }
        [Test]
        public void testCreate() {
            Assert.That(0, Is.EqualTo(patrons.countActivePatrons()));
        }

        public void testAddOne(){
            patrons.addPatron(new Patron("Bob"));
            Assert.AreEqual(1, patrons.countActivePatrons());
            Patron bob = patrons.findPatronById("Bob");
            Assert.True(bob.hasId("Bob"));
        }

        [Test]
        public void testAddAFew() {
            patrons.addPatron(new Patron("Bob"));
            patrons.addPatron(new Patron("Tim"));
            patrons.addPatron(new Patron("Dean"));
            Assert.That(3, Is.EqualTo(patrons.countActivePatrons()));
            Patron bob = patrons.findPatronById("Tim");
            Assert.True(bob.hasId("Tim"));
        }
        [Test]
        public void testRetrieveNonexistant() {
            Assert.Null(patrons.findPatronById("nonesuch"));
        }
    }
}
