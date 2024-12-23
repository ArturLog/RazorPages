using Application.ModelsDTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Numerics;

namespace GameRental.Pages.Game.Actions
{
    public class CreateModel : PageModel
    {
        private readonly IGameService _gameService;
        private readonly IGenreService _genreService;

        public CreateModel(IGameService gameService, IGenreService genreService)
        {
            _gameService = gameService;
            _genreService = genreService;
        }

        [BindProperty]
        public GameDTO Game { get; set; } = default!;

        [BindProperty]
        public IEnumerable<GenreDTO?> Genres { get; set; } = default!;

        [BindProperty]
        public List<int> SelectedGenresIds { get; set; } = default!;

        [BindProperty]
        public IFormFile? UploadedImage { get; set; }
        public async Task<IActionResult> OnGet()
        {
            Genres = await _genreService.GetAllAsync();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (UploadedImage != null && UploadedImage.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await UploadedImage.CopyToAsync(memoryStream);
                    Game.Image = memoryStream.ToArray();
                }
            }

            if (SelectedGenresIds.Any())
            {
                Game.Genres = SelectedGenresIds
                    .Select(genreId => new GenreDTO { Id = genreId })
                    .ToList();
            }

            await _gameService.AddAsync(Game);

            return RedirectToPage("/Game/Index");
        }
    }
}
