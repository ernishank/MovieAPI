using Microsoft.AspNetCore.Mvc;
using MovieAPI.Entity;
using MovieAPI.ResponseObject;
using MovieAPI.Services.Interface;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IMovie _movie;
        public MovieController(ILogger<MovieController> logger, IMovie movie)
        {
            _logger = logger;
            _movie = movie;
        }

        [HttpGet(Name = "GetMovieWithDetails")]
        public ActionResult<MovieDetails> GetMovieWithDetails([FromQuery] int movieId)
        {
            if (movieId <= 0)
            {
                return BadRequest();
            }
            _logger.LogDebug($"Searching the Movie detail by MovieId: {movieId}");

            MovieDetails movieDetails = _movie.GetMovieWithDetails(movieId).Result;
            if (movieDetails != null)
            {
                _logger.LogDebug($"Successfully retrieved the movies: {movieDetails}");
                return Ok(movieDetails);
            }
            return NotFound();
            
        }

        [HttpGet(Name = "GetMoviesByActorId")]
        public ActionResult<IEnumerable<Movie>> GetMoviesByActorId([FromQuery] int actorId)
        {
            if (actorId <= 0)
            {
                return BadRequest();
            }
            _logger.LogDebug($"Searching the Movie detail by ActorId: {actorId}");           
            var movies = _movie.GetMoviesByActor(actorId).Result;
            if (movies != null)
            {
                _logger.LogDebug($"Successfully retrieved the movies: {movies}");
                return Ok(movies);
            }
            return NotFound();
        }

        [HttpGet(Name = "GetMoviesByGenreId")]
        public ActionResult<IEnumerable<Movie>> GetMoviesByGenreId([FromQuery] int genreId)
        {
            if (genreId <= 0)
            {
                return BadRequest();
            }
            _logger.LogDebug($"Searching the Movie detail by GenreId: {genreId}");
            var movies = _movie.GetMoviesByGenre(genreId).Result;
            if (movies != null)
            {
                _logger.LogDebug($"Successfully retrieved the movies: {movies}");
                return Ok(movies);
            }
            return NotFound();
        }
    }
}
