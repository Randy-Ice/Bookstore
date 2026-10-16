using System.ComponentModel.DataAnnotations;

namespace Bookstore.Features.Books.DTO
{
    public class GetBookSimpleDTO
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string? BookImage { get; set; }
        public BookAuthorDTO Author { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
