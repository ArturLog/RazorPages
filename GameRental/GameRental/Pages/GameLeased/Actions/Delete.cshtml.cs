using Application.ModelsDTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameRental.Pages.GameLeased
{
    public class DeleteModel : PageModel
    {
        private readonly IGameLeasedService _gameLeasedService;
        public DeleteModel(IGameLeasedService gameLeasedService)
        {
            _gameLeasedService = gameLeasedService;
        }
        [BindProperty]
        public GameLeasedDTO GameLeased { get; set; }
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
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var gameLeased = await _gameLeasedService.GetByIdAsync(id);
            if (gameLeased != null)
            {
                GameLeased = gameLeased;
                await _gameLeasedService.DeleteAsync(id);
            }
            else
            {
                return NotFound();
            }

            return RedirectToPage("/GameLeased/Index");
        }
    }
}
