// Implicit Casting
int integerValue = 3;
double doubleValue = integerValue;

// Console.WriteLine(doubleValue.GetType());

// cannot implicitly convert due to
// loss of data
// double pi = 3.14;
// int intPi = pi;

// explicit casting
double doubleValue2 = 3.14159;

// Notice the need to put (int) in front of the value to cast it to integer
int integerValue2 = (int)doubleValue2;

/* Console.WriteLine(integerValue2);
Console.WriteLine(integerValue2.GetType()); */

int reallyLargeInt = 2_100_000_000;
int anotherLargeInt = 2_100_000_000;

var result = (long)reallyLargeInt + anotherLargeInt;
/* Console.WriteLine(result);
Console.WriteLine(result.GetType()); */

// Unboxing Approach
// never use a generic type like object
// just for demo purposes
object boxedData = "This is clearly a string";

// Make sure it is the type you need before proceeding
if (boxedData is int)
{
    // This shouldn't run
    Console.WriteLine("I guess we have an integer value in this box?");
}
if (boxedData is string)
{
    Console.WriteLine("It is totally a string in the box!");
}

// Safe Explicit Casting
// Only possible with nullable types
object actuallyString = "a string";
string? explicitString = actuallyString as string;

// THIS WON'T WORK!!
object ActuallyInt = 256;
// int ExplicitInt = ActuallyInt as int; // error

Console.WriteLine(explicitString);
if (explicitString != null)
{
    Console.WriteLine(explicitString.GetType());
}
