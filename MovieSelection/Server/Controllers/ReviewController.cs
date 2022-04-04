namespace MovieSelection.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly MovieSelectionContext _context;

    public ReviewController(
        MovieSelectionContext context)
    {
        _context = context;
    }
}