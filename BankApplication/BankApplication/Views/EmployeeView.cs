using static BankApplication.Common.Enums;
using System.Collections.Generic;
using System;
using BankApplication.Common;
using System.Linq;
using BankApplication.Services;
using BankApplication.Models;

namespace BankApplication.Views
{
    public class EmployeeView
    {
        static EmployeeService employeeService = new EmployeeService();
        static UserService userservice = new UserService();
        BankView bankview = new BankView();
        public static void BankStaffMenu()
        {
           
            BankStaffOption option;
            do
            {
                List<string> bankStaffMenuOptions = Enum.GetNames(typeof(BankStaffOption)).ToList();
                Utility.GenerateOptions(bankStaffMenuOptions);

                option = (BankStaffOption)Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case BankStaffOption.CreateNewAccountAndProvideUsernameAndPasswordToAccountHolder:
                        Console.Write("Enter First Name: ");
                        string firstName = Console.ReadLine();

                        Console.Write("Enter Last Name: ");
                        string lastName = Console.ReadLine();
                        User newUser = new User();                        
                        Response createUserResponse = userservice.CreateUser(newUser);
                        if (createUserResponse.IsSuccess)
                        {
                            Console.WriteLine(createUserResponse.Message);
                            Console.WriteLine("User ID: " + createUserResponse.Data);
                        }
                        else
                        {
                            Console.WriteLine(createUserResponse.Message);
                        }
                        break;
                    case BankStaffOption.UpdateAccount:
                        employeeService.UpdateAccount();
                        break;
                    case BankStaffOption.DeleteAccount:
                        Employee employee = new Employee();
                        employeeService.DeleteEmployee(employee);
                        break;
                    case BankStaffOption.ShowAllAccounts:
                        employeeService.ShowAllAccounts();
                        break;
                    case BankStaffOption.AddNewAcceptedCurrencyWithExchangeRate:
                        //employeeService.();
                        break;
                    case BankStaffOption.AddServiceChargeForSameBankAccount:
                        Console.Write("Enter RTGS charge: ");
                        float rtgsCharge = float.Parse(Console.ReadLine());

                        Console.Write("Enter IMPS charge: ");
                        float impsCharge = float.Parse(Console.ReadLine());

                        employeeService.AddServiceChargeForSameBankAccount(rtgsCharge, impsCharge);
                        break;
                    case BankStaffOption.AddServiceChargeForOtherBankAccount:
                        Console.Write("Enter RTGS charge: ");
                        float rtgsChargeOther = float.Parse(Console.ReadLine());

                        Console.Write("Enter IMPS charge: ");
                        float impsChargeOther = float.Parse(Console.ReadLine());

                        employeeService.AddServiceChargeForOtherBankAccount(rtgsChargeOther, impsChargeOther);
                        break;
                    case BankStaffOption.ViewAccountTransactionHistory:
                        Console.Write("Enter the account number: ");
                        string accountNumber = Console.ReadLine();
                        Account account = DataStorage.Accounts.FirstOrDefault(acc => acc.AccountNumber == accountNumber);
                        if (account != null)
                        {
                            employeeService.ViewAccountTransactionHistory(account);
                        }
                        else
                        {
                            Console.WriteLine("Account not found. Please enter a valid account number.");
                        }
                        break;
                    case BankStaffOption.RevertAnyTransaction:
                        Console.Write("Enter the transaction ID: ");
                        string transactionId = Console.ReadLine();
                        Response revertResponse = employeeService.RevertTransaction(transactionId);
                        Console.WriteLine(revertResponse.Message);
                        break;
                    case BankStaffOption.GoBackToStart:
                        // Implement go back to start logic
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input.");
                        break;
                }
            } while (option != BankStaffOption.GoBackToStart);
        }
    }
}







