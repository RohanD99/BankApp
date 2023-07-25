using BankApp.SetupNewBank;
using System;
using static BankApp.AccountHolder.UserLogin;
using static BankApp.BankStaff.Staff;
using static BankApp.SetupNewBank.Admin;
using static BankApp.SetupNewBank.Bank;

namespace BankApp
{
    internal class Program
    { 
        public static void Main()
        {
            int option;
            do
            {
                Console.WriteLine("_______///Welcome to Bank Management System\\\\\\________\nSelect an option:\n1. Setup new Bank\n2. Login as Account Holder\n3. Login as Bank Staff\n4. Exit\n");

                string input = Console.ReadLine();
                if (int.TryParse(input, out option))
                {
                    switch (option)
                    {
                        case 1:
                            BankSetup.SetupNewBank(new Bank());
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
