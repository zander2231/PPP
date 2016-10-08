using System;
using VS_Object_Mentor.ExcerciseTwo.Data;
using VS_Object_Mentor.ExcerciseTwo.Models;
using VS_Object_Mentor.ExcerciseTwo.Utils;

namespace VS_Object_Mentor.ExcerciseTwo
{
    public class Library
    {
        private readonly BookCatalog catalog;
        private readonly DataServices dataServices;
        private TimeSource timeSource;

        public Library(DataServices dataServices)
        {
            this.dataServices = dataServices;
            catalog = new BookCatalog(dataServices);
            timeSource = new StandardTimeSource();
        }

        public BookCopy acceptBook(string isbn)
        {
            return catalog.addCopy(isbn);
        }

        public Receipt borrow(string copyId, string borrowerId)
        {
            var copy = catalog.findCopyById(copyId);
            var borrower = dataServices.findPatronById(borrowerId);
            var borrowReceipt = new Receipt(borrower, Receipt.BORROW_RECEIPT);
            if (copy == null)
                borrowReceipt.setStatus(Receipt.UNKNOWN_BOOK);
            else
            {
                copy.setBorrowed(borrowReceipt);
                borrowReceipt.setStatus(Receipt.OK);
                borrowReceipt.setCopy(copy);
                borrowReceipt.setReturnDate(getReturnDate());
            }
            return borrowReceipt;
        }

        private DateTime getReturnDate()
        {
            var now = timeSource.getTime();
            return now.AddDays(14);
        }

        public void setTimeSource(TimeSource timeSource)
        {
            this.timeSource = timeSource;
        }

        public Receipt returnCopy(string copyId)
        {
            var copy = catalog.findCopyById(copyId);
            var receipt = new Receipt(Receipt.RETURN_RECEIPT);
            if (copy == null)
            {
                receipt.setStatus(Receipt.UNKNOWN_BOOK);
            }
            else if (!copy.isBorrowed())
            {
                receipt.setStatus(Receipt.UNBORROWED_BOOK);
                receipt.setCopy(copy);
            }
            else
            {
                var borrowReceipt = copy.getBorrowReceipt();
                if (timeSource.getTime().CompareTo(borrowReceipt.getDueDate()) > 0)
                {
                    receipt.setStatus(Receipt.LATE);
                    receipt.setFine(calculateFine(receipt));
                }
                else
                {
                    receipt.setStatus(Receipt.OK);
                }
                copy.setBorrowed(null);
                receipt.setCopy(copy);
            }

            return receipt;
        }

        private Money calculateFine(Receipt receipt)
        {
            var days = DateUtil.daysLate(timeSource.getTime(), receipt.getDueDate());
            return new Money(days*50);
        }
    }
}