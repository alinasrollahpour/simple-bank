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
                }
            }
            //here someone is logged in
            
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
                    
                }
            }
        }
    }

    
}