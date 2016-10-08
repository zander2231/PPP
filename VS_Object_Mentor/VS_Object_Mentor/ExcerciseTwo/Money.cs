using System;

namespace VS_Object_Mentor.ExcerciseTwo
{
    public class Money {
        private int pennies;

        public Money(int pennies) {
            this.pennies = pennies;
        }

        public override bool Equals(object object1) {
            if (object1 == null || !(object1.GetType() == typeof(Money)))
            return false;

            Money that = (Money) object1;
            return Equals(that);
        }

        protected bool Equals(Money other)
        {
            return pennies == other.pennies;
        }

        public override int GetHashCode()
        {
            return pennies;
        }

        public int hashCode() {
            return pennies;
        }

        public String toString() {
            return "" + pennies;
        }
    }
}
