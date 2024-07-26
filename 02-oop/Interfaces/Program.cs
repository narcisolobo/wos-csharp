using Interfaces.Classes;
using Interfaces.Interfaces;

var lesPaul = new Guitar("Les Paul", "Standard", "Dual Humbucker");
var koaloha = new Ukulele("Koaloha", "Special Anniversary Edition");
var steinway = new Piano("Steinway", "Grand");

var playables = new List<IPlayable>() { lesPaul, koaloha, steinway };

foreach (var playable in playables)
{
    Console.WriteLine(playable.Play());
}

// var test = new StringedInstrument("", ""); this errors out