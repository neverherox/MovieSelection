using MovieSelection.Models.RequestModels;

namespace MovieSelection.Client.Interfaces
{
    public interface IMovieFilterService
    {
        public string Name { get; set; }

        public int GenreId { get; set; }

        public int SubgenreId { get; set; }

        public int CountryId { get; set; }

        public int MinRate { get; set; }

        public int MaxRate { get; set; }

        public int MinYear { get; set; }

        public int MaxYear { get; set; }

        IEnumerable<GetMovie> ApplyFilters(IEnumerable<GetMovie> movies);

        void ResetFilters();
    }
}
