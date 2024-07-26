using Interfaces.Interfaces;

namespace Interfaces.Classes;

public class Piano : IPlayable
{
    public string Brand { get; set; }
    public string Model { get; set; }

    public Piano(string brand, string model)
    {
        Brand = brand;
        Model = model;
    }

    public string Play()
    {
        return $"The {Brand} {Model} is playing.";
    }
}
