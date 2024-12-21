using Application.ModelsDTO;
using Application.Services.Interfaces;

namespace Application.Services.Classes
{
    public class GameOfferService : IGameOfferService
    {
        public Task<GameOfferDTO?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GameOfferDTO?>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(GameOfferDTO gameOfferDto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(GameOfferDTO gameOfferDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
