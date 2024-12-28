using Application.ModelsDTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameRental.Pages.GameOffer
{
    public class IndexModel : PageModel
    {
        private readonly IGameOfferService _gameOfferService;
        public IEnumerable<GameOfferDTO?> OfferGames { get; set; } = default!;

        public IndexModel(IGameOfferService gameOfferService)
        {
            _gameOfferService = gameOfferService;
        }

        public async Task OnGetAsync()
        {
            OfferGames = await _gameOfferService.GetAllAsync();
        }
    }
}
