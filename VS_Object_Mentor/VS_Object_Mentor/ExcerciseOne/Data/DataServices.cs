using System.Collections.Generic;
using VS_Object_Mentor.ExcerciseOne.Models;

namespace VS_Object_Mentor.ExcerciseOne.Data
{
    public interface DataServices
    {
        // ADD FUNCTIONS---------------------
        /**
	 * Adds a book title
	 * 
	 * @param bt
	 * @return
	 */
        Book addBook(BookTitle bt);

        /**
	 * Adds a patron
	 * 
	 * @param patron
	 * @return
	 */
        void addPatron(Patron patron);

        /**
	 * Finds a book copy using the isbn
	 * 
	 * @param string
	 *            (isbn)
	 * @return
	 */

        // FIND and QUERY METHODS--------------------------------------
        Book findCopy1(string string1);

        /**
	 * Returns the number of different books (not individual copies)
	 * 
	 * @return
	 */
        int countBooks();

        /**
	 * Returns all copies of all books
	 * 
	 * @param string
	 *            (isbn)
	 * @return
	 */
        List<Book> findMany(string string1);

        /**
	 * Returns true if any books w/ this isbn are stored
	 * 
	 * @param string
	 *            (isbn)
	 * @return
	 */
        bool canFindCopy(string string1);

        /**
	 * Returns the first copy found that is not also borrowed
	 * 
	 * @param string
	 * @return
	 */
        Book findAvailableCopy(string string1);

        /**
	 * Finds a book copy using the copy id
	 * 
	 * @param string
	 *            (copy id)
	 * @return
	 */
        Book findCopy2(string string1);

        /**
	 * Returns the number of different patrons (not individual copies)
	 * 
	 * @return
	 */
        int countActivePatrons(); // TODO - this should return null instead of throw
        // exception

        /**
	 * Finds a patron using the id
	 * 
	 * @param id
	 * @return
	 */
        Patron findPatron(string id);

        /**
	 * Returns a BookTitle object using the submitted String as an ISBN to match
	 * against it
	 * 
	 * @param string
	 * @return
	 */
        BookTitle findTitleByIsbn(string string1);
    }
}