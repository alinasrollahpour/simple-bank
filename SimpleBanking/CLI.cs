namespace Banking;

public class CLI
{
    public static KeyValuePair<string, string> readUserPass()
    {
        Console.Write("Please login:\nusername: ");
        var signedUser = Console.ReadLine();
        Console.Write("password: ");
        var signedPassword = Console.ReadLine();
        return new KeyValuePair<string, string>(signedUser, signedPassword);
    }

    public static KeyValuePair<string, long> readMove(Bank bank)
    {
        string destination;
        while (true)
        {
            Console.Write("Enter username of destination account: ");
            destination = Console.ReadLine();
            if (!bank.DoesUsernameExist(destination))
            {
                continue;
            }
            break;
        }

        while (true)
        {
            
        }
        
    } 
    static void ProcessCommand()
    {
        if (signedUser == null)
        {
            
        }
        else
        {
            Console.WriteLine("You can do transaction(move) , account status(log)");
            string? input =  Console.ReadLine();
            while (input != "move" && input != "log")
            {
                Console.WriteLine("Sorry, entered command is invalid. available commands: [move, log]");
                input = Console.ReadLine();
            }
            //now we have a valid command
            
        }
    }
}