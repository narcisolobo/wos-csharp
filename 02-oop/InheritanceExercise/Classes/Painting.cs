namespace InheritanceExercise.Classes;

public class Painting : ContemporaryArt
{
    public string Medium { get; set; }

    public Painting(string title, string artist, string link, int year, string medium) : base(title, artist, link, year)
    {
        Medium = medium;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Medium: {Medium}");
    }
}
