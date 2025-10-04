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

    public static KeyValuePair<string, long> readMove(Bank bank, string signedUser)
    {
        string destination;
        long amount;
        while (true)
        {
            Console.Write("Enter username of destination account: ");
            destination = Console.ReadLine();
            if (!bank.DoesUsernameExist(destination))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This username does not exist.");
                Console.ResetColor();
                continue;
            }

            if (destination == signedUser)
            {
                Console.WriteLine("This is yourself`s username.");
                continue;
            }
            break;
        }

        while (true)
        {
            Console.Write("How much money to move? ");
            try
            {
                amount = long.Parse(Console.ReadLine());
                if (amount <= 0)
                {
                    Console.WriteLine("Amount must be positive!");
                    continue;
                }
                break;
            }
            catch (Exception e)
            {
                Console.Write("Please enter a valid positive number: ");
            }
        }
        
        return new KeyValuePair<string, long>(destination, amount);
    } 
}