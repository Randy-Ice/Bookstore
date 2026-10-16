namespace Bookstore.Features.Authors.DTO
{
    public class GetAuthorDetailsDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Bio { get; set; }
        public string Contact { get; set; }
        public string? AuthorImage { get; set; }
        public List<AuthorBookDTO> Books { get; set; }
    }
}
