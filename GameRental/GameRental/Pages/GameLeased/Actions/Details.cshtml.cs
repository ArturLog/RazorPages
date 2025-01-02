using Application.ModelsDTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameRental.Pages.GameLeased
{
    public class DetailsModel : PageModel
    {
        private readonly IGameLeasedService _gameLeasedService;
        public DetailsModel(IGameLeasedService gameLeasedService)
        {
            _gameLeasedService = gameLeasedService;
        }
        public GameLeasedDTO GameLeased { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var gameLeased = await _gameLeasedService.GetByIdAsync(id);
            if (gameLeased == null)
            {
                return NotFound();
            }
            else
            {
                GameLeased = gameLeased;
            }
            return Page();
        }
    }
}
