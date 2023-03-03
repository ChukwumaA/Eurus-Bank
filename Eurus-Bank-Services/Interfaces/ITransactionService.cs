using Eurus_Bank_Models;

namespace Eurus_Bank_Services.Interfaces;

public interface ITransactionService
{
    void CreateTransaction(Transaction transaction);
    List<Transaction> GetTransactionsByUserId(int userId);
}