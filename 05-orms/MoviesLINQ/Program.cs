using MoviesLINQ.Classes;

List<Movie> movies =
[
    new Movie { MovieId = 1, Title = "Inception", Director = "Christopher Nolan", Genre = "Sci-Fi", ReleaseDate = new DateTime(2010, 7, 16), Rating = 8.8, DurationInMinutes = 148 },
    new Movie { MovieId = 2, Title = "The Godfather", Director = "Francis Ford Coppola", Genre = "Crime", ReleaseDate = new DateTime(1972, 3, 24), Rating = 9.2, DurationInMinutes = 175 },
    new Movie { MovieId = 3, Title = "The Dark Knight", Director = "Christopher Nolan", Genre = "Action", ReleaseDate = new DateTime(2008, 7, 18), Rating = 9.0, DurationInMinutes = 152 },
    new Movie { MovieId = 4, Title = "Pulp Fiction", Director = "Quentin Tarantino", Genre = "Crime", ReleaseDate = new DateTime(1994, 10, 14), Rating = 8.9, DurationInMinutes = 154 },
    new Movie { MovieId = 5, Title = "Schindler's List", Director = "Steven Spielberg", Genre = "Biography", ReleaseDate = new DateTime(1993, 12, 15), Rating = 8.9, DurationInMinutes = 195 },
    new Movie { MovieId = 6, Title = "The Shawshank Redemption", Director = "Frank Darabont", Genre = "Drama", ReleaseDate = new DateTime(1994, 9, 23), Rating = 9.3, DurationInMinutes = 142 },
    new Movie { MovieId = 7, Title = "Forrest Gump", Director = "Robert Zemeckis", Genre = "Drama", ReleaseDate = new DateTime(1994, 7, 6), Rating = 8.8, DurationInMinutes = 142 },
    new Movie { MovieId = 8, Title = "Fight Club", Director = "David Fincher", Genre = "Drama", ReleaseDate = new DateTime(1999, 10, 15), Rating = 8.8, DurationInMinutes = 139 },
    new Movie { MovieId = 9, Title = "The Matrix", Director = "Lana Wachowski, Lilly Wachowski", Genre = "Sci-Fi", ReleaseDate = new DateTime(1999, 3, 31), Rating = 8.7, DurationInMinutes = 136 },
    new Movie { MovieId = 10, Title = "The Lord of the Rings: The Fellowship of the Ring", Director = "Peter Jackson", Genre = "Fantasy", ReleaseDate = new DateTime(2001, 12, 19), Rating = 8.8, DurationInMinutes = 178 },
    new Movie { MovieId = 11, Title = "The Room", Director = "Tommy Wiseau", Genre = "Drama", ReleaseDate = new DateTime(2003, 6, 27), Rating = 3.7, DurationInMinutes = 99 },
    new Movie { MovieId = 12, Title = "Battlefield Earth", Director = "Roger Christian", Genre = "Sci-Fi", ReleaseDate = new DateTime(2000, 5, 12), Rating = 2.5, DurationInMinutes = 118 },
    new Movie { MovieId = 13, Title = "Cats", Director = "Tom Hooper", Genre = "Musical", ReleaseDate = new DateTime(2019, 12, 20), Rating = 2.8, DurationInMinutes = 110 },
    new Movie { MovieId = 14, Title = "Gigli", Director = "Martin Brest", Genre = "Romance", ReleaseDate = new DateTime(2003, 8, 1), Rating = 2.6, DurationInMinutes = 121 },
    new Movie { MovieId = 15, Title = "Batman & Robin", Director = "Joel Schumacher", Genre = "Action", ReleaseDate = new DateTime(1997, 6, 20), Rating = 3.8, DurationInMinutes = 125 },
    new Movie { MovieId = 16, Title = "The Love Guru", Director = "Marco Schnabel", Genre = "Comedy", ReleaseDate = new DateTime(2008, 6, 20), Rating = 3.8, DurationInMinutes = 87 },
    new Movie { MovieId = 17, Title = "Movie 43", Director = "Various", Genre = "Comedy", ReleaseDate = new DateTime(2013, 1, 25), Rating = 4.3, DurationInMinutes = 94 },
    new Movie { MovieId = 18, Title = "Dragonball Evolution", Director = "James Wong", Genre = "Action", ReleaseDate = new DateTime(2009, 4, 10), Rating = 2.5, DurationInMinutes = 85 },
    new Movie { MovieId = 19, Title = "Fifty Shades of Grey", Director = "Sam Taylor-Johnson", Genre = "Romance", ReleaseDate = new DateTime(2015, 2, 13), Rating = 4.1, DurationInMinutes = 125 },
    new Movie { MovieId = 20, Title = "Pixels", Director = "Chris Columbus", Genre = "Comedy", ReleaseDate = new DateTime(2015, 7, 24), Rating = 5.6, DurationInMinutes = 106 }
];

// PrintEach(movies, "Here are the movies");
// lambda function/expression syntax
// param => body

var comedyCount = movies.Count((m) => m.Genre == "Comedy");
var comedies = movies
    .Where((movie) => movie.Genre == "Comedy")
    .ToList();

Console.WriteLine($"Comedy Count: {comedyCount}");
PrintEach(comedies, "Comedy Movies");

// Find all the movies rated higher than 9
var goodMovies = movies
    .Where((m) => m.Rating > 9)
    .ToList();

PrintEach(goodMovies, "Movies rated higher than 9");

var badMovies = movies
    .Where((m) => m.Rating < 4)
    .ToList();

PrintEach(badMovies, "Movies rated less than 4");

// Movies ordered by release date in descending order
var sortedByReleaseDate = movies
    .OrderByDescending((m) => m.ReleaseDate)
    .ToList();

PrintEach(sortedByReleaseDate, "Movies by release date descending");

// List of titles of each movie
var titles = movies
    .Select((m) => m.Title)
    .ToList();

PrintEach(titles, "Only titles");

// movies grouped by genre
var groupedByGenre = movies
    .GroupBy((m) => m.Genre)
    .ToList();

foreach (var grouping in groupedByGenre)
{
    PrintEach(grouping);
}

// order by genre, then by rating within each genre
var sortedByGenreAndRating = movies
    .OrderBy((m) => m.Genre)
    .ThenByDescending((m) => m.Rating)
    .ToList();

PrintEach(sortedByGenreAndRating, "Sorted by genre, then rating");

var runForrest = movies
    .FirstOrDefault((m) => m.MovieId == 7);

Console.WriteLine($"Forrest? {runForrest}");

var shortestDuration = movies
    .Min((m) => m.DurationInMinutes);

Console.WriteLine($"Shortest duration: {shortestDuration}");

var shortestMovie = movies
    .Where((m) => m.DurationInMinutes == shortestDuration)
    .FirstOrDefault();

Console.WriteLine("Shortest Movie:");
Console.WriteLine(shortestMovie);

var averageDuration = movies
    .Average((m) => m.DurationInMinutes);

Console.WriteLine($"Average duration: {averageDuration}");

static void PrintEach(IEnumerable<dynamic> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (var item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
