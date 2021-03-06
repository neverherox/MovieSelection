using MovieSelection.Models.RequestModels;

namespace MovieSelection.Client.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<GetSaving>> GetSavingsAsync(Guid id);

        Task<IEnumerable<GetUserRate>> GetRatesAsync(Guid id);

        Task<IEnumerable<GetMovie>> GetRecommendationsAsync(Guid id, int top);
    }
}
