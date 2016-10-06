namespace VS_Object_Mentor.Models.One
{
    public class Book
    {
        private BookTitle t;
        private string id;
        private Receipt r;

        public Book(BookTitle t, string string1)
        {
            this.t = t;
            this.id = string1;
        }

        public BookTitle getTitle()
        {
            return t;
        }

        public void setTitle(BookTitle t)
        {
            this.t = t;
        }

        public bool isBorrowed()
        {
            return r != null;
        }

        public string getId()
        {
            return id;
        }

        public Receipt getReceipt()
        {
            return r;
        }

        public void setBorrowed(Receipt r)
        {
            this.r = r;
        }
    }
}