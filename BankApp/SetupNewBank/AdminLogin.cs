using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BankApp.SetupNewBank.NewBank;

namespace BankApp.SetupNewBank
{
    internal class AdminLogin
    {
        private static bool isAdminLoggedIn = false;

        public static void RunAdminLogin()
        {
            while (true)
            {
                Console.WriteLine("Admin Login");
                Console.WriteLine("------------");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Exit");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AdminVerification.Verification();
                        break;
                    case 2:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public class AdminVerification
        {
            public static void Verification()
            {
                Console.WriteLine("Enter admin username:");
                string adminUsername = Console.ReadLine();

                Console.WriteLine("Enter admin password:");
                string adminPassword = Console.ReadLine();

                // Check if admin credentials are valid
                if (adminUsername == "admin" && adminPassword == "password")
                {
                    isAdminLoggedIn = true;
                    Console.WriteLine("Admin login successful.");

                    while (true)
                    {
                        Console.WriteLine("\nBank Management Menu");
                        Console.WriteLine("---------------------");
                        Console.WriteLine("1. Display all banks");
                        Console.WriteLine("2. Add new bank");
                        Console.WriteLine("3. Exit");
                        Console.Write("Enter your choice: ");

                        int choice = Convert.ToInt32(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                BankManager.DisplayBanks();
                                break;
                            case 2:
                                BankSetup.SetupNewBank();
                                break;
                            case 3:
                                Console.WriteLine("Exiting...");
                                return;
                            default:
                                Console.WriteLine("Invalid choice. Please try again.");
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid admin credentials. Login failed.");
                }
            }
        }
    }
}
