using Application.ModelsDTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameRental.Pages.Genre
{
    public class IndexModel : PageModel
    {
        private readonly IGenreService _genreService;
        public IEnumerable<GenreDTO?> Genres { get; set; } = default!;

        public IndexModel(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public async Task OnGetAsync()
        {
            Genres = await _genreService.GetAllAsync();
        }
    }
}
