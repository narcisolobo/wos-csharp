for (int i = 1; i <= 10; i++)
{
    // Console.WriteLine(i);
}

int j = 1;
while (j <= 10)
{
    // Console.WriteLine(j);
    j++;
}

// do while loop
// executes the loop at least once
int k = 11;
do
{
    // Console.WriteLine(k);
    k++;
}
while (k <= 10);

// Random Numbers
// new keyword creates an instance of a class (object)
var rand = new Random();

// very similar syntax
string name = "Andy";

for (int i = 0; i <= 100; i++)
{
    // exclusive upper bound
    // Console.WriteLine(rand.Next(10));
}

for (int i = 0; i < rand.Next(11); i++)
{
    // Console.WriteLine(i);
}


for (int i = 1; i <= 10; i++)
{
    // Every time the loop executes we will get a NEW random value between 2 and 7
    // Console.WriteLine(rand.Next(2, 9)); // dice roll choice
    // Console.WriteLine(rand.NextDouble());
}

/* 
    Combine what you've learned so far! Write a loop that runs 15 times and gets
    a random number between 1 and 10 (10 inclusive) each time.
    
    However, you should
    only print the value if it is equal to 1 OR 7.
    
    Run this code several times and
    see how many times you get results on each run.
    
    Tip: Break this problem into
    multiple parts, first get ALL values to print, then limit it to only printing
    the values you need.
*/

for (int i = 1; i < 16; i++)
{
    var result = rand.Next(1, 11);
    if (result == 1 || result == 7)
    {
        Console.WriteLine(result);
    }
}
