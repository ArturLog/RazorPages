using Application.ModelsDTO;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Repositories.Interfaces;

namespace Application.Services.Classes
{
    public class GameOfferService : IGameOfferService
    {
        private readonly IGameOfferRepository _repository;
        public GameOfferService(IGameOfferRepository gameOfferRepository)
        {
            _repository = gameOfferRepository;
        }

        public async Task<IEnumerable<GameOfferDTO?>> GetAllAsync()
        {
            var gameOffer = await _repository.GetAllAsync();
            return gameOffer.Select(g => new GameOfferDTO
            {
                Price = g.Price,
                Amount = g.Amount,
                GameId = g.GameId,
                OwnerId = g.OwnerId
            }).ToList();
        }

        public async Task<GameOfferDTO?> GetByIdAsync(int id)
        {
            var gameOffer = await _repository.GetByIdAsync(id);
            return gameOffer is not null ? new GameOfferDTO
            {
                Id = gameOffer.Id,
                Price = gameOffer.Price,
                Amount = gameOffer.Amount,
                GameId = gameOffer.GameId,
                OwnerId = gameOffer.OwnerId
            } : null;
        }

        public async Task AddAsync(GameOfferDTO gameOfferDto)
        {
            var gameOffer = new GameOffer
            {
                Price = gameOfferDto.Price,
                Amount = gameOfferDto.Amount,
                GameId = gameOfferDto.GameId,
                OwnerId = gameOfferDto.OwnerId
            };
            await _repository.AddAsync(gameOffer);
        }

        public async Task UpdateAsync(GameOfferDTO gameOfferDto)
        {
            var gameOffer = new GameOffer
            {
                Id = gameOfferDto.Id,
                Price = gameOfferDto.Price,
                Amount = gameOfferDto.Amount,
                GameId = gameOfferDto.GameId,
                OwnerId = gameOfferDto.OwnerId
            };
            await _repository.UpdateAsync(gameOffer);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
