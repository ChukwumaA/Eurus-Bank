using System.ComponentModel.DataAnnotations;

namespace Eurus_Bank_Models;

public class User
{
    public int Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
   [Range(0,10)]
    public int AccountNumber { get; set; }
    
    public decimal AccountBalance { get; set; }
    
    public List<Transaction> Transactions { get; set; }
}