namespace Banking;

public class Preload
{
    public static void AddDummyAccounts(Bank bank)
    {
        bank.AddAccount("al", "asdf", 12);
        bank.AddAccount("ta", "1234", 22);
        bank.AddAccount("jo", "jkl", 57);
    }
}