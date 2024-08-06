using ManyToMany.Models;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany.Context;

public class ApplicationContext : DbContext
{
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Association> Associations { get; set; }
    public ApplicationContext(DbContextOptions options) : base(options) { }
}
