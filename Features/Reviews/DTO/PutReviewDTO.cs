using System.ComponentModel.DataAnnotations;

namespace Bookstore.Features.Reviews.DTO
{
    public class PutReviewDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MinLength(15, ErrorMessage = "Leave a reasonable review please, at least 15 characters.")]
        public string Content { get; set; }

    }
}
