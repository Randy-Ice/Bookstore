using Bookstore.Data;
using Bookstore.Features.Reviews.DTO;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Features.Reviews
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly BookstoreDB _db;
        public ReviewController(BookstoreDB db)
        {
            _db = db;
        }

        [HttpPost]
        [Authorize(Roles = "RegisteredUser")]
        public async Task<IActionResult> Post(PostReviewDTO dto)
        {
            var review = dto.Adapt<Review>();
            _db.Reviews.Add(review);
            await _db.SaveChangesAsync();
            return Ok(review);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "RegisteredUser")]
        public async Task<IActionResult> Put(Guid id, PostReviewDTO dto)
        {
            var review = await _db.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            dto.Adapt(review);
            await _db.SaveChangesAsync();
            return Ok(review);
        }
    }
}
