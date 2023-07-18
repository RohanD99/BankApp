using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.BankStaff
{
    internal class AccountDetails
    {
        internal class Account
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string AccountNumber { get; set; }

            public List<string> TransactionHistory { get; set; }
        }

        public static Dictionary<string, Account> accountDatabase = new Dictionary<string, Account>();

        public static void CreateNewAccount()
        {
            Console.WriteLine("Enter account holder's username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter account holder's password:");
            string password = Console.ReadLine();

            string accountNumber = GenerateAccountNumber(username);

            Account newAccount = new Account
            {
                Username = username,
                Password = password,
                AccountNumber = accountNumber,
                TransactionHistory = new List<string>()
        };

            accountDatabase.Add(accountNumber, newAccount);

            Console.WriteLine("Account created successfully. Username: " + username + ", Password: " + password);
            Console.WriteLine("Account Number: " + accountNumber);
        }

        private static string GenerateAccountNumber(string accountHolderName)
        {
            string accountNumber = accountHolderName.Substring(0, 3) + DateTime.Now.ToString("yyyyMMdd");
            return accountNumber;
        }

        public static void UpdateAccount()
        {
            Console.WriteLine("Enter the account number to update:");
            string accountNumber = Console.ReadLine();

            if (accountDatabase.ContainsKey(accountNumber))
            {
                Console.WriteLine("Enter the new username:");
                string newUsername = Console.ReadLine();

                Console.WriteLine("Enter the new password:");
                string newPassword = Console.ReadLine();

                // Update the account details
                Account account = accountDatabase[accountNumber];
                account.Username = newUsername;
                account.Password = newPassword;

                Console.WriteLine("Account updated successfully.");
            }
            else
            {
                Console.WriteLine("Account not found. Please enter a valid account number.");
            }
        }

        public static void DeleteAccount()
        {
            Console.WriteLine("Enter the account number to delete:");
            string accountNumber = Console.ReadLine();

            if (accountDatabase.ContainsKey(accountNumber))
            {
                // Delete the account
                accountDatabase.Remove(accountNumber);
                Console.WriteLine("Account deleted successfully.");
            }
            else
            {
                Console.WriteLine("Account not found. Please enter a valid account number.");
            }
        }

        public static void ShowAllAccounts()
        {
            Console.WriteLine("List of all accounts:");

            foreach (var account in accountDatabase.Values)
            {
                Console.WriteLine("Account Number: " + account.AccountNumber);
                Console.WriteLine("Username: " + account.Username);
                Console.WriteLine("Password: " + account.Password);
                Console.WriteLine("-------------------------");
            }
        }

        public static void ViewAccountTransactionHistory(string accountNumber)
        {
            if (accountDatabase.ContainsKey(accountNumber))
            {
                Account account = accountDatabase[accountNumber];
                Console.WriteLine("Transaction history for Account Number: " + accountNumber);
                foreach (string transaction in account.TransactionHistory)
                {
                    Console.WriteLine(transaction);
                }
            }
            else
            {
                Console.WriteLine("Account not found. Please enter a valid account number.");
            }
        }

        public static void AddTransactionToHistory(string accountNumber, string transaction)
        {
            if (accountDatabase.ContainsKey(accountNumber))
            {
                Account account = accountDatabase[accountNumber];
                account.TransactionHistory.Add(transaction);
                Console.WriteLine("Transaction added to the history successfully.");
            }
            else
            {
                Console.WriteLine("Account not found. Please enter a valid account number.");
            }
        }

        public static string GenerateTransactionID(string bankID, string accountID)
        {
            string transactionID = "TXN" + bankID + accountID + DateTime.Now.ToString("yyyyMMdd");
            return transactionID;
        }
    }

}


