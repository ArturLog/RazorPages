using Application.ModelsDTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameRental.Pages.Genre.Actions
{
    public class DeleteModel : PageModel
    {
        private readonly IGenreService _genreService;
        public DeleteModel(IGenreService genreService)
        {
            _genreService = genreService;
        }
        [BindProperty]
        public GenreDTO Genre { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var genre = await _genreService.GetByIdAsync(id);
            if (genre == null)
            {
                return NotFound();
            }
            else
            {
                Genre = genre;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var genre = await _genreService.GetByIdAsync(id);
            if (genre != null)
            {
                Genre = genre;
                await _genreService.DeleteAsync(id);
            }
            else
            {
                return NotFound();
            }

            return RedirectToPage("/Genre/Index");
        }
    }
}
