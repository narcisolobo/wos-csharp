namespace InheritanceExercise.Classes;

public class ContemporaryArt
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Link { get; set; }
    public int Year { get; set; }

    public ContemporaryArt(string title, string artist, string link, int year)
    {
        if (year < 1960 || year > DateTime.Now.Year)
        {
            throw new ArgumentOutOfRangeException(
                nameof(year), "year must be between 1960 and this year"
            );
        }
        Title = title;
        Artist = artist;
        Link = link;
        Year = year;
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"\"{Title}\", by {Artist}, {Year} \nLink: {Link}");
    }
}