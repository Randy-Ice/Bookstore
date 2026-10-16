using System.ComponentModel.DataAnnotations;

namespace Bookstore.Features.Categories.DTO
{
    public class PutCategoryDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        public string Name { get; set; }
    }
}
