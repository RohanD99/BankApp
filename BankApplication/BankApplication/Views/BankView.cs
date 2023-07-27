using System;
using System.Collections.Generic;
using System.Linq;
using BankApplication.Common;
using BankApplication.Models;
using BankApplication.Services;
using static BankApplication.Common.Enums;

namespace BankApplication.Views
{
    public class BankView
    {
        BankService bankService = new BankService();
        EmployeeService employeeService = new EmployeeService(); 
        UserService userService = new UserService();
        UserView userview = new UserView();
        Employee newEmployee = new Employee();
        public void Initialize()
        {          
            try
            {
                MainMenuOption option;
                do
                {
                    List<string> mainMenuOptions = Enum.GetNames(typeof(MainMenuOption)).ToList();
                    Utility.GenerateOptions(mainMenuOptions);
                    option = (MainMenuOption)Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case MainMenuOption.CreateNewBank:
                            CreateNewBank();
                            break;
                        case MainMenuOption.LoginAsAccountHolder:
                            
                            Account account = new Account();
                            
                            userview.UserAccountMenu(account);
                            break;                         
                        case MainMenuOption.LoginAsBankStaff:
                            string bankID = Console.ReadLine();
                            SetupBankAdmin(bankID);
                            EmployeeView.BankStaffMenu();
                            break;
                        case MainMenuOption.Exit:
                            Console.WriteLine("Thank you for Visiting...");
                            Environment.Exit(Environment.ExitCode);
                            break;
                        default:
                            Console.WriteLine("Please enter a valid input.");
                            this.Initialize();
                            break;
                    }
                } while (option != MainMenuOption.Exit);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please enter valid input.");
                this.Initialize();
            }
        }

        private void CreateNewBank()
        {
            
            Bank bank = new Bank()
            {
                BankName = Utility.ReadStringInput("Enter Bank Name", true),
                Location = Utility.ReadStringInput("Enter Location", true),
                IFSC = Utility.ReadStringInput("Enter IFSC code", true),
                IMPSforOtherBank = 6,
                IMPSforSameBank = 5,
                RTGSforOtherBank = 2,
                RTGSforSameBank = 0
            };

            var response = bankService.CreateBank(bank);
            Console.WriteLine(response.Message);
            if (!response.IsSuccess)
            {
                CreateNewBank();
            }
            else
            {
               SetupBankAdmin(response.Data);
               
            }
        }

        private void SetupBankAdmin(string bankID)
        {
            Employee employee = new Employee()
            {
                BankId = bankID,
                Name = Utility.ReadStringInput("Enter Name", true),
                Password = Utility.ReadStringInput("Enter Password", true),
                UserName = Utility.ReadStringInput("Enter User Name", true),
                Type = Enums.UserType.Admin
            };
            this.employeeService.CreateEmployee(employee);
            Console.WriteLine("Admin added successfully");
        }

        public void AddUser()
        {
            User user = new User()
            {
                UserName = Utility.ReadStringInput("Enter username", true),
                Password = Utility.ReadStringInput("Enter password", true)
            };
            userService.CreateUser(user);
        }
    }
}

