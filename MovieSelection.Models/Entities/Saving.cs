namespace MovieSelection.Models.Entities
{
    public class Saving
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        public User User { get; set; }

        public bool IsWatched { get; set; }
    }
}
