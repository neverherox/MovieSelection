using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieSelection.Data.Context;
using MovieSelection.Data.Models;

namespace MovieSelection.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieImagesController : ControllerBase
    {
        private readonly MovieSelectionContext _context;

        public MovieImagesController(MovieSelectionContext context)
        {
            _context = context;
        }

        // GET: api/MovieImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieImage>>> GetMovieImages()
        {
            return await _context.MovieImages.ToListAsync();
        }

        // GET: api/MovieImages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieImage>> GetMovieImage(int id)
        {
            var movieImage = await _context.MovieImages.FindAsync(id);

            if (movieImage == null)
            {
                return NotFound();
            }


            return movieImage;
        }

        // PUT: api/MovieImages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieImage(int id, MovieImage movieImage)
        {
            if (id != movieImage.MovieId)
            {
                return BadRequest();
            }

            _context.Entry(movieImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieImageExists(id))
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

        // POST: api/MovieImages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovieImage>> PostMovieImage(int id, IFormFile image)
        {
            var movieImage = new MovieImage
            {
                MovieId = id
            };
            using (var ms = new MemoryStream())
            {
                await image.CopyToAsync(ms);
                movieImage.Image = ms.ToArray();
            }
            _context.MovieImages.Add(movieImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovieImage", new { id = movieImage.MovieId }, movieImage);
        }

        // DELETE: api/MovieImages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieImage(int id)
        {
            var movieImage = await _context.MovieImages.FindAsync(id);
            if (movieImage == null)
            {
                return NotFound();
            }

            _context.MovieImages.Remove(movieImage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieImageExists(int id)
        {
            return _context.MovieImages.Any(e => e.MovieId == id);
        }
    }
}
