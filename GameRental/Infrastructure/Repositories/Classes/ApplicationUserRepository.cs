using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;

namespace Infrastructure.Repositories.Classes
{
    public class ApplicationUserRepository(IApplicationDbContext _context) : IApplicationUserRepository
    {
        public async Task<ApplicationUser?> GetByIdAsync(string id)
        {
            return await _context.ApplicationUsers
                .Include(u => u.OfferGames)
                .Include(u => u.LeasedGames)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            return await _context.ApplicationUsers
                .Include(u => u.OfferGames)
                .Include(u => u.LeasedGames)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddAsync(ApplicationUser applicationUser)
        {
            if (applicationUser == null)
                throw new ArgumentNullException(nameof(applicationUser));

            _context.ApplicationUsers.Add(applicationUser);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ApplicationUser applicationUser)
        {
            if (applicationUser == null)
                throw new ArgumentNullException(nameof(applicationUser));

            _context.ApplicationUsers.Update(applicationUser);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var user = await GetByIdAsync(id);
            if (user is null)
                throw new InvalidOperationException($"User with ID {id} not found.");

            _context.ApplicationUsers.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
