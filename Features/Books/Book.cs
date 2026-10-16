using Bookstore.Features.Authors;
using Bookstore.Features.Categories;
using Bookstore.Features.Reviews;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Features.Books
{
    public class Book
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [Precision(6, 2)]//Max price 9999.99
        public decimal Price { get; set; } = 1.99m;
        public string? BookImage { get; set; }
        public short NumberOfPages { get; set; }
        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }
        public string ReleaseDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public List<Review> Reviews { get; set; } = new();

        //Navigation properties
        public Author Author { get; set; }
        public Category Category { get; set; }

    }
}
