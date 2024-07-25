namespace Inheritance.Classes;

public class Guitar : StringedInstrument
{
    public string PickupType { get; set; }
    public Guitar(string brand, string model, string pickupType) : base(brand, model, "Guitar", 6)
    {
        PickupType = pickupType;
    }

    public string PlayWhammyBar()
    {
        return $"Whoa, that's a sweet whammy bar.";
    }

    public override string Play()
    {
        return $"The {Brand} {Model} {Type} is now playing. Kerrang!!!";
    }
}
