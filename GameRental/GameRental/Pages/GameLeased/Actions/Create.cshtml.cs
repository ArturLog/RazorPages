using Application.ModelsDTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameRental.Pages.GameLeased
{
    public class CreateModel : PageModel
    {
        private readonly IGameLeasedService _gameLeasedService;
        private readonly IGameOfferService _gameOfferService;

        public CreateModel(IGameOfferService gameOfferService, IApplicationUserService applicationUserService, IGameLeasedService gameLeasedService)
        {
            _gameOfferService = gameOfferService;
            _gameLeasedService = gameLeasedService;
        }
        [BindProperty]
        public GameLeasedDTO GameLeased { get; set; } = default!;
        [BindProperty]
        public IEnumerable<GameOfferDTO?> GameOffers { get; set; } = default!;

        [BindProperty]
        public int SelectedGameOfferId { get; set; } = default!;

        public async Task<IActionResult> OnGet()
        {
            GameOffers = await _gameOfferService.GetAllAsync();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            GameLeased.GameOfferId = SelectedGameOfferId;
            var gameOffer = await _gameOfferService.GetByIdAsync(GameLeased.GameOfferId);
            if (gameOffer is null || gameOffer.Amount <= 0)
            {
                ModelState.AddModelError(nameof(GameLeased.GameOfferId), "Game offer is not available");
            }
            else
            {
                gameOffer.Amount -= 1;
                await _gameOfferService.UpdateAsync(gameOffer);

                var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                GameLeased.RenterId = userId;
                GameLeased.Active = true;
                GameLeased.Price = gameOffer.Price;
            }

            ModelState.ClearValidationState(nameof(GameLeased));
            if (!TryValidateModel(GameLeased, nameof(GameLeased)))
            {
                return Page();
            }

            await _gameLeasedService.AddAsync(GameLeased);

            return RedirectToPage("/GameLeased/Index");
        }
    }
}
