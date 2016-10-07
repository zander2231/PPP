using System.Collections.Generic;
using VS_Object_Mentor.ExcerciseOne.Data;
using VS_Object_Mentor.ExcerciseOne.Models;

namespace VS_Object_Mentor.ExcerciseOne
{
    public class Catalog
    {
        private readonly DataServices ds;

        public Catalog(DataServices ds)
        {
            this.ds = ds;
        }

        /**
   * Adds a copy of a Book to the catalog
   * @param string
   * @return
   */

        public Book add(string string1)
        {
            //string is isbn - get the title from the isbnService
            //giving it the isbn
            var t = ds.findTitleByIsbn(string1);
            if (t == null)
                throw new IsbnDoesNotExistException();
            //addBook the copy if we found it
            return ds.addBook(t);
        }

        /**
   * Finds the copy by the isbn
   * @param string
   * @return
   */

        public Book find1(string string1)
        {
            return ds.findCopy1(string1);
        }

        /**
   * Using the string as an isbn, finds all
   * copies whether borrowed or in stock
   * @param string
   * @return
   */

        public List<Book> findList(string string1)
        {
            return ds.findMany(string1);
        }

        /**
   * How many?
   * @return
   */

        public int getCount()
        {
            return ds.countBooks();
        }

        /**
   * Returns true if the string (isbn) passed
   * in can be found in the gateway
   * @param string
   * @return
   */

        public bool exists(string string1)
        {
            return ds.canFindCopy(string1);
        }

        /**
   * Finds an AVAILABLE copy (i.e. one that exists
   * but is not borrowed)
   * @param string
   * @return
   */

        public Book find2(string string1)
        {
            return ds.findAvailableCopy(string1);
        }

        /**
   * Finds the copy by the id
   * @param string
   * @return
   */

        public Book find3(string string1)
        {
            return ds.findCopy2(string1);
        }
    }
}