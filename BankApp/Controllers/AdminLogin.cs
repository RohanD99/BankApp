using System;
using System.Text.RegularExpressions;

namespace BankApp.SetupNewBank
{
    internal class AdminLogin
    {
        private static bool isAdminAdded = false;

        public class AdminVerification
        {
            public static void AdminMenu()
            {
                while (true)
                {
                    Console.WriteLine("---------------------");
                    Console.WriteLine("1. Create Admin");
                    Console.WriteLine("2. Exit");
                    Console.Write("Enter your choice: ");

                    try
                    {
                        int choice = Convert.ToInt32(Console.ReadLine());

                        switch (choice)
                        {                            
                            case 1:
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
                            case 2:
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

                Console.WriteLine("Enter admin password:");
                string password = Console.ReadLine();
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

                    Console.WriteLine("Enter staff password:");
                    string password = Console.ReadLine();

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
