using System;
using BankApp.AccountHolder;

namespace BankApp.BankStaff
{
    internal class StaffLogin
    {
        private static bool isBankStaffLoggedIn = false;

        public class LoginAsBankStaff
        {
           
            public static void BankStaff()
            {
                if (isBankStaffLoggedIn)
                {
                    Console.WriteLine("You are already logged in as Bank Staff.");
                    DisplayBankStaffOptions();
                }
                else
                {
                    Console.WriteLine("Login as Bank Staff");
                    int attempts = 3;
                    while (attempts > 0)
                    {
                        Console.WriteLine("Enter your username:");
                        string username = Console.ReadLine();

                        Console.WriteLine("Enter your password:");
                        string password = Console.ReadLine();

                        if (ValidateBankStaffCredentials(username, password))
                        {
                            isBankStaffLoggedIn = true;
                            Console.WriteLine("Login successful. Welcome, " + username + "!");
                            DisplayBankStaffOptions();
                            break;
                        }
                        else
                        {
                            attempts--;
                            Console.WriteLine($"Invalid username or password. {attempts} attempts left.");
                        }
                    }

                    if (attempts == 0)
                    {
                        Console.WriteLine("Login failed. You've reached the maximum number of attempts.");
                    }
                }
            }

            private static void DisplayBankStaffOptions()
            {
                while (true)
                {
                    Console.WriteLine("Select an action:");
                    Console.WriteLine("1. Create new account and provide username and password to account holder");
                    Console.WriteLine("2. Update account");
                    Console.WriteLine("3. Delete account");
                    Console.WriteLine("4. Show all accounts");
                    Console.WriteLine("5. Add new accepted currency with exchange rate");
                    Console.WriteLine("6. Add service charge for same bank account (RTGS and IMPS)");
                    Console.WriteLine("7. Add service charge for other bank account (RTGS and IMPS)");
                    Console.WriteLine("8. View account transaction history");
                    Console.WriteLine("9. Go back to start");
                    Console.WriteLine();

                    int action = GetUserChoice();
                    if (action == 9)
                    {
                        Console.WriteLine("Going back to start...");
                        isBankStaffLoggedIn = false;
                        break;
                    }
                    PerformBankStaffAction(action);
                }
            }

            private static bool ValidateBankStaffCredentials(string username, string password)
            {
                return AccountDetails.ValidateBankStaffCredentials(username, password);
            }

            private static int GetUserChoice()
            {
                int action;
                while (!int.TryParse(Console.ReadLine(), out action))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                return action;
            }

            public static void PerformBankStaffAction(int action)
            {
                switch (action)
                {
                    case 1:
                        Console.WriteLine("Create New Account");
                        AccountDetails.CreateNewAccount();
                        break;
                    case 2:
                        Console.WriteLine("Update Account");
                        AccountDetails.UpdateAccount();
                        break;
                    case 3:
                        Console.WriteLine("Delete Account");
                        AccountDetails.DeleteAccount();
                        break;
                    case 4:
                        Console.WriteLine("Show all Accounts");
                        AccountDetails.ShowAllAccounts();
                        //ViewAccountBalance();
                        break;
                    case 5:
                        Console.WriteLine("Add New Accepted Currency");
                        CurrencyType.AddAcceptedCurrency();
                        break;
                    case 6:
                        Console.WriteLine("Add Service Charge for Same Bank Account");
                        ServiceCharge.SetServiceChargeSameBank();
                        break;
                    case 7:
                        Console.WriteLine("Add Service Charge for Other Bank Account");
                        ServiceCharge.SetServiceChargeOtherBank();
                        break;
                    case 8:
                        Console.WriteLine("View Account Transaction History");
                        Console.WriteLine("Enter the account number:");
                        string accountNumber = Console.ReadLine();
                        AccountDetails.ViewAccountTransactionHistory(accountNumber);
                        //ViewAccountBalance();
                        break;
                    case 9:
                        Console.WriteLine("Going back to start...");
                        isBankStaffLoggedIn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid action. Please try again.");
                        break;
                }
            }
        }
    }
}
