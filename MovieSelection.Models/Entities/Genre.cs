namespace MovieSelection.Models.Entities;

public class Genre
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int? ParentId { get; set; }
}