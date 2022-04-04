namespace MovieSelection.Data.Models;

public class MovieActor
{
    public int MovieId { get; set; }

    public int ActorId { get; set; }

    public Actor Actor { get; set; } = null!;
}