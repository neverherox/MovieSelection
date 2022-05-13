using System.Net.Http.Json;
using MovieSelection.Client.Interfaces;
using MovieSelection.Models.RequestModels;

namespace MovieSelection.Client.Services
{
    public class SavingService : BaseService, ISavingService
    {
        public SavingService(IHttpClientFactory factory) : base(factory)
        {
        }

        public async Task PostSavingAsync(PostSaving saving)
        {
            await PrivateClient.PostAsJsonAsync("savings", saving);
        }

        public async Task PutReviewLikeAsync(PutSaving saving)
        {
            await PrivateClient.PutAsJsonAsync($"savings/{saving.Id}", saving);
        }

        public async Task DeleteSavingAsync(int id)
        {
            await PrivateClient.DeleteAsync($"savings/{id}");
        }
    }
}
