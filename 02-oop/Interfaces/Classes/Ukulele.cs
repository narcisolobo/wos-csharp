namespace Interfaces.Classes;

public class Ukulele : StringedInstrument
{
    public Ukulele(string brand, string model) : base(brand, model, "Ukulele", 4)
    {

    }
    public override string Play()
    {
        return $"The {Brand} {Model} {Type} is now playing. Plunkity plunk!";
    }
}
