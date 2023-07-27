using BankApplication.Common;
using BankApplication.Models;
using System.Linq;

namespace BankApplication.Services
{
    internal class EmployeeService
    {
        Bank bank = new Bank();
        Response response = new Response();
        UserService userService = new UserService();
        public Response CreateEmployee(Employee employee)
        {
            try
            {
                employee.Id = Utility.GenerateEmployeeID();
                DataStorage.Employees.Add(employee);
                response.IsSuccess = true;
                response.Message = "Employee created successfully.";
                response.Data = employee.Id;
            }
            catch
            {
                response.IsSuccess = false;
                response.Message = "Employee creation failed.";
            }
            return response;
        }

        public Response DeleteEmployee(Employee employee)
        {
            try
            {
                DataStorage.Employees.Remove(employee);
                response.IsSuccess = true;
                response.Message = "Employee deleted successfully.";
                response.Data = employee.Id;
            }
            catch
            {
                response.IsSuccess = false;
                response.Message = "Employee not deleted";
            }
            return response;
        }

        public void UpdateAccount()
        {
            response.Message = "Updating an account:";

            string accountNumberToUpdate = Utility.ReadStringInput("Enter the account number to update", true);

            Account accountToUpdate = DataStorage.Accounts.FirstOrDefault(acc => acc.AccountNumber == accountNumberToUpdate);

            if (accountToUpdate != null)
            {
                response.Message = "Current Account Details:";
                response.Message = $"Account Number: {accountToUpdate.AccountNumber}";
                response.Message = $"Account Holder Name: {accountToUpdate.AccountHolderName}";
                response.Message = $"Balance: {accountToUpdate.Balance}";

                string newAccountHolderName = Utility.ReadStringInput("Enter the new account holder name", true);
                string newAccountType = Utility.ReadStringInput("Change account type", true);

                accountToUpdate.AccountHolderName = newAccountHolderName;
                accountToUpdate.AccountType = newAccountType;

                response.Message = "Account updated successfully.";
            }
            else
            {
                response.Message = "Account not found. Please enter a valid account number.";
            }
        }

        public void ShowAllAccounts()
        {
            response.Message = "Listing all accounts:";
            foreach (var account in DataStorage.Accounts)
            {
                response.Message = $"Account Number: {account.AccountNumber}";
                response.Message = $"Account Holder Name: {account.AccountHolderName}";
                response.Message = $"Balance: {account.Balance}";
                response.Message = $"Account type: {account.AccountType}";
                response.Message = "----------------------------";
            }
        }

        public void AddServiceChargeForSameBankAccount(float rtgsCharge, float impsCharge)
        {
            response.Message = "Adding service charge for same bank account (RTGS and IMPS):";
            float previousRTGSCharge = bank.RTGSforSameBank;
            float previousIMPSCharge = bank.IMPSforSameBank;

            bank.RTGSforSameBank = rtgsCharge;
            bank.IMPSforSameBank = impsCharge;
            response.Message = "Service charges updated successfully.";
        }

        public void AddServiceChargeForOtherBankAccount(float rtgsCharge, float impsCharge)
        {
            response.Message = "Adding service charge for other bank account (RTGS and IMPS):";
            float previousRTGSCharge = bank.RTGSforOtherBank;
            float previousIMPSCharge = bank.IMPSforOtherBank;

            bank.RTGSforOtherBank = rtgsCharge;
            bank.IMPSforOtherBank = impsCharge;
            response.Message = "Service charges updated successfully.";
        }

        public void ViewAccountTransactionHistory(Account account)
        {
            response.Message = $"Viewing transaction history for account number: {account.AccountNumber}";
            userService.ViewTransactionHistory(account);
        }

        public Response RevertTransaction(string transactionId)
        {
            Response response = new Response();
            Transaction transactionToRevert = DataStorage.Transactions.FirstOrDefault(t => t.TransactionId == transactionId);

            if (transactionToRevert != null && !transactionToRevert.IsReverted)
            {
                Account account = DataStorage.Accounts.FirstOrDefault(a => a.AccountNumber == transactionToRevert.AccountNumber);
                if (account != null)
                {
                    account.Balance += transactionToRevert.Amount;
                    transactionToRevert.IsReverted = true;
                    response.IsSuccess = true;
                    response.Message = "Transaction reverted successfully.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Account not found. Unable to revert the transaction.";
                }
            }
            return response;
        }
    }
}

