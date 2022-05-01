using MovieSelection.Models.RequestModels;

namespace MovieSelection.Client.Interfaces
{
    public interface IReviewService
    {
        Task PostReviewAsync(PostReview review);
    }
}
