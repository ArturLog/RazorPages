using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Classes
{
    public class GameLeasedRepository(IApplicationDbContext context) : IGameLeasedRepository
    {
        public async Task<GameLeased?> GetByIdAsync(int id)
        {
            return await context.GamesLeased.FindAsync(id);
        }

        public async Task<IEnumerable<GameLeased?>> GetAllAsync()
        {
            return await context.GamesLeased.ToListAsync();
        }
        public async Task AddAsync(GameLeased gameLeased)
        {
            context.GamesLeased.Add(gameLeased);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(GameLeased gameLeased)
        {
            context.GamesLeased.Update(gameLeased);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var gameLeased = await context.GamesLeased.FindAsync(id);
            if (gameLeased is not null)
            {
                context.GamesLeased.Remove(gameLeased);
                await context.SaveChangesAsync();
            }
        }
    }
}
