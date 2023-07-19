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

        public static decimal GetAccountBalanceByAccountNumber(string accountNumber)
        {
            AccountDetails.Account account = AccountDetails.GetAccountByNumber(accountNumber);
            if (account != null)
            {
                return account.AccountBalance;
            }
            return 0;
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
                    ViewTransactionHistory();
                    break;
                case 5:
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
                UpdateLinkedAccountBalance(amount);
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
                UpdateLinkedAccountBalance(-amount);
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
                UpdateLinkedAccountBalance(-amount);
            }
        }

        private static void UpdateLinkedAccountBalance(double amount)
        {
            if (!string.IsNullOrEmpty(linkedAccountNumber))
            {
                var account = AccountDetails.GetAccountByNumber(linkedAccountNumber);
                if (account != null)
                {
                    account.AccountBalance += (decimal)amount;
                    account.TransactionHistory.Add("Linked Account Transaction: " + (amount >= 0 ? "+" : "-") + Math.Abs(amount));
                }
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
