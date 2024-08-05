using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieLibrary.Data;
using MovieLibrary.Models;

namespace MovieScheduleApp.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly IMovieRepository _movieRepository;

        public CreateModel(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _movieRepository.AddMovie(Movie);
            return RedirectToPage("./Index");
        }
    }
}
