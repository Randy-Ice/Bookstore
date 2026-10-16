namespace Bookstore.Features.Authors.DTO
{
    public class PutAuthorDTO
    {
        public string Name { get; set; }
        public string? Bio { get; set; }
        public string Contact { get; set; }
        public string? AuthorImage { get; set; }
    }
}
