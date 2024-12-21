using Application.ModelsDTO;
using Application.Services.Interfaces;

namespace Application.Services.Classes
{
    internal class GameLeasedService : IGameLeasedService
    {
        public Task<GameLeasedDTO?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GameLeasedDTO?>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(GameLeasedDTO gameLeasedDto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(GameLeasedDTO gameLeasedDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
