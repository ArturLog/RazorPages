using Application.ModelsDTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameRental.Pages.Genre.Actions
{
    public class DetailsModel : PageModel
    {
        private readonly IGenreService _genreService;
        public DetailsModel(IGenreService genreService)
        {
            _genreService = genreService;
        }
        public GenreDTO Genre { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var game = await _genreService.GetByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            else
            {
                Genre = game;
            }
            return Page();
        }
    }
}
