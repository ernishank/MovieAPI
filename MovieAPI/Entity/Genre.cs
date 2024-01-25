namespace MovieAPI.Entity
{
    public class Genre
    {
        public int GenreId { get; set; }

        public string GenreName { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
