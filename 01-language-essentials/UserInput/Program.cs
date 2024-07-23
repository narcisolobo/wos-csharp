/* string? inputLine;

do
{
    Console.WriteLine("Type something, then hit enter: ");
    inputLine = Console.ReadLine();
    if (inputLine != null && inputLine.Trim().Length > 0)
    {
        Console.WriteLine($"You wrote: {inputLine.Trim()}");
    }
    else
    {
        Console.WriteLine("Invalid input.");
    }
}
while (inputLine == null || inputLine.Trim().Length == 0); */

// NEVER TRUST THE USER TO SUPPLY GOOD DATA!!

/* Console.WriteLine("Type a number, then hit enter: ");
string NumberInput = Console.ReadLine();
Console.WriteLine(10 + NumberInput); */

Console.WriteLine("Type a number, then hit enter: ");
string NumberInput = Console.ReadLine();

// TryParse takes 2 parameters: the item to be parsed and a variable
// you would like to output (out) to if it is successful

if (int.TryParse(NumberInput, out int parsedValue))
{
    // Notice how we used parsedValue instead of NumberInput
    Console.WriteLine($"The integer was {parsedValue}");
    Console.WriteLine(10 + parsedValue);
}

string aNumber = "7";
int converted = Convert.ToInt32(aNumber);

Console.WriteLine(14 + converted); // should print 21

string aDecimal = "3.14";
double convertDec = Convert.ToDouble(aDecimal);
Console.WriteLine(1.8 + convertDec); // should print 4.94

