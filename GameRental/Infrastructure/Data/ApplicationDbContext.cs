using System.Reflection;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
        public ApplicationDbContext() { }
        ChangeTracker ChangeTracker => base.ChangeTracker;
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GameLeased> GamesLeased { get; set; }
        public DbSet<GameOffer> GamesOffered { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

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
                .HasMany(g => g.Offers)
                .WithOne(o => o.Game)
                .OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Game>()
                .HasMany(g => g.Genres)
                .WithMany(g => g.Games);

            builder.Entity<GameOffer>()
                .HasMany(l => l.LeasedGames)
                .WithOne(o => o.GameOffer)
                .OnDelete(DeleteBehavior.SetNull);

        }
        public async Task<Guid> SaveChangesAsync()
        {
            await base.SaveChangesAsync();
            return Guid.NewGuid();
        }
    }
}
