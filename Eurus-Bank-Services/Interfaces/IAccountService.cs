using Eurus_Bank_Models;

namespace Eurus_Bank_Services.Interfaces;

public interface IAccountService
{
    void Deposit(User user, decimal amount);
    
    void Withdrawal(User user, decimal amount);
    
    void Transfer(User user, int receiverAccountNumber, decimal amount);
    
    void CheckBalance(User user);
}