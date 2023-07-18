using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.BankStaff;

namespace BankApp.BankStaff
{
    internal class StaffLogin
    { 
        public class LoginAsBankStaff
        {
            
            public static void BankStaff()
            {
                Console.WriteLine("Login as Bank Staff");
                Console.WriteLine("Enter your username:");
                string username = Console.ReadLine();

                Console.WriteLine("Enter your password:");
                string password = Console.ReadLine();
                if (ValidateCredentials(username, password))
                {
                    Console.WriteLine("Login successful. Welcome, " + username + "!");
                    Console.WriteLine("Select an action:");
                    Console.WriteLine("1. Create new account and provide username and password to account holder");
                    Console.WriteLine("2. Update account");
                    Console.WriteLine("3. Delete account");
                    Console.WriteLine("4. Show all accounts");
                    Console.WriteLine("5. Add new accepted currency with exchange rate");
                    Console.WriteLine("6. Add service charge for same bank account (RTGS and IMPS)");
                    Console.WriteLine("7. Add service charge for other bank account (RTGS and IMPS)");
                    Console.WriteLine("8. View account transaction history");
                    Console.WriteLine();

                    int action = int.Parse(Console.ReadLine());
                    PerformBankStaffAction(action);
                }
                else
                {
                    Console.WriteLine("Invalid username or password. Please try again.");
                }
            }
        }

        public static bool ValidateCredentials(string username, string password)
        {
            return username == "staff" && password == "password";
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
                    Console.WriteLine("Update Account ");
                    AccountDetails.UpdateAccount();
                    break;
                case 3:
                    Console.WriteLine("Delete Account ");
                    AccountDetails.DeleteAccount();
                    break;
                case 4:
                    Console.WriteLine("Show all Accounts ");
                    AccountDetails.ShowAllAccounts();
                    break;
                case 5:
                    Console.WriteLine("Add New Accepted Currency");
                    CurrencyType.AddAcceptedCurrency();
                    break;
                case 6:
                    Console.WriteLine(" Add Service Charge for Same Bank Account");
                    ServiceCharge.SetServiceChargeSameBank();
                    break;
                case 7:
                    Console.WriteLine(" Add Service Charge for Other Bank Account");
                    ServiceCharge.SetServiceChargeOtherBank();
                    break;
                case 8:
                    Console.WriteLine(" View Account Transaction History");
                    //AccountDetails.ViewAccountTransactionHistory();
                    break;
                default:
                    Console.WriteLine("Invalid action. Please try again.");
                    break;
            }
        }
    }

}

