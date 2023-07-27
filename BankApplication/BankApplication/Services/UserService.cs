using BankApplication.Common;
using BankApplication.Models;
using System;
using System.Linq;
using System.Text;

namespace BankApplication.Services
{
    internal class UserService
    {
        Response response = new Response();
        public Response CreateUser(User user) 
        {           
            try
            {
                user.Id = Utility.GenerateAccountNumber();               
                DataStorage.Users.Add(user);
                response.IsSuccess = true;
                response.Message = "User added successfully.";
                response.Data = user.Id;
            }
            catch
            {
                response.IsSuccess = false;
                response.Message = "User creation failed.";
            }
            return response;
        }

        public Response Deposit(Account account, decimal amount)
        {
            Response response = new Response();
            if (amount <= 0)
            {
                response.IsSuccess = false;
                response.Message = "Invalid amount. Deposit amount should be greater than zero.";
                return response;
            }

            account.Balance += amount;
                                                                                 
            Transaction transaction = new Transaction                                                 // Create a new transaction to record the deposit
            {
                TransactionId = Utility.GenerateTransactionID(),
                AccountNumber = account.AccountNumber,
                TransactionType = TransactionType.Deposit,
                Amount = amount,
                TransactionDate = DateTime.Now
            };

            DataStorage.Transactions.Add(transaction);

            response.IsSuccess = true;
            response.Message = "Deposit successful.";
            response.Data = account.Balance.ToString();
            return response;
        }

        public Response Withdraw(Account account, decimal amount)
        {
            Response response = new Response();
            if (amount <= 0)
            {
                response.IsSuccess = false;
                response.Message = "Invalid amount. Withdrawal amount should be greater than zero.";
                return response;
            }

            if (amount > account.Balance)
            {
                response.IsSuccess = false;
                response.Message = "Insufficient balance. You cannot withdraw more than the available balance.";
                return response;
            }

            account.Balance -= amount;
          
            Transaction transaction = new Transaction                                                // Create a new transaction to record the withdrawal
            {
                TransactionId = Utility.GenerateTransactionID(),
                AccountNumber = account.AccountNumber,
                TransactionType = TransactionType.Withdrawal,
                Amount = amount,
                TransactionDate = DateTime.Now,
            };

            DataStorage.Transactions.Add(transaction);

            response.IsSuccess = true;
            response.Message = "Withdrawal successful.";
            response.Data = account.Balance.ToString();
            return response;
        }


        public Response TransferFunds(Account sourceAccount, Account destinationAccount, decimal amount)
        {
            if (amount <= 0)
            {
                response.IsSuccess = false;
                response.Message = "Invalid amount. Transfer amount should be greater than zero.";
                return response;
            }

            if (amount > sourceAccount.Balance)
            {
                response.IsSuccess = false;
                response.Message = "Insufficient balance. You cannot transfer more than the available balance.";
                return response;
            }

            sourceAccount.Balance -= amount;
            destinationAccount.Balance += amount;

            Transaction sourceTransaction = new Transaction
            {
                TransactionId = Utility.GenerateTransactionID(),
                AccountNumber = sourceAccount.AccountNumber,
                TransactionType = TransactionType.FundTransfer,
                Amount = -amount, 
                TransactionDate = DateTime.Now
            };

           
            Transaction destinationTransaction = new Transaction
            {
                TransactionId = Utility.GenerateTransactionID(),
                AccountNumber = destinationAccount.AccountNumber,
                TransactionType = TransactionType.FundTransfer,
                Amount = amount,
                TransactionDate = DateTime.Now
            };

            DataStorage.Transactions.Add(sourceTransaction);
            DataStorage.Transactions.Add(destinationTransaction);

            response.IsSuccess = true;
            response.Message = "Funds transferred successfully.";
            return response;
        }

        public Response CheckBalance(Account account)
        {
            response.IsSuccess = true;
            response.Message = "Account balance check successful.";
            response.Data = account.Balance.ToString();
            return response;
        }

        public Response ViewTransactionHistory(Account account)
        {
            Response response = new Response();
            var transactions = DataStorage.Transactions
                .Where(t => t.AccountNumber == account.AccountNumber)
                .ToList();

            if (transactions.Any())
            {
                StringBuilder sb = new StringBuilder();
                foreach (var transaction in transactions)
                {
                    sb.AppendLine($"Transaction ID: {transaction.TransactionId}");
                    sb.AppendLine($"Transaction Type: {transaction.TransactionType}");
                    sb.AppendLine($"Transaction Amount: {transaction.Amount}");
                    sb.AppendLine($"Transaction Date: {transaction.TransactionDate}");
                    sb.AppendLine("----------------------------");
                }

                response.IsSuccess = true;
                response.Message = "Transaction history retrieved successfully.";
                response.Data = sb.ToString();
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "No transaction history found for this account.";
                response.Data = string.Empty;
            }

            return response;
        }      
    }
}

    


