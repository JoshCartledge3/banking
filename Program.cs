using BankingMainApplication.Services;
using System.Security.Cryptography.X509Certificates;

namespace BankingMainApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            // Read 3 databases into variables
            List<PersonalAccount> db_PersonalAccounts = AccountService.ReadAllPersonalAccounts();
            List<BusinessAccount> db_BusinessAccounts = AccountService.ReadAllBusinessAccounts();
            List<ISAAccount> db_ISAAccounts = AccountService.ReadAllISAAccounts();

            // Display main menu options
            Console.WriteLine("This is a banking application. What would you like to do?");
            Console.WriteLine("Transactions (1)");
            Console.WriteLine("Accounts (2)");
            Console.WriteLine("Validation (3)");
            Console.WriteLine("Current Test (4)");
            string? mainMenuDialogResult = Console.ReadLine();

            // Return requested service options
            switch (mainMenuDialogResult)
            {
                case "1":
                    TransactionService.GetTransactionDetails();
                    break;
                case "2":
                    AccountService.CreateAccountMenu();
                    break;
                case "3":
                    // Perform and display the result of the validation attempt (Test)
                    Console.WriteLine(ValidationService.BasicVerification() ? "Validation Successful" : "Validation Unsuccessful");
                    break;
                default:
                    break;
            }

            // Save all database data before exiting
            AccountService.SaveAllDatabaseData();

            // This'll just keep running so it's less annoying than having to constantly run the app
            Console.WriteLine();
            Main(new string[] { "test" });
        }
    }
}