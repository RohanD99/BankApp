using BankApp.BankStaff;
using BankApp.Views;
using System;

namespace BankApp.AccountHolder
{
        internal class UserLoginService
        {
            public class LoginAsAccountHolder
            {
                private static string loggedInUsername = string.Empty;
                public static void AccountHolder()
                {
                    if (UserAccountService.IsAccountHolderLoggedIn)
                    {
   
                        DisplayAccountHolderOptions();
                    }
                    else
                    {
                    AccountView.DisplayAsUser();
                        int attempts = 3;
                        while (attempts > 0)
                        {

                        string username = AccountView.GetUsername();
                        string password = AccountView.GetPassword();

                        if (ValidateCredentials(username, password))
                            {
                                UserAccountService.IsAccountHolderLoggedIn = true;
                                loggedInUsername = username;

                                AdminView.LoginSuccessful(username);
                                DisplayAccountHolderOptions();
                                break;
                            }
                            else
                            {
                                attempts--;
                                AdminView.DisplayInvalidCredentials();
                            }
                        }

                        if (attempts == 0)
                        {
                         AdminView.DisplayLoginFailed();
                        }
                    }
                }
            private static bool ValidateCredentials(string username, string password)
            {
                foreach (var account in AccountServices.accounts)
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
                    AdminView.DisplayInvalidInput();
                }
                return action;
            }

            private static void DisplayAccountHolderOptions()
            {
                while (true)
                {
                    AccountView.DisplayUserOperations();

                    int action = GetUserChoice();
                    if (action == 6)
                    {
                        AdminView.DisplayBackToStart();
                        UserAccountService.IsAccountHolderLoggedIn = false;
                        break;
                    }
                    UserAccountService userAccount = new UserAccountService();
                    userAccount.PerformAccountHolderAction(action);
                
                }
            }
        }
    }
}
