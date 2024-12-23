using Application.ModelsDTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameRental.Pages.Game.Actions
{
    public class DetailsModel : PageModel
    {
		private readonly IGameService _gameService;
		public DetailsModel(IGameService gameService)
		{
			_gameService = gameService;
		}
		public GameDTO Game { get; set; } = default!;
		public async Task<IActionResult> OnGetAsync(int id)
	    {
		    var game = await _gameService.GetByIdAsync(id);
		    if (game == null)
		    {
			    return NotFound();
		    }
		    else
		    {
			    Game = game;
		    }
		    return Page();
	    }
	}
}
