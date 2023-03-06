using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Eurus_Bank_DAL.DbConfig;

public class EurusDbContextFactory : IDesignTimeDbContextFactory<EurusDbContext>
{
    public EurusDbContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<EurusDbContext>();
        const string ConnectionString = 
            @"Data Source=WORKSPACE\SQLEXPRESS;Initial Catalog=ATM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        optionBuilder.UseSqlServer(ConnectionString);
        return new EurusDbContext(optionBuilder.Options);
    }
}