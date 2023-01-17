
namespace BankingMainApplication
{
    public class BusinessAccount : Account
    {
        // Standard business account attributes
        public string? BusinessName { get; set; }
        public string? BusinessType { get; set; }
        public const int AnnualAccountFee = 120;

        // If a business is any of the below type, it does not qualify for for a business account
        public string[] ExcludedBusinesses = { "Enterprise", "PLC", "Charity", "Public Sector" };
    }
}
