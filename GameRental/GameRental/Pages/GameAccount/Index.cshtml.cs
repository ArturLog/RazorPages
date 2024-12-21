using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GameRental.Pages.GameAccount
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IList<GameOffer> GameOffers { get; set; } = default!;
        public IList<GameLeased> LeasedGames { get; set; } = default!;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task OnGetAsync()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            GameOffers = await _context.GamesOffered.Where(g => g.OwnerId == currentUserId).ToListAsync();
            LeasedGames = await _context.GamesLeased.Where(g => g.RenterId == currentUserId).ToListAsync();
        }
    }
}
