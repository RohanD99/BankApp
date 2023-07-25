using BankApp.Views;
using System;
using System.Text.RegularExpressions;

namespace BankApp.SetupNewBank
{
    internal class AdminServices
    {
        private static bool isAdminAdded = false;

        public class AdminVerification
        {
            public static void AdminMenu()
            {
                while (true)
                {
                    AdminView.DisplayAdminMenu();

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
                                    AdminView.DisplayAdminAlreadyAdded();
                                    HireStaff();
                                }
                                break;
                            case 2:
                                AdminView.DisplayExiting();
                                return;
                            default:
                                AdminView.DisplayInvalidChoice();
                                break;
                        }
                    }
                    catch (FormatException)
                    {
                        AdminView.DisplayInvalidInput();
                    }
                    catch (OverflowException)
                    {
                        AdminView.DisplayInputOutOfRange();
                    }
                }
            }

            private static void HireAdmin()
            {
                string username = AccountView.GetUsername();

                if (!IsValidInput(username))
                {
                    AdminView.DisplayInvalidCredentials();
                    return;
                }

                string password = AccountView.GetPassword();
                AdminView.DisplayAdminHiredSuccessfully();
            }

            private static void HireStaff()
            {
                while (true)
                {
                    AdminView.DisplayHiringStaff();
                    string username = AccountView.GetUsername();

                    if (!IsValidInput(username))
                    {
                        AdminView.DisplayInvalidCredentials();
                        continue;
                    }

                    string password = AccountView.GetPassword();

                    AdminView.DisplayStaffHiredSuccessfully();

                }
            }

            private static bool IsValidInput(string input)
            {
                return Regex.IsMatch(input, "^[a-zA-Z]+$");
            }
        }
    }
}
