using System;

namespace BankingMainApplication.Services
{
    public static class AccountService
    {
        public static void GetAccountDetails()
        {
            Console.WriteLine("GetAccountDetails");
        }

        public static void CreateAccountMenu()
        {
            Console.WriteLine("*** CREATE ACCOUNTS ***");
            Console.WriteLine("Select an account to create.");
            Console.WriteLine("Personal Account (1)");
            Console.WriteLine("Business Account (2)");
            Console.WriteLine("ISA Account (3)");

            string? createAccountDialogResponse = Console.ReadLine();

            switch (createAccountDialogResponse)
            {
                case "1":
                    PersonalAccount.CreatePersonalAccount();
                    break;
                case "2":
                    BusinessAccount.CreateBusinessAccount();
                    break;
                case "3":
                    ISAAccount.CreateISAAccount();
                    break;
                default:
                    Console.WriteLine("No option Selected");
                    break;
            }
        }
    }
}
