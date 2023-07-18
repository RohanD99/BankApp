using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp;

namespace BankApp.SetupNewBank
{
    internal class NewBank
    {
        private string adminUsername;
        private string adminPassword;
        public string bankId;
        public string bankName;
        public string branchCode;
        public string branchName;
        public int impsCharge;
        public int rtgsCharge;
        public int rtgsChargeOtherBank;
        public int impsChargeOtherBank;
        public int currencyType;

        public class BankSetup
        {
            public static void SetupNewBank()
            {

                NewBank newBank = new NewBank();

                Console.WriteLine("Enter bank name:");
                newBank.bankName = Console.ReadLine();

                Console.WriteLine("Enter branch name:");
                newBank.branchName = Console.ReadLine();

                Console.WriteLine("Enter currency type (1 for INR, 2 for USD, etc.):");
                newBank.currencyType = Convert.ToInt32(Console.ReadLine());

                newBank.bankId = GenerateBankId(newBank.bankName);
                newBank.branchCode = GenerateBranchCode(newBank.branchName);

                newBank.rtgsCharge = 0;
                newBank.impsCharge = 5;

                newBank.rtgsChargeOtherBank = 2;
                newBank.impsChargeOtherBank = 6;

                BankManager.AddBank(newBank);

                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Bank setup completed:");
                Console.WriteLine("Bank Name: " + newBank.bankName);
                Console.WriteLine("Bank ID: " + newBank.bankId);
                Console.WriteLine("Branch Name: " + newBank.branchName);
                Console.WriteLine("IMPS Charge: " + newBank.impsCharge + "%");
                Console.WriteLine("RTGS Charge: " + newBank.rtgsCharge + "%");
                Console.WriteLine("RTGS Charge (Other Bank): " + newBank.rtgsChargeOtherBank + "%");
                Console.WriteLine("IMPS Charge (Other Bank): " + newBank.impsChargeOtherBank + "%");
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
        }       
    }




