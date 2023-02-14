namespace BankingMainApplication.Services
{
    public static class ValidationService
    {
        public static void GetValidationDetails()
        {
            Console.WriteLine("GetValidationDetails");
        }

        #region Opening Account Validation

        /// <summary>
        /// Performs the three basic verification checks
        /// </summary>
        /// <returns>True if all checks pass</returns>
        public static bool BasicVerification()
        {
            string[] basicChecks = new string[2];

            // Prompt user with verification questions
            Console.Write("Has the applicant presented a valid photo ID? [Y/N]: ");
            basicChecks[0] = Console.ReadLine().ToLower();
            Console.Write("Has the applicant presented a valid address-based ID? [Y/N]: ");
            basicChecks[1] = Console.ReadLine().ToLower();

            return basicChecks.SequenceEqual(new string[] { "y", "y"});
        }

        /// <summary>
        /// Verification process for an applicant attempting to open a personal account
        /// </summary>
        /// <returns>Returns true if the applicant is verified</returns>
        public static bool VerifyPersonalAccount()
        {
            return BasicVerification();
        }

        /// <summary>
        /// Verification process for an applicant attempting to open a business account
        /// </summary>
        /// <returns>Returns true if the applicant is verified</returns>
        public static bool VerifyBusinessAccount()
        {
            return BasicVerification();
        }

        /// <summary>
        /// Verification process for an applicant attempting to open an ISA account
        /// </summary>
        /// <returns>True if the applicant is verified</returns>
        public static bool VerifyISAAccount()
        {
            return BasicVerification();
        }

        #endregion
    }
}
