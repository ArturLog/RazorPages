using Application.Common.Interfaces;
using Application.Repositories.Classes;
using Application.Services.Interfaces;
using Domain.Entities;

namespace Application.Services.Classes
{
    public class RentService : IRentService
    {
        private readonly GameOfferRepository _gameOfferRepository;
        private readonly GameLeasedRepository _gameLeasedRepository;

        public RentService(IApplicationDbContext context)
        {
            _gameOfferRepository = new GameOfferRepository(context);
            _gameLeasedRepository = new GameLeasedRepository(context);
        }
        public async Task<GameLeased> RentGameAsync(GameOffer gameOffer, DateTime dateTo)
        {
            var gameLeased = new GameLeased()
            {
                DateFrom = DateTime.Today,
                DateTo = dateTo,
                GameId = gameOffer.GameId,
                Price = gameOffer.Price,
                GameOfferId = gameOffer.Id,
                Active = true
            };
            await _gameLeasedRepository.Create(gameLeased);
            gameOffer.Amount -= 1;
            await _gameOfferRepository.Update(gameOffer);
            return gameLeased;
        }

        public async Task<bool> ReturnGameAsync(GameLeased gameLeased)
        {
            gameLeased.Active = false;
            gameLeased.GameOffer.Amount += 1;
            return true;
        }
    }
}
