# CRUD Step-by-Step
Now that we have a database, our application setup has reached its final form.

Below are the steps I go through when creating a new CRUD application. Feel free to adjust this however you like.

## 1. Create new MVC project
Create a new mvc project with the following command (replace `<AppName>` with the name of your app):
```bash
dotnet new mvc --no-https -o <AppName>
```
## 2. Install the Entity Framework Core design-time tools and the EF Core provider for MySQL.
```bash
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Pomelo.EntityFrameworkCore.MySql
```
## 3. Create your models
Create all necessary models in the `Models` directory.
- Don't forget the `Id`, `CreatedAt`, and `UpdatedAt` properties. 
- All other fields should have validation attributes.
- If you don't like the yellow warning squiggly lines, add `pragma warning disable CS9618` to the top of your file.

**Example:**
```cs
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace MovieCRUD.Models;

public class Movie
{
    [Key]
    public int MovieId { get; set; }

    [Required(ErrorMessage = "Please enter title.")]
    [MinLength(2, ErrorMessage = "Title must be at least two characters.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Please enter duration in minutes.")]
    [Range(1, 1000, ErrorMessage = "Duration must be between 1 and 1000 minutes.")]
    public int DurationInMInutes { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
```

## 4. Create your database context
I like to create a new namespace and directory for the context, but it's also fine to have this file in your `Models` directory. This example shows the more modularized approach.

**Example:**
```cs
using Microsoft.EntityFrameworkCore;
using MovieCRUD.Models;

namespace MovieCRUD.Context;

public class MovieContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }

    public MovieContext(DbContextOptions options) : base(options) { }
}
```

## 5. Add your database connection string
Go to your `appsettings.json` file and add your database connection string. Be sure to change your password if it's different and don't forget to change the database name.
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection":
    "Server=localhost;port=3306;userid=root;password=root;database=movies_db;"
  }
}
```

## 6. Edit your `Program.cs` file
Configure your project to use your connection string to connect to MySQL, add session.

**Example:**
```cs
using Microsoft.EntityFrameworkCore;
using MovieCRUD.Context;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddDbContext<MovieContext>((options) =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
```

## 7. Create your first migration and update your database
Create your first migration:
```bash
dotnet ef migrations add FirstMigration
```
Update your database:
```bash
dotnet ef database update
```

## 8. Edit your `.sln` file
If your `.sln` filename contains `.generated`, rename it to match the `.csproj` filename.

![sln file](./assets/sln.png)

## 9. Inject your database context into your controllers

Every controller that needs access to the database should have the `DbContext` injected into its controller.

**Example:**
```cs
using Microsoft.AspNetCore.Mvc;
using MovieCRUD.Context;
using MovieCRUD.Models;

namespace MovieCRUD.Controllers;

public class MovieController : Controller
{
    private readonly MovieContext _context;

    public MovieController(MovieContext context)
    {
        _context = context;
    }

    // action methods go here
}
```