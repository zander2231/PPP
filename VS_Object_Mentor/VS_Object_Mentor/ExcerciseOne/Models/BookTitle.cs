namespace VS_Object_Mentor.ExcerciseOne.Models
{
    public class BookTitle
    {
        private readonly string isbn;

        public BookTitle(string string1)
        {
            this.isbn = string1;
        }

        public string getIsbn()
        {
            return isbn;
        }

    }
}
