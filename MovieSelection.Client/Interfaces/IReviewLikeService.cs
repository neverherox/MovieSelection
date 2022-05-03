using MovieSelection.Models.Entities;

namespace MovieSelection.Client.Interfaces
{
    public interface IReviewLikeService
    {
        Task PostReviewLikeAsync(ReviewLike reviewLike);

        Task PutReviewLikeAsync(ReviewLike reviewLike);

        Task DeleteReviewLikeAsync(int id);
    }
}
