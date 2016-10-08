using System.Collections.Generic;
using NUnit.Framework;
using VS_Object_Mentor.ExcerciseOne.Data;
using VS_Object_Mentor.ExcerciseOne.Mocks;
using VS_Object_Mentor.ExcerciseOne.Models;

namespace VS_Object_Mentor.ExcerciseOne
{
    [TestFixture]
    public class CatalogTest
    {
        [Test]
        public void testCatalog()
        {
            MockDataServices ds;
            Catalog c;
            ds = new MockDataServices();
            c = new Catalog(ds);
            // empty tests
            Assert.That(0, Is.EqualTo(c.getCount()), "expected empty catalog");
            Assert.False(c.exists("book"));
            Assert.Throws<KeyNotFoundException>(() => c.find2("book"));
            // one book test
            ds.setBookToReturn(new BookTitle("ISBN"));
            var b1 = c.add("ISBN");
            Assert.That("ISBN", Is.EqualTo(ds.wasLastCalledWithThisIsbn));
            Assert.That(ds.added.getTitle(), Is.EqualTo(b1.getTitle()));
            Assert.Throws<KeyNotFoundException>(() => c.find1("NOT ISBN"));
            Assert.NotNull(c.find1("ISBN"));
            Assert.True(c.exists("ISBN"));
            Assert.False(c.exists("NOT ISBN"));
            Assert.NotNull(c.find2("ISBN"));
            // multiple books
            ds.setBookToReturn(new BookTitle("ISBN 2"));
            var b2 = c.add("ISBN 2");
            Assert.That(b1, Is.SameAs(c.find1("ISBN")));
            Assert.That(b2, Is.SameAs(c.find1("ISBN 2")));
            // borrow one of one
            var copies = c.findList("ISBN 2");
            var bb = copies[0];
            bb.setBorrowed(new Receipt(new Patron("borrower")));
            Assert.Null(c.find2("ISBN 2"));
            // non-existant
            try
            {
                c.add("NON-EXISTENT ISBN");
                Assert.Fail();
            }
            catch (IsbnDoesNotExistException e)
            {
            }
            // multiple copies
            var b1_2 = c.add("ISBN");
            var cl = c.findList("ISBN");
            Assert.That(2, Is.EqualTo(cl.Count));
            Assert.True(cl.Contains(b1));
            Assert.True(cl.Contains(b1_2));
            // borrow one of many
            bb = cl[0];
            bb.setBorrowed(new Receipt(new Patron("borrower")));
            Assert.NotNull(c.find2("ISBN"));
        }
    }
}