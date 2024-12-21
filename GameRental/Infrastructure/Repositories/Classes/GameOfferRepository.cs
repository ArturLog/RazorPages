using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Classes
{
    public class GameOfferRepository(IApplicationDbContext context) : IGameOfferRepository
    {
        public async Task<GameOffer?> GetByIdAsync(int id)
        {
            return await context.GamesOffered.FindAsync(id);
        }

        public async Task<IEnumerable<GameOffer?>> GetAllAsync()
        {
            return await context.GamesOffered.ToListAsync();
        }
        public async Task AddAsync(GameOffer gameOffer)
        {
            context.GamesOffered.Add(gameOffer);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(GameOffer gameOffer)
        {
            context.GamesOffered.Update(gameOffer);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var gameOffer = await context.GamesOffered.FindAsync(id);
            if (gameOffer is not null)
            {
                context.GamesOffered.Remove(gameOffer);
                await context.SaveChangesAsync();
            }
        }
    }
}
