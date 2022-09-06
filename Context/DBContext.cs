using Microsoft.EntityFrameworkCore;

namespace LibraryTravelApi.Context
{
    public class DBContext: DbContext
    {
        public DBContext()
        {

        }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public virtual DbSet<Models.Author.AuthorModel> AuthorModel { get; set; }
        public virtual DbSet<Models.Book_Author.BookAuthorModel> BookAuthor { get; set; }
        public virtual DbSet<Models.Book.BookModel> BookModel  { get; set; }
        public DbSet<Models.Editorial.EditorialModel> editorialModel  { get; set; }

    }

}
