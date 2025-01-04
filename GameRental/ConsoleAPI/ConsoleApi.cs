using Bogus.DataSets;
using Domain.Entities;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApi
{
    class Program
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private const string BaseUrl = "https://localhost:7018/api/";

        static async Task Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("API Shooter");
                Console.WriteLine("1. Genre");
                Console.WriteLine("2. Game");
                Console.WriteLine("3. Game offer");
                Console.WriteLine("4. Game leased");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        await ShootToGenre();
                        break;
                    case "2":
                        await ShootToGame();
                        break;
                    case "3":
                        await ShootToGameOffer();
                        break;
                    case "4":
                        await ShootToGameLeased();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }


                if (!exit)
                {
                    Console.WriteLine("Press any key to return to the menu...");
                    Console.ReadKey();
                }
            }
        }

        private static async Task ShootToGenre()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Genre");
                Console.WriteLine("1. Get all");
                Console.WriteLine("2. Get by id");
                Console.WriteLine("3. Add");
                Console.WriteLine("4. Update");
                Console.WriteLine("5. Delete");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        await GetItemsAsync("genre");
                        break;
                    case "2":
                        await GetItemAsync("genre");
                        break;
                    case "3":
                        await AddGenreAsync();
                        break;
                    case "4":
                        await UpdateGenreAsync();
                        break;
                    case "5":
                        await DeleteItemAsync("genre");
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }


                if (!exit)
                {
                    Console.WriteLine("Press any key to return to the menu...");
                    Console.ReadKey();
                }
            }
        }
        private static async Task ShootToGame()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Game");
                Console.WriteLine("1. Get all");
                Console.WriteLine("2. Get by id");
                Console.WriteLine("3. Add");
                Console.WriteLine("4. Update");
                Console.WriteLine("5. Delete");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        await GetItemsAsync("game");
                        break;
                    case "2":
                        await GetItemAsync("game");
                        break;
                    case "3":
                        await AddGameAsync();
                        break;
                    case "4":
                        await UpdateGameAsync();
                        break;
                    case "5":
                        await DeleteItemAsync("game");
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }


                if (!exit)
                {
                    Console.WriteLine("Press any key to return to the menu...");
                    Console.ReadKey();
                }
            }
        }
        private static async Task ShootToGameOffer()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Game offer");
                Console.WriteLine("1. Get all");
                Console.WriteLine("2. Get by id");
                Console.WriteLine("3. Add");
                Console.WriteLine("4. Update");
                Console.WriteLine("5. Delete");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        await GetItemsAsync("gameoffer");
                        break;
                    case "2":
                        await GetItemAsync("gameoffer");
                        break;
                    case "3":
                        await AddGameOfferAsync();
                        break;
                    case "4":
                        await UpdateGameOfferAsync();
                        break;
                    case "5":
                        await DeleteItemAsync("gameoffer");
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }


                if (!exit)
                {
                    Console.WriteLine("Press any key to return to the menu...");
                    Console.ReadKey();
                }
            }
        }
        private static async Task ShootToGameLeased()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Game leased");
                Console.WriteLine("1. Get all");
                Console.WriteLine("2. Get by id");
                Console.WriteLine("3. Add");
                Console.WriteLine("4. Update");
                Console.WriteLine("5. Delete");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        await GetItemsAsync("gameleased");
                        break;
                    case "2":
                        await GetItemAsync("gameleased");
                        break;
                    case "3":
                        await AddGameLeasedAsync();
                        break;
                    case "4":
                        await UpdateGameLeasedAsync();
                        break;
                    case "5":
                        await DeleteItemAsync("gameleased");
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }


                if (!exit)
                {
                    Console.WriteLine("Press any key to return to the menu...");
                    Console.ReadKey();
                }
            }
        }
        private static async Task GetItemsAsync(string endpoint)
        {
            try
            {
                Console.WriteLine($"Fetching {endpoint}...");
                HttpResponseMessage response = await httpClient.GetAsync($"{BaseUrl}{endpoint}");

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"{endpoint.Capitalize()} Data:");
                    Console.WriteLine(responseData);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        private static async Task GetItemAsync(string endpoint)
        {
            Console.WriteLine($"Write an id");
            string id = Console.ReadLine();

            try
            {
                Console.WriteLine($"Fetching {endpoint}...");
                HttpResponseMessage response = await httpClient.GetAsync($"{BaseUrl}{endpoint}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"{endpoint.Capitalize()} Data:");
                    Console.WriteLine(responseData);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        private static async Task DeleteItemAsync(string endpoint)
        {
            try
            {
                Console.Write("Enter ID to delete: ");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Deleting...");
                HttpResponseMessage response = await httpClient.DeleteAsync($"{BaseUrl}{endpoint}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        private static async Task AddItemAsync(string endpoint, object o)
        {
            try
            {
                string json = JsonSerializer.Serialize(o);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                Console.WriteLine("Adding...");
                HttpResponseMessage response = await httpClient.PostAsync($"{BaseUrl}{endpoint}", content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Added successfully.");
                }
                else
                {
                    string errorDetails = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error: {response.StatusCode} - {errorDetails}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        private static async Task UpdateItemAsync(string endpoint, object o, int id)
        {
            try
            {
                string json = JsonSerializer.Serialize(o);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                Console.WriteLine("Updating...");
                HttpResponseMessage response = await httpClient.PutAsync($"{BaseUrl}{endpoint}/{id}", content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Updated successfully.");
                }
                else
                {
                    string errorDetails = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error: {response.StatusCode} - {errorDetails}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        private static async Task AddGenreAsync()
        {
            Console.Write("Enter Genre Name: ");
            string name = Console.ReadLine();

            var genre = new { Name = name };
            await AddItemAsync("genre", genre);
        }
        private static async Task UpdateGenreAsync()
        {
            Console.Write("Enter Genre ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter New Genre Name: ");
            string name = Console.ReadLine();

            var genre = new { Id = id, Name = name };
            UpdateItemAsync("genre", genre, id);
        }
        private static async Task AddGameAsync()
        {
            Console.Write("Enter Game Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Game Description (optional): ");
            string? description = Console.ReadLine();

            Console.Write("Enter Release Date (yyyy-MM-dd, optional): ");
            string releaseDateInput = Console.ReadLine();
            DateOnly? releaseDate = string.IsNullOrWhiteSpace(releaseDateInput)
                ? null
                : DateOnly.Parse(releaseDateInput);

            Console.Write("Enter Genre IDs (comma-separated): ");
            string genreIdsInput = Console.ReadLine();
            var genres = ParseGenreIds(genreIdsInput);

            var game = new
            {
                Title = title,
                Description = description,
                ReleaseDate = releaseDate,
                Genres = genres
            };
            await AddItemAsync("game", game);
        }
        private static async Task UpdateGameAsync()
        {
            Console.Write("Enter Game ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter New Game Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter New Game Description (optional): ");
            string? description = Console.ReadLine();

            Console.Write("Enter New Release Date (yyyy-MM-dd, optional): ");
            string releaseDateInput = Console.ReadLine();
            DateOnly? releaseDate = string.IsNullOrWhiteSpace(releaseDateInput)
                ? null
                : DateOnly.Parse(releaseDateInput);

            Console.Write("Enter New Genre IDs (comma-separated): ");
            string genreIdsInput = Console.ReadLine();
            var genres = ParseGenreIds(genreIdsInput);

            var game = new
            {
                Id = id,
                Title = title,
                Description = description,
                ReleaseDate = releaseDate,
                Genres = genres
            };
            UpdateItemAsync("game", game, id);
        }
        private static async Task AddGameOfferAsync()
        {
            Console.Write("Enter Game Price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Enter Game Amount: ");
            int amount = int.Parse(Console.ReadLine());

            Console.Write("Enter Game ID: ");
            int gameId = int.Parse(Console.ReadLine());

            Console.Write("Enter Owner ID: ");
            string ownerId = Console.ReadLine();

            var gameOffer = new
            {
                Price = price,
                Amount = amount,
                GameId = gameId,
                OwnerId = ownerId
            };
            await AddItemAsync("gameOffer", gameOffer);
        }
        private static async Task UpdateGameOfferAsync()
        {
            Console.Write("Enter Game Offer ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter New Game Price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Enter New Game Amount: ");
            int amount = int.Parse(Console.ReadLine());

            Console.Write("Enter New Game ID: ");
            int gameId = int.Parse(Console.ReadLine());

            Console.Write("Enter New Owner ID: ");
            string ownerId = Console.ReadLine();

            var gameOffer = new
            {
                Id = id,
                Price = price,
                Amount = amount,
                GameId = gameId,
                OwnerId = ownerId
            };
            UpdateItemAsync("gameOffer", gameOffer, id);
        }
        private static async Task AddGameLeasedAsync()
        {
            Console.Write("Enter Leased Date From (yyyy-MM-dd): ");
            DateOnly dateFrom = DateOnly.Parse(Console.ReadLine());

            Console.Write("Enter Leased Date To (yyyy-MM-dd): ");
            DateOnly dateTo = DateOnly.Parse(Console.ReadLine());

            Console.Write("Enter Game Price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Is the lease active? (true/false): ");
            bool active = bool.Parse(Console.ReadLine());

            Console.Write("Enter Game Offer ID: ");
            int gameOfferId = int.Parse(Console.ReadLine());

            Console.Write("Enter Renter ID: ");
            string renterId = Console.ReadLine();

            var gameLeased = new
            {
                DateFrom = dateFrom,
                DateTo = dateTo,
                Price = price,
                Active = active,
                GameOfferId = gameOfferId,
                RenterId = renterId
            };
            await AddItemAsync("gameOffer", gameLeased);
        }
        private static async Task UpdateGameLeasedAsync()
        {
            Console.Write("Enter Game Leased ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter New Leased Date From (yyyy-MM-dd): ");
            DateOnly dateFrom = DateOnly.Parse(Console.ReadLine());

            Console.Write("Enter New Leased Date To (yyyy-MM-dd): ");
            DateOnly dateTo = DateOnly.Parse(Console.ReadLine());

            Console.Write("Enter New Game Price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Is the lease active? (true/false): ");
            bool active = bool.Parse(Console.ReadLine());

            Console.Write("Enter New Game Offer ID: ");
            int gameOfferId = int.Parse(Console.ReadLine());

            Console.Write("Enter New Renter ID: ");
            string renterId = Console.ReadLine();

            var gameLeased = new
            {
                Id = id,
                DateFrom = dateFrom,
                DateTo = dateTo,
                Price = price,
                Active = active,
                GameOfferId = gameOfferId,
                RenterId = renterId
            };
            UpdateItemAsync("game", gameLeased, id);
        }
        private static List<object> ParseGenreIds(string genreIdsInput)
        {
            var genres = new List<object>();

            if (!string.IsNullOrWhiteSpace(genreIdsInput))
            {
                var ids = genreIdsInput.Split(',', StringSplitOptions.RemoveEmptyEntries);
                foreach (var id in ids)
                {
                    if (int.TryParse(id.Trim(), out int genreId))
                    {
                        genres.Add(new { Id = genreId });
                    }
                    else
                    {
                        Console.WriteLine($"Invalid Genre ID: {id}. Skipping.");
                    }
                }
            }

            return genres;
        }
    }
    public static class StringExtensions
    {
        public static string Capitalize(this string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }
    }


}
