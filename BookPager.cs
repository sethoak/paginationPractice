using System.Collections.Generic;
using System.Linq;

namespace GenericsExample
{
    public class BookPager
    {
        public int CurrentPage { get; set; }
        public int RecordsPerPage { get; set; } = 5;
        public List<Book> AllRecords { get; set; }
        public List<Book> GetCurrentPage()
        {
            var skipAmount = CurrentPage * RecordsPerPage;

            return AllRecords
                //allows skipping of 5 for the different pages
                //when it's on the first page, it displays the first 5.
                .Skip(skipAmount)
                //grabs next '5'
                .Take(RecordsPerPage)
                .ToList();
        }
        public List<Book> GetPreviousPage()
        {
            //using a decrement, taking '1' off of it
            CurrentPage--;
            return GetCurrentPage();
        }
        public List<Book> GetNextPage()
        {
            //adding '1' to it
            CurrentPage++;
            return GetCurrentPage();
        }
    }
}