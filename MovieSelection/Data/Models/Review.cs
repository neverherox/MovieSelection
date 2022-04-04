namespace MovieSelection.Data.Models;

public class Review
{
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    public int MovieId { get; set; }
}