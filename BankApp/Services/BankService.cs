using BankApp.Views;
using System;
using System.Text.RegularExpressions;

namespace BankApp.SetupNewBank
{
    internal class BankService
    {
        public string bankId;
        public string bankName;
        public string branchCode;
        public string branchName;
        public string ifscCode;
        public int impsCharge;
        public int rtgsCharge;
        public int rtgsChargeOtherBank;
        public int impsChargeOtherBank;
        public int currencyType;

        public class BankSetup
        {
            public static void SetupNewBank(BankService newBank)
            {

                newBank.bankName = BankView.GetBankName();

                if (!IsValidInput(newBank.bankName))
                {
                    AdminView.DisplayInvalidCredentials();
                    return;
                }

                BankView.GetBranchName();
                newBank.branchName = Console.ReadLine();

                if (!IsValidInput(newBank.branchName))
                {
                    AdminView.DisplayInvalidCredentials();
                    return;
                }

                newBank.bankId = GenerateBankId(newBank.bankName.ToUpper());
                newBank.branchCode = GenerateBranchCode(newBank.branchName);
                newBank.ifscCode = GenerateIfscCode(newBank.branchName);

                newBank.CalculateCharges();

                BankManagerService.AddBank(newBank);

            }
        }
        private static string GenerateBankId(string bankName)
        {
            try
            {
                if (!Regex.IsMatch(bankName, "^[a-zA-Z]+$"))
                {
                    AdminView.DisplayInvalidCredentials();
                }

                string currentDate = DateTime.Now.ToString("yyyyMMdd");
                return bankName.Substring(0, 3) + currentDate;
            }
            catch (ArgumentOutOfRangeException)
            {
                AdminView.DisplayInputOutOfRange();
                return null;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private static string GenerateBranchCode(string branchName)
        {
            try
            {
                if (!Regex.IsMatch(branchName, "^[a-zA-Z]+$"))
                {
                    AdminView.DisplayInvalidCredentials();
                }

                return branchName.Substring(0, 3) + DateTime.Now.ToString("yyyyMMdd");
            }
            catch (ArgumentOutOfRangeException)
            {
                AdminView.DisplayInputOutOfRange();
                return null;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private static string GenerateIfscCode(string branchName)
        {
            if (string.IsNullOrEmpty(branchName))
            {
                AdminView.DisplayInvalidCredentials();
                return null;
            }

            Random random = new Random();
            string randomDigits = random.Next(1000, 9999).ToString();

            if (branchName.Length >= 3)
            {
                return branchName.Substring(0, 3).ToUpper() + randomDigits;
            }
            else
            {
                AdminView.DisplayInputOutOfRange();
                return null;
            }
        }

        private static bool IsValidInput(string input)
        {
            return Regex.IsMatch(input, "^[a-zA-Z]+$");
        }


        public void CalculateCharges()
        {
            if (currencyType == 1) 
            {
                impsCharge = 5;
                rtgsCharge = 0;
                impsChargeOtherBank = 0;
                rtgsChargeOtherBank = 0;
            }
            else 
            {
                impsCharge = 6;
                rtgsCharge = 0;
                impsChargeOtherBank = 6;
                rtgsChargeOtherBank = 2;
            }
        }
    }
}
