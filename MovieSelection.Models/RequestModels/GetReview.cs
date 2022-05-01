namespace MovieSelection.Models.RequestModels
{
    public class GetReview
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string UserName { get; set; }

        public DateTime ReviewDate { get; set; }
    }
}
