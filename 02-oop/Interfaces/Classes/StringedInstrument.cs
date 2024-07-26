using Interfaces.Interfaces;

namespace Interfaces.Classes;

public abstract class StringedInstrument : IPlayable
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

    public override string ToString()
    {
        return $"Brand: {Brand}, Model: {Model}, Type: {Type}, NumberOfStrings: {NumberOfStrings}";
    }

    public abstract string Play();
}
