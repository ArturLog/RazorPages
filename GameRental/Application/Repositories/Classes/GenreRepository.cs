
using Application.Common.Interfaces;
using Application.Repositories.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories.Classes
{
    public class GenreRepository(IApplicationDbContext context) : ICrudRepository<Genre>
    {
        public async Task<Genre> Create(Genre entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            context.Genres.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<Genre?> Read(int id)
        {
            return await context.Genres.FindAsync(id);
        }

        public async Task<List<Genre>> ReadAll()
        {
            return await context.Genres.ToListAsync();
        }

        public async Task<bool> Update(Genre entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            context.Genres.Update(entity);
            var changes = await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var genre = await context.Genres.FirstOrDefaultAsync(x => x.Id == id);
            if (genre == null)
                return false;
            context.Genres.Remove(genre);
            var changes = await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
