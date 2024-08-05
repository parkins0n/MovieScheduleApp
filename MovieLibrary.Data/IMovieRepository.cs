using MovieLibrary.Models;

namespace MovieLibrary.Data
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovieById(int id);
        void AddMovie(Movie movie);
        void DeleteMovie(int id);
        void UpdateMovie(Movie movie);

        IEnumerable<Movie> SearchMovies(string searchTerm);
    }
}