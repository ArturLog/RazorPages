using System.Reflection;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
        public ApplicationDbContext() { }
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GameLeased> GamesLeased { get; set; }
        public DbSet<GameOffer> GamesOffered { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=sqlite.db");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.LeasedGames)
                .WithOne(l => l.Renter)
                .OnDelete(DeleteBehavior.SetNull);
            builder.Entity<ApplicationUser>()
                .HasMany(u => u.OfferGames)
                .WithOne(o => o.Owner)
                .OnDelete(DeleteBehavior.SetNull);


            builder.Entity<Game>()
                .HasMany(g => g.Leases)
                .WithOne(l => l.Game)
                .OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Game>()
                .HasMany(g => g.Offers)
                .WithOne(o => o.Game)
                .OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Game>()
                .HasMany(g => g.Genres)
                .WithMany(g => g.Games);

            builder.Entity<GameOffer>()
                .HasMany(l => GamesLeased)
                .WithOne(l => l.GameOffer)
                .OnDelete(DeleteBehavior.SetNull);

        }
        public async Task<Guid> SaveChangesAsync()
        {
            await base.SaveChangesAsync();
            return Guid.NewGuid();
        }
    }
}
