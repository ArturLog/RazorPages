using Application.Repositories.Interfaces;
using Domain.Entities;
using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories.Classes
{
    public class ApplicationUserRepository(IApplicationDbContext context) : ICrudRepository<ApplicationUser>
    {
        public async Task<ApplicationUser> Create(ApplicationUser entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            context.Users.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<ApplicationUser?> Read(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<List<ApplicationUser>> ReadAll()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<bool> Update(ApplicationUser entity)
        {
            var user = await context.Users.FindAsync(entity.Id);
            if (user is null)
                return false;
            user.Email = entity.Email;
            await context.SaveChangesAsync();
            return true;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(string id)
        {
            var user = await context.Users.FindAsync(id);
            if (user is null)
                return false;
            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
