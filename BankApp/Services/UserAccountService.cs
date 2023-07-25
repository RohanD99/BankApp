using BankApp.Views;
using System;
using System.Collections.Generic;

namespace BankApp.AccountHolder
{
    internal class UserAccountService
    {      
        public double accountBalance = 0;
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
                    AdminView.DisplayBackToStart();
                    isAccountHolderLoggedIn = false;
                    break;
                default:
                    AdminView.DisplayInvalidChoice();
                    break;
            }
        }

        private void DepositAmount()
        {
            AccountView.GetAmount();
            double amount = Convert.ToDouble(Console.ReadLine());

            if (amount <= 0)
            {
                AdminView.DisplayInvalidInput();
            }
            else
            {
                accountBalance += amount;
                BankView.AmountDepositedSuccessfully();
                transactionHistory.Add("Deposit: +" + amount);
            }
        }

        private void WithdrawAmount()
        {
            AccountView.GetAmount();
            double amount = Convert.ToDouble(Console.ReadLine());

            if (amount <= 0)
            {
                AdminView.DisplayInvalidInput();
            }
            else if (amount > accountBalance)
            {
                AccountView.DisplayInsufficientFunds();
            }
            else
            {
                accountBalance -= amount;
                BankView.AmountWithdrawnSuccessfully();
                transactionHistory.Add("Withdrawal: -" + amount);
            }
        }

        private void TransferFunds()
        {
            AccountView.GetAmount();
            double amount = Convert.ToDouble(Console.ReadLine());

            if (amount <= 0)
            {
                AdminView.DisplayInvalidInput();
            }
            else if (amount > accountBalance)
            {
                AccountView.DisplayInsufficientFunds();
            }
            else
            {

                string recipientAccountNumber = AccountView.GetAccountNumberByUser();

                BankView.FundsTransferredSuccessfully();
                accountBalance -= amount;
                transactionHistory.Add("Transfer: -" + amount + " to Account No. " + recipientAccountNumber);
            }
        }

        private void ViewTransactionHistory()
        {
            BankView.ViewTransactionHistory();
            foreach (string transaction in transactionHistory)
            {
                BankView.ViewTransaction(transaction);
            }
        }

        private void CheckBalance()
        {
            BankView.ViewBalance(accountBalance);
        }

        public static void SetLoggedInUsername(string username)
        {
            loggedInUsername = username;
        }
    }
}