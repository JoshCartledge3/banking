using System;
using System.Collections.Generic;
using System.IO;
using BankingMainApplication.Services;

namespace BankingMainApplication
{
    public class BusinessAccount : Account
    {
        // Standard business account attributes
        public string? BusinessName { get; set; }
        public string? BusinessType { get; set; }
        public DateOnly RegistryDate { get; set; }

        public const int AnnualAccountFee = 120;

        // If a business is any of the below type, it does not qualify for for a business account
        private static readonly List<string> ExcludedBusinesses = new List<string>{ "Enterprise", "PLC", "Charity", "Public Sector" };

        /// <summary>
        /// Creates a new business account
        /// </summary>
        public static void CreateBusinessAccount()
        {
            // Get business details
            Console.Write("Business name: ");
            var businessName = Console.ReadLine() ?? throw new Exception("You must provided a business name.");
            Console.Write("Business type: ");
            var businessType = Console.ReadLine()  ?? throw new Exception("You must provided a business name.");
            Console.WriteLine("Business Registry Date: ");
            var registryDate = AppHelpers.StringToDateOnly();

            // Create a new instance of a business account
            BusinessAccount newBusinessAccount = new BusinessAccount()
            {
                AccountId = Guid.NewGuid(),
                BusinessName = businessName,
                BusinessType = businessType,
                RegistryDate = registryDate,
                Balance = 0
            };

            // Initialize an error list
            List<int> errorList = new();
            if (ExcludedBusinesses.Contains(businessType) || string.IsNullOrWhiteSpace(businessType)) errorList.Add(1);
            if (string.IsNullOrWhiteSpace(newBusinessAccount.BusinessName)) errorList.Add(2);

            // Read in the list of business accounts
            List<BusinessAccount> allBusinessAccounts = AccountService.ReadAllBusinessAccounts();
            {
                foreach (var account in allBusinessAccounts)
                {
                    if ((account.BusinessName == newBusinessAccount.BusinessName) && !string.IsNullOrWhiteSpace(newBusinessAccount.BusinessName)) errorList.Add(3);
                    break;
                }
            }

            // Perform basic ID verification
            if (!ValidationService.BasicVerification()) errorList.Add(4);

            // If the object is complete, verify the business and write their account to CSV
            if (errorList.Count == 0)
            {
                if (errorList.Count == 0)
                {
                    AccountService.CreateNewPersonalAccount(newBusinessAccount);
                    Console.WriteLine("Account creation successful.");
                }
            }
            // Otherwise, do not create account and display the error
            else
            {
                Console.WriteLine("** Account creation failed **");
                foreach (var error in errorList)
                {
                    switch (error)
                    {
                        case 1:
                            Console.WriteLine("- Invalid business type.");
                            break;
                        case 2:
                            Console.WriteLine("- No business name was entered.");
                            break;
                        case 3:
                            Console.WriteLine("- Business already exists.");
                            break;
                        case 4:
                            Console.WriteLine("- Invalid/No ID presented.");
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
