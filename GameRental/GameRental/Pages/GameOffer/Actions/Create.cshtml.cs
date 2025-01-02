using Application.ModelsDTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameRental.Pages.GameOffer
{
    public class CreateModel : PageModel
    {
        private readonly IGameOfferService _gameOfferService;
        private readonly IGameService _gameService;
        private readonly IApplicationUserService _applicationUserService;

        public CreateModel(IGameService gameService, IGameOfferService gameOfferService, IApplicationUserService applicationUserService)
        {
            _gameService = gameService;
            _applicationUserService = applicationUserService;
            _gameOfferService = gameOfferService;
        }
        [BindProperty]
        public GameOfferDTO GameOffer { get; set; } = default!;
        [BindProperty]

        public IEnumerable<GameDTO?> Games { get; set; } = default!;

        [BindProperty]
        public int SelectedGameId { get; set; } = default!;

        public async Task<IActionResult> OnGet()
        {
            Games = await _gameService.GetAllAsync();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            GameOffer.GameId = SelectedGameId;
            GameOffer.Game = await _gameService.GetByIdAsync(SelectedGameId);
            if(GameOffer.Game == null)
            {
                ModelState.AddModelError("GameOffer.Game", "The selected game could not be found.");
            }


            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            GameOffer.OwnerId = userId;
            GameOffer.Owner = await _applicationUserService.GetByIdAsync(userId);
            if (GameOffer.Owner == null)
            {
                ModelState.AddModelError("GameOffer.Owner", "The user could not be found.");
            }

            ModelState.ClearValidationState(nameof(GameOffer));
            if (!TryValidateModel(GameOffer, nameof(GameOffer)))
            {
                return Page();
            }

            await _gameOfferService.AddAsync(GameOffer);

            return RedirectToPage("/GameOffer/Index");
        }
    }
}
