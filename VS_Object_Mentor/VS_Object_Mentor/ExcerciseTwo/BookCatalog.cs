using System.Collections.Generic;
using VS_Object_Mentor.ExcerciseTwo.Data;
using VS_Object_Mentor.ExcerciseTwo.Models;

namespace VS_Object_Mentor.ExcerciseTwo
{
    public class BookCatalog
    {
        private readonly DataServices dataServices;

        public BookCatalog(DataServices dataServices)
        {
            this.dataServices = dataServices;
        }

        public BookCopy addCopy(string isbn)
        {
            var bookTitle = dataServices.findTitleByIsbn(isbn);
            if (bookTitle == null)
                throw new IsbnDoesNotExistException();
            return dataServices.addCopy(bookTitle);
        }

        public BookCopy findCopy(string isbn)
        {
            return dataServices.findCopy(isbn);
        }

        public List<BookCopy> findAllCopies(string isbn)
        {
            return dataServices.findAllCopies(isbn);
        }

        public int bookCount()
        {
            return dataServices.bookCount();
        }

        public bool containsTitle(string isbn)
        {
            return dataServices.containsTitle(isbn);
        }

        public BookCopy findAvailableCopy(string isbn)
        {
            return dataServices.findAvailableCopy(isbn);
        }

        public BookCopy findCopyById(string copyId)
        {
            return dataServices.findCopyById(copyId);
        }
    }
}