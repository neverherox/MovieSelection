namespace MovieSelection.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly MovieSelectionContext _context;

    public MovieController(
        MovieSelectionContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Movie>> GetMovies()
    {
        return Ok(_context.Movies.ToList());
    }

    [HttpGet("novelties")]
    public ActionResult<IEnumerable<Movie>> GetNovelties()
    {
        var novelties = _context
            .Movies
            .OrderByDescending(x => x.Year)
            .ToList();

        return Ok(novelties);
    }

    [HttpGet("highly-rated")]
    public ActionResult<IEnumerable<Movie>> GetHighlyRated()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public ActionResult<Movie> GetMovie(int id)
    {
        var movie = _context.Movies.Find(id);
        if (movie == null)
        {
            return NotFound();
        }
        return Ok(movie);
    }

    [HttpGet("{id}/actors")]
    public ActionResult<IEnumerable<Movie>> GetActors(int id)
    {
        var actors = _context
            .MovieActors
            .Where(x => x.MovieId == id)
            .Select(x => x.Actor)
            .ToList();

        return Ok(actors);
    }

    [HttpGet("{id}/rate")]
    public ActionResult<Rate> GetRate(int id)
    {
        var rates = _context
            .Rates
            .Where(r => r.MovieId == id)
            .ToList();

        //var rate = _rateService.CalculateAverage(rates);

        return Ok(null);
    }

    [HttpGet("{id}/reviews")]
    public ActionResult<IEnumerable<Movie>> GetReviews(int id)
    {
        var reviews = _context
            .Reviews
            .Where(review => review.MovieId == id)
            .ToList();

        return Ok(reviews);
    }
}