using System;
using VS_Object_Mentor.ExcerciseOne.Data;
using VS_Object_Mentor.ExcerciseOne.Models;

namespace VS_Object_Mentor.ExcerciseOne
{
    public class Library
    {
        private readonly Catalog c;
        private readonly DataServices ds;
        private DateTime tmpDate;

        public Library(DataServices ds)
        {
            c = new Catalog(ds);
            this.ds = ds;
        }

        public Book acceptBook(string isbn)
        {
            return c.add(isbn);
        }

        /**
   * 
   * @param string1 is the id of the copy (not the ISBN)
   * @param string2 is the id of the Patron borrowing the book
   * @return book
   */

        public Receipt borrow(string string1, string string2)
        {
            //find the copy using the find method that uses the ID
            var c2 = c.find3(string1);

            //find the patron using the patron id
            var p = ds.findPatron(string2);

            //make a receipt
            var r = new Receipt(p);

            //20040314 rcm SPR#12443432
            //20050519 jwg SPR#77452233
            //20050520 dac SPR#78552342
            //if there is a copy of the book, set the status to no such book
            if (c2 == null)
                r.setStatus(Receipt.NO_SUCH_BOOK);
            //otherwise...
            else
            {
                c2.setBorrowed(r);
                r.setStatus(Receipt.OK);
                r.setCopy(c2);
                var d = tmpDate == null ? new DateTime() : tmpDate;
                var d2 = d.AddDays(14);
                r.setDate(d2);
            }
            return r;
        }

        public void setTmpDate(DateTime d)
        {
            tmpDate = d;
        }
    }
}