using BankApp.SetupNewBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Views
{
    internal class BankView
    {
        public static void DisplayBankDetails(BankService bank)
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

        public static void DisplayNoBanksFound()
        {
            Console.WriteLine("No banks found.");
        }

        public static void DisplayBankSetupCompleted(BankService newBank)
        {
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

        public static string GetBankName()
        {
            Console.WriteLine("Enter bank name:");
            return Console.ReadLine();
        }

        public static string GetBranchName()
        {
            Console.WriteLine("Enter branch name:");
            return Console.ReadLine();
        }

        public static void DisplayRTGSChargeUpdateSameBank()
        {
            Console.WriteLine("Enter the service charge for RTGS (in percentage) for same bank:");
        }
        public static void DisplayIMPSChargeUpdateSameBank()
        {
            Console.WriteLine("Enter the service charge for IMPS (in percentage) for same bank:");
        }

        public static void DisplayRTGSChargeUpdateOtherBank()
        {
            Console.WriteLine("Enter the service charge for RTGS (in percentage) for other bank:");
        }

        public static void DisplayIMPSChargeUpdateOtherBank()
        {
            Console.WriteLine("Enter the service charge for IMPS (in percentage) for other bank:");
        }

        public static void DisplayServiceChargeForOtherBank()
        {
            Console.WriteLine("Add Service Charge for Other Bank Account");
        }

        public static void DisplayAcceptedCurrency()
        {
            Console.WriteLine("Add New Accepted Currency");
        }

        public static void DisplayServiceChargeForSameBank()
        {
            Console.WriteLine("Add Service Charge for Same Bank Account");
        }

        public static void DisplayChargesUpdated()
        {
            Console.WriteLine("Service charges updated successfully for given bank.");
        }

        public static void DisplayCurrencyCode()
        {
            Console.WriteLine("Enter the currency code:");
        }

        public static void DisplayExchangeRate()
        {
            Console.WriteLine("Enter the exchange rate:");
        }

        public static void DisplayCurrencyAdded()
        {
            Console.WriteLine("Enter the exchange rate:");
        }

        public static void DisplayAsBankStaff()
        {
            Console.WriteLine("Login as Bank Staff");
        }

        public static void DisplayStaffOperations()
        {
            Console.WriteLine("Select an action:");
            Console.WriteLine("1. Create new account and provide username and password to account holder");
            Console.WriteLine("2. Update account");
            Console.WriteLine("3. Delete account");
            Console.WriteLine("4. Show all accounts");
            Console.WriteLine("5. Add new accepted currency with exchange rate");
            Console.WriteLine("6. Add service charge for same bank account (RTGS and IMPS)");
            Console.WriteLine("7. Add service charge for other bank account (RTGS and IMPS)");
            Console.WriteLine("8. View account transaction history");
            Console.WriteLine("9. Go back to start");
            Console.WriteLine();
        }

        public static void AmountDepositedSuccessfully()
        {
            Console.WriteLine("Amount deposited successfully.");
        }

        public static void AmountWithdrawnSuccessfully()
        {
            Console.WriteLine("Amount withdrawn successfully.");
        }

        public static void ViewTransactionHistory()
        {
            Console.WriteLine("Transaction History:");
        }

        public static void ViewBalance(double accountBalance)
        {
            Console.WriteLine("Account Balance: " + accountBalance);
        }

        public static void ViewTransaction(string transaction)
        {
            Console.WriteLine(transaction);
        }

        public static void FundsTransferredSuccessfully()
        {
            Console.WriteLine("Funds transferred successfully.");
        }

    }
}
