using Eurus_Bank_Models;
using Microsoft.EntityFrameworkCore;

namespace Eurus_Bank_DAL.DbConfig;

public class EurusDbContext : DbContext
{
    public EurusDbContext(DbContextOptions<EurusDbContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
}