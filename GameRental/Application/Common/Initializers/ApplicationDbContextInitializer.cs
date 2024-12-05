using Application.Common.Interfaces;
using Bogus;
using Domain.Entities;

namespace Application.Common.Initializers
{
    public class ApplicationDbContextInitializer(IApplicationDbContext context)
    {
        public async Task SeedSampleData(int amountOfGenres=10, int amountOfGames=10, int amountOfOffers=10, int amountOfLeased=10)
        {
            var faker = new Faker();
            var random = new Random();
            var users = new List<ApplicationUser>();
            var games = new List<Game>();
            var genres = new List<Genre>();
            var gameLeased = new List<GameLeased>();
            var gameOffer = new List<GameOffer>();

            var user = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@admin.pl",
                PasswordHash = "admin"
            };
            users.Add(user);
            context.Users.AddRange(users);
            await context.SaveChangesAsync();

            for(int i = 0; i < amountOfGenres; i++)
            {
                var genre = new Genre
                {
                    Name = faker.Music.Genre()
                };
                genres.Add(genre);
            }
            context.Genres.AddRange(genres);
            await context.SaveChangesAsync();

            for (int i = 0; i < amountOfGames; i++)
            {
                var game = new Game
                {
                    Title = faker.Random.String2(10),
                    Description = faker.Random.String2(100),
                    ReleaseDate = faker.Date.Past(),
                    Genres = genres.OrderBy(x => random.Next()).Take(3).ToList()
                };
                games.Add(game);
            }

            context.Games.AddRange(games);
            await context.SaveChangesAsync();

            for(int i = 0; i < amountOfOffers; i++)
            {
                var userOffered = users.OrderBy(x => random.Next()).First();
                var gameOffered = games.OrderBy(x => random.Next()).First();
                var offer = new GameOffer
                {
                    OwnerId = userOffered.Id,
                    GameId = gameOffered.Id,
                    Price = faker.Random.Double(1, 1000),
                    Amount = faker.Random.Int(1, 100)
                };
                gameOffer.Add(offer);
            }
            context.GamesOffered.AddRange(gameOffer);
            await context.SaveChangesAsync();

            for (int i = 0; i < amountOfLeased; i++)
            {
                var userLeased = users.OrderBy(x => random.Next()).First();
                var gameGameLeased = games.OrderBy(x => random.Next()).First();
                var leased = new GameLeased
                {
                    DateFrom = faker.Date.Past(),
                    DateTo = faker.Date.Future(),
                    GameId = gameGameLeased.Id,
                    RenterId = userLeased.Id,
                    Price = faker.Random.Double(1, 1000)
                };
                gameLeased.Add(leased);
            }

            context.GamesLeased.AddRange(gameLeased);
            await context.SaveChangesAsync();

        }
    }
}
