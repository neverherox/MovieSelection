namespace MovieSelection.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RateController : ControllerBase
{
    private readonly MovieSelectionContext _context;

    public RateController(
        MovieSelectionContext context)
    {
        _context = context;
    }
}