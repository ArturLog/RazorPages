using Application.ModelsDTO;

namespace Application.Services.Interfaces
{
    public interface IGameService
    {
        Task<GameDTO?> GetByIdAsync(int id);
        Task<IEnumerable<GameDTO?>> GetAllAsync();
        Task AddAsync(GameDTO gameDto);
        Task UpdateAsync(GameDTO gameDto);
        Task DeleteAsync(int id);
    }
}
