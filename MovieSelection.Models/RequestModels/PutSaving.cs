namespace MovieSelection.Models.RequestModels
{
    public class PutSaving
    {
        public int Id { get; set; }

        public bool IsWatched { get; set; }

        public int MovieId { get; set; }

        public Guid UserId { get; set; }
    }
}
