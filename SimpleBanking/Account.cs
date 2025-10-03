using System.Security.Cryptography;
using System.Text;

namespace Banking;

public class Account
{
    private string cardNumber;
    private string userName;
    private long balance = 0;
    private string password;
    
    public string CardNumber { get => cardNumber; }
    public string UserName { get => userName; }
    
    public long GetBalance() {return balance;}

    public void ModifyBalance(long amount)
    {
        //amount could be positive or negative
        if (balance + amount < 0)
        {
            Console.Error.WriteLine("No enough money");
            throw new Exception("No enough money");
        }
        balance += amount;
        
    }
    
    public Account(string userName, string password, string cardNumber, long balance)
    {
        this.password = password;
        this.balance = balance;
        this.userName = userName;
        this.cardNumber = cardNumber;
    }

    public bool IsPasswordCorrect(string passwd)
    {
        return password == passwd;
    }

    public string LogAccount()
    {
        return              "\n userName: " + userName 
                            + "\n cardNumber: " + cardNumber
                            + "\n balance: " + balance;
    }
    
}