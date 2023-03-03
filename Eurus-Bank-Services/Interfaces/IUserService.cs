using Eurus_Bank_Models;

namespace Eurus_Bank_Services.Interfaces;

public interface IUserService
{
    User CreateUser(User user);
    
    User GetUserById(int id);
    
    User GetUserByEmail(string email);
    
    User GetUserByAccountNumber(int accountNumber);
    
    void UpdateUser(User user);
}