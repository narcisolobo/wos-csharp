using Microsoft.EntityFrameworkCore;
using MoviesCRUD.Models;

namespace MoviesCRUD.Context;

public class ApplicationContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }

    public ApplicationContext(DbContextOptions options) : base(options) { }
}
