using System.Text;

namespace VS_Object_Mentor.ExcerciseTwo.Models
{
    public class Patron
    {
        private readonly string city;
        private readonly string firstName;
        private readonly string lastName;
        private readonly string middleInitial;
        private readonly string state;
        private readonly string street;
        private readonly string street2;
        private readonly string zip;

        private readonly string id;

        public Patron(string id, string firstName, string middleInitial,
            string lastName, string street, string street2, string city,
            string state, string zip, string phone)
        {
            this.id = id;
            this.firstName = firstName;
            this.middleInitial = middleInitial;
            this.lastName = lastName;
            this.street = street;
            this.street2 = street2;
            this.city = city;
            this.state = state;
            this.zip = zip;
        }

        public Patron(string id)
            : this(id, "", "", "", "", "", "", "", "", "")
        {
        }

        public bool hasId(string expectedId)
        {
            return id == expectedId;
        }

        public string getId()
        {
            return id;
        }

        public string getFullName()
        {
            var builder = new StringBuilder(firstName);
            if (middleInitial != null)
                builder.Append(" ").Append(middleInitial).Append(".");
            return builder.Append(" ").Append(lastName).ToString();
        }

        public object printAddress()
        {
            var builder = new StringBuilder(street);
            if (street2 != null)
                builder.Append("\n").Append(street2);
            return builder.Append("\n").Append(city).Append(", ")
                .Append(state).Append(" ").Append(zip).ToString();
        }
    }
}