using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<GameOffer>? OfferGames { get; set; } = [];
        public ICollection<GameLeased>? LeasedGames { get; set; } = [];
    }
}
