namespace Banking;

public class Preload
{
    public static void AddDummyAccounts(Bank bank)
    {
        bank.AddAccount("alius", "asdf", 12);
        bank.AddAccount("hasan", "1234", 22);
        bank.AddAccount("jo", "jkl", 57);
    }
}