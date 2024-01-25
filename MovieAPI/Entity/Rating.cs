namespace MovieAPI.Entity
{
    public class Ratings
    {
        public int RatingId { get; set; }

        public decimal? Rating { get; set; }

        public string Source { get; set; } = null!;
    }
}
