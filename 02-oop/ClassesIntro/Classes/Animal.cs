namespace ClassesIntro.Classes;

// singular and PascalCase
public class Animal
{
    // field
    /* private string _name;

    // property
    public string Name
    {
        get
        {
            return _name;
        }

        set
        {
            _name = value;
        }
    } */

    // auto-implemented property
    public string Name { get; set; }
    public string Type { get; set; }
    public int Age { get; set; }

    // constructor
    public Animal(string name, string type, int age)
    {
        Name = name;
        Type = type;
        Age = age;
    }

    // overloaded constructor
    public Animal(string name, string type)
    {
        Name = name;
        Type = type;
        Age = 0;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Type: {Type}, Age: {Age}";
    }

    // method
    public void Birthday()
    {
        Age++;
    }
}
