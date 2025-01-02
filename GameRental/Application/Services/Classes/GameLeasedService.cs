using Application.ModelsDTO;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Repositories.Interfaces;

namespace Application.Services.Classes
{
    public class GameLeasedService : IGameLeasedService
    {
        private readonly IGameLeasedRepository _repository;

        private readonly IGameOfferService _gameOfferService;
        private readonly IApplicationUserService _applicationUserService;
        public GameLeasedService(IGameLeasedRepository gameLeasedRepository, IGameOfferRepository gameOfferRepository, IApplicationUserRepository userRepository, IGameOfferService gameOfferService, IGameService gameService, IApplicationUserService applicationUserService)
        {
            _repository = gameLeasedRepository;

            _gameOfferService = gameOfferService;
            _applicationUserService = applicationUserService;
        }

        public async Task<IEnumerable<GameLeasedDTO?>> GetAllAsync()
        {
            var gameLeased = await _repository.GetAllAsync();
            var result = await Task.WhenAll(gameLeased.Select(async g => new GameLeasedDTO
            {
	            Id = g.Id,
				DateFrom = DateOnly.FromDateTime(g.DateFrom),
                DateTo = DateOnly.FromDateTime(g.DateTo),
                Price = g.Price,
                Active = g.Active,
                GameOfferId = g.GameOfferId,
                RenterId = g.RenterId,
                GameOffer = await _gameOfferService.GetByIdAsync(g.GameOfferId),
                Renter = await _applicationUserService.GetByIdAsync(g.RenterId),
            }));
            return result;
        }

        public async Task<GameLeasedDTO?> GetByIdAsync(int id)
        {
            var gameLeased = await _repository.GetByIdAsync(id);
            return gameLeased is not null ? new GameLeasedDTO
            {
                Id = gameLeased.Id,
                DateFrom = DateOnly.FromDateTime(gameLeased.DateFrom),
                DateTo = DateOnly.FromDateTime(gameLeased.DateTo),
                Price = gameLeased.Price,
                Active = gameLeased.Active,
                GameOfferId = gameLeased.GameOfferId,
                RenterId = gameLeased.RenterId,
                GameOffer = await _gameOfferService.GetByIdAsync(gameLeased.GameOfferId),
                Renter = await _applicationUserService.GetByIdAsync(gameLeased.RenterId),
            } : null;
        }

        public async Task AddAsync(GameLeasedDTO gameLeasedDto)
        {
            var gameLeased = new GameLeased
            {
                DateFrom = gameLeasedDto.DateFrom.ToDateTime(TimeOnly.MinValue),
                DateTo = gameLeasedDto.DateTo.ToDateTime(TimeOnly.MinValue),
                Price = gameLeasedDto.Price,
                Active = gameLeasedDto.Active,
                GameOfferId = gameLeasedDto.GameOfferId,
                RenterId = gameLeasedDto.RenterId,
            };
            await _repository.AddAsync(gameLeased);
        }

        public async Task UpdateAsync(GameLeasedDTO gameLeasedDto)
        {
            var gameLeased = new GameLeased
            {
                Id = gameLeasedDto.Id,
                DateFrom = gameLeasedDto.DateFrom.ToDateTime(TimeOnly.MinValue),
                DateTo = gameLeasedDto.DateTo.ToDateTime(TimeOnly.MinValue),
                Price = gameLeasedDto.Price,
                Active = gameLeasedDto.Active,
                GameOfferId = gameLeasedDto.GameOfferId,
                RenterId = gameLeasedDto.RenterId,
            };
            await _repository.UpdateAsync(gameLeased);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
