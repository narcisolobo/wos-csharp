namespace InheritanceExercise.Classes;

public class DigitalArt : ContemporaryArt
{
    public string SoftwareUsed { get; set; }

    public DigitalArt(string title, string artist, string link, int year, string softwareUsed) : base(title, artist, link, year)
    {
        SoftwareUsed = softwareUsed;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"SoftwareUsed: {SoftwareUsed}");
    }
}