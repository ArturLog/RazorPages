using Application.ModelsDTO;

namespace Application.Services.Interfaces
{
    public interface IGameOfferService
    {
        Task<GameOfferDTO?> GetByIdAsync(int id);
        Task<IEnumerable<GameOfferDTO?>> GetAllAsync();
        Task AddAsync(GameOfferDTO gameOfferDto);
        Task UpdateAsync(GameOfferDTO gameOfferDto);
        Task DeleteAsync(int id);
    }
}
