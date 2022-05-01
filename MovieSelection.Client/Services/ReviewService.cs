using System.Net.Http.Json;
using MovieSelection.Client.Interfaces;
using MovieSelection.Models.RequestModels;

namespace MovieSelection.Client.Services
{
    public class ReviewService :  BaseService, IReviewService
    {
        public ReviewService(IHttpClientFactory factory) : base(factory)
        {
        }

        public async Task PostReviewAsync(PostReview review)
        {
            await PrivateClient.PostAsJsonAsync("reviews", review);
        }
    }
}
