using Application.ModelsDTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameRental.Pages.GameLeased
{
    public class EditModel : PageModel
    {
        private readonly IGameLeasedService _gameLeasedService;
        private readonly IGameOfferService _gameOfferService;
        public EditModel(IGameOfferService gameOfferService, IGameLeasedService gameLeasedService)
        {
            _gameOfferService = gameOfferService;
            _gameLeasedService = gameLeasedService;
        }
        [BindProperty]
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
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.ClearValidationState(nameof(GameLeased));
            if (!TryValidateModel(GameLeased, nameof(GameLeased)))
            {
                return Page();
            }

            await _gameLeasedService.UpdateAsync(GameLeased);

            return RedirectToPage("/GameLeased/Index");
        }
    }
}
