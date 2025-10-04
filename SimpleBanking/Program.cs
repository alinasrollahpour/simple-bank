using System;

namespace Banking;

class Program
{
    private static bool exitFlag = false;
    private static string? signedUser = null;
    private static string? signedPassword = null;
    
    static void Main(string[] args)
    {
        var simpleBank = new Bank("Simple");
        Console.WriteLine("\nWelcome to Simple Bank!");
        
        Preload.AddDummyAccounts(simpleBank);

        while (!exitFlag)
        {
            while (signedUser == null)
            {
                var input = CLI.readUserPass();
                if (simpleBank.IsUserPassValid(input.Key, input.Value))
                {
                    signedUser = input.Key;
                    signedPassword = input.Value;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Login successful!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Username or password is incorrect\n");
                    Console.ResetColor();
                }
            }
            //here someone is logged in

            Console.WriteLine("\n Available commands: move, log, exit, logout");
            Console.Write("::> ");
            
            var command =  Console.ReadLine();
            switch (command)
            {
                case "exit":
                {
                    exitFlag = true;
                    break;
                }
                case "move":
                {
                    //key: destination username, value: amount of money
                    var moveData = CLI.readMove(simpleBank, signedUser);
                    try
                    {
                        simpleBank.Transaction(signedPassword, signedUser, moveData.Key, moveData.Value);
                        Console.WriteLine("Transaction successful!");
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Transaction failed: " + e.Message);
                        Console.ResetColor();
                    }
                    break;
                }
                case "log":
                {
                    Console.WriteLine("Here is account summary for: " + signedUser);
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(simpleBank.BankAccounts.Single(p => p.UserName == signedUser).LogAccount());
                        Console.ResetColor();
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("Failed to log account: " + e.Message);
                    }
                    break;
                }
                case "login":
                case "logout":
                {
                    signedUser = null;
                    signedPassword = null;
                    Console.WriteLine("Logged out.\n");
                    break;
                }
            }
        }
        signedUser = null;
        signedPassword = null;

        Console.WriteLine("\n Exiting... (Press ENTER to exit)");
        Console.ReadLine();//wait
    }
}