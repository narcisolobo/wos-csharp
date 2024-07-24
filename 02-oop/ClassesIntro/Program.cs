using ClassesIntro.Classes;

var ani = new Animal("Huey", "Duck");

Console.WriteLine(ani);
ani.Birthday();
Console.WriteLine(ani);

var jinja = new Animal("Jinja", "Sheepadoodle", 1);
Console.WriteLine(jinja);

// Console.WriteLine($"{ani.Name} {ani.Type} Age: {ani.Age}");

var animalList = new List<Animal>() { ani, jinja };

foreach (var animal in animalList)
{
    Console.WriteLine(animal);
}