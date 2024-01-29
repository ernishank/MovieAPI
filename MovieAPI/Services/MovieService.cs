using Microsoft.EntityFrameworkCore;
using MovieAPI.Context;
using MovieAPI.Entity;
using MovieAPI.ResponseObject;
using MovieAPI.Services.Interface;

namespace MovieAPI.Services
{
    //● Ensure proper exception handling and logging in the API controller.
    public class MovieService : IMovie
    {
        private readonly MovieDbContext _db;
        public MovieService(MovieDbContext db)
        {
            _db = db;
        }

        //    ● Implement an API endpoint to retrieve a movie with all details of the movie -
        //actors, director, genre, reviews.
        public async Task<MovieDetails> GetMovieWithDetails(int MovieId)
        {
            if (MovieId > 0)
            {
                var movieDetails = _db.Movies
                .Include(m => m.Genre)
                .Include(m => m.Director)
                .Include(m => m.Actors)
                .Include(m => m.RatingNavigation)
                .FirstOrDefault(m => m.MovieId == MovieId);

                if (movieDetails != null)
                {
                    MovieDetails movie = new MovieDetails
                    {
                        MovieId = movieDetails.MovieId,
                        ActorName = movieDetails.Actors?.Select(a => $"{a.FirstName} {a.LastName}").First(),
                        DirectorName = $"{movieDetails.Director?.FirstName} {movieDetails.Director?.LastName}",
                        GenreName = movieDetails.Genre?.GenreName,
                        Rating = movieDetails.RatingNavigation?.Rating ?? 0,
                    };
                }
            }
            return new MovieDetails();
        }

        //● Implement an API endpoint to retrieve an actor with a list of all movies.
        public async Task<List<Movie>> GetMoviesByActor(int actorId)
        {

            if (actorId > 0)
            {
                    var movies = _db.Movies
                .Where(movie => movie.Actors.Any(actor => actor.ActorId == actorId))
                .ToList();

                return movies;
            }
            return new List<Movie>();
        }

        //● Implement an API endpoint to list all movies by a genre.
        public async Task<List<Movie>> GetMoviesByGenre(int genreId)
        {

            if (genreId > 0)
            {
                var movies = _db.Movies
            .Where(movie => movie.GenreId == genreId)
            .ToList();

                return movies;
            }
            return new List<Movie>();
        }
    }
}
