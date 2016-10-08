
using VS_Object_Mentor.ExcerciseTwo.Models;

namespace VS_Object_Mentor.ExcerciseTwo
{
    public class PrintUsage {
        int totalDue;
        const int perPageRate = 5;

        public PrintUsage(Patron patron) {
            totalDue = 0;
        }

        public int charges() {
            return totalDue;
        }

        public void pagePrinted(PrintRecord printRecord) {
            totalDue += printRecord.pages() * perPageRate;
        }


    }
}