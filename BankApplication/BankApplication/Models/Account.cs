using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Models
{
        public class Account : User
        {
            public string AccountNumber { get; set; }
            public string AccountHolderName { get; set; }
            public decimal Balance { get; set; }
            public string AccountType { get;  set; }
        }
}

