using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieSelection.Data.Context;
using MovieSelection.Models.Entities;
using MovieSelection.Models.RequestModels;

namespace MovieSelection.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MovieSelectionContext _context;

        public UsersController(MovieSelectionContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}/savings")]
        [Authorize(Roles = "user")]
        public async Task<ActionResult<IEnumerable<GetSaving>>> GetSavings(Guid id)
        {
            return await _context
                .Savings
                .Where(x => x.UserId == id)
                .Select(x => new GetSaving
                {
                    Id = x.Id,
                    Movie = new GetMovie
                    {
                        Id = x.Movie.Id,
                        Name = x.Movie.Name,
                        Description = x.Movie.Description,
                        Image = x.Movie.Image,
                        Year = x.Movie.Year,
                        Country = x.Movie.Country,
                        Genres = x.Movie.MovieGenres.Select(y => y.Genre).ToList(),
                        Rate = _context.Rates.Where(y => y.MovieId == x.Id).Select(y => y.Value).DefaultIfEmpty().Average(),
                        Savings = x.Movie.Savings.ToList()
                    },
                    IsWatched = x.IsWatched
                })
                .ToListAsync();
        }

        private bool UserExists(Guid id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
