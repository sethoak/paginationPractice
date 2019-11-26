using System.Collections.Generic;
using System.Linq;

namespace GenericsExample
{
    public class DVDPager
    {
        public int CurrentPage { get; set; }
        public int RecordsPerPage { get; set; } = 5;
        public List<DVD> AllRecords { get; set; }
        public List<DVD> GetCurrentPage()
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
        public List<DVD> GetPreviousPage()
        {
            //using a decrement, taking '1' off of it
            CurrentPage--;
            return GetCurrentPage();
        }
        public List<DVD> GetNextPage()
        {
            //adding '1' to it
            CurrentPage++;
            return GetCurrentPage();
        }
    }
}