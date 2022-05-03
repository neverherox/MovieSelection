namespace MovieSelection.Models.Entities
{
    public class ReviewLike
    {
        public int Id { get; set; }

        public int ReviewId { get; set; }

        public Guid UserId { get; set; }

        public bool Like { get; set; }
    }
}
