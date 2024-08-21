using FileUpload.Models;
using Microsoft.EntityFrameworkCore;

namespace FileUpload.Context;

public class ApplicationContext : DbContext
{
    public DbSet<Ukulele> Ukuleles { get; set; }

    public ApplicationContext(DbContextOptions options) : base(options) { }
}
