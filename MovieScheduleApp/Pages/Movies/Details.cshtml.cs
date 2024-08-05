using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieLibrary.Data;
using MovieLibrary.Models;

namespace MovieScheduleApp.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly IMovieRepository _movieRepository;

        public DetailsModel(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public Movie Movie { get; private set; }

        public IActionResult OnGet(int id)
        {
            Movie = _movieRepository.GetMovieById(id);

            if (Movie == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            var movie = _movieRepository.GetMovieById(id);

            if (movie == null)
            {
                return NotFound();
            }

            _movieRepository.DeleteMovie(id);
            return RedirectToPage("/Movies/Index");
        }
    }
}