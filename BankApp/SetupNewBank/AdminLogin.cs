using BankApp.BankStaff;
using System;
using static BankApp.SetupNewBank.NewBank;

namespace BankApp.SetupNewBank
{
    internal class AdminLogin
    {
        private static bool isAdminLoggedIn = false;
        private static NewBank newBank;

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
                int attempts = 3;

                while (attempts > 0)
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
                        break; 
                    }
                    else
                    {
                        attempts--;
                        Console.WriteLine($"Invalid admin credentials. {attempts} attempts left.");
                    }
                }

                if (attempts == 0)
                {
                    Console.WriteLine("Login failed. You've reached the maximum number of attempts.");
                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine("\nBank Management Menu");
                        Console.WriteLine("---------------------");
                        Console.WriteLine("1. Display all banks");
                        Console.WriteLine("2. Add new bank");
                        Console.WriteLine("3. Hire a staff");
                        Console.WriteLine("4. Show All staff members");
                        Console.WriteLine("5. Exit");
                        Console.Write("Enter your choice: ");

                        int choice = Convert.ToInt32(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                BankManager.DisplayBanks();
                                break;
                            case 2:
                                newBank = new NewBank();
                                BankSetup.SetupNewBank(newBank);
                                break;
                            case 3:
                                HireStaff();
                                break;
                            case 4:
                                BankManager.DisplayStaffMembers();
                                break;
                            case 5:
                                Console.WriteLine("Exiting...");
                                return;
                            default:
                                Console.WriteLine("Invalid choice. Please try again.");
                                break;
                        }
                    }
                }
            }

            private static void HireStaff()
            {
                Console.WriteLine("Enter staff username:");
                string username = Console.ReadLine();

                Console.WriteLine("Enter staff password:");
                string password = Console.ReadLine();

                AccountDetails.AddStaffAccount(username, password);

                Console.WriteLine("Staff hired successfully.");

            }
        }
    }
    }

