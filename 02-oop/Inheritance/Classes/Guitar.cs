namespace Inheritance.Classes;

public class Guitar : StringedInstrument
{
    public Guitar(string brand, string model) : base(brand, model, "Guitar", 6)
    {

    }

    public override string Play()
    {
        return $"The {Brand} {Model} {Type} is now playing. Kerrang!!!";
    }
}
