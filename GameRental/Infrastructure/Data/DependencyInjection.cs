using Application.Common.Initializers;
using Application.Common.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
using Application.Services.Classes;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Infrastructure.Repositories.Classes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<DbConnection, SqliteConnection>(serviceProvider =>
            {
                var connection = new SqliteConnection(@"Data Source=C:\Users\artur\Desktop\Studia\Sem7\RAI\RazorPages\RazorPages\GameRental\Infrastructure\sqlite.db");
                connection.Open();
                return connection;
            });

            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>((serviceProvider, options) =>
            {
                var connection = serviceProvider.GetRequiredService<DbConnection>();
                options.UseSqlite(connection);
            });

            services.AddScoped<ApplicationDbContextInitializer>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IGameOfferService, GameOfferService>();
            services.AddScoped<IGameOfferRepository, GameOfferRepository>();
            services.AddScoped<IGameLeasedService, GameLeasedService>();
            services.AddScoped<IGameLeasedRepository, GameLeasedRepository>();
            services.AddScoped<IApplicationUserService, ApplicationUserService>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.BuildServiceProvider();

            return services;
        }
    }

    public static class ServiceProviderExtensions
    {
        public static IServiceProvider UpdateDatabase(this IServiceProvider provider)
        {
            using (var scope = provider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            using (var context = scope.ServiceProvider.GetService<ApplicationDbContext>())
                context.Database.Migrate();

            return provider;
        }
    }
}
