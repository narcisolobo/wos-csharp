using Microsoft.EntityFrameworkCore;
using OneToMany.Models;

namespace OneToMany.Context;

public class ApplicationContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }

    public ApplicationContext(DbContextOptions options) : base(options) { }
}
