using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BankApp.SetupNewBank
{
    internal class Bank
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
            public static void SetupNewBank(Bank newBank)
            {
                Console.WriteLine("Enter bank name:");
                newBank.bankName = Console.ReadLine();

                if (!IsValidInput(newBank.bankName))
                {
                    Console.WriteLine("Invalid bank name. Please enter only alphabets.");
                    return;
                }

                Console.WriteLine("Enter branch name:");
                newBank.branchName = Console.ReadLine();

                if (!IsValidInput(newBank.branchName))
                {
                    Console.WriteLine("Invalid branch name. Please enter only alphabets.");
                    return;
                }

                newBank.bankId = GenerateBankId(newBank.bankName.ToUpper());
                newBank.branchCode = GenerateBranchCode(newBank.branchName);
                newBank.ifscCode = GenerateIfscCode(newBank.branchName);

                newBank.CalculateCharges();

                BankManager.AddBank(newBank);

                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Bank setup completed:");
                Console.WriteLine("Bank Name: " + newBank.bankName);
                Console.WriteLine("Bank ID: " + newBank.bankId);
                Console.WriteLine("Branch Name: " + newBank.branchName);
                Console.WriteLine("Branch IFSC Code: " + newBank.ifscCode);
                Console.WriteLine("IMPS Charge: " + (newBank.currencyType == 1 ? newBank.impsCharge : newBank.impsChargeOtherBank) + "%");
                Console.WriteLine("RTGS Charge: " + (newBank.currencyType == 1 ? newBank.rtgsCharge : newBank.rtgsChargeOtherBank) + "%");
                Console.WriteLine("Currency Type: " + newBank.currencyType);
                Console.WriteLine("Bank added successfully");
                Console.WriteLine("-------------------------------------------");
            }
        }
        private static string GenerateBankId(string bankName)
        {
            try
            {
                if (!Regex.IsMatch(bankName, "^[a-zA-Z]+$"))
                {
                    throw new ArgumentException("Invalid bank name. Please enter only alphabets.");
                }

                string currentDate = DateTime.Now.ToString("yyyyMMdd");
                return bankName.Substring(0, 3) + currentDate;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid bank name length. Please enter a valid name.");
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
                    throw new ArgumentException("Invalid branch name. Please enter only alphabets.");
                }

                return branchName.Substring(0, 3) + DateTime.Now.ToString("yyyyMMdd");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid branch name length. Please enter a valid name.");
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
                Console.WriteLine("Branch name is null or empty. Please enter a valid name.");
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
                Console.WriteLine("Branch name is too short. Please enter a valid name.");
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
