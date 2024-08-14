using Newtonsoft.Json;

namespace DadJokes.Models;

public class DadJoke
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("joke")]
    public string? Joke { get; set; }

    [JsonProperty("status")]
    public int Status { get; set; }

    public static DadJoke FromJson(string json)
    {
        var dadJoke = JsonConvert.DeserializeObject<DadJoke>(json);
        if (dadJoke is not null)
        {
            return dadJoke;
        }
        throw new InvalidOperationException("Failed to deserialize json");
    }
}
