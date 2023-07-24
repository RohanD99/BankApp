using BankApp.SetupNewBank;
using System;
using static BankApp.AccountHolder.UserLogin;
using static BankApp.BankStaff.StaffLogin;
using static BankApp.SetupNewBank.AdminLogin;
using static BankApp.SetupNewBank.NewBank;

namespace BankApp
{
    internal class Program
    {
        private static NewBank newBank;
        public static void Main()
        {
            int option;
            do
            {
                Console.WriteLine("_______///Welcome to Bank Management System\\\\\\________\nSelect an option:\n1. Setup new Bank\n2. Login as Account Holder\n3. Login as Bank Staff\n4. Exit\n");

                string input = Console.ReadLine();
                if (int.TryParse(input, out option))              //converts string to int & out holds the result of conversion
                {
                    switch (option)
                    {
                        case 1:
                            newBank = new NewBank();
                            BankSetup.SetupNewBank(newBank);
                            AdminVerification.AdminMenu();
                            break;
                        case 2:
                            LoginAsAccountHolder.AccountHolder();
                            break;
                        case 3:
                            LoginAsBankStaff.BankStaff();
                            break;
                        case 4:
                            Console.WriteLine("Thank you for Visiting...");
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid numeric option.");
                }

                Console.WriteLine();
            } while (option != 4);
        }
    }
}
