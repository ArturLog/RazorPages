using Domain.Entities;

namespace Domain.Repositories.Interfaces
{
    public interface IGameOfferRepository
    {
        Task<GameOffer> GetByIdAsync(int id);
        Task<IEnumerable<GameOffer>> GetAllAsync();
        Task AddAsync(GameOffer gameOffer);
        Task UpdateAsync(GameOffer gameOffer);
        Task DeleteAsync(int id);
    }
}
