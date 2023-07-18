using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AccountHolder
{
    internal class UserLogin
    {
        public class LoginAsAccountHolder
        {          
            public static void AccountHolder()
            {
                Console.WriteLine("Login as Account Holder");
                Console.WriteLine("Enter your username:");
                string username = Console.ReadLine();

                Console.WriteLine("Enter your password:");
                string password = Console.ReadLine();
                if (ValidateCredentials(username, password))
                {
                    Console.WriteLine("Login successful. Welcome, " + username + "!");
                    Console.WriteLine("Select an action:");
                    Console.WriteLine("1. Deposit amount");
                    Console.WriteLine("2. Withdraw amount");
                    Console.WriteLine("3. Transfer funds");
                    Console.WriteLine("4. View transaction history");
                    Console.WriteLine();

                    int action = int.Parse(Console.ReadLine());
                    UserAccount.PerformAccountHolderAction(action);
                }
                else
                {
                    Console.WriteLine("Invalid username or password. Please try again.");
                }
            }
        }

        static bool ValidateCredentials(string username, string password)
        {
            
            return username == "user" && password == "password";
        }

    }
    }

