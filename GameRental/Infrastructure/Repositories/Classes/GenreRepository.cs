using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Classes
{
    public class GenreRepository(IApplicationDbContext context) : IGenreRepository
    {
        public async Task<Genre?> GetByIdAsync(int id)
        {
            return await context.Genres.FindAsync(id);
        }

        public async Task<IEnumerable<Genre?>> GetAllAsync()
        {
            return await context.Genres.ToListAsync();
        }
        public async Task AddAsync(Genre genre)
        {
            context.Genres.Add(genre);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Genre genre)
        {
            context.Genres.Update(genre);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var genre = await context.Genres.FindAsync(id);
            if (genre is not null)
            {
                context.Genres.Remove(genre);
                await context.SaveChangesAsync();
            }
        }
    }
}
