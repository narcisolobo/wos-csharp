using InterfacesAndAbstractClassesExercise.Interfaces;

namespace InterfacesAndAbstractClassesExercise.Classes;

public class Laptop : ElectronicDevice, IRechargeable
{
    public Laptop(string brand, string model) : base(brand, model) { }

    public Laptop Sleep()
    {
        Console.WriteLine("Going into hibernation...");
        return this;
    }

    public override ElectronicDevice TurnOn()
    {
        Console.WriteLine($"The {Brand} {Model} laptop has powered up.");
        return this;
    }

    public override ElectronicDevice TurnOff()
    {
        Console.WriteLine($"The {Brand} {Model} laptop has powered down.");
        return this;
    }

    public void Recharge()
    {
        Console.WriteLine($"Recharging the {Brand} {Model} laptop.");
    }
}