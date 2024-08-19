using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace DadJokes.Models;

public class DadJoke
{
    [Key]
    [JsonProperty("id")]
    public string? DadJokeId { get; set; }

    [JsonProperty("joke")]
    public string? Joke { get; set; }

    [NotMapped]
    [JsonProperty("status")]
    public int Status { get; set; }

    public List<EyeRoll> EyeRolls { get; set; } = [];

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
