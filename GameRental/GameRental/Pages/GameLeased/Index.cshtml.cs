using Application.ModelsDTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameRental.Pages.GameLeased
{
    public class IndexModel : PageModel
    {
        private readonly IGameLeasedService _gameLeasedService;
        public IEnumerable<GameLeasedDTO?> LeasedGames { get; set; } = default!;

        public IndexModel(IGameLeasedService gameLeasedService)
        {
            _gameLeasedService = gameLeasedService;
        }

        public async Task OnGetAsync()
        {
            LeasedGames = await _gameLeasedService.GetAllAsync();
        }
    }
}
