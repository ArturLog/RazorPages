using Application.ModelsDTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameRental.Pages.Genre.Actions
{
    public class EditModel : PageModel
    {
        private readonly IGenreService _genreService;
        public EditModel(IGenreService genreService)
        {
            _genreService = genreService;
        }
        [BindProperty]
        public GenreDTO Genre { get; set; } = default!;
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
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _genreService.UpdateAsync(Genre);

            return RedirectToPage("/Genre/Index");
        }
    }
}
