using MovieSelection.Client.Interfaces;
using MovieSelection.Models.RequestModels;

namespace MovieSelection.Client.Services
{
    public class MovieFilterService : IMovieFilterService
    {
        public int GenreId { get; set; }

        public int SubgenreId { get; set; }

        public int CountryId { get; set; }

        public int MinRate { get; set; }

        public int MaxRate { get; set; } = 10;

        public int MinYear { get; set; } = 2001;

        public int MaxYear { get; set; } = 2022;

        public IEnumerable<GetMovie> ApplyFilters(IEnumerable<GetMovie> movies)
        {
            if (GenreId != 0)
            {
                movies = movies.Where(x => x.Genres.Any(y => y.Id == GenreId));
            }
            if (SubgenreId != 0)
            {
                movies = movies.Where(x => x.Genres.Any(y => y.Id == SubgenreId));
            }
            if (CountryId != 0)
            {
                movies = movies.Where(x => x.Country.Id == CountryId);
            }
            movies = movies.Where(x => x.Rate >= MinRate && x.Rate <= MaxRate);
            movies = movies.Where(x => x.Year >= MinYear && x.Year <= MaxYear);
            return movies.ToList();
        }

        public void ResetFilters()
        {
            GenreId = 0;
            SubgenreId = 0;
            CountryId = 0;
            MinRate = 0;
            MaxRate = 10;
            MinYear = 2001;
            MaxYear = 2022;
        }
    }
}
