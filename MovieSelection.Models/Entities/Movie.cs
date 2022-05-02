namespace MovieSelection.Models.Entities;

public class Movie
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public int Year { get; set; }

    public int CountryId { get; set; }

    public byte[] Image { get; set; }
}