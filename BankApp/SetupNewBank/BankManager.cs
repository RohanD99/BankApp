using System;
using System.Collections.Generic;

namespace BankApp.SetupNewBank
{
    internal class BankManager
    {
        public static List<NewBank> banks = new List<NewBank>();

        public static void AddBank(NewBank newBank)
        {
            banks.Add(newBank);
        }

        public static void DisplayBanks()
        {
            if (banks.Count > 0)
            {
                Console.WriteLine("List of Banks:");
                foreach (NewBank bank in banks)
                {
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("Bank Name: " + bank.bankName);
                    Console.WriteLine("Bank ID: " + bank.bankId);
                    Console.WriteLine("Branch Name: " + bank.branchName);
                    Console.WriteLine("Branch IFSC Code: " + bank.ifscCode);
                    Console.WriteLine("IMPS Charge: " + (bank.currencyType == 1 ? bank.impsCharge : bank.impsChargeOtherBank) + "%");
                    Console.WriteLine("RTGS Charge: " + (bank.currencyType == 1 ? bank.rtgsCharge : bank.rtgsChargeOtherBank) + "%");
                    Console.WriteLine("Currency Type: " + bank.currencyType);
                    Console.WriteLine("-------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("No banks found.");
            }
        }

        public static NewBank GetBankByName(string bankName)
        {
            foreach (NewBank bank in banks)
            {
                if (bank.bankName == bankName)
                {
                    return bank;
                }
            }
            return null;
        }

        public static NewBank GetBankById(string bankId)
        {
            foreach (NewBank bank in banks)
            {
                if (bank.bankId == bankId)
                {
                    return bank;
                }
            }
            return null;
        }
    }
}
