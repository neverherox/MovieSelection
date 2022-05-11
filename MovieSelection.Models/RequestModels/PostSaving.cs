namespace MovieSelection.Models.RequestModels
{
    public class PostSaving
    {
        public Guid UserId { get; set; }

        public int MovieId { get; set; }
    }
}
