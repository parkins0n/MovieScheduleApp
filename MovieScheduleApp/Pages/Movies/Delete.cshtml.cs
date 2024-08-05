using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieLibrary.Data;
using MovieLibrary.Models;

namespace MovieScheduleApp.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        private readonly IMovieRepository _movieRepository;

        public DeleteModel(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public IActionResult OnGet(int id)
        {
            Movie = _movieRepository.GetMovieById(id);

            if (Movie == null)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            _movieRepository.DeleteMovie(Movie.Id);
            return RedirectToPage("./Index");
        }
    }
}