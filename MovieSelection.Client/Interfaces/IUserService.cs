using MovieSelection.Models.RequestModels;

namespace MovieSelection.Client.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<GetSaving>> GetSavingsAsync(Guid id);
    }
}
