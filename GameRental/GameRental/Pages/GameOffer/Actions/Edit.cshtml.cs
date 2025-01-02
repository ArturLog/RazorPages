using Application.ModelsDTO;
using Application.Services.Classes;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameRental.Pages.GameOffer
{
    public class EditModel : PageModel
    {
        private readonly IGameOfferService _gameOfferService;
        private readonly IGameService _gameService;
        private readonly IApplicationUserService _applicationUserService;
        public EditModel(IGameOfferService gameOfferService, IGameService gameService, IApplicationUserService applicationUserService)
        {
            _gameOfferService = gameOfferService;
            _gameService = gameService;
            _applicationUserService = applicationUserService;
        }
        [BindProperty]
        public GameOfferDTO GameOffer { get; set; } = default!;

        [BindProperty]
        public IEnumerable<GameDTO?> Games { get; set; } = default!;
        [BindProperty]
        public int SelectedGameId { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var gameOffer = await _gameOfferService.GetByIdAsync(id);
            if (gameOffer == null)
            {
                return NotFound();
            }
            else
            {
                GameOffer = gameOffer;
            }
            Games = await _gameService.GetAllAsync();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {

            GameOffer.GameId = SelectedGameId;

            ModelState.ClearValidationState(nameof(GameOffer));
            if (!TryValidateModel(GameOffer, nameof(GameOffer)))
            {
                return Page();
            }

            await _gameOfferService.UpdateAsync(GameOffer);

            return RedirectToPage("/GameOffer/Index");
        }
    }
}
