namespace MovieAPI.Entity
{
    public class Movie
    {
        public int MovieId { get; set; }

        public int? GenreId { get; set; }

        public int? DirectorId { get; set; }

        public string Title { get; set; } = null!;

        public int ReleaseYear { get; set; }

        public decimal Rating { get; set; }

        public string? Plot { get; set; }

        public int? MovieLength { get; set; }

        public Genre Genre { get; set; }
        public Director Director { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public Ratings RatingNavigation { get; set; }
    }
}
