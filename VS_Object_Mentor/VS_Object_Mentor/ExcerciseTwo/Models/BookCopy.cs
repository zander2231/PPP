
namespace VS_Object_Mentor.ExcerciseTwo.Models
{
    public class BookCopy {
        private BookTitle title;
        private string id;
        private Receipt receipt;

        public BookCopy(BookTitle title, string id) {
            this.title = title;
            this.id = id;
        }

        public BookTitle getBookTitle() {
            return title;
        }

        public void setTitle(BookTitle title) {
            this.title = title;
        }

        public bool isBorrowed() {
            return receipt != null;
        }

        public string getId() {
            return id;
        }

        public Receipt getBorrowReceipt() {
            return receipt;
        }

        public void setBorrowed(Receipt receipt) {
            this.receipt = receipt;
        }
    }
}
