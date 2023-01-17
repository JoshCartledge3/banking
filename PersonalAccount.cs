
namespace BankingMainApplication
{
    public class PersonalAccount : Account
    {
        // Standard customer account attributes
        public bool ResidentOrCrownServant { get; set; }
        public const int DailyOverdraftFee = 5;
    }
}