namespace MovieAPI.Entity
{
    public class Director
    {
        public int DirectorId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Nationality { get; set; } = null!;

        public DateOnly? BirthDate { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
