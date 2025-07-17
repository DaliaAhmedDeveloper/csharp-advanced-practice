// Namespace: practice.objects
// Purpose: Demonstrates class and object creation in C# with a simple BankAccount example
// This example includes fields, properties, methods, constructors, and user interaction.

namespace practice.objects;

class BankAccount  // Create a class for bank account 
{
    private string accountNumber; // feild private : means accessable only inside same class
    private decimal balance;

    public decimal Balance // property -- u can here add your logic when getting or setting a value 
    {
        get
        {
            return balance;
        }
    }
    public string AccountNumber // public means : accessable inside same class and children and objects from 
    {
        get
        {
            return accountNumber;
        }
    }
    public BankAccount(string accountNumber) //A constructor is a special method in a class that automatically executes when an object of that class is created.
    {
        this.accountNumber = accountNumber;
    }

    public void Deposit(decimal amount) // method for deposit ,, returns void
    {
        if (amount > 0)
        {
            balance += amount;
        }
        else
        {
            Console.WriteLine("invalid amount");
        }
    }
    public void Withdraw(decimal amount) // method for withdraw ,, returns void
    {
        if (amount > 0 && balance >= amount)
        {
            balance -= amount;
        }
        else
        {
            Console.WriteLine("invalid or not enough amount");
        }
    }
    public void DisplayAccountInfo(string operation, decimal amount) // mehod for display information ,, returns void
    {
        Console.WriteLine($"Account Number Is : {AccountNumber}");
        Console.WriteLine($"Operation Is : {operation}");
        Console.WriteLine($"Amount Is : {amount}");
        Console.WriteLine($"Your Balance  Is : {balance}");

    }
}
class Program
{
    static void Main() // the entry point of the program
    {
        Console.WriteLine("Please Enter Your Account Number Contains (15 digits)");
        string? account_number; // null-conditional operator -- use it when the variable may contain null
        BankAccount userAccount;
        while (true) // using while loop because iterations depend on user inputs, not fixed count
        {
            account_number = Console.ReadLine(); // always return string
            if (account_number?.Length == 15)
            {
                userAccount = new BankAccount(account_number); // create an object from BankAccount class
                break;
            }
            else
            {
                Console.WriteLine("Please Enter a Valid Account Number Contains (15 digits)");
            }
        }

        while (true)
        {
            Console.WriteLine("for deposite enter 1 , for withdraw enter 2");
            string? option;
            while (true)
            {
                option = Console.ReadLine();
                if (option == "1" || option == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please Enter Correct Selection");
                }
            }

            Console.WriteLine("Please Enter Amount");
            string? amount;
            while (true) // infinite loop till break excutes ,, its for repeated inputs till the user enter exist for example
            {
                amount = Console.ReadLine();
                if (decimal.TryParse(amount, out decimal result))
                // tryparse : if input is "yy" it will return false  -- if u are using parse only it will throw an exception
                // if input is "5" it will convert it to decimal and return it 
                {
                    if (option == "1")
                    {
                        userAccount.Deposit(result); // accress public method inside the class using the object instance
                        userAccount.DisplayAccountInfo("Deposit", result);
                    }
                    if (option == "2")
                    {
                        userAccount.Withdraw(result);
                        userAccount.DisplayAccountInfo("withdraw", result);
                    }
                    break; // finish the loop 
                }
                else
                {
                    Console.WriteLine("Please Enter Valid Amount");
                }
            }
        }
    }
}
