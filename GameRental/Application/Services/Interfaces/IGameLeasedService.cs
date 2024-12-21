using Application.ModelsDTO;

namespace Application.Services.Interfaces
{
    public interface IGameLeasedService
    {
        Task<GameLeasedDTO?> GetByIdAsync(int id);
        Task<IEnumerable<GameLeasedDTO?>> GetAllAsync();
        Task AddAsync(GameLeasedDTO gameLeasedDto);
        Task UpdateAsync(GameLeasedDTO gameLeasedDto);
        Task DeleteAsync(int id);
    }
}
