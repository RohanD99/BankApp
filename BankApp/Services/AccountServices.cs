using BankApp.SetupNewBank;
using System;
using System.Collections.Generic;
using System.Linq;
using BankApp.Models;
using BankApp.AccountHolder;
using BankApp.Views;

namespace BankApp.BankStaff
{
    internal class AccountServices
    {
        public static List<Account> accounts = new List<Account>();
        public static void CreateNewAccount()
        {
            if (BankManagerService.banks.Count == 0)
            {
                AccountView.DisplayNoBanksSetUp();
                return;
            }

            string username = AccountView.GetUsername();
            string password = AccountView.GetPassword();

            string accountNumber = GenerateAccountNumber();

            int accountTypeChoice = AccountView.GetAccountTypeChoiceFromUser();

            AccountType accountType = (AccountType)accountTypeChoice;

            BankManagerService.DisplayBanks();                      //selecting bank from list

            string bankId = AccountView.GetBankIdFromUser();

            BankService selectedBank = BankManagerService.GetBankById(bankId);
            if (selectedBank == null)
            {
                AccountView.DisplayBankNotFound();
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
                Bank = selectedBank,
                LinkedAccountNumber = string.Empty
            };

            accounts.Add(newAccount);

            AccountView.DisplayAccountCreatedSuccessfully(accountNumber);
        }
        public static Account GetAccountByUsername(string username)
        {
            return accounts.FirstOrDefault(a => a.Username == username);
        }

        public static void UpdateAccount()
        {
            string accountNumber = AccountView.GetAccountNumber();

            Account account = GetAccountByNumber(accountNumber);

            if (account != null)
            {
                string newUsername = AccountView.GetUpdatedUsername();
                string newPassword = AccountView.GetUpdatedPassword();

                int accountTypeChoice = AccountView.GetAccountTypeChoiceFromUser();

                AccountType accountType = (AccountType)accountTypeChoice;
                account.Type = accountType;

                account.Username = newUsername;
                account.Password = newPassword;
                AccountView.DisplayAccountUpdatedSuccessfully();
            }
            else
            {
                AccountView.DisplayAccountNotFound();
            }
        }

        public static void DeleteAccount()
        {
            string accountNumber = AccountView.GetAccountNumber();
            Account account = GetAccountByNumber(accountNumber);

            if (account != null)
            {
                accounts.Remove(account);
                AccountView.DisplayAccountDeletedSuccessfully();
            }
            else
            {
                AccountView.DisplayAccountNotFound();
            }
        }

        public static void ShowAllAccounts()
        {
            UserAccountService userAccount = new UserAccountService();
            if (accounts.Count > 0)
            {
                foreach (Account account in accounts)
                {
                    if (!IsBankStaffAccount(account))
                    {
                        AccountView.DisplayAllAccounts(account);
                    }
                }
            }
            else
            {
                AccountView.DisplayAccountNotFound();
            }
        }
    

        public static void ViewAccountTransactionHistory(string accountNumber)
        {
            Account account = GetAccountByNumber(accountNumber);

            if (account != null)
            {
                foreach (string transaction in account.TransactionHistory)
                {
                    Console.WriteLine(transaction);
                }
            }
            else
            {
                AccountView.DisplayAccountNotFound();
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
                TransactionHistory = new List<string>(),
                Bank = null
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