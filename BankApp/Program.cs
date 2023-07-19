using BankApp.SetupNewBank;
using System;
using static BankApp.AccountHolder.UserLogin;
using static BankApp.BankStaff.StaffLogin;
using static BankApp.SetupNewBank.AdminLogin;
using static BankApp.SetupNewBank.NewBank;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("_______///Welcome\\\\\\________");
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Setup new Bank");
                Console.WriteLine("2. Login as Account Holder");
                Console.WriteLine("3. Login as Bank Staff");
                Console.WriteLine("4. Exit");
                Console.WriteLine();

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AdminVerification.Verification();
                        break;
                    case 2:
                        LoginAsAccountHolder.AccountHolder();
                        break;
                    case 3:
                        LoginAsBankStaff.BankStaff();
                        break;
                    case 4:
                        Console.WriteLine("Thankyou for Visiting...");
                        Environment.Exit(0);                       
                        return;
                        //break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
           
        }
    }
    }

