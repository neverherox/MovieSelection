﻿using AutoMapper;
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
        public async Task<ActionResult<IEnumerable<GetMovie>>> GetMovies()
        {
            var movies =  await _context.Movies
                .Select(x => new GetMovie
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Image = x.Image,
                    Year = x.Year,
                    Country = x.Country,
                    Genres = x.MovieGenres.Select(y => y.Genre).ToList(),
                    Rate = _context.Rates.Where(y => y.MovieId == x.Id).Select(y => y.Value).DefaultIfEmpty().Average(),
                    Savings = x.Savings.ToList()
                }).ToListAsync();
            return movies;
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetMovie>> GetMovie(int id)
        {
            var movie = await _context.Movies
                .Include(x => x.Country)
                .Include(x => x.MovieGenres)
                .ThenInclude(x => x.Genre)
                .Include(x => x.Savings)
                .FirstOrDefaultAsync(x => x.Id == id);

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
                Country = movie.Country,
                Genres = movie.MovieGenres.Select(x => x.Genre).ToList(),
                Savings = movie.Savings.ToList()
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
                .Select(x => x.Actor)
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
                    UserName = x.User.Name,
                    ReviewDate = x.ReviewDate,
                    Likes = x.ReviewLikes,
                    LikesCount = x.ReviewLikes.Count(y => y.Like) - x.ReviewLikes.Count(y => !y.Like)
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
                ValuesCount = valuesCount,
                Rates = await _context.Rates.Where(x => x.MovieId == id).ToListAsync()
            };

            return rate;
        }

        [HttpGet]
        [Route("/api/movie-names")]
        public async Task<ActionResult<IEnumerable<string>>> GetMovieNames()
        {
            return await _context.Movies
                .Select(x => x.Name)
                .ToListAsync();
        }

        [HttpGet]
        [Route("/api/highly-rated/{top}")]
        public ActionResult<IEnumerable<GetMovie>> GetHighlyRated(int top)
        {
            var highlyRated =  _context
                .Rates
                .Include(x => x.Movie)
                .ThenInclude(x => x.Savings)
                .ThenInclude(x => x.User)
                .Include(x => x.Movie)
                .ThenInclude(x => x.MovieGenres)
                .ThenInclude(x => x.Genre)
                .Include(x => x.Movie)
                .ThenInclude(x => x.Country)
                .GroupBy(x => x.MovieId)
                .Select(x => x.First())
                .ToList()
                .Select(x => new GetMovie
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
                })
                .OrderByDescending(x => x.Rate)
                .Take(top)
                .ToList();
            return highlyRated;
        }

        [HttpGet]
        [Route("/api/novelties/{top}")]
        public async Task<ActionResult<IEnumerable<GetMovie>>> GetNovelties(int top)
        {
            return await _context.Movies
                .OrderByDescending(x => x.Year)
                .Take(top)
                .Select(x => new GetMovie
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Image = x.Image,
                    Year = x.Year,
                    Country = x.Country,
                    Genres = x.MovieGenres.Select(y => y.Genre).ToList(),
                    Rate = _context.Rates.Where(y => y.MovieId == x.Id).Select(y => y.Value).DefaultIfEmpty().Average(),
                    Savings = x.Savings.ToList()
                })
                .ToListAsync();
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
