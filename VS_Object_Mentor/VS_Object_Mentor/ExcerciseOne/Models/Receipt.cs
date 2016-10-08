using System;

namespace VS_Object_Mentor.ExcerciseOne.Models
{
  public class Receipt {
  public static readonly int OK = 1;
  public static readonly int NO_SUCH_BOOK = 2;

  private int stat;
  private DateTime d;
  private Patron p;
  private Book c;

  public Receipt(Patron p) {
    this.p = p;
  }

  public int getStatus() {
    return stat;
  }

  public void setStatus(int stat) {
    this.stat = stat;
  }

  /**
   * Returns the return date
   * @return
   */
  public DateTime getDate() {
    return d;
  }

  /**
   * Sets the return date
   * @param d
   */
  public void setDate(DateTime d) {
    this.d = d;
  }

  /**
   * Returns the patron who borrowed the book
   * @return
   */
  public Patron getPatron() {
    return p;
  }

  /**
   * Returns the exact copy instance that is
   * associated with this specific receipt
   * @return
   */
  public Book getCopy() {
    return c;
  }

  /**
   * Sets the copy
   * @param c
   */
  public void setCopy(Book c) {
    this.c = c;
  }
}
}
