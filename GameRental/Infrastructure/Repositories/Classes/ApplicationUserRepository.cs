using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Classes
{
    public class ApplicationUserRepository(IApplicationDbContext context) : IApplicationUserRepository
    {
        public async Task<ApplicationUser?> GetByIdAsync(string id)
        {
            return await context.ApplicationUsers.FindAsync(id);
        }

        public async Task<IEnumerable<ApplicationUser?>> GetAllAsync()
        {
            return await context.ApplicationUsers.ToListAsync();

        }

        public async Task AddAsync(ApplicationUser applicationUser)
        {
            context.ApplicationUsers.Add(applicationUser);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ApplicationUser applicationUser)
        {
            context.ApplicationUsers.Update(applicationUser);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var user = await context.ApplicationUsers.FindAsync(id);
            if (user is not null)
            {
                context.ApplicationUsers.Remove(user);
                await context.SaveChangesAsync();
            }
        }
    }
}
