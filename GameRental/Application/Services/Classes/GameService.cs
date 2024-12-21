using Application.ModelsDTO;
using Application.Services.Interfaces;
using Domain.Repositories.Interfaces;

namespace Application.Services.Classes
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _repository;
        public GameService(IGameRepository gameRepository)
        {
            _repository = gameRepository;
        }

        public async Task<List<GameDTO?>> GetGamesAsync()
        {
            var game = await _repository.GetAllAsync();
            return game.Select(g => new GameDTO
            {
                Id = g.Id,
                Title = g.Title,
                Description = g.Description,
                ReleaseDate = g.ReleaseDate.HasValue ? DateOnly.FromDateTime(g.ReleaseDate.Value) : (DateOnly?)null
            }).ToList();
        }

        public async Task<GameDTO?> GetGameByIdAsync(int id)
        {
            var game = await _repository.GetByIdAsync(id);
            return game is not null ? new GameDTO
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                ReleaseDate = game.ReleaseDate.HasValue ? DateOnly.FromDateTime(game.ReleaseDate.Value) : (DateOnly?)null
            } : null;
        }

        public Task<GameDTO?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GameDTO?>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(GameDTO gameDto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(GameDTO gameDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
