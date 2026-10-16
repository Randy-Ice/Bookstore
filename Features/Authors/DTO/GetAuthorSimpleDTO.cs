namespace Bookstore.Features.Authors.DTO
{
    public class GetAuthorSimpleDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? AuthorImage { get; set; }

    }
}
