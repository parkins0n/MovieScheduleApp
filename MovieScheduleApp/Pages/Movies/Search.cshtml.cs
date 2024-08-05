using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieLibrary.Data;
using MovieLibrary.Models;
using System.Collections.Generic;

namespace MovieScheduleApp.Pages.Movies
{
    public class SearchModel : PageModel
    {
        private readonly IMovieRepository _movieRepository;

        public SearchModel(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public IEnumerable<Movie> Movies { get; private set; }

        public void OnGet()
        {
            Movies = _movieRepository.SearchMovies(SearchTerm ?? string.Empty);
        }
    }
}