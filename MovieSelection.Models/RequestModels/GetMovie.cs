namespace MovieSelection.Models.RequestModels
{
    public class GetMovie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public int Year { get; set; }

        public string Country { get; set; }

        public IEnumerable<string> Genres { get; set; }

        public byte[] Image { get; set; }
    }
}
