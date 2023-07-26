using BankApp.SetupNewBank;
using System;
using static BankApp.AccountHolder.UserLoginService;
using static BankApp.BankStaff.StaffService;
using static BankApp.Constants;
using static BankApp.SetupNewBank.AdminServices;
using static BankApp.SetupNewBank.BankService;

namespace BankApp
{
    internal class Program
    {
        public static void Main()
        {
            MainMenuOption option;
            do
            {
                Console.WriteLine("\nSelect an option:\n1. Setup new Bank\n2. Login as Account Holder\n3. Login as Bank Staff\n4. Exit\n");

                string input = Console.ReadLine();
                if (Enum.TryParse(input, out option))
                {
                    switch (option)
                    {
                        case MainMenuOption.SetupNewBank:
                            BankSetup.SetupNewBank(new BankService());
                            AdminVerification.AdminMenu();
                            break;
                        case MainMenuOption.LoginAsAccountHolder:
                            LoginAsAccountHolder.AccountHolder();
                            break;
                        case MainMenuOption.LoginAsBankStaff:
                            LoginAsBankStaff.BankStaff();
                            break;
                        case MainMenuOption.Exit:
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
            } while (option != MainMenuOption.Exit);
        }
    }
}
