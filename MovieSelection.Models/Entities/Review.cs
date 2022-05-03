namespace MovieSelection.Models.Entities;

public class Review
{
    public int Id { get; set; }

    public string Text { get; set; }

    public DateTime ReviewDate { get; set; }

    public int MovieId { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; }

    public ICollection<ReviewLike> ReviewLikes { get; set; }
}