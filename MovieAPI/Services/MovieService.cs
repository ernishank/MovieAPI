using Microsoft.AspNetCore.Mvc;
using MovieAPI.Context;
using MovieAPI.Entity;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
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
        public async Task<List<Object>> GetMovieWithDetails(int MovieId)
        {
            if(MovieId > 0) 
            {
                var movieDetails = _db.Movies
                .Include(m => m.Genre)
                .Include(m => m.Director)
                .Include(m => m.Actors)
                .Include(m => m.RatingNavigation)
                .FirstOrDefault(m => m.MovieId == MovieId);

                return null;
                //if (movieDetails != null)
                //{
                //    // Access movie details, including related entities
                //    var title = movieDetails.Title;
                //    var genreName = movieDetails.Genre?.GenreName;
                //    var directorName = $"{movieDetails.Director?.FirstName} {movieDetails.Director?.LastName}";
                //    var actors = movieDetails.Actors?.Select(a => $"{a.FirstName} {a.LastName}");
                //    var ratingValue = movieDetails.RatingNavigation?.RatingValue;

                //    // ... (access other properties as needed)
                //}
            }
            return null;
        }

        //● Implement an API endpoint to retrieve an actor with a list of all movies.
        public async Task<List<Movie>> GetMoviesByActor(int id)
        {

            if (id > 0)
            {
                var movieDetails = _db.Actors
                .Include(m => m.Movies)
                .FirstOrDefault(m => m.ActorId == id);

                return null;
            }
            return null;
        }

        //● Implement an API endpoint to list all movies by a genre.
        public async Task<List<Movie>> GetMoviesByGenre(int id)
        {

            if (id > 0)
            {
                var movieDetails = _db.Genres
                .Include(m => m.Movies)
                .FirstOrDefault(m => m.GenreId == id);

                return null;
            }
            return null;
        }
    }
}
