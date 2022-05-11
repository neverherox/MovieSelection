namespace MovieSelection.Models.Entities;

public class Movie
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public int Year { get; set; }

    public int CountryId { get; set; }

    public byte[] Image { get; set; }

    public Country Country { get; set; }

    public ICollection<MovieGenre> MovieGenres { get; set; }

    public ICollection<Saving> Savings { get; set; }
}