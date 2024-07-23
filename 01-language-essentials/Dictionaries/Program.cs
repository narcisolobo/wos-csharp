var profile = new Dictionary<string, string>
{
    { "Name", "Sandra" },
    { "Language", "C#" },
    { "Location", "England" }
};

// Now we can render the data like so
Console.WriteLine("Student profile");

// Notice how we use ["KeyName"] to pull the value out
Console.WriteLine($"Name - {profile["Name"]}"); // string interpolation
Console.WriteLine("From - " + profile["Location"]);
Console.WriteLine("Favorite Language - " + profile["Language"]);

foreach (var entry in profile)
{
    Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
}
