using Inheritance.Classes;

var instrument = new StringedInstrument("Fender", "Stratocaster", "Guitar", 6);

var lesPaul = new Guitar("Les Paul", "Standard", "Dual Humbucker");

Console.WriteLine(lesPaul.PickupType);

Console.WriteLine(lesPaul.PlayWhammyBar());

Console.WriteLine(instrument.Play());

Console.WriteLine(instrument);

Console.WriteLine(lesPaul.Play());

Console.WriteLine(lesPaul);

var koaloha = new Ukulele("Koaloha", "Special Anniversary Edition");

Console.WriteLine(koaloha.Play());

Console.WriteLine(koaloha);

var instruments = new List<StringedInstrument>()
{
    lesPaul,
    koaloha
};

foreach (var inst in instruments)
{
    Console.WriteLine(inst.Play());
}
