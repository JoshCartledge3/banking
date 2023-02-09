
using System.Text;

namespace BankingMainApplication
{
    public class Account
    {
        // Requirements
        public const int MinimumDeposit = 1;

        // User Information
        public long AccountId { get; set; }
        public double Balance { get; set; }
        public string? Forename { get; set; }
        public string? Surname { get; set; }
        public DateOnly DateOfBirth { get; set; }

        #region Account Helpers
        /// <summary>
        /// Creates a new account ID based on a customers name and date of birth
        /// </summary>
        /// <param name="Forename"></param>
        /// <param name="Surname"></param>
        /// <param name="Date of birth"></param>
        /// <returns>A 12 digit unique account ID</returns>
        public static long CreateNewAccountID(string forename, string surname, DateOnly DOB)
        {
            // Pad one place with Z and X if a customer's name only has one letter
            forename = forename.PadRight(2, 'Z').ToUpper();
            surname = surname.PadRight(2, 'Y').ToUpper();

            // Create numbers based on ascii values of the first characters of a customer's first and last names
            string forenameEncoded = ((int)forename[0] + (int)forename[1]).ToString();
            string surnameEndoded = ((int)surname[0] + (int)surname[1]).ToString();

            // Return a long comprised of (first name (3), surname (3), date of birth (6)
            return Convert.ToInt64(forenameEncoded + surnameEndoded + DOB.ToString("ddMMyy"));
        }
        #endregion
    }

}
