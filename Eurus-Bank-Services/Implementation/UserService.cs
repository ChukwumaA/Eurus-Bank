using Eurus_Bank_DAL.DbConfig;
using Eurus_Bank_Models;
using Eurus_Bank_Services.Interfaces;

namespace Eurus_Bank_Services.Implementation;

public class UserService : IUserService
{
    private readonly EurusDbContext _context;
    
    public UserService(EurusDbContext context)
    {
        _context = context;
    }
    
    public User CreateUser(User user)
    {
        //create user in database
        _context.Users.Add(user);
        //save changes to database
        _context.SaveChanges();
        //return user
        return user;
    }

    public User GetUserById(int id)
    {
        //get user from database using linq
        var userId = _context.Users.FirstOrDefault(u => u.Id == id);
        //return user
        return userId;
    }

    public User GetUserByEmail(string email)
    {
        //Get user by email using linq
        var userEmail = _context.Users.FirstOrDefault(u => u.Email == email);
        //return user
        return userEmail;
    }

    public User GetUserByAccountNumber(int accountNumber)
    {
        //Get user by account number using linq
        var userAccountNumber = _context.Users.FirstOrDefault(u => u.AccountNumber == accountNumber);
        //return user
        return userAccountNumber;
    }

    public void UpdateUser(User user)
    {
        //update user in database
        _context.Users.Update(user);
        //save changes to database
        _context.SaveChanges();
    }
}