using BankApp.SetupNewBank;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApp.BankStaff
{
    internal class AccountDetails
    {
        internal enum AccountType
        {
            Savings,
            Salary
        }
        internal class Account
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string AccountNumber { get; set; }

            public AccountType Type { get; set; }
            public NewBank Bank { get; set; }
            public decimal AccountBalance { get; set; }
            public List<string> TransactionHistory { get; set; }
        }

        public static List<Account> accounts = new List<Account>();

        public static void CreateNewAccount()
        {
            Console.WriteLine("Enter account holder's username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter account holder's password:");
            string password = Console.ReadLine();

            string accountNumber = GenerateAccountNumber();

            Console.WriteLine("Enter account type (1 for Savings, 2 for Salary):");
            int accountTypeChoice = Convert.ToInt32(Console.ReadLine());

            AccountType accountType = (AccountType)accountTypeChoice;

            Console.WriteLine("Select a bank from the list:");
            BankManager.DisplayBanks();

            Console.WriteLine("Enter the bank ID:");
            string bankId = Console.ReadLine();

            NewBank selectedBank = BankManager.GetBankById(bankId);
            if (selectedBank == null)
            {
                Console.WriteLine("Bank not found.");
                return;
            }

            Account newAccount = new Account
            {
                Username = username,
                Password = password,
                AccountNumber = accountNumber,
                AccountBalance = 0,
                TransactionHistory = new List<string>(),
                Type = accountType,
                Bank = selectedBank
            };

            accounts.Add(newAccount);

            Console.WriteLine("Account created successfully.");
            Console.WriteLine("Account Number: " + accountNumber);
        }

        public static void UpdateAccount()
        {
            Console.WriteLine("Enter the account number:");
            string accountNumber = Console.ReadLine();

            Account account = GetAccountByNumber(accountNumber);

            if (account != null)
            {
                Console.WriteLine("Enter new username:");
                string newUsername = Console.ReadLine();

                Console.WriteLine("Enter new password:");
                string newPassword = Console.ReadLine();

                account.Username = newUsername;
                account.Password = newPassword;

                Console.WriteLine("Account updated successfully.");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public static void DeleteAccount()
        {
            Console.WriteLine("Enter the account number:");
            string accountNumber = Console.ReadLine();

            Account account = GetAccountByNumber(accountNumber);

            if (account != null)
            {
                accounts.Remove(account);
                Console.WriteLine("Account deleted successfully.");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public static void ShowAllAccounts()
        {
            if (accounts.Count > 0)
            {
                Console.WriteLine("List of User Accounts:");
                foreach (Account account in accounts)
                {
                    if (!IsBankStaffAccount(account))
                    {
                        Console.WriteLine("Account Number: " + account.AccountNumber);
                        Console.WriteLine("Username: " + account.Username);
                        Console.WriteLine("Password: " + account.Password);
                        Console.WriteLine("Account Type: " + account.Type);
                        Console.WriteLine("Account Balance: " + account.AccountBalance);
                        Console.WriteLine("Bank name: " + account.Bank.bankName);
                        Console.WriteLine("-------------------------------------------");
                    }
                }
            }
            else
            {
                Console.WriteLine("No accounts found.");
            }
        }

        public static void ViewAccountTransactionHistory(string accountNumber)
        {
            Account account = GetAccountByNumber(accountNumber);

            if (account != null)
            {
                Console.WriteLine("Transaction History for Account Number: " + account.AccountNumber);
                foreach (string transaction in account.TransactionHistory)
                {
                    Console.WriteLine(transaction);
                }
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        private static string GenerateAccountNumber()
        {
            Random random = new Random();
            return random.Next(100000000, 999999999).ToString();
        }

        public static Account GetAccountByNumber(string accountNumber)
        {
            return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        public static void AddStaffAccount(string username, string password)
        {
            Account newAccount = new Account
            {
                Username = username,
                Password = password,
                AccountNumber = string.Empty,
                AccountBalance = 0,
                TransactionHistory = new List<string>()
            };

            accounts.Add(newAccount);
        }


        private static bool IsBankStaffAccount(Account account)
        {
            return account.Username.Trim().ToLower().StartsWith("staff");
        }

        public static bool ValidateBankStaffCredentials(string username, string password)
        {
            return accounts.Any(a => a.Username == username && a.Password == password);
        }
    }

}
