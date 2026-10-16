using Bookstore.Data;
using Bookstore.Features.Categories.DTO;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Features.Categories
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly BookstoreDB _db;
        public CategoryController(BookstoreDB db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _db.Categories.ToListAsync();
            return Ok(categories.Adapt<IEnumerable<GetCataegoryDTO>>());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category.Adapt<GetCataegoryDTO>());
        }



        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(PostCategoryDTO dto)
        {
            var category = dto.Adapt<Category>();
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category.Adapt<GetCataegoryDTO>());
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(Guid id, PutCategoryDTO dto)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            dto.Adapt(category);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();
            return NoContent();
        }


    }//Controller end
}//Namespace end
