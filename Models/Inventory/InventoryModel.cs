namespace LibraryTravelApi.Models.Inventory
{
    public class InventoryModel
    {
        public int IdAuthor { get; set; }
        public int ISBNBook { get; set; }
        public string Author { get; set; }
        public string Book { get; set; }
        public string Synopsis { get; set; }
        public int NumberPages { get; set; }
        public string Editorial { get; set; }
        public string Campus { get; set; }
    }
}
