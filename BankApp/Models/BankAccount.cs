﻿using BankApp.SetupNewBank;
using System.Collections.Generic;

namespace BankApp.Models
{
    internal class Account 
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string AccountNumber { get; set; }
        public AccountType Type { get; set; }
        public BankService Bank { get; set; }
        public decimal AccountBalance { get; set; }
        public List<string> TransactionHistory { get; set; }
        public string LinkedAccountNumber { get; set; }
    }

    internal enum AccountType
    {
        Savings,
        Salary
    }

}
