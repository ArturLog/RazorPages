using Application.ModelsDTO;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Repositories.Interfaces;

namespace Application.Services.Classes
{
    public class GameLeasedService : IGameLeasedService
    {
        private readonly IGameLeasedRepository _repository;
        private readonly IGameOfferRepository _gameOfferRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IApplicationUserRepository _userRepository;

        private readonly IGameOfferService _gameOfferService;
        private readonly IGameService _gameService;
        private readonly IApplicationUserService _applicationUserService;
        public GameLeasedService(IGameLeasedRepository gameLeasedRepository, IGameOfferRepository gameOfferRepository, IGameRepository gameRepository, IApplicationUserRepository userRepository, IGameOfferService gameOfferService, IGameService gameService, IApplicationUserService applicationUserService)
        {
            _repository = gameLeasedRepository;
            _gameOfferRepository = gameOfferRepository;
            _gameRepository = gameRepository;
            _userRepository = userRepository;

            _gameOfferService = gameOfferService;
            _gameService = gameService;
            _applicationUserService = applicationUserService;
        }

        public async Task<IEnumerable<GameLeasedDTO?>> GetAllAsync()
        {
            var gameLeased = await _repository.GetAllAsync();
            return (IEnumerable<GameLeasedDTO?>)gameLeased.Select(async g => new GameLeasedDTO
            {
	            Id = g.Id,
				DateFrom = DateOnly.FromDateTime(g.DateFrom),
                DateTo = DateOnly.FromDateTime(g.DateTo),
                Price = g.Price,
                Active = g.Active,
                GameOffer = await _gameOfferService.GetByIdAsync(g.GameOfferId),
                Renter = await _applicationUserService.GetByIdAsync(g.RenterId),
                Game = await _gameService.GetByIdAsync(g.GameId)
            }).ToList();
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
                GameOffer = await _gameOfferService.GetByIdAsync(gameLeased.GameOfferId),
                Renter = await _applicationUserService.GetByIdAsync(gameLeased.RenterId),
                Game = await _gameService.GetByIdAsync(gameLeased.GameId)
            } : null;
        }

        public async Task AddAsync(GameLeasedDTO gameLeasedDto)
        {
            var existingGames = await _gameRepository.GetAllAsync();
            var existingUsers = await _userRepository.GetAllAsync();
            var existingGameOffer = await _gameOfferRepository.GetAllAsync();
            var gameLeased = new GameLeased
            {
                DateFrom = gameLeasedDto.DateFrom.ToDateTime(TimeOnly.MinValue),
                DateTo = gameLeasedDto.DateTo.ToDateTime(TimeOnly.MinValue),
                Price = gameLeasedDto.Price,
                Active = gameLeasedDto.Active,
                GameOffer = existingGameOffer.Where(gameOffer => gameLeasedDto.GameOffer.Id == gameOffer.Id).FirstOrDefault(),
                Renter = existingUsers.Where(user => gameLeasedDto.Renter.Id == user.Id).FirstOrDefault(),
                Game = existingGames.Where(game => gameLeasedDto.Game.Id == game.Id).FirstOrDefault()
            };
            await _repository.AddAsync(gameLeased);
        }

        public async Task UpdateAsync(GameLeasedDTO gameLeasedDto)
        {
            var existingGames = await _gameRepository.GetAllAsync();
            var existingUsers = await _userRepository.GetAllAsync();
            var existingGameOffer = await _gameOfferRepository.GetAllAsync();
            var gameLeased = new GameLeased
            {
                Id = gameLeasedDto.Id,
                DateFrom = gameLeasedDto.DateFrom.ToDateTime(TimeOnly.MinValue),
                DateTo = gameLeasedDto.DateTo.ToDateTime(TimeOnly.MinValue),
                Price = gameLeasedDto.Price,
                Active = gameLeasedDto.Active,
                GameOffer = existingGameOffer.Where(gameOffer => gameLeasedDto.GameOffer.Id == gameOffer.Id).FirstOrDefault(),
                Renter = existingUsers.Where(user => gameLeasedDto.Renter.Id == user.Id).FirstOrDefault(),
                Game = existingGames.Where(game => gameLeasedDto.Game.Id == game.Id).FirstOrDefault()
            };
            await _repository.UpdateAsync(gameLeased);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
