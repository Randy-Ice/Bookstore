namespace Bookstore.Features.Books.DTO
{
    public class GetBookDetailsDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? BookImage { get; set; }
        public short NumberOfPages { get; set; }
        public BookAuthorDTO Author { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<BookReviewDTO> Reviews { get; set; }


    }
}
