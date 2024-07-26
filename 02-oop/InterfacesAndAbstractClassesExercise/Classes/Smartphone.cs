using InterfacesAndAbstractClassesExercise.Interfaces;

namespace InterfacesAndAbstractClassesExercise.Classes;

public class Smartphone : ElectronicDevice, IRechargeable
{
    public Smartphone(string brand, string name) : base(brand, name) { }

    public Smartphone ActivateAirplaneMode()
    {
        Console.WriteLine("Airplane mode activated.");
        return this;
    }

    public Smartphone DeactivateAirplaneMode()
    {
        Console.WriteLine("Airplane mode deactivated.");
        return this;
    }

    public override ElectronicDevice TurnOn()
    {
        Console.WriteLine($"The {Brand} {Model} smartphone has powered up.");
        return this;
    }

    public override ElectronicDevice TurnOff()
    {
        Console.WriteLine($"The {Brand} {Model} smartphone has powered down.");
        return this;
    }

    public void Recharge()
    {
        Console.WriteLine($"Recharging the {Brand} {Model} smartphone.");
    }
}
