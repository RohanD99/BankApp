using BankApplication.Common;
using BankApplication.Models;
using BankApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using static BankApplication.Common.Enums;

namespace BankApplication.Views
{
    internal class UserView
    {
        private UserService userService = new UserService();
        public void UserAccountMenu(Account account)
        {
            UserAccountOption option;
            do
            {
                List<string> userAccountMenuOptions = Enum.GetNames(typeof(UserAccountOption)).ToList();
                Utility.GenerateOptions(userAccountMenuOptions);

                option = (UserAccountOption)Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case UserAccountOption.DepositAmount:
                        Console.Write("Enter the amount to deposit: ");
                        decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                        Response depositResponse = userService.Deposit(account, depositAmount);
                        Console.WriteLine(depositResponse.Message);
                        break;

                    case UserAccountOption.WithdrawAmount:
                        Console.Write("Enter the amount to withdraw: ");
                        decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                        Response withdrawResponse = userService.Withdraw(account, withdrawAmount);
                        Console.WriteLine(withdrawResponse.Message);
                        break;

                    case UserAccountOption.TransferFunds:
                        Console.Write("Enter the destination account number: ");
                        string destinationAccountNumber = Console.ReadLine();
                        Account destinationAccount = DataStorage.Accounts.FirstOrDefault(a => a.AccountNumber == destinationAccountNumber);

                        if (destinationAccount == null)
                        {
                            Console.WriteLine("Destination account not found. Transfer failed.");
                            break;
                        }

                        Console.Write("Enter the amount to transfer: ");
                        decimal transferAmount = Convert.ToDecimal(Console.ReadLine());

                        Response transferResponse = userService.TransferFunds(account, destinationAccount, transferAmount);
                        break;

                    case UserAccountOption.CheckBalance:
                        Response balanceResponse = userService.CheckBalance(account);
                        Console.WriteLine($"Your account balance: {balanceResponse.Data}");
                        break;

                    case UserAccountOption.ViewTransactionHistory:
                        Response transactionHistoryResponse = userService.ViewTransactionHistory(account);
                        Console.WriteLine(transactionHistoryResponse.Message);
                        Console.WriteLine(transactionHistoryResponse.Data);
                        break;

                    case UserAccountOption.GoBackToStart:
                        break;

                    default:
                        Console.WriteLine("Please enter a valid input.");
                        break;
                }
            } while (option != UserAccountOption.GoBackToStart);
        }
    }
}

