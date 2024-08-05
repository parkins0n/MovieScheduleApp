using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieLibrary.Data;
using MovieLibrary.Models;
using System;
using System.Linq;

namespace MovieScheduleApp.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly IMovieRepository _movieRepository;

        public EditModel(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        [BindProperty]
        public string Showtimes { get; set; }

        public IActionResult OnGet(int id)
        {
            Movie = _movieRepository.GetMovieById(id);

            if (Movie == null)
            {
                return NotFound();
            }

            Showtimes = string.Join("\n", Movie.Showtimes.Select(s => $"{s.StartTime:yyyy-MM-ddTHH:mm} - {s.Location}"));
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var showtimesList = Showtimes.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                                         .Select(s => s.Split(" - "))
                                         .Select(parts => new Showtime
                                         {
                                             StartTime = DateTime.Parse(parts[0]),
                                             Location = parts[1]
                                         })
                                         .ToList();

            Movie.Showtimes = showtimesList;

            _movieRepository.UpdateMovie(Movie);
            return RedirectToPage("/Movies/Index");
        }
    }
}