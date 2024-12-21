using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GameLeased> GamesLeased { get; set; }
        public DbSet<GameOffer> GamesOffered { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        Task<Guid> SaveChangesAsync();
    }
}