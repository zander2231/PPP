namespace VS_Object_Mentor.Models.One
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
