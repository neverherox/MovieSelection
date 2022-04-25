using MovieSelection.Models;

namespace MovieSelection.Client.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();

        Task<Movie> GetMovieAsync(int id);

        Task<IEnumerable<Actor>> GetActorsAsync(int id);
    }
}
