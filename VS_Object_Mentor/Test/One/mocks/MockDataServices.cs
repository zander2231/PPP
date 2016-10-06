using System.Collections.Generic;
using VS_Object_Mentor.App_Data.One;
using VS_Object_Mentor.Models.One;

public class MockDataServices : DataServices
{
    private static long lastId;
    public Book added;
    private readonly Dictionary<string, List<Book>> map = new Dictionary<string, List<Book>>();
    private readonly Dictionary<string, Patron> patronMap = new Dictionary<string, Patron>();
    private readonly Dictionary<string, BookTitle> titleMap = new Dictionary<string, BookTitle>();
    public string wasLastCalledWithThisIsbn;

    public Book addBook(BookTitle string1)
    {
        var c = new Book(string1, "" + ++lastId);
        var isbn = string1.getIsbn();
        if (!map.ContainsKey(isbn)) map.Add(isbn, new List<Book>());
        var copies2 = map[isbn];

        copies2.Add(c);
        added = c;
        return c;
    }

    public Book findCopy1(string string1)
    {
        var copies2 = map[string1];
        if (copies2 != null)
            return copies2[0];
        return null;
    }

    public int countBooks()
    {
        return map.Count;
    }

    public List<Book> findMany(string isbn)
    {
        var copies2 = map[isbn];
        if (copies2 == null)
            return new List<Book>();
        return copies2;
    }

    public bool canFindCopy(string string1)
    {
        return map.ContainsKey(string1);
    }

    public Book findAvailableCopy(string isbn)
    {
        var copies2 = findMany(isbn);
        for (var i = 0; i < copies2.Count; i++)
        {
            var c = copies2[i];
            if (!c.isBorrowed())
                return c;
        }
        return null;
    }

    public Book findCopy2(string copyId)
    {
        var copies2 = map.Values;
        for (var i = copies2.GetEnumerator(); i.MoveNext();)
        {
            var copies3 = i.Current;
            for (var j = 0; j < copies3.Count; j++)
            {
                var c = copies3[j];
                if (c.getId().Equals(copyId))
                    return c;
            }
        }
        return null;
    }

    public int countActivePatrons()
    {
        return patronMap.Count;
    }

    public void addPatron(Patron p)
    {
        patronMap.Add(p.getId(), p);
    }

    public Patron findPatron(string string1)
    {
        return patronMap[string1];
    }

    public BookTitle findTitleByIsbn(string string1)
    {
        wasLastCalledWithThisIsbn = string1;
        return titleMap[string1];
    }

    public void setBookToReturn(BookTitle t)
    {
        titleMap.Add(t.getIsbn(), t);
    }
}