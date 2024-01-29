using MovieAPI.Entity;
using MovieAPI.ResponseObject;
namespace MovieAPI.Services.Interface
{
    public interface IMovie
    {
        Task<MovieDetails> GetMovieWithDetails(int MovieId);
        Task<List<Movie>> GetMoviesByActor(int id);
        Task<List<Movie>> GetMoviesByGenre(int id);
    }
}
