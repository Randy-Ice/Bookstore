using Bookstore.Features.Books;

namespace Bookstore.Features.Authors
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Bio { get; set; }
        public string Contact { get; set; }
        public string? AuthorImage { get; set; }
        public List<Book> Books { get; set; } = new();

    }
}
