using System.Collections.Generic;
using VS_Object_Mentor.ExcerciseTwo.Data;
using VS_Object_Mentor.ExcerciseTwo.Models;

namespace VS_Object_Mentor.ExcerciseTwo.Mocks
{
    public class MockDataServices : DataServices
    {
        private static long lastId;
        public BookCopy addedBookCopy;
        private readonly Dictionary<string, List<BookCopy>> bookCopies = new Dictionary<string, List<BookCopy>>();

        private readonly Dictionary<string, Patron> patronMap = new Dictionary<string, Patron>();
        private readonly Dictionary<string, BookTitle> titles = new Dictionary<string, BookTitle>();

        public string wasLastCalledWithThisIsbn;

        public BookCopy addCopy(BookTitle bookTitle)
        {
            var bookCopy = new BookCopy(bookTitle, "" + ++lastId);
            var isbn = bookTitle.getIsbn();
            if (!bookCopies.ContainsKey(isbn))
                bookCopies.Add(isbn, new List<BookCopy>());
            var copies = bookCopies[isbn];
            copies.Add(bookCopy);
            addedBookCopy = bookCopy;
            return bookCopy;
        }

        public BookCopy findCopy(string isbn)
        {
            var copies = bookCopies[isbn];
            if (copies != null)
                return copies[0];
            return null;
        }

        public int bookCount()
        {
            return bookCopies.Count;
        }

        public List<BookCopy> findAllCopies(string isbn)
        {
            var copies = bookCopies[isbn];
            if (copies == null)
                return new List<BookCopy>();
            return copies;
        }

        public bool containsTitle(string isbn)
        {
            return bookCopies.ContainsKey(isbn);
        }

        public BookCopy findAvailableCopy(string isbn)
        {
            var copies = findAllCopies(isbn);
            for (var i = 0; i < copies.Count; i++)
            {
                var copy = copies[i];
                if (!copy.isBorrowed())
                    return copy;
            }
            return null;
        }

        public BookCopy findCopyById(string copyId)
        {
            var listsOfCopies = bookCopies.Values;
            for (var i = listsOfCopies.GetEnumerator(); i.MoveNext();)
            {
                var copies = i.Current;
                for (var j = 0; j < copies.Count; j++)
                {
                    var bookCopy = copies[j];
                    if (bookCopy.getId().Equals(copyId))
                        return bookCopy;
                }
            }
            return null;
        }

        public BookTitle findTitleByIsbn(string isbn)
        {
            wasLastCalledWithThisIsbn = isbn;
            if (titles.ContainsKey(isbn))
                return titles[isbn];
            return null;
        }

        public int countActivePatrons()
        {
            return patronMap.Count;
        }

        public void addPatron(Patron patron)
        {
            patronMap.Add(patron.getId(), patron);
        }

        public Patron findPatronById(string id)
        {
            if (patronMap.ContainsKey(id))
                return patronMap[id];
            return null;
        }

        public void setBookToReturn(BookTitle title)
        {
            titles[title.getIsbn()] = title;
        }
    }
}