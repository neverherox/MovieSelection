namespace MovieSelection.Models.RequestModels
{
    public class GetSaving
    {
        public int Id { get; set; }

        public GetMovie Movie { get; set; }

        public bool IsWatched { get; set; }
    }
}
