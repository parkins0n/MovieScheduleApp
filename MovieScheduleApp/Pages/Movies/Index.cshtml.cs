using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieLibrary.Data;
using MovieLibrary.Models;
using System.Collections.Generic;

namespace MovieScheduleApp.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly IMovieRepository _movieRepository;

        public IndexModel(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IEnumerable<Movie> Movies { get; private set; }

        public void OnGet()
        {
            Movies = _movieRepository.GetAllMovies();
        }
    }
}