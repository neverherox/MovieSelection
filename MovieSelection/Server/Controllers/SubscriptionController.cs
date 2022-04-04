namespace MovieSelection.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscriptionController : ControllerBase
{
    private readonly MovieSelectionContext _context;

    public SubscriptionController(
        MovieSelectionContext context)
    {
        _context = context;
    }
}