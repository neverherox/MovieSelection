using MovieSelection.Models.Entities;

namespace MovieSelection.Client.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();

        Task<Movie> GetMovieAsync(int id);

        Task<IEnumerable<Actor>> GetActorsAsync(int id);

        Task<IEnumerable<Review>> GetReviewsAsync(int id);
    }
}
