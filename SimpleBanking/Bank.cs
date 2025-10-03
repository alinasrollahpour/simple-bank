using System;
using System.Collections.Generic;
using System.Linq;

namespace Banking;

public class Bank
{
    private string bankName;
    private string lastGeneratedCardNumber = "000000";
    
    List<Account> bankAccounts = new List<Account>();
    
    public Bank(string bankName)
    {
        this.bankName = bankName;
    }

    public void AddAccount(string userName, string password, long balance)
    {
        var newCardNumber = GenerateCardNumber();
        //update it
        lastGeneratedCardNumber = newCardNumber;
        
        var newAccount = new Account(
            userName, password,  newCardNumber, balance);
        bankAccounts.Add(newAccount);
    }

    public void Transaction(string password, string from, string to, long amount)
    {
        if (amount <= 0) throw new ArgumentException("Amount must be greater than zero");
        
        //throws exception
        //first find that account in the List
        var fromAccount = bankAccounts.First(p => p.CardNumber == from);
        var toAccount = bankAccounts.First(p => p.CardNumber == to);
        //check password
        if (!fromAccount.IsPasswordCorrect(password))
        {
            throw new ArgumentException("The password is incorrect");
        }
        //transfer the money
        fromAccount.ModifyBalance(-amount);
        toAccount.ModifyBalance(amount);
        Console.WriteLine("Transaction successful!");
    }

    public bool DoesUsernameExist(string userName)
    {
        return bankAccounts.Any(p => p.UserName == userName);
    }
    
    public bool IsUserPassValid(string userName, string password)
    {
        return bankAccounts.Any(p => ( p.CardNumber == userName && p.IsPasswordCorrect(password) ));
    }
    
    private string GenerateCardNumber()
    {
        long last = Convert.ToInt64(lastGeneratedCardNumber);
        long next = last + 17;
        return Convert.ToString(next);
    }
}