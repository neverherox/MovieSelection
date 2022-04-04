namespace MovieSelection.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenreController : ControllerBase
{
    private readonly MovieSelectionContext _context;

    public GenreController(
        MovieSelectionContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Genre>> GetGenres()
    {
        return Ok(_context.Genres.ToList());
    }

    [HttpGet("{id}/sub-genres")]
    public ActionResult<IEnumerable<Genre>> GetSubGenres(int id)
    {
        var subGenres = _context
            .Genres
            .Where(x => x.ParentId == id)
            .ToList();
        return Ok(subGenres);
    }
}