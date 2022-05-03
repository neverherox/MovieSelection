using System.Net.Http.Json;
using MovieSelection.Client.Interfaces;
using MovieSelection.Models.Entities;

namespace MovieSelection.Client.Services
{
    public class ReviewLikeService : BaseService, IReviewLikeService
    {
        public ReviewLikeService(IHttpClientFactory factory) : base(factory)
        {
        }

        public async Task PostReviewLikeAsync(ReviewLike reviewLike)
        {
            await PrivateClient.PostAsJsonAsync("review-likes", reviewLike);
        }

        public async Task PutReviewLikeAsync(ReviewLike reviewLike, int id)
        {
            await PrivateClient.PutAsJsonAsync($"review-likes/{id}", reviewLike);
        }

        public async Task DeleteReviewLikeAsync(int id)
        {
            await PrivateClient.DeleteAsync($"review-likes/{id}");
        }
    }
}
