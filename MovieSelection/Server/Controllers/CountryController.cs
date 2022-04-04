namespace MovieSelection.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly MovieSelectionContext _context;

    public CountryController(
        MovieSelectionContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Genre>> GetCountries()
    {
        return Ok(_context.Countries.ToList());
    }
}