using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Models
{
    public class Transaction 
    {
        public string TransactionId { get; set; }
        public string AccountNumber { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool IsReverted { get; set; }
    }

    public enum TransactionType
    {
        Deposit,
        Withdrawal,
        FundTransfer
    }
}
