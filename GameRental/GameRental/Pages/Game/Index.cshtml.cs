using Application.ModelsDTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameRental.Pages.Game
{
    public class IndexModel : PageModel
    {
        private readonly IGameService _gameService;
        public IEnumerable<GameDTO?> Games { get; set; } = default!;

        public IndexModel(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task OnGetAsync()
        {
            Games = await _gameService.GetAllAsync();
        }
    }
}
