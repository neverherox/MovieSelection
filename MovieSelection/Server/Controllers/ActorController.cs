namespace MovieSelection.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActorController : ControllerBase
{
    private readonly MovieSelectionContext _context;

    public ActorController(
        MovieSelectionContext context)
    {
        _context = context;
    }
}