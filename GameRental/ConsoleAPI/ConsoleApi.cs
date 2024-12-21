using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace ConsoleApi
{
    class Program
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private const string BaseUrl = "https://localhost:7018/api/games";

        static async Task Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("API Shooter");
                Console.WriteLine("1. Get Games");
                Console.WriteLine("2. Add Game");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        await GetGamesAsync();
                        break;
                    case "2":
                        await AddGameAsync();
                        break;
                    case "3":
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

        private static async Task GetGamesAsync()
        {
            try
            {
                Console.WriteLine("Fetching games...");
                HttpResponseMessage response = await httpClient.GetAsync(BaseUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Games:");
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

        private static async Task AddGameAsync()
        {
            try
            {
                Console.Write("Enter game name: ");
                string name = Console.ReadLine();

                Console.Write("Enter game description: ");
                string description = Console.ReadLine();

                var game = new { Name = name, Description = description };
                string json = JsonSerializer.Serialize(game);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                Console.WriteLine("Adding game...");
                HttpResponseMessage response = await httpClient.PostAsync(BaseUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Game added successfully.");
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
    }
}
