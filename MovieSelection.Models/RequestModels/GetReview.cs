using MovieSelection.Models.Entities;

namespace MovieSelection.Models.RequestModels
{
    public class GetReview
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string UserName { get; set; }

        public int LikesCount { get; set; }

        public IEnumerable<ReviewLike> Likes { get; set; }

        public DateTime ReviewDate { get; set; }
    }
}
