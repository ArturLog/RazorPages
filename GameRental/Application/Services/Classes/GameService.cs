using Application.Repositories.Interfaces;
using Domain.Entities;

namespace Application.Services.Classes
{
    public class GameService
    {
        private readonly ICrudRepository<Game> _gameRepository;
        public GameService(ICrudRepository<Game> gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<IEnumerable<Game>> GetAllGames()
        {
            return await _gameRepository.ReadAll();
        }

        public async Task<Game?> GetGameById(int id)
        {
            return await _gameRepository.Read(id);
        }

        public async Task<Game> AddGame(Game game)
        {
            return await _gameRepository.Create(game);
        }

        public async Task<bool> UpdateGame(Game game)
        {
            return await _gameRepository.Update(game);
        }

        public async Task<bool> DeleteGame(int id)
        {
            return await _gameRepository.Delete(id);
        }
    }
}
