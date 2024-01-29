namespace MovieAPI.ResponseObject
{
    public class MovieDetails
    {
        public int MovieId { get; set; }
        public string GenreName { get; set; }
        public string ActorName { get; set; }
        public string DirectorName { get; set; }
        public decimal Rating { get; set; }
    }
}
