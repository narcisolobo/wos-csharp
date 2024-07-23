static void StartGame(Dictionary<string, string> choices)
{
    Console.WriteLine("Welcome to Rock, Paper, Scissors!");
    string username = GetUsername();
    Console.WriteLine($"Greetings, {username}.");

    bool playAgain;

    do
    {
        string computerChoice = GetComputerChoice(choices);
        string userChoice = GetUserChoice(choices);

        string result = DetermineWinner(userChoice, computerChoice);
        Console.WriteLine(result);
        playAgain = AskToPlayAgain();

    } while (playAgain);
}

static string GetUsername()
{
    Console.Write("What should I call you? ");
    string? username;

    do
    {
        username = Console.ReadLine();
        if (username != null)
        {
            username = username.Trim();
        }

        if (username == null || username.Length < 3)
        {
            Console.WriteLine("Usernames must be at least three characters.");
            Console.Write("What should I call you? ");
        }
    }
    while (username == null || username.Length < 3);

    return username;
}

static string GetComputerChoice(Dictionary<string, string> choices)
{
    var choiceValues = choices.Values.ToList();

    var rand = new Random();
    int randomIndex = rand.Next(choiceValues.Count);
    return choiceValues[randomIndex];
}

static string GetUserChoice(Dictionary<string, string> choices)
{
    Console.WriteLine("Ready?");
    Console.WriteLine("Press Enter key to start.");
    Console.ReadLine();

    for (var i = 3; i > 0; i--)
    {
        Console.WriteLine(i);
        Thread.Sleep(1000);
    }

    Console.WriteLine("Go!");
    string? userChoice;

    do
    {
        Console.Write("Enter your choice (r for Rock, p for Paper, s for Scissors): ");

        userChoice = Console.ReadLine();
        if (userChoice != null)
        {
            userChoice = userChoice.Trim().ToLower();
        }
        if (userChoice == null || !choices.Keys.ToList().Contains(userChoice))
        {
            Console.WriteLine("Invalid choice.");
        }
    }
    while (userChoice == null || !choices.Keys.ToList().Contains(userChoice));

    return choices[userChoice];
}

static string DetermineWinner(string userChoice, string computerChoice)
{
    if (userChoice == computerChoice)
    {
        return "It's a tie!";
    }
    else if ((userChoice == "Rock" && computerChoice == "Scissors") ||
             (userChoice == "Paper" && computerChoice == "Rock") ||
             (userChoice == "Scissors" && computerChoice == "Paper"))
    {
        return "You win!";
    }
    else
    {
        return "Computer wins!";
    }
}

static bool AskToPlayAgain()
{
    Console.Write("Do you want to play again? (y/n): ");
    string? response = Console.ReadLine();
    return response != null && response.Trim().Equals("y", StringComparison.CurrentCultureIgnoreCase);
}

var choices = new Dictionary<string, string>
{
    {"r", "Rock"},
    {"p", "Paper"},
    {"s", "Scissors"},
};

StartGame(choices);