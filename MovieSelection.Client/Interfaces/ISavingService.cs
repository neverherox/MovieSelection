using MovieSelection.Models.RequestModels;

namespace MovieSelection.Client.Interfaces
{
    public interface ISavingService
    {
        Task PostSavingAsync(PostSaving saving);

        Task DeleteSavingAsync(int id);
    }
}
