using Domain.Entities;

namespace Domain.Repositories.Interfaces
{
    public interface IGameLeasedRepository
    {
        Task<GameLeased> GetByIdAsync(int id);
        Task<IEnumerable<GameLeased>> GetAllAsync();
        Task AddAsync(GameLeased gameLeased);
        Task UpdateAsync(GameLeased gameLeased);
        Task DeleteAsync(int id);
    }
}
