
namespace BankingMainApplication
{
    public class ISAAccount : Account
    {
        // Standard ISA Account attributes
        // Residential Status
        public bool ResidentOrCrownServant { get; set; }

        // Age conditions
        public const int MinimumAge = 18;
        public const int MaximumAge = 40;

        // Interest and Bonus rates
        public const float InterestRate = 2.7f;
        public const float EarlyWithdrawalFee = 0.25f;
        public const float AnnualBonus = 0.25f;

        // Accepted withdrawal conditions
        public string[] AcceptedWithdrawalConditions = { "Terminal", "Retirement", "First Home" };
    }
}
