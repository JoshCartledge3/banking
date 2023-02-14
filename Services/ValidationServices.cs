using System;
using System.Linq;

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
            string[] validInputs = { "y", "n" };

            // Prompt user with verification questions
            Console.WriteLine("Has the applicant presented a valid photo ID? [Y/N]");
            var photoIdAnswer = Console.ReadLine() ?? "";
            var validPhotoId = ValidateReadLineInput(photoIdAnswer, validInputs);

            Console.WriteLine("Has the applicant presented a valid address-based ID? [Y/N]");
            var proofOfAddressAnswer = Console.ReadLine() ?? "";
            var validProofOfAddress = ValidateReadLineInput(proofOfAddressAnswer, validInputs);

            return false;
        }

        private static string ValidateReadLineInput(string? input, string[] validInputs)
        {
            if (input == null) throw new Exception("Please provide an answer.");

            while (!validInputs.Contains(input.ToLower()))
            {
                Console.WriteLine("Please enter a valid answer");
                input = Console.ReadLine() ?? "";
            }

            return input;
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
