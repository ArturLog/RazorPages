using Domain.Entities;

namespace Domain.Repositories.Interfaces
{
    public interface IApplicationUserRepository
    {
        Task<ApplicationUser?> GetByIdAsync(string id);
        Task<IEnumerable<ApplicationUser?>> GetAllAsync();
        Task AddAsync(ApplicationUser applicationUser);
        Task UpdateAsync(ApplicationUser applicationUser);
        Task DeleteAsync(string id);
    }
}
