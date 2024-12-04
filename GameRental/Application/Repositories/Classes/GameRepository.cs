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
            var game = await context.Games.FindAsync(entity.Id);
            if (game is null)
                return false;
            game.Genres = entity.Genres;
            game.Description = entity.Description;
            game.Title = entity.Title;
            game.ReleaseDate = entity.ReleaseDate;
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var game = await context.Games.FindAsync(id);
            if (game is null)
                return false;
            context.Games.Remove(game);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
