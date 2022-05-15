using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ML;
using MovieSelection.Data.Context;
using MovieSelection.Models.Entities;
using MovieSelection.Models.RequestModels;
using MovieSelection_Api.MLModel;
using System.Linq;

namespace MovieSelection.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MovieSelectionContext _context;
        private readonly PredictionEnginePool<RateMLModel.ModelInput, RateMLModel.ModelOutput> _predictionEnginePool;

        public UsersController(MovieSelectionContext context,
            PredictionEnginePool<RateMLModel.ModelInput, RateMLModel.ModelOutput> predictionEnginePool)
        {
            _context = context;
            _predictionEnginePool = predictionEnginePool;
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

        [HttpGet("{id}/rates")]
        [Authorize(Roles = "user")]
        public async Task<ActionResult<IEnumerable<GetUserRate>>> GetRates(Guid id)
        {
            return await _context
                .Rates
                .Where(x => x.UserId == id)
                .Select(x => new GetUserRate
                {
                    Directing = x.Directing,
                    Entertainment = x.Entertainment,
                    Actors = x.Actors,
                    Plot = x.Plot,
                    Value = x.Value,
                    Movie = new GetMovie
                    {
                        Id = x.Movie.Id,
                        Name = x.Movie.Name,
                        Description = x.Movie.Description,
                        Image = x.Movie.Image,
                        Year = x.Movie.Year,
                        Country = x.Movie.Country,
                        Genres = x.Movie.MovieGenres.Select(y => y.Genre).ToList(),
                        Rate = _context.Rates.Where(y => y.MovieId == x.Movie.Id).Select(y => y.Value).DefaultIfEmpty().Average(),
                        Savings = x.Movie.Savings.ToList()
                    }
                }).ToListAsync();
        }

        [HttpGet("{id}/recommendations/{top}")]
        [Authorize(Roles = "user")]
        public async Task<ActionResult<IEnumerable<GetMovie>>> GetRecommendations(Guid id, int top)
        {
            var userId = id.ToString();

            var allMovieIds = await _context.Rates
                .Select(x => x.MovieId)
                .Distinct()
                .ToListAsync();

            var ratedMovieIds = await _context
                .Rates
                .Where(x => x.UserId == id)
                .Select(x => x.MovieId)
                .Distinct()
                .ToListAsync();

            var notRatedMovieIds = allMovieIds
                .Except(ratedMovieIds)
                .ToList();

            var rateInputs = notRatedMovieIds
                .Select(x => new RateMLModel.ModelInput
                {
                    UserId = userId,
                    MovieId = x
                })
                .ToList();

            var predictions = new Dictionary<int,RateMLModel.ModelOutput>();
            foreach (var rateInput in rateInputs)
            {
                var prediction = _predictionEnginePool.Predict(rateInput);
                if (prediction.Score > 8)
                {
                    var intMovieId = Convert.ToInt32(rateInput.MovieId);
                    predictions.Add(intMovieId, prediction);
                }
            }
            
            var recommendations = new List<GetMovie>();
            foreach (var prediction in predictions.OrderByDescending(x => x.Value.Score).Take(top))
            {
                var movie = await _context.Movies
                    .Include(x => x.Country)
                    .Include(x => x.MovieGenres)
                    .ThenInclude(x => x.Genre)
                    .Include(x => x.Savings)
                    .FirstAsync(x => x.Id == prediction.Key);

                var recommendedMovie = new GetMovie
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    Description = movie.Description,
                    Image = movie.Image,
                    Year = movie.Year,
                    Country = movie.Country,
                    Genres = movie.MovieGenres.Select(y => y.Genre).ToList(),
                    Rate = _context.Rates.Where(y => y.MovieId == movie.Id).Select(y => y.Value).DefaultIfEmpty().Average(),
                    Savings = movie.Savings.ToList()
                };
                recommendations.Add(recommendedMovie);
            }
        
            return recommendations;
        }

        private bool UserExists(Guid id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
