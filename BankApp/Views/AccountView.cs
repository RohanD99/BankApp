using BankApp.Models;
using System;

namespace BankApp.Views
{
    internal static class AccountView
    {
        public static void DisplayNoBanksSetUp()
        {
            Console.WriteLine("No banks have been set up yet. Please set up a bank before creating an account.");
        }

        public static string GetUsername()
        {
            Console.WriteLine("Enter username:");
            return Console.ReadLine();
        }

        public static string GetPassword()
        {
            Console.WriteLine("Enter password:");
            return Console.ReadLine();
        }

        public static string GetAccountNumber()
        {
            Console.WriteLine("Enter the account number:");
            return Console.ReadLine();
        }

        public static int GetAccountTypeChoiceFromUser()
        {
            Console.WriteLine("Enter account type (1 for Savings, 2 for Salary):");
            return Convert.ToInt32(Console.ReadLine());
        }

        public static string GetUpdatedUsername()
        {
            Console.WriteLine("Enter new username:");
            return Console.ReadLine();
        }

        public static string GetUpdatedPassword()
        {
            Console.WriteLine("Enter new password:");
            return Console.ReadLine();
        }

        public static string GetAccountNumberByUser()
        {
            Console.WriteLine("Enter account number:");
            return Console.ReadLine();
        }

        public static string GetBankIdFromUser()
        {
            Console.WriteLine("Enter the bank ID:");
            return Console.ReadLine();
        }

        public static void DisplayBankNotFound()
        {
            Console.WriteLine("Bank not found.");
        }

        public static void DisplayAccountCreatedSuccessfully(string accountNumber)
        {
            Console.WriteLine("Account created successfully.");
            Console.WriteLine("Account Number: " + accountNumber);
        }

        public static void DisplayAccountUpdatedSuccessfully()
        {
            Console.WriteLine("Account updated successfully.");
        }

        public static void DisplayAccountNotFound()
        {
            Console.WriteLine("Account not found");
        }

        public static void DisplayAccountDeletedSuccessfully()
        {
            Console.WriteLine("Account deleted succesfully");
        }

        public static void DisplayAllAccounts(Account account)
        {
            Console.WriteLine("Account Number: " + account.AccountNumber);
            Console.WriteLine("Username: " + account.Username);
            Console.WriteLine("Password: " + account.Password);
            Console.WriteLine("Account Type: " + account.Type);
            if (account.Bank != null)
            {
                Console.WriteLine("Bank name: " + account.Bank.bankName);
            }
            else
            {
                Console.WriteLine("Bank name: N/A");
            }
            Console.WriteLine("-------------------------------------------");
        }

        public static void DisplayUserOperations()
        {
            Console.WriteLine("Select an action:");
            Console.WriteLine("1. Deposit amount");
            Console.WriteLine("2. Withdraw amount");
            Console.WriteLine("3. Transfer funds");
            Console.WriteLine("4. Check Balance");
            Console.WriteLine("5. View transaction history");
            Console.WriteLine("6. Go back to start");
            Console.WriteLine();
        }

        public static void DisplayAsUser()
        {
            Console.WriteLine("Login as Account holder");
        }

        public static void GetAmount()
        {
            Console.WriteLine("Enter the amount:");
        }

        public static void DisplayInsufficientFunds()
        {
            Console.WriteLine("Insufficient funds. Cannot withdraw the requested amount.");
        }

        public static void CreateNewAccount()
        {
            Console.WriteLine("Create New Account");
        }

        public static void UpdateAccount()
        {
            Console.WriteLine("Update Account");
        }

        public static void DeleteAccount()
        {
            Console.WriteLine("Delete Account");
        }

        public static void ShowAllAccounts()
        {
            Console.WriteLine("Show all Accounts");
        }
    }
}
