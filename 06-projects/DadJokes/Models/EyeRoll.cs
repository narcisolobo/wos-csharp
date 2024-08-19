using System.ComponentModel.DataAnnotations;

namespace DadJokes.Models;

public class EyeRoll
{
    [Key]
    public int EyeRollId { get; set; }

    public virtual DadJokeUser? DadJokeUser { get; set; }

    public string? DadJokeId { get; set; }
    public DadJoke? DadJoke { get; set; }
}