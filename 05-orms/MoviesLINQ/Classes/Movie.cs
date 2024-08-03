#pragma warning disable CS8618

namespace MoviesLINQ.Classes;

public class Movie
{
    public int MovieId { get; set; }
    public string Title { get; set; }
    public string Director { get; set; }
    public string Genre { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public double? Rating { get; set; }
    public int? DurationInMinutes { get; set; }

    public override string ToString()
    {
        return $@"
MovieID: {MovieId}
Title: {Title} ({ReleaseDate}), {DurationInMinutes} min.
Director: {Director}
Genre: {Genre}
Rating: {Rating}";
    }
}
