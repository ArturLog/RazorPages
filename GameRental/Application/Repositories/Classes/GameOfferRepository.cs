using Application.Repositories.Interfaces;
using Domain.Entities;
using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories.Classes
{
    public class GameOfferRepository(IApplicationDbContext context) : ICrudRepository<GameOffer>
    {
        public async Task<GameOffer> Create(GameOffer entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            context.GamesOffered.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<GameOffer?> Read(int id)
        {
            return await context.GamesOffered.FindAsync(id);
        }

        public async Task<List<GameOffer>> ReadAll()
        {
            return await context.GamesOffered.ToListAsync();
        }

        public async Task<bool> Update(GameOffer entity)
        {
            var gameOffer = await context.GamesOffered.FindAsync(entity.Id);
            if (gameOffer is null)
                return false;
            gameOffer.Price = entity.Price;
            gameOffer.Amount = entity.Amount;
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var gameOffer = await context.GamesOffered.FindAsync(id);
            if (gameOffer is null)
                return false;
            context.GamesOffered.Remove(gameOffer);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
