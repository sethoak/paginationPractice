using System.Collections.Generic;
using System.Linq;

namespace GenericsExample
{
    //taking a type parameter with the <T>. Telling it what type of 'thing' to use/variable for a type.
    public class Pager<T>
    {
        private List<T> _allRecords;

        public int CurrentPage { get; set; }
        public int RecordsPerPage { get; set; } = 5;

        public Pager(List<T> allRecords)
        {
            _allRecords = allRecords;
        }

        public List<T> GetCurrentPage()
        {
            //refer to the .Skip. It is 0 * 5 will display the first 5
            var skipAmount = CurrentPage * RecordsPerPage;

            return _allRecords
                //allows skipping of 5 for the different pages
                //when it's on the first page, it displays the first 5.
                .Skip(skipAmount)
                //grabs next '5'
                .Take(RecordsPerPage)
                .ToList();
        }
        public List<T> GetPreviousPage()
        {
            //using a decrement, taking '1' off of it
            CurrentPage--;
            return GetCurrentPage();
        }
        public List<T> GetNextPage()
        {
            //adding '1' to it
            CurrentPage++;
            return GetCurrentPage();
        }
    }
}