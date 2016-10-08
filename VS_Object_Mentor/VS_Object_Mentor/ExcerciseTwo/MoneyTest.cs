using NUnit.Framework;

namespace VS_Object_Mentor.ExcerciseTwo
{
    [TestFixture]
    public class MoneyTest{
        [Test]
        public void testEqualityShouldPassWithEqualValues() {
            Assert.That(new Money(0), Is.EqualTo(new Money(0)));
        }

        [Test]
        public void testEqualityShouldFailWithUnequalValues() {
            Assert.False(new Money(0).Equals(new Money(1)));
        }

        [Test]
        public void testEqualityShouldFailOnNull() {
            Money money = null;
            Assert.False(new Money(0).Equals(money));
        }

        [Test]
        public void testEqualityShouldFailOnWrongType() {
            Assert.False(new Money(0).Equals("I am not money"));
        }

    }
}
