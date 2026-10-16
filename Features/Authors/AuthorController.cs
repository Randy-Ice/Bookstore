using Bookstore.Data;
using Bookstore.Features.Authors.DTO;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Features.Authors
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly BookstoreDB _db;
        public AuthorController(BookstoreDB db)
        {
            _db = db;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            var authors = await _db.Authors.ToListAsync();
            return Ok(authors.Adapt<IEnumerable<GetAuthorSimpleDTO>>());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var author = await _db.Authors
                .Include(x => x.Books)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author.Adapt<GetAuthorDetailsDTO>());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(PostAuthorDTO dto)
        {
            var author = dto.Adapt<Author>();
            await _db.Authors.AddAsync(author);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = author.Id }, author.Adapt<GetAuthorDetailsDTO>());
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(Guid id, PutAuthorDTO dto)
        {
            var author = await _db.Authors.FirstOrDefaultAsync(x => x.Id == id);
            if (author == null)
            {
                return NotFound();
            }
            dto.Adapt(author);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var author = await _db.Authors.FirstOrDefaultAsync(x => x.Id == id);
            if (author == null)
            {
                return NotFound();
            }
            _db.Authors.Remove(author);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
