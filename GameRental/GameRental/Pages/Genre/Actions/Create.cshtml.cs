using Application.ModelsDTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GenreRental.Pages.Genre
{
    public class CreateModel : PageModel
    {
        private readonly IGenreService _genreService;
        public CreateModel(IGenreService gameService)
        {
            _genreService = gameService;
        }
        [BindProperty]
        public GenreDTO Genre { get; set; } = default!;
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _genreService.AddAsync(Genre);

            return RedirectToPage("/Genre/Index");
        }
    }
}
