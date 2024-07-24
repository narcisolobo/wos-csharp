# Classes Exercise

**Objectives:**
- Students will follow specifications for creating a class.
- Students will implement default values in parameters for properties that can be assigned on instantiation.
- Students will use basic programmatic logic to implement the functionality of a bank account
- Students will handle edge-cases, such as insufficient funds, with the appropriate control structure
- Students will demonstrate proficiency in updating properties of an object instance from within the class.
- Students will thoroughly test the functionality of their class by creating instances and calling methods with different test data and scenarios.

## Exercise Description
In this exercise we will build a `BankAccount` class. We will then test our code in the `Program.cs` file.

### The `BankAccount` Class
Our `BankAccount` class will define the state and behavior of a typical bank account. This class will have three properties and three methods. We will also override the `ToString()` method.

**Properties of the `BankAccount` Class**
- `Owner`: represents the name of the owner of the account
- `Balance`: represents the balance of the account
- `InterestRate`: represents the interest rate of the account

**Constructor of the `BankAccount` Class**
`Owner`: When a new BankAccount instance is created, the account's `Owner` property should be set to the argument passed in to the constructor.

`InterestRate`: The account should also have an interest rate in decimal format. For example, a 1% interest rate would be saved as 0.01. The interest rate should be provided upon instantiation.

`Balance`: If an amount is given, the balance of the account should initially be set to that amount; otherwise, the balance should start at $0. This is a parameter with a default value.

**Methods of the `BankAccount` Class**
- `Deposit(double amount)`: increases the account balance by the given amount
- `Withdraw(double amount)`: decreases the account balance by the given amount *if there are sufficient funds*. If there is not enough money, print a message `"Insufficient funds: Charging a $5 fee"` and deduct $5
- `YieldInterest()`: increases the account balance by the current balance * the interest rate (as long as the balance is positive)

**Override the `ToString()` Method**
- Override the class' `ToString()` method such that it returns a string showing the object's `Owner` and `Balance`.

## Testing the `BankAccount` Class
In `Program.cs`, test your code with the following steps.

- [ ] Create 2 accounts
- [ ] To the first account, make 3 deposits and 1 withdrawal, then yield interest and display the account's info.
- [ ] To the second account, make 2 deposits and 4 withdrawals, then yield interest and display the account's info.

## Going Further
**Adding an Auto-Generated Account Number**
Add a ten-digit account number to each account object upon instantiation of the object. This account number should start at number 1234567890 and increase by one for every successive account created.

**Reconsider the Property Access Modifiers**
Should all properties have a getter and setter? Should some have only a getter, or only a setter? Should we make either the getter or setter of a property `private`?

A reconsideration of access modifiers may necessitate additional methods.

**The `Transaction` Class**
Add a `Transaction` class that represents a transaction. Possible properties of this class include `Date`, `Amount`, and `Note`.

Adjust your `BankAccount` class such that it contains a new `private` field - a list of transactions. Adjust the getter of the `Balance` property such that it iterates through this list and returns the sum of all amounts.

Adjust the `Deposit`, `Withdraw`, and `YieldInterest` methods such that they instantiate a new `Transaction` object and adds it to the list of transactions.

**`AccountHistory` Method**
Add a method to the class that prints a report to the console. The report should show the details of every transaction.
