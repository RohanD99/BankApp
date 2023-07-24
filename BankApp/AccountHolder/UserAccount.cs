using System;
using System.Collections.Generic;
using BankApp.BankStaff;
using BankApp.Models;

namespace BankApp.AccountHolder
{
    internal class UserAccount
    {

        private double accountBalance = 0;
        private static List<string> transactionHistory = new List<string>();
        private static bool isAccountHolderLoggedIn = false;
        private static string loggedInUsername = "";


        public static bool IsAccountHolderLoggedIn
        {
            get { return isAccountHolderLoggedIn; }
            set { isAccountHolderLoggedIn = value; }
        }

        public static void PerformAccountHolderAction(int action)
        {
            UserAccount userAccount = new UserAccount();
            switch (action)
            {
                case 1:
                    userAccount.DepositAmount();
                    break;
                case 2:
                    userAccount.WithdrawAmount();
                    break;
                case 3:
                    userAccount.TransferFunds();
                    break;
                case 4:
                    userAccount.CheckBalance();
                    break;
                case 5:
                    userAccount.ViewTransactionHistory();
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

        private void CheckBalance()
        {
            Console.WriteLine("Account Balance: " + accountBalance);
        }


        private  void ViewTransactionHistory()
        {
            Console.WriteLine("Transaction History:");
            foreach (string transaction in transactionHistory)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}