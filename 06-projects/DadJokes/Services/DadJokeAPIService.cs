using System.Net.Http.Headers;
using DadJokes.Models;

namespace DadJokes.Services;

public interface IDadJokeAPIService
{
    Task<DadJoke> GetDadJokeAsync(string endpoint);
}

public class DadJokeAPIService : IDadJokeAPIService
{
    private readonly HttpClient _client;
    public DadJokeAPIService(HttpClient client)
    {
        _client = client;
    }

    async public Task<DadJoke> GetDadJokeAsync(string endpoint)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return DadJoke.FromJson(json);
    }
}
