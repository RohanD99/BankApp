using BankApp.BankStaff;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BankApp.SetupNewBank
{
    internal class AdminLogin
    {
        private static bool isAdminLoggedIn = false;
        private static bool isAdminAdded = false;

        // Lists to store admin and staff credentials
        private static List<string> adminUsernames = new List<string>();
        private static List<string> adminPasswords = new List<string>();
        private static List<string> staffUsernames = new List<string>();
        private static List<string> staffPasswords = new List<string>();

        public class AdminVerification
        {
            public static void AdminMenu()
            {
                while (true)
                {
                    Console.WriteLine("\nBank Management Menu");
                    Console.WriteLine("---------------------");
                    Console.WriteLine("1. Display all banks");
                    Console.WriteLine("2. Create Admin");
                    Console.WriteLine("3. Exit");
                    Console.Write("Enter your choice: ");

                    try
                    {
                        int choice = Convert.ToInt32(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                BankManager.DisplayBanks();
                                break;
                            case 2:
                                if (!isAdminAdded)
                                {
                                    isAdminAdded = true;
                                    HireAdmin();
                                }
                                else
                                {
                                    Console.WriteLine("An admin has already been added.");
                                    HireStaff();
                                }
                                break;
                            case 3:
                                Console.WriteLine("Exiting...");
                                return;
                            default:
                                Console.WriteLine("Invalid choice. Please try again.");
                                break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Invalid input. The number is too large or too small.");
                    }
                }
            }

            private static void HireAdmin()
            {
                Console.WriteLine("Enter admin username:");
                string username = Console.ReadLine();

                if (!IsValidInput(username))
                {
                    Console.WriteLine("Invalid username. Please enter only alphabets.");
                    return;
                }

                if (adminUsernames.Contains(username))
                {
                    Console.WriteLine("Admin username already exists. Please choose a different username.");
                    return;
                }

                Console.WriteLine("Enter admin password:");
                string password = Console.ReadLine();

                if (adminPasswords.Contains(password))
                {
                    Console.WriteLine("Admin password already exists. Please choose a different password.");
                    return;
                }

                adminUsernames.Add(username);
                adminPasswords.Add(password);

                Console.WriteLine("Admin hired successfully.");
            }

            private static void HireStaff()
            {
                while (true)
                {
                    Console.WriteLine("Hiring a staff !!");
                    Console.WriteLine("Enter staff username:");
                    string username = Console.ReadLine();

                    if (!IsValidInput(username))
                    {
                        Console.WriteLine("Invalid username. Please enter only alphabets.");
                        continue;
                    }

                    if (staffUsernames.Contains(username) || adminUsernames.Contains(username))
                    {
                        Console.WriteLine("Username already exists. Please choose a different username.");
                        continue;
                    }

                    Console.WriteLine("Enter staff password:");
                    string password = Console.ReadLine();

                    if (staffPasswords.Contains(password) || adminPasswords.Contains(password))
                    {
                        Console.WriteLine("Password already exists. Please choose a different password.");
                        continue;
                    }

                    staffUsernames.Add(username);
                    staffPasswords.Add(password);

                    AccountDetails.AddStaffAccount(username, password);

                    Console.WriteLine("Staff hired successfully.");

                    Console.WriteLine("Do you want to add more staff? (Y/N):");
                    string response = Console.ReadLine();
                    if (response.ToUpper() != "Y")
                    {
                        break;
                    }
                }
            }

            private static bool IsValidInput(string input)
            {
                return Regex.IsMatch(input, "^[a-zA-Z]+$");
            }
        }
    }
}
