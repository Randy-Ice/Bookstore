namespace Bookstore.Features.Authors.DTO
{
    public class AuthorBookDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }
        public string? BookImage { get; set; }

        public Guid CategoryId { get; set; }

    }
}
