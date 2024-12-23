using Application.ModelsDTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameRental.Pages.Game.Actions
{
    public class DeleteModel : PageModel
    {
        private readonly IGameService _gameService;
        public DeleteModel(IGameService gameService)
        {
            _gameService = gameService;
        }
        [BindProperty]
        public GameDTO Game { get; set; }
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
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var game = await _gameService.GetByIdAsync(id);
            if (game != null)
            {
                Game = game;
                await _gameService.DeleteAsync(id);
            }
            else
            {
                return NotFound();
            }

            return RedirectToPage("/Game/Index");
        }

    }
}
