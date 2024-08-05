using LoginReg.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginReg.Context;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public ApplicationContext(DbContextOptions options) : base(options) { }
}
