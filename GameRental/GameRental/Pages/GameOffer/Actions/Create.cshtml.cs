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
        public IEnumerable<ApplicationUserDTO?> Users { get; set; } = default!;

        [BindProperty]
        public int SelectedGameId { get; set; } = default!;

        [BindProperty]
        public int SelectedRenterId { get; set; } = default!;

        public async Task<IActionResult> OnGet()
        {
            Games = await _gameService.GetAllAsync();
            Users = await _applicationUserService.GetAllAsync();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {

            GameOffer.Game = await _gameService.GetByIdAsync(SelectedGameId);
            if(GameOffer.Game == null) 
                return RedirectToPage("/GameOffer/Actions/Create");

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            GameOffer.Owner = await _applicationUserService.GetByIdAsync(userId);
            if (GameOffer.Owner == null)
            {
                return RedirectToPage("/GameOffer/Actions/Create");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _gameOfferService.AddAsync(GameOffer);

            return RedirectToPage("/GameOffer/Index");
        }
    }
}
