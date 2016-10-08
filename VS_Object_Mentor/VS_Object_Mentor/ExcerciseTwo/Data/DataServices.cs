using System.Collections.Generic;
using VS_Object_Mentor.ExcerciseTwo.Models;

namespace VS_Object_Mentor.ExcerciseTwo.Data
{
    public interface DataServices
    {
        // ADD FUNCTIONS------------------------
        BookCopy addCopy(BookTitle bookTitle);

        void addPatron(Patron patron);

        // FIND FUNCTIONS------------------------
        BookCopy findCopy(string isbn);

        BookTitle findTitleByIsbn(string isbn);

        List<BookCopy> findAllCopies(string isbn);

        BookCopy findAvailableCopy(string isbn);

        BookCopy findCopyById(string copyId);

        Patron findPatronById(string id);

        // BOOLEAN QUERIES-----------------------
        bool containsTitle(string isbn);

        // COUNT QUERIES-------------------------
        int countActivePatrons();

        int bookCount();
    }
}