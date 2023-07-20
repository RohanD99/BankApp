using BankApp.BankStaff;
using System;

namespace BankApp.AccountHolder
{
        internal class UserLogin
        {
            public class LoginAsAccountHolder
            {
                private static string loggedInUsername = string.Empty;

                public static void AccountHolder()
                {
                    if (UserAccount.IsAccountHolderLoggedIn)
                    {
                        Console.WriteLine("You are already logged in as " + loggedInUsername);
                        DisplayAccountHolderOptions();
                    }
                    else
                    {
                        Console.WriteLine("Login as Account Holder");
                        int attempts = 3;
                        while (attempts > 0)
                        {
                            Console.WriteLine("Enter your username:");
                            string username = Console.ReadLine();

                            Console.WriteLine("Enter your password:");
                            string password = Console.ReadLine();

                            if (ValidateCredentials(username, password))
                            {
                                UserAccount.IsAccountHolderLoggedIn = true;
                                loggedInUsername = username;

                                Console.WriteLine("Login successful. Welcome, " + username + "!");
                                DisplayAccountHolderOptions();
                                break;
                            }
                            else
                            {
                                attempts--;
                                Console.WriteLine($"Invalid username or password. {attempts} attempts left.");
                            }
                        }

                        if (attempts == 0)
                        {
                            Console.WriteLine("Login failed. You've reached the maximum number of attempts.");
                        }
                    }
                }

                private static bool ValidateCredentials(string username, string password)
            {
                foreach (var account in AccountDetails.accounts)
                {
                    if (account.Username == username && account.Password == password)
                    {
                        return true;
                    }
                }

                return false;
            }

            private static int GetUserChoice()
            {
                int action;
                while (!int.TryParse(Console.ReadLine(), out action))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                return action;
            }

            private static void DisplayAccountHolderOptions()
            {
                while (true)
                {
                    Console.WriteLine("Select an action:");
                    Console.WriteLine("1. Deposit amount");
                    Console.WriteLine("2. Withdraw amount");
                    Console.WriteLine("3. Transfer funds");
                    Console.WriteLine("4. Check Balance");
                    Console.WriteLine("5. View transaction history");
                    Console.WriteLine("6. Go back to start");
                    Console.WriteLine();

                    int action = GetUserChoice();
                    if (action == 6)
                    {
                        Console.WriteLine("Going back to start...");
                        UserAccount.IsAccountHolderLoggedIn = false;
                        break;
                    }
                    UserAccount.PerformAccountHolderAction(action);
                }
            }
        }
    }
}
