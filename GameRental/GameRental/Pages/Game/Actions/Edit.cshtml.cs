using Application.ModelsDTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace GameRental.Pages.Game.Actions
{
    public class EditModel : PageModel
    {
        private readonly IGameService _gameService;
        private readonly IGenreService _genreService;
        public EditModel(IGameService gameService, IGenreService genreService)
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
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var game = await _gameService.GetByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            else
            {
                Game = game;
            }
            Genres = await _genreService.GetAllAsync();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            foreach (var genreId in SelectedGenresIds)
            {
                var genre = await _genreService.GetByIdAsync(genreId);
                if (genre != null)
                {
                    Game.Genres.Add(genre);
                }
            }

            if (UploadedImage != null && UploadedImage.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await UploadedImage.CopyToAsync(memoryStream);
                    Game.Image = memoryStream.ToArray();
                }
            }

            ModelState.ClearValidationState(nameof(Game));
            if (!TryValidateModel(Game, nameof(Game)))
            {
                return Page();
            }

            await _gameService.UpdateAsync(Game);

            return RedirectToPage("/Game/Index");
        }
    }
}
