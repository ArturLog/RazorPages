using Application.ModelsDTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameRental.Pages.GameOffer
{
    public class DeleteModel : PageModel
    {
        private readonly IGameOfferService _gameOfferService;
        public DeleteModel(IGameOfferService gameOfferService)
        {
            _gameOfferService = gameOfferService;
        }
        [BindProperty]
        public GameOfferDTO GameOffer { get; set; }
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
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var gameOffer = await _gameOfferService.GetByIdAsync(id);
            if (gameOffer != null)
            {
                GameOffer = gameOffer;
                await _gameOfferService.DeleteAsync(id);
            }
            else
            {
                return NotFound();
            }

            return RedirectToPage("/GameOffer/Index");
        }
    }
}
