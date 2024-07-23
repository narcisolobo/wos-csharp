// Methods/Functions require a return type
static void SayHello() // Method names are PascalCase
{
    Console.WriteLine("Hello how are you doing today?");
}

SayHello();

static void SayHelloWithName(string firstName) // parameters are camelCase
{
    Console.WriteLine($"Hello, {firstName}, how are you doing today?");
}

SayHelloWithName("Kermit");

static int GiveMeAnInt(int number)
{
    return number;
}

var pi = 3.14;

// Console.WriteLine(GiveMeAnInt(pi)); // compiler error

// Notice how new parameters are separated by commas and their types are defined
static void SayHelloWithTwoParams(string firstName, string lastName)
{
    Console.WriteLine($"Hello, {firstName} {lastName}, how are you doing today?");
}

// call function without named parameters
// must be in same order as defined in declaration
SayHelloWithTwoParams("Luke", "Skywalker");

// call function with named parameters
// order now does not matter
SayHelloWithTwoParams(lastName: "Skywalker", firstName: "Luke");

static void SayHelloWithDefault(string firstName = "buddy")
{
    Console.WriteLine($"Hey, {firstName}!");
}
// We can call it without providing any arguments and the default value will be used...
SayHelloWithDefault();
// ...or we can call it with an argument and that argument's value will be used
SayHelloWithDefault("Yoda");

// with return
static string SayHelloWithReturn(string firstName = "buddy")
{
    return $"Hey {firstName}!";
}

string greeting;
greeting = SayHelloWithReturn();
Console.WriteLine(greeting);
