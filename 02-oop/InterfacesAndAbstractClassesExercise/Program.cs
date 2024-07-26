using InterfacesAndAbstractClassesExercise.Classes;
using InterfacesAndAbstractClassesExercise.Interfaces;

var iPhone = new Smartphone("Apple", "iPhone 15");
var macBookAir = new Laptop("Apple", "MacBook Air M2");
var s90C = new Television("Samsung", "S90C Smart TV");

var devices = new List<ElectronicDevice>() { iPhone, macBookAir, s90C };

foreach (var device in devices)
{
    Console.WriteLine(device);
    device.TurnOn();
    if (device is Laptop laptop)
    {
        laptop.Sleep();
    }
    if (device is Smartphone smartphone)
    {
        smartphone.ActivateAirplaneMode();
        smartphone.DeactivateAirplaneMode();
    }
    if (device is Television television)
    {
        television.ScanAvailableChannels();
    }
    device.TurnOff();
    Console.WriteLine("\n");
}

var rechargeables = new List<IRechargeable>() { iPhone, macBookAir };

foreach (var rechargeable in rechargeables)
{
    rechargeable.Recharge();
}
