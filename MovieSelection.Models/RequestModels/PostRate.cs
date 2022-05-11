namespace MovieSelection.Models.RequestModels
{
    public class PostRate
    {
        public int? Directing { get; set; }

        public int? Entertainment { get; set; }

        public int? Actors { get; set; }

        public int? Plot { get; set; }

        public int Value { get; set; }

        public int MovieId { get; set; }

        public Guid UserId { get; set; }
    }
}
