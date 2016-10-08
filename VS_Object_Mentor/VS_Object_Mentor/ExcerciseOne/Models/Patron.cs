namespace VS_Object_Mentor.ExcerciseOne.Models
{
    public class Patron
    {
        private readonly string id;

        public Patron(string string1, string string2, string string3,
            string string4, Address address, string string5)
        {
            //string1 is id
            //string2 is first name
            //string3 is middle initial
            //string4 is last name
            //string5 is either phone or zip - can't remember which
            id = string1;
        }

        public Patron(string id) : this(id, "", "", "", new Address("", "", "", "", ""), "")
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
    }
}