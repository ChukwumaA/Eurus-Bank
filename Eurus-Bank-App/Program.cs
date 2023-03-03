using Eurus_Bank_DAL.DbConfig;
using Eurus_Bank_Models;
using Eurus_Bank_Services.Implementation;

var dbContextFactory = new EurusDbContextFactory();
using var dbContext = dbContextFactory.CreateDbContext(null);
dbContext.Database.EnsureCreated();

var userService = new UserService(dbContext);
var transactionService = new TransactionService(dbContext);
var accountService = new AccountService(userService, transactionService);

Console.Clear();
Console.WriteLine("Eurus Bank Welcomes You!\n");

while (true)
{
    Console.WriteLine("Kindly select an option: \n1. Register\n2. Login\n3. Exit\n");
    var options = Console.ReadLine();

    switch (options)
    {
        case "1":
            Console.Write("Enter your name: ");
            var firstName = Console.ReadLine();
            
            Console.Write("Enter your name: ");
            var lastName = Console.ReadLine();

            Console.Write("Enter your email address: ");
            var email = Console.ReadLine();

            Console.Write("Create account number: ");
            var accountNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter your password: ");
            var password = Console.ReadLine();

            var user = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                AccountNumber = accountNumber,
                Password = password,
                AccountBalance = 0,
                Transactions = new List<Transaction>()
            };
            userService.CreateUser(user);
            Console.WriteLine("\nSuccessfully Registered.\n");
            break;

        case "2":
            Console.Write("Enter your email address: ");
            var loginEmail = Console.ReadLine();

            Console.Write("Enter your password: ");
            var loginPassword = Console.ReadLine();

            var loginUserByEmail = userService.GetUserByEmail(loginEmail);
            if (loginUserByEmail == null || loginUserByEmail.Password != loginPassword)
            {
                Console.WriteLine("Invalid email or password\n");
                break;
            }

            Console.Clear();
            Console.WriteLine($"Welcome back, {loginUserByEmail.FirstName}{loginUserByEmail.LastName}\n");

            while (true)
            {
                Console.WriteLine("Please select an option to continue: ");
                Console.WriteLine(
                    "1. Withdraw\n2. Payment\n3. Transfer\n4. Check Balance\n5. Deposit\n6. Logout\n");

                var accountOperation = Console.ReadLine();
                switch (accountOperation)
                {
                    case "1":
                        Console.Write("Enter withdrawal amount: ");
                        var withdrawalAmount = decimal.Parse(Console.ReadLine());
                        accountService.Withdrawal(loginUserByEmail, withdrawalAmount);
                        break;
                    
                    case "2":
                        Console.Write("Enter recipient's account number: ");
                        var recipientAccountNumber = int.Parse(Console.ReadLine());

                        Console.Write("Enter transfer amount: ");
                        var transferAmount = decimal.Parse(Console.ReadLine());

                        accountService.Transfer(loginUserByEmail, recipientAccountNumber, transferAmount);
                        break;
                    case "3":
                        accountService.CheckBalance(loginUserByEmail);
                        break;
                    case "4":
                        Console.Write("Enter the amount you wish to deposit: ");
                        var depositAmount = decimal.Parse(Console.ReadLine());
                        accountService.Deposit(loginUserByEmail, depositAmount);
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine($"Goodbye, {loginUserByEmail.FirstName}!\n");
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }

                if (accountOperation == "5")
                {
                    break;
                }
            }

            break;
        case "3":
            Console.WriteLine($"Thank you for banking with us!\n");
            break;
        default:
            Console.WriteLine("Invalid Option.");
            break;
    }
}