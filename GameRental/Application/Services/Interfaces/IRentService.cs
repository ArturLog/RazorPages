
using Bogus.DataSets;
using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IRentService
    {
        Task<GameLeased> RentGameAsync(GameOffer gameOffer, DateTime dateTo);
        Task<bool> ReturnGameAsync(GameLeased gameLeased);
    }
}
