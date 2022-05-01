namespace MovieSelection.Models.RequestModels
{
    public class GetRate
    {
        public double? Directing { get; set; }

        public double? Entertainment { get; set; }

        public double? Actors { get; set; }

        public double? Plot { get; set; }

        public double Value { get; set; }

        public int ValuesCount { get; set; }
    }
}
