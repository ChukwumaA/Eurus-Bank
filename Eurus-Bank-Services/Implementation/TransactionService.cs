using Eurus_Bank_DAL.DbConfig;
using Eurus_Bank_Models;
using Eurus_Bank_Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Eurus_Bank_Services.Implementation;

public class TransactionService : ITransactionService
{
    private readonly EurusDbContext _dbContext;
    
    public TransactionService(EurusDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void CreateTransaction(Transaction transaction)
    {
        _dbContext.Transactions.Add(transaction);
        _dbContext.SaveChanges();
    }
    
    public List<Transaction> GetTransactionsByUserId(int userId)
    {
        //get transactions by user id using linq
        return _dbContext.Transactions.Where(x => x.UserId == userId).ToList();

    }


}