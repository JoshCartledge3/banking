
namespace BankingMainApplication
{
    public class ISAAccount : Account
    {
        // Standard ISA Account attributes
        // Age conditions
        public const int MinimumAge = 18;
        public const int MaximumAge = 40;

        // Interest and Bonus rates
        public const float InterestRate = 2.7f;
        public const float EarlyWithdrawlFee = 0.25f;
        public const float AnnualBonus = EarlyWithdrawlFee;

        // Accepted withdrawl conditions
        public string[] AcceptedWithdrawlConditions = { "Terminal", "Retirement", "First Home" };
    }
}
