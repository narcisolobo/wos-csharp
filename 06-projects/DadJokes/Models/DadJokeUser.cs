using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DadJokes.Models;

public class DadJokeUser : IdentityUser
{
    public virtual Profile? Profile { get; set; }
    public List<EyeRoll> EyeRolls { get; set; } = [];
}
