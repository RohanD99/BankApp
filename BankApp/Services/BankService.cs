using BankApp.Views;
using System;
using System.Text.RegularExpressions;

namespace BankApp.SetupNewBank
{
    internal class BankService
    {
        public string BankId;
        public string BankName;
        public string BranchCode;
        public string BranchName;
        public string IfscCode;
        public int ImpsCharge;
        public int RtgsCharge;
        public int RtgsChargeOtherBank;
        public int ImpsChargeOtherBank;
        public int CurrencyType;

        public class BankSetup
        {
            public static void SetupNewBank(BankService newBank)
            {
                newBank.BankName = BankView.GetBankName();       //1

                if (!IsValidInput(newBank.BankName))
                {
                    AdminView.DisplayInvalidCredentials();        //2
                    return;
                }

                newBank.BranchName = BankView.GetBranchName();      //3

                if (!IsValidInput(newBank.BranchName))
                {
                    AdminView.DisplayInvalidCredentials();              //4
                    return;
                }

                newBank.BankId = GenerateBankId(newBank.BankName.ToUpper());
                newBank.BranchCode = GenerateBranchCode(newBank.BranchName);
                newBank.IfscCode = GenerateIfscCode(newBank.BranchName);

                newBank.CalculateCharges();

                BankManagerService.AddBank(newBank);               
                 BankView.DisplayBankSetupCompleted(newBank);             //5
            } 
        }
        private static string GenerateBankId(string bankName)
        {
            try
            {
                if (!Regex.IsMatch(bankName, "^[a-zA-Z]+$"))
                {
                    AdminView.DisplayInvalidCredentials();                   //6
                }

                string currentDate = DateTime.Now.ToString("yyyyMMdd");
                return bankName.Substring(0, 3) + currentDate;
            }
            catch (ArgumentOutOfRangeException)
            {
                AdminView.DisplayInputOutOfRange();                            //7
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
            if (CurrencyType == 1) 
            {
                ImpsCharge = 5;
                RtgsCharge = 0;
                ImpsChargeOtherBank = 0;
                RtgsChargeOtherBank = 0;
            }
            else 
            {
                ImpsCharge = 6;
                RtgsCharge = 0;
                ImpsChargeOtherBank = 6;
                RtgsChargeOtherBank = 2;
            }
        }
    }
}
