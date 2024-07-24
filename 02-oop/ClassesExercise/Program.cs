using ClassesExercise.Classes;

var bankAccount = new BankAccount("Kermit the Frog", .1);

Console.WriteLine(bankAccount);

// deposit into the account
bankAccount.Deposit(100);

// calling the ToString() method
Console.WriteLine(bankAccount);

// testing with a negative deposit amount
try
{
    bankAccount.Deposit(-100);
}
catch (ArgumentOutOfRangeException error)
{
    Console.WriteLine(error.Message);
}

Console.WriteLine(bankAccount);

// withdraw from the account
bankAccount.Withdraw(50);

Console.WriteLine(bankAccount);

// testing with insufficient funds
try
{
    bankAccount.Withdraw(200);
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine(e.ToString());
}

Console.WriteLine(bankAccount);

// yield interest
bankAccount.YieldInterest();

Console.WriteLine(bankAccount);

bankAccount.Withdraw(49.5);

Console.WriteLine(bankAccount);

// testing with a zero balance
bankAccount.YieldInterest();

Console.WriteLine(bankAccount);

// bankAccount.Balance = 1000000000;