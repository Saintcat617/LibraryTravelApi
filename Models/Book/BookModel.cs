using System;

namespace LibraryTravelApi.Models.Book
{
    public class BookModel
    {
        public int ISBN { get; set; }
        public int Id_Editorial { get; set; }
        public string Book_Title { get; set; }
        public string Synopsis { get; set; }
        public int Number_Page { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
