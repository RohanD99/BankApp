using BankApp.Views;
using System;
using System.Collections.Generic;

namespace BankApp.SetupNewBank
{
    internal class BankManagerService
    {
        public static List<BankService> banks = new List<BankService>();

        public static void AddBank(BankService newBank)
        {
            banks.Add(newBank);
        }

        public static void DisplayBanks()
        {
            if (banks.Count > 0)
            {                
                foreach (BankService bank in banks)
                {
                    BankView.DisplayBankDetails(bank);
                }
            }
            else
            {
                BankView.DisplayNoBanksFound();
            }
        }


        public static BankService GetBankByName(string bankName)
        {
            foreach (BankService bank in banks)
            {
                if (bank.bankName == bankName)
                {
                    return bank;
                }
            }
            return null;
        }

        public static BankService GetBankById(string bankId)
        {
            foreach (BankService bank in banks)
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
