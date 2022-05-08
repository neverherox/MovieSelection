using MovieSelection.Models.RequestModels;

namespace MovieSelection.Client.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<GetGenre>> GetGenresAsync();
    }
}
