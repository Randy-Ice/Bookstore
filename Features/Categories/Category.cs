using System.ComponentModel.DataAnnotations;

namespace Bookstore.Features.Categories
{
    public class Category
    {
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
