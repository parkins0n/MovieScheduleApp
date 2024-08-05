using MovieLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary.Data
{
    public class MovieRepository : IMovieRepository
    {
        private readonly List<Movie> _movies = new List<Movie>
        {
            new Movie
            {
                Id = 1,
                Title = "Inception",
                Director = "Christopher Nolan",
                Genre = "Sci-Fi",
                Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a CEO.",
                Showtimes = new List<Showtime>
                {
                    new Showtime { StartTime = new DateTime(2024, 8, 5, 18, 30, 0), Location = "Theater 1" },
                    new Showtime { StartTime = new DateTime(2024, 8, 5, 21, 00, 0), Location = "Theater 2" }
                }
            },
        };

        public IEnumerable<Movie> GetAllMovies() => _movies;

        public Movie GetMovieById(int id) => _movies.FirstOrDefault(m => m.Id == id);

        public void AddMovie(Movie movie)
        {
            movie.Id = _movies.Max(m => m.Id) + 1; 
            _movies.Add(movie);
        }

        public void DeleteMovie(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                _movies.Remove(movie);
            }
        }

        public void UpdateMovie(Movie updatedMovie)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == updatedMovie.Id);
            if (movie != null)
            {
                movie.Title = updatedMovie.Title;
                movie.Director = updatedMovie.Director;
                movie.Genre = updatedMovie.Genre;
                movie.Description = updatedMovie.Description;
                movie.Showtimes = updatedMovie.Showtimes;
            }
        }

        public IEnumerable<Movie> SearchMovies(string searchTerm)
        {
            searchTerm = searchTerm.ToLower();
            return _movies.Where(m =>
                m.Title.ToLower().Contains(searchTerm) ||
                m.Director.ToLower().Contains(searchTerm) ||
                m.Genre.ToLower().Contains(searchTerm) ||
                m.Description.ToLower().Contains(searchTerm) ||
                m.Showtimes.Any(s => s.Location.ToLower().Contains(searchTerm) ||
                                     s.StartTime.ToString("g").Contains(searchTerm))
            ).ToList();
        }
    }
}