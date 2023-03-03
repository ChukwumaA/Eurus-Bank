using Eurus_Bank_Models.Enum;

namespace Eurus_Bank_Models;

public class Transaction
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    
    public TransactionType Type { get; set; }
    
    public decimal Amount { get; set; }
    
    public DateTime DateTime { get; set; }
}