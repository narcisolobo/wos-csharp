// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string name = "Andy";
Console.WriteLine(name);

Console.WriteLine(name.EndsWith('q'));

int number = 2_100_000_000;
long longNumber = 2;

double pi = 3.14;
double anotherDouble = 4.2;
float bigPi = 3.14F;


Console.WriteLine(number);
Console.WriteLine(longNumber);

Console.WriteLine(pi);
Console.WriteLine(bigPi);

Console.WriteLine(pi + anotherDouble);
// type casting
Console.WriteLine((decimal)anotherDouble + (decimal)bigPi);

// Variable to interpolate
string place = "Coding Dojo";

// Interpolated string, note the $
// This is idiomatic code
Console.WriteLine($"Hello {place}");

// Another option uses placeholders like so
// Note this does NOT have a $ at the start
// This code is not idiomatic
Console.WriteLine("Hello {0}", place);

// string concatenation
Console.WriteLine("Hello " + place);