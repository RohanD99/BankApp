using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Views
{
    internal class AdminView
    {
        public static void DisplayAdminMenu()
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("1. Create Admin");
            Console.WriteLine("2. Exit");
            Console.Write("Enter your choice: ");
        }

        public static void DisplayAdminAlreadyAdded()
        {
            Console.WriteLine("An admin has already been added.");
        }

        public static void DisplayExiting()
        {
            Console.WriteLine("Exiting...");
        }

        public static void DisplayBackToStart()
        {
            Console.WriteLine("Going back to start...");
        }

        public static void DisplayInvalidChoice()
        {
            Console.WriteLine("Invalid choice. Please try again.");
        }

        public static void DisplayInvalidInput()
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }

        public static void DisplayInputOutOfRange()
        {
            Console.WriteLine("Invalid input. The number is too large or too small.");
        }

        public static void DisplayInvalidCredentials()
        {
            Console.WriteLine("Invalid credentials. Please enter only alphabets.");
        }

        public static void DisplayLoginFailed()
        {
            Console.WriteLine("Login failed. You've reached the maximum number of attempts.");
        }

        public static void DisplayAdminHiredSuccessfully()
        {
            Console.WriteLine("Admin hired successfully.");
        }

        public static void DisplayHiringStaff()
        {
            Console.WriteLine("Hiring a staff !!");
        }

        public static void DisplayEnterStaffUsername()
        {
            Console.WriteLine("Enter staff username:");
        }

        public static void DisplayStaffHiredSuccessfully()
        {
            Console.WriteLine("Staff hired successfully.");
        }

        public static void LoginSuccessful(string username)
        {
            Console.WriteLine("Login successful. Welcome, " + username + "!");
        }


    }
}

