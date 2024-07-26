namespace InheritanceExercise.Classes;

public class Sculpture : ContemporaryArt
{
    public string Material { get; set; }

    public Sculpture(string title, string artist, string link, int year, string material) : base(title, artist, link, year)
    {
        Material = material;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Material: {Material}");
    }
}