namespace MovieSelection.Data.Models;

public class Rate
{
    public int Id { get; set; }

    public double? Directing { get; set; }

    public double? Entertainment { get; set; }

    public double? Actors { get; set; }

    public double? Plot { get; set; }

    public double Value { get; set; }

    public int MovieId { get; set; }
}