using MovieSelection.Models.Entities;

namespace MovieSelection.Models.RequestModels
{
    public class GetGenre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Genre> Subgenres { get; set; }
    }
}
