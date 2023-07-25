using BankApp.Views;
using System;

namespace BankApp.BankStaff
{
    internal class StaffService
    {
        private static bool isBankStaffLoggedIn = false;
        public class LoginAsBankStaff
        {          
            public static void BankStaff()
            {
                if (isBankStaffLoggedIn)
                {
                    DisplayBankStaffOptions();
                }
                else
                {
                    BankView.DisplayAsBankStaff();
                    int attempts = 3;
                    while (attempts > 0)
                    {
                        string username = AccountView.GetUsername();
                        string password = AccountView.GetPassword();

                       isBankStaffLoggedIn = true;
                        AdminView.LoginSuccessful(username);
                        DisplayBankStaffOptions();
                       break;                        
                    }

                    if (attempts == 0)
                    {
                        AdminView.DisplayLoginFailed();
                    }
                }
            }

            public static void DisplayBankStaffOptions()
            {
                while (true)
                {
                    BankView.DisplayStaffOperations();
                    int action = GetUserChoice();
                    if (action == 9)
                    {
                        AdminView.DisplayBackToStart();
                        isBankStaffLoggedIn = false;
                        break;
                    }
                    PerformBankStaffAction(action);
                }
            }

            private static bool ValidateBankStaffCredentials(string username, string password)
            {
                return AccountServices.ValidateBankStaffCredentials(username, password);
            }

            private static int GetUserChoice()
            {
                int action;
                while (!int.TryParse(Console.ReadLine(), out action))
                {
                    AdminView.DisplayInvalidInput();
                }
                return action;
            }

            public static void PerformBankStaffAction(int action)
            {
                switch (action)
                {
                    case 1:
                        AccountView.CreateNewAccount();
                        AccountServices.CreateNewAccount();
                        break;
                    case 2:
                        AccountView.UpdateAccount();
                        AccountServices.UpdateAccount();
                        break;
                    case 3:
                        AccountView.DeleteAccount();    
                        AccountServices.DeleteAccount();
                        break;
                    case 4:
                        AccountView.ShowAllAccounts();
                        AccountServices.ShowAllAccounts();
                        break;
                    case 5:
                        BankView.DisplayAcceptedCurrency();
                        CurrencyServices.AddAcceptedCurrency();
                        break;
                    case 6:
                        BankView.DisplayServiceChargeForSameBank();
                        ChargesService.SetServiceChargeSameBank();
                        break;
                    case 7:
                        BankView.DisplayServiceChargeForOtherBank();
                        ChargesService.SetServiceChargeOtherBank();
                        break;
                    case 8:
                        BankView.ViewTransactionHistory();
                        AccountView.GetAccountNumberByUser();
                        string accountNumber = Console.ReadLine();
                        AccountServices.ViewAccountTransactionHistory(accountNumber);
                        break;
                    case 9:
                        AdminView.DisplayBackToStart();
                        isBankStaffLoggedIn = false;
                        break;
                    default:
                        AdminView.DisplayInvalidChoice();
                        break;
                }
            }
        }
    }
}
