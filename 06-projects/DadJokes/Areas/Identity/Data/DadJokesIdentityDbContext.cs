using DadJokes.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DadJokes.Areas.Identity.Data;

public class DadJokesContext(DbContextOptions<DadJokesContext> options) : IdentityDbContext<DadJokeUser>(options)
{
    public DbSet<DadJokeUser> DadJokeUsers { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<DadJoke> DadJokes { get; set; }
    public DbSet<EyeRoll> EyeRolls { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
