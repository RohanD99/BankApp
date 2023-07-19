using System;
using System.Collections.Generic;

namespace BankApp.SetupNewBank
{
    internal class NewBank
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
            public static void SetupNewBank(NewBank newBank)
            {
                Console.WriteLine("Enter bank name:");
                newBank.bankName = Console.ReadLine();

                Console.WriteLine("Enter branch name:");
                newBank.branchName = Console.ReadLine();

                Console.WriteLine("Enter currency type (1 for INR, 2 for USD, etc.):");
                newBank.currencyType = Convert.ToInt32(Console.ReadLine());

                newBank.bankId = GenerateBankId(newBank.bankName);
                newBank.branchCode = GenerateBranchCode(newBank.branchName);
                newBank.ifscCode = GenerateIfscCode(newBank.branchName);

                if (newBank.currencyType == 1) // INR currency
                {
                    newBank.rtgsCharge = 0;
                    newBank.impsCharge = 5;
                    newBank.rtgsChargeOtherBank = 0;
                    newBank.impsChargeOtherBank = 0;
                }
                else // Other currency
                {
                    newBank.rtgsCharge = 0;
                    newBank.impsCharge = 0;
                    newBank.rtgsChargeOtherBank = 2;
                    newBank.impsChargeOtherBank = 6;
                }

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
            return bankName.Substring(0, 3) + DateTime.Now.ToString("yyyyMMdd");
        }

        private static string GenerateBranchCode(string branchName)
        {
            return branchName.Substring(0, 3) + DateTime.Now.ToString("yyyyMMdd");
        }

        private static string GenerateIfscCode(string branchName)
        {
            Random random = new Random();
            string randomDigits = random.Next(1000, 9999).ToString();
            return branchName.Substring(0, 3).ToUpper() + randomDigits;
        }
      
      
    }
}
