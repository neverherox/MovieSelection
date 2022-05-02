using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieSelection.Models.RequestModels;
using MovieSelection.Data.Context;
using MovieSelection.Models.Entities;

namespace MovieSelection.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieSelectionContext _context;
        private readonly IMapper _mapper;

        public MoviesController(MovieSelectionContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetMovie>> GetMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            var getMovie = new GetMovie
            {
                Id = movie.Id,
                Name = movie.Name,
                Description = movie.Description,
                Image = movie.Image,
                Year = movie.Year,
                Country = _context.Countries.FirstOrDefault(x => x.Id == movie.CountryId)?.Name,
                Genres = _context.MovieGenres
                       .Where(x => x.MovieId == movie.Id)
                       .Select(x => _context.Genres.First(y => y.Id == x.GenreId).Name)
                       .ToList()
            };

            return getMovie;
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
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

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie([FromForm] PostMovie movie)
        {
            var movieEntity = _mapper.Map<Movie>(movie);
            _context.Movies.Add(movieEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movieEntity.Id }, movieEntity);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}/actors")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetActors(int id)
        {
            return await _context
                .MovieActors
                .Where(x => x.MovieId == id)
                .Select(x => _context.Actors.First(y => x.ActorId == y.Id))
                .ToListAsync();
        }

        [HttpGet("{id}/reviews")]
        public async Task<ActionResult<IEnumerable<GetReview>>> GetReviews(int id)
        {
            return await _context
                .Reviews
                .Where(x => x.MovieId == id)
                .Select(x => new GetReview
                {
                    Id = x.Id,
                    Text = x.Text,
                    UserName = _context.Users.First(y => y.Id == x.UserId).Name,
                    ReviewDate = x.ReviewDate
                })
                .ToListAsync();
        }

        [HttpGet("{id}/rate")]
        public async Task<ActionResult<GetRate>> GetRate(int id)
        {
            var value = await _context.Rates
                .Where(x => x.MovieId == id)
                .Select(x => x.Value)
                .DefaultIfEmpty()
                .AverageAsync();

            var directing = await _context.Rates
                .Where(x => x.MovieId == id)
                .Select(x => x.Directing)
                .DefaultIfEmpty()
                .AverageAsync();

            var entertainment = await _context.Rates
                .Where(x => x.MovieId == id)
                .Select(x => x.Entertainment)
                .DefaultIfEmpty()
                .AverageAsync();

            var plot = await _context.Rates
                .Where(x => x.MovieId == id)
                .Select(x => x.Plot)
                .DefaultIfEmpty()
                .AverageAsync();

            var actors = await _context.Rates
                .Where(x => x.MovieId == id)
                .Select(x => x.Actors)
                .DefaultIfEmpty()
                .AverageAsync();

            var valuesCount = await _context
                .Rates
                .Where(x => x.MovieId == id)
                .CountAsync();

            var rate = new GetRate
            {
                Value = value,
                Directing = directing,
                Entertainment = entertainment,
                Plot = plot,
                Actors = actors,
                ValuesCount = valuesCount
            };

            return rate;
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
