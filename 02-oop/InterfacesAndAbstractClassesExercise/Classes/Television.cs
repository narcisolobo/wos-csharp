namespace InterfacesAndAbstractClassesExercise.Classes;

public class Television : ElectronicDevice
{
    public Television(string brand, string model) : base(brand, model) { }

    public Television ScanAvailableChannels()
    {
        Console.WriteLine("Scanning for available channels...");
        return this;
    }

    public override ElectronicDevice TurnOn()
    {
        Console.WriteLine($"The {Brand} {Model} television has powered up.");
        return this;
    }

    public override ElectronicDevice TurnOff()
    {
        Console.WriteLine($"The {Brand} {Model} television has powered down.");
        return this;
    }
}