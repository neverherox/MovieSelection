namespace MovieSelection.Data.Models;

public class Subscription
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public short Duration { get; set; }
}