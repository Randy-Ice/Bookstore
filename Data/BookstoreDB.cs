using Bookstore.Features.Authors;
using Bookstore.Features.Books;
using Bookstore.Features.Categories;
using Bookstore.Features.Reviews;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Data
{
    public class BookstoreDB : DbContext
    {
        public BookstoreDB(DbContextOptions<BookstoreDB> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
