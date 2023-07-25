using System;
using System.Collections.Generic;
using BankApp.Models;

namespace BankApp.AccountHolder
{
    internal class UserAccount
    {      
        public double accountBalance = 0;
        Account account;
        private List<string> transactionHistory = new List<string>();
        private static bool isAccountHolderLoggedIn = false;
        private static string loggedInUsername = string.Empty;

        public static bool IsAccountHolderLoggedIn
        {
            get { return isAccountHolderLoggedIn; }
            set { isAccountHolderLoggedIn = value; }
        }

        public void PerformAccountHolderAction(int action)
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
                    CheckBalance();
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

        private void DepositAmount()
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

        private void WithdrawAmount()
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

        private void TransferFunds()
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

        private void ViewTransactionHistory()
        {
            Console.WriteLine("Transaction History:");
            foreach (string transaction in transactionHistory)
            {
                Console.WriteLine(transaction);
            }
        }

        private void CheckBalance()
        {
            Console.WriteLine("Account Balance: " + accountBalance);
        }

        // Method to set the logged-in username
        public static void SetLoggedInUsername(string username)
        {
            loggedInUsername = username;
        }
    }
}