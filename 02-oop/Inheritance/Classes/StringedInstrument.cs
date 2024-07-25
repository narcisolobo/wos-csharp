namespace Inheritance.Classes;

public class StringedInstrument
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Type { get; set; }
    public int NumberOfStrings { get; set; }

    public StringedInstrument(string brand, string model, string type, int numberOfStrings)
    {
        Brand = brand;
        Model = model;
        Type = type;
        NumberOfStrings = numberOfStrings;
    }

    public virtual string Play()
    {
        return $"The {Brand} {Model} {Type} is now playing.";
    }

    public override string ToString()
    {
        return $"Brand: {Brand}, Model: {Model}, Type: {Type}, NumberOfStrings: {NumberOfStrings}";
    }
}
