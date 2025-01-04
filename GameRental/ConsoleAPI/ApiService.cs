using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(string baseAddress)
    {
        _httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
    }

    public async Task<List<T>> GetAllAsync<T>(string endpoint)
    {
        return await _httpClient.GetFromJsonAsync<List<T>>(endpoint);
    }

    public async Task<T> GetByIdAsync<T>(string endpoint, int id)
    {
        return await _httpClient.GetFromJsonAsync<T>($"{endpoint}/{id}");
    }

    public async Task UpdateAsync<T>(string endpoint, int id, T item)
    {
        var response = await _httpClient.PutAsJsonAsync($"{endpoint}/{id}", item);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(string endpoint, int id)
    {
        var response = await _httpClient.DeleteAsync($"{endpoint}/{id}");
        response.EnsureSuccessStatusCode();
    }
}