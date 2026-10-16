using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Features.Books.DTO
{
    public class PutBookDTO
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [Precision(6, 2)]//Max price 9999.99
        public decimal Price { get; set; }
        public string? BookImage { get; set; }
        public short NumberOfPages { get; set; }

    }
}
