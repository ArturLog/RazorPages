using Application.Common.Interfaces;
using Application.Repositories.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories.Classes
{
    public class GameRepository(IApplicationDbContext context) : ICrudRepository<Game>
    {
        public async Task<Game> Create(Game entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            context.Games.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<Game?> Read(int id)
        {
            return await context.Games.FindAsync(id);
        }

        public async Task<List<Game>> ReadAll()
        {
            return await context.Games.ToListAsync();
        }

        public async Task<bool> Update(Game entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
