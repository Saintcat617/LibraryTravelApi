using System;

namespace LibraryTravelApi.Models.Author
{
    public class AuthorModel
    {
        public int Id_Author { get; set; }
        public string Names { get; set; }
        public string Surnames { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
