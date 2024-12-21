using Domain.Entities;

namespace Domain.Repositories.Interfaces
{
    public interface IApplicationUserRepository
    {
        Task<ApplicationUser> GetByIdAsync(string id);
        Task<IEnumerable<ApplicationUser>> GetAllAsync();
        Task AddAsync(ApplicationUser gameLeased);
        Task UpdateAsync(ApplicationUser gameLeased);
        Task DeleteAsync(string id);
    }
}
