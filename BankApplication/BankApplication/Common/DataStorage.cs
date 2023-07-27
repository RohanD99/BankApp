using BankApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Common
{
    internal class DataStorage
    {
        public static List<Bank> Banks { get; set; } = new List<Bank>();                                 //storing banks
        public static List<Employee> Employees { get; set; } = new List<Employee>();                      //storing employees                       
        public static List<User> Users { get; set; } = new List<User>();
        public static List<Account> Accounts { get; set; } = new List<Account>();

        public static List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
