using BankApp.BankStaff;
using System;
using System.Collections.Generic;

namespace BankApp.AccountHolder
{
    internal class UserAccount
    {
        private static double accountBalance = 0;
        private static List<string> transactionHistory = new List<string>();

        private static bool isAccountHolderLoggedIn = false;
        private static string loggedInUsername = string.Empty;
        private static string linkedAccountNumber = string.Empty;

        public static void SetLinkedAccountNumber(string accountNumber)
        {
            linkedAccountNumber = accountNumber;
        }

        public static bool IsAccountHolderLoggedIn
        {
            get { return isAccountHolderLoggedIn; }
            set { isAccountHolderLoggedIn = value; }
        }

        private static void CheckTotalAccountBalance()
        {
            Console.WriteLine("Enter the account number to check the total account balance:");
            string accountNumber = Console.ReadLine();

            decimal totalBalance = CalculateTotalAccountBalance(accountNumber);
            if (totalBalance >= 0)
            {
                Console.WriteLine("Total Account Balance for Account Number " + accountNumber + ": " + totalBalance);
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        private static decimal CalculateTotalAccountBalance(string accountNumber)
        {
            decimal totalBalance = 0;
            foreach (AccountDetails.Account account in AccountDetails.accounts)
            {
                if (account.AccountNumber == accountNumber)
                {
                    totalBalance = account.AccountBalance;

                    // Check for linked account balance
                    if (!string.IsNullOrEmpty(account.LinkedAccountNumber))
                    {
                        var linkedAccount = AccountDetails.GetAccountByNumber(account.LinkedAccountNumber);
                        if (linkedAccount != null)
                        {
                            totalBalance += linkedAccount.AccountBalance;
                        }
                    }

                    return totalBalance;
                }
            }
            return -1; // Indicates that the account was not found
        }

        public static void PerformAccountHolderAction(int action)
        {
            switch (action)
            {
                case 1:
                    DepositAmount();
                    break;
                case 2:
                    WithdrawAmount();
                    break;
                case 3:
                    TransferFunds();
                    break;
                case 4:
                    
                    break;
                case 5:
                    ViewTransactionHistory();
                    break;
                case 6:
                    Console.WriteLine("Going back to start...");
                    isAccountHolderLoggedIn = false;
                    break;
                default:
                    Console.WriteLine("Invalid action. Please try again.");
                    break;
            }
        }

        private static void DepositAmount()
        {
            Console.WriteLine("Enter the amount to deposit:");
            double amount = Convert.ToDouble(Console.ReadLine());

            if (amount <= 0)
            {
                Console.WriteLine("Invalid amount. Please enter a positive value.");
            }
            else
            {
                accountBalance += amount;
                Console.WriteLine("Amount deposited successfully.");
                transactionHistory.Add("Deposit: +" + amount);
            }
        }

        private static void WithdrawAmount()
        {
            Console.WriteLine("Enter the amount to withdraw:");
            double amount = Convert.ToDouble(Console.ReadLine());

            if (amount <= 0)
            {
                Console.WriteLine("Invalid amount. Please enter a positive value.");
            }
            else if (amount > accountBalance)
            {
                Console.WriteLine("Insufficient funds. Cannot withdraw the requested amount.");
            }
            else
            {
                accountBalance -= amount;
                Console.WriteLine("Amount withdrawn successfully.");
                transactionHistory.Add("Withdrawal: -" + amount);
              
            }
        }

        private static void TransferFunds()
        {
            Console.WriteLine("Enter the amount to transfer:");
            double amount = Convert.ToDouble(Console.ReadLine());

            if (amount <= 0)
            {
                Console.WriteLine("Invalid amount. Please enter a positive value.");
            }
            else if (amount > accountBalance)
            {
                Console.WriteLine("Insufficient funds. Cannot transfer the requested amount.");
            }
            else
            {
                Console.WriteLine("Enter the recipient's account number:");
                string recipientAccountNumber = Console.ReadLine();

                Console.WriteLine("Funds transferred successfully.");
                accountBalance -= amount;
                transactionHistory.Add("Transfer: -" + amount + " to Account No. " + recipientAccountNumber);
                
            }
        }

      

        private static void ViewTransactionHistory()
        {
            Console.WriteLine("Transaction History:");
            foreach (string transaction in transactionHistory)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}
