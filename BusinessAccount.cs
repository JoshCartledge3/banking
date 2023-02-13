
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
        public static string[] ExcludedBusinesses = { "Enterprise", "PLC", "Charity", "Public Sector" };
    

        public static void CreateBusinessAccount()
        {
            // Get business details
            Console.Write("Business name: ");
            string? businessName = Console.ReadLine();
            Console.Write("Business type: ");
            string? businessType = Console.ReadLine();
            Console.Write("Business Registry Date: ");
            DateOnly registryDate = AppHelpers.StringToDateOnly();

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

            try //to read the file
            {
                foreach (var account in File.ReadAllLines("BusinessAccounts.csv"))
                {
                    if (account.Contains(newBusinessAccount.BusinessName) && !string.IsNullOrWhiteSpace(newBusinessAccount.BusinessName)) errorList.Add(3);
                    break;
                }
            }
            catch
            {
                // Do nothing
            }

            // Perform basic ID verification
            if (!ValidationService.BasicVerification()) errorList.Add(4);

            // If the object is complete, verify the business and write their account to CSV
            if (errorList.Count == 0)
            {
                using (StreamWriter sw = File.AppendText("BusinessAccounts.csv"))
                {
                    sw.WriteLine($"{newBusinessAccount.AccountId}, {newBusinessAccount.BusinessName}," +
                                 $"{newBusinessAccount.BusinessType}, {newBusinessAccount.RegistryDate}, " +
                                 $"{newBusinessAccount.Balance}");
                }
                Console.WriteLine("Account creation successful.");
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
