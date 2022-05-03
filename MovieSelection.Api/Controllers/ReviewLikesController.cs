using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieSelection.Data.Context;
using MovieSelection.Models.Entities;

namespace MovieSelection.Api.Controllers
{
    [Route("api/review-likes")]
    [ApiController]
    public class ReviewLikesController : ControllerBase
    {
        private readonly MovieSelectionContext _context;

        public ReviewLikesController(MovieSelectionContext context)
        {
            _context = context;
        }

        // GET: api/ReviewLikes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewLike>>> GetReviewLikes()
        {
            return await _context.ReviewLikes.ToListAsync();
        }

        // GET: api/ReviewLikes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewLike>> GetReviewLike(int id)
        {
            var reviewLike = await _context.ReviewLikes.FindAsync(id);

            if (reviewLike == null)
            {
                return NotFound();
            }

            return reviewLike;
        }

        // PUT: api/ReviewLikes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReviewLike(int id, ReviewLike reviewLike)
        {
            if (id != reviewLike.Id)
            {
                return BadRequest();
            }

            _context.Entry(reviewLike).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewLikeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ReviewLikes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "user")]
        public async Task<ActionResult<ReviewLike>> PostReviewLike(ReviewLike reviewLike)
        {
            _context.ReviewLikes.Add(reviewLike);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReviewLike", new { id = reviewLike.Id }, reviewLike);
        }

        // DELETE: api/ReviewLikes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReviewLike(int id)
        {
            var reviewLike = await _context.ReviewLikes.FindAsync(id);
            if (reviewLike == null)
            {
                return NotFound();
            }

            _context.ReviewLikes.Remove(reviewLike);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReviewLikeExists(int id)
        {
            return _context.ReviewLikes.Any(e => e.Id == id);
        }
    }
}
