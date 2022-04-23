namespace MovieSelection.Data.Models;

public class Movie
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public short Year { get; set; }

    public int CountryId { get; set; }
}