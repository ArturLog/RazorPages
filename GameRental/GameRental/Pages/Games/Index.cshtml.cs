using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GameRental.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IList<GameOffer> GameOffers { get; set; } = default!;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            GameOffers = await _context.GamesOffered.ToListAsync();
        }
    }
}