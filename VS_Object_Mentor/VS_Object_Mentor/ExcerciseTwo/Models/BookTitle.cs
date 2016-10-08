namespace VS_Object_Mentor.ExcerciseTwo.Models
{
    public class BookTitle
    {
        private readonly string isbn;

        public BookTitle(string isbn)
        {
            this.isbn = isbn;
        }

        public string getIsbn()
        {
            return isbn;
        }
    }
}