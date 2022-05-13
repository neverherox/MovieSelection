namespace MovieSelection.Models.RequestModels
{
    public class GetUserRate
    {
        public int? Directing { get; set; }

        public int? Entertainment { get; set; }

        public int? Actors { get; set; }

        public int? Plot { get; set; }

        public int Value { get; set; }

        public GetMovie Movie { get; set; }
    }
}
