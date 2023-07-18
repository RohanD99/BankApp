using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.SetupNewBank
{
    internal class BankManager
    {
        private static List<NewBank> banks = new List<NewBank>();

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
                    Console.WriteLine("Bank Name: " + bank.bankName);
                    Console.WriteLine("Bank ID: " + bank.bankId);
                    Console.WriteLine("Branch Name: " + bank.branchName);
                    Console.WriteLine("IMPS Charge: " + bank.impsCharge + "%");
                    Console.WriteLine("RTGS Charge: " + bank.rtgsCharge + "%");
                    Console.WriteLine("RTGS Charge (Other Bank): " + bank.rtgsChargeOtherBank + "%");
                    Console.WriteLine("IMPS Charge (Other Bank): " + bank.impsChargeOtherBank + "%");
                    Console.WriteLine("Currency Type: " + bank.currencyType);
                    Console.WriteLine("-------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("No banks found.");
            }
        }
    }
}
