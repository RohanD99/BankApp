﻿using BankApp.SetupNewBank;
using System;

namespace BankApp.Views
{
    internal class BankView
    {
        public static void DisplayBankDetails(BankService bank)
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Bank Name: " + bank.BankName);
            Console.WriteLine("Bank ID: " + bank.BankId);
            Console.WriteLine("Branch Name: " + bank.BranchName);
            Console.WriteLine("Branch IFSC Code: " + bank.IfscCode);
            Console.WriteLine("IMPS Charge: " + (bank.CurrencyType == 1 ? bank.ImpsCharge : bank.ImpsChargeOtherBank) + "%");
            Console.WriteLine("RTGS Charge: " + (bank.CurrencyType == 1 ? bank.RtgsCharge : bank.RtgsChargeOtherBank) + "%");
            Console.WriteLine("Currency Type: " + bank.CurrencyType);
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
            Console.WriteLine("Bank Name: " + newBank.BankName);
            Console.WriteLine("Bank ID: " + newBank.BankId);
            Console.WriteLine("Branch Name: " + newBank.BranchName);
            Console.WriteLine("Branch IFSC Code: " + newBank.IfscCode);
            Console.WriteLine("IMPS Charge: " + (newBank.CurrencyType == 1 ? newBank.ImpsCharge : newBank.ImpsChargeOtherBank) + "%");
            Console.WriteLine("RTGS Charge: " + (newBank.CurrencyType == 1 ? newBank.RtgsCharge : newBank.RtgsChargeOtherBank) + "%");
            Console.WriteLine("Currency Type: " + newBank.CurrencyType);
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
