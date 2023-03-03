using Eurus_Bank_Models;
using Eurus_Bank_Models.Enum;
using Eurus_Bank_Services.Interfaces;

namespace Eurus_Bank_Services.Implementation;

public class AccountService :IAccountService
{
    
    private readonly IUserService _userService;
    private readonly ITransactionService _transactionService;

    public AccountService(IUserService userService, ITransactionService transactionService)
    {
        _userService = userService;
        _transactionService = transactionService;
    }
    
    public void InsufficientFunds(User user, decimal amount)
    {
        if (user.AccountBalance >= amount) return;
        Console.WriteLine("Insufficient fund.");
    }
    public void Deposit(User user, decimal amount)
    {
        var transaction = new Transaction
        {
            UserId = user.Id,
            Type = TransactionType.Deposit,
            Amount = amount,
            DateTime = DateTime.Now
        };
        
        _transactionService.CreateTransaction(transaction);
        user.AccountBalance += amount;
        _userService.UpdateUser(user);
        
        Console.WriteLine(
            $"{amount:N} was successfully deposited into {user.AccountNumber}. " +
            $"\tYour new account balance is {user.AccountBalance:C}.\n");

    }

    public void Withdrawal(User user, decimal amount)
    {
        InsufficientFunds(user, amount);
        
        var transaction = new Transaction
        {
            UserId = user.Id,
            Type = TransactionType.Withdrawal,
            Amount = amount,
            DateTime = DateTime.Now
        };  
        
        _transactionService.CreateTransaction(transaction);
        user.AccountBalance -= amount;
        _userService.UpdateUser(user);
        
        Console.WriteLine(
            $"{amount:N} was successfully withdrawn from {user.AccountNumber}. " +
            $"\tYour new account balance is {user.AccountBalance:C}.\n");
    }

    public void Transfer(User user, int receiverAccountNumber, decimal amount)
    {
        InsufficientFunds(user, amount);
        
        var receivingUser = _userService.GetUserByAccountNumber(receiverAccountNumber);
        if (receivingUser == null)
        {
            Console.WriteLine("Receiver's account not found.\n");
            return;
        }
        
        user.AccountBalance -= amount;
        receivingUser.AccountBalance += amount;
        _userService.UpdateUser(user);
        _userService.UpdateUser(receivingUser);
        
        var transaction = new Transaction
        {
            UserId = user.Id,
            Type = TransactionType.Transfer,
            Amount = amount,
            DateTime = DateTime.Now
        };
        
        _transactionService.CreateTransaction(transaction);
        
        Console.WriteLine(
            $"{amount:N} was successfully transferred into {receivingUser.AccountNumber}. " +
            $"\tYour new account balance is {user.AccountBalance:C}.\n");
    }

    public void CheckBalance(User user)
    {
        Console.WriteLine($"Your account balance is: {user.AccountBalance}");
    }


}