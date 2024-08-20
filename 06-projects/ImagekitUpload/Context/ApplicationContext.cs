using Microsoft.EntityFrameworkCore;
using ImagekitUpload.Models;

namespace ImagekitUpload.Context;

public class ApplicationContext : DbContext
{
    public DbSet<Pet> Pets { get; set; }

    public ApplicationContext(DbContextOptions options) : base(options) { }
}
