using System.ComponentModel.DataAnnotations;

namespace MovieSelection.Models.RequestModels
{
    public class PostReview
    {
        [Required]
        [StringLength(1000, ErrorMessage = "The {0} must be at max {1} characters long.", MinimumLength = 1)]
        public string Text { get; set; }

        public int MovieId { get; set; }

        public Guid UserId { get; set; }
    }
}
