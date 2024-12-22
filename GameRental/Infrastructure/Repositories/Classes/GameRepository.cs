using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Classes
{
    public class GameRepository(IApplicationDbContext context) : IGameRepository
    {
        public async Task<Game?> GetByIdAsync(int id)
        {
            return await context.Games.Include(g => g.Genres).FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<IEnumerable<Game?>> GetAllAsync()
        {
            return await context.Games.Include(g => g.Genres).ToListAsync();
        }
        public async Task AddAsync(Game game)
        {
            context.Games.Add(game);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Game game)
        {
            context.Games.Update(game);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var game = await context.Games.FindAsync(id);
            if (game is not null)
            {
                context.Games.Remove(game);
                await context.SaveChangesAsync();
            }
        }
    }
}
