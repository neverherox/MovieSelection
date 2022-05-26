using MovieSelection.Models.Entities;

namespace MovieSelection.Models.RequestModels
{
    public class GetMovie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public int Year { get; set; }

        public Country Country { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string Image { get; set; }

        public double Rate { get; set; }

        public IEnumerable<Saving> Savings { get; set; }
    }
}
