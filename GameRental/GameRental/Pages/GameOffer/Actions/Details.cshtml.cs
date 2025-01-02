using Application.ModelsDTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameRental.Pages.GameOffer
{
    public class DetailsModel : PageModel
    {
        private readonly IGameOfferService _gameOfferService;
        public DetailsModel(IGameOfferService gameOfferService)
        {
            _gameOfferService = gameOfferService;
        }
        public GameOfferDTO GameOffer { get; set; } = default!;
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
            return Page();
        }
    }
}
