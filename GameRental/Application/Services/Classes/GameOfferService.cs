using Application.ModelsDTO;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Repositories.Interfaces;

namespace Application.Services.Classes
{
    public class GameOfferService : IGameOfferService
    {
        private readonly IGameOfferRepository _gameOfferRepository;

        private readonly IGameService _gameService;
        private readonly IApplicationUserService _applicationUserService;
        public GameOfferService(IGameOfferRepository gameOfferRepository, IGameRepository gameRepository, IApplicationUserRepository userRepository, IGameService gameService, IApplicationUserService applicationUserService)
        {
            _gameOfferRepository = gameOfferRepository;

            _gameService = gameService;
            _applicationUserService = applicationUserService;
        }

        public async Task<IEnumerable<GameOfferDTO?>> GetAllAsync()
        {
            var gameOffer = await _gameOfferRepository.GetAllAsync();
            var result = await Task.WhenAll(gameOffer.Select(async g => new GameOfferDTO
            {
                Id = g.Id,
                Price = g.Price,
                Amount = g.Amount,
                GameId = g.GameId,
                OwnerId = g.OwnerId,
                Game = await _gameService.GetByIdAsync(g.GameId),
                Owner = await _applicationUserService.GetByIdAsync(g.OwnerId)
            }));

            return result;
        }

        public async Task<GameOfferDTO?> GetByIdAsync(int id)
        {
            var gameOffer = await _gameOfferRepository.GetByIdAsync(id);
            return gameOffer is not null ? new GameOfferDTO
            {
                Id = gameOffer.Id,
                Price = gameOffer.Price,
                Amount = gameOffer.Amount,
                GameId = gameOffer.GameId,
                OwnerId = gameOffer.OwnerId,
                Game = await _gameService.GetByIdAsync(gameOffer.GameId),
                Owner = await _applicationUserService.GetByIdAsync(gameOffer.OwnerId)
            } : null;
        }

        public async Task AddAsync(GameOfferDTO gameOfferDto)
        {
            var gameOffer = new GameOffer
            {
                Price = gameOfferDto.Price,
                Amount = gameOfferDto.Amount,
                GameId = gameOfferDto.GameId,
                OwnerId = gameOfferDto.OwnerId,
            };
            await _gameOfferRepository.AddAsync(gameOffer);
        }

        public async Task UpdateAsync(GameOfferDTO gameOfferDto)
        {
            var gameOffer = new GameOffer
            {
                Id = gameOfferDto.Id,
                Price = gameOfferDto.Price,
                Amount = gameOfferDto.Amount,
                GameId = gameOfferDto.GameId,
                OwnerId = gameOfferDto.OwnerId,
            };
            await _gameOfferRepository.UpdateAsync(gameOffer);
        }

        public async Task DeleteAsync(int id)
        {
            await _gameOfferRepository.DeleteAsync(id);
        }
    }
}
