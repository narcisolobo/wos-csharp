// List<T> pronouned "List of T"
// Generic Type

// Statically-Typed Language

// Initializing an empty list of Motorcycle Manufacturers that expects string values


var bikes = new List<string>();
// Use the Add function in a similar fashion to push

bikes.Add("Kawasaki");
bikes.Add("Triumph");
bikes.Add("BMW");
bikes.Add("Moto Guzzi");
bikes.Add("Harley Davidson");
bikes.Add("Suzuki");


// Accessing a generic list value is the same as an array
Console.WriteLine(bikes[2]); //Prints "BMW", remember we start at 0!
// To get the size of a List, we use Count instead of Length
Console.WriteLine($"We currently know of {bikes.Count} motorcycle manufacturers.");

bikes.Remove("BMW");
Console.WriteLine(bikes[2]);

Console.WriteLine(bikes.Contains("Hello"));

bikes.Sort();

// Enumerable (IEnumerable Interface)
foreach (var bike in bikes)
{
    Console.WriteLine(bike);
}

string[] bikesArray = new string[]
{
    "Kawasaki",
    "BMW"
};

bikesArray[0] = "Moto Guzzi";

foreach (var bike in bikesArray)
{
    Console.WriteLine(bike);
}

